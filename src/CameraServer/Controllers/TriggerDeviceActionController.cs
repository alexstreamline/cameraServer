using CameraServer.Models.Devices;
using CameraServer.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CameraServer.Controllers
{
    [Authorize]
    public class TriggerDeviceActionController : Controller
    {
        #region Fields & Properties

        public IRepository<TriggerDeviceAction> TriggerDeviceActionRepo { get; set; }

        #endregion Fields & Properties

        #region ctors

        public TriggerDeviceActionController(IRepository<TriggerDeviceAction> repo)
        {
            TriggerDeviceActionRepo = repo;
        }

        #endregion ctors

        #region Methods

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.Items = TriggerDeviceActionRepo.GetAll();
            return View();
        }

        public IActionResult CreateTriggerDeviceAction()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateTriggerDeviceAction(long? id)
        {
            var model = new TriggerDeviceAction();
            if (id.HasValue)
            {
                model = TriggerDeviceActionRepo.Get(id.Value);
            }
            return View(model);
        }

        [HttpGet]
        public ContentResult DeleteTriggerDeviceAction(long? id)
        {
            if (id.HasValue)
            {
                TriggerDeviceActionRepo.Delete(id.Value);
            }
            return Content($"Удален 'TriggerDeviceAction' с id = {id}<br/><a href='/'>На главную</a>", "text/html");
        }

        [HttpPost]
        public string CreateTriggerDeviceAction(TriggerDeviceAction deviceAction)
        {
            if (TriggerDeviceActionRepo.Get(deviceAction.Id) != null)
            {
                var update = TriggerDeviceActionRepo.Get(deviceAction.Id);
                update.CopyDataFrom(deviceAction);
                TriggerDeviceActionRepo.Put(update.Id, update);
                return $"Cущность 'TriggerDeviceAction' была изменена: {deviceAction}";
            }
            TriggerDeviceActionRepo.Post(deviceAction);
            return $"Cущность 'TriggerDeviceAction' была добавлена: {deviceAction}";
        }

        #endregion Methods
    }
}