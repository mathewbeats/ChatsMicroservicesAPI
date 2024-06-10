namespace ChatMicroserviceAPI.Models.Dtos;

public static class ToDto
{

    public static Message ToDtoMessage(this Message message)
    {
        return new Message()
        {
            Id = message.Id,

        };
    }
    
    
    
}