using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CameraServer.Models.Devices
{
    public class DeviceSensorSettings
    {
        [Display(Name = "По оси Х")]
        [UIHint("Float")]
        public float CompasLimitValueX { get; set; }   //todo уточнить, какие блядские направления есть у компаса
        public float CompasLimitValueY { get; set; }
        public float CompasLimitValueZ { get; set; }
        public DeviceWorkMode CompasWorkMode { get; set; }
        [Display(Name = "По оси Х")]
        [UIHint("Float")]
        public float GyroscopeLimitValueX { get; set; }
        public float GyroscopeLimitValueY { get; set; }
        public float GyroscopeLimitValueZ { get; set; }
        public DeviceWorkMode GyroscopeWorkMode { get; set; }
        [Display(Name = "По оси Х")]
        [UIHint("Float")]
        public float AccelerometerLimitValueX { get; set; }
        public float AccelerometerLimitValueY { get; set; }
        public float AccelerometerLimitValueZ { get; set; }
        public DeviceWorkMode AccelerometerWorkMode { get; set; }

        public float GPSGLONASSLimitValueLat { get; set; }
        public float GPSGLONASSLimitValueLon { get; set; }
        public DeviceWorkMode GPSGLONASSWorkMode { get; set; }

        public float ThermometerLimitValue { get; set; }
        public DeviceWorkMode ThermometerWorkMode { get; set; }

        public float BarometerLimitValue { get; set; }
        public DeviceWorkMode BarometerWorkMode { get; set; }

        public float WetSensorLimitValue { get; set; }
        public DeviceWorkMode WetSensorWorkMode { get; set; }
    }
}
