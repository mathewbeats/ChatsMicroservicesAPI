using ChatMicroserviceAPI.Models;

namespace ChatMicroserviceAPI.IRepository;

public interface IMessageRepository
{
    Task<IEnumerable<Message>> GetAllMessagesAsync();
    Task<IEnumerable<Message>> GetMessagesByUserAsync(int userId);
    Task<Message> GetMessageByIdAsync(int id);
    Task<Message> CreateMessageAsync(Message message);
    Task<bool> UpdateMessageAsync(int id, Message message);
    Task<bool> DeleteMessageAsync(int id);
    Task<bool> SaveChangesAsync();

    Task<IEnumerable<Message>> GetMessagesByConversationIdAsync(int conversationId);
}