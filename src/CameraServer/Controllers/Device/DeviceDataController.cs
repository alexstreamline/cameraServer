using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CameraServer.Enums;
using CameraServer.Models.Devices;
using CameraServer.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CameraServer.Controllers.Device
{
    [Authorize]
    public class DeviceDataController : Controller
    {
        #region Fields & Properties

        public IRepository<DeviceData> Repository { get; set; }

        #endregion Fields & Properties

        #region ctors

        public DeviceDataController(IRepository<DeviceData> repo)
        {
            Repository = repo;
        }

        #endregion ctors

        #region Methods

        public IActionResult Index()
        {
            ViewBag.Label = $"Сущности {nameof(DeviceData)}";
            ViewBag.Items = Repository.GetAll();
            return View();
        }

        public IActionResult Error(string actionString, long id)
        {
            ViewBag.Id = id;
            CrudAction action;
            Enum.TryParse(actionString, out action);
            switch (action)
            {
                case CrudAction.Create:
                    ViewBag.Action = "Создать";
                    break;
                case CrudAction.Read:
                    ViewBag.Action = "Прочитать";
                    break;
                case CrudAction.Update:
                    ViewBag.Action = "Обновить";
                    break;
                case CrudAction.Delete:
                    ViewBag.Action = "Удалить";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(action), action, null);
            }
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create(long? id)
        {
            var model = new DeviceData();
            if (id.HasValue)
            {
                model = Repository.Get(id.Value);
            }
            return View(model);
        }

        [HttpGet]
        public RedirectResult Delete(long? id)
        {
            if (!id.HasValue)
                return Redirect($"DeviceData/Error?action={CrudAction.Delete}&id={id}");
            Repository.Delete(id.Value);
            return Redirect("/DeviceData");
        }

        [HttpPost]
        public RedirectResult Create(DeviceData deviceData)
        {
            if (Repository.Get(deviceData.Id) != null)
            {
                var update = Repository.Get(deviceData.Id);
                update.CopyDataFrom(deviceData);
                Repository.Put(update.Id, update);
                return Redirect("/DeviceData");
            }
            Repository.Post(deviceData);
            return Redirect("/DeviceData");
        }

        #endregion Methods
    }
}