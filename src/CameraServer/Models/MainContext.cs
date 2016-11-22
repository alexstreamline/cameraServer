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

        public DbSet<DeviceAction> DeviceActions { get; set; }
        public DbSet<TriggerDeviceAction> TriggerDeviceActions { get; set; }
        public DbSet<DeviceSensorSettings> DeviceSensorSettings { get; set; }
        public DbSet<DeviceData> DeviceData { get; set; }
        public DbSet<BaseSensor> BaseSensors { get; set; }
        public DbSet<CameraPhoto> CameraPhotos { get; set; }
        public DbSet<PhotoTransmit> PhotoTransmits { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DeviceAction>().HasKey(m => m.Id);
            builder.Entity<TriggerDeviceAction>().HasKey(m => m.Id);
            builder.Entity<DeviceSensorSettings>().HasKey(m => m.Id);
            builder.Entity<DeviceData>().HasKey(m => m.Id);
            builder.Entity<BaseSensor>().HasKey(m => m.Id);
            builder.Entity<CameraPhoto>().HasKey(m => m.Id);
            builder.Entity<PhotoTransmit>().HasKey(m => m.Id);
            base.OnModelCreating(builder);
        }
    }
}
