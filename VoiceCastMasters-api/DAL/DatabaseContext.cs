using Microsoft.EntityFrameworkCore;
using VoiceCastMasters_api.Model;

namespace VoiceCastMasters_api.DAL;

public class DatabaseContext : DbContext
{
    public DbSet<User> Users { get; set; }
    
    public DatabaseContext()
        
    {
    }
}