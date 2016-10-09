using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CameraServer.Models.Device
{
    public class DeviceAction
    {
        public DateTime ActionTime { get; set; }
        public DayOfWeek ActionDayOfWeek { get; set; }

        public bool IsCamera1PhotoNeed { get; set; } = false;
        public bool IsCamera2PhotoNeed { get; set; } = false;
        public bool IsCamera3PhotoNeed { get; set; } = false;
        public bool IsCamera4PhotoNeed { get; set; } = false;

        public bool IsSensorDataNeed { get; set; } = false;
    }
}
