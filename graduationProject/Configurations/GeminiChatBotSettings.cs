namespace graduationProject.Configurations
{
    public class GeminiChatBotSettings
    {
        public string ApiKey { get; set; } = string.Empty;
        public string Model { get; set; } = "gemini-2.0-flash-exp";
        public int MaxTokens { get; set; } = 2048;
        public double Temperature { get; set; } = 0.7;
        public int TopK { get; set; } = 40;
        public double TopP { get; set; } = 0.95;
        public int TimeoutSeconds { get; set; } = 30;
    }
} 