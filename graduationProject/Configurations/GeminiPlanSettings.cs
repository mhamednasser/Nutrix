namespace graduationProject.Configurations
{
    public class GeminiPlanSettings
    {
        public string ApiKey { get; set; } = string.Empty;
        public string Model { get; set; } = "gemini-2.0-flash-exp";
        public int MaxTokens { get; set; } = 2048;
        public double Temperature { get; set; } = 0.1; // Low temp for faster, consistent responses
        public int TimeoutSeconds { get; set; } = 30;
        public int TopK { get; set; } = 20; // Reduced for speed
        public double TopP { get; set; } = 0.8; // Optimized for speed
    }
} 