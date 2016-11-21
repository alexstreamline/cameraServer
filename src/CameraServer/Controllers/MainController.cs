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
        public IActionResult GetDevicesByWeekDay(DayOfWeek dayOfWeek)
        {
            ViewBag.DeviceActionsLabel = $"Сущности {nameof(DeviceAction)}";//nameof(DeviceActionRepo);
            ViewBag.DeviceActions = (DeviceActionRepo as DeviceActionsRepository).GetAllByDay(dayOfWeek);
            ViewBag.TriggerDeviceActionsLabel = $"Сущности {nameof(TriggerDeviceAction)}";//nameof(TriggerDeviceActionRepo);
            ViewBag.TriggerDeviceActions = (TriggerDeviceActionRepo as TriggerDeviceActionRepository).GetAllByDay(dayOfWeek);
            return View();
        }

        #endregion Methods
    }
}
