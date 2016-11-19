using System;
using System.Collections.Generic;
using System.Linq;
using CameraServer.Models;
using CameraServer.Models.Devices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CameraServer.Repositories
{
    public class TriggerDeviceActionRepository : IRepository<TriggerDeviceAction>
    {
        #region Fields & Properties

        protected readonly MainContext Context;
        protected readonly ILogger Logger;

        #endregion Fields & Properties

        #region ctors
        public TriggerDeviceActionRepository(MainContext context, ILoggerFactory loggerFactory)
        {
            Context = context;
            Logger = loggerFactory.CreateLogger(nameof(TriggerDeviceActionRepository));
        }

        #endregion ctors

        #region Methods

        public TriggerDeviceAction Get(long id)
        {
            return Context.TriggerDeviceActions.FirstOrDefault(t => t.Id == id);
        }

        public List<TriggerDeviceAction> GetAll()
        {
            Logger.LogCritical("Получение всех 'TriggerDeviceActions'");
            return Context.TriggerDeviceActions.ToList();
        }

        public void Delete(long id)
        {
            var entity = Context.TriggerDeviceActions.FirstOrDefault(t => t.Id == id);
            Context.TriggerDeviceActions.Remove(entity);
            Context.SaveChanges();
        }

        public void Post(TriggerDeviceAction entity)
        {
            Context.TriggerDeviceActions.Add(entity);
            Context.SaveChanges();
        }

        public void Put(long id, [FromBody]TriggerDeviceAction entity)
        {
            Context.TriggerDeviceActions.Update(entity);
            Context.SaveChanges();
        }

        public List<TriggerDeviceAction> GetAllByDay(DayOfWeek dayOfWeek)
        {
            Logger.LogCritical($"Получение всех 'TriggerDeviceActions' по дню {dayOfWeek}");
            return Context.TriggerDeviceActions.Where(tda => tda.ActionDayOfWeek == dayOfWeek).ToList();
        }

        #endregion Methods
    }
}