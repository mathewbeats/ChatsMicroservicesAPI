using ChatMicroserviceAPI.Data;
using ChatMicroserviceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatMicroserviceAPI.IRepository.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ApplicationDbContext _context;

        public MessageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Message>> GetAllMessagesAsync()
        {
            return await _context.Messages.OrderBy(c => c.SenderId).ThenBy(c => c.ReceiverId).ToListAsync();
        }

        public async Task<IEnumerable<Message>> GetMessagesByUserAsync(int userId)
        {
            return _context.Messages.Where(c => c.SenderId == userId || c.ReceiverId == userId)
                .OrderBy(c => c.SentAt)
                .ToList();
        }

        public async Task<IEnumerable<Message>> GetMessagesByConversationIdAsync(int conversationId)
        {
            return await _context.Messages
                .Where(m => m.ConversationId == conversationId)
                .ToListAsync();
        }

        public async Task<Message> GetMessageByIdAsync(int id)
        {
            return await _context.Messages.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Message> CreateMessageAsync(Message message)
        {
            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();
            return message;
        }

        public async Task<bool> UpdateMessageAsync(int id, Message message)
        {
            var existingMessage = await _context.Messages.FindAsync(id);

            if (existingMessage is null)
            {
                throw new ArgumentNullException(nameof(existingMessage));
            }

            _context.Entry(existingMessage).CurrentValues.SetValues(message);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMessageAsync(int id)
        {
            var existingId = await _context.Messages.FindAsync(id);

            if (existingId is null)
            {
                return false;
            }

            _context.Messages.Remove(existingId);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
