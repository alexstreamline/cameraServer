namespace CameraServer.Models.Sensors
{
    /// <summary>
    /// TODO:
    /// </summary>
    public class BaseSensor
    {
        public long Id { get; set; }
        /// <summary>
        /// Имя датчика
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Время на запуск датчика, секунды
        /// </summary>
        public int SensorTimeForGetReady { get; set; }
        /// <summary>
        /// Время (я так понял что периодичность) опроса устройства (датчика)
        /// </summary>
        public InterrogationTime SensorInterrogationTime { get; set; } = InterrogationTime.Auto;
        /// <summary>
        /// Пороговое значение срабатывания датчика
        /// </summary>
        public double SensorTriggeredValueLimit { get; set; }

    }
}
