using System.ComponentModel.DataAnnotations;
using CameraServer.Enums;
using System;

namespace CameraServer.Models.Devices
{
    public class DeviceSensorSettings
    {
        #region Fields & Properties
        //motion
        //compass
        //gyroscope
        //accelerometer
        //barometer
        //gps
        //temperature
        //humidity (wet sensor)

        [Required]
        [UIHint("HiddenInput")]
        public long Id { get; set; }

        #region Motion

        private int _motionTimeLimit;

        [Display(Name = "Датчик движения: ограничение, сек. (0 - 10)")]
        public int MotionTimeLimit
        {
            get { return _motionTimeLimit; }
            set
            {
                if (value >= 0 && value <= 10)
                {
                    _motionTimeLimit = value;
                }
            }
        }

        #endregion

        #region Compas

        private float _compasLimitValue;
        [Display(Name = "Компас: ограничение, градусы (0-360)")]
        public float CompasLimitValue
        {
            get { return _compasLimitValue; }
            set
            {
                if (value >= 0 && value < 360)
                {
                    _compasLimitValue = value;
                }
            }
        }
        //[Display(Name = "Компас: режим")]
        //public DeviceWorkMode CompasWorkMode { get; set; }

        #endregion Compas

        #region Gyroscope

        public float _gyroscopeLimitValue;

        [Display(Name = "Гироскоп: ограничение, градусы (0-360)")]
        public float GyroscopeLimitValue
        {
            get { return _gyroscopeLimitValue; }
            set
            {
                if (value >= 0 && value <= 360)
                {
                    _gyroscopeLimitValue = value;
                }
            }
        }
        //[Display(Name = "Гироскоп: режим")]
        //public DeviceWorkMode GyroscopeWorkMode { get; set; }

        #endregion Gyroscope

        #region Accelerometer

        private float _accelerometerLimitValue;

        [Display(Name = "Акселерометр: ограничение, м/с^2 (0-10)")]
        public float AccelerometerLimitValue
        {
            get { return _accelerometerLimitValue; }
            set
            {
                if (value >= 0 && value <= 10)
                {
                    _accelerometerLimitValue = value;
                }
            }

        }
        //[Display(Name = "Акселерометр: режим")]
        //public DeviceWorkMode AccelerometerWorkMode { get; set; }

        #endregion Accelerometer

        #region Barometer

        private float _barometerLimitValue;
        [Display(Name = "Барометр: ограничение, мбар (0-1000)")]
        public float BarometerLimitValue
        {
            get { return _barometerLimitValue; }
            set
            {
                if (value >= 0 && value <= 1000)
                {
                    _barometerLimitValue = value;
                }
            }
        }
        //[Display(Name = "Барометр: режим")]
        //public DeviceWorkMode BarometerWorkMode { get; set; }

        #endregion Barometer

        #region GPS / GLONASS

        // ReSharper disable InconsistentNaming
        private float _GPSGLONASSLimitValue;
        [Display(Name = "GPS/GLONASS: ограничение, град. (0 - 0.1)")]
        public float GPSGLONASSLimitValue
        {
            get { return _GPSGLONASSLimitValue; }
            set
            {
                if (value >= 0 && value <= 0.1)
                {
                    _GPSGLONASSLimitValue = value;
                }
            }
        }
        //[Display(Name = "GPS/GLONASS: режим")]
        //public DeviceWorkMode GPSGLONASSWorkMode { get; set; }
        // ReSharper restore InconsistentNaming

        #endregion GPS / GLONASS

        #region Thermometer

        private float _thermometerLimitValue;
        [Display(Name = "Термометр: ограничение, град. Цельсия (0-50)")]
        public float ThermometerLimitValue
        {
            get { return _thermometerLimitValue; }
            set
            {
                if (value >= 0 && value <= 50)
                {
                    _thermometerLimitValue = value;
                }
            }
        }
        //[Display(Name = "Термометр: режим")]
        //public DeviceWorkMode ThermometerWorkMode { get; set; }

        #endregion Thermometer

        #region WetSensor

        private float _wetSensorLimitValue;
        [Display(Name = "Датчик влажности: ограничение, % (0-30)")]
        public float WetSensorLimitValue
        {  
             get { return _wetSensorLimitValue; }
            set
            {
                if (value >= 0 && value <= 30)
                {
                    _wetSensorLimitValue = value;
                }
            }
        }

        [Display(Name = "Включить режим непрерывного обмена")]
        public bool IsContinousModeEnable { get; set; }
        [Display(Name = "Время старта режима (ЧЧ:ММ)")]
        [DataType(DataType.Time)]
        public DateTime StartTimeContinousMode { get; set; }
        [Display(Name = "Время окончания режима (ЧЧ:ММ)")]
        [DataType(DataType.Time)]
        public DateTime EndTimeContinousMode { get; set; }
        //[Display(Name = "Датчик влажности: режим")]
        //public DeviceWorkMode WetSensorWorkMode { get; set; }

        #endregion WetSensor

        #endregion Fields & Properties

        #region Methods

        public void CopyDataFrom(DeviceSensorSettings otherDss)
        {
            //Id = otherDss.Id;
            CompasLimitValue = otherDss.CompasLimitValue;
            //CompasWorkMode = otherDss.CompasWorkMode;
            GyroscopeLimitValue = otherDss.GyroscopeLimitValue;
            //GyroscopeWorkMode = otherDss.GyroscopeWorkMode;
            AccelerometerLimitValue = otherDss.AccelerometerLimitValue;
            //AccelerometerWorkMode = otherDss.AccelerometerWorkMode;
            GPSGLONASSLimitValue = otherDss.GPSGLONASSLimitValue;
            //GPSGLONASSWorkMode = otherDss.GPSGLONASSWorkMode;
            ThermometerLimitValue = otherDss.ThermometerLimitValue;
            //ThermometerWorkMode = otherDss.ThermometerWorkMode;
            BarometerLimitValue = otherDss.BarometerLimitValue;
            //BarometerWorkMode = otherDss.BarometerWorkMode;
            WetSensorLimitValue = otherDss.WetSensorLimitValue;
            //WetSensorWorkMode = otherDss.WetSensorWorkMode;
        }

        public void CopySettings(DeviceSensorSettings otherDss)
        {
            IsContinousModeEnable = otherDss.IsContinousModeEnable;
            StartTimeContinousMode = otherDss.StartTimeContinousMode;
            EndTimeContinousMode = otherDss.EndTimeContinousMode;
        }

        #endregion Methods
    }
}