﻿using System;
using CameraServer.Models.Devices;
using CameraServer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CameraServer.Controllers
{
    public class MainController : Controller
    {
        #region Fields & Properties

        public IRepository<DeviceAction> DeviceActionRepo { get; set; }

        #endregion Fields & Properties

        #region ctors

        public MainController(IRepository<DeviceAction> repo)
        {
            DeviceActionRepo = repo;
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
            //ViewBag.DeviceActions = DeviceActionRepo.GetAll();
            ViewBag.DeviceActions = (DeviceActionRepo as DeviceActionsRepository).GetAllByDay(dayOfWeek);
            return View();
        }

        #endregion Methods
    }
}
