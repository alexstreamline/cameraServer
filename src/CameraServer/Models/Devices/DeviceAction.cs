using System;

namespace CameraServer.Models.Devices
{
    /// <summary>
    /// TODO:
    /// </summary>
    public class DeviceAction
    {
        public long Id { get; set; }

        public DateTime ActionTime { get; set; }
        public DayOfWeek ActionDayOfWeek { get; set; }

        public bool IsCamera1PhotoNeed { get; set; } = false;
        public bool IsCamera2PhotoNeed { get; set; } = false;
        public bool IsCamera3PhotoNeed { get; set; } = false;
        public bool IsCamera4PhotoNeed { get; set; } = false;

        public bool IsSensorDataNeed { get; set; } = false;
    }
}
