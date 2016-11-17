using CameraServer.Models.Devices;
using CameraServer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CameraServer.Controllers
{
    public class DeviceActionController : Controller
    {
        public IRepository<DeviceAction> DeviceActionRepo { get; set; }

        public DeviceActionController(IRepository<DeviceAction> repo)
        {
            DeviceActionRepo = repo;
        }

        public IActionResult Index()
        {
            ViewBag.Items = DeviceActionRepo.GetAll();
            return View();
        }

        public IActionResult CreateDeviceAction()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateDeviceAction(long? id)
        {
            var model = new DeviceAction();
            if (id.HasValue)
            {
                model = DeviceActionRepo.Get(id.Value);
            }
            return View(model);
        }

        [HttpGet]
        public ContentResult DeleteDeviceAction(long? id)
        {
            if (id.HasValue)
            {
                DeviceActionRepo.Delete(id.Value);
            }
            //return View("/");
            return Content($"Удален 'DeviceAction' с id = {id}<br/><a href='/'>На главную</a>", "text/html");
        }

        [HttpPost]
        public string CreateDeviceAction(DeviceAction deviceAction)
        {
            if (DeviceActionRepo.Get(deviceAction.Id) != null)
            {
                DeviceActionRepo.Put(deviceAction.Id, deviceAction);
                //var update = DeviceActionRepo.Get(deviceAction.Id);
                //DeviceActionRepo.Put(update.Id, update);
                return $"Cущность 'DeviceAction' была изменена: {deviceAction}";
            }
            DeviceActionRepo.Post(deviceAction);
            return $"Cущность 'DeviceAction' была добавлена: {deviceAction}";
        }
    }
}
