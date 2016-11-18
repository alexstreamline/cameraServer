using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CameraServer.Models.Devices;

namespace CameraServer.Core.Controller
{
    public class DeviceActionMessageBuilder
    {
        public byte[] MessageBuilder(DeviceAction deviceAction)
        {
           byte[] dataMessage = new byte[5];
            dataMessage[0] = 0xBE;
            dataMessage[1] = (byte)deviceAction.ActionTime.Hour;
            dataMessage[2] = (byte)deviceAction.ActionTime.Minute;
            //dataMessage[1] = (byte) deviceAction.Hour;
            //dataMessage[2] = (byte)deviceAction.Minute;
            dataMessage[3] = (byte) deviceAction.ActionDayOfWeek;
            byte camAndConnect = 0;
            if (deviceAction.IsCamera1PhotoNeed) { camAndConnect += 1;}
            if (deviceAction.IsCamera2PhotoNeed) { camAndConnect += 2; }
            if (deviceAction.IsCamera3PhotoNeed) { camAndConnect += 4; }
            if (deviceAction.IsCamera4PhotoNeed) { camAndConnect += 8; }
            if (deviceAction.IsSensorDataNeed) { camAndConnect += 16; }

            dataMessage[4] = camAndConnect;
            dataMessage[5] = 0xBE;
            return dataMessage;
        }
    }
}
