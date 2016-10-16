using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CameraServer.Repositories
{
    using Models;
    using Models.Devices;

    /// <summary>
    /// Репозиторий Devices
    /// </summary>
    public class DevicesRepository : Repository<Device>
    {
        public DevicesRepository(MainContext context, ILoggerFactory loggerFactory) 
            : base(context, loggerFactory)
        {

        }

        public override Device Get(long id)
        {
            return Context.Devices.First(t => t.Id == id);
        }

        public override List<Device> GetAll()
        {
            Logger.LogCritical("Получение всех 'Devices'");
            return Context.Devices.ToList();
        }

        public override void Delete(long id)
        {
            var entity = Context.Devices.First(t => t.Id == id);
            Context.Devices.Remove(entity);
            Context.SaveChanges();
        }

        public override void Post(Device device)
        {
            Context.Devices.Add(device);
            Context.SaveChanges();
        }

        public override void Put(long id, [FromBody]Device device)
        {
            Context.Devices.Update(device);
            Context.SaveChanges();
        }
    }
}
