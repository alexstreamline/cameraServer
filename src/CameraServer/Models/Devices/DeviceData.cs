using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CameraServer.Models.Devices
{
    /// <summary>
    /// Класс с телеметрией (значениями датчиков), полученной от устройства
    /// Каждый экземпляр соотвествует одному запросу данных
    /// </summary>
    public class DeviceData
    {
        [Display(Name = "Данные от GPS/ГЛОНАСС")]
        [UIHint("Float")]
        // ReSharper disable once InconsistentNaming
        public float GPSGLONASSDataLat { get; set; }
        public float GPSGLONASSDataLon { get; set; }

        [Display(Name = "Данные от барометра")]
        [UIHint("Float")]
        public float BarometerData { get; set; }

        [Display(Name = "Данные от компаса")] //todo направления у компаса
        [UIHint("Float")]
        public float CompassData { get; set; }

        [Display(Name = "Данные от акселерометра")]
        [UIHint("Float")]
        public float AccelerometerDataX { get; set; }
        public float AccelerometerDataY { get; set; }
        public float AccelerometerDataZ { get; set; }

        [Display(Name = "Данные от гироскопа")]
        [UIHint("Float")]
        public float GyroscopeDataX { get; set; }
        public float GyroscopeDataY { get; set; }
        public float GyroscopeDataZ { get; set; }

        [Display(Name = "Данные от термометра")]
        [UIHint("Float")]
        public float ThermometerData { get; set; }

        [Display(Name = "Данные от датчика влаги")]
        [UIHint("Float")]
        public float WetSensorData { get; set; }

        [Display(Name = "Данные от датчика вибрации")]
        [UIHint("Float")]
        public float VibrationSensorData { get; set; }
    }
}
