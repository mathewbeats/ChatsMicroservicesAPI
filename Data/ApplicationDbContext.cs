using ChatMicroserviceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatMicroserviceAPI.Data;

public class ApplicationDbContext:DbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
    {
        
    }
    
    public DbSet<Message> Messages { get; set; }
    
}