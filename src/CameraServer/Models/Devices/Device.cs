using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace CameraServer.Models.Devices
{
    /// <summary>
    /// Базовый класс для описания запроса сбора информации на устройстве
    /// </summary>
    public abstract class Device
    {
        #region Fields & Properties

        private PropertyInfo[] _propertyInfos;

        [Required]
        [UIHint("HiddenInput")]
        public long Id { get; set; }

        [Display(Name = "День недели")]
        public DayOfWeek ActionDayOfWeek { get; set; }

        [Display(Name = "Нужна фото от 1 камеры?")]
        [UIHint("Boolean")]
        public bool IsCamera1PhotoNeed { get; set; }

        [Display(Name = "Нужна фото от 2 камеры?")]
        [UIHint("Boolean")]
        public bool IsCamera2PhotoNeed { get; set; }

        [Display(Name = "Нужна фото от 3 камеры?")]
        [UIHint("Boolean")]
        public bool IsCamera3PhotoNeed { get; set; }

        [Display(Name = "Нужна фото от 4 камеры?")]
        [UIHint("Boolean")]
        public bool IsCamera4PhotoNeed { get; set; }

        [Display(Name = "Отправлять фото на сервер?")]
        [UIHint("Boolean")]
        public bool IsPhotoNeedToServer { get; set; }

        [Display(Name = "Нужны данные от датчиков?")]
        [UIHint("Boolean")]
        public bool IsSensorDataNeed { get; set; }

        [Display(Name = "Нужны данные от 1 датчика движения?")]
        [UIHint("Boolean")]
        public bool IsMotionSensor1DataNeed { get; set; }

        [Display(Name = "Нужны данные от 2 датчика движения?")]
        [UIHint("Boolean")]
        public bool IsMotionSensor2DataNeed { get; set; }

        [Display(Name = "Нужны данные от 3 датчика движения?")]
        [UIHint("Boolean")]
        public bool IsMotionSensor3DataNeed { get; set; }

        [Display(Name = "Нужны данные от 4 датчика движения?")]
        [UIHint("Boolean")]
        public bool IsMotionSensor4DataNeed { get; set; }

        [Display(Name = "Нужны данные от GPS/ГЛОНАСС?")]
        [UIHint("Boolean")]
        // ReSharper disable once InconsistentNaming
        public bool IsGPSGLONASSDataNeed { get; set; }

        [Display(Name = "Нужны данные от барометра?")]
        [UIHint("Boolean")]
        public bool IsBarometerDataNeed { get; set; }

        [Display(Name = "Нужны данные от компаса?")]
        [UIHint("Boolean")]
        public bool IsCompassDataNeed { get; set; }

        [Display(Name = "Нужны данные от акселерометра?")]
        [UIHint("Boolean")]
        public bool IsAccelerometerDataNeed { get; set; }

        [Display(Name = "Нужны данные от гироскопа?")]
        [UIHint("Boolean")]
        public bool IsGyroscopeDataNeed { get; set; }

        [Display(Name = "Нужны данные от термометра?")]
        [UIHint("Boolean")]
        public bool IsThermometerDataNeed { get; set; }

        [Display(Name = "Нужны данные от датчика влаги?")]
        [UIHint("Boolean")]
        public bool IsWetSensorDataNeed { get; set; }

        [Display(Name = "Нужны данные от датчика вибрации?")]
        [UIHint("Boolean")]
        public bool IsVibrationSensorDataNeed { get; set; }

        #endregion Fields & Properties

        #region Methods

        public override string ToString()
        {
            if (_propertyInfos == null)
                _propertyInfos = this.GetType().GetProperties();

            var sb = new StringBuilder();

            foreach (var info in _propertyInfos)
            {
                var value = info.GetValue(this, null) ?? "(null)";
                sb.AppendLine($"{info.Name} : {value}");
            }

            return sb.ToString();
        }

        #endregion Methods
    }
}