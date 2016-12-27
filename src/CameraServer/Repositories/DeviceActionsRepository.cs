using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CameraServer.Repositories
{
    using Models;
    using Models.Devices;
    using CameraServer.Enums;

    /// <summary>
    /// Репозиторий DeviceActions
    /// </summary>
    public class DeviceActionsRepository : IRepository<DeviceAction>
    {
        #region Fields & Properties

        protected readonly MainContext Context;
        protected readonly ILogger Logger;

        #endregion Fields & Properties

        #region ctors

        public DeviceActionsRepository(MainContext context, ILoggerFactory loggerFactory) 
        {
            Context = context;
            Logger = loggerFactory.CreateLogger(nameof(DeviceActionsRepository));
        }

        #endregion ctors

        #region Methods

        public DeviceAction Get(long id)
        {
            return Context.DeviceActions.FirstOrDefault(t => t.Id == id);
        }

        public List<DeviceAction> GetAll()
        {
            Logger.LogCritical($"Получение всех '{nameof(DeviceAction)}'");
            return Context.DeviceActions.ToList();
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

        public List<DeviceAction> GetAllByDay(DayOfWeekCustom dayOfWeek)
        {
            Logger.LogCritical($"Получение всех '{nameof(DeviceAction)}' по дню {dayOfWeek}");
            return Context.DeviceActions.Where(da => da.ActionDayOfWeek == dayOfWeek).ToList();
        }

        #endregion Methods
    }
}
