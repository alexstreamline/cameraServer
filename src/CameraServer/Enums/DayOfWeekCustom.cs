using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CameraServer.Enums
{
    public enum DayOfWeekCustom
    {
        [Display(Name = "Понедельник")]
        Monday = 1,
        [Display(Name = "Вторник")]
        Tuesday,
        [Display(Name = "Среда")]
        Wednesday,
        [Display(Name = "Четверг")]
        Thursday,
        [Display(Name = "Пятница")] 
        Friday,
        [Display(Name = "Суббота")]
        Saturday,
        [Display(Name = "Воскресенье")]
        Sunday = 0
    }
}
