using System;
using System.ComponentModel.DataAnnotations;

namespace CameraServer.Models.Devices
{
    /// <summary>
    /// Класс с телеметрией (значениями датчиков), полученной от устройства
    /// Каждый экземпляр соотвествует одному запросу данных
    /// </summary>
    public class DeviceData
    {
        #region Fields & Properties

        [Required]
        [UIHint("HiddenInput")]
        public long Id { get; set; }

        [Display(Name = "Дата и время")]
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Timestamp { get; set; }

        #region GPS / GLONASS

        [Display(Name = "GPS/GLONASS: широта")]
        // ReSharper disable InconsistentNaming
        public float GPSGLONASSDataLat { get; set; }
        [Display(Name = "GPS/GLONASS: долгота")]
        public float GPSGLONASSDataLon { get; set; }
        // ReSharper restore InconsistentNaming

        #endregion GPS / GLONASS

        #region Accelerometer

        [Display(Name = "Акселерометр: ось Х")]
        public float AccelerometerDataX { get; set; }
        [Display(Name = "Акселерометр: ось Y")]
        public float AccelerometerDataY { get; set; }
        [Display(Name = "Акселерометр: ось Z")]
        public float AccelerometerDataZ { get; set; }

        #endregion Accelerometer

        #region Gyroscope

        [Display(Name = "Гироскоп: ось Х")]
        public float GyroscopeDataX { get; set; }
        [Display(Name = "Гироскоп: ось Y")]
        public float GyroscopeDataY { get; set; }
        [Display(Name = "Гироскоп: ось Z")]
        public float GyroscopeDataZ { get; set; }

        #endregion Gyroscope

        [Display(Name = "Данные от барометра")]
        public float BarometerData { get; set; }

        [Display(Name = "Данные от компаса")] //todo направления у компаса
        public float CompassData { get; set; }

        [Display(Name = "Данные от термометра")]
        public float ThermometerData { get; set; }

        [Display(Name = "Данные от датчика влаги")]
        public float WetSensorData { get; set; }

        [Display(Name = "Данные от датчика вибрации")]
        public float VibrationSensorData { get; set; }

        #endregion Fields & Properties

        #region Methods

        public void CopyDataFrom(DeviceData otherDd)
        {
            Id = otherDd.Id;
            Timestamp = otherDd.Timestamp;
            GPSGLONASSDataLat = otherDd.GPSGLONASSDataLat;
            GPSGLONASSDataLon = otherDd.GPSGLONASSDataLon;
            AccelerometerDataX = otherDd.AccelerometerDataX;
            AccelerometerDataY = otherDd.AccelerometerDataY;
            AccelerometerDataZ = otherDd.AccelerometerDataZ;
            GyroscopeDataX = otherDd.GyroscopeDataX;
            GyroscopeDataY = otherDd.GyroscopeDataY;
            GyroscopeDataZ = otherDd.GyroscopeDataZ;
            BarometerData = otherDd.BarometerData;
            CompassData = otherDd.CompassData;
            ThermometerData = otherDd.ThermometerData;
            WetSensorData = otherDd.WetSensorData;
            VibrationSensorData = otherDd.VibrationSensorData;
        }

        #endregion Methods
    }
}