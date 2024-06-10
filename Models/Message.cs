using System.ComponentModel.DataAnnotations;

namespace ChatMicroserviceAPI.Models;

public class Message
{
    // [Key]
    // public int Id { get; set; }
    // public int SenderId { get; set; }
    // public int ReceiverId { get; set; }
    // public string Content { get; set; }
    // public DateTime SentAt { get; set; }
    // public bool IsRead { get; set; }
    
    
        [Key]
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public int ConversationId { get; set; } // Asegúrate de que este campo existe
        public string Content { get; set; }
        public DateTime SentAt { get; set; }
        public bool IsRead { get; set; }
    
}