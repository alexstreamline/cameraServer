using System.Collections.Generic;
using System.Linq;
using CameraServer.Models;
using CameraServer.Models.Devices;
using Microsoft.Extensions.Logging;

namespace CameraServer.Repositories
{
    public class DeviceSensorSettingsRepository : IRepository<DeviceSensorSettings>
    {
        #region Fields & Properties

        protected readonly MainContext Context;
        protected readonly ILogger Logger;

        #endregion Fields & Properties

        #region ctors

        public DeviceSensorSettingsRepository(MainContext context, ILoggerFactory loggerFactory)
        {
            Context = context;
            Logger = loggerFactory.CreateLogger(nameof(DeviceSensorSettingsRepository));
        }

        #endregion ctors

        #region Methods

        public DeviceSensorSettings Get(long id)
        {
            return Context.DeviceSensorSettings.FirstOrDefault(t => t.Id == id);
        }

        public List<DeviceSensorSettings> GetAll()
        {
            Logger.LogCritical($"Получение всех '{nameof(DeviceSensorSettings)}'");
            return Context.DeviceSensorSettings.ToList();
        }

        public void Delete(long id)
        {
            var entity = Context.DeviceSensorSettings.FirstOrDefault(t => t.Id == id);
            Context.DeviceSensorSettings.Remove(entity);
            Context.SaveChanges();
        }
            
        public void Post(DeviceSensorSettings entity)
        {
            Context.DeviceSensorSettings.Add(entity);
            Context.SaveChanges();
        }

        public void Put(long id, DeviceSensorSettings entity)
        {
            Context.DeviceSensorSettings.Update(entity);
            Context.SaveChanges();
        }

        #endregion Methods
    }
}