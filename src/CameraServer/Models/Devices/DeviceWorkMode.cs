using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CameraServer.Models.Devices
{
    /// <summary>
    /// Режим работы датчика - включен, по опросу (?), выключен 
    /// </summary>
    public enum DeviceWorkMode
    {
        On,
        Query,
        Off
    }
}
