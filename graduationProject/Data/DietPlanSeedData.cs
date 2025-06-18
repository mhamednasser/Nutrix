using graduationProject.Models;
using System.Text.Json;

namespace graduationProject.Data
{
    public static class DietPlanSeedData
    {
        public static List<GeneralDietPlan> GetDietPlans()
        {
            return new List<GeneralDietPlan>
            {
                new GeneralDietPlan
                {
                   
                    Name = "Mediterranean Diet",
                    Category = "Balanced",
                    Description = "Heart-healthy eating pattern inspired by Mediterranean countries with emphasis on olive oil, fish, vegetables, and whole grains.",
                    ImageUrl = "https://images.unsplash.com/photo-1498837167922-ddd27525d352",
                    Duration = 30,
                    DailyCalories = 2000,
                    Difficulty = "Beginner",
                    Goals = "Heart Health,Weight Management,Anti-inflammatory",
                    ProteinPercentage = 20,
                    CarbPercentage = 50,
                    FatPercentage = 30,
                    KeyFeatures = "Olive Oil,Fish,Vegetables,Whole Grains,Nuts",
                    Benefits = "Heart Health,Anti-inflammatory,Weight Management,Brain Health",
                    VideoUrl = "https://www.youtube.com/watch?v=LbtwwZP4Yfs",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    PlanDetailsJson = JsonSerializer.Serialize(new
                    {
                        breakfast = new[]
                        {
                            new
                            {
                                id = 1,
                                name = "Greek Yogurt with Berries",
                                imageUrl = "https://images.unsplash.com/photo-1488477181946-6428a0291777",
                                videoUrl = "https://www.youtube.com/shorts/oM28PAQdmyc?feature=share",
                                calories = 280,
                                time = 5,
                                macros = new { fat = 8, protein = 20, carbs = 35 },
                                ingredients = new[] { "1 cup Greek yogurt", "1/2 cup mixed berries", "1 tbsp honey", "1 tbsp almonds" },
                                steps = new[] { "Place Greek yogurt in bowl", "Top with fresh berries", "Drizzle with honey", "Sprinkle with chopped almonds" },
                                benefits = new[] { "High in Protein: Supports muscle health", "Rich in Antioxidants: Berries provide powerful antioxidants", "Heart Healthy: Greek yogurt supports cardiovascular health" }
                            },
                            new
                            {
                                id = 2,
                                name = "Mediterranean Omelet",
                                imageUrl = "https://images.unsplash.com/photo-1525351484163-7529414344d8",
                                videoUrl = "https://www.youtube.com/shorts/rjq988JMH2Q?feature=share",
                                calories = 320,
                                time = 10,
                                macros = new { fat = 22, protein = 18, carbs = 8 },
                                ingredients = new[] { "3 large eggs", "1/4 cup feta cheese", "1/4 cup olives", "1 tomato", "2 tbsp olive oil" },
                                steps = new[] { "Beat eggs in bowl", "Heat olive oil in pan", "Pour eggs and cook until set", "Add feta, olives, and tomato", "Fold omelet and serve" },
                                benefits = new[] { "Complete Protein: Eggs provide all essential amino acids", "Healthy Fats: Olive oil supports heart health", "Mediterranean Flavors: Authentic taste with health benefits" }
                            }
                        },
                        lunch = new[]
                        {
                            new
                            {
                                id = 3,
                                name = "Grilled Salmon Salad",
                                imageUrl = "https://images.unsplash.com/photo-1467003909585-2f8a72700288",
                                videoUrl = "https://www.youtube.com/shorts/F-43RBEqHoE?feature=share",
                                calories = 450,
                                time = 15,
                                macros = new { fat = 28, protein = 35, carbs = 12 },
                                ingredients = new[] { "150g salmon fillet", "2 cups mixed greens", "1/2 cucumber", "10 cherry tomatoes", "2 tbsp olive oil", "1 tbsp lemon juice" },
                                steps = new[] { "Season salmon with herbs", "Grill salmon for 4-5 minutes each side", "Mix greens, cucumber, tomatoes", "Top with grilled salmon", "Drizzle with olive oil and lemon" },
                                benefits = new[] { "Omega-3 Rich: Salmon provides essential fatty acids", "Heart Healthy: Supports cardiovascular health", "Anti-inflammatory: Reduces inflammation markers" }
                            },
                            new
                            {
                                id = 4,
                                name = "Quinoa Tabbouleh",
                                imageUrl = "https://images.unsplash.com/photo-1512621776951-a57141f2eefd",
                                videoUrl = "https://www.youtube.com/shorts/ivOTn3zR_7w?feature=share",
                                calories = 380,
                                time = 20,
                                macros = new { fat = 14, protein = 12, carbs = 55 },
                                ingredients = new[] { "1 cup cooked quinoa", "2 tomatoes diced", "1/2 cup parsley", "1/4 cup mint", "3 tbsp olive oil", "2 tbsp lemon juice" },
                                steps = new[] { "Cook quinoa and let cool", "Dice tomatoes finely", "Chop parsley and mint", "Mix all ingredients", "Season with salt and pepper", "Chill for 30 minutes" },
                                benefits = new[] { "Complete Protein: Quinoa contains all amino acids", "Fiber Rich: Supports digestive health", "Mediterranean Style: Traditional flavors and nutrients" }
                            }
                        },
                        dinner = new[]
                        {
                            new
                            {
                                id = 5,
                                name = "Baked Sea Bass with Vegetables",
                                imageUrl = "https://images.unsplash.com/photo-1519708227418-c8fd9a32b7a2",
                                videoUrl = "https://www.youtube.com/shorts/nCw67rYCs24?feature=share",
                                calories = 520,
                                time = 25,
                                macros = new { fat = 24, protein = 42, carbs = 18 },
                                ingredients = new[] { "200g sea bass fillet", "1 zucchini", "1 bell pepper", "1 onion", "3 tbsp olive oil", "2 cloves garlic", "Fresh herbs" },
                                steps = new[] { "Preheat oven to 400°F", "Cut vegetables into chunks", "Place fish and vegetables on baking sheet", "Drizzle with olive oil and herbs", "Bake for 20-25 minutes" },
                                benefits = new[] { "Lean Protein: Sea bass is low in fat, high in protein", "Vegetable Rich: Provides essential vitamins and minerals", "Heart Healthy: Omega-3 fatty acids support cardiovascular health" }
                            },
                            new
                            {
                                id = 6,
                                name = "Mediterranean Chicken Bowl",
                                imageUrl = "https://images.unsplash.com/photo-1546833999-b9f581a1996d",
                                videoUrl = "https://www.youtube.com/shorts/KRFHUZe2E-g?feature=share",
                                calories = 480,
                                time = 18,
                                macros = new { fat = 20, protein = 38, carbs = 32 },
                                ingredients = new[] { "150g chicken breast", "1/2 cup brown rice", "1/2 cucumber", "1/4 cup feta", "2 tbsp tzatziki", "Mixed greens" },
                                steps = new[] { "Grill seasoned chicken breast", "Cook brown rice", "Dice cucumber", "Arrange ingredients in bowl", "Top with feta and tzatziki" },
                                benefits = new[] { "High Protein: Supports muscle maintenance", "Balanced Nutrition: Contains all macronutrients", "Mediterranean Flavors: Authentic and healthy combination" }
                            }
                        }
                    })
                },
                new GeneralDietPlan
                {
               
                    Name = "Keto Diet",
                    Category = "High-Fat",
                    Description = "High-fat, moderate-protein, and low-carb diet designed to induce ketosis for weight loss and improved health.",
                    ImageUrl = "https://cdn.britannica.com/87/234287-050-61908AB8/Ketogenic-diet-Cuisine-food.jpg",
                    Duration = 30,
                    DailyCalories = 2000,
                    Difficulty = "Intermediate",
                    Goals = "Weight Loss,Ketosis,Blood Sugar Control",
                    ProteinPercentage = 20,
                    CarbPercentage = 5,
                    FatPercentage = 75,
                    KeyFeatures = "High Fat,Moderate Protein,Low Carb",
                    Benefits = "Weight Loss,Ketosis,Blood Sugar Control,Improved Brain Function",
                    VideoUrl = "https://www.youtube.com/watch?v=dQw4w9WgXcQ",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    PlanDetailsJson = JsonSerializer.Serialize(new
                    {
                        breakfast = new[]
                        {
                            new
                            {
                                id = 1,
                                name = "Keto Breakfast Smoothie",
                                imageUrl = "https://images.pexels.com/photos/8330380/pexels-photo-8330380.jpeg",
                                videoUrl = "https://www.youtube.com/watch?v=dQw4w9WgXcQ",
                                calories = 200,
                                time = 5,
                                macros = new { fat = 18, protein = 10, carbs = 10 },
                                ingredients = new[] { "1 cup almond milk", "1/2 cup spinach", "1/2 cup frozen berries", "1 tbsp coconut oil", "1 tbsp flaxseed" },
                                steps = new[] { "Blend all ingredients in blender", "Pour into glass" },
                                benefits = new[] { "High in Fat: Promotes ketosis", "Rich in Antioxidants: Berries provide powerful antioxidants", "Heart Healthy: Coconut oil supports cardiovascular health" }
                            },
                            new
                            {
                                id = 2,
                                name = "Keto Breakfast Scramble",
                                imageUrl = "https://www.flavcity.com/wp-content/uploads/2019/11/IMG_0005-40-2.jpg",
                                videoUrl = "https://www.youtube.com/watch?v=dQw4w9WgXcQ",
                                calories = 250,
                                time = 10,
                                macros = new { fat = 20, protein = 15, carbs = 5 },
                                ingredients = new[] { "2 large eggs", "1/2 cup spinach", "1/2 cup mushrooms", "1/2 cup feta cheese", "1 tbsp coconut oil" },
                                steps = new[] { "Beat eggs in bowl", "Heat coconut oil in pan", "Add spinach and mushrooms", "Pour eggs and cook until set", "Add feta and serve" },
                                benefits = new[] { "Complete Protein: Eggs provide all essential amino acids", "Healthy Fats: Coconut oil supports heart health", "Mediterranean Flavors: Authentic taste with health benefits" }
                            }
                        },
                        lunch = new[]
                        {
                            new
                            {
                                id = 3,
                                name = "Keto Chicken Salad",
                                imageUrl = "https://www.ruled.me/wp-content/uploads/2019/07/low-carb-thai-chicken-salad-bowl-featured.jpg",
                                videoUrl = "https://www.youtube.com/watch?v=dQw4w9WgXcQ",
                                calories = 400,
                                time = 15,
                                macros = new { fat = 24, protein = 30, carbs = 10 },
                                ingredients = new[] { "150g chicken breast", "2 cups mixed greens", "1/2 cucumber", "10 cherry tomatoes", "2 tbsp olive oil", "1 tbsp lemon juice" },
                                steps = new[] { "Season chicken with herbs", "Grill chicken for 4-5 minutes each side", "Mix greens, cucumber, tomatoes", "Top with grilled chicken", "Drizzle with olive oil and lemon" },
                                benefits = new[] { "Lean Protein: Chicken is high in protein", "Heart Healthy: Supports cardiovascular health", "Anti-inflammatory: Reduces inflammation markers" }
                            },
                            new
                            {
                                id = 4,
                                name = "Keto Cauliflower Rice",
                                imageUrl = "https://www.loveandotherspices.com/wp-content/uploads/2021/08/KetoCauliflowerRice.jpg",
                                videoUrl = "https://www.youtube.com/watch?v=dQw4w9WgXcQ",
                                calories = 300,
                                time = 20,
                                macros = new { fat = 18, protein = 10, carbs = 12 },
                                ingredients = new[] { "1/2 cup cauliflower rice", "1/2 cup chicken broth", "1/2 cup spinach", "1/2 cup grated cheese", "1 tbsp coconut oil" },
                                steps = new[] { "Cook cauliflower rice", "Add chicken broth and spinach", "Cook until spinach is wilted", "Add grated cheese and coconut oil", "Mix well" },
                                benefits = new[] { "Complete Protein: Cheese provides all essential amino acids", "Fiber Rich: Supports digestive health", "Mediterranean Style: Traditional flavors and nutrients" }
                            }
                        },
                        dinner = new[]
                        {
                            new
                            {
                                id = 5,
                                name = "Keto Beef Stir Fry",
                                imageUrl = "https://grumpyshoneybunch.com/wp-content/uploads/2023/06/Low-Carb-Broccoli-Stir-Fry-hero.jpeg",
                                videoUrl = "https://www.youtube.com/watch?v=dQw4w9WgXcQ",
                                calories = 500,
                                time = 25,
                                macros = new { fat = 32, protein = 35, carbs = 10 },
                                ingredients = new[] { "200g beef sirloin", "1 zucchini", "1 bell pepper", "1 onion", "3 tbsp coconut oil", "2 cloves garlic", "Fresh herbs" },
                                steps = new[] { "Heat coconut oil in pan", "Add garlic and onions", "Add beef and cook until browned", "Add zucchini and bell pepper", "Drizzle with coconut oil and herbs" },
                                benefits = new[] { "Lean Protein: Beef is high in protein", "Vegetable Rich: Provides essential vitamins and minerals", "Heart Healthy: Coconut oil supports cardiovascular health" }
                            },
                            new
                            {
                                id = 6,
                                name = "Keto Chicken Stir Fry",
                                imageUrl = "https://www.ruled.me/wp-content/uploads/2021/03/Chicken-Mushroom-Broccoli-Stir-Fry-Featured.jpg",
                                videoUrl = "https://www.youtube.com/watch?v=dQw4w9WgXcQ",
                                calories = 450,
                                time = 18,
                                macros = new { fat = 24, protein = 30, carbs = 10 },
                                ingredients = new[] { "150g chicken breast", "1 zucchini", "1 bell pepper", "1 onion", "2 tbsp coconut oil", "2 cloves garlic", "Fresh herbs" },
                                steps = new[] { "Heat coconut oil in pan", "Add garlic and onions", "Add chicken and cook until browned", "Add zucchini and bell pepper", "Drizzle with coconut oil and herbs" },
                                benefits = new[] { "High Protein: Chicken is high in protein", "Heart Healthy: Supports cardiovascular health", "Anti-inflammatory: Reduces inflammation markers" }
                            }
                        }
                    })
                },
                new GeneralDietPlan
                {
              
                    Name = "Paleo Diet",
                    Category = "Whole Foods",
                    Description = "Eat like our ancestors with whole, unprocessed foods including meat, fish, vegetables, fruits, nuts, and seeds.",
                    ImageUrl = "https://images.unsplash.com/photo-1511690743698-d9d85f2fbf38",
                    Duration = 30,
                    DailyCalories = 1900,
                    Difficulty = "Intermediate",
                    Goals = "Weight Loss,Inflammation Reduction,Digestive Health",
                    ProteinPercentage = 30,
                    CarbPercentage = 35,
                    FatPercentage = 35,
                    KeyFeatures = "No Grains,No Dairy,No Legumes,Whole Foods Only",
                    Benefits = "Better Digestion,Reduced Inflammation,Natural Weight Loss,Improved Energy",
                    VideoUrl = "https://www.youtube.com/watch?v=BMOjVYgYaG8",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    PlanDetailsJson = JsonSerializer.Serialize(new
                    {
                        breakfast = new[]
                        {
                            new
                            {
                                id = 7,
                                name = "Paleo Sweet Potato Hash",
                                imageUrl = "https://images.unsplash.com/photo-1482049016688-2d3e1b311543",
                                videoUrl = "https://www.youtube.com/watch?v=vGr3zIhDX0s",
                                calories = 350,
                                time = 15,
                                macros = new { fat = 18, protein = 16, carbs = 38 },
                                ingredients = new[] { "1 large sweet potato", "2 eggs", "1/2 bell pepper", "1/4 cup onion", "2 tbsp coconut oil", "Herbs and spices" },
                                steps = new[] { "Dice sweet potato and cook in coconut oil", "Add peppers and onions", "Create wells and crack eggs", "Cover and cook until eggs set", "Season with herbs" },
                                benefits = new[] { "Complex Carbs: Sustained energy from sweet potatoes", "Complete Protein: High-quality eggs", "Anti-inflammatory: Coconut oil benefits" }
                            },
                            new
                            {
                                id = 8,
                                name = "Coconut Chia Pudding",
                                imageUrl = "https://images.unsplash.com/photo-1488477181946-6428a0291777",
                                videoUrl = "https://www.youtube.com/watch?v=Nqr0L0JmJ7Q",
                                calories = 280,
                                time = 5,
                                macros = new { fat = 20, protein = 8, carbs = 18 },
                                ingredients = new[] { "3 tbsp chia seeds", "1 cup coconut milk", "1 tbsp honey", "1/2 cup berries", "1 tbsp nuts" },
                                steps = new[] { "Mix chia seeds with coconut milk", "Add honey and stir well", "Refrigerate overnight", "Top with berries and nuts", "Serve chilled" },
                                benefits = new[] { "Omega-3 Rich: Chia seeds provide healthy fats", "Fiber Dense: Supports digestive health", "Natural Sweetness: No refined sugars" }
                            }
                        },
                        lunch = new[]
                        {
                            new
                            {
                                id = 9,
                                name = "Grilled Chicken Salad",
                                imageUrl = "https://images.unsplash.com/photo-1467003909585-2f8a72700288",
                                videoUrl = "https://www.youtube.com/watch?v=KU6AGQJ9-aU",
                                calories = 420,
                                time = 20,
                                macros = new { fat = 22, protein = 35, carbs = 15 },
                                ingredients = new[] { "150g chicken breast", "Mixed greens", "1/2 avocado", "Cherry tomatoes", "Olive oil", "Lemon juice" },
                                steps = new[] { "Season and grill chicken breast", "Prepare mixed green salad", "Slice avocado and tomatoes", "Make simple olive oil dressing", "Combine and serve" },
                                benefits = new[] { "Lean Protein: Supports muscle maintenance", "Healthy Fats: Avocado provides monounsaturated fats", "Nutrient Dense: Variety of vegetables" }
                            },
                            new
                            {
                                id = 10,
                                name = "Zucchini Noodle Bowl",
                                imageUrl = "https://images.unsplash.com/photo-1512621776951-a57141f2eefd",
                                videoUrl = "https://www.youtube.com/watch?v=vr0HWgUKgL8",
                                calories = 380,
                                time = 15,
                                macros = new { fat = 24, protein = 18, carbs = 20 },
                                ingredients = new[] { "2 large zucchini", "100g ground turkey", "1 tbsp olive oil", "Garlic", "Cherry tomatoes", "Fresh basil" },
                                steps = new[] { "Spiralize zucchini into noodles", "Brown ground turkey with garlic", "Add tomatoes and cook", "Toss with zucchini noodles", "Garnish with basil" },
                                benefits = new[] { "Low Carb: Zucchini replaces traditional pasta", "Lean Protein: Turkey is low in fat", "Fresh Flavors: Herbs and vegetables" }
                            }
                        },
                        dinner = new[]
                        {
                            new
                            {
                                id = 11,
                                name = "Herb-Crusted Salmon",
                                imageUrl = "https://images.unsplash.com/photo-1519708227418-c8fd9a32b7a2",
                                videoUrl = "https://www.youtube.com/watch?v=1n-5LRGAz8Q",
                                calories = 480,
                                time = 25,
                                macros = new { fat = 28, protein = 40, carbs = 12 },
                                ingredients = new[] { "180g salmon fillet", "Fresh herbs", "Broccoli", "Sweet potato", "Olive oil", "Lemon" },
                                steps = new[] { "Coat salmon with herb mixture", "Roast sweet potato chunks", "Steam broccoli until tender", "Bake salmon for 15 minutes", "Serve with lemon" },
                                benefits = new[] { "Omega-3 Powerhouse: Supports brain and heart health", "Antioxidant Rich: Herbs provide anti-inflammatory compounds", "Complete Nutrition: Balanced meal with vegetables" }
                            },
                            new
                            {
                                id = 12,
                                name = "Beef and Vegetable Stir-Fry",
                                imageUrl = "https://images.unsplash.com/photo-1546833999-b9f581a1996d",
                                videoUrl = "https://www.youtube.com/watch?v=Q7d5jK8pzSI",
                                calories = 450,
                                time = 18,
                                macros = new { fat = 24, protein = 38, carbs = 16 },
                                ingredients = new[] { "150g beef strips", "Mixed vegetables", "Coconut aminos", "Ginger", "Garlic", "Coconut oil" },
                                steps = new[] { "Heat coconut oil in wok", "Stir-fry beef until browned", "Add vegetables and aromatics", "Season with coconut aminos", "Serve immediately" },
                                benefits = new[] { "High Protein: Supports muscle building", "Nutrient Dense: Variety of colorful vegetables", "Paleo-Friendly: No soy or grains" }
                            }
                        }
                    })
                },
                // Diet Plan 4: DASH Diet
                new GeneralDietPlan
                {
               
                    Name = "DASH Diet",
                    Category = "Heart Healthy", 
                    Description = "Dietary approach to stop hypertension focusing on fruits, vegetables, whole grains, and lean proteins while limiting sodium.",
                    ImageUrl = "https://images.unsplash.com/photo-1490645935967-10de6ba17061",
                    Duration = 30,
                    DailyCalories = 2000,
                    Difficulty = "Beginner",
                    Goals = "Blood Pressure Control,Heart Health,Weight Management",
                    ProteinPercentage = 25,
                    CarbPercentage = 55,
                    FatPercentage = 20,
                    KeyFeatures = "Low Sodium,High Potassium,Whole Grains,Lean Protein",
                    Benefits = "Lower Blood Pressure,Heart Health,Stroke Prevention,Kidney Health",
                    VideoUrl = "https://www.youtube.com/watch?v=uLQsavygtR8",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    PlanDetailsJson = JsonSerializer.Serialize(new
                    {
                        breakfast = new[]
                        {
                            new
                            {
                                id = 13,
                                name = "Oatmeal with Berries and Nuts",
                                imageUrl = "https://images.unsplash.com/photo-1517982856301-9cb8282dfdb4",
                                videoUrl = "https://www.youtube.com/watch?v=GLmNbz5AIY8",
                                calories = 320,
                                time = 10,
                                macros = new { fat = 8, protein = 12, carbs = 52 },
                                ingredients = new[] { "1 cup oats", "1/2 cup blueberries", "1 tbsp walnuts", "1 cup low-fat milk", "1 tsp honey" },
                                steps = new[] { "Cook oats with low-fat milk", "Top with fresh blueberries", "Sprinkle chopped walnuts", "Drizzle with honey" },
                                benefits = new[] { "Heart Healthy: Soluble fiber reduces cholesterol", "Antioxidant Rich: Blueberries support cardiovascular health", "Low Sodium: Supports blood pressure control" }
                            },
                            new
                            {
                                id = 14,
                                name = "Whole Grain Toast with Avocado",
                                imageUrl = "https://images.unsplash.com/photo-1541519527459-826367cb3eba",
                                videoUrl = "https://www.youtube.com/watch?v=PWJWjsNS2JA",
                                calories = 280,
                                time = 5,
                                macros = new { fat = 14, protein = 8, carbs = 32 },
                                ingredients = new[] { "2 slices whole grain bread", "1/2 avocado", "1 tomato", "Black pepper", "Lemon juice" },
                                steps = new[] { "Toast whole grain bread", "Mash avocado with lemon juice", "Spread on toast", "Top with tomato slices", "Season with pepper" },
                                benefits = new[] { "Healthy Fats: Monounsaturated fats support heart health", "Fiber Rich: Whole grains aid digestion", "Potassium Rich: Supports blood pressure regulation" }
                            }
                        },
                        lunch = new[]
                        {
                            new
                            {
                                id = 15,
                                name = "Grilled Chicken and Quinoa Bowl",
                                imageUrl = "https://images.unsplash.com/photo-1546833999-b9f581a1996d",
                                videoUrl = "https://www.youtube.com/watch?v=8jcc4lGIW7E",
                                calories = 420,
                                time = 20,
                                macros = new { fat = 12, protein = 35, carbs = 45 },
                                ingredients = new[] { "150g chicken breast", "1/2 cup quinoa", "Mixed vegetables", "Olive oil", "Herbs", "Lemon" },
                                steps = new[] { "Grill seasoned chicken breast", "Cook quinoa according to package", "Steam mixed vegetables", "Arrange in bowl", "Drizzle with olive oil and lemon" },
                                benefits = new[] { "Lean Protein: Supports muscle maintenance", "Complete Protein: Quinoa provides all amino acids", "Low Sodium: Heart-healthy preparation" }
                            },
                            new
                            {
                                id = 16,
                                name = "Bean and Vegetable Soup",
                                imageUrl = "https://images.unsplash.com/photo-1547592166-23ac45744acd",
                                videoUrl = "https://www.youtube.com/watch?v=BodE_BrLjTI",
                                calories = 350,
                                time = 25,
                                macros = new { fat = 6, protein = 18, carbs = 58 },
                                ingredients = new[] { "1 cup mixed beans", "2 cups vegetables", "Low-sodium broth", "Herbs", "Garlic", "Onion" },
                                steps = new[] { "Sauté onion and garlic", "Add vegetables and broth", "Add beans and simmer", "Season with herbs", "Cook until tender" },
                                benefits = new[] { "High Fiber: Supports digestive and heart health", "Plant Protein: Beans provide essential amino acids", "Low Fat: Heart-healthy option" }
                            }
                        },
                        dinner = new[]
                        {
                            new
                            {
                                id = 17,
                                name = "Baked Salmon with Sweet Potato",
                                imageUrl = "https://images.unsplash.com/photo-1519708227418-c8fd9a32b7a2",
                                videoUrl = "https://www.youtube.com/watch?v=4c9O15PUqm8",
                                calories = 480,
                                time = 30,
                                macros = new { fat = 18, protein = 40, carbs = 35 },
                                ingredients = new[] { "180g salmon fillet", "1 medium sweet potato", "Broccoli", "Olive oil", "Herbs", "Lemon" },
                                steps = new[] { "Bake sweet potato until tender", "Season salmon with herbs", "Bake salmon for 15 minutes", "Steam broccoli", "Serve with lemon" },
                                benefits = new[] { "Omega-3 Rich: Supports heart and brain health", "Potassium Rich: Sweet potato aids blood pressure control", "Anti-inflammatory: Reduces cardiovascular risk" }
                            },
                            new
                            {
                                id = 18,
                                name = "Turkey and Vegetable Stir-Fry",
                                imageUrl = "https://images.unsplash.com/photo-1603133872878-684f208fb84b",
                                videoUrl = "https://www.youtube.com/watch?v=Q7d5jK8pzSI",
                                calories = 380,
                                time = 15,
                                macros = new { fat = 10, protein = 32, carbs = 35 },
                                ingredients = new[] { "150g ground turkey", "Mixed vegetables", "Brown rice", "Low-sodium soy sauce", "Ginger", "Garlic" },
                                steps = new[] { "Cook brown rice", "Brown turkey in pan", "Add vegetables and aromatics", "Season lightly", "Serve over rice" },
                                benefits = new[] { "Lean Protein: Turkey is low in saturated fat", "Whole Grains: Brown rice provides fiber", "Low Sodium: Heart-friendly preparation" }
                            }
                        }
                    })
                },
                // Diet Plan 5: Plant-Based Diet
                new GeneralDietPlan
                {
                
                    Name = "Plant-Based Diet",
                    Category = "Vegan",
                    Description = "Whole food plant-based eating focusing on fruits, vegetables, legumes, nuts, and seeds while eliminating animal products.",
                    ImageUrl = "https://images.unsplash.com/photo-1512621776951-a57141f2eefd",
                    Duration = 30,
                    DailyCalories = 1800,
                    Difficulty = "Intermediate",
                    Goals = "Environmental Health,Weight Loss,Disease Prevention",
                    ProteinPercentage = 15,
                    CarbPercentage = 65,
                    FatPercentage = 20,
                    KeyFeatures = "No Animal Products,High Fiber,Antioxidant Rich,Sustainable",
                    Benefits = "Lower Cholesterol,Reduced Cancer Risk,Environmental Impact,Weight Management",
                    VideoUrl = "https://www.youtube.com/watch?v=d5wabeFTcWg",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    PlanDetailsJson = JsonSerializer.Serialize(new
                    {
                        breakfast = new[]
                        {
                            new
                            {
                                id = 19,
                                name = "Green Smoothie Bowl",
                                imageUrl = "https://images.unsplash.com/photo-1511690743698-d9d85f2fbf38",
                                videoUrl = "https://www.youtube.com/watch?v=Nqr0L0JmJ7Q",
                                calories = 320,
                                time = 10,
                                macros = new { fat = 12, protein = 8, carbs = 48 },
                                ingredients = new[] { "1 cup spinach", "1 banana", "1/2 cup berries", "1 tbsp chia seeds", "1 cup almond milk", "Granola" },
                                steps = new[] { "Blend spinach, banana, berries with almond milk", "Pour into bowl", "Top with chia seeds and granola", "Add fresh fruit" },
                                benefits = new[] { "Nutrient Dense: Packed with vitamins and minerals", "High Fiber: Supports digestive health", "Plant Protein: Chia seeds provide complete protein" }
                            },
                            new
                            {
                                id = 20,
                                name = "Tofu Scramble",
                                imageUrl = "https://images.unsplash.com/photo-1525351484163-7529414344d8",
                                videoUrl = "https://www.youtube.com/watch?v=qoCnde0mq8s",
                                calories = 280,
                                time = 12,
                                macros = new { fat = 14, protein = 18, carbs = 20 },
                                ingredients = new[] { "150g firm tofu", "1/2 cup vegetables", "Nutritional yeast", "Turmeric", "Olive oil", "Spinach" },
                                steps = new[] { "Crumble tofu in heated oil", "Add turmeric and nutritional yeast", "Add vegetables and spinach", "Cook until heated through" },
                                benefits = new[] { "Complete Protein: Tofu provides all essential amino acids", "B-Vitamin Rich: Nutritional yeast supports energy", "Low Saturated Fat: Heart healthy option" }
                            }
                        },
                        lunch = new[]
                        {
                            new
                            {
                                id = 21,
                                name = "Buddha Bowl",
                                imageUrl = "https://images.unsplash.com/photo-1546833999-b9f581a1996d",
                                videoUrl = "https://www.youtube.com/watch?v=8jcc4lGIW7E",
                                calories = 450,
                                time = 20,
                                macros = new { fat = 16, protein = 15, carbs = 65 },
                                ingredients = new[] { "1/2 cup quinoa", "Roasted vegetables", "1/4 avocado", "Chickpeas", "Tahini dressing", "Greens" },
                                steps = new[] { "Cook quinoa", "Roast mixed vegetables", "Arrange quinoa, vegetables, chickpeas in bowl", "Top with avocado", "Drizzle with tahini dressing" },
                                benefits = new[] { "Plant Protein: Quinoa and chickpeas provide complete nutrition", "Healthy Fats: Avocado and tahini support absorption", "Fiber Rich: Supports digestive and heart health" }
                            },
                            new
                            {
                                id = 22,
                                name = "Lentil Soup",
                                imageUrl = "https://images.unsplash.com/photo-1547592166-23ac45744acd",
                                videoUrl = "https://www.youtube.com/watch?v=BodE_BrLjTI",
                                calories = 380,
                                time = 30,
                                macros = new { fat = 8, protein = 18, carbs = 60 },
                                ingredients = new[] { "1 cup red lentils", "Vegetables", "Vegetable broth", "Herbs", "Garlic", "Onion" },
                                steps = new[] { "Sauté onion and garlic", "Add lentils and vegetables", "Pour in broth and simmer", "Season with herbs", "Cook until lentils are tender" },
                                benefits = new[] { "High Protein: Lentils provide plant-based protein", "Iron Rich: Supports energy production", "Low Fat: Heart healthy preparation" }
                            }
                        },
                        dinner = new[]
                        {
                            new
                            {
                                id = 23,
                                name = "Stuffed Bell Peppers",
                                imageUrl = "https://images.unsplash.com/photo-1603133872878-684f208fb84b",
                                videoUrl = "https://www.youtube.com/watch?v=Q7d5jK8pzSI",
                                calories = 400,
                                time = 35,
                                macros = new { fat = 12, protein = 16, carbs = 58 },
                                ingredients = new[] { "4 bell peppers", "1 cup brown rice", "Black beans", "Corn", "Tomatoes", "Herbs" },
                                steps = new[] { "Hollow out bell peppers", "Mix cooked rice with beans, corn, tomatoes", "Stuff peppers with mixture", "Bake until peppers are tender" },
                                benefits = new[] { "Complete Nutrition: Rice and beans provide complete protein", "Fiber Rich: Supports digestive health", "Antioxidant Rich: Colorful vegetables provide vitamins" }
                            },
                            new
                            {
                                id = 24,
                                name = "Mushroom and Walnut Pasta",
                                imageUrl = "https://images.unsplash.com/photo-1512621776951-a57141f2eefd",
                                videoUrl = "https://www.youtube.com/watch?v=vr0HWgUKgL8",
                                calories = 420,
                                time = 18,
                                macros = new { fat = 16, protein = 14, carbs = 62 },
                                ingredients = new[] { "Whole grain pasta", "Mixed mushrooms", "Walnuts", "Garlic", "Olive oil", "Fresh herbs" },
                                steps = new[] { "Cook pasta according to package", "Sauté mushrooms with garlic", "Add walnuts and herbs", "Toss with cooked pasta", "Drizzle with olive oil" },
                                benefits = new[] { "Omega-3 Rich: Walnuts provide healthy fats", "Whole Grains: Pasta provides sustained energy", "Umami Rich: Mushrooms provide satisfying flavor" }
                            }
                        }
                    })
                },
                // Diet Plan 6: Intermittent Fasting 16:8
                new GeneralDietPlan
                {
               
                    Name = "Intermittent Fasting 16:8",
                    Category = "Time-Restricted",
                    Description = "Time-restricted eating with 16-hour fasting window and 8-hour eating window, focusing on nutrient-dense meals.",
                    ImageUrl = "https://www.maurerfoundation.org/wp-content/uploads/Shutterstock_1677548296-scaled.jpg",
                    Duration = 30,
                    DailyCalories = 1900,
                    Difficulty = "Intermediate",
                    Goals = "Weight Loss,Metabolic Health,Autophagy,Insulin Sensitivity",
                    ProteinPercentage = 25,
                    CarbPercentage = 45,
                    FatPercentage = 30,
                    KeyFeatures = "16-Hour Fast,8-Hour Eating Window,Nutrient Dense,Metabolic Benefits",
                    Benefits = "Weight Loss,Improved Insulin Sensitivity,Cellular Repair,Mental Clarity",
                    VideoUrl = "https://www.youtube.com/watch?v=4UkZAwKoCP8",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    PlanDetailsJson = JsonSerializer.Serialize(new
                    {
                        breakfast = new[]
                        {
                            new
                            {
                                id = 25,
                                name = "Break-Fast Protein Bowl",
                                imageUrl = "https://images.unsplash.com/photo-1546833999-b9f581a1996d",
                                videoUrl = "https://www.youtube.com/watch?v=8jcc4lGIW7E",
                                calories = 400,
                                time = 10,
                                macros = new { fat = 18, protein = 28, carbs = 32 },
                                ingredients = new[] { "2 eggs", "1/2 avocado", "Greek yogurt", "Berries", "Nuts", "Seeds" },
                                steps = new[] { "Prepare eggs as preferred", "Slice avocado", "Arrange with yogurt and berries", "Top with nuts and seeds" },
                                benefits = new[] { "Protein Rich: Helps maintain satiety during fasting", "Healthy Fats: Support hormone production", "Nutrient Dense: Maximizes nutrition in eating window" }
                            },
                            new
                            {
                                id = 26,
                                name = "Green Tea and Almonds",
                                imageUrl = "https://images.unsplash.com/photo-1556881286-fc6915169721",
                                videoUrl = "https://www.youtube.com/watch?v=dQw4w9WgXcQ",
                                calories = 200,
                                time = 2,
                                macros = new { fat = 14, protein = 8, carbs = 8 },
                                ingredients = new[] { "Green tea", "1 oz almonds", "Lemon", "Optional: stevia" },
                                steps = new[] { "Brew green tea", "Serve with almonds", "Add lemon if desired" },
                                benefits = new[] { "Antioxidant Rich: Green tea supports cellular health", "Healthy Fats: Almonds provide sustained energy", "Fasting Compatible: Minimal calories maintain fasted state" }
                            }
                        },
                        lunch = new[]
                        {
                            new
                            {
                                id = 27,
                                name = "Salmon and Quinoa Power Bowl",
                                imageUrl = "https://images.unsplash.com/photo-1467003909585-2f8a72700288",
                                videoUrl = "https://www.youtube.com/watch?v=zJLzGaHgQw4",
                                calories = 520,
                                time = 20,
                                macros = new { fat = 22, protein = 38, carbs = 42 },
                                ingredients = new[] { "150g salmon", "1/2 cup quinoa", "Mixed greens", "Vegetables", "Olive oil", "Lemon" },
                                steps = new[] { "Grill salmon with herbs", "Cook quinoa", "Prepare fresh vegetables", "Arrange in bowl", "Dress with olive oil and lemon" },
                                benefits = new[] { "Omega-3 Rich: Supports brain and heart health", "Complete Protein: Salmon and quinoa provide all amino acids", "Anti-inflammatory: Reduces oxidative stress" }
                            },
                            new
                            {
                                id = 28,
                                name = "Chicken and Sweet Potato",
                                imageUrl = "https://images.unsplash.com/photo-1603133872878-684f208fb84b",
                                videoUrl = "https://www.youtube.com/watch?v=Q7d5jK8pzSI",
                                calories = 480,
                                time = 25,
                                macros = new { fat = 16, protein = 36, carbs = 48 },
                                ingredients = new[] { "150g chicken breast", "1 medium sweet potato", "Broccoli", "Olive oil", "Herbs" },
                                steps = new[] { "Bake sweet potato", "Grill seasoned chicken", "Steam broccoli", "Serve together with herbs" },
                                benefits = new[] { "Lean Protein: Supports muscle maintenance during fasting", "Complex Carbs: Sweet potato provides sustained energy", "Nutrient Dense: Maximizes vitamins and minerals" }
                            }
                        },
                        dinner = new[]
                        {
                            new
                            {
                                id = 29,
                                name = "Steak and Vegetable Medley",
                                imageUrl = "https://images.unsplash.com/photo-1546833999-b9f581a1996d",
                                videoUrl = "https://www.youtube.com/watch?v=Q7d5jK8pzSI",
                                calories = 550,
                                time = 20,
                                macros = new { fat = 26, protein = 42, carbs = 28 },
                                ingredients = new[] { "150g lean steak", "Mixed vegetables", "Olive oil", "Garlic", "Herbs", "Side salad" },
                                steps = new[] { "Season and grill steak", "Sauté vegetables with garlic", "Prepare fresh side salad", "Serve together" },
                                benefits = new[] { "High Protein: Supports muscle maintenance and satiety", "Iron Rich: Steak provides bioavailable iron", "Vegetable Rich: Provides essential micronutrients" }
                            },
                            new
                            {
                                id = 30,
                                name = "Tuna and Avocado Salad",
                                imageUrl = "https://images.unsplash.com/photo-1467003909585-2f8a72700288",
                                videoUrl = "https://www.youtube.com/watch?v=zJLzGaHgQw4",
                                calories = 420,
                                time = 10,
                                macros = new { fat = 24, protein = 32, carbs = 18 },
                                ingredients = new[] { "150g tuna steak", "1 avocado", "Mixed greens", "Cherry tomatoes", "Olive oil", "Lemon" },
                                steps = new[] { "Sear tuna quickly", "Slice avocado", "Prepare salad with greens and tomatoes", "Top with tuna and avocado", "Dress with olive oil and lemon" },
                                benefits = new[] { "Omega-3 Powerhouse: Tuna provides essential fatty acids", "Healthy Fats: Avocado supports hormone production", "Quick and Satisfying: Perfect for eating window" }
                            }
                        }
                    })
                },
                // Diet Plan 7: High-Protein Diet
                new GeneralDietPlan
                {
            
                    Name = "High-Protein Diet",
                    Category = "Muscle Building",
                    Description = "Protein-focused eating plan designed to support muscle growth, recovery, and athletic performance.",
                    ImageUrl = "https://kaynutrition.com/wp-content/uploads/2022/01/how-to-increase-protein-intake.jpg",
                    Duration = 30,
                    DailyCalories = 2200,
                    Difficulty = "Intermediate",
                    Goals = "Muscle Building,Athletic Performance,Recovery,Strength",
                    ProteinPercentage = 35,
                    CarbPercentage = 35,
                    FatPercentage = 30,
                    KeyFeatures = "High Protein,Lean Meats,Recovery Focus,Performance",
                    Benefits = "Muscle Growth,Improved Recovery,Increased Strength,Better Body Composition",
                    VideoUrl = "https://www.youtube.com/watch?v=Ks-_Mh1QhMc",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    PlanDetailsJson = JsonSerializer.Serialize(new
                    {
                        breakfast = new[]
                        {
                            new
                            {
                                id = 31,
                                name = "Protein Power Smoothie",
                                imageUrl = "https://images.unsplash.com/photo-1488477181946-6428a0291777",
                                videoUrl = "https://www.youtube.com/watch?v=Nqr0L0JmJ7Q",
                                calories = 450,
                                time = 5,
                                macros = new { fat = 12, protein = 40, carbs = 35 },
                                ingredients = new[] { "1 scoop protein powder", "1 banana", "1 cup milk", "1 tbsp peanut butter", "1 tbsp oats" },
                                steps = new[] { "Blend all ingredients until smooth", "Add ice if desired", "Pour into glass" },
                                benefits = new[] { "High Protein: Supports muscle protein synthesis", "Quick Absorption: Whey protein for fast recovery", "Balanced Nutrition: Provides sustained energy" }
                            },
                            new
                            {
                                id = 32,
                                name = "Egg White Omelet",
                                imageUrl = "https://images.unsplash.com/photo-1525351484163-7529414344d8",
                                videoUrl = "https://www.youtube.com/watch?v=qoCnde0mq8s",
                                calories = 380,
                                time = 10,
                                macros = new { fat = 8, protein = 35, carbs = 25 },
                                ingredients = new[] { "6 egg whites", "1 whole egg", "Vegetables", "Low-fat cheese", "Whole grain toast" },
                                steps = new[] { "Beat egg whites and whole egg", "Cook with vegetables", "Add cheese", "Serve with toast" },
                                benefits = new[] { "Pure Protein: Egg whites are complete protein", "Low Fat: Maintains lean muscle building focus", "Leucine Rich: Triggers muscle protein synthesis" }
                            }
                        },
                        lunch = new[]
                        {
                            new
                            {
                                id = 33,
                                name = "Grilled Chicken and Rice",
                                imageUrl = "https://images.unsplash.com/photo-1603133872878-684f208fb84b",
                                videoUrl = "https://www.youtube.com/watch?v=Q7d5jK8pzSI",
                                calories = 520,
                                time = 20,
                                macros = new { fat = 10, protein = 45, carbs = 50 },
                                ingredients = new[] { "200g chicken breast", "1 cup brown rice", "Vegetables", "Herbs", "Olive oil" },
                                steps = new[] { "Grill seasoned chicken breast", "Cook brown rice", "Steam vegetables", "Serve together" },
                                benefits = new[] { "Lean Protein: Chicken breast is ideal for muscle building", "Complex Carbs: Brown rice provides sustained energy", "Complete Nutrition: Supports training demands" }
                            },
                            new
                            {
                                id = 34,
                                name = "Tuna and Bean Salad",
                                imageUrl = "https://images.unsplash.com/photo-1467003909585-2f8a72700288",
                                videoUrl = "https://www.youtube.com/watch?v=zJLzGaHgQw4",
                                calories = 480,
                                time = 10,
                                macros = new { fat = 14, protein = 38, carbs = 42 },
                                ingredients = new[] { "150g tuna", "1 cup beans", "Mixed greens", "Olive oil", "Lemon", "Vegetables" },
                                steps = new[] { "Combine tuna and beans", "Add to mixed greens", "Top with vegetables", "Dress with olive oil and lemon" },
                                benefits = new[] { "Double Protein: Tuna and beans provide complete amino acids", "Fiber Rich: Beans support digestive health", "Omega-3: Tuna provides essential fatty acids" }
                            }
                        },
                        dinner = new[]
                        {
                            new
                            {
                                id = 35,
                                name = "Lean Beef and Quinoa",
                                imageUrl = "https://images.unsplash.com/photo-1546833999-b9f581a1996d",
                                videoUrl = "https://www.youtube.com/watch?v=Q7d5jK8pzSI",
                                calories = 580,
                                time = 25,
                                macros = new { fat = 18, protein = 48, carbs = 45 },
                                ingredients = new[] { "180g lean beef", "1/2 cup quinoa", "Vegetables", "Olive oil", "Herbs" },
                                steps = new[] { "Cook quinoa", "Grill lean beef", "Sauté vegetables", "Combine and serve" },
                                benefits = new[] { "High Protein: Beef provides all essential amino acids", "Iron Rich: Supports oxygen transport for performance", "Complete Protein: Quinoa adds plant-based amino acids" }
                            },
                            new
                            {
                                id = 36,
                                name = "Salmon and Sweet Potato",
                                imageUrl = "https://images.unsplash.com/photo-1519708227418-c8fd9a32b7a2",
                                videoUrl = "https://www.youtube.com/watch?v=4c9O15PUqm8",
                                calories = 520,
                                time = 20,
                                macros = new { fat = 20, protein = 42, carbs = 38 },
                                ingredients = new[] { "180g salmon", "1 sweet potato", "Asparagus", "Olive oil", "Lemon" },
                                steps = new[] { "Bake sweet potato", "Grill salmon", "Steam asparagus", "Serve with lemon" },
                                benefits = new[] { "Omega-3 Rich: Supports recovery and reduces inflammation", "Quality Protein: Salmon provides complete amino acids", "Complex Carbs: Sweet potato supports glycogen replenishment" }
                            }
                        }
                    })
                },
                // Diet Plan 8: Low-FODMAP Diet
                new GeneralDietPlan
                {
               
                    Name = "Low-FODMAP Diet",
                    Category = "Digestive Health",
                    Description = "Specialized diet for managing IBS and digestive issues by reducing fermentable carbohydrates.",
                    ImageUrl = "https://images.unsplash.com/photo-1498837167922-ddd27525d352",
                    Duration = 30,
                    DailyCalories = 1900,
                    Difficulty = "Advanced",
                    Goals = "Digestive Health,IBS Management,Gut Health,Symptom Relief",
                    ProteinPercentage = 20,
                    CarbPercentage = 50,
                    FatPercentage = 30,
                    KeyFeatures = "Low FODMAP,Gut Friendly,IBS Support,Digestive Relief",
                    Benefits = "Reduced Bloating,Better Digestion,Symptom Management,Gut Health",
                    VideoUrl = "https://www.youtube.com/watch?v=N2ub5qvGx1I",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    PlanDetailsJson = JsonSerializer.Serialize(new
                    {
                        breakfast = new[]
                        {
                            new
                            {
                                id = 37,
                                name = "Rice Porridge with Berries",
                                imageUrl = "https://images.unsplash.com/photo-1517982856301-9cb8282dfdb4",
                                videoUrl = "https://www.youtube.com/watch?v=GLmNbz5AIY8",
                                calories = 280,
                                time = 12,
                                macros = new { fat = 6, protein = 8, carbs = 52 },
                                ingredients = new[] { "1/2 cup rice", "1 cup lactose-free milk", "1/2 cup blueberries", "1 tbsp maple syrup" },
                                steps = new[] { "Cook rice with lactose-free milk", "Top with blueberries", "Drizzle with maple syrup" },
                                benefits = new[] { "Gut Friendly: Rice is easily digestible", "Low FODMAP: Blueberries are well tolerated", "Gentle Nutrition: Supports digestive healing" }
                            },
                            new
                            {
                                id = 38,
                                name = "Gluten-Free Toast with Egg",
                                imageUrl = "https://images.unsplash.com/photo-1541519527459-826367cb3eba",
                                videoUrl = "https://www.youtube.com/watch?v=PWJWjsNS2JA",
                                calories = 320,
                                time = 8,
                                macros = new { fat = 14, protein = 16, carbs = 32 },
                                ingredients = new[] { "2 slices gluten-free bread", "1 egg", "Butter", "Chives", "Salt" },
                                steps = new[] { "Toast gluten-free bread", "Cook egg as desired", "Serve together with chives" },
                                benefits = new[] { "Gluten-Free: Reduces digestive inflammation", "Easy Protein: Eggs are well tolerated", "Simple Ingredients: Minimizes trigger foods" }
                            }
                        },
                        lunch = new[]
                        {
                            new
                            {
                                id = 39,
                                name = "Chicken and Rice Bowl",
                                imageUrl = "https://images.unsplash.com/photo-1546833999-b9f581a1996d",
                                videoUrl = "https://www.youtube.com/watch?v=8jcc4lGIW7E",
                                calories = 420,
                                time = 20,
                                macros = new { fat = 12, protein = 35, carbs = 42 },
                                ingredients = new[] { "150g chicken breast", "1/2 cup white rice", "Carrots", "Green beans", "Olive oil" },
                                steps = new[] { "Cook white rice", "Grill chicken breast", "Steam carrots and green beans", "Combine in bowl" },
                                benefits = new[] { "Lean Protein: Chicken is easily digestible", "Safe Carbs: White rice is low FODMAP", "Gentle Vegetables: Carrots and green beans are well tolerated" }
                            },
                            new
                            {
                                id = 40,
                                name = "Tuna and Potato Salad",
                                imageUrl = "https://images.unsplash.com/photo-1467003909585-2f8a72700288",
                                videoUrl = "https://www.youtube.com/watch?v=zJLzGaHgQw4",
                                calories = 380,
                                time = 15,
                                macros = new { fat = 10, protein = 28, carbs = 45 },
                                ingredients = new[] { "150g tuna", "2 small potatoes", "Lettuce", "Olive oil", "Lemon juice" },
                                steps = new[] { "Boil potatoes until tender", "Combine with tuna", "Serve on lettuce", "Dress with olive oil and lemon" },
                                benefits = new[] { "Safe Protein: Tuna is low FODMAP", "Gentle Starch: Potatoes are well tolerated", "Simple Preparation: Reduces digestive stress" }
                            }
                        },
                        dinner = new[]
                        {
                            new
                            {
                                id = 41,
                                name = "Baked Fish with Vegetables",
                                imageUrl = "https://images.unsplash.com/photo-1519708227418-c8fd9a32b7a2",
                                videoUrl = "https://www.youtube.com/watch?v=4c9O15PUqm8",
                                calories = 450,
                                time = 25,
                                macros = new { fat = 16, protein = 38, carbs = 28 },
                                ingredients = new[] { "180g white fish", "Zucchini", "Bell pepper", "Olive oil", "Herbs" },
                                steps = new[] { "Season fish with herbs", "Cut vegetables into chunks", "Bake together until tender" },
                                benefits = new[] { "Gentle Protein: White fish is easily digestible", "Low FODMAP Vegetables: Zucchini and bell pepper are safe", "Anti-inflammatory: Supports gut healing" }
                            },
                            new
                            {
                                id = 42,
                                name = "Turkey and Quinoa Stuffed Pepper",
                                imageUrl = "https://images.unsplash.com/photo-1603133872878-684f208fb84b",
                                videoUrl = "https://www.youtube.com/watch?v=Q7d5jK8pzSI",
                                calories = 420,
                                time = 30,
                                macros = new { fat = 14, protein = 32, carbs = 38 },
                                ingredients = new[] { "150g ground turkey", "1/2 cup quinoa", "Red bell pepper", "Herbs", "Olive oil" },
                                steps = new[] { "Cook quinoa", "Brown turkey", "Stuff pepper with mixture", "Bake until pepper is tender" },
                                benefits = new[] { "Lean Protein: Turkey is well tolerated", "Safe Grain: Quinoa is low FODMAP in small amounts", "Gentle Cooking: Baking preserves nutrients" }
                            }
                        }
                    })
                },
                // Diet Plan 9: Anti-Inflammatory Diet
                new GeneralDietPlan
                {
              
                    Name = "Anti-Inflammatory Diet",
                    Category = "Health Focused",
                    Description = "Anti-inflammatory eating plan rich in omega-3s, antioxidants, and whole foods to reduce chronic inflammation.",
                    ImageUrl = "https://images.unsplash.com/photo-1511690743698-d9d85f2fbf38",
                    Duration = 30,
                    DailyCalories = 1950,
                    Difficulty = "Beginner",
                    Goals = "Reduce Inflammation,Joint Health,Disease Prevention,Overall Wellness",
                    ProteinPercentage = 20,
                    CarbPercentage = 50,
                    FatPercentage = 30,
                    KeyFeatures = "Omega-3 Rich,Antioxidant Dense,Anti-inflammatory,Whole Foods",
                    Benefits = "Reduced Inflammation,Joint Health,Heart Health,Brain Function",
                    VideoUrl = "https://www.youtube.com/watch?v=S2IXpAKEwxs",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    PlanDetailsJson = JsonSerializer.Serialize(new
                    {
                        breakfast = new[]
                        {
                            new
                            {
                                id = 43,
                                name = "Golden Turmeric Smoothie",
                                imageUrl = "https://images.unsplash.com/photo-1488477181946-6428a0291777",
                                videoUrl = "https://www.youtube.com/watch?v=Nqr0L0JmJ7Q",
                                calories = 320,
                                time = 5,
                                macros = new { fat = 12, protein = 12, carbs = 42 },
                                ingredients = new[] { "1 cup coconut milk", "1/2 banana", "1 tsp turmeric", "1 tsp ginger", "1 tbsp chia seeds" },
                                steps = new[] { "Blend all ingredients until smooth", "Add ice if desired", "Top with extra chia seeds" },
                                benefits = new[] { "Anti-inflammatory: Turmeric and ginger reduce inflammation", "Omega-3 Rich: Chia seeds provide essential fatty acids", "Antioxidant Dense: Protects against oxidative stress" }
                            },
                            new
                            {
                                id = 44,
                                name = "Berry Walnut Bowl",
                                imageUrl = "https://images.unsplash.com/photo-1517982856301-9cb8282dfdb4",
                                videoUrl = "https://www.youtube.com/watch?v=GLmNbz5AIY8",
                                calories = 350,
                                time = 8,
                                macros = new { fat = 16, protein = 10, carbs = 45 },
                                ingredients = new[] { "1 cup mixed berries", "1/4 cup walnuts", "Greek yogurt", "Honey", "Flaxseeds" },
                                steps = new[] { "Arrange berries in bowl", "Top with Greek yogurt", "Add walnuts and flaxseeds", "Drizzle with honey" },
                                benefits = new[] { "Antioxidant Powerhouse: Berries fight free radicals", "Omega-3 Rich: Walnuts and flaxseeds reduce inflammation", "Probiotic Support: Greek yogurt supports gut health" }
                            }
                        },
                        lunch = new[]
                        {
                            new
                            {
                                id = 45,
                                name = "Salmon and Leafy Green Salad",
                                imageUrl = "https://images.unsplash.com/photo-1467003909585-2f8a72700288",
                                videoUrl = "https://www.youtube.com/watch?v=zJLzGaHgQw4",
                                calories = 480,
                                time = 15,
                                macros = new { fat = 26, protein = 35, carbs = 18 },
                                ingredients = new[] { "150g wild salmon", "Mixed leafy greens", "Cherry tomatoes", "Olive oil", "Lemon", "Avocado" },
                                steps = new[] { "Grill salmon with herbs", "Prepare salad with greens and tomatoes", "Top with salmon and avocado", "Dress with olive oil and lemon" },
                                benefits = new[] { "Omega-3 Powerhouse: Wild salmon provides EPA and DHA", "Antioxidant Rich: Leafy greens and tomatoes fight inflammation", "Healthy Fats: Olive oil and avocado support nutrient absorption" }
                            },
                            new
                            {
                                id = 46,
                                name = "Quinoa and Vegetable Bowl",
                                imageUrl = "https://images.unsplash.com/photo-1546833999-b9f581a1996d",
                                videoUrl = "https://www.youtube.com/watch?v=8jcc4lGIW7E",
                                calories = 420,
                                time = 25,
                                macros = new { fat = 14, protein = 16, carbs = 58 },
                                ingredients = new[] { "1/2 cup quinoa", "Roasted vegetables", "Chickpeas", "Tahini", "Lemon", "Herbs" },
                                steps = new[] { "Cook quinoa", "Roast colorful vegetables", "Add chickpeas", "Dress with tahini and lemon", "Garnish with herbs" },
                                benefits = new[] { "Complete Protein: Quinoa provides all amino acids", "Fiber Rich: Supports gut health and reduces inflammation", "Plant Compounds: Vegetables provide anti-inflammatory phytonutrients" }
                            }
                        },
                        dinner = new[]
                        {
                            new
                            {
                                id = 47,
                                name = "Herb-Crusted Mackerel",
                                imageUrl = "https://images.unsplash.com/photo-1519708227418-c8fd9a32b7a2",
                                videoUrl = "https://www.youtube.com/watch?v=4c9O15PUqm8",
                                calories = 520,
                                time = 20,
                                macros = new { fat = 28, protein = 40, carbs = 22 },
                                ingredients = new[] { "180g mackerel", "Fresh herbs", "Sweet potato", "Broccoli", "Olive oil" },
                                steps = new[] { "Coat mackerel with herbs", "Roast sweet potato", "Steam broccoli", "Bake fish until flaky" },
                                benefits = new[] { "Omega-3 Dense: Mackerel is one of the richest sources", "Antioxidant Herbs: Provide anti-inflammatory compounds", "Nutrient Dense: Sweet potato and broccoli support overall health" }
                            },
                            new
                            {
                                id = 48,
                                name = "Turmeric Chicken Stir-Fry",
                                imageUrl = "https://images.unsplash.com/photo-1603133872878-684f208fb84b",
                                videoUrl = "https://www.youtube.com/watch?v=Q7d5jK8pzSI",
                                calories = 450,
                                time = 18,
                                macros = new { fat = 18, protein = 36, carbs = 32 },
                                ingredients = new[] { "150g chicken breast", "Mixed vegetables", "Turmeric", "Ginger", "Coconut oil", "Brown rice" },
                                steps = new[] { "Heat coconut oil", "Add chicken with turmeric and ginger", "Stir-fry vegetables", "Serve over brown rice" },
                                benefits = new[] { "Anti-inflammatory Spices: Turmeric and ginger reduce inflammation", "Lean Protein: Chicken supports muscle health", "Whole Grains: Brown rice provides sustained energy" }
                            }
                        }
                    })
                },
                // Diet Plan 10: Flexitarian Diet
                new GeneralDietPlan
                {
              
                    Name = "Flexitarian Diet",
                    Category = "Semi-Vegetarian",
                    Description = "Flexible vegetarian approach that includes mostly plant foods with occasional meat and fish.",
                    ImageUrl = "https://wildbrine.com/wp-content/uploads/bb-plugin/cache/what-is-flexitarian-diet-landscape-788c04c1fc4e2621cd18ceaf716db7f3-uwae8n1lbkqp.jpg",
                    Duration = 30,
                    DailyCalories = 1850,
                    Difficulty = "Beginner",
                    Goals = "Balanced Nutrition,Environmental Impact,Health,Flexibility",
                    ProteinPercentage = 18,
                    CarbPercentage = 55,
                    FatPercentage = 27,
                    KeyFeatures = "Mostly Plants,Occasional Meat,Flexible,Sustainable",
                    Benefits = "Better Health,Environmental Impact,Weight Management,Nutrient Diversity",
                    VideoUrl = "https://www.youtube.com/watch?v=NxvQPzrg2Wg",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    PlanDetailsJson = JsonSerializer.Serialize(new
                    {
                        breakfast = new[]
                        {
                            new
                            {
                                id = 49,
                                name = "Plant-Based Pancakes",
                                imageUrl = "https://images.unsplash.com/photo-1517982856301-9cb8282dfdb4",
                                videoUrl = "https://www.youtube.com/watch?v=GLmNbz5AIY8",
                                calories = 320,
                                time = 15,
                                macros = new { fat = 10, protein = 12, carbs = 48 },
                                ingredients = new[] { "Oat flour", "Plant milk", "Banana", "Berries", "Maple syrup", "Nuts" },
                                steps = new[] { "Mix oat flour with plant milk", "Add mashed banana", "Cook pancakes", "Top with berries and nuts", "Drizzle with maple syrup" },
                                benefits = new[] { "Plant-Based: Supports environmental goals", "Fiber Rich: Oats support digestive health", "Natural Sweetness: Banana and berries provide nutrients" }
                            },
                            new
                            {
                                id = 50,
                                name = "Veggie Scramble with Optional Cheese",
                                imageUrl = "https://images.unsplash.com/photo-1525351484163-7529414344d8",
                                videoUrl = "https://www.youtube.com/watch?v=qoCnde0mq8s",
                                calories = 280,
                                time = 10,
                                macros = new { fat = 12, protein = 16, carbs = 24 },
                                ingredients = new[] { "2 eggs", "Mixed vegetables", "Optional cheese", "Whole grain toast", "Herbs" },
                                steps = new[] { "Scramble eggs with vegetables", "Use minimal oil", "Serve with small portion of whole grain toast", "Season with herbs" },
                                benefits = new[] { "Flexible Protein: Eggs provide complete amino acids", "Vegetable Rich: Supports daily nutrient goals", "Optional Additions: Allows for personal preference" }
                            }
                        },
                        lunch = new[]
                        {
                            new
                            {
                                id = 51,
                                name = "Mediterranean Chickpea Salad",
                                imageUrl = "https://images.unsplash.com/photo-1467003909585-2f8a72700288",
                                videoUrl = "https://www.youtube.com/watch?v=zJLzGaHgQw4",
                                calories = 420,
                                time = 15,
                                macros = new { fat = 16, protein = 18, carbs = 52 },
                                ingredients = new[] { "Chickpeas", "Vegetables", "Feta cheese", "Olive oil", "Lemon", "Herbs" },
                                steps = new[] { "Combine chickpeas with vegetables", "Add crumbled feta", "Dress with olive oil and lemon", "Garnish with herbs" },
                                benefits = new[] { "Plant Protein: Chickpeas provide fiber and protein", "Mediterranean Flavors: Heart-healthy olive oil", "Satisfying: Keeps you full with plant-based nutrition" }
                            },
                            new
                            {
                                id = 52,
                                name = "Occasional Fish Salad",
                                imageUrl = "https://images.unsplash.com/photo-1467003909585-2f8a72700288",
                                videoUrl = "https://www.youtube.com/watch?v=zJLzGaHgQw4",
                                calories = 380,
                                time = 12,
                                macros = new { fat = 14, protein = 28, carbs = 32 },
                                ingredients = new[] { "100g white fish", "Mixed greens", "Quinoa", "Vegetables", "Olive oil", "Lemon" },
                                steps = new[] { "Grill fish lightly", "Prepare quinoa salad", "Combine with greens", "Dress with olive oil and lemon" },
                                benefits = new[] { "Omega-3: Fish provides essential fatty acids", "Plant-Forward: Mostly vegetables and grains", "Balanced: Combines plant and animal proteins" }
                            }
                        },
                        dinner = new[]
                        {
                            new
                            {
                                id = 53,
                                name = "Lentil and Vegetable Curry",
                                imageUrl = "https://images.unsplash.com/photo-1547592166-23ac45744acd",
                                videoUrl = "https://www.youtube.com/watch?v=BodE_BrLjTI",
                                calories = 450,
                                time = 30,
                                macros = new { fat = 12, protein = 20, carbs = 65 },
                                ingredients = new[] { "Red lentils", "Mixed vegetables", "Coconut milk", "Spices", "Brown rice" },
                                steps = new[] { "Cook lentils with vegetables", "Add coconut milk and spices", "Simmer until tender", "Serve over brown rice" },
                                benefits = new[] { "Plant Protein: Lentils provide complete nutrition", "Fiber Dense: Supports digestive health", "Flavorful: Spices provide antioxidants" }
                            },
                            new
                            {
                                id = 54,
                                name = "Occasional Chicken Stir-Fry",
                                imageUrl = "https://images.unsplash.com/photo-1603133872878-684f208fb84b",
                                videoUrl = "https://www.youtube.com/watch?v=Q7d5jK8pzSI",
                                calories = 420,
                                time = 18,
                                macros = new { fat = 14, protein = 32, carbs = 38 },
                                ingredients = new[] { "100g chicken breast", "Lots of vegetables", "Brown rice", "Soy sauce", "Ginger" },
                                steps = new[] { "Stir-fry vegetables first", "Add small amount of chicken", "Season with ginger and soy sauce", "Serve over brown rice" },
                                benefits = new[] { "Mostly Plants: Vegetables are the main focus", "Quality Protein: Small amount of lean chicken", "Balanced: Plant-forward with occasional meat" }
                            }
                        }
                    })
                },
                // Diet Plan 11: Nordic Diet
                new GeneralDietPlan
                {
             
                    Name = "Nordic Diet",
                    Category = "Scandinavian",
                    Description = "Traditional Nordic eating pattern emphasizing fish, berries, root vegetables, and whole grains.",
                    ImageUrl = "https://www.heartuk.org.uk/images/nutrition-academy/new-nordic-diet_cropped.jpg",
                    Duration = 30,
                    DailyCalories = 1950,
                    Difficulty = "Beginner",
                    Goals = "Heart Health,Sustainability,Traditional Foods,Nordic Wellness",
                    ProteinPercentage = 22,
                    CarbPercentage = 48,
                    FatPercentage = 30,
                    KeyFeatures = "Nordic Fish,Berries,Root Vegetables,Whole Grains",
                    Benefits = "Heart Health,Sustainability,Weight Management,Traditional Nutrition",
                    VideoUrl = "https://www.youtube.com/watch?v=dQw4w9WgXcQ",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    PlanDetailsJson = JsonSerializer.Serialize(new
                    {
                        breakfast = new[]
                        {
                            new
                            {
                                id = 55,
                                name = "Nordic Berry Bowl",
                                imageUrl = "https://images.unsplash.com/photo-1517982856301-9cb8282dfdb4",
                                videoUrl = "https://www.youtube.com/watch?v=GLmNbz5AIY8",
                                calories = 300,
                                time = 8,
                                macros = new { fat = 8, protein = 12, carbs = 48 },
                                ingredients = new[] { "Rye porridge", "Lingonberries", "Blueberries", "Nuts", "Yogurt" },
                                steps = new[] { "Cook rye porridge", "Top with Nordic berries", "Add nuts and yogurt", "Serve warm" },
                                benefits = new[] { "Antioxidant Rich: Nordic berries provide unique compounds", "Whole Grains: Rye supports digestive health", "Traditional: Authentic Nordic nutrition" }
                            },
                            new
                            {
                                id = 56,
                                name = "Smoked Fish on Rye",
                                imageUrl = "https://images.unsplash.com/photo-1541519527459-826367cb3eba",
                                videoUrl = "https://www.youtube.com/watch?v=PWJWjsNS2JA",
                                calories = 320,
                                time = 5,
                                macros = new { fat = 12, protein = 20, carbs = 32 },
                                ingredients = new[] { "Rye bread", "Smoked fish", "Dill", "Cucumber", "Cream cheese" },
                                steps = new[] { "Toast rye bread", "Spread with cream cheese", "Top with smoked fish", "Garnish with dill and cucumber" },
                                benefits = new[] { "Omega-3 Rich: Smoked fish provides essential fats", "Traditional: Classic Nordic combination", "Protein Rich: Supports morning nutrition" }
                            }
                        },
                        lunch = new[]
                        {
                            new
                            {
                                id = 57,
                                name = "Salmon and Root Vegetable Bowl",
                                imageUrl = "https://images.unsplash.com/photo-1467003909585-2f8a72700288",
                                videoUrl = "https://www.youtube.com/watch?v=zJLzGaHgQw4",
                                calories = 480,
                                time = 25,
                                macros = new { fat = 22, protein = 35, carbs = 35 },
                                ingredients = new[] { "Fresh salmon", "Root vegetables", "Barley", "Dill", "Lemon" },
                                steps = new[] { "Roast root vegetables", "Cook barley", "Grill salmon", "Combine with dill and lemon" },
                                benefits = new[] { "Nordic Fish: Salmon provides omega-3 fatty acids", "Root Vegetables: Traditional Nordic nutrition", "Whole Grains: Barley supports heart health" }
                            },
                            new
                            {
                                id = 58,
                                name = "Herring and Beetroot Salad",
                                imageUrl = "https://images.unsplash.com/photo-1467003909585-2f8a72700288",
                                videoUrl = "https://www.youtube.com/watch?v=zJLzGaHgQw4",
                                calories = 380,
                                time = 15,
                                macros = new { fat = 18, protein = 22, carbs = 32 },
                                ingredients = new[] { "Pickled herring", "Beetroot", "Potatoes", "Dill", "Sour cream" },
                                steps = new[] { "Arrange herring and beetroot", "Add boiled potatoes", "Garnish with dill", "Serve with sour cream" },
                                benefits = new[] { "Traditional Nordic: Authentic Scandinavian flavors", "Omega-3: Herring provides essential fatty acids", "Probiotic: Pickled foods support gut health" }
                            }
                        },
                        dinner = new[]
                        {
                            new
                            {
                                id = 59,
                                name = "Nordic Meatballs with Lingonberries",
                                imageUrl = "https://images.unsplash.com/photo-1603133872878-684f208fb84b",
                                videoUrl = "https://www.youtube.com/watch?v=Q7d5jK8pzSI",
                                calories = 520,
                                time = 30,
                                macros = new { fat = 24, protein = 36, carbs = 38 },
                                ingredients = new[] { "Lean beef and pork", "Lingonberries", "Root vegetables", "Cream sauce" },
                                steps = new[] { "Form and cook meatballs", "Prepare lingonberry sauce", "Roast root vegetables", "Serve together" },
                                benefits = new[] { "Traditional Protein: Nordic-style meat preparation", "Antioxidant Berries: Lingonberries provide unique compounds", "Balanced Meal: Complete Nordic nutrition" }
                            },
                            new
                            {
                                id = 60,
                                name = "Cod with Cabbage and Dill",
                                imageUrl = "https://images.unsplash.com/photo-1519708227418-c8fd9a32b7a2",
                                videoUrl = "https://www.youtube.com/watch?v=4c9O15PUqm8",
                                calories = 420,
                                time = 20,
                                macros = new { fat = 14, protein = 38, carbs = 28 },
                                ingredients = new[] { "Fresh cod", "Cabbage", "Potatoes", "Dill", "Butter" },
                                steps = new[] { "Steam cod with dill", "Cook cabbage and potatoes", "Serve with butter sauce" },
                                benefits = new[] { "Lean Fish: Cod provides high-quality protein", "Nordic Vegetables: Cabbage is traditional", "Simple Preparation: Preserves natural flavors" }
                            }
                        }
                    })
                },
                // Diet Plan 12: Whole30 Diet
                new GeneralDietPlan
                {
             
                    Name = "Whole30 Diet",
                    Category = "Elimination",
                    Description = "30-day elimination diet removing sugar, grains, dairy, legumes, and processed foods.",
                    ImageUrl = "https://blog.nasm.org/hubfs/whole30-diet-blog.jpg",
                    Duration = 30,
                    DailyCalories = 1900,
                    Difficulty = "Advanced",
                    Goals = "Reset,Elimination,Clean Eating,Food Sensitivity",
                    ProteinPercentage = 30,
                    CarbPercentage = 35,
                    FatPercentage = 35,
                    KeyFeatures = "No Sugar,No Grains,No Dairy,No Legumes,Whole Foods",
                    Benefits = "Reset Habits,Identify Sensitivities,Clean Eating,Energy Boost",
                    VideoUrl = "https://www.youtube.com/watch?v=StZru2fSvTI",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    PlanDetailsJson = JsonSerializer.Serialize(new
                    {
                        breakfast = new[]
                        {
                            new
                            {
                                id = 61,
                                name = "Compliant Veggie Scramble",
                                imageUrl = "https://images.unsplash.com/photo-1525351484163-7529414344d8",
                                videoUrl = "https://www.youtube.com/watch?v=qoCnde0mq8s",
                                calories = 350,
                                time = 12,
                                macros = new { fat = 20, protein = 24, carbs = 18 },
                                ingredients = new[] { "3 eggs", "Vegetables", "Avocado", "Coconut oil", "Herbs" },
                                steps = new[] { "Cook vegetables in coconut oil", "Add beaten eggs", "Top with avocado", "Season with compliant herbs" },
                                benefits = new[] { "Whole30 Compliant: Follows elimination guidelines", "Protein Rich: Eggs provide complete amino acids", "Healthy Fats: Avocado and coconut oil support satiety" }
                            },
                            new
                            {
                                id = 62,
                                name = "Sweet Potato Hash",
                                imageUrl = "https://images.unsplash.com/photo-1482049016688-2d3e1b311543",
                                videoUrl = "https://www.youtube.com/watch?v=vGr3zIhDX0s",
                                calories = 320,
                                time = 18,
                                macros = new { fat = 16, protein = 12, carbs = 38 },
                                ingredients = new[] { "Sweet potato", "Bell peppers", "Onions", "Coconut oil", "Herbs" },
                                steps = new[] { "Dice sweet potato", "Cook in coconut oil", "Add peppers and onions", "Season with compliant herbs" },
                                benefits = new[] { "Complex Carbs: Sweet potato provides sustained energy", "Compliant: No prohibited ingredients", "Vegetable Rich: Supports nutrient goals" }
                            }
                        },
                        lunch = new[]
                        {
                            new
                            {
                                id = 63,
                                name = "Compliant Chicken Salad",
                                imageUrl = "https://images.unsplash.com/photo-1467003909585-2f8a72700288",
                                videoUrl = "https://www.youtube.com/watch?v=zJLzGaHgQw4",
                                calories = 420,
                                time = 15,
                                macros = new { fat = 22, protein = 35, carbs = 15 },
                                ingredients = new[] { "Chicken breast", "Mixed greens", "Avocado", "Olive oil", "Vinegar" },
                                steps = new[] { "Grill chicken breast", "Prepare fresh salad", "Top with avocado", "Dress with olive oil and vinegar" },
                                benefits = new[] { "Lean Protein: Supports stable blood sugar", "Whole30 Compliant: No prohibited ingredients", "Healthy Fats: Avocado and olive oil provide satiety" }
                            },
                            new
                            {
                                id = 64,
                                name = "Zucchini Noodle Bowl",
                                imageUrl = "https://images.unsplash.com/photo-1512621776951-a57141f2eefd",
                                videoUrl = "https://www.youtube.com/watch?v=vr0HWgUKgL8",
                                calories = 380,
                                time = 20,
                                macros = new { fat = 20, protein = 28, carbs = 18 },
                                ingredients = new[] { "Zucchini noodles", "Ground turkey", "Vegetables", "Olive oil", "Herbs" },
                                steps = new[] { "Spiralize zucchini", "Cook turkey with vegetables", "Toss with zucchini noodles", "Finish with herbs" },
                                benefits = new[] { "Grain-Free: Zucchini replaces traditional pasta", "Lean Protein: Turkey is Whole30 compliant", "Low Carb: Supports elimination goals" }
                            }
                        },
                        dinner = new[]
                        {
                            new
                            {
                                id = 65,
                                name = "Compliant Beef and Vegetables",
                                imageUrl = "https://images.unsplash.com/photo-1546833999-b9f581a1996d",
                                videoUrl = "https://www.youtube.com/watch?v=Q7d5jK8pzSI",
                                calories = 520,
                                time = 25,
                                macros = new { fat = 26, protein = 42, carbs = 22 },
                                ingredients = new[] { "Grass-fed beef", "Mixed vegetables", "Sweet potato", "Coconut oil", "Herbs" },
                                steps = new[] { "Grill beef to preference", "Roast vegetables with coconut oil", "Bake sweet potato", "Serve together with herbs" },
                                benefits = new[] { "Quality Protein: Grass-fed beef provides complete nutrition", "Whole30 Compliant: No prohibited ingredients", "Nutrient Dense: Vegetables provide essential vitamins" }
                            },
                            new
                            {
                                id = 66,
                                name = "Salmon with Cauliflower Rice",
                                imageUrl = "https://images.unsplash.com/photo-1519708227418-c8fd9a32b7a2",
                                videoUrl = "https://www.youtube.com/watch?v=4c9O15PUqm8",
                                calories = 450,
                                time = 20,
                                macros = new { fat = 24, protein = 38, carbs = 16 },
                                ingredients = new[] { "Wild salmon", "Cauliflower rice", "Broccoli", "Olive oil", "Lemon" },
                                steps = new[] { "Bake salmon with herbs", "Sauté cauliflower rice", "Steam broccoli", "Serve with lemon" },
                                benefits = new[] { "Omega-3 Rich: Wild salmon provides essential fats", "Grain-Free: Cauliflower replaces rice", "Anti-inflammatory: Supports reset goals" }
                            }
                        }
                    })
                },
                // Diet Plan 13: Zone Diet
                new GeneralDietPlan
                {
              
                    Name = "Zone Diet",
                    Category = "Balanced Ratios",
                    Description = "Precise macronutrient ratios of 40% carbs, 30% protein, 30% fat to control inflammation.",
                    ImageUrl = "https://cdn.shopify.com/s/files/1/1497/9682/files/2_adc687f4-66d7-4d9e-a8a1-ca8997c2666f.jpg?v=1643820508",
                    Duration = 30,
                    DailyCalories = 2000,
                    Difficulty = "Intermediate",
                    Goals = "Hormonal Balance,Inflammation Control,Performance,Precision",
                    ProteinPercentage = 30,
                    CarbPercentage = 40,
                    FatPercentage = 30,
                    KeyFeatures = "40-30-30 Ratio,Hormone Control,Anti-inflammatory,Precise",
                    Benefits = "Hormonal Balance,Reduced Inflammation,Stable Energy,Mental Clarity",
                    VideoUrl = "https://www.youtube.com/watch?v=dQw4w9WgXcQ",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    PlanDetailsJson = JsonSerializer.Serialize(new
                    {
                        breakfast = new[]
                        {
                            new
                            {
                                id = 67,
                                name = "Zone-Perfect Omelet",
                                imageUrl = "https://images.unsplash.com/photo-1525351484163-7529414344d8",
                                videoUrl = "https://www.youtube.com/watch?v=qoCnde0mq8s",
                                calories = 400,
                                time = 10,
                                macros = new { fat = 13, protein = 30, carbs = 40 },
                                ingredients = new[] { "4 egg whites", "1 whole egg", "Vegetables", "Olive oil", "Fruit" },
                                steps = new[] { "Cook omelet with precise protein", "Use measured olive oil", "Serve with exact carb portion", "Balance 40-30-30 ratio" },
                                benefits = new[] { "Perfect Ratios: 40-30-30 macronutrient balance", "Hormone Control: Supports insulin regulation", "Anti-inflammatory: Balanced nutrition reduces inflammation" }
                            },
                            new
                            {
                                id = 68,
                                name = "Zone Smoothie",
                                imageUrl = "https://images.unsplash.com/photo-1488477181946-6428a0291777",
                                videoUrl = "https://www.youtube.com/watch?v=Nqr0L0JmJ7Q",
                                calories = 380,
                                time = 5,
                                macros = new { fat = 13, protein = 29, carbs = 38 },
                                ingredients = new[] { "Protein powder", "Berries", "Nuts", "Water", "Measured portions" },
                                steps = new[] { "Blend exact protein amount", "Add measured berries for carbs", "Include precise fat from nuts", "Achieve 40-30-30 balance" },
                                benefits = new[] { "Precise Nutrition: Exact macronutrient ratios", "Quick Preparation: Perfect for busy mornings", "Hormone Support: Balanced nutrition for optimal function" }
                            }
                        },
                        lunch = new[]
                        {
                            new
                            {
                                id = 69,
                                name = "Zone Chicken and Rice",
                                imageUrl = "https://images.unsplash.com/photo-1546833999-b9f581a1996d",
                                videoUrl = "https://www.youtube.com/watch?v=8jcc4lGIW7E",
                                calories = 480,
                                time = 20,
                                macros = new { fat = 16, protein = 36, carbs = 48 },
                                ingredients = new[] { "Measured chicken breast", "Brown rice", "Vegetables", "Olive oil", "Precise portions" },
                                steps = new[] { "Grill exact amount of chicken", "Measure rice portion precisely", "Add measured olive oil", "Include vegetables for balance" },
                                benefits = new[] { "Macronutrient Precision: Perfect 40-30-30 balance", "Sustained Energy: Balanced ratios prevent crashes", "Performance: Supports athletic and mental performance" }
                            },
                            new
                            {
                                id = 70,
                                name = "Zone Fish Salad",
                                imageUrl = "https://images.unsplash.com/photo-1467003909585-2f8a72700288",
                                videoUrl = "https://www.youtube.com/watch?v=zJLzGaHgQw4",
                                calories = 420,
                                time = 15,
                                macros = new { fat = 14, protein = 32, carbs = 42 },
                                ingredients = new[] { "White fish", "Mixed greens", "Fruit", "Nuts", "Measured portions" },
                                steps = new[] { "Grill measured fish portion", "Add exact fruit for carbs", "Include precise nuts for fat", "Balance with vegetables" },
                                benefits = new[] { "Anti-inflammatory: Fish provides omega-3s", "Zone Perfect: Maintains hormonal balance", "Nutrient Dense: Quality ingredients in perfect ratios" }
                            }
                        },
                        dinner = new[]
                        {
                            new
                            {
                                id = 71,
                                name = "Zone Beef and Vegetables",
                                imageUrl = "https://images.unsplash.com/photo-1546833999-b9f581a1996d",
                                videoUrl = "https://www.youtube.com/watch?v=Q7d5jK8pzSI",
                                calories = 520,
                                time = 25,
                                macros = new { fat = 17, protein = 39, carbs = 52 },
                                ingredients = new[] { "Lean beef", "Sweet potato", "Vegetables", "Olive oil", "Precise measurements" },
                                steps = new[] { "Grill exact beef portion", "Measure sweet potato precisely", "Add calculated olive oil", "Include vegetables for balance" },
                                benefits = new[] { "Perfect Balance: 40-30-30 macronutrient ratio", "Hormone Optimization: Supports insulin control", "Quality Protein: Beef provides complete amino acids" }
                            },
                            new
                            {
                                id = 72,
                                name = "Zone Salmon Dinner",
                                imageUrl = "https://images.unsplash.com/photo-1519708227418-c8fd9a32b7a2",
                                videoUrl = "https://www.youtube.com/watch?v=4c9O15PUqm8",
                                calories = 480,
                                time = 20,
                                macros = new { fat = 16, protein = 36, carbs = 48 },
                                ingredients = new[] { "Salmon fillet", "Quinoa", "Vegetables", "Olive oil", "Measured portions" },
                                steps = new[] { "Bake measured salmon", "Cook exact quinoa amount", "Add precise olive oil", "Balance with vegetables" },
                                benefits = new[] { "Omega-3 Rich: Salmon supports anti-inflammatory goals", "Zone Perfect: Maintains hormonal balance", "Complete Nutrition: All essential nutrients in proper ratios" }
                            }
                        }
                    })
                },
                // Diet Plan 14: Alkaline Diet
                new GeneralDietPlan
                {
                
                    Name = "Alkaline Diet",
                    Category = "pH Focused",
                    Description = "Emphasis on alkaline-forming foods like vegetables, fruits, and plant proteins while limiting acidic foods.",
                    ImageUrl = "https://s44074.pcdn.co/wp-content/uploads/2023/01/What-Are-The-Benefits-of-an-Alkaline-Diet.png",
                    Duration = 30,
                    DailyCalories = 1800,
                    Difficulty = "Intermediate",
                    Goals = "pH Balance,Detox,Energy,Overall Wellness",
                    ProteinPercentage = 15,
                    CarbPercentage = 60,
                    FatPercentage = 25,
                    KeyFeatures = "Alkaline Foods,Lots of Vegetables,Plant Focus,pH Balance",
                    Benefits = "Better pH Balance,Increased Energy,Detoxification,Improved Digestion",
                    VideoUrl = "https://www.youtube.com/watch?v=dQw4w9WgXcQ",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    PlanDetailsJson = JsonSerializer.Serialize(new
                    {
                        breakfast = new[]
                        {
                            new
                            {
                                id = 73,
                                name = "Green Alkaline Smoothie",
                                imageUrl = "https://images.unsplash.com/photo-1488477181946-6428a0291777",
                                videoUrl = "https://www.youtube.com/watch?v=Nqr0L0JmJ7Q",
                                calories = 280,
                                time = 5,
                                macros = new { fat = 8, protein = 8, carbs = 48 },
                                ingredients = new[] { "Spinach", "Cucumber", "Celery", "Green apple", "Lemon", "Coconut water" },
                                steps = new[] { "Blend all green vegetables", "Add green apple for sweetness", "Include lemon for alkalinity", "Thin with coconut water" },
                                benefits = new[] { "Highly Alkaline: Greens support pH balance", "Detoxifying: Helps cleanse the system", "Energizing: Natural sugars provide clean energy" }
                            },
                            new
                            {
                                id = 74,
                                name = "Alkaline Fruit Bowl",
                                imageUrl = "https://images.unsplash.com/photo-1517982856301-9cb8282dfdb4",
                                videoUrl = "https://www.youtube.com/watch?v=GLmNbz5AIY8",
                                calories = 300,
                                time = 8,
                                macros = new { fat = 6, protein = 6, carbs = 62 },
                                ingredients = new[] { "Watermelon", "Cantaloupe", "Berries", "Coconut flakes", "Almonds" },
                                steps = new[] { "Cut alkaline fruits", "Arrange in bowl", "Top with coconut and almonds", "Serve fresh" },
                                benefits = new[] { "Alkaline Fruits: Support pH balance", "Hydrating: High water content", "Natural Energy: Fruit sugars provide quick energy" }
                            }
                        },
                        lunch = new[]
                        {
                            new
                            {
                                id = 75,
                                name = "Large Green Salad",
                                imageUrl = "https://images.unsplash.com/photo-1467003909585-2f8a72700288",
                                videoUrl = "https://www.youtube.com/watch?v=zJLzGaHgQw4",
                                calories = 350,
                                time = 15,
                                macros = new { fat = 12, protein = 8, carbs = 52 },
                                ingredients = new[] { "Mixed greens", "Cucumber", "Avocado", "Sprouts", "Lemon dressing", "Seeds" },
                                steps = new[] { "Prepare large portion of greens", "Add alkaline vegetables", "Include avocado for healthy fats", "Dress with lemon" },
                                benefits = new[] { "Highly Alkaline: Greens are the most alkaline foods", "Nutrient Dense: Packed with vitamins and minerals", "Digestive Support: Raw foods aid digestion" }
                            },
                            new
                            {
                                id = 76,
                                name = "Vegetable Soup",
                                imageUrl = "https://images.unsplash.com/photo-1547592166-23ac45744acd",
                                videoUrl = "https://www.youtube.com/watch?v=BodE_BrLjTI",
                                calories = 320,
                                time = 25,
                                macros = new { fat = 8, protein = 12, carbs = 52 },
                                ingredients = new[] { "Alkaline vegetables", "Vegetable broth", "Herbs", "Lemon", "Olive oil" },
                                steps = new[] { "Simmer alkaline vegetables", "Season with herbs", "Finish with lemon and olive oil", "Serve warm" },
                                benefits = new[] { "Alkaline Vegetables: Support pH balance", "Warming: Cooked foods are easier to digest", "Hydrating: Broth provides additional fluids" }
                            }
                        },
                        dinner = new[]
                        {
                            new
                            {
                                id = 77,
                                name = "Quinoa and Vegetable Bowl",
                                imageUrl = "https://images.unsplash.com/photo-1546833999-b9f581a1996d",
                                videoUrl = "https://www.youtube.com/watch?v=8jcc4lGIW7E",
                                calories = 420,
                                time = 20,
                                macros = new { fat = 12, protein = 16, carbs = 62 },
                                ingredients = new[] { "Quinoa", "Steamed vegetables", "Avocado", "Lemon", "Herbs" },
                                steps = new[] { "Cook quinoa (alkaline grain)", "Steam alkaline vegetables", "Top with avocado", "Season with lemon and herbs" },
                                benefits = new[] { "Alkaline Grain: Quinoa is one of few alkaline grains", "Plant Protein: Complete amino acid profile", "Balanced: Provides sustained energy" }
                            },
                            new
                            {
                                id = 78,
                                name = "Raw Vegetable Platter",
                                imageUrl = "https://images.unsplash.com/photo-1512621776951-a57141f2eefd",
                                videoUrl = "https://www.youtube.com/watch?v=vr0HWgUKgL8",
                                calories = 380,
                                time = 15,
                                macros = new { fat = 16, protein = 12, carbs = 52 },
                                ingredients = new[] { "Raw vegetables", "Hummus", "Nuts", "Seeds", "Alkaline dressing" },
                                steps = new[] { "Prepare variety of raw vegetables", "Serve with alkaline hummus", "Include nuts and seeds", "Dress with alkaline ingredients" },
                                benefits = new[] { "Maximum Alkalinity: Raw vegetables are most alkaline", "Enzyme Rich: Raw foods provide digestive enzymes", "Cleansing: Supports natural detoxification" }
                            }
                        }
                    })
                },
                // Diet Plan 15: Diabetic-Friendly Diet
                new GeneralDietPlan
                {
             
                    Name = "Diabetic-Friendly Diet",
                    Category = "Blood Sugar Control",
                    Description = "Blood sugar management through controlled carbohydrates, fiber-rich foods, and balanced nutrition.",
                    ImageUrl = "https://www.calgaryfoodbank.com/wp-content/uploads/2022/08/Food-Guide-Visual.jpg",
                    Duration = 30,
                    DailyCalories = 1900,
                    Difficulty = "Intermediate",
                    Goals = "Blood Sugar Control,Diabetes Management,Heart Health,Weight Management",
                    ProteinPercentage = 25,
                    CarbPercentage = 45,
                    FatPercentage = 30,
                    KeyFeatures = "Low Glycemic,Controlled Carbs,High Fiber,Heart Healthy",
                    Benefits = "Stable Blood Sugar,Diabetes Management,Heart Health,Weight Control",
                    VideoUrl = "https://www.youtube.com/watch?v=dQw4w9WgXcQ",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    PlanDetailsJson = JsonSerializer.Serialize(new
                    {
                        breakfast = new[]
                        {
                            new
                            {
                                id = 79,
                                name = "Low-Glycemic Oatmeal",
                                imageUrl = "https://images.unsplash.com/photo-1517982856301-9cb8282dfdb4",
                                videoUrl = "https://www.youtube.com/watch?v=GLmNbz5AIY8",
                                calories = 320,
                                time = 10,
                                macros = new { fat = 8, protein = 16, carbs = 45 },
                                ingredients = new[] { "Steel-cut oats", "Protein powder", "Nuts", "Cinnamon", "Berries" },
                                steps = new[] { "Cook steel-cut oats slowly", "Add protein powder", "Top with nuts and berries", "Season with cinnamon" },
                                benefits = new[] { "Low Glycemic: Steel-cut oats release sugar slowly", "High Protein: Helps stabilize blood sugar", "Fiber Rich: Supports glucose control" }
                            },
                            new
                            {
                                id = 80,
                                name = "Veggie Egg Scramble",
                                imageUrl = "https://images.unsplash.com/photo-1525351484163-7529414344d8",
                                videoUrl = "https://www.youtube.com/watch?v=qoCnde0mq8s",
                                calories = 280,
                                time = 10,
                                macros = new { fat = 12, protein = 20, carbs = 18 },
                                ingredients = new[] { "2 eggs", "Non-starchy vegetables", "Olive oil", "Herbs", "Whole grain toast" },
                                steps = new[] { "Scramble eggs with vegetables", "Use minimal oil", "Serve with small portion of whole grain toast", "Season with herbs" },
                                benefits = new[] { "Protein Rich: Helps prevent blood sugar spikes", "Low Carb: Minimal impact on glucose", "Fiber: Vegetables support blood sugar control" }
                            }
                        },
                        lunch = new[]
                        {
                            new
                            {
                                id = 81,
                                name = "Diabetic-Friendly Chicken Salad",
                                imageUrl = "https://images.unsplash.com/photo-1467003909585-2f8a72700288",
                                videoUrl = "https://www.youtube.com/watch?v=zJLzGaHgQw4",
                                calories = 420,
                                time = 15,
                                macros = new { fat = 14, protein = 35, carbs = 32 },
                                ingredients = new[] { "Grilled chicken", "Leafy greens", "Non-starchy vegetables", "Olive oil", "Vinegar" },
                                steps = new[] { "Grill lean chicken breast", "Prepare fresh salad", "Top with avocado", "Dress with olive oil and vinegar" },
                                benefits = new[] { "Lean Protein: Supports stable blood sugar", "Whole30 Compliant: No prohibited ingredients", "Healthy Fats: Avocado and olive oil provide satiety" }
                            },
                            new
                            {
                                id = 82,
                                name = "Bean and Vegetable Soup",
                                imageUrl = "https://images.unsplash.com/photo-1547592166-23ac45744acd",
                                videoUrl = "https://www.youtube.com/watch?v=BodE_BrLjTI",
                                calories = 380,
                                time = 25,
                                macros = new { fat = 8, protein = 18, carbs = 58 },
                                ingredients = new[] { "Beans", "Non-starchy vegetables", "Low-sodium broth", "Herbs", "Olive oil" },
                                steps = new[] { "Simmer beans with vegetables", "Use low-sodium broth", "Season with herbs", "Finish with small amount of olive oil" },
                                benefits = new[] { "High Fiber: Beans help control blood sugar", "Plant Protein: Supports muscle health", "Low Sodium: Heart-healthy preparation" }
                            }
                        },
                        dinner = new[]
                        {
                            new
                            {
                                id = 83,
                                name = "Baked Fish with Vegetables",
                                imageUrl = "https://images.unsplash.com/photo-1519708227418-c8fd9a32b7a2",
                                videoUrl = "https://www.youtube.com/watch?v=4c9O15PUqm8",
                                calories = 450,
                                time = 25,
                                macros = new { fat = 16, protein = 38, carbs = 28 },
                                ingredients = new[] { "White fish", "Non-starchy vegetables", "Sweet potato", "Olive oil", "Herbs" },
                                steps = new[] { "Bake fish with herbs", "Roast non-starchy vegetables", "Include small portion of sweet potato", "Use minimal olive oil" },
                                benefits = new[] { "Lean Protein: Fish supports stable glucose", "Omega-3: Supports heart health", "Controlled Carbs: Sweet potato in moderation" }
                            },
                            new
                            {
                                id = 84,
                                name = "Turkey and Quinoa Bowl",
                                imageUrl = "https://images.unsplash.com/photo-1546833999-b9f581a1996d",
                                videoUrl = "https://www.youtube.com/watch?v=8jcc4lGIW7E",
                                calories = 420,
                                time = 20,
                                macros = new { fat = 12, protein = 32, carbs = 42 },
                                ingredients = new[] { "Ground turkey", "Quinoa", "Vegetables", "Olive oil", "Herbs" },
                                steps = new[] { "Cook lean ground turkey", "Prepare controlled portion of quinoa", "Add plenty of vegetables", "Season with herbs" },
                                benefits = new[] { "Complete Protein: Turkey and quinoa provide all amino acids", "Controlled Portions: Supports blood sugar management", "Fiber Rich: Quinoa and vegetables aid glucose control" }
                            }
                        }
                    })
                }
            };
        }
    }
} 