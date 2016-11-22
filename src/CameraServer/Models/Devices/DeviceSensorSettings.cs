using System.ComponentModel.DataAnnotations;
using CameraServer.Enums;

namespace CameraServer.Models.Devices
{
    public class DeviceSensorSettings
    {
        #region Fields & Properties

        [Required]
        [UIHint("HiddenInput")]
        public long Id { get; set; }

        #region Compas

        [Display(Name = "Компас: ограничение")]
        public float CompasLimitValue { get; set; }   //todo уточнить, какие направления есть у компаса
        [Display(Name = "Компас: режим")]
        public DeviceWorkMode CompasWorkMode { get; set; }

        #endregion Compas

        #region Gyroscope

        [Display(Name = "Гироскоп: ограничение")]
        public float GyroscopeLimitValue { get; set; }
        [Display(Name = "Гироскоп: режим")]
        public DeviceWorkMode GyroscopeWorkMode { get; set; }

        #endregion Gyroscope

        #region Accelerometer

        [Display(Name = "Акселерометр: ограничение")]
        public float AccelerometerLimitValue { get; set; }
        [Display(Name = "Акселерометр: режим")]
        public DeviceWorkMode AccelerometerWorkMode { get; set; }

        #endregion Accelerometer

        #region GPS / GLONASS

        // ReSharper disable InconsistentNaming
        [Display(Name = "GPS/GLONASS: ограничение")]
        public float GPSGLONASSLimitValue { get; set; }
        [Display(Name = "GPS/GLONASS: режим")]
        public DeviceWorkMode GPSGLONASSWorkMode { get; set; }
        // ReSharper restore InconsistentNaming

        #endregion GPS / GLONASS

        #region Thermometer

        [Display(Name = "Термометр: ограничение")]
        public float ThermometerLimitValue { get; set; }
        [Display(Name = "Термометр: режим")]
        public DeviceWorkMode ThermometerWorkMode { get; set; }

        #endregion Thermometer

        #region Barometer

        [Display(Name = "Барометр: ограничение")]
        public float BarometerLimitValue { get; set; }
        [Display(Name = "Барометр: режим")]
        public DeviceWorkMode BarometerWorkMode { get; set; }

        #endregion Barometer

        #region WetSensor

        [Display(Name = "Датчик влажности: ограничение")]
        public float WetSensorLimitValue { get; set; }
        [Display(Name = "Датчик влажности: режим")]
        public DeviceWorkMode WetSensorWorkMode { get; set; }

        #endregion WetSensor

        #endregion Fields & Properties

        #region Methods

        public void CopyDataFrom(DeviceSensorSettings otherDss)
        {
            Id = otherDss.Id;
            CompasLimitValue = otherDss.CompasLimitValue;
            CompasWorkMode = otherDss.CompasWorkMode;
            GyroscopeLimitValue = otherDss.GyroscopeLimitValue;
            GyroscopeWorkMode = otherDss.GyroscopeWorkMode;
            AccelerometerLimitValue = otherDss.AccelerometerLimitValue;
            AccelerometerWorkMode = otherDss.AccelerometerWorkMode;
            GPSGLONASSLimitValue = otherDss.GPSGLONASSLimitValue;
            GPSGLONASSWorkMode = otherDss.GPSGLONASSWorkMode;
            ThermometerLimitValue = otherDss.ThermometerLimitValue;
            ThermometerWorkMode = otherDss.ThermometerWorkMode;
            BarometerLimitValue = otherDss.BarometerLimitValue;
            BarometerWorkMode = otherDss.BarometerWorkMode;
            WetSensorLimitValue = otherDss.WetSensorLimitValue;
            WetSensorWorkMode = otherDss.WetSensorWorkMode;
        }

        #endregion Methods
    }
}