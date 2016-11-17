using System;
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
    public class DeviceActionsRepository : IRepository<DeviceAction>
    {
        #region Fields & Properties

        protected readonly MainContext Context;
        protected readonly ILogger Logger;

        #endregion Fields & Properties

        public DeviceActionsRepository(MainContext context, ILoggerFactory loggerFactory) 
            //: base(context, loggerFactory)
        {
            Context = context;
            Logger = loggerFactory.CreateLogger(nameof(DeviceActionsRepository));
        }

        public DeviceAction Get(long id)
        {
            return Context.DeviceActions.FirstOrDefault(t => t.Id == id);
        }

        public List<DeviceAction> GetAll()
        {
            Logger.LogCritical("Получение всех 'DeviceActions'");
            return Context.DeviceActions.ToList();
        }

        public List<DeviceAction> GetAllByDay(DayOfWeek dayOfWeek)
        {
            Logger.LogCritical($"Получение всех 'DeviceActions' по дню {dayOfWeek}");
            return Context.DeviceActions.Where(da => da.ActionDayOfWeek == dayOfWeek).ToList();
        }

        public void Delete(long id)
        {
            var entity = Context.DeviceActions.FirstOrDefault(t => t.Id == id);
            if(entity == null)
                return;
            Context.DeviceActions.Remove(entity);
            Context.SaveChanges();
        }

        public void Post(DeviceAction action)
        {
            Context.DeviceActions.Add(action);
            Context.SaveChanges();
        }

        public void Put(long id, [FromBody]DeviceAction action)
        {
            Context.DeviceActions.Update(action);
            Context.SaveChanges();
        }
    }
}
