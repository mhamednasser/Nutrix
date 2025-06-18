using graduationProject.Models;
using System.Text.Json;

namespace graduationProject.Data
{
    public static class WorkoutPlanSeedData
    {
        public static List<GeneralWorkoutPlan> GetWorkoutPlans()
        {
            return new List<GeneralWorkoutPlan>
            {
                new GeneralWorkoutPlan
                {
             
                    Name = "Full Body Beginner",
                    Category = "Strength",
                    Description = "Complete full-body workout designed for beginners to build strength, muscle, and confidence in the gym.",
                    ImageUrl = "https://cdn.mos.cms.futurecdn.net/taungfzgwFJdTaiuRJYbYE-970-80.jpg.webp",
                    Duration = 30,
                    ExerciseCount = 30,
                    Difficulty = "Beginner",
                    Goals = "Muscle Building,Strength,General Fitness",
                    CaloriesBurned = 350,
                    KeyFeatures = "Full Body,Compound Movements,Progressive Overload,3 Days Per Week",
                    Benefits = "Builds Foundation,Improves Strength,Increases Muscle Mass,Boosts Confidence",
                    TargetMuscles = "Full Body,Chest,Back,Legs,Arms,Core",
                    Equipment = "Dumbbells,Barbell,Bench,Bodyweight",
                    VideoUrl = "https://www.youtube.com/watch?v=R6gZoAzAhCg",
                    IsActive = true,  
                    CreatedAt = DateTime.UtcNow, 
                    UpdatedAt = DateTime.UtcNow,       
                    PlanDetailsJson = JsonSerializer.Serialize(new
                    {
                        days = new[]
                        {
                            new
                            {
                                day = 1,
                                name = "Day 1 - Full Body A",
                                exercises = new[]
                                {
                                    new
                                    {
                                        id = 1,
                                        name = "Bodyweight Squats",
                                        imageUrl = "https://thefitnessphantom.com/wp-content/uploads/2020/07/Bodyweight-Squat-Exercise.jpg",
                                        videoUrl = "https://www.youtube.com/shorts/eFEVKmp3M4g",
                                        sets = 3,
                                        reps = 12,
                                        duration = 0,
                                        restTime = 60,
                                        targetMuscle = "Legs,Glutes",
                                        equipment = "Bodyweight",
                                        difficulty = "Beginner",
                                        instructions = new[] { "Stand with feet shoulder-width apart", "Lower down as if sitting in a chair", "Keep chest up and knees tracking over toes", "Push through heels to return to start" },
                                        tips = new[] { "Keep weight in your heels", "Don't let knees cave inward", "Go only as low as comfortable" },
                                        benefits = new[] { "Builds leg strength", "Improves mobility", "Functional movement pattern" }
                                    },
                                    new
                                    {
                                        id = 2,
                                        name = "Push-ups",
                                        imageUrl = "https://blog.nasm.org/hubfs/power-pushups.jpg",
                                        videoUrl = "https://www.youtube.com/shorts/EiCjxcfBAPQ?feature=share",
                                        sets = 3,
                                        reps = 8,
                                        duration = 0,
                                        restTime = 60,
                                        targetMuscle = "Chest,Shoulders,Triceps",
                                        equipment = "Bodyweight",
                                        difficulty = "Beginner",
                                        instructions = new[] { "Start in plank position", "Lower chest to floor", "Keep body straight", "Push back to start position" },
                                        tips = new[] { "Modify on knees if needed", "Keep core engaged", "Don't let hips sag" },
                                        benefits = new[] { "Builds upper body strength", "Improves core stability", "No equipment needed" }
                                    },
                                    new
                                    {
                                        id = 3,
                                        name = "Dumbbell Rows",
                                        imageUrl = "https://www.meridian-fitness.co.uk/wp-content/uploads/2025/03/Dumbbell-Bent-Over-Row-Single-Arm.webp",
                                        videoUrl = "https://www.youtube.com/shorts/yHqqGd0tXcw",
                                        sets = 3,
                                        reps = 10,
                                        duration = 0,
                                        restTime = 60,
                                        targetMuscle = "Back,Biceps",
                                        equipment = "Dumbbells",
                                        difficulty = "Beginner",
                                        instructions = new[] { "Bend over with dumbbell in hand", "Pull weight to hip", "Squeeze shoulder blades", "Lower with control" },
                                        tips = new[] { "Keep back straight", "Pull with your back, not arms", "Feel the squeeze between shoulder blades" },
                                        benefits = new[] { "Builds back strength", "Improves posture", "Balances pushing movements" }
                                    },
                                    new
                                    {
                                        id = 4,
                                        name = "Plank",
                                        imageUrl = "https://as2.ftcdn.net/v2/jpg/02/70/00/73/1000_F_270007332_XKUTg4xkGRVMLZZIYnjYygM1qSKjkH08.jpg",
                                        videoUrl = "https://www.youtube.com/shorts/v3V6iyQfKzY?feature=share",
                                        sets = 3,
                                        reps = 0,
                                        duration = 30,
                                        restTime = 60,
                                        targetMuscle = "Core,Shoulders",
                                        equipment = "Bodyweight",
                                        difficulty = "Beginner",
                                        instructions = new[] { "Start in push-up position", "Hold body straight", "Engage core muscles", "Breathe normally" },
                                        tips = new[] { "Don't let hips sag", "Keep head neutral", "Start with shorter holds" },
                                        benefits = new[] { "Core stability", "Improves posture", "Full body engagement" }
                                    },
                                    new
                                    {
                                        id = 5,
                                        name = "Lunges",
                                        imageUrl = "https://www.healthshots.com/healthshots/en/uploads/2024/05/02174153/Lunges-770x436.jpg",
                                        videoUrl = "https://www.youtube.com/shorts/38xlLGfguz4",
                                        sets = 3,
                                        reps = 10,
                                        duration = 0,
                                        restTime = 60,
                                        targetMuscle = "Legs,Glutes",
                                        equipment = "Bodyweight",
                                        difficulty = "Beginner",
                                        instructions = new[] { "Step forward into lunge", "Lower back knee toward ground", "Push back to starting position", "Alternate legs" },
                                        tips = new[] { "Keep front knee over ankle", "Engage core for balance", "Take a big step forward" },
                                        benefits = new[] { "Leg strength", "Balance improvement", "Unilateral training" }
                                    }
                                }
                            },
                            new
                            {
                                day = 2,
                                name = "Day 2 - Active Recovery",
                                exercises = new[]
                                {
                                    new
                                    {
                                        id = 6,
                                        name = "Walking",
                                        imageUrl = "https://as1.ftcdn.net/jpg/01/90/62/50/1000_F_190625076_dSBWNzVBiDj7APIps4M8xhudRgg7s8IL.jpg",
                                        videoUrl = "https://www.youtube.com/watch?v=Fh_f0qMOTw4",
                                        sets = 1,
                                        reps = 0,
                                        duration = 1800,
                                        restTime = 0,
                                        targetMuscle = "Cardiovascular",
                                        equipment = "None",
                                        difficulty = "Beginner",
                                        instructions = new[] { "Walk at comfortable pace", "Maintain good posture", "Breathe naturally", "Enjoy the movement" },
                                        tips = new[] { "Start with 20-30 minutes", "Gradually increase duration", "Listen to your body" },
                                        benefits = new[] { "Active recovery", "Improves cardiovascular health", "Low impact exercise" }
                                    },
                                    new
                                    {
                                        id = 7,
                                        name = "Dynamic Stretching",
                                        imageUrl = "https://www.holisticbodyworks.com.au/wp-content/uploads/2018/08/Dynamic-Stretching.jpg",
                                        videoUrl = "https://www.youtube.com/watch?v=dilAhJzMGUo",
                                        sets = 2,
                                        reps = 10,
                                        duration = 0,
                                        restTime = 30,
                                        targetMuscle = "Full Body",
                                        equipment = "None",
                                        difficulty = "Beginner",
                                        instructions = new[] { "Perform leg swings", "Arm circles", "Hip circles", "Gentle twists" },
                                        tips = new[] { "Move slowly and controlled", "Don't force the stretch", "Focus on mobility" },
                                        benefits = new[] { "Improves flexibility", "Increases blood flow", "Reduces stiffness" }
                                    },
                                    new
                                    {
                                        id = 8,
                                        name = "Foam Rolling",
                                        imageUrl = "https://wellness360magazine.com/wp-content/uploads/2016/12/Screen-Shot-2016-12-21-at-12.48.00-PM.png",
                                        videoUrl = "https://www.youtube.com/watch?v=zQCX1pBnwWc",
                                        sets = 1,
                                        reps = 0,
                                        duration = 600,
                                        restTime = 0,
                                        targetMuscle = "Full Body",
                                        equipment = "Foam Roller",
                                        difficulty = "Beginner",
                                        instructions = new[] { "Roll each muscle group slowly", "Focus on tight areas", "Breathe deeply", "Apply moderate pressure" },
                                        tips = new[] { "Don't roll too fast", "Avoid rolling directly on bones", "Stop if pain is severe" },
                                        benefits = new[] { "Muscle recovery", "Reduces tension", "Improves circulation" }
                                    },
                                    new
                                    {
                                        id = 9,
                                        name = "Cat-Cow Stretch",
                                        imageUrl = "https://images.unsplash.com/photo-1506629905607-0e1cb3c50563",
                                        videoUrl = "https://www.youtube.com/watch?v=K9bK0BwKFjs",
                                        sets = 3,
                                        reps = 8,
                                        duration = 0,
                                        restTime = 30,
                                        targetMuscle = "Spine,Core",
                                        equipment = "None",
                                        difficulty = "Beginner",
                                        instructions = new[] { "Start on hands and knees", "Arch back (cow)", "Round back (cat)", "Move slowly between positions" },
                                        tips = new[] { "Move with your breath", "Focus on spinal mobility", "Don't rush the movement" },
                                        benefits = new[] { "Spinal mobility", "Core activation", "Relieves back tension" }
                                    }
                                }
                            }
                        }
                    })
                },
                // Workout Plan 2: Upper Body Strength
                new GeneralWorkoutPlan
                {
              
                    Name = "Upper Body Strength",
                    Category = "Strength",
                    Description = "Focused upper body strength training targeting chest, back, shoulders, and arms with progressive overload.",
                    ImageUrl = "https://images.unsplash.com/photo-1581009146145-b5ef050c2e1e",
                    Duration = 45,
                    ExerciseCount = 25,
                    Difficulty = "Intermediate",
                    Goals = "Upper Body Strength,Muscle Building,Power",
                    CaloriesBurned = 280,
                    KeyFeatures = "Push Pull Split,Progressive Overload,Compound Movements",
                    Benefits = "Increased Upper Body Strength,Improved Posture,Better Definition",
                    TargetMuscles = "Chest,Back,Shoulders,Arms",
                    Equipment = "Dumbbells,Barbell,Bench,Pull-up Bar",
                    VideoUrl = "https://www.youtube.com/watch?v=vc1E5CfRfos",
                    IsActive = true,  
                    CreatedAt = DateTime.UtcNow, 
                    UpdatedAt = DateTime.UtcNow,     
                    PlanDetailsJson = JsonSerializer.Serialize(new
                    {
                        days = new[]
                        {
                            new
                            {
                                day = 1,
                                name = "Push Day - Chest & Shoulders",
                                exercises = new[]
                                {
                                    new
                                    {
                                        id = 10,
                                        name = "Bench Press",
                                        imageUrl = "https://www.anytimefitness.com/wp-content/uploads/2024/01/AF-HERO_BenchPress-1024x683.jpg",
                                        videoUrl = "https://www.youtube.com/watch?v=rT7DgCr-3pg",
                                        sets = 4,
                                        reps = 8,
                                        duration = 0,
                                        restTime = 90,
                                        targetMuscle = "Chest,Shoulders,Triceps",
                                        equipment = "Barbell,Bench",
                                        difficulty = "Intermediate",
                                        instructions = new[] { "Lie on bench with feet flat", "Grip bar slightly wider than shoulders", "Lower bar to chest", "Press up explosively" },
                                        tips = new[] { "Keep shoulder blades squeezed", "Control the descent", "Drive through your heels" },
                                        benefits = new[] { "Builds chest strength", "Improves pressing power", "Compound movement benefits" }
                                    },
                                    new
                                    {
                                        id = 11,
                                        name = "Overhead Press",
                                        imageUrl = "https://i.pinimg.com/736x/76/90/88/769088293353fed118d92d579fdfa9e5.jpg",
                                        videoUrl = "https://www.youtube.com/watch?v=2yjwXTZQDDI",
                                        sets = 4,
                                        reps = 6,
                                        duration = 0,
                                        restTime = 90,
                                        targetMuscle = "Shoulders,Triceps,Core",
                                        equipment = "Barbell",
                                        difficulty = "Intermediate",
                                        instructions = new[] { "Stand with feet hip-width", "Press bar overhead", "Keep core tight", "Lower with control" },
                                        tips = new[] { "Don't arch back excessively", "Press in straight line", "Engage your core" },
                                        benefits = new[] { "Shoulder strength", "Core stability", "Functional pressing pattern" }
                                    },
                                    new
                                    {
                                        id = 12,
                                        name = "Incline Dumbbell Press",
                                        imageUrl = "https://www.puregym.com/media/shtduovg/incline-dumbbell-bench-press.jpg?quality=80",
                                        videoUrl = "https://www.youtube.com/watch?v=8iPEnn-ltC8",
                                        sets = 3,
                                        reps = 10,
                                        duration = 0,
                                        restTime = 75,
                                        targetMuscle = "Upper Chest,Shoulders",
                                        equipment = "Dumbbells,Incline Bench",
                                        difficulty = "Intermediate",
                                        instructions = new[] { "Set bench to 30-45 degrees", "Press dumbbells up and together", "Lower with control", "Feel stretch in chest" },
                                        tips = new[] { "Don't go too steep", "Control the weight", "Focus on upper chest" },
                                        benefits = new[] { "Upper chest development", "Shoulder stability", "Unilateral training" }
                                    },
                                    new
                                    {
                                        id = 13,
                                        name = "Dips",
                                        imageUrl = "https://www.pullup-dip.com/cdn/shop/articles/dip-training-ausfuehrung_600x600_e9e67fe8-041e-4605-aa43-ee328badf60c.jpg?v=1744810105&width=1000",
                                        videoUrl = "https://www.youtube.com/watch?v=2z8JmcrW-As",
                                        sets = 3,
                                        reps = 12,
                                        duration = 0,
                                        restTime = 60,
                                        targetMuscle = "Chest,Triceps,Shoulders",
                                        equipment = "Dip Station",
                                        difficulty = "Intermediate",
                                        instructions = new[] { "Support body on dip bars", "Lower body by bending arms", "Push back to start", "Lean forward for chest focus" },
                                        tips = new[] { "Control the descent", "Don't go too low", "Use assistance if needed" },
                                        benefits = new[] { "Compound pushing movement", "Bodyweight strength", "Tricep development" }
                                    },
                                    new
                                    {
                                        id = 14,
                                        name = "Lateral Raises",
                                        imageUrl = "https://experiencelife.lifetime.life/wp-content/uploads/2023/04/jun23-bid-lateral-raise.jpg",
                                        videoUrl = "https://www.youtube.com/watch?v=3VcKaXpzqRo",
                                        sets = 3,
                                        reps = 15,
                                        duration = 0,
                                        restTime = 60,
                                        targetMuscle = "Side Delts",
                                        equipment = "Dumbbells",
                                        difficulty = "Beginner",
                                        instructions = new[] { "Hold dumbbells at sides", "Raise arms to shoulder height", "Lower with control", "Keep slight bend in elbows" },
                                        tips = new[] { "Don't swing the weights", "Focus on side delts", "Control the movement" },
                                        benefits = new[] { "Shoulder width", "Deltoid isolation", "Better shoulder health" }
                                    }
                                }
                            }
                        }
                    })
                },
                // Workout Plan 3: Lower Body Power
                new GeneralWorkoutPlan
                {
             
                    Name = "Lower Body Power",
                    Category = "Strength",
                    Description = "Explosive lower body training focusing on squats, deadlifts, and power movements for strength and athleticism.",
                    ImageUrl = "http://cdn.mos.cms.futurecdn.net/h28xaaTD73GPx8aXiAvLVo-970-80.jpg.webp",
                    Duration = 50,
                    ExerciseCount = 28,
                    Difficulty = "Intermediate",
                    Goals = "Lower Body Strength,Power,Athletic Performance",
                    CaloriesBurned = 400,
                    KeyFeatures = "Compound Movements,Progressive Overload,Power Training",
                    Benefits = "Leg Strength,Power Development,Athletic Performance",
                    TargetMuscles = "Quads,Hamstrings,Glutes,Calves",
                    Equipment = "Barbell,Dumbbells,Squat Rack",
                    VideoUrl = "https://www.youtube.com/watch?v=ultWZbUMPL8",
                    IsActive = true,  
                    CreatedAt = DateTime.UtcNow, 
                    UpdatedAt = DateTime.UtcNow,     
                    PlanDetailsJson = JsonSerializer.Serialize(new
                    {
                        days = new[]
                        {
                            new
                            {
                                day = 1,
                                name = "Lower Body Power Day",
                                exercises = new[]
                                {
                                    new
                                    {
                                        id = 15,
                                        name = "Back Squats",
                                        imageUrl = "https://cdn.prod.website-files.com/66c501d753ae2a8c705375b6/67efe1dcd37f3af3af12c06d_AnytimeFitness_BarbellSquat-3-768x512.jpeg",
                                        videoUrl = "https://www.youtube.com/watch?v=ultWZbUMPL8",
                                        sets = 4,
                                        reps = 6,
                                        duration = 0,
                                        restTime = 120,
                                        targetMuscle = "Quads,Glutes,Core",
                                        equipment = "Barbell,Squat Rack",
                                        difficulty = "Intermediate",
                                        instructions = new[] { "Position bar on upper back", "Descend by sitting back", "Drive through heels", "Keep chest up throughout" },
                                        tips = new[] { "Keep knees tracking over toes", "Maintain neutral spine", "Go to comfortable depth" },
                                        benefits = new[] { "Ultimate leg builder", "Functional strength", "Core stability" }
                                    },
                                    new
                                    {
                                        id = 16,
                                        name = "Romanian Deadlifts",
                                        imageUrl = "https://www.puregym.com/media/5gwmhhys/romanian-deadlift.jpg?quality=80",
                                        videoUrl = "https://www.youtube.com/watch?v=jEy_czb3RKA",
                                        sets = 4,
                                        reps = 8,
                                        duration = 0,
                                        restTime = 90,
                                        targetMuscle = "Hamstrings,Glutes,Lower Back",
                                        equipment = "Barbell",
                                        difficulty = "Intermediate",
                                        instructions = new[] { "Hold bar with overhand grip", "Hinge at hips", "Lower bar along legs", "Drive hips forward to return" },
                                        tips = new[] { "Keep bar close to body", "Feel stretch in hamstrings", "Don't round your back" },
                                        benefits = new[] { "Hamstring strength", "Hip hinge pattern", "Posterior chain development" }
                                    },
                                    new
                                    {
                                        id = 17,
                                        name = "Bulgarian Split Squats",
                                        imageUrl = "https://images.unsplash.com/photo-1571019613454-1cb2f99b2d8b",
                                        videoUrl = "https://www.youtube.com/watch?v=2C-uNgKwPLE",
                                        sets = 3,
                                        reps = 10,
                                        duration = 0,
                                        restTime = 75,
                                        targetMuscle = "Quads,Glutes",
                                        equipment = "Dumbbells,Bench",
                                        difficulty = "Intermediate",
                                        instructions = new[] { "Place rear foot on bench", "Lower into lunge position", "Push through front heel", "Switch legs after set" },
                                        tips = new[] { "Most weight on front leg", "Don't push off back foot", "Maintain balance" },
                                        benefits = new[] { "Unilateral strength", "Balance improvement", "Muscle imbalance correction" }
                                    },
                                    new
                                    {
                                        id = 18,
                                        name = "Walking Lunges",
                                        imageUrl = "https://images.unsplash.com/photo-1571019613454-1cb2f99b2d8b",
                                        videoUrl = "https://www.youtube.com/watch?v=L8fvypPrzzs",
                                        sets = 3,
                                        reps = 12,
                                        duration = 0,
                                        restTime = 60,
                                        targetMuscle = "Quads,Glutes,Core",
                                        equipment = "Dumbbells",
                                        difficulty = "Beginner",
                                        instructions = new[] { "Step forward into lunge", "Lower back knee down", "Push through front heel", "Step forward with back leg" },
                                        tips = new[] { "Take big steps", "Keep torso upright", "Control the movement" },
                                        benefits = new[] { "Functional movement", "Dynamic stability", "Leg endurance" }
                                    },
                                    new
                                    {
                                        id = 19,
                                        name = "Calf Raises",
                                        imageUrl = "https://images.unsplash.com/photo-1571019613454-1cb2f99b2d8b",
                                        videoUrl = "https://www.youtube.com/watch?v=gwLzBJYoWlI",
                                        sets = 4,
                                        reps = 15,
                                        duration = 0,
                                        restTime = 45,
                                        targetMuscle = "Calves",
                                        equipment = "Dumbbells,Step",
                                        difficulty = "Beginner",
                                        instructions = new[] { "Stand on step with toes", "Let heels drop below step", "Rise up on toes", "Lower with control" },
                                        tips = new[] { "Full range of motion", "Squeeze at the top", "Control the descent" },
                                        benefits = new[] { "Calf strength", "Ankle stability", "Lower leg definition" }
                                    }
                                }
                            }
                        }
                    })
                },
                // Workout Plan 4: HIIT Cardio
                new GeneralWorkoutPlan
                {
             
                    Name = "HIIT Cardio Blast",
                    Category = "Cardio",
                    Description = "High-intensity interval training for maximum calorie burn, cardiovascular fitness, and metabolic boost.",
                    ImageUrl = "https://blastpit.com.au/wp-content/uploads/2023/09/BlastPit_lunge-1300x767-1.jpg",
                    Duration = 25,
                    ExerciseCount = 20,
                    Difficulty = "Intermediate",
                    Goals = "Fat Loss,Cardiovascular Fitness,Endurance",
                    CaloriesBurned = 350,
                    KeyFeatures = "High Intensity,Short Duration,Metabolic Boost",
                    Benefits = "Fat Burning,Improved Conditioning,Time Efficient",
                    TargetMuscles = "Full Body,Cardiovascular System",
                    Equipment = "Bodyweight,Optional Dumbbells",
                    VideoUrl = "https://www.youtube.com/watch?v=ml6cT4AZdqI",
                    IsActive = true,  
                    CreatedAt = DateTime.UtcNow, 
                    UpdatedAt = DateTime.UtcNow,     
                    PlanDetailsJson = JsonSerializer.Serialize(new
                    {
                        days = new[]
                        {
                            new
                            {
                                day = 1,
                                name = "HIIT Circuit",
                                exercises = new[]
                                {
                                    new
                                    {
                                        id = 20,
                                        name = "Burpees",
                                        imageUrl = "https://images.unsplash.com/photo-1518611012118-696072aa579a",
                                        videoUrl = "https://www.youtube.com/watch?v=auBLPXO8Fww",
                                        sets = 4,
                                        reps = 0,
                                        duration = 45,
                                        restTime = 15,
                                        targetMuscle = "Full Body",
                                        equipment = "Bodyweight",
                                        difficulty = "Intermediate",
                                        instructions = new[] { "Start standing", "Drop to push-up position", "Perform push-up", "Jump feet to hands", "Jump up with arms overhead" },
                                        tips = new[] { "Modify by stepping instead of jumping", "Keep core engaged", "Breathe rhythmically" },
                                        benefits = new[] { "Full body conditioning", "High calorie burn", "Cardiovascular improvement" }
                                    },
                                    new
                                    {
                                        id = 21,
                                        name = "Mountain Climbers",
                                        imageUrl = "https://images.unsplash.com/photo-1518611012118-696072aa579a",
                                        videoUrl = "https://www.youtube.com/watch?v=nmwgirgXLYM",
                                        sets = 4,
                                        reps = 0,
                                        duration = 45,
                                        restTime = 15,
                                        targetMuscle = "Core,Shoulders,Legs",
                                        equipment = "Bodyweight",
                                        difficulty = "Intermediate",
                                        instructions = new[] { "Start in plank position", "Alternate bringing knees to chest", "Keep hips level", "Move as fast as possible" },
                                        tips = new[] { "Don't let hips rise", "Keep hands planted", "Breathe steadily" },
                                        benefits = new[] { "Core strength", "Cardio conditioning", "Agility improvement" }
                                    },
                                    new
                                    {
                                        id = 22,
                                        name = "Jump Squats",
                                        imageUrl = "https://images.unsplash.com/photo-1518611012118-696072aa579a",
                                        videoUrl = "https://www.youtube.com/watch?v=CVaEhXotL7M",
                                        sets = 4,
                                        reps = 0,
                                        duration = 45,
                                        restTime = 15,
                                        targetMuscle = "Legs,Glutes",
                                        equipment = "Bodyweight",
                                        difficulty = "Intermediate",
                                        instructions = new[] { "Perform regular squat", "Explode up into jump", "Land softly", "Immediately go into next rep" },
                                        tips = new[] { "Land with bent knees", "Use arms for momentum", "Stay light on feet" },
                                        benefits = new[] { "Leg power", "Explosive strength", "High intensity cardio" }
                                    },
                                    new
                                    {
                                        id = 23,
                                        name = "High Knees",
                                        imageUrl = "https://images.unsplash.com/photo-1518611012118-696072aa579a",
                                        videoUrl = "https://www.youtube.com/watch?v=8opcQdC-V-U",
                                        sets = 4,
                                        reps = 0,
                                        duration = 45,
                                        restTime = 15,
                                        targetMuscle = "Legs,Core",
                                        equipment = "Bodyweight",
                                        difficulty = "Beginner",
                                        instructions = new[] { "Run in place", "Bring knees to chest level", "Pump arms naturally", "Maintain rapid pace" },
                                        tips = new[] { "Stay on balls of feet", "Keep core engaged", "Maintain good posture" },
                                        benefits = new[] { "Cardiovascular fitness", "Leg endurance", "Coordination" }
                                    },
                                    new
                                    {
                                        id = 24,
                                        name = "Plank Jacks",
                                        imageUrl = "https://images.unsplash.com/photo-1518611012118-696072aa579a",
                                        videoUrl = "https://www.youtube.com/watch?v=maUJ2TnyNt0",
                                        sets = 4,
                                        reps = 0,
                                        duration = 45,
                                        restTime = 15,
                                        targetMuscle = "Core,Shoulders",
                                        equipment = "Bodyweight",
                                        difficulty = "Intermediate",
                                        instructions = new[] { "Start in plank position", "Jump feet apart and together", "Keep core engaged", "Maintain plank form" },
                                        tips = new[] { "Don't let hips sag", "Keep shoulders over wrists", "Control the movement" },
                                        benefits = new[] { "Core stability", "Cardio conditioning", "Full body engagement" }
                                    }
                                }
                            }
                        }
                    })
                },
                // Workout Plan 5: Yoga Flow
                new GeneralWorkoutPlan
                {
               
                    Name = "Yoga Flow",
                    Category = "Flexibility",
                    Description = "Flowing yoga sequence combining strength, flexibility, balance, and mindfulness for complete wellness.",
                    ImageUrl = "https://nutritionsource.hsph.harvard.edu/wp-content/uploads/2021/11/pexels-yan-krukov-8436601-copy-1024x768.jpg",
                    Duration = 40,
                    ExerciseCount = 20,
                    Difficulty = "Beginner",
                    Goals = "Flexibility,Balance,Mindfulness,Stress Relief",
                    CaloriesBurned = 180,
                    KeyFeatures = "Mind-Body Connection,Flexibility,Balance,Breathing",
                    Benefits = "Improved Flexibility,Stress Relief,Better Balance,Mental Clarity",
                    TargetMuscles = "Full Body,Core,Balance",
                    Equipment = "Yoga Mat",
                    VideoUrl = "https://www.youtube.com/watch?v=v7AYKMP6rOE",
                    IsActive = true,  
                    CreatedAt = DateTime.UtcNow, 
                    UpdatedAt = DateTime.UtcNow,     
                    PlanDetailsJson = JsonSerializer.Serialize(new
                    {
                        days = new[]
                        {
                            new
                            {
                                day = 1,
                                name = "Morning Yoga Flow",
                                exercises = new[]
                                {
                                    new
                                    {
                                        id = 25,
                                        name = "Sun Salutation A",
                                        imageUrl = "https://images.unsplash.com/photo-1506629905607-0e1cb3c50563",
                                        videoUrl = "https://www.youtube.com/watch?v=73sjOqXgJVE",
                                        sets = 3,
                                        reps = 0,
                                        duration = 300,
                                        restTime = 30,
                                        targetMuscle = "Full Body",
                                        equipment = "Yoga Mat",
                                        difficulty = "Beginner",
                                        instructions = new[] { "Flow through mountain pose", "Forward fold", "Half lift", "Chaturanga", "Upward dog", "Downward dog" },
                                        tips = new[] { "Move with your breath", "Modify as needed", "Focus on alignment" },
                                        benefits = new[] { "Full body warmup", "Flexibility", "Mind-body connection" }
                                    },
                                    new
                                    {
                                        id = 26,
                                        name = "Warrior II Flow",
                                        imageUrl = "https://images.unsplash.com/photo-1506629905607-0e1cb3c50563",
                                        videoUrl = "https://www.youtube.com/watch?v=QGIeMJ2Ayh0",
                                        sets = 2,
                                        reps = 0,
                                        duration = 240,
                                        restTime = 30,
                                        targetMuscle = "Legs,Core,Balance",
                                        equipment = "Yoga Mat",
                                        difficulty = "Beginner",
                                        instructions = new[] { "Step into warrior II", "Hold for breaths", "Flow to reverse warrior", "Return to warrior II", "Switch sides" },
                                        tips = new[] { "Keep front knee over ankle", "Sink into the pose", "Breathe deeply" },
                                        benefits = new[] { "Leg strength", "Hip flexibility", "Mental focus" }
                                    },
                                    new
                                    {
                                        id = 27,
                                        name = "Downward Dog Hold",
                                        imageUrl = "https://images.unsplash.com/photo-1506629905607-0e1cb3c50563",
                                        videoUrl = "https://www.youtube.com/watch?v=iD2DorUepEM",
                                        sets = 3,
                                        reps = 0,
                                        duration = 60,
                                        restTime = 30,
                                        targetMuscle = "Shoulders,Core,Hamstrings",
                                        equipment = "Yoga Mat",
                                        difficulty = "Beginner",
                                        instructions = new[] { "Form inverted V shape", "Press hands into mat", "Lengthen spine", "Breathe deeply" },
                                        tips = new[] { "Bend knees if needed", "Don't dump into shoulders", "Create length in spine" },
                                        benefits = new[] { "Shoulder strength", "Hamstring stretch", "Inversion benefits" }
                                    },
                                    new
                                    {
                                        id = 28,
                                        name = "Tree Pose",
                                        imageUrl = "https://images.unsplash.com/photo-1506629905607-0e1cb3c50563",
                                        videoUrl = "https://www.youtube.com/watch?v=CZstBrYvJyk",
                                        sets = 2,
                                        reps = 0,
                                        duration = 60,
                                        restTime = 30,
                                        targetMuscle = "Core,Balance,Focus",
                                        equipment = "Yoga Mat",
                                        difficulty = "Beginner",
                                        instructions = new[] { "Stand on one foot", "Place other foot on inner thigh", "Bring hands to prayer", "Focus on breath", "Switch sides" },
                                        tips = new[] { "Use wall for support", "Don't place foot on knee", "Find focal point" },
                                        benefits = new[] { "Balance improvement", "Mental focus", "Core strength" }
                                    },
                                    new
                                    {
                                        id = 29,
                                        name = "Savasana Relaxation",
                                        imageUrl = "https://images.unsplash.com/photo-1506629905607-0e1cb3c50563",
                                        videoUrl = "https://www.youtube.com/watch?v=l_vS7OURVXs",
                                        sets = 1,
                                        reps = 0,
                                        duration = 300,
                                        restTime = 0,
                                        targetMuscle = "Full Body Relaxation",
                                        equipment = "Yoga Mat",
                                        difficulty = "Beginner",
                                        instructions = new[] { "Lie flat on back", "Close eyes", "Relax entire body", "Focus on breath", "Complete stillness" },
                                        tips = new[] { "Let go completely", "Don't fall asleep", "Focus on present moment" },
                                        benefits = new[] { "Stress relief", "Mental clarity", "Complete relaxation" }
                                    }
                                }
                            }
                        }
                    })
                },
                // Workout Plan 6: Core Blast
                new GeneralWorkoutPlan
                {
             
                    Name = "Core Blast",
                    Category = "Core",
                    Description = "Intensive core-focused workout targeting all abdominal muscles for strength, stability, and definition.",
                    ImageUrl = "https://images.unsplash.com/photo-1571019613454-1cb2f99b2d8b",
                    Duration = 30,
                    ExerciseCount = 25,
                    Difficulty = "Intermediate",
                    Goals = "Core Strength,Stability,Muscle Definition",
                    CaloriesBurned = 220,
                    KeyFeatures = "Core Focus,Progressive Difficulty,Functional Movements",
                    Benefits = "Strong Core,Better Posture,Athletic Performance,Back Health",
                    TargetMuscles = "Abs,Obliques,Deep Core,Lower Back",
                    Equipment = "Mat,Optional Medicine Ball",
                    VideoUrl = "https://www.youtube.com/watch?v=50kH0rKrrhs",
                    IsActive = true,  
                    CreatedAt = DateTime.UtcNow, 
                    UpdatedAt = DateTime.UtcNow,     
                    PlanDetailsJson = JsonSerializer.Serialize(new
                    {
                        days = new[]
                        {
                            new
                            {
                                day = 1,
                                name = "Core Strength Circuit",
                                exercises = new[]
                                {
                                    new
                                    {
                                        id = 30,
                                        name = "Plank Variations",
                                        imageUrl = "https://images.unsplash.com/photo-1571019613454-1cb2f99b2d8b",
                                        videoUrl = "https://www.youtube.com/watch?v=pSHjTRCQxIw",
                                        sets = 4,
                                        reps = 0,
                                        duration = 45,
                                        restTime = 60,
                                        targetMuscle = "Core,Shoulders",
                                        equipment = "Mat",
                                        difficulty = "Intermediate",
                                        instructions = new[] { "Standard plank 15s", "Side plank right 15s", "Side plank left 15s", "Return to standard plank" },
                                        tips = new[] { "Keep body straight", "Engage core throughout", "Breathe normally" },
                                        benefits = new[] { "Core stability", "Shoulder strength", "Full core activation" }
                                    },
                                    new
                                    {
                                        id = 31,
                                        name = "Russian Twists",
                                        imageUrl = "https://images.unsplash.com/photo-1571019613454-1cb2f99b2d8b",
                                        videoUrl = "https://www.youtube.com/watch?v=wkD8rjkodUI",
                                        sets = 4,
                                        reps = 20,
                                        duration = 0,
                                        restTime = 45,
                                        targetMuscle = "Obliques,Core",
                                        equipment = "Mat,Optional Weight",
                                        difficulty = "Intermediate",
                                        instructions = new[] { "Sit with knees bent", "Lean back slightly", "Rotate torso left and right", "Keep core engaged" },
                                        tips = new[] { "Don't rush the movement", "Feel the twist in core", "Keep chest up" },
                                        benefits = new[] { "Oblique strength", "Rotational power", "Core endurance" }
                                    },
                                    new
                                    {
                                        id = 32,
                                        name = "Dead Bug",
                                        imageUrl = "https://images.unsplash.com/photo-1571019613454-1cb2f99b2d8b",
                                        videoUrl = "https://www.youtube.com/watch?v=g_BYB0R-4Ws",
                                        sets = 3,
                                        reps = 10,
                                        duration = 0,
                                        restTime = 45,
                                        targetMuscle = "Deep Core,Stability",
                                        equipment = "Mat",
                                        difficulty = "Beginner",
                                        instructions = new[] { "Lie on back, arms up", "Knees at 90 degrees", "Lower opposite arm and leg", "Return slowly, switch" },
                                        tips = new[] { "Keep lower back flat", "Move slowly and controlled", "Focus on stability" },
                                        benefits = new[] { "Deep core activation", "Spinal stability", "Coordination" }
                                    },
                                    new
                                    {
                                        id = 33,
                                        name = "Bicycle Crunches",
                                        imageUrl = "https://images.unsplash.com/photo-1571019613454-1cb2f99b2d8b",
                                        videoUrl = "https://www.youtube.com/watch?v=9FGilxCbdz8",
                                        sets = 4,
                                        reps = 24,
                                        duration = 0,
                                        restTime = 45,
                                        targetMuscle = "Abs,Obliques",
                                        equipment = "Mat",
                                        difficulty = "Intermediate",
                                        instructions = new[] { "Lie on back, hands behind head", "Bring knee to opposite elbow", "Alternate sides in cycling motion", "Keep core engaged" },
                                        tips = new[] { "Don't pull on neck", "Focus on the twist", "Control the movement" },
                                        benefits = new[] { "Abdominal strength", "Oblique activation", "Dynamic core work" }
                                    },
                                    new
                                    {
                                        id = 34,
                                        name = "Mountain Climber Plank",
                                        imageUrl = "https://images.unsplash.com/photo-1571019613454-1cb2f99b2d8b",
                                        videoUrl = "https://www.youtube.com/watch?v=nmwgirgXLYM",
                                        sets = 3,
                                        reps = 0,
                                        duration = 30,
                                        restTime = 45,
                                        targetMuscle = "Core,Cardio",
                                        equipment = "Mat",
                                        difficulty = "Intermediate",
                                        instructions = new[] { "Start in plank position", "Alternate bringing knees to chest", "Keep hips level", "Maintain pace" },
                                        tips = new[] { "Don't bounce hips", "Keep core tight", "Breathe rhythmically" },
                                        benefits = new[] { "Core endurance", "Cardio conditioning", "Dynamic stability" }
                                    }
                                }
                            }
                        }
                    })
                },
                // Workout Plan 7: Functional Training
                new GeneralWorkoutPlan
                {
              
                    Name = "Functional Training",
                    Category = "Functional",
                    Description = "Real-world movement patterns and exercises that improve daily activities and athletic performance.",
                    ImageUrl = "https://sunnyhealthfitness.com/cdn/shop/articles/functional-training-how-to-include-fitness-routine-FB_1100x.jpg?v=1579069824",
                    Duration = 45,
                    ExerciseCount = 30,
                    Difficulty = "Intermediate",
                    Goals = "Functional Strength,Movement Quality,Athletic Performance",
                    CaloriesBurned = 320,
                    KeyFeatures = "Movement Patterns,Multi-Planar,Sport Specific",
                    Benefits = "Better Movement,Injury Prevention,Athletic Performance,Daily Function",
                    TargetMuscles = "Full Body,Movement Patterns",
                    Equipment = "Dumbbells,Kettlebell,Medicine Ball,TRX",
                    VideoUrl = "https://www.youtube.com/watch?v=VC9xU2K1bkU",
                    IsActive = true,  
                    CreatedAt = DateTime.UtcNow, 
                    UpdatedAt = DateTime.UtcNow,     
                    PlanDetailsJson = JsonSerializer.Serialize(new
                    {
                        days = new[]
                        {
                            new
                            {
                                day = 1,
                                name = "Functional Movement Day",
                                exercises = new[]
                                {
                                    new
                                    {
                                        id = 35,
                                        name = "Turkish Get-Up",
                                        imageUrl = "https://images.unsplash.com/photo-1571019613454-1cb2f99b2d8b",
                                        videoUrl = "https://www.youtube.com/watch?v=0bWRPC99tFU",
                                        sets = 3,
                                        reps = 3,
                                        duration = 0,
                                        restTime = 90,
                                        targetMuscle = "Full Body,Stability",
                                        equipment = "Kettlebell",
                                        difficulty = "Advanced",
                                        instructions = new[] { "Start lying with weight overhead", "Roll to elbow, then hand", "Bridge up and sweep leg", "Stand up maintaining weight overhead" },
                                        tips = new[] { "Start with light weight", "Focus on form", "Move slowly and controlled" },
                                        benefits = new[] { "Full body coordination", "Shoulder stability", "Functional strength" }
                                    },
                                    new
                                    {
                                        id = 36,
                                        name = "Farmer's Walks",
                                        imageUrl = "https://images.unsplash.com/photo-1571019613454-1cb2f99b2d8b",
                                        videoUrl = "https://www.youtube.com/watch?v=p3W_gerQuXc",
                                        sets = 4,
                                        reps = 0,
                                        duration = 60,
                                        restTime = 90,
                                        targetMuscle = "Grip,Core,Posture",
                                        equipment = "Heavy Dumbbells",
                                        difficulty = "Intermediate",
                                        instructions = new[] { "Hold heavy weights at sides", "Walk forward with good posture", "Keep shoulders back", "Maintain tight core" },
                                        tips = new[] { "Don't let weights pull you forward", "Take controlled steps", "Breathe normally" },
                                        benefits = new[] { "Grip strength", "Core stability", "Functional carrying strength" }
                                    },
                                    new
                                    {
                                        id = 37,
                                        name = "Single Arm Row to Rotation",
                                        imageUrl = "https://images.unsplash.com/photo-1571019613454-1cb2f99b2d8b",
                                        videoUrl = "https://www.youtube.com/watch?v=T3N-TO4reLQ",
                                        sets = 3,
                                        reps = 8,
                                        duration = 0,
                                        restTime = 60,
                                        targetMuscle = "Back,Core,Rotation",
                                        equipment = "Cable/Resistance Band",
                                        difficulty = "Intermediate",
                                        instructions = new[] { "Row cable/band to ribs", "Rotate torso as you pull", "Control the return", "Engage core throughout" },
                                        tips = new[] { "Initiate with back muscles", "Don't over-rotate", "Keep hips stable" },
                                        benefits = new[] { "Back strength", "Rotational power", "Core integration" }
                                    },
                                    new
                                    {
                                        id = 38,
                                        name = "Lateral Lunges",
                                        imageUrl = "https://images.unsplash.com/photo-1571019613454-1cb2f99b2d8b",
                                        videoUrl = "https://www.youtube.com/watch?v=k8AE8K_xgUU",
                                        sets = 3,
                                        reps = 10,
                                        duration = 0,
                                        restTime = 60,
                                        targetMuscle = "Legs,Hip Mobility",
                                        equipment = "Bodyweight/Dumbbells",
                                        difficulty = "Intermediate",
                                        instructions = new[] { "Step wide to one side", "Sit back into hip", "Keep other leg straight", "Push back to center" },
                                        tips = new[] { "Keep chest up", "Don't let knee cave in", "Feel stretch in inner thigh" },
                                        benefits = new[] { "Hip mobility", "Lateral strength", "Movement variety" }
                                    },
                                    new
                                    {
                                        id = 39,
                                        name = "Bear Crawl",
                                        imageUrl = "https://images.unsplash.com/photo-1571019613454-1cb2f99b2d8b",
                                        videoUrl = "https://www.youtube.com/watch?v=Azrg6ueaC5c",
                                        sets = 3,
                                        reps = 0,
                                        duration = 45,
                                        restTime = 75,
                                        targetMuscle = "Full Body,Coordination",
                                        equipment = "Bodyweight",
                                        difficulty = "Intermediate",
                                        instructions = new[] { "Start on hands and knees", "Lift knees slightly off ground", "Crawl forward maintaining position", "Keep core engaged" },
                                        tips = new[] { "Small movements", "Don't rush", "Keep hips level" },
                                        benefits = new[] { "Full body strength", "Coordination", "Core stability" }
                                    }
                                }
                            }
                        }
                    })
                },
                // Workout Plan 8: Bodyweight Mastery
                new GeneralWorkoutPlan
                {
              
                    Name = "Bodyweight Mastery",
                    Category = "Bodyweight",
                    Description = "Advanced bodyweight training focusing on skill development, strength, and movement mastery.",
                    ImageUrl = "https://www.ramassfitness.com/cdn/shop/articles/Planche_on_RAMASS_Parallettes_2131891b-7ecc-42c7-a4b0-5f48c7b0b0e5_1080x.jpg?v=1742904098",
                    Duration = 40,
                    ExerciseCount = 25,
                    Difficulty = "Advanced",
                    Goals = "Bodyweight Strength,Skill Development,Movement Mastery",
                    CaloriesBurned = 300,
                    KeyFeatures = "Progressive Skills,No Equipment,Advanced Movements",
                    Benefits = "Relative Strength,Skill Development,Mobility,Control",
                    TargetMuscles = "Full Body,Movement Control",
                    Equipment = "Pull-up Bar,Bodyweight Only",
                    VideoUrl = "https://www.youtube.com/watch?v=vc1E5CfRfos",
                    IsActive = true,  
                    CreatedAt = DateTime.UtcNow, 
                    UpdatedAt = DateTime.UtcNow,     
                    PlanDetailsJson = JsonSerializer.Serialize(new
                    {
                        days = new[]
                        {
                            new
                            {
                                day = 1,
                                name = "Bodyweight Skills",
                                exercises = new[]
                                {
                                    new
                                    {
                                        id = 40,
                                        name = "Archer Push-ups",
                                        imageUrl = "https://images.unsplash.com/photo-1571019613454-1cb2f99b2d8b",
                                        videoUrl = "https://www.youtube.com/watch?v=vUNT_b_6YPs",
                                        sets = 3,
                                        reps = 5,
                                        duration = 0,
                                        restTime = 90,
                                        targetMuscle = "Chest,Shoulders,Core",
                                        equipment = "Bodyweight",
                                        difficulty = "Advanced",
                                        instructions = new[] { "Wide hand position", "Shift weight to one arm", "Lower while keeping other arm straight", "Push up and switch sides" },
                                        tips = new[] { "Start with assisted version", "Control the movement", "Build up gradually" },
                                        benefits = new[] { "Unilateral strength", "Advanced pushing pattern", "Core stability" }
                                    },
                                    new
                                    {
                                        id = 41,
                                        name = "Pistol Squat Progression",
                                        imageUrl = "https://images.unsplash.com/photo-1571019613454-1cb2f99b2d8b",
                                        videoUrl = "https://www.youtube.com/watch?v=qDcniqddTeE",
                                        sets = 3,
                                        reps = 3,
                                        duration = 0,
                                        restTime = 90,
                                        targetMuscle = "Legs,Balance,Mobility",
                                        equipment = "Bodyweight",
                                        difficulty = "Advanced",
                                        instructions = new[] { "Stand on one leg", "Extend other leg forward", "Lower into single leg squat", "Rise back to standing" },
                                        tips = new[] { "Use assistance initially", "Focus on control", "Work on ankle mobility" },
                                        benefits = new[] { "Unilateral leg strength", "Balance", "Mobility" }
                                    },
                                    new
                                    {
                                        id = 42,
                                        name = "L-Sit Hold",
                                        imageUrl = "https://images.unsplash.com/photo-1571019613454-1cb2f99b2d8b",
                                        videoUrl = "https://www.youtube.com/watch?v=IUZJoSP66HI",
                                        sets = 4,
                                        reps = 0,
                                        duration = 15,
                                        restTime = 60,
                                        targetMuscle = "Core,Shoulders,Hip Flexors",
                                        equipment = "Parallel Bars/Dip Station",
                                        difficulty = "Advanced",
                                        instructions = new[] { "Support body on parallel bars", "Lift legs to 90 degrees", "Hold position", "Keep shoulders down" },
                                        tips = new[] { "Start with bent knees", "Engage lats", "Build up hold time" },
                                        benefits = new[] { "Core strength", "Shoulder stability", "Hip flexor strength" }
                                    },
                                    new
                                    {
                                        id = 43,
                                        name = "Handstand Wall Walk",
                                        imageUrl = "https://images.unsplash.com/photo-1571019613454-1cb2f99b2d8b",
                                        videoUrl = "https://www.youtube.com/watch?v=BMquvdGW5g8",
                                        sets = 3,
                                        reps = 0,
                                        duration = 30,
                                        restTime = 120,
                                        targetMuscle = "Shoulders,Core,Balance",
                                        equipment = "Wall",
                                        difficulty = "Advanced",
                                        instructions = new[] { "Place feet on wall in plank", "Walk feet up wall", "Walk hands closer to wall", "Hold handstand position" },
                                        tips = new[] { "Start conservative", "Keep core engaged", "Exit safely" },
                                        benefits = new[] { "Shoulder strength", "Inversion skills", "Core control" }
                                    },
                                    new
                                    {
                                        id = 44,
                                        name = "Dragon Squat",
                                        imageUrl = "https://images.unsplash.com/photo-1571019613454-1cb2f99b2d8b",
                                        videoUrl = "https://www.youtube.com/watch?v=Jp7QF8tXDI8",
                                        sets = 3,
                                        reps = 5,
                                        duration = 0,
                                        restTime = 90,
                                        targetMuscle = "Legs,Mobility,Balance",
                                        equipment = "Bodyweight",
                                        difficulty = "Advanced",
                                        instructions = new[] { "From deep lunge position", "Extend front leg while maintaining low position", "Return to lunge", "Switch legs" },
                                        tips = new[] { "Use hands for balance", "Go slow and controlled", "Work on flexibility" },
                                        benefits = new[] { "Hip mobility", "Leg strength", "Dynamic balance" }
                                    }
                                }
                            }
                        }
                    })
                },
                // Workout Plan 9: Powerlifting Basics
                new GeneralWorkoutPlan
                {
               
                    Name = "Powerlifting Basics",
                    Category = "Powerlifting",
                    Description = "Introduction to powerlifting focusing on squat, bench press, and deadlift technique and strength.",
                    ImageUrl = "https://www.basic-fit.com/dw/image/v2/BDFP_PRD/on/demandware.static/-/Library-Sites-basic-fit-shared-library/default/dw48f50233/Roots/Blog/Blog-Header/1088x612/19-07-Blog-Fitness-Training-Deadlift-Shoes.png?sw=968",
                    Duration = 60,
                    ExerciseCount = 15,
                    Difficulty = "Intermediate",
                    Goals = "Maximal Strength,Powerlifting Technique,Progressive Overload",
                    CaloriesBurned = 320,
                    KeyFeatures = "Big Three Lifts,Progressive Overload,Technique Focus",
                    Benefits = "Maximal Strength,Better Technique,Competitive Preparation",
                    TargetMuscles = "Full Body,Primary Movers",
                    Equipment = "Barbell,Squat Rack,Bench,Plates",
                    VideoUrl = "https://www.youtube.com/watch?v=wYREQkVtvEc",
                    IsActive = true,  
                    CreatedAt = DateTime.UtcNow, 
                    UpdatedAt = DateTime.UtcNow,     
                    PlanDetailsJson = JsonSerializer.Serialize(new
                    {
                        days = new[]
                        {
                            new
                            {
                                day = 1,
                                name = "Powerlifting Day",
                                exercises = new[]
                                {
                                    new
                                    {
                                        id = 45,
                                        name = "Competition Squat",
                                        imageUrl = "https://images.unsplash.com/photo-1583500178690-f7fd39d8440d",
                                        videoUrl = "https://www.youtube.com/watch?v=ultWZbUMPL8",
                                        sets = 5,
                                        reps = 3,
                                        duration = 0,
                                        restTime = 180,
                                        targetMuscle = "Quads,Glutes,Core",
                                        equipment = "Barbell,Squat Rack",
                                        difficulty = "Intermediate",
                                        instructions = new[] { "Set up in squat rack", "Descend to legal depth", "Drive through heels", "Complete lockout" },
                                        tips = new[] { "Focus on competition commands", "Maintain tight setup", "Hit proper depth" },
                                        benefits = new[] { "Maximum leg strength", "Competition preparation", "Technical mastery" }
                                    },
                                    new
                                    {
                                        id = 46,
                                        name = "Competition Bench Press",
                                        imageUrl = "https://images.unsplash.com/photo-1583500178690-f7fd39d8440d",
                                        videoUrl = "https://www.youtube.com/watch?v=rT7DgCr-3pg",
                                        sets = 5,
                                        reps = 3,
                                        duration = 0,
                                        restTime = 180,
                                        targetMuscle = "Chest,Shoulders,Triceps",
                                        equipment = "Barbell,Bench",
                                        difficulty = "Intermediate",
                                        instructions = new[] { "Set up arch and leg drive", "Lower to chest with pause", "Wait for press command", "Lock out completely" },
                                        tips = new[] { "Practice competition timing", "Maintain arch", "Use leg drive" },
                                        benefits = new[] { "Upper body strength", "Competition technique", "Pressing power" }
                                    },
                                    new
                                    {
                                        id = 47,
                                        name = "Competition Deadlift",
                                        imageUrl = "https://images.unsplash.com/photo-1583500178690-f7fd39d8440d",
                                        videoUrl = "https://www.youtube.com/watch?v=ytGaGIn3SjE",
                                        sets = 5,
                                        reps = 3,
                                        duration = 0,
                                        restTime = 180,
                                        targetMuscle = "Posterior Chain,Full Body",
                                        equipment = "Barbell,Plates",
                                        difficulty = "Intermediate",
                                        instructions = new[] { "Set up over bar", "Initiate with legs", "Hip hinge movement", "Complete lockout" },
                                        tips = new[] { "Keep bar close", "Drive through heels", "Finish with hips" },
                                        benefits = new[] { "Total body strength", "Posterior chain power", "Competition preparation" }
                                    },
                                    new
                                    {
                                        id = 48,
                                        name = "Pause Bench Press",
                                        imageUrl = "https://images.unsplash.com/photo-1583500178690-f7fd39d8440d",
                                        videoUrl = "https://www.youtube.com/watch?v=rT7DgCr-3pg",
                                        sets = 3,
                                        reps = 5,
                                        duration = 0,
                                        restTime = 120,
                                        targetMuscle = "Chest,Shoulders,Triceps",
                                        equipment = "Barbell,Bench",
                                        difficulty = "Intermediate",
                                        instructions = new[] { "Lower bar to chest", "Pause for 1-2 seconds", "Press up explosively", "Complete lockout" },
                                        tips = new[] { "Practice competition pause", "Stay tight during pause", "Explode off chest" },
                                        benefits = new[] { "Competition specificity", "Bottom position strength", "Technique refinement" }
                                    }
                                }
                            }
                        }
                    })
                },
                // Workout Plan 10: Athletic Performance
                new GeneralWorkoutPlan
                {
             
                    Name = "Athletic Performance",
                    Category = "Athletic",
                    Description = "Sport-specific training for explosive power, speed, agility, and athletic conditioning.",
                    ImageUrl = "https://ponchatoulatherapy.com/wp-content/uploads/2019/02/peak-performance.jpg.webp",
                    Duration = 50,
                    ExerciseCount = 30,
                    Difficulty = "Advanced",
                    Goals = "Explosive Power,Speed,Agility,Sport Performance",
                    CaloriesBurned = 450,
                    KeyFeatures = "Plyometrics,Speed Training,Sport Specific,Power Development",
                    Benefits = "Athletic Performance,Explosive Power,Speed,Injury Prevention",
                    TargetMuscles = "Full Body,Power Systems",
                    Equipment = "Plyometric Box,Cones,Ladder,Medicine Ball",
                    VideoUrl = "https://www.youtube.com/watch?v=g_tea8ZNk5A",
                    IsActive = true,  
                    CreatedAt = DateTime.UtcNow, 
                    UpdatedAt = DateTime.UtcNow,     
                    PlanDetailsJson = JsonSerializer.Serialize(new
                    {
                        days = new[]
                        {
                            new
                            {
                                day = 1,
                                name = "Power & Speed Day",
                                exercises = new[]
                                {
                                    new
                                    {
                                        id = 49,
                                        name = "Box Jumps",
                                        imageUrl = "https://images.unsplash.com/photo-1518611012118-696072aa579a",
                                        videoUrl = "https://www.youtube.com/watch?v=52r_Ul5k03g",
                                        sets = 4,
                                        reps = 5,
                                        duration = 0,
                                        restTime = 120,
                                        targetMuscle = "Legs,Power,Explosiveness",
                                        equipment = "Plyometric Box",
                                        difficulty = "Intermediate",
                                        instructions = new[] { "Stand in front of box", "Jump explosively onto box", "Land softly with bent knees", "Step down carefully" },
                                        tips = new[] { "Focus on landing mechanics", "Start with lower box", "Quality over quantity" },
                                        benefits = new[] { "Explosive leg power", "Reactive strength", "Athletic jumping ability" }
                                    },
                                    new
                                    {
                                        id = 50,
                                        name = "Medicine Ball Slams",
                                        imageUrl = "https://images.unsplash.com/photo-1518611012118-696072aa579a",
                                        videoUrl = "https://www.youtube.com/watch?v=hURDfaLhBYU",
                                        sets = 4,
                                        reps = 8,
                                        duration = 0,
                                        restTime = 90,
                                        targetMuscle = "Core,Shoulders,Full Body",
                                        equipment = "Medicine Ball",
                                        difficulty = "Intermediate",
                                        instructions = new[] { "Hold ball overhead", "Slam down explosively", "Engage core throughout", "Pick up and repeat" },
                                        tips = new[] { "Use your whole body", "Focus on explosive movement", "Protect your back" },
                                        benefits = new[] { "Explosive power", "Core strength", "Athletic conditioning" }
                                    },
                                    new
                                    {
                                        id = 51,
                                        name = "Agility Ladder Drills",
                                        imageUrl = "https://images.unsplash.com/photo-1518611012118-696072aa579a",
                                        videoUrl = "https://www.youtube.com/watch?v=3f4Q6C8T5N4",
                                        sets = 3,
                                        reps = 0,
                                        duration = 60,
                                        restTime = 90,
                                        targetMuscle = "Legs,Coordination,Agility",
                                        equipment = "Agility Ladder",
                                        difficulty = "Intermediate",
                                        instructions = new[] { "Perform various footwork patterns", "In-in-out-out", "Lateral shuffles", "Single leg hops" },
                                        tips = new[] { "Stay light on feet", "Focus on quick feet", "Maintain good posture" },
                                        benefits = new[] { "Foot speed", "Coordination", "Athletic agility" }
                                    },
                                    new
                                    {
                                        id = 52,
                                        name = "Sprint Intervals",
                                        imageUrl = "https://images.unsplash.com/photo-1518611012118-696072aa579a",
                                        videoUrl = "https://www.youtube.com/watch?v=ZwOzC-2Kby4",
                                        sets = 6,
                                        reps = 0,
                                        duration = 30,
                                        restTime = 90,
                                        targetMuscle = "Cardiovascular,Legs,Speed",
                                        equipment = "Track/Space",
                                        difficulty = "Advanced",
                                        instructions = new[] { "Sprint at maximum effort", "Focus on proper form", "Drive with arms", "Maintain speed throughout" },
                                        tips = new[] { "Warm up thoroughly", "Focus on acceleration", "Cool down properly" },
                                        benefits = new[] { "Top speed development", "Anaerobic power", "Running mechanics" }
                                    }
                                }
                            }
                        }
                    })
                },
                // Workout Plan 11: Rehabilitation & Recovery
                new GeneralWorkoutPlan
                {
                 
                    Name = "Rehabilitation & Recovery",
                    Category = "Recovery",
                    Description = "Gentle movement, stretching, and corrective exercises for injury prevention and recovery.",
                    ImageUrl = "https://therecoveryproject.net/wp-content/uploads/2021/02/sideimg-orthopedic-sports-injury-rehabilitation.jpg",
                    Duration = 35,
                    ExerciseCount = 15,
                    Difficulty = "Beginner",
                    Goals = "Injury Prevention,Mobility,Recovery,Pain Relief",
                    CaloriesBurned = 120,
                    KeyFeatures = "Corrective Exercise,Mobility,Gentle Movement,Therapeutic",
                    Benefits = "Injury Prevention,Pain Relief,Better Movement,Flexibility",
                    TargetMuscles = "Full Body,Problem Areas",
                    Equipment = "Foam Roller,Bands,Mat",
                    VideoUrl = "https://www.youtube.com/watch?v=L_xrDAtykMI",
                    IsActive = true,  
                    CreatedAt = DateTime.UtcNow, 
                    UpdatedAt = DateTime.UtcNow,     
                    PlanDetailsJson = JsonSerializer.Serialize(new
                    {
                        days = new[]
                        {
                            new
                            {
                                day = 1,
                                name = "Recovery & Mobility",
                                exercises = new[]
                                {
                                    new
                                    {
                                        id = 53,
                                        name = "Thoracic Spine Mobility",
                                        imageUrl = "https://images.unsplash.com/photo-1506629905607-0e1cb3c50563",
                                        videoUrl = "https://www.youtube.com/watch?v=lLDjNkic_QE",
                                        sets = 3,
                                        reps = 10,
                                        duration = 0,
                                        restTime = 30,
                                        targetMuscle = "Upper Back,Spine",
                                        equipment = "Mat",
                                        difficulty = "Beginner",
                                        instructions = new[] { "Kneel with hands on ground", "Rotate one arm up and back", "Follow with your eyes", "Return and repeat" },
                                        tips = new[] { "Move slowly and controlled", "Feel the stretch", "Don't force the movement" },
                                        benefits = new[] { "Spinal mobility", "Posture improvement", "Upper back health" }
                                    },
                                    new
                                    {
                                        id = 54,
                                        name = "Hip Flexor Stretch",
                                        imageUrl = "https://images.unsplash.com/photo-1506629905607-0e1cb3c50563",
                                        videoUrl = "https://www.youtube.com/watch?v=UGEpQ1BRx-4",
                                        sets = 3,
                                        reps = 0,
                                        duration = 60,
                                        restTime = 30,
                                        targetMuscle = "Hip Flexors,Quads",
                                        equipment = "Mat",
                                        difficulty = "Beginner",
                                        instructions = new[] { "Kneel in lunge position", "Push hips forward", "Feel stretch in front of hip", "Hold and breathe" },
                                        tips = new[] { "Don't arch back excessively", "Feel stretch in hip, not back", "Relax into the stretch" },
                                        benefits = new[] { "Hip mobility", "Posture improvement", "Lower back relief" }
                                    },
                                    new
                                    {
                                        id = 55,
                                        name = "Glute Bridges",
                                        imageUrl = "https://images.unsplash.com/photo-1506629905607-0e1cb3c50563",
                                        videoUrl = "https://www.youtube.com/watch?v=OUgsJ8-Vi0E",
                                        sets = 3,
                                        reps = 15,
                                        duration = 0,
                                        restTime = 45,
                                        targetMuscle = "Glutes,Core",
                                        equipment = "Mat",
                                        difficulty = "Beginner",
                                        instructions = new[] { "Lie on back with knees bent", "Squeeze glutes and lift hips", "Create straight line", "Lower slowly" },
                                        tips = new[] { "Focus on glute activation", "Don't arch back excessively", "Feel the squeeze" },
                                        benefits = new[] { "Glute activation", "Hip stability", "Lower back support" }
                                    },
                                    new
                                    {
                                        id = 56,
                                        name = "Band Pull-Aparts",
                                        imageUrl = "https://images.unsplash.com/photo-1506629905607-0e1cb3c50563",
                                        videoUrl = "https://www.youtube.com/watch?v=ak4cvO8vSKY",
                                        sets = 3,
                                        reps = 15,
                                        duration = 0,
                                        restTime = 30,
                                        targetMuscle = "Rear Delts,Upper Back",
                                        equipment = "Resistance Band",
                                        difficulty = "Beginner",
                                        instructions = new[] { "Hold band at shoulder height", "Pull band apart", "Squeeze shoulder blades", "Return slowly" },
                                        tips = new[] { "Keep arms straight", "Focus on rear delts", "Control the return" },
                                        benefits = new[] { "Posture improvement", "Rear delt strength", "Upper back activation" }
                                    }
                                }
                            }
                        }
                    })
                },
                // Workout Plan 12: Martial Arts Conditioning
                new GeneralWorkoutPlan
                {
               
                    Name = "Martial Arts Conditioning",
                    Category = "Martial Arts",
                    Description = "Combat sports conditioning with focus on explosive power, flexibility, and martial arts specific movements.",
                    ImageUrl = "https://centurymartialarts.com/cdn/shop/collections/training-gear-359488.jpg?v=1687903111&width=1920",
                    Duration = 45,
                    ExerciseCount = 25,
                    Difficulty = "Intermediate",
                    Goals = "Combat Conditioning,Flexibility,Power,Martial Arts Performance",
                    CaloriesBurned = 380,
                    KeyFeatures = "Combat Specific,Explosive Power,Flexibility,Conditioning",
                    Benefits = "Combat Fitness,Explosive Power,Flexibility,Mental Focus",
                    TargetMuscles = "Full Body,Core,Explosive Power",
                    Equipment = "Heavy Bag,Medicine Ball,Bodyweight",
                    VideoUrl = "https://www.youtube.com/watch?v=QpWc8cfkOpc",
                    IsActive = true,  
                    CreatedAt = DateTime.UtcNow, 
                    UpdatedAt = DateTime.UtcNow,     
                    PlanDetailsJson = JsonSerializer.Serialize(new
                    {
                        days = new[]
                        {
                            new
                            {
                                day = 1,
                                name = "Combat Conditioning",
                                exercises = new[]
                                {
                                    new
                                    {
                                        id = 57,
                                        name = "Heavy Bag Combinations",
                                        imageUrl = "https://images.unsplash.com/photo-1544367567-0f2fcb009e0b",
                                        videoUrl = "https://www.youtube.com/watch?v=t5xpShBCGxQ",
                                        sets = 5,
                                        reps = 0,
                                        duration = 180,
                                        restTime = 60,
                                        targetMuscle = "Full Body,Cardio,Power",
                                        equipment = "Heavy Bag,Gloves",
                                        difficulty = "Intermediate",
                                        instructions = new[] { "Throw jab-cross combinations", "Add hooks and uppercuts", "Include kicks if trained", "Focus on technique and power" },
                                        tips = new[] { "Keep hands up", "Breathe with punches", "Focus on form over power" },
                                        benefits = new[] { "Combat conditioning", "Hand-eye coordination", "Explosive power" }
                                    },
                                    new
                                    {
                                        id = 58,
                                        name = "Sprawls",
                                        imageUrl = "https://images.unsplash.com/photo-1544367567-0f2fcb009e0b",
                                        videoUrl = "https://www.youtube.com/watch?v=cUxh2GDrDnw",
                                        sets = 4,
                                        reps = 10,
                                        duration = 0,
                                        restTime = 60,
                                        targetMuscle = "Full Body,Core,Conditioning",
                                        equipment = "Bodyweight",
                                        difficulty = "Intermediate",
                                        instructions = new[] { "Start in fighting stance", "Drop to sprawl position", "Kick legs back", "Return to standing quickly" },
                                        tips = new[] { "Explode back to feet", "Keep hands up", "Land soft on hands" },
                                        benefits = new[] { "Takedown defense", "Explosive conditioning", "Full body power" }
                                    },
                                    new
                                    {
                                        id = 59,
                                        name = "Plyometric Push-ups",
                                        imageUrl = "https://images.unsplash.com/photo-1544367567-0f2fcb009e0b",
                                        videoUrl = "https://www.youtube.com/watch?v=vUNT_b_6YPs",
                                        sets = 4,
                                        reps = 6,
                                        duration = 0,
                                        restTime = 90,
                                        targetMuscle = "Chest,Shoulders,Power",
                                        equipment = "Bodyweight",
                                        difficulty = "Advanced",
                                        instructions = new[] { "Perform explosive push-up", "Push off ground", "Land softly", "Immediately go into next rep" },
                                        tips = new[] { "Land with bent arms", "Focus on explosive power", "Start with regular push-ups" },
                                        benefits = new[] { "Upper body power", "Explosive pushing strength", "Athletic conditioning" }
                                    },
                                    new
                                    {
                                        id = 60,
                                        name = "Dynamic Kicks",
                                        imageUrl = "https://images.unsplash.com/photo-1544367567-0f2fcb009e0b",
                                        videoUrl = "https://www.youtube.com/watch?v=Ll-S21ZhGuY",
                                        sets = 4,
                                        reps = 10,
                                        duration = 0,
                                        restTime = 60,
                                        targetMuscle = "Legs,Core,Balance",
                                        equipment = "Bodyweight",
                                        difficulty = "Intermediate",
                                        instructions = new[] { "Front kicks", "Side kicks", "Roundhouse kicks", "Focus on form and balance" },
                                        tips = new[] { "Start slow and controlled", "Focus on technique", "Use wall for balance if needed" },
                                        benefits = new[] { "Leg strength", "Balance", "Martial arts technique" }
                                    }
                                }
                            }
                        }
                    })
                },
                // Workout Plan 13: Swimmer's Strength
                new GeneralWorkoutPlan
                {
                  
                    Name = "Swimmer's Strength",
                    Category = "Swimming",
                    Description = "Dry-land training specifically designed for swimmers focusing on stroke-specific strength and conditioning.",
                    ImageUrl = "https://vmrw8k5h.tinifycdn.com/news/wp-content/uploads/2016/08/anthony-ervin-muscles-celebrate-rio-1024x669.jpg",
                    Duration = 40,
                    ExerciseCount = 20,
                    Difficulty = "Intermediate",
                    Goals = "Swimming Performance,Stroke Power,Endurance,Technique",
                    CaloriesBurned = 280,
                    KeyFeatures = "Swimming Specific,Stroke Simulation,Core Focus,Endurance",
                    Benefits = "Swimming Performance,Stroke Power,Injury Prevention,Endurance",
                    TargetMuscles = "Shoulders,Back,Core,Full Body",
                    Equipment = "Resistance Bands,Pull-up Bar,Medicine Ball",
                    VideoUrl = "https://www.youtube.com/watch?v=5uHMDI_LuQU",
                    IsActive = true,  
                    CreatedAt = DateTime.UtcNow, 
                    UpdatedAt = DateTime.UtcNow,     
                    PlanDetailsJson = JsonSerializer.Serialize(new
                    {
                        days = new[]
                        {
                            new
                            {
                                day = 1,
                                name = "Swim-Specific Strength",
                                exercises = new[]
                                {
                                    new
                                    {
                                        id = 61,
                                        name = "Lat Pulldowns",
                                        imageUrl = "https://images.unsplash.com/photo-1571019613454-1cb2f99b2d8b",
                                        videoUrl = "https://www.youtube.com/watch?v=CAwf7n6Luuc",
                                        sets = 4,
                                        reps = 12,
                                        duration = 0,
                                        restTime = 75,
                                        targetMuscle = "Lats,Back,Swimming Power",
                                        equipment = "Cable Machine/Bands",
                                        difficulty = "Intermediate",
                                        instructions = new[] { "Pull bar to upper chest", "Squeeze lats at bottom", "Control the return", "Focus on stroke pattern" },
                                        tips = new[] { "Think about swimming stroke", "Keep chest up", "Don't use momentum" },
                                        benefits = new[] { "Swimming pull strength", "Lat development", "Stroke power" }
                                    },
                                    new
                                    {
                                        id = 62,
                                        name = "Band Pull-Aparts",
                                        imageUrl = "https://images.unsplash.com/photo-1571019613454-1cb2f99b2d8b",
                                        videoUrl = "https://www.youtube.com/watch?v=ak4cvO8vSKY",
                                        sets = 4,
                                        reps = 15,
                                        duration = 0,
                                        restTime = 45,
                                        targetMuscle = "Rear Delts,Upper Back",
                                        equipment = "Resistance Band",
                                        difficulty = "Beginner",
                                        instructions = new[] { "Hold band at shoulder height", "Pull apart with straight arms", "Squeeze shoulder blades", "Control return" },
                                        tips = new[] { "Focus on rear delts", "Keep arms straight", "Feel the squeeze" },
                                        benefits = new[] { "Shoulder health", "Posture", "Stroke balance" }
                                    },
                                    new
                                    {
                                        id = 63,
                                        name = "Flutter Kicks",
                                        imageUrl = "https://images.unsplash.com/photo-1571019613454-1cb2f99b2d8b",
                                        videoUrl = "https://www.youtube.com/watch?v=yZGBKdJyLI4",
                                        sets = 4,
                                        reps = 0,
                                        duration = 45,
                                        restTime = 60,
                                        targetMuscle = "Core,Hip Flexors,Kick Strength",
                                        equipment = "Mat",
                                        difficulty = "Intermediate",
                                        instructions = new[] { "Lie on back", "Keep legs straight", "Alternate small kicks", "Keep core engaged" },
                                        tips = new[] { "Small, quick movements", "Keep lower back pressed down", "Breathe rhythmically" },
                                        benefits = new[] { "Kick strength", "Core endurance", "Swimming-specific conditioning" }
                                    },
                                    new
                                    {
                                        id = 64,
                                        name = "Streamline Hold",
                                        imageUrl = "https://images.unsplash.com/photo-1571019613454-1cb2f99b2d8b",
                                        videoUrl = "https://www.youtube.com/watch?v=JM5KIv-mKcc",
                                        sets = 4,
                                        reps = 0,
                                        duration = 30,
                                        restTime = 60,
                                        targetMuscle = "Core,Shoulders,Position Strength",
                                        equipment = "Wall",
                                        difficulty = "Beginner",
                                        instructions = new[] { "Arms overhead in streamline", "Squeeze biceps to ears", "Engage core", "Hold position" },
                                        tips = new[] { "Keep arms straight", "Don't arch back", "Maintain position" },
                                        benefits = new[] { "Streamline strength", "Core stability", "Position awareness" }
                                    }
                                }
                            }
                        }
                    })
                },
                // Workout Plan 14: Endurance Running
                new GeneralWorkoutPlan
                {
                 
                    Name = "Endurance Running",
                    Category = "Running",
                    Description = "Comprehensive running program building aerobic base, endurance, and running-specific strength.",
                    ImageUrl = "https://cdn.centr.com/content/22000/21968/images/landscapewidemobile2x-dc-endurance-header-169.jpg",
                    Duration = 45,
                    ExerciseCount = 15,
                    Difficulty = "Intermediate",
                    Goals = "Endurance,Running Performance,Aerobic Base,Distance",
                    CaloriesBurned = 400,
                    KeyFeatures = "Progressive Distance,Aerobic Base,Running Form,Endurance",
                    Benefits = "Cardiovascular Fitness,Running Endurance,Mental Toughness,Fat Burning",
                    TargetMuscles = "Cardiovascular System,Legs,Core",
                    Equipment = "Running Shoes,Track/Trail",
                    VideoUrl = "https://www.youtube.com/watch?v=_kGESn8ArrU",
                    IsActive = true,  
                    CreatedAt = DateTime.UtcNow, 
                    UpdatedAt = DateTime.UtcNow,     
                    PlanDetailsJson = JsonSerializer.Serialize(new
                    {
                        days = new[]
                        {
                            new
                            {
                                day = 1,
                                name = "Base Building Run",
                                exercises = new[]
                                {
                                    new
                                    {
                                        id = 65,
                                        name = "Dynamic Warm-up",
                                        imageUrl = "https://images.unsplash.com/photo-1544367567-0f2fcb009e0b",
                                        videoUrl = "https://www.youtube.com/watch?v=dilAhJzMGUo",
                                        sets = 1,
                                        reps = 10,
                                        duration = 0,
                                        restTime = 0,
                                        targetMuscle = "Full Body,Preparation",
                                        equipment = "Bodyweight",
                                        difficulty = "Beginner",
                                        instructions = new[] { "Leg swings", "High knees", "Butt kicks", "Ankle circles", "Walking lunges" },
                                        tips = new[] { "Start slowly", "Gradually increase range", "Prepare body for running" },
                                        benefits = new[] { "Injury prevention", "Better performance", "Muscle activation" }
                                    },
                                    new
                                    {
                                        id = 66,
                                        name = "Steady State Run",
                                        imageUrl = "https://images.unsplash.com/photo-1544367567-0f2fcb009e0b",
                                        videoUrl = "https://www.youtube.com/watch?v=_kGESn8ArrU",
                                        sets = 1,
                                        reps = 0,
                                        duration = 1800,
                                        restTime = 0,
                                        targetMuscle = "Cardiovascular,Legs,Endurance",
                                        equipment = "Running Shoes",
                                        difficulty = "Intermediate",
                                        instructions = new[] { "Maintain steady, comfortable pace", "Focus on breathing rhythm", "Land midfoot", "Keep relaxed posture" },
                                        tips = new[] { "Conversational pace", "Listen to your body", "Focus on form" },
                                        benefits = new[] { "Aerobic base building", "Endurance", "Fat burning" }
                                    },
                                    new
                                    {
                                        id = 67,
                                        name = "Running Drills",
                                        imageUrl = "https://images.unsplash.com/photo-1544367567-0f2fcb009e0b",
                                        videoUrl = "https://www.youtube.com/watch?v=8opcQdC-V-U",
                                        sets = 3,
                                        reps = 0,
                                        duration = 60,
                                        restTime = 60,
                                        targetMuscle = "Running Form,Coordination",
                                        equipment = "Running Space",
                                        difficulty = "Intermediate",
                                        instructions = new[] { "High knees", "Butt kicks", "A-skips", "Carioca", "Strides" },
                                        tips = new[] { "Focus on form", "Don't overstride", "Stay relaxed" },
                                        benefits = new[] { "Running form", "Neuromuscular coordination", "Efficiency" }
                                    },
                                    new
                                    {
                                        id = 68,
                                        name = "Cool Down Walk",
                                        imageUrl = "https://images.unsplash.com/photo-1544367567-0f2fcb009e0b",
                                        videoUrl = "https://www.youtube.com/watch?v=Fh_f0qMOTw4",
                                        sets = 1,
                                        reps = 0,
                                        duration = 600,
                                        restTime = 0,
                                        targetMuscle = "Recovery,Circulation",
                                        equipment = "None",
                                        difficulty = "Beginner",
                                        instructions = new[] { "Walk at easy pace", "Focus on breathing", "Gradually slow heart rate", "Prepare for stretching" },
                                        tips = new[] { "Don't stop immediately", "Keep moving", "Hydrate properly" },
                                        benefits = new[] { "Active recovery", "Improved circulation", "Better adaptation" }
                                    }
                                }
                            }
                        }
                    })
                },
                // Workout Plan 15: Senior Fitness
                new GeneralWorkoutPlan
                {
                  
                    Name = "Senior Fitness",
                    Category = "Senior",
                    Description = "Age-appropriate fitness program focusing on balance, flexibility, strength, and functional movement for seniors.",
                    ImageUrl = "https://discoveryvillages.com/wp-content/uploads/2021/02/Keeping-Senior-Citizens-Active-and-Engaged.jpeg",
                    Duration = 30,
                    ExerciseCount = 12,
                    Difficulty = "Beginner",
                    Goals = "Balance,Flexibility,Functional Strength,Fall Prevention",
                    CaloriesBurned = 150,
                    KeyFeatures = "Low Impact,Balance Focus,Functional Movements,Safety",
                    Benefits = "Better Balance,Increased Mobility,Fall Prevention,Quality of Life",
                    TargetMuscles = "Full Body,Balance,Functional Movement",
                    Equipment = "Chair,Light Weights,Mat",
                    VideoUrl = "https://www.youtube.com/watch?v=DhqmNxuq8Ng",
                    IsActive = true,  
                    CreatedAt = DateTime.UtcNow, 
                    UpdatedAt = DateTime.UtcNow,     
                    PlanDetailsJson = JsonSerializer.Serialize(new
                    {
                        days = new[]
                        {
                            new
                            {
                                day = 1,
                                name = "Senior Wellness Session",
                                exercises = new[]
                                {
                                    new
                                    {
                                        id = 69,
                                        name = "Chair Sit-to-Stand",
                                        imageUrl = "https://images.unsplash.com/photo-1506629905607-0e1cb3c50563",
                                        videoUrl = "https://www.youtube.com/watch?v=t7D6QvPb_eo",
                                        sets = 3,
                                        reps = 10,
                                        duration = 0,
                                        restTime = 60,
                                        targetMuscle = "Legs,Functional Strength",
                                        equipment = "Chair",
                                        difficulty = "Beginner",
                                        instructions = new[] { "Sit on edge of chair", "Stand up without using hands", "Sit back down slowly", "Keep chest up" },
                                        tips = new[] { "Use arms if needed initially", "Go at your own pace", "Focus on control" },
                                        benefits = new[] { "Leg strength", "Functional movement", "Independence" }
                                    },
                                    new
                                    {
                                        id = 70,
                                        name = "Standing Balance",
                                        imageUrl = "https://images.unsplash.com/photo-1506629905607-0e1cb3c50563",
                                        videoUrl = "https://www.youtube.com/watch?v=CZstBrYvJyk",
                                        sets = 3,
                                        reps = 0,
                                        duration = 30,
                                        restTime = 60,
                                        targetMuscle = "Balance,Core,Stability",
                                        equipment = "Chair for Support",
                                        difficulty = "Beginner",
                                        instructions = new[] { "Stand on one foot", "Hold onto chair if needed", "Focus on one point", "Switch feet" },
                                        tips = new[] { "Use chair for safety", "Start with brief holds", "Progress gradually" },
                                        benefits = new[] { "Balance improvement", "Fall prevention", "Confidence" }
                                    },
                                    new
                                    {
                                        id = 71,
                                        name = "Gentle Arm Circles",
                                        imageUrl = "https://images.unsplash.com/photo-1506629905607-0e1cb3c50563",
                                        videoUrl = "https://www.youtube.com/watch?v=3VcKaXpzqRo",
                                        sets = 3,
                                        reps = 10,
                                        duration = 0,
                                        restTime = 30,
                                        targetMuscle = "Shoulders,Mobility",
                                        equipment = "Light Weights Optional",
                                        difficulty = "Beginner",
                                        instructions = new[] { "Extend arms to sides", "Make small circles", "Gradually increase size", "Reverse direction" },
                                        tips = new[] { "Move within comfort range", "Don't force movement", "Breathe naturally" },
                                        benefits = new[] { "Shoulder mobility", "Upper body movement", "Joint health" }
                                    },
                                    new
                                    {
                                        id = 72,
                                        name = "Heel-to-Toe Walk",
                                        imageUrl = "https://images.unsplash.com/photo-1506629905607-0e1cb3c50563",
                                        videoUrl = "https://www.youtube.com/watch?v=CZstBrYvJyk",
                                        sets = 3,
                                        reps = 10,
                                        duration = 0,
                                        restTime = 60,
                                        targetMuscle = "Balance,Coordination",
                                        equipment = "Wall for Support",
                                        difficulty = "Beginner",
                                        instructions = new[] { "Walk in straight line", "Place heel directly in front of toe", "Use wall for balance", "Look ahead" },
                                        tips = new[] { "Go slowly", "Use wall if needed", "Focus on straight line" },
                                        benefits = new[] { "Dynamic balance", "Coordination", "Confidence walking" }
                                    }
                                }
                            }
                        }
                    })
                }
            };
        }
    }
} 