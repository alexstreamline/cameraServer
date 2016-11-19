using System;
using CameraServer.Models.Devices;
using CameraServer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CameraServer.Controllers
{
    public class MainController : Controller
    {
        #region Fields & Properties

        public IRepository<DeviceAction> DeviceActionRepo { get; set; }
        public IRepository<TriggerDeviceAction> TriggerDeviceActionRepo { get; set; }

        #endregion Fields & Properties

        #region ctors

        public MainController(IRepository<DeviceAction> repoDa, IRepository<TriggerDeviceAction> repoTda)
        {
            DeviceActionRepo = repoDa;
            TriggerDeviceActionRepo = repoTda;
        }

        #endregion ctors

        #region Methods

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetDeviceActionsByWeekDay(DayOfWeek dayOfWeek)
        {
            ViewBag.Message = $"Day of week (0-6, sunday = 0): {dayOfWeek}";
            ViewBag.DeviceActions = (DeviceActionRepo as DeviceActionsRepository).GetAllByDay(dayOfWeek);
            return View();
        }

        [HttpGet]
        public IActionResult GetTriggerDeviceActionsByWeekDay(DayOfWeek dayOfWeek)
        {
            ViewBag.Message = $"Day of week (0-6, sunday = 0): {dayOfWeek}";
            ViewBag.TriggerDeviceActions = (TriggerDeviceActionRepo as TriggerDeviceActionRepository).GetAllByDay(dayOfWeek);
            return View();
        }

        #endregion Methods
    }
}
