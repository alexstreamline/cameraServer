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
    public class BaseSensorRepository : Repository<BaseSensor>
    {
        public BaseSensorRepository(MainContext context, ILoggerFactory loggerFactory)
            : base(context, loggerFactory)
        {
            
        }

        #region Methods

        public override BaseSensor Get(long id)
        {
            return Context.BaseSensors.First(t => t.Id == id);
        }

        public override List<BaseSensor> GetAll()
        {
            Logger.LogCritical("Получение всех 'BaseSensors'");
            return Context.BaseSensors.ToList();
        }

        public override void Delete(long id)
        {
            var entity = Context.BaseSensors.First(t => t.Id == id);
            Context.BaseSensors.Remove(entity);
            Context.SaveChanges();
        }

        public override void Post(BaseSensor sensor)
        {
            Context.BaseSensors.Add(sensor);
            Context.SaveChanges();
        }

        public override void Put(long id, [FromBody]BaseSensor sensor)
        {
            Context.BaseSensors.Update(sensor);
            Context.SaveChanges();
        }

        #endregion Methods
    }
}
