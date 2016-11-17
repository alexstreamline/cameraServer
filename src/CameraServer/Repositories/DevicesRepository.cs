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
    public class DevicesRepository : IRepository<Device>
    {
        #region Fields & Properties

        protected readonly MainContext Context;
        protected readonly ILogger Logger;

        #endregion Fields & Properties

        public DevicesRepository(MainContext context, ILoggerFactory loggerFactory) 
            //: base(context, loggerFactory)
        {
            Context = context;
            Logger = loggerFactory.CreateLogger(nameof(DevicesRepository));
        }

        public Device Get(long id)
        {
            return Context.Devices.First(t => t.Id == id);
        }

        public List<Device> GetAll()
        {
            Logger.LogCritical("Получение всех 'Devices'");
            return Context.Devices.ToList();
        }

        public void Delete(long id)
        {
            var entity = Context.Devices.First(t => t.Id == id);
            Context.Devices.Remove(entity);
            Context.SaveChanges();
        }

        public void Post(Device device)
        {
            Context.Devices.Add(device);
            Context.SaveChanges();
        }

        public void Put(long id, [FromBody]Device device)
        {
            Context.Devices.Update(device);
            Context.SaveChanges();
        }
    }
}
