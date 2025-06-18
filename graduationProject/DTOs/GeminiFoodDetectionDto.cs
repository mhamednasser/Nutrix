using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace graduationProject.DTOs
{
    // New streamlined food detection response format
    public class GeminiFoodDetectionResponse
    {
        [JsonPropertyName("items")]
        public List<FoodItem> Items { get; set; } = new();

        [JsonPropertyName("source")]
        public string Source { get; set; } = "Gemini AI Analysis";

        [JsonPropertyName("confidence_avg")]
        public double ConfidenceAvg { get; set; }
    }

    public class FoodItem
    {
        [JsonPropertyName("food_name")]
        public string FoodName { get; set; } = string.Empty;

        [JsonPropertyName("serving_size")]
        public string ServingSize { get; set; } = string.Empty;

        [JsonPropertyName("calories")]
        public double Calories { get; set; }

        [JsonPropertyName("macros")]
        public MacroNutrients Macros { get; set; } = new();
    }

    public class MacroNutrients
    {
        [JsonPropertyName("protein")]
        public string Protein { get; set; } = string.Empty;

        [JsonPropertyName("fat")]
        public string Fat { get; set; } = string.Empty;

        [JsonPropertyName("carbohydrates")]
        public string Carbohydrates { get; set; } = string.Empty;
    }

    // Wrapper for API responses
    public class GeminiFoodDetectionWrapper
    {
        [JsonPropertyName("status")]
        public string Status { get; set; } = "success";

        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        [JsonPropertyName("food_detection")]
        public GeminiFoodDetectionResponse FoodDetection { get; set; } = new();
    }
} 