using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

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
        [DataType(DataType.Date)]
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
        }

        public override string ToString()
        {
            return
                new StringBuilder($"Id: {Id}, \nActionTime: {ActionTime}, \nActionDayOfWeek: {ActionDayOfWeek}, \n")
                    .ToString();
            //.Append($"IsCamera1PhotoNeed: {IsCamera1PhotoNeed}, \nIsCamera2PhotoNeed: {IsCamera2PhotoNeed}, \n")
            //.Append($"IsCamera3PhotoNeed: {IsCamera3PhotoNeed}, \nIsCamera4PhotoNeed: {IsCamera4PhotoNeed}, \n")
            //.Append($"IsSensorDataNeed: {IsSensorDataNeed}")
            //.ToString();
        }

        #endregion Methods
    }
}
