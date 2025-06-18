using System.ComponentModel.DataAnnotations;

namespace graduationProject.DTOs
{
    public class ChatMessageRequestDto
    {
        [Required]
        [StringLength(4000, ErrorMessage = "Message cannot exceed 4000 characters")]
        public string Message { get; set; } = string.Empty;
        
        public string? SessionId { get; set; }
        
        public bool IsFirstContact { get; set; } = false;
    }

    public class ChatMessageResponseDto
    {
        public string Message { get; set; } = string.Empty;
        public string SessionId { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public string BotPersona { get; set; } = string.Empty;
        public bool IsStreaming { get; set; } = false;
        public ChatResponseStatus Status { get; set; } = ChatResponseStatus.Success;
        public string? Error { get; set; }
    }

    public class ChatSessionDto
    {
        public string SessionId { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public string BotPersona { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime LastActivity { get; set; } = DateTime.UtcNow;
        public List<ChatHistoryItemDto> Messages { get; set; } = new();
    }

    public class ChatHistoryItemDto
    {
        public string Role { get; set; } = string.Empty; // "user" or "assistant"
        public string Content { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }

    public enum ChatResponseStatus
    {
        Success,
        Error,
        RateLimited,
        InvalidInput
    }

    public enum BotPersona
    {
        NotSet,
        NutritionCoach,
        FitnessCoach
    }
} 