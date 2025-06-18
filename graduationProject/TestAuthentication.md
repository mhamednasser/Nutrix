# 🧪 JWT Authentication Testing Guide - Complete Security Implementation

## Overview
This guide shows how to test the comprehensive JWT authentication system that properly extracts user IDs from tokens instead of URL parameters. **All controllers are now secured** and use JWT token validation.

## 🚀 Test Flow

### 1. Register a New User
```bash
curl -X 'POST' \
  'http://localhost:5181/api/Auth/register' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "username": "testuser",
  "email": "test@example.com",
  "password": "TestPass123!"
}'
```

**Expected Response:**
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "refreshToken": "base64-string",
  "expiresAt": "2024-06-08T...",
  "user": {
    "id": "guid-string",
    "username": "testuser",
    "email": "test@example.com",
    "roles": []
  }
}
```

### 2. Extract the JWT Token
Copy the `token` value from the response - you'll need it for all authenticated requests.

### 3. Create User Profile (Authenticated)
```bash
curl -X 'POST' \
  'http://localhost:5181/api/user/profile' \
  -H 'accept: */*' \
  -H 'Authorization: Bearer YOUR_JWT_TOKEN_HERE' \
  -H 'Content-Type: application/json' \
  -d '{
  "age": 25,
  "gender": "Male",
  "height": 180,
  "weight": 75,
  "fitnessLevel": "Intermediate",
  "weeklyWorkoutDays": 4,
  "workoutDuration": 60,
  "goal": "Build Muscle",
  "dietaryRestrictions": "None",
  "preferredDiet": "Balanced",
  "medicalConditions": "None"
}'
```

### 4. Get User Profile (Authenticated)
```bash
curl -X 'GET' \
  'http://localhost:5181/api/user/profile' \
  -H 'accept: */*' \
  -H 'Authorization: Bearer YOUR_JWT_TOKEN_HERE'
```

### 5. Generate Diet Plan (Authenticated)
```bash
curl -X 'POST' \
  'http://localhost:5181/api/plan/diet' \
  -H 'accept: */*' \
  -H 'Authorization: Bearer YOUR_JWT_TOKEN_HERE'
```

### 6. Get Diet Plan (Authenticated)
```bash
curl -X 'GET' \
  'http://localhost:5181/api/plan/diet' \
  -H 'accept: */*' \
  -H 'Authorization: Bearer YOUR_JWT_TOKEN_HERE'
```

### 7. Generate Workout Plan (Authenticated)
```bash
curl -X 'POST' \
  'http://localhost:5181/api/plan/workout' \
  -H 'accept: */*' \
  -H 'Authorization: Bearer YOUR_JWT_TOKEN_HERE'
```

### 8. Get All Plans (Authenticated)
```bash
curl -X 'GET' \
  'http://localhost:5181/api/plan/all' \
  -H 'accept: */*' \
  -H 'Authorization: Bearer YOUR_JWT_TOKEN_HERE'
```

### 9. Food Detection - Scan Food (Authenticated)
```bash
curl -X 'POST' \
  'http://localhost:5181/api/FoodDetection/scan' \
  -H 'accept: */*' \
  -H 'Authorization: Bearer YOUR_JWT_TOKEN_HERE' \
  -F 'image=@path/to/your/food_image.jpg'
```

### 10. Get All Nutritional Info (Authenticated)
```bash
curl -X 'GET' \
  'http://localhost:5181/api/FoodDetection' \
  -H 'accept: */*' \
  -H 'Authorization: Bearer YOUR_JWT_TOKEN_HERE'
```

### 11. Get Muscle Groups (Authenticated)
```bash
curl -X 'GET' \
  'http://localhost:5181/api/MuscleGroups' \
  -H 'accept: */*' \
  -H 'Authorization: Bearer YOUR_JWT_TOKEN_HERE'
```

### 12. Get Exercises by Muscle Group (Authenticated)
```bash
curl -X 'GET' \
  'http://localhost:5181/api/Exercises/1' \
  -H 'accept: */*' \
  -H 'Authorization: Bearer YOUR_JWT_TOKEN_HERE'
```

## 🔒 Security Tests

### Test 1: Access Without Token (Should Fail for ALL endpoints)
```bash
# User Profile (should fail)
curl -X 'GET' \
  'http://localhost:5181/api/user/profile' \
  -H 'accept: */*'

# Plans (should fail)
curl -X 'GET' \
  'http://localhost:5181/api/plan/all' \
  -H 'accept: */*'

# Food Detection (should fail)
curl -X 'GET' \
  'http://localhost:5181/api/FoodDetection' \
  -H 'accept: */*'

# Muscle Groups (should fail)
curl -X 'GET' \
  'http://localhost:5181/api/MuscleGroups' \
  -H 'accept: */*'

