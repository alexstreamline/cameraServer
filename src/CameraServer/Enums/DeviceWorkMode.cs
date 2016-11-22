using System.ComponentModel.DataAnnotations;

namespace CameraServer.Enums
{
    /// <summary>
    /// Режим работы датчика - включен, по запросу (?), выключен 
    /// </summary>
    public enum DeviceWorkMode
    {
        [Display(Name = "Включен")]
        On,
        [Display(Name = "По запросу")]
        Query,
        [Display(Name = "Выключен")]
        Off
    }
}
