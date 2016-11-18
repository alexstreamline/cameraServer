using Microsoft.EntityFrameworkCore;

namespace CameraServer.Models.Users
{
    /// <summary>
    /// Контекст пользователей (для авторизации)
    /// </summary>
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {

        }
    }
}
