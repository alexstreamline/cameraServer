using CameraServer.Models.Devices;
using CameraServer.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CameraServer.Enums;

namespace CameraServer.Controllers
{
    [Authorize]
    public class MainController : Controller
    {
        #region Fields & Properties

        public IRepository<DeviceAction> Repository { get; set; }
        
        #endregion Fields & Properties

        #region ctors

        public MainController(IRepository<DeviceAction> repository)
        {
            Repository = repository;
        }

        #endregion ctors

        #region Methods

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index(DayOfWeekCustom? dayOfWeek)
        {
            if (!dayOfWeek.HasValue)
                dayOfWeek = DayOfWeekCustom.Monday;
            ViewBag.Day = dayOfWeek.Value;
            return View();
        }

        [HttpGet]
        public IActionResult GetDevicesByWeekDay(DayOfWeekCustom dayOfWeek)
        {
            ViewBag.DeviceActionsLabel = "Сбор данных по времени";
            ViewBag.DeviceActions = (Repository as DeviceActionsRepository).GetAllByDay(dayOfWeek);
            return View();
        }

        #endregion Methods
    }
}
