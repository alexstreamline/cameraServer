using System;
using CameraServer.Enums;
using CameraServer.Models.Devices;
using CameraServer.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CameraServer.Controllers.Device
{
    [Authorize]
    public class DeviceActionController : Controller
    {
        #region Fields & Properties

        public IRepository<DeviceAction> Repository { get; set; }

        #endregion Fields & Properties

        #region ctors

        public DeviceActionController(IRepository<DeviceAction> repo)
        {
            Repository = repo;
        }

        #endregion ctors

        #region Methods

        public IActionResult Index()
        {
            ViewBag.Items = Repository.GetAll();
            return View();
        }

        [HttpGet]
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
            var model = new DeviceAction();
            if (id.HasValue)
            {
                model = Repository.Get(id.Value);
            }
            return View(model);
        }

        [HttpGet]
        //public ContentResult Delete(long? id)
        public RedirectResult Delete(long? id)
        {
            if (!id.HasValue)
                return Redirect($"DeviceAction/Error?actionString={CrudAction.Delete}&id={id}");
            Repository.Delete(id.Value);
            return Redirect("/");
            //return Content($"Удален '{nameof(DeviceAction)}' с id = {id}<br/><a href='/'>На главную</a>", "text/html");
        }

        [HttpPost]
        //public string Create(DeviceAction deviceAction)
        public RedirectResult Create(DeviceAction deviceAction)
        {
            if (Repository.Get(deviceAction.Id) != null)
            {
                var update = Repository.Get(deviceAction.Id);
                update.CopyDataFrom(deviceAction);
                Repository.Put(update.Id, update);
                return Redirect("/");
                //return $"Cущность '{nameof(DeviceAction)}' была изменена: {deviceAction}";
            }
            Repository.Post(deviceAction);
            return Redirect("/");
            //return $"Cущность '{nameof(DeviceAction)}' была добавлена: {deviceAction}";
        }

        #endregion Methods
    }
}