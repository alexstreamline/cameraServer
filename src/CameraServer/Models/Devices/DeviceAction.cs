using System;

namespace CameraServer.Models.Devices
{
    /// <summary>
    /// TODO:
    /// </summary>
    public class DeviceAction: Device
    {
        public long Id { get; set; }

       public int Hour { get; set; }
        public int Minute { get; set; }
    }
}