# Exercises (should fail)
curl -X 'GET' \
  'http://localhost:5181/api/Exercises/1' \
  -H 'accept: */*'
```
**Expected:** `401 Unauthorized` for ALL endpoints

### Test 2: Access With Invalid Token (Should Fail)
```bash
curl -X 'GET' \
  'http://localhost:5181/api/user/profile' \
  -H 'accept: */*' \
  -H 'Authorization: Bearer invalid-token'
```
**Expected:** `401 Unauthorized`

### Test 3: Try to Access Another User's Data (Should Fail)
The old system allowed `/api/user/profile/{userId}` - now users can only access their own data.

## 📋 Updated API Endpoints

### User Management (All require authentication)
- `POST /api/user/profile` - Create profile for authenticated user
- `GET /api/user/profile` - Get authenticated user's profile  
- `PUT /api/user/profile` - Update authenticated user's profile
- `DELETE /api/user/profile` - Delete authenticated user's profile

### Plan Management (All require authentication)
- `POST /api/plan/diet` - Generate diet plan for authenticated user
- `GET /api/plan/diet` - Get authenticated user's diet plan
- `DELETE /api/plan/diet` - Delete authenticated user's diet plan
- `POST /api/plan/workout` - Generate workout plan for authenticated user
- `GET /api/plan/workout` - Get authenticated user's workout plan
- `DELETE /api/plan/workout` - Delete authenticated user's workout plan
- `GET /api/plan/all` - Get all plans for authenticated user

### Profile (All require authentication)
- `GET /api/profile` - Get authenticated user's complete profile with plans

### Food Detection (All require authentication) 🆕
- `POST /api/FoodDetection/scan` - Scan food image for authenticated user
- `GET /api/FoodDetection` - Get all nutritional info for authenticated user
- `GET /api/FoodDetection/{id}` - Get specific nutritional info for authenticated user
- `DELETE /api/FoodDetection/{id}` - Delete nutritional info for authenticated user

### Exercise Data (All require authentication) 🆕
- `GET /api/MuscleGroups` - Get all muscle groups (requires authentication)
- `GET /api/Exercises/{muscleGroupId}` - Get exercises by muscle group (requires authentication)

### Authentication (Public endpoints)
- `POST /api/Auth/register` - Register new user
- `POST /api/Auth/login` - Login user
- `POST /api/Auth/google-login` - Google OAuth login

## 🔧 Key Security Features

1. **JWT Token Extraction**: User ID is extracted from `ClaimTypes.NameIdentifier` in JWT token
2. **Universal Authorization**: ALL controllers except Auth use `[Authorize]` attribute
3. **User Validation**: Controllers validate that authenticated user matches requested data
4. **No URL User IDs**: User IDs are no longer exposed in URLs for any endpoints
5. **Consistent Error Handling**: Proper 401/403 responses for authentication/authorization failures
6. **Database Security**: NutritionalInfo now properly linked to UserProfile with foreign key constraints

## 🎯 What's Fixed

✅ **Token System**: Properly extracts user ID from JWT tokens in ALL controllers
✅ **Security**: Users can only access their own data across ALL endpoints
✅ **User Model**: Complete migration from old User to AppUser + UserProfile
✅ **Plan Generation**: Works with UserProfile instead of old User model
✅ **Authorization**: ALL endpoints require valid JWT tokens (except Auth)
✅ **Error Handling**: Proper authentication error responses across all controllers
✅ **DTO Security**: Removed UserId field from CreateUserProfileDto to prevent client manipulation
✅ **Food Detection**: Secured and updated to work with UserProfile instead of old User
✅ **Exercise Data**: Secured muscle groups and exercises endpoints
✅ **Database Integrity**: NutritionalInfo properly linked to UserProfile with cascading deletes
✅ **API Consistency**: All user-related endpoints follow same security pattern

## 🚨 Security Transformations

### Before (Insecure):
- ❌ User IDs in URL parameters
- ❌ No authentication on several controllers
- ❌ Mixed authentication patterns
- ❌ Client could specify user IDs in requests
- ❌ Direct database access without user validation

### After (Secure):
- ✅ User IDs extracted from JWT tokens only
- ✅ Universal authentication requirement
- ✅ Consistent security patterns across all controllers
- ✅ Server-side user ID determination only
- ✅ All data access validates authenticated user ownership

## 📊 Complete Security Coverage

**Secured Controllers**: 7/7 (100%)
- ✅ UserController 
- ✅ PlanController
- ✅ ProfileController
- ✅ FoodDetectionController
- ✅ ExercisesController
- ✅ MuscleGroupsController
- ✅ AuthController (public by design)

**JWT Integration**: Complete across all user-facing endpoints
**Database Security**: All user data properly isolated and protected 