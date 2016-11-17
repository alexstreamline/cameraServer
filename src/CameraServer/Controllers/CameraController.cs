using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CameraServer.Models;
using CameraServer.Models.Devices;
using CameraServer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CameraServer.Controllers
{
    public class CameraController : Controller
    {
        //public Repository<DeviceAction> DeviceActionRepo { get; set; }

        //public CameraController(Repository<DeviceAction> repo)
        //{
        //    DeviceActionRepo = repo;
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Main()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public string CreateCameraPhoto(CameraPhoto photo)
        //{
        //    return $"Попытка создать сущность 'CameraPhoto': {photo}";
        //}

        //public IActionResult DeviceAction()
        //{
        //    ViewBag.Items = DeviceActionRepo.GetAll();
        //    return View();
        //}

        //[HttpGet]
        //public IActionResult GetDeviceActionsByWeekDay(DayOfWeek dayOfWeek)
        //{
        //    ViewBag.Message = $"Day of week (0-6, sunday = 0): {dayOfWeek}";
        //    return View();
        //}

        //public IActionResult CreateDeviceAction()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public string CreateDeviceAction(DeviceAction deviceAction)
        //{
        //    DeviceActionRepo.Post(deviceAction);
        //    return $"Попытка создать сущность 'DeviceAction': {deviceAction}";
        //}

        //[HttpGet]
        //public string CreateCameraPhoto(CameraPhoto photo)
        //{
        //    return $"Попытка создать сущность 'CameraPhoto': {photo}";
        //}

        //[HttpGet]
        //public string CreateCameraPhoto(int id)
        //{
        //    return $"Попытка создать сущность 'CameraPhoto': id {id}";
        //}
    }
}
