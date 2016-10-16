using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CameraServer.Repositories
{
    using Models;
    using Models.Devices;

    /// <summary>
    /// Репозиторий DeviceActions
    /// </summary>
    public class DeviceActionsRepository : Repository<DeviceAction>
    {
        public DeviceActionsRepository(MainContext context, ILoggerFactory loggerFactory) 
            : base(context, loggerFactory)
        {

        }

        public override DeviceAction Get(long id)
        {
            return Context.DeviceActions.First(t => t.Id == id);
        }

        public override List<DeviceAction> GetAll()
        {
            Logger.LogCritical("Получение всех 'DeviceActions'");
            return Context.DeviceActions.ToList();
        }

        public override void Delete(long id)
        {
            var entity = Context.DeviceActions.First(t => t.Id == id);
            Context.DeviceActions.Remove(entity);
            Context.SaveChanges();
        }

        public override void Post(DeviceAction action)
        {
            Context.DeviceActions.Add(action);
            Context.SaveChanges();
        }

        public override void Put(long id, [FromBody]DeviceAction action)
        {
            Context.DeviceActions.Update(action);
            Context.SaveChanges();
        }
    }
}
