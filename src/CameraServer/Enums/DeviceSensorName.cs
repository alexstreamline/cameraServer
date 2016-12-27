using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CameraServer.Enums
{
    public enum DeviceSensorName
    {
        // [Display(Name = "Motion1")]
        [Display(Name = "Датчик движения 1")]
        Motion1 = 1,
        [Display(Name = "Датчик движения 2")]
        Motion2,
        [Display(Name = "Датчик движения 3")]
        Motion3,
        [Display(Name = "Датчик движения 4")]
        Motion4,
        [Display(Name = "Компас")]
        Compass,
        [Display(Name = "Гироскоп")]
        Gyroscope,
        [Display(Name = "Акселерометр")]
        Accelerometer,
        [Display(Name = "Барометр")]
        Barometer,
        [Display(Name = "GPS/Глонасс")]
        Gps,
        [Display(Name = "Термометр")]
        Temperature,
        [Display(Name = "Датчик влажности")]
        Humidity,
        [Display(Name = "Датчик вибрации")]
        Vibration
            
        
    }
}
