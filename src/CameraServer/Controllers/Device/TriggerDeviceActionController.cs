using System;
using CameraServer.Enums;
using CameraServer.Models.Devices;
using CameraServer.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CameraServer.Controllers.Device
{
    [Authorize]
    public class TriggerDeviceActionController : Controller
    {
        #region Fields & Properties

        public IRepository<TriggerDeviceAction> Repository { get; set; }

        #endregion Fields & Properties

        #region ctors

        public TriggerDeviceActionController(IRepository<TriggerDeviceAction> repo)
        {
            Repository = repo;
        }

        #endregion ctors

        #region Methods

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.TriggerDeviceActionsLabel = "Сбор данных по событию";
            ViewBag.TriggerDeviceActions = Repository.GetAll();
            return View();
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
            var model = new TriggerDeviceAction();
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
                return Redirect($"TriggerDeviceAction/Error?action={CrudAction.Delete}&id={id}");
            Repository.Delete(id.Value);
            return Redirect("/?dayOfWeek=100");
        }

        [HttpPost]
        public RedirectResult Create(TriggerDeviceAction deviceAction)
        {
            if (Repository.Get(deviceAction.Id) != null)
            {
                var update = Repository.Get(deviceAction.Id);
                update.CopyDataFrom(deviceAction);
                Repository.Put(update.Id, update);
                return Redirect("/?dayOfWeek=100");
            }
            Repository.Post(deviceAction);
            return Redirect("/?dayOfWeek=100");
        }

        #endregion Methods
    }
}