using ChatMicroserviceAPI.IRepository;
using ChatMicroserviceAPI.Models;

namespace ChatMicroserviceAPI.Api
{
    public static class ApiExtensions
    {
        public static void MapEndPoints(IEndpointRouteBuilder map)
        {
            map.MapGet("chats", async (IMessageRepository repository) => await GetChatsAsync(repository));

            map.MapGet("chats/user/{userId:int}",
                async (int userId, IMessageRepository repository) => await GetChatsByUserIdAsync(userId, repository));

            map.MapGet("chats/{id:int}",
                async (int id, IMessageRepository repository) => await GetChatByIdAsync(id, repository));

            map.MapPost("chats",
                async (Message message, IMessageRepository repository) => await PostMessageAsync(message, repository));
        
            map.MapPut("chats/{id:int}",
                async (int id, Message message, IMessageRepository repository) =>
                    await UpdateMessageAsync(id, message, repository));
        
            map.MapDelete("chats/{id:int}",
                async (int id, IMessageRepository repository) => await DeleteMessageAsync(id, repository));

            map.MapGet("chats/conversation/{conversationId:int}",
                async (int conversationId, IMessageRepository repository) => await GetMessagesByConversationAsync(conversationId, repository));
        }

        private static async Task<IResult> GetMessagesByConversationAsync(int conversationId, IMessageRepository repository)
        {
            var messages = await repository.GetMessagesByConversationIdAsync(conversationId);
            return Results.Ok(messages);
        }

        private static async Task<IResult> GetChatsAsync(IMessageRepository repository)
        {
            var messages = await repository.GetAllMessagesAsync();
            return Results.Ok(messages);
        }

        private static async Task<IResult> GetChatsByUserIdAsync(int userId, IMessageRepository repository)
        {
            var messages = await repository.GetMessagesByUserAsync(userId);
            return Results.Ok(messages);
        }

        private static async Task<IResult> GetChatByIdAsync(int id, IMessageRepository repository)
        {
            var message = await repository.GetMessageByIdAsync(id);
            return Results.Ok(message);
        }

        private static async Task<IResult> PostMessageAsync(Message message, IMessageRepository repository)
        {
            var createdMessage = await repository.CreateMessageAsync(message);
            return Results.Created($"chats/{createdMessage.Id}", createdMessage);
        }

        private static async Task<IResult> UpdateMessageAsync(int id, Message message, IMessageRepository repository)
        {
            var updated = await repository.UpdateMessageAsync(id, message);
            return updated ? Results.NoContent() : Results.NotFound();
        }

        private static async Task<IResult> DeleteMessageAsync(int id, IMessageRepository repository)
        {
            var deleted = await repository.DeleteMessageAsync(id);
            return deleted ? Results.NoContent() : Results.NotFound();
        }
    }
}
