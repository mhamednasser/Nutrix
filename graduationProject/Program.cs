using graduationProject.Configurations;
using graduationProject.Interfaces;
using graduationProject.Models;
using graduationProject.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace graduationProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Clear default claim mappings to ensure proper JWT claim handling
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            // Bind configuration settings
            builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
            builder.Services.Configure<GoogleAuthSettings>(builder.Configuration.GetSection("GoogleAuth"));
            builder.Services.Configure<GeminiAISettings>(builder.Configuration.GetSection("GeminiAI"));
            builder.Services.Configure<GeminiPlanSettings>(builder.Configuration.GetSection("GeminiPlan"));
            builder.Services.Configure<GeminiChatBotSettings>(builder.Configuration.GetSection("GeminiChatBot"));
            builder.Services.Configure<FastAPISettings>(builder.Configuration.GetSection("FastAPISettings"));
            builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
            builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            
            // Configure Swagger with JWT Bearer token support
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Title = "Nutrix API", 
                    Version = "v1",
                    Description = "Fitness and Nutrition API with JWT Authentication and AI ChatBot"
                });

                // Add JWT Bearer Authentication to Swagger
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            // Register DbContext to use SQL Server with connection string from the configuration
            var databaseSettings = builder.Configuration.GetSection("DatabaseSettings").Get<DatabaseSettings>();
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(databaseSettings?.ConnectionString ?? throw new InvalidOperationException("Database connection string not found")));

            // Add Identity Services for user authentication and management
            builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 8;

                // User settings
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = false;
            })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            // Configure JWT Authentication
            var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();
            var key = Encoding.UTF8.GetBytes(jwtSettings?.SecretKey ?? throw new InvalidOperationException("JWT Secret Key not found"));

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ClockSkew = TimeSpan.Zero,
                    // Fix claim mapping issue
                    NameClaimType = ClaimTypes.Name,
                    RoleClaimType = ClaimTypes.Role
                };
            })
            .AddGoogle(options =>
            {
                var googleSettings = builder.Configuration.GetSection("GoogleAuth").Get<GoogleAuthSettings>();
                options.ClientId = googleSettings?.ClientId ?? string.Empty;
                options.ClientSecret = googleSettings?.ClientSecret ?? string.Empty;
            });

            // Add CORS (Cross-Origin Resource Sharing) to allow frontend communication
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            // Add memory caching for chat sessions
            builder.Services.AddMemoryCache();

            // Add HttpClient for making external requests
            builder.Services.AddHttpClient<PlanGenerationService>();

            // Add HttpClient for PythonApiService
            var fastApiSettings = builder.Configuration.GetSection("FastAPISettings").Get<FastAPISettings>();
            builder.Services.AddHttpClient<PythonApiService>(client =>
            {
                client.BaseAddress = new Uri(fastApiSettings?.Endpoint ?? "http://localhost:8000");
            });

            // Add HttpClient for GeminiService
            builder.Services.AddHttpClient<graduationProject.Services.GeminiService>();

            // Add HttpClient for GeminiPlanService (SPEED OPTIMIZED)
            builder.Services.AddHttpClient<GeminiPlanService>(client =>
            {
                client.Timeout = TimeSpan.FromSeconds(30); // Speed optimization
            });

            // Add HttpClient for ChatBotService (STREAMING OPTIMIZED)
            builder.Services.AddHttpClient<ChatBotService>(client =>
            {
                client.Timeout = TimeSpan.FromSeconds(30); // Optimized for streaming
            });

            // Register services
            builder.Services.AddScoped<IJwtService, JwtService>();
            builder.Services.AddScoped<IEmailService, EmailService>();
            builder.Services.AddScoped<graduationProject.Interfaces.IGeminiService, graduationProject.Services.GeminiService>();
            // SPEED UPGRADE: Using Gemini Flash 2.5 instead of Mock for 2-4x faster plan generation
            builder.Services.AddScoped<IPlanGenerationService, GeminiPlanService>();
            // NEW: ChatBot service with streaming support
            builder.Services.AddScoped<IChatBotService, ChatBotService>();
            // NEW: Challenge service for 28-day challenge feature
            builder.Services.AddScoped<IChallengeService, ChallengeService>();
            // NEW: General Plans services for diet and workout plans
            builder.Services.AddScoped<graduationProject.Repositories.IGeneralPlanRepository, graduationProject.Repositories.GeneralPlanRepository>();
            builder.Services.AddScoped<graduationProject.Services.IGeneralPlanService, graduationProject.Services.GeneralPlanService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
