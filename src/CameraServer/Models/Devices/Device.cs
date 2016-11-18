namespace CameraServer.Models.Devices
{
    /// <summary>
    /// TODO: базовый класс для описания запроса сбора информации на устройстве
    /// </summary>
    public class Device
    {
        public long Id { get; set; }
        public System.DayOfWeek ActionDayOfWeek { get; set; }
        public bool IsCamera1PhotoNeed { get; set; } = false;
        public bool IsCamera2PhotoNeed { get; set; } = false;
        public bool IsCamera3PhotoNeed { get; set; } = false;
        public bool IsCamera4PhotoNeed { get; set; } = false;
        public bool IsPhotoNeedToServer { get; set; } = false;
        public bool IsSensorDataNeed { get; set; } = false;
        public bool IsMotionSensor1DataNeed { get; set; } = false;
        public bool IsMotionSensor2DataNeed { get; set; } = false;
        public bool IsMotionSensor3DataNeed { get; set; } = false;
        public bool IsMotionSensor4DataNeed { get; set; } = false;
        public bool IsGPSGLONASSDataNeed { get; set; } = false;
        public bool IsBarometerDataNeed { get; set; } = false;
        public bool IsCompassDataNeed { get; set; } = false;
        public bool IsAccelerometerDataNeed { get; set; } = false;
        public bool IsGyroscopeDataNeed { get; set; } = false;
        public bool IsThermometerDataNeed { get; set; } = false;
        public bool IsWetSensorDataNeed { get; set; } = false;
    }
}
