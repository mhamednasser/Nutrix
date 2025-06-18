using graduationProject.DTOs;

namespace graduationProject.Interfaces
{
    public interface IChatBotService
    {
        Task<ChatMessageResponseDto> SendMessageAsync(string userId, ChatMessageRequestDto request);
        IAsyncEnumerable<string> SendMessageStreamAsync(string userId, ChatMessageRequestDto request);
        Task<ChatSessionDto?> GetChatSessionAsync(string userId, string? sessionId = null);
        Task<bool> ClearChatSessionAsync(string userId, string sessionId);
        Task<List<ChatSessionDto>> GetUserChatSessionsAsync(string userId);
    }
} 