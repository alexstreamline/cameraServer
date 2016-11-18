using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CameraServer.Models.Devices
{
    /// <summary>
    /// TODO:
    /// </summary>
    public class DeviceAction
    {
        #region Fields & Properties

        [Required]
        [UIHint("HiddenInput")]
        public long Id { get; set; }

        [Display(Name = "Время в формате ЧЧ:ММ")]
        //[DisplayFormat(DataFormatString = "{0:t}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime ActionTime { get; set; }

        //[Display(Name = "Час")]
        //public int Hour { get; set; }
        //[Display(Name = "Минута")]
        //public int Minute { get; set; }

        [Display(Name = "День недели (0-6)")]
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

        [Display(Name = "Нужны данные от датчиков?")]
        [UIHint("Boolean")]
        public bool IsSensorDataNeed { get; set; }

        #endregion Fields & Properties

        #region Methods

        public void CopyDataFrom(DeviceAction otherDa)
        {
            Id = otherDa.Id;
            ActionTime = otherDa.ActionTime;
            //Hour = otherDa.Hour;
            //Minute = otherDa.Minute;
            ActionDayOfWeek = otherDa.ActionDayOfWeek;
            IsCamera1PhotoNeed = otherDa.IsCamera1PhotoNeed;
            IsCamera2PhotoNeed = otherDa.IsCamera2PhotoNeed;
            IsCamera3PhotoNeed = otherDa.IsCamera3PhotoNeed;
            IsCamera4PhotoNeed = otherDa.IsCamera4PhotoNeed;
            IsSensorDataNeed = otherDa.IsSensorDataNeed;
        }

        public override string ToString()
        {
            return new StringBuilder($"Id: {Id}, \nActionTime: {ActionTime}, \nActionDayOfWeek: {ActionDayOfWeek}, \n")
                .Append($"IsCamera1PhotoNeed: {IsCamera1PhotoNeed}, \nIsCamera2PhotoNeed: {IsCamera2PhotoNeed}, \n")
                .Append($"IsCamera3PhotoNeed: {IsCamera3PhotoNeed}, \nIsCamera4PhotoNeed: {IsCamera4PhotoNeed}, \n")
                .Append($"IsSensorDataNeed: {IsSensorDataNeed}")
                .ToString();
        }

        #endregion Methods
    }
}
