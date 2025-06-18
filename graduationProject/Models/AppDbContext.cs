using graduationProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace graduationProject.Models
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSets
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<nExercise> nExercises { get; set; }
        public DbSet<MuscleGroup> MuscleGroups { get; set; }
        public DbSet<WorkoutPlan> WorkoutPlans { get; set; }
        public DbSet<DietPlan> DietPlans { get; set; }
        public DbSet<GeneratedDietPlan> GeneratedDietPlans { get; set; }
        public DbSet<GeneratedWorkoutPlan> GeneratedWorkoutPlans { get; set; }
        public DbSet<StructuredDietPlan> StructuredDietPlans { get; set; }
        public DbSet<StructuredWorkoutPlan> StructuredWorkoutPlans { get; set; }
        public DbSet<NutritionalInfo> NutritionalInfos { get; set; }
        
        // General Plans DbSets
        public DbSet<GeneralDietPlan> GeneralDietPlans { get; set; }
        public DbSet<GeneralWorkoutPlan> GeneralWorkoutPlans { get; set; }
        
        // Challenge Feature DbSets
        public DbSet<Challenge> Challenges { get; set; }
        public DbSet<ChallengeDayTask> ChallengeDayTasks { get; set; }
        public DbSet<UserChallengeProgress> UserChallengeProgress { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure AppUser - UserProfile relationship (One-to-One)
            modelBuilder.Entity<AppUser>()
                .HasOne(u => u.UserProfile)
                .WithOne(up => up.AppUser)
                .HasForeignKey<UserProfile>(up => up.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure UserProfile - StructuredDietPlan relationship (One-to-Many)
            modelBuilder.Entity<StructuredDietPlan>()
                .HasOne(sdp => sdp.UserProfile)
                .WithMany(up => up.StructuredDietPlans)
                .HasForeignKey(sdp => sdp.UserProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure UserProfile - StructuredWorkoutPlan relationship (One-to-Many)
            modelBuilder.Entity<StructuredWorkoutPlan>()
                .HasOne(swp => swp.UserProfile)
                .WithMany(up => up.StructuredWorkoutPlans)
                .HasForeignKey(swp => swp.UserProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure UserProfile - GeneratedDietPlan relationship (One-to-Many)
            modelBuilder.Entity<GeneratedDietPlan>()
                .HasOne(gdp => gdp.UserProfile)
                .WithMany()
                .HasForeignKey(gdp => gdp.UserProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure UserProfile - GeneratedWorkoutPlan relationship (One-to-Many)
            modelBuilder.Entity<GeneratedWorkoutPlan>()
                .HasOne(gwp => gwp.UserProfile)
                .WithMany()
                .HasForeignKey(gwp => gwp.UserProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure UserProfile - NutritionalInfo relationship (One-to-Many)
            modelBuilder.Entity<NutritionalInfo>()
                .HasOne(ni => ni.UserProfile)
                .WithMany()
                .HasForeignKey(ni => ni.UserProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure nExercise - MuscleGroup relationship (Many-to-One)
            modelBuilder.Entity<nExercise>()
                .HasOne(e => e.MuscleGroup)
                .WithMany(mg => mg.nExercises)
                .HasForeignKey(e => e.MuscleGroupId)
                .OnDelete(DeleteBehavior.Restrict);

            // ===== CHALLENGE FEATURE RELATIONSHIPS =====
            
            // Configure Challenge - ChallengeDayTask relationship (One-to-Many)
            modelBuilder.Entity<ChallengeDayTask>()
                .HasOne(cdt => cdt.Challenge)
                .WithMany(c => c.DayTasks)
                .HasForeignKey(cdt => cdt.ChallengeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure UserProfile - UserChallengeProgress relationship (One-to-Many)
            modelBuilder.Entity<UserChallengeProgress>()
                .HasOne(ucp => ucp.UserProfile)
                .WithMany()
                .HasForeignKey(ucp => ucp.UserProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure Challenge - UserChallengeProgress relationship (One-to-Many)
            modelBuilder.Entity<UserChallengeProgress>()
                .HasOne(ucp => ucp.Challenge)
                .WithMany(c => c.UserProgress)
                .HasForeignKey(ucp => ucp.ChallengeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed data for MuscleGroups
            modelBuilder.Entity<MuscleGroup>().HasData(
                new MuscleGroup { Id = 1, Name = "ARM" },
                new MuscleGroup { Id = 2, Name = "Chest" },
                new MuscleGroup { Id = 3, Name = "ABS" },
                new MuscleGroup { Id = 4, Name = "LEG" },
                new MuscleGroup { Id = 5, Name = "Back & Shoulder" },
                new MuscleGroup { Id = 6, Name = "Stretches" }
            );

            // ===== CHALLENGE FEATURE SEED DATA =====
            
            // Seed default challenge
            modelBuilder.Entity<Challenge>().HasData(
                new Challenge
                {
                    Id = 1,
                    ChallengeTitle = "Healthy Habits Challenge",
                    Description = "A 4-level challenge to build better daily habits.",
                    CreatedAt = new DateTime(2024, 1, 1),
                    UpdatedAt = new DateTime(2024, 1, 1)
                }
            );

            // Seed challenge day tasks (28 days total)
            SeedChallengeDayTasks(modelBuilder);

            // ===== GENERAL PLANS SEED DATA =====
            
            // Seed General Diet Plans
            modelBuilder.Entity<GeneralDietPlan>().HasData(graduationProject.Data.DietPlanSeedData.GetDietPlans());
            
            // Seed General Workout Plans  
            modelBuilder.Entity<GeneralWorkoutPlan>().HasData(graduationProject.Data.WorkoutPlanSeedData.GetWorkoutPlans());

            // Seed data for nExercises
            modelBuilder.Entity<nExercise>().HasData(
                new nExercise { Id = 1, Name = "Overhead Extension", Sets = "3*12", VideoUrl = "https://www.youtube.com/embed/3DH2fwV5u1k", Icon = "https://img.youtube.com/vi/3DH2fwV5u1k/maxresdefault.jpg", MuscleGroupId = 1 },
                new nExercise { Id = 2, Name = "Dumbbell Press", Sets = "3*10", VideoUrl = "https://www.youtube.com/embed/SNFj4cBJ6ds", Icon = "https://img.youtube.com/vi/SNFj4cBJ6ds/maxresdefault.jpg", MuscleGroupId = 1 },
                new nExercise { Id = 3, Name = "Tricep Dips", Sets = "3*10", VideoUrl = "https://www.youtube.com/embed/tPAkjMLWvCY", Icon = "https://img.youtube.com/vi/tPAkjMLWvCY/maxresdefault.jpg", MuscleGroupId = 1 },
                new nExercise { Id = 4, Name = "Dumbbell Pullover", Sets = "3*12", VideoUrl = "https://www.youtube.com/embed/sz_BVxduUWE", Icon = "https://img.youtube.com/vi/sz_BVxduUWE/maxresdefault.jpg", MuscleGroupId = 1 },
                new nExercise { Id = 5, Name = "Concentration Curl", Sets = "3*12", VideoUrl = "https://www.youtube.com/embed/dsRNsZHuUkw", Icon = "https://img.youtube.com/vi/dsRNsZHuUkw/maxresdefault.jpg", MuscleGroupId = 1 },
                new nExercise { Id = 6, Name = "Cable Reverse", Sets = "3*10", VideoUrl = "https://www.youtube.com/embed/BneGVmsYBTY", Icon = "https://img.youtube.com/vi/BneGVmsYBTY/maxresdefault.jpg", MuscleGroupId = 1 },
                new nExercise { Id = 7, Name = "Cable Crossovers", Sets = "3*12", VideoUrl = "https://www.youtube.com/embed/KVT2n9CpqRU", Icon = "https://img.youtube.com/vi/KVT2n9CpqRU/maxresdefault.jpg", MuscleGroupId = 2 },
                new nExercise { Id = 8, Name = "Chest Press", Sets = "3*10", VideoUrl = "https://www.youtube.com/embed/W1qukYP2FLA", Icon = "https://img.youtube.com/vi/W1qukYP2FLA/maxresdefault.jpg", MuscleGroupId = 2 },
                new nExercise { Id = 9, Name = "Dumbbell Chest", Sets = "3*10", VideoUrl = "https://www.youtube.com/embed/WU_AUjGaHnM", Icon = "https://img.youtube.com/vi/WU_AUjGaHnM/maxresdefault.jpg", MuscleGroupId = 2 },
                new nExercise { Id = 10, Name = "Dumbbell Fly", Sets = "3*12", VideoUrl = "https://www.youtube.com/embed/OAps0BeSd7Y", Icon = "https://img.youtube.com/vi/OAps0BeSd7Y/maxresdefault.jpg", MuscleGroupId = 2 },
                new nExercise { Id = 11, Name = "Band Bench Press", Sets = "3*12", VideoUrl = "https://www.youtube.com/embed/mATfjUjXr60", Icon = "https://img.youtube.com/vi/mATfjUjXr60/maxresdefault.jpg", MuscleGroupId = 2 },
                new nExercise { Id = 12, Name = "Weighted Crunch", Sets = "3*10", VideoUrl = "https://www.youtube.com/embed/WfFWsolPlP8", Icon = "https://img.youtube.com/vi/WfFWsolPlP8/maxresdefault.jpg", MuscleGroupId = 3 },
                new nExercise { Id = 13, Name = "Rotating Stomach", Sets = "3*12", VideoUrl = "https://www.youtube.com/embed/cK2VIjqK4PY?si=-JIDMS5GRjBU_2PI", Icon = "https://img.youtube.com/vi/cK2VIjqK4PY/maxresdefault.jpg", MuscleGroupId = 3 },
                new nExercise { Id = 14, Name = "Cable Crunch", Sets = "3*10", VideoUrl = "https://www.youtube.com/embed/iZOAVk8qjjU", Icon = "https://img.youtube.com/vi/iZOAVk8qjjU/maxresdefault.jpg", MuscleGroupId = 3 },
                new nExercise { Id = 15, Name = "Leg Reverse Crunch", Sets = "3*12", VideoUrl = "https://www.youtube.com/embed/jZYon72vEtU", Icon = "https://img.youtube.com/vi/jZYon72vEtU/maxresdefault.jpg", MuscleGroupId = 3 },
                new nExercise { Id = 16, Name = " Seated Crunch", Sets = "3*10", VideoUrl = "https://www.youtube.com/embed/-uQO2gG8sjk", Icon = "https://img.youtube.com/vi/-uQO2gG8sjk/maxresdefault.jpg", MuscleGroupId = 3 },
                new nExercise { Id = 17, Name = "Leg Curl", Sets = "3*10", VideoUrl = "https://www.youtube.com/embed/1SaYpphpQ5w", Icon = "https://img.youtube.com/vi/1SaYpphpQ5w/maxresdefault.jpg", MuscleGroupId = 4 },
                new nExercise { Id = 18, Name = "Low Bar Squat", Sets = "3*12", VideoUrl = "https://www.youtube.com/embed/weVucBtUl7I", Icon = "https://img.youtube.com/vi/weVucBtUl7I/maxresdefault.jpg", MuscleGroupId = 4 },
                new nExercise { Id = 19, Name = "Smith Deadlift", Sets = "3*12", VideoUrl = "https://www.youtube.com/embed/aL3VFTD_4ew", Icon = "https://img.youtube.com/vi/aL3VFTD_4ew/maxresdefault.jpg", MuscleGroupId = 4 },
                new nExercise { Id = 20, Name = "Leg Press", Sets = "3*10", VideoUrl = "https://www.youtube.com/embed/myNurJqfgDc", Icon = "https://img.youtube.com/vi/myNurJqfgDc/maxresdefault.jpg", MuscleGroupId = 4 },
                new nExercise { Id = 21, Name = "Standing Calf Raises", Sets = "3*10", VideoUrl = "https://www.youtube.com/embed/qvCOYW80akQ", Icon = "https://img.youtube.com/vi/qvCOYW80akQ/maxresdefault.jpg", MuscleGroupId = 4 },
                new nExercise { Id = 22, Name = "Hip Abduction", Sets = "3*12", VideoUrl = "https://www.youtube.com/embed/33sUKgU3yjI", Icon = "https://img.youtube.com/vi/33sUKgU3yjI/maxresdefault.jpg", MuscleGroupId = 4 },
                new nExercise { Id = 23, Name = "Hip Thrusts", Sets = "3*10", VideoUrl = "https://www.youtube.com/embed/hghkuX7ejVo", Icon = "https://img.youtube.com/vi/hghkuX7ejVo/maxresdefault.jpg", MuscleGroupId = 4 },
                new nExercise { Id = 24, Name = "Barbell Lunge", Sets = "3*10", VideoUrl = "https://www.youtube.com/embed/2Zbv0h5OA3I", Icon = "https://img.youtube.com/vi/2Zbv0h5OA3I/maxresdefault.jpg", MuscleGroupId = 4 },
                new nExercise { Id = 25, Name = "Cable Elevated Row", Sets = "3*12", VideoUrl = "https://www.youtube.com/embed/EQZvNNjCCPM", Icon = "https://img.youtube.com/vi/EQZvNNjCCPM/maxresdefault.jpg", MuscleGroupId = 5 },
                new nExercise { Id = 26, Name = "Cable Arm Pulldown", Sets = "3*10", VideoUrl = "https://www.youtube.com/embed/T-wcu8iRSW4", Icon = "https://img.youtube.com/vi/T-wcu8iRSW4/maxresdefault.jpg", MuscleGroupId = 5 },
                new nExercise { Id = 27, Name = "Reverse Fly", Sets = "3*12", VideoUrl = "https://www.youtube.com/embed/XsN8glqhebU", Icon = "https://img.youtube.com/vi/XsN8glqhebU/maxresdefault.jpg", MuscleGroupId = 5 },
                new nExercise { Id = 28, Name = "Lying T Bar Back", Sets = "3*10", VideoUrl = "https://www.youtube.com/embed/LGjNc2nKYsk", Icon = "https://img.youtube.com/vi/LGjNc2nKYsk/maxresdefault.jpg", MuscleGroupId = 5 },
                new nExercise { Id = 29, Name = "Cable Pulldown", Sets = "3*12", VideoUrl = "https://www.youtube.com/embed/imkOFyqxNUc", Icon = "https://img.youtube.com/vi/imkOFyqxNUc/maxresdefault.jpg", MuscleGroupId = 5 },
                new nExercise { Id = 30, Name = "Dumbbell Press", Sets = "3*10", VideoUrl = "https://www.youtube.com/embed/anxZfYAXmsY", Icon = "https://img.youtube.com/vi/anxZfYAXmsY/maxresdefault.jpg", MuscleGroupId = 5 },
                new nExercise { Id = 31, Name = "Cuban Press", Sets = "3*12", VideoUrl = "https://www.youtube.com/embed/U79gWoPFNMU", Icon = "https://img.youtube.com/vi/U79gWoPFNMU/maxresdefault.jpg", MuscleGroupId = 5 },
                new nExercise { Id = 32, Name = "Raise Plate", Sets = "3*10", VideoUrl = "https://www.youtube.com/embed/BEazZDwwns0", Icon = "https://img.youtube.com/vi/BEazZDwwns0/maxresdefault.jpg", MuscleGroupId = 5 },
                new nExercise { Id = 33, Name = "Lying Cross Over", Sets = "3*12", VideoUrl = "https://www.youtube.com/embed/YkvgWqV9SuU", Icon = "https://img.youtube.com/vi/YkvgWqV9SuU/maxresdefault.jpg", MuscleGroupId = 6 },
                new nExercise { Id = 34, Name = "Crouching Heel Stretch", Sets = "3*10", VideoUrl = "https://www.youtube.com/embed/UzLl2wWApDM", Icon = "https://img.youtube.com/vi/UzLl2wWApDM/maxresdefault.jpg", MuscleGroupId = 6 },
                new nExercise { Id = 35, Name = "Kneeling Toe Up Stretch", Sets = "3*10", VideoUrl = "https://www.youtube.com/embed/1qVP0Sz-jhE", Icon = "https://img.youtube.com/vi/1qVP0Sz-jhE/maxresdefault.jpg", MuscleGroupId = 6 },
                new nExercise { Id = 36, Name = "Single Lean Back Stretch", Sets = "3*10", VideoUrl = "https://www.youtube.com/embed/sJ7FLxLCqe8", Icon = "https://img.youtube.com/vi/sJ7FLxLCqe8/maxresdefault.jpg", MuscleGroupId = 6 },
                new nExercise { Id = 37, Name = "Back Pec Stretch", Sets = "3*10", VideoUrl = "https://www.youtube.com/embed/W-4JfmbiEl8", Icon = "https://img.youtube.com/vi/W-4JfmbiEl8/maxresdefault.jpg", MuscleGroupId = 6 }
            );
        }

        private void SeedChallengeDayTasks(ModelBuilder modelBuilder)
        {
            var dayTasks = new List<ChallengeDayTask>();

            // Level 1: Days 1-7
            dayTasks.AddRange(new[]
            {
                new ChallengeDayTask { Id = 1, ChallengeId = 1, DayNumber = 1, Level = 1, Title = "Drink More Water", Description = "Drink at least 8 cups of water today.", Tip = "Keep a water bottle with you at all times." },
                new ChallengeDayTask { Id = 2, ChallengeId = 1, DayNumber = 2, Level = 1, Title = "Walk 20 Minutes", Description = "Take a brisk 20-minute walk.", Tip = "Walking after meals improves digestion." },
                new ChallengeDayTask { Id = 3, ChallengeId = 1, DayNumber = 3, Level = 1, Title = "Sleep 8 Hours", Description = "Ensure you get at least 8 hours of sleep.", Tip = "Avoid screens 1 hour before bed." },
                new ChallengeDayTask { Id = 4, ChallengeId = 1, DayNumber = 4, Level = 1, Title = "Eat Vegetables", Description = "Add at least 2 servings of vegetables to your meals.", Tip = "Try a new vegetable today." },
                new ChallengeDayTask { Id = 5, ChallengeId = 1, DayNumber = 5, Level = 1, Title = "Meditate", Description = "Meditate for 10 minutes to reduce stress.", Tip = "Use a guided meditation app if needed." },
                new ChallengeDayTask { Id = 6, ChallengeId = 1, DayNumber = 6, Level = 1, Title = "No Sugar Day", Description = "Avoid added sugar for the whole day.", Tip = "Check food labels carefully." },
                new ChallengeDayTask { Id = 7, ChallengeId = 1, DayNumber = 7, Level = 1, Title = "Stretch", Description = "Do 10 minutes of full-body stretching.", Tip = "Focus on breathing while stretching." }
            });

            // Level 2: Days 8-14
            dayTasks.AddRange(new[]
            {
                new ChallengeDayTask { Id = 8, ChallengeId = 1, DayNumber = 8, Level = 2, Title = "Increase Water Intake", Description = "Drink at least 10 cups of water today.", Tip = "Add lemon for flavor variety." },
                new ChallengeDayTask { Id = 9, ChallengeId = 1, DayNumber = 9, Level = 2, Title = "Walk 30 Minutes", Description = "Take a brisk 30-minute walk or light jog.", Tip = "Try walking in a new location." },
                new ChallengeDayTask { Id = 10, ChallengeId = 1, DayNumber = 10, Level = 2, Title = "Quality Sleep", Description = "Sleep 8+ hours with good sleep hygiene.", Tip = "Keep your room cool and dark." },
                new ChallengeDayTask { Id = 11, ChallengeId = 1, DayNumber = 11, Level = 2, Title = "More Vegetables", Description = "Add 3 servings of vegetables to your meals.", Tip = "Include vegetables in every meal." },
                new ChallengeDayTask { Id = 12, ChallengeId = 1, DayNumber = 12, Level = 2, Title = "Extended Meditation", Description = "Meditate for 15 minutes.", Tip = "Try different meditation techniques." },
                new ChallengeDayTask { Id = 13, ChallengeId = 1, DayNumber = 13, Level = 2, Title = "Healthy Snacks", Description = "Choose only healthy snacks today.", Tip = "Prepare snacks in advance." },
                new ChallengeDayTask { Id = 14, ChallengeId = 1, DayNumber = 14, Level = 2, Title = "Yoga Flow", Description = "Do 15 minutes of yoga or stretching.", Tip = "Focus on flexibility and relaxation." }
            });

            // Level 3: Days 15-21
            dayTasks.AddRange(new[]
            {
                new ChallengeDayTask { Id = 15, ChallengeId = 1, DayNumber = 15, Level = 3, Title = "Hydration Challenge", Description = "Drink water before every meal.", Tip = "This helps with digestion and portion control." },
                new ChallengeDayTask { Id = 16, ChallengeId = 1, DayNumber = 16, Level = 3, Title = "Cardio Boost", Description = "Do 40 minutes of moderate cardio.", Tip = "Mix different activities to stay engaged." },
                new ChallengeDayTask { Id = 17, ChallengeId = 1, DayNumber = 17, Level = 3, Title = "Sleep Optimization", Description = "Create the perfect sleep environment.", Tip = "Remove all electronic devices from bedroom." },
                new ChallengeDayTask { Id = 18, ChallengeId = 1, DayNumber = 18, Level = 3, Title = "Plant-Based Day", Description = "Eat only plant-based foods today.", Tip = "Explore new plant-based recipes." },
                new ChallengeDayTask { Id = 19, ChallengeId = 1, DayNumber = 19, Level = 3, Title = "Mindfulness Practice", Description = "Practice mindfulness for 20 minutes.", Tip = "Try walking meditation outdoors." },
                new ChallengeDayTask { Id = 20, ChallengeId = 1, DayNumber = 20, Level = 3, Title = "Detox Day", Description = "Avoid processed foods completely.", Tip = "Focus on whole, natural foods." },
                new ChallengeDayTask { Id = 21, ChallengeId = 1, DayNumber = 21, Level = 3, Title = "Strength & Flexibility", Description = "Combine strength training with yoga.", Tip = "Balance is key to overall fitness." }
            });

            // Level 4: Days 22-28
            dayTasks.AddRange(new[]
            {
                new ChallengeDayTask { Id = 22, ChallengeId = 1, DayNumber = 22, Level = 4, Title = "Ultimate Hydration", Description = "Perfect your daily hydration routine.", Tip = "Track your intake and adjust as needed." },
                new ChallengeDayTask { Id = 23, ChallengeId = 1, DayNumber = 23, Level = 4, Title = "Peak Performance", Description = "Do your most challenging workout yet.", Tip = "Push your limits safely." },
                new ChallengeDayTask { Id = 24, ChallengeId = 1, DayNumber = 24, Level = 4, Title = "Recovery Focus", Description = "Prioritize rest and recovery.", Tip = "Listen to your body's needs." },
                new ChallengeDayTask { Id = 25, ChallengeId = 1, DayNumber = 25, Level = 4, Title = "Nutritional Excellence", Description = "Create the perfect nutrition day.", Tip = "Plan every meal mindfully." },
                new ChallengeDayTask { Id = 26, ChallengeId = 1, DayNumber = 26, Level = 4, Title = "Mind-Body Connection", Description = "Focus on the connection between mind and body.", Tip = "Combine meditation with movement." },
                new ChallengeDayTask { Id = 27, ChallengeId = 1, DayNumber = 27, Level = 4, Title = "Lifestyle Integration", Description = "Integrate all healthy habits seamlessly.", Tip = "Make healthy choices feel natural." },
                new ChallengeDayTask { Id = 28, ChallengeId = 1, DayNumber = 28, Level = 4, Title = "Challenge Complete", Description = "Celebrate your achievement and plan ahead.", Tip = "Reflect on your journey and set new goals." }
            });

            modelBuilder.Entity<ChallengeDayTask>().HasData(dayTasks);
        }
    }
}


