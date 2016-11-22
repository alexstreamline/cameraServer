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
        //public IRepository<DeviceData> DeviceDataRepository { get; set; }
        //public IRepository<DeviceSensorSettings> DeviceSensorSettingsRepository { get; set; }
        
        #endregion Fields & Properties

        #region ctors

        public MainController(IRepository<DeviceAction> repoDa, IRepository<TriggerDeviceAction> repoTda)
                              //IRepository<DeviceData> repoDd, IRepository<DeviceSensorSettings> repoDss)
        {
            DeviceActionRepo = repoDa;
            TriggerDeviceActionRepo = repoTda;
            //DeviceDataRepository = repoDd;
            //DeviceSensorSettingsRepository = repoDss;
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
            ViewBag.DeviceActionsLabel = $"Сущности {nameof(DeviceAction)}";
            ViewBag.DeviceActions = (DeviceActionRepo as DeviceActionsRepository).GetAllByDay(dayOfWeek);
            ViewBag.TriggerDeviceActionsLabel = $"Сущности {nameof(TriggerDeviceAction)}";
            ViewBag.TriggerDeviceActions = (TriggerDeviceActionRepo as TriggerDeviceActionRepository).GetAllByDay(dayOfWeek);
            return View();
        }

        //[HttpGet]
        //public IActionResult DeviceSensorSettings()
        //{
        //    ViewBag.DeviceSensorSettingsLabel = $"Сущности {nameof(Models.Devices.DeviceSensorSettings)}";
        //    ViewBag.DeviceSensorSettings = DeviceSensorSettingsRepository.GetAll();
        //    return View();
        //}

        //[HttpGet]
        //public IActionResult DeviceData()
        //{
        //    ViewBag.DeviceDataLabel = $"Сущности {nameof(Models.Devices.DeviceSensorSettings)}";
        //    ViewBag.DeviceData = DeviceDataRepository.GetAll();
        //    return View();
        //}

        #endregion Methods
    }
}
