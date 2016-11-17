using System;
using System.ComponentModel.DataAnnotations;

namespace CameraServer.Models
{
    /// <summary>
    /// Сущность для представления фото с камеры
    /// </summary>
    public class CameraPhoto
    {
        public long Id { get; set; }
        public int CameraNumber { get; set; }
        public string Name { get; set; }
        public string FsLocation { get; set; }
        //[DataType(DataType.Date)]
        public DateTime TimeStamp { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, CamNum: {CameraNumber}, Name: {Name}, FsLocation: {FsLocation}, TimeStamp: {TimeStamp}";
            //return base.ToString();
        }
    }
}
