using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CameraServer.Repositories
{
    using Models;
    using Models.Sensors;

    /// <summary>
    /// Репозиторий BaseSensors
    /// </summary>
    public class BaseSensorRepository : IRepository<BaseSensor>
    {
        #region Fields & Properties

        protected readonly MainContext Context;
        protected readonly ILogger Logger;

        #endregion Fields & Properties

        public BaseSensorRepository(MainContext context, ILoggerFactory loggerFactory)
            //: base(context, loggerFactory)
        {
            Context = context;
            Logger = loggerFactory.CreateLogger(nameof(BaseSensorRepository));
        }

        #region Methods

        public BaseSensor Get(long id)
        {
            return Context.BaseSensors.First(t => t.Id == id);
        }

        public List<BaseSensor> GetAll()
        {
            Logger.LogCritical("Получение всех 'BaseSensors'");
            return Context.BaseSensors.ToList();
        }

        public void Delete(long id)
        {
            var entity = Context.BaseSensors.First(t => t.Id == id);
            Context.BaseSensors.Remove(entity);
            Context.SaveChanges();
        }

        public void Post(BaseSensor sensor)
        {
            Context.BaseSensors.Add(sensor);
            Context.SaveChanges();
        }

        public void Put(long id, [FromBody]BaseSensor sensor)
        {
            Context.BaseSensors.Update(sensor);
            Context.SaveChanges();
        }

        #endregion Methods
    }
}
