using System;

namespace CameraServer.Models
{
    /// <summary>
    /// Сущность для представления фото с камеры
    /// </summary>
    public class CameraPhoto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string FsLocation { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
