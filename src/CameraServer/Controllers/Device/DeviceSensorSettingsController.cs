using System;
using CameraServer.Enums;
using CameraServer.Models.Devices;
using CameraServer.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CameraServer.Controllers.Device
{
    [Authorize]
    public class DeviceSensorSettingsController : Controller
    {
        #region Fields & Properties

        public IRepository<DeviceSensorSettings> Repository { get; set; }

        #endregion Fields & Properties

        #region ctors

        public DeviceSensorSettingsController(IRepository<DeviceSensorSettings> repo)
        {
            Repository = repo;
        }

        #endregion ctors

        #region Methods

        public IActionResult Index()
        {
            ViewBag.Label = "Настройки датчиков";//$"Сущности {nameof(DeviceSensorSettings)}";
            ViewBag.Items = Repository.GetAll();
            return View(ViewBag.Items[0]);
        }
        [AllowAnonymous]
        public JsonResult GetAllByJson()
        {
            ViewBag.Items = Repository.GetAll();
            return Json(Repository.GetAll());
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
            var model = new DeviceSensorSettings();
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
                return Redirect($"DeviceSensorSettings/Error?action={CrudAction.Delete}&id={id}");
            Repository.Delete(id.Value);
            return Redirect("/DeviceSensorSettings");
        }

        [HttpPost]
        public RedirectResult Create(DeviceSensorSettings sensorSettings)
        {
            if (Repository.Get(sensorSettings.Id) != null)
            {
                var update = Repository.Get(sensorSettings.Id);
                update.CopyDataFrom(sensorSettings);
                Repository.Put(update.Id, update);
                return Redirect("/DeviceSensorSettings");
            }
            Repository.Post(sensorSettings);
            return Redirect("/DeviceSensorSettings");
        }

        [HttpPost]
        public RedirectResult ChangeSettings(DeviceSensorSettings sensorSettings)//(bool isEnabled, string startTime, string endTime)
        {
            var settings = Repository.GetAll();

            if (settings.Count <= 0)
                return Redirect("/DeviceSensorSettings");
            var setting = Repository.Get(settings[0].Id);
            setting.CopyDataFrom(sensorSettings);
            Repository.Put(setting.Id, setting);
            return Redirect("/DeviceSensorSettings");
        }

        #endregion Methods
    }
}
