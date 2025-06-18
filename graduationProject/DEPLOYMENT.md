# 🚀 Nutrix API Deployment Guide

This guide covers deploying the Nutrix API to various cloud platforms.

## 📋 Prerequisites

- Docker installed
- Git installed
- Access to your cloud platform (Azure, AWS, or Google Cloud)
- Environment variables configured

## 🔐 Environment Variables Setup

Before deploying, you need to set up the following environment variables. Use the `env.example` file as a template:

```bash
# Copy the example file
cp env.example .env

# Edit with your actual values
# NEVER commit .env to version control!
```

### Required Environment Variables:

| Variable | Description | Example |
|----------|-------------|---------|
| `JWT_SECRET_KEY` | Secret key for JWT token generation | `your-super-secure-jwt-secret-key` |
| `GOOGLE_CLIENT_ID` | Google OAuth Client ID | `123456789-abcdef.apps.googleusercontent.com` |
| `GOOGLE_CLIENT_SECRET` | Google OAuth Client Secret | `GOCSPX-abcdefghijklmnop` |
| `GEMINI_AI_API_KEY` | Google Gemini AI API Key | `AIzaSy...` |
| `GOOGLE_PROJECT_ID` | Google Cloud Project ID | `my-project-id` |
| `GOOGLE_PROJECT_NUMBER` | Google Cloud Project Number | `123456789` |
| `GEMINI_PLAN_API_KEY` | Gemini Plan API Key | `AIzaSy...` |
| `GEMINI_CHATBOT_API_KEY` | Gemini ChatBot API Key | `AIzaSy...` |
| `DATABASE_CONNECTION_STRING` | Database connection string | `Server=...;Database=Nutrix;...` |
| `SENDER_EMAIL` | Email for notifications | `your-email@gmail.com` |
| `SENDER_PASSWORD` | Gmail app password | `abcd efgh ijkl mnop` |
| `FRONTEND_URL` | Frontend application URL | `https://your-frontend.com` |

## 🐳 Docker Deployment

### Local Docker Build

```bash
# Build the image
docker build -t nutrix-api .

# Run with environment file
docker run --env-file .env -p 8080:8080 nutrix-api
```

### Docker Compose

```bash
# Start all services (API + SQL Server)
docker-compose up -d

# View logs
docker-compose logs -f

# Stop services
docker-compose down
```

## ☁️ Cloud Platform Deployment

### Microsoft Azure

#### Azure Container Instances

```bash
# Create resource group
az group create --name nutrix-rg --location eastus

# Deploy container
az container create \
  --resource-group nutrix-rg \
  --name nutrix-api \
  --image your-registry/nutrix-api:latest \
  --dns-name-label nutrix-api \
  --ports 8080 \
  --environment-variables \
    ASPNETCORE_ENVIRONMENT=Production \
    JWT_SECRET_KEY="your-jwt-secret" \
    GOOGLE_CLIENT_ID="your-client-id"
    # ... add all other env vars
```

#### Azure App Service

```bash
# Create App Service plan
az appservice plan create --name nutrix-plan --resource-group nutrix-rg --sku B1 --is-linux

# Create web app
az webapp create --resource-group nutrix-rg --plan nutrix-plan --name nutrix-api --deployment-container-image-name your-registry/nutrix-api:latest

# Configure environment variables
az webapp config appsettings set --resource-group nutrix-rg --name nutrix-api --settings \
  ASPNETCORE_ENVIRONMENT=Production \
  JWT_SECRET_KEY="your-jwt-secret" \
  GOOGLE_CLIENT_ID="your-client-id"
```

### Amazon Web Services (AWS)

#### AWS Elastic Container Service (ECS)

1. Push image to ECR
2. Create ECS cluster
3. Create task definition with environment variables
4. Create service

#### AWS App Runner

```bash
# Create apprunner.yaml
cat > apprunner.yaml << EOF
version: 1.0
runtime: docker
build:
  commands:
    build:
      - echo Build started on `date`
      - docker build -t nutrix-api .
run:
  runtime-version: latest
  command: dotnet graduationProject.dll
  network:
    port: 8080
    env: PORT
  env:
    - name: ASPNETCORE_ENVIRONMENT
      value: Production
    - name: JWT_SECRET_KEY
      value: your-jwt-secret
EOF
```

### Google Cloud Platform (GCP)

#### Google Cloud Run

```bash
# Build and push to Container Registry
gcloud builds submit --tag gcr.io/your-project-id/nutrix-api

# Deploy to Cloud Run
gcloud run deploy nutrix-api \
  --image gcr.io/your-project-id/nutrix-api \
  --platform managed \
  --region us-central1 \
  --allow-unauthenticated \
  --set-env-vars ASPNETCORE_ENVIRONMENT=Production,JWT_SECRET_KEY=your-jwt-secret
```

## 🗄️ Database Setup

### Azure SQL Database

```bash
# Create Azure SQL Database
az sql server create --name nutrix-sql-server --resource-group nutrix-rg --location eastus --admin-user sqladmin --admin-password YourPassword123!

az sql db create --resource-group nutrix-rg --server nutrix-sql-server --name Nutrix --service-objective Basic
```

### AWS RDS

```bash
# Create RDS instance
aws rds create-db-instance \
  --db-instance-identifier nutrix-db \
  --db-instance-class db.t3.micro \
  --engine sqlserver-ex \
  --master-username admin \
  --master-user-password YourPassword123!
```

### Google Cloud SQL

```bash
# Create Cloud SQL instance
gcloud sql instances create nutrix-db --tier=db-f1-micro --region=us-central1
```

## 🔍 Health Checks & Monitoring

### Health Check Endpoint

The API includes health check endpoints:

- `/health` - Basic health check
- `/health/ready` - Readiness probe
- `/health/live` - Liveness probe

### Monitoring Setup

Configure monitoring for:
- API response times
- Database connection health
- External API calls (Gemini AI)
- Error rates and logs

## 🔒 Security Considerations

### Production Security Checklist

- [ ] All environment variables are set securely
- [ ] Database uses encrypted connections
- [ ] HTTPS is enforced
- [ ] API keys are rotated regularly
- [ ] CORS is properly configured
- [ ] Rate limiting is enabled
- [ ] Input validation is in place
- [ ] Logging excludes sensitive data

### Secrets Management

Use your cloud platform's secrets management:
- **Azure**: Azure Key Vault
- **AWS**: AWS Secrets Manager
- **GCP**: Google Secret Manager

## 🚦 CI/CD Pipeline

### GitHub Actions Example

```yaml
name: Deploy to Cloud

on:
  push:
    branches: [ main ]

jobs:
  deploy:
    runs-on: ubuntu-latest
    steps:
    - uses: actions/checkout@v2
    
    - name: Build Docker image
      run: docker build -t nutrix-api .
    
    - name: Deploy to Cloud
      run: |
        # Add your cloud deployment commands here
```

## 📈 Scaling Considerations

### Performance Optimization

- Enable response caching
- Use connection pooling
- Implement async patterns
- Configure load balancing
- Set up auto-scaling rules

### Database Scaling

- Configure read replicas
- Implement connection pooling
- Use database indexing
- Consider caching strategies

## 🐛 Troubleshooting

### Common Issues

1. **Environment Variables Not Loading**
   - Check variable names match exactly
   - Ensure values are properly escaped
   - Verify platform-specific syntax

2. **Database Connection Failures**
   - Check connection string format
   - Verify firewall rules
   - Ensure database is running

3. **API Integration Issues**
   - Verify API keys are valid
   - Check rate limits
   - Monitor external service status

### Logs and Debugging

```bash
# View container logs
docker logs nutrix-api

# View cloud service logs
# Azure: az webapp log tail --name nutrix-api --resource-group nutrix-rg
# AWS: aws logs tail /aws/apprunner/nutrix-api
# GCP: gcloud logging tail
```

## 📞 Support

For deployment issues:
1. Check the logs first
2. Verify all environment variables
3. Test with minimal configuration
4. Contact the development team

---

**Happy Deploying! 🚀** 