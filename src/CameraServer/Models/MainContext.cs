using Microsoft.EntityFrameworkCore;

namespace CameraServer.Models
{
    using Devices;
    using Sensors;
    using HardwareTrasmittableData;

    /// <summary>
    /// Основной контекст
    /// </summary>
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options)
            : base(options)
        {
            
        }

        public DbSet<Device> Devices { get; set; }
        public DbSet<DeviceAction> DeviceActions { get; set; }
        public DbSet<BaseSensor> BaseSensors { get; set; }
        public DbSet<CameraPhoto> CameraPhotos { get; set; }
        public DbSet<PhotoTransmit> PhotoTransmits { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Device>().HasKey(m => m.Id);
            builder.Entity<DeviceAction>().HasKey(m => m.Id);
            builder.Entity<BaseSensor>().HasKey(m => m.Id);
            builder.Entity<CameraPhoto>().HasKey(m => m.Id);
            builder.Entity<PhotoTransmit>().HasKey(m => m.Id);
            base.OnModelCreating(builder);
        }
    }
}
