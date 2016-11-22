using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameraServer.Models.Devices
{
    /// <summary>
    /// TODO:
    /// </summary>
    [Table("DeviceActions")]
    public class DeviceAction : Device
    {
        #region Fields & Properties

        [Display(Name = "Время в формате ЧЧ:ММ")]
        //[RegularExpression(@"^([0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]", ErrorMessage = "Неверное значение (формат: ЧЧ:ММ)")]
        //[RegularExpression(@"^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]", ErrorMessage = "Неверное значение (формат: ЧЧ:ММ)")]
        //[RegularExpression(@"(0[0-9]|1[0-9]|2[0-3]):([0-5][0-9])", ErrorMessage = "Неверное значение (формат: ЧЧ:ММ)")]
        //[RegularExpression(@"^\d$", ErrorMessage = "Неверное значение (формат: ЧЧ:ММ)")]
        [Required]
        [DataType(DataType.Time)]
        public DateTime ActionTime { get; set; }

        #endregion Fields & Properties

        #region Methods

        public void CopyDataFrom(DeviceAction otherDa)
        {
            Id = otherDa.Id;
            ActionTime = otherDa.ActionTime;
            ActionDayOfWeek = otherDa.ActionDayOfWeek;
            IsCamera1PhotoNeed = otherDa.IsCamera1PhotoNeed;
            IsCamera2PhotoNeed = otherDa.IsCamera2PhotoNeed;
            IsCamera3PhotoNeed = otherDa.IsCamera3PhotoNeed;
            IsCamera4PhotoNeed = otherDa.IsCamera4PhotoNeed;
            IsPhotoNeedToServer = otherDa.IsPhotoNeedToServer;
            IsSensorDataNeed = otherDa.IsSensorDataNeed;
            IsMotionSensor1DataNeed = otherDa.IsMotionSensor1DataNeed;
            IsMotionSensor2DataNeed = otherDa.IsMotionSensor2DataNeed;
            IsMotionSensor3DataNeed = otherDa.IsMotionSensor3DataNeed;
            IsMotionSensor4DataNeed = otherDa.IsMotionSensor4DataNeed;
            IsGPSGLONASSDataNeed = otherDa.IsGPSGLONASSDataNeed;
            IsBarometerDataNeed = otherDa.IsBarometerDataNeed;
            IsCompassDataNeed = otherDa.IsCompassDataNeed;
            IsAccelerometerDataNeed = otherDa.IsAccelerometerDataNeed;
            IsGyroscopeDataNeed = otherDa.IsGyroscopeDataNeed;
            IsThermometerDataNeed = otherDa.IsThermometerDataNeed;
            IsWetSensorDataNeed = otherDa.IsWetSensorDataNeed;
            IsVibrationSensorDataNeed = otherDa.IsVibrationSensorDataNeed;
        }

        #endregion Methods
    }
}
