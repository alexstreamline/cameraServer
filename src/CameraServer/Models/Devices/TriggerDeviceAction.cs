using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CameraServer.Models.Devices
{
    [Table("TriggerDeviceActions")]
    public class TriggerDeviceAction : Device
    {
        [Display(Name = "Название датчика")]
        public string SensorName { get; set; }

        #region Methods

        public void CopyDataFrom(TriggerDeviceAction otherDa)
        {
            Id = otherDa.Id;
            SensorName = otherDa.SensorName;
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
                new StringBuilder($"Id: {Id}, \nSensorName: {SensorName}, \nActionDayOfWeek: {ActionDayOfWeek}, \n")
                    .ToString();
            //.Append($"IsCamera1PhotoNeed: {IsCamera1PhotoNeed}, \nIsCamera2PhotoNeed: {IsCamera2PhotoNeed}, \n")
            //.Append($"IsCamera3PhotoNeed: {IsCamera3PhotoNeed}, \nIsCamera4PhotoNeed: {IsCamera4PhotoNeed}, \n")
            //.Append($"IsSensorDataNeed: {IsSensorDataNeed}")
            //.ToString();
        }

        #endregion Methods
    }
}
