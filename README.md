# 🏃‍♂️ Nutrix - AI-Powered Fitness & Nutrition Platform

<div align="center">

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://asp.net/)
[![Entity Framework](https://img.shields.io/badge/Entity%20Framework-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://docs.microsoft.com/en-us/ef/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white)](https://www.microsoft.com/en-us/sql-server)

[![Docker](https://img.shields.io/badge/Docker-2496ED?style=for-the-badge&logo=docker&logoColor=white)](https://www.docker.com/)
[![Google Gemini](https://img.shields.io/badge/Google%20Gemini%20AI-4285F4?style=for-the-badge&logo=google&logoColor=white)](https://ai.google.dev/)
[![JWT](https://img.shields.io/badge/JWT-000000?style=for-the-badge&logo=JSON%20web%20tokens&logoColor=white)](https://jwt.io/)
[![Swagger](https://img.shields.io/badge/Swagger-85EA2D?style=for-the-badge&logo=swagger&logoColor=black)](https://swagger.io/)

</div>

---

## 🌟 **What is Nutrix?**

**Nutrix** is a cutting-edge AI-powered fitness and nutrition management platform that revolutionizes how people approach their health and wellness journey. Built with **.NET 8** and powered by **Google Gemini AI**, Nutrix combines advanced artificial intelligence with modern web technologies to deliver truly personalized health solutions.

<div align="center">

### 🎯 **Core Mission**
*Empowering individuals to achieve their optimal health through intelligent, data-driven, and personalized fitness & nutrition guidance*

</div>

---

## ✨ **Key Features & Capabilities**

### 🤖 **AI-Powered Intelligence**
- **🍽️ Smart Meal Planning** - AI generates personalized meal plans based on dietary preferences, restrictions, and goals
- **💪 Intelligent Workout Generation** - Custom fitness routines adapted to user's fitness level and equipment availability
- **🎯 Goal-Based Recommendations** - AI analyzes progress and suggests real-time optimizations
- **💬 24/7 AI Nutrition Assistant** - Intelligent chatbot for nutrition and fitness questions
- **📈 Predictive Analytics** - AI forecasts progress and suggests timeline adjustments
- **🧠 Personalization Engine** - AI learns from user behavior and adapts recommendations

### 💪 **Comprehensive Fitness Management**
- **📋 Custom Workout Plans** - Tailored routines for strength, cardio, flexibility, and sports-specific training
- **🏋️ Exercise Library** - Extensive database with detailed instructions, form tips, and video demonstrations
- **📊 Progress Tracking** - Visual analytics showing strength gains, endurance improvements, and body measurements
- **🎯 SMART Goal Framework** - Milestone tracking with achievement notifications
- **📅 Flexible Scheduling** - Workout planning with reminder notifications and calendar integration
- **🏆 Gamification System** - Badges, streaks, leaderboards, and rewards for motivation

### 🥗 **Advanced Nutrition Management**
- **🗄️ Comprehensive Food Database** - 500,000+ food items with complete nutritional information
- **🏷️ Smart Food Logging** - Barcode scanning, voice input, and photo-based food entry
- **🍽️ Recipe Management** - Create, save, and share custom recipes with nutritional analysis
- **🥘 AI Meal Planning** - Weekly meal plans optimized for goals and preferences
- **📊 Nutritional Intelligence** - Real-time macro/micro tracking with gap analysis
- **🚫 Dietary Support** - Comprehensive allergy, intolerance, and preference management

### 🔐 **Authentication & Security**
- **JWT Token Authentication** with refresh token support
- **Google OAuth 2.0** integration for seamless social login
- **Role-Based Authorization** (User, Admin, Trainer)
- **Secure Password Management** with BCrypt hashing
- **Session Management** with automatic token refresh
- **Enterprise-grade Security** with HTTPS, CORS, and rate limiting

### 📊 **Analytics & Insights**
- **📈 Progress Analytics** - Comprehensive tracking of all fitness and nutrition metrics
- **📊 Trend Analysis** - Long-term performance patterns and insights
- **🎯 Goal Achievement** - SMART goal tracking with milestone celebrations
- **🏆 Achievement System** - Gamification with badges and rewards
- **📋 Custom Reports** - Personalized health and progress reports

---

## 🏗️ **Technical Architecture**

### **Backend Technology Stack**

| Component | Technology | Purpose |
|-----------|------------|---------|
| **🏗️ Framework** | .NET 8 | High-performance, cross-platform development |
| **🌐 Web API** | ASP.NET Core | RESTful API development with modern features |
| **🗄️ Database** | Entity Framework Core | Advanced ORM with SQL Server/PostgreSQL |
| **🔐 Authentication** | JWT + OAuth 2.0 | Secure, stateless authentication system |
| **🤖 AI Integration** | Google Gemini AI | Advanced AI for personalization and recommendations |
| **📋 Validation** | FluentValidation | Comprehensive input validation and business rules |
| **🔄 Mapping** | AutoMapper | Efficient object-to-object mapping |
| **📊 Documentation** | Swagger/OpenAPI | Interactive API documentation |

### **Development & Deployment**

| Aspect | Technology | Features |
|--------|------------|----------|
| **🐳 Containerization** | Docker | Multi-stage builds, optimized images |
| **🚀 Orchestration** | Docker Compose | Complete development environment |
| **☁️ Cloud Deployment** | Azure, AWS, GCP | Production-ready cloud configurations |
| **📊 Monitoring** | Health Checks | Comprehensive application monitoring |
| **📝 Logging** | Structured Logging | Advanced logging with correlation IDs |
| **🔒 Security** | HTTPS, CORS, Rate Limiting | Enterprise-grade security measures |

---

## 📋 **API Endpoints Overview**

### **🔐 Authentication Endpoints**

| Endpoint | Method | Description | Response |
|----------|--------|-------------|----------|
| `/api/auth/register` | POST | User registration with email verification | JWT Token + User Profile |
| `/api/auth/login` | POST | User login with credentials | JWT Token + Refresh Token |
| `/api/auth/google-login` | POST | Google OAuth 2.0 authentication | JWT Token + Profile Data |
| `/api/auth/refresh-token` | POST | JWT token refresh | New JWT Token |
| `/api/auth/logout` | POST | Secure user logout | Success Confirmation |
| `/api/auth/forgot-password` | POST | Password reset request | Email Confirmation |

### **👤 User Management**
- `GET /api/users/profile` - Comprehensive user profile data with health metrics
- `PUT /api/users/profile` - Update profile and preferences with real-time validation
- `GET /api/users/dashboard` - Personalized dashboard with key metrics and activities
- `POST /api/users/goals` - Set new fitness and nutrition goals using SMART framework
- `GET /api/users/achievements` - User achievements, badges, and gamification data
- `POST /api/users/measurements` - Log body measurements for progress tracking

### **💪 Fitness & Exercise**
- `GET /api/exercises` - Browse exercise library with advanced filters (muscle group, equipment, difficulty)
- `POST /api/exercises` - Create custom exercises with detailed instructions and media
- `GET /api/workouts` - Retrieve user's workout plans and complete history
- `POST /api/workouts` - Create custom workout plans with exercise sequencing
- `POST /api/workouts/{id}/log` - Log workout completion with performance metrics
- `GET /api/workouts/suggestions` - AI-powered workout suggestions based on goals and progress

### **🥗 Nutrition & Meals**
- `GET /api/foods` - Search 500,000+ foods with nutritional filters
- `POST /api/meals/log` - Log meals with portion tracking and nutritional analysis
- `GET /api/nutrition/analysis` - Comprehensive nutritional insights and recommendations
- `POST /api/nutrition/goals` - Set macro/micro nutritional targets
- `GET /api/recipes` - Browse and search custom recipes
- `POST /api/recipes` - Create recipes with automatic nutritional calculation

### **🤖 AI-Powered Features**
- `POST /api/ai/meal-plan` - Generate personalized meal plans based on goals and preferences
- `POST /api/ai/workout-plan` - Create custom workout routines adapted to user's level
- `POST /api/ai/chat` - Chat with AI fitness and nutrition assistant
- `POST /api/ai/recommendations` - Get personalized suggestions based on progress
- `POST /api/ai/progress-analysis` - AI-powered progress evaluation and optimization

### **📊 Analytics & Reports**
- `GET /api/analytics/progress` - Detailed progress metrics and trend analysis
- `GET /api/analytics/trends` - Long-term performance patterns and insights
- `POST /api/reports/generate` - Generate personalized health and fitness reports
- `GET /api/analytics/goals` - Goal achievement statistics and milestone tracking

---

## 🚀 **Getting Started**

### **📋 Prerequisites**
- **.NET 8 SDK** or later
- **Visual Studio 2022** or **VS Code** (recommended)
- **SQL Server** (LocalDB, Express, or Full)
- **Git** for version control
- **Google Cloud Account** with Gemini AI API access
- **Google OAuth 2.0** credentials
- **Email service** (Gmail/SMTP)

### **⚡ Quick Setup Guide**

#### **1️⃣ Clone Repository**
```bash
git clone https://github.com/mhamednasser/Nutrix.git
cd Nutrix/graduationProject
```

#### **2️⃣ Configure Development Settings**
```bash
# Copy base configuration
cp appsettings.json appsettings.Development.json

# Add your real API keys and connection strings
# The .gitignore will protect your sensitive data
```

#### **3️⃣ Database Setup**
```bash
# Update database with latest migrations
dotnet ef database update

# Optional: Seed initial data
dotnet run --seed-data
```

#### **4️⃣ Run Application**
```bash
# Start the development server
dotnet run

# Or use hot reload for development
dotnet watch run
```

#### **5️⃣ Access Points**

| Service | URL | Description |
|---------|-----|-------------|
| **🌐 API** | `https://localhost:7243` | Main API endpoint |
| **📚 Swagger UI** | `https://localhost:7243/swagger` | Interactive API documentation |
| **🔍 Health Checks** | `https://localhost:7243/health` | Application health monitoring |

---

## 🐳 **Docker Deployment**

### **🚀 Quick Start with Docker**
```bash
# Start complete environment (API + Database)
docker-compose up -d

# View real-time logs
docker-compose logs -f nutrix-api

# Stop all services
docker-compose down
```

### **🏭 Production Deployment**
```bash
# Build optimized production image
docker build -t nutrix-api:latest .

# Run with environment configuration
docker run -d \
  --name nutrix-api \
  -p 8080:8080 \
  --env-file .env \
  nutrix-api:latest
```

---

## 📖 **Documentation & Resources**

- **📚 [API Documentation](swagger)** - Interactive Swagger/OpenAPI documentation
- **🚀 [Deployment Guide](DEPLOYMENT.md)** - Comprehensive deployment instructions for cloud platforms
- **⚙️ [Environment Setup](env.example)** - Configuration templates and environment variables
- **🐳 [Docker Guide](docker-compose.yml)** - Containerization and orchestration setup
- **💻 [Contributing Guidelines](CONTRIBUTING.md)** - Development workflow and contribution process
- **🔒 [Security Guidelines](SECURITY.md)** - Security best practices and guidelines

---

## 📊 **Project Statistics**

<div align="center">

| Metric | Value | Description |
|--------|-------|-------------|
| **🚀 Version** | `1.0.0` | Current stable release |
| **📅 Last Updated** | `January 2025` | Latest version date |
| **🛠️ Framework** | `.NET 8.0` | Microsoft's latest LTS |
| **📊 API Endpoints** | `50+` | Comprehensive API coverage |
| **🤖 AI Models** | `Google Gemini` | Advanced AI integration |
| **🗄️ Database** | `SQL Server/PostgreSQL` | Enterprise-grade storage |
| **🐳 Container Ready** | `✅` | Docker & Kubernetes support |
| **☁️ Cloud Platforms** | `Azure, AWS, GCP` | Multi-cloud deployment |

</div>

---

## 🤝 **Contributing**

We welcome contributions from the community! Here's how you can help make Nutrix even better:

### **🔧 Development Process**
1. **Fork** the repository
2. **Create** a feature branch (`git checkout -b feature/amazing-feature`)
3. **Implement** your changes with proper testing
4. **Commit** your changes (`git commit -m '✨ Add amazing feature'`)
5. **Push** to the branch (`git push origin feature/amazing-feature`)
6. **Submit** a pull request

### **📋 Contribution Areas**
- 🐛 **Bug fixes and improvements**
- ✨ **New feature development**
- 📚 **Documentation enhancements**
- 🧪 **Test coverage expansion**
- 🎨 **UI/UX improvements**
- 🌍 **Internationalization support**

---

## 👨‍💻 **Author & Team**

<div align="center">

### **Mohamed Nasser**
*Senior .NET Developer & AI Integration Specialist*

[![Email](https://img.shields.io/badge/Email-nasermohammed391%40gmail.com-red?style=for-the-badge&logo=gmail&logoColor=white)](mailto:nasermohammed391@gmail.com)
[![GitHub](https://img.shields.io/badge/GitHub-mhamednasser-black?style=for-the-badge&logo=github&logoColor=white)](https://github.com/mhamednasser)
[![LinkedIn](https://img.shields.io/badge/LinkedIn-Mohamed%20Nasser-blue?style=for-the-badge&logo=linkedin&logoColor=white)](https://linkedin.com/in/mhamednasser)

</div>

---

## 🙏 **Acknowledgments**

- **🤖 Google Gemini AI** - For providing powerful AI capabilities that make intelligent recommendations possible
- **🏗️ Microsoft .NET Team** - For the excellent .NET framework and development tools
- **🗄️ Entity Framework Core Team** - For seamless data access and ORM capabilities
- **🌐 ASP.NET Core Team** - For the robust and modern web framework
- **🐳 Docker Community** - For containerization technology that simplifies deployment
- **☁️ Cloud Providers** - For scalable hosting solutions and infrastructure
- **🎨 Open Source Community** - For tools, libraries, and inspiration
- **🧪 Beta Testers** - For valuable feedback and testing during development

---

## 📝 **License**

This project is licensed under the **MIT License** - see the [LICENSE](LICENSE) file for complete details.

---

<div align="center">

## 🌟 **Built with ❤️ using .NET 8 and Google Gemini AI**

### *Empowering healthy lifestyles through intelligent technology*

[![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![Google AI](https://img.shields.io/badge/Google%20AI-4285F4?style=for-the-badge&logo=google&logoColor=white)](https://ai.google.dev/)
[![Docker](https://img.shields.io/badge/Docker-2496ED?style=for-the-badge&logo=docker&logoColor=white)](https://www.docker.com/)

---

**⭐ Star this repository if you find it helpful! ⭐**

</div> 
