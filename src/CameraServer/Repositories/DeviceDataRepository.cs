using System.Collections.Generic;
using System.Linq;
using CameraServer.Models;
using CameraServer.Models.Devices;
using Microsoft.Extensions.Logging;

namespace CameraServer.Repositories
{
    public class DeviceDataRepository : IRepository<DeviceData>
    {
        #region Fields & Properties

        protected readonly MainContext Context;
        protected readonly ILogger Logger;

        #endregion Fields & Properties

        #region ctors

        public DeviceDataRepository(MainContext context, ILoggerFactory loggerFactory)
        {
            Context = context;
            Logger = loggerFactory.CreateLogger(nameof(DeviceDataRepository));
        }

        #endregion ctors

        #region Methods

        public DeviceData Get(long id)
        {
            return Context.DeviceData.FirstOrDefault(t => t.Id == id);
        }

        public List<DeviceData> GetAll()
        {
            Logger.LogCritical($"Получение всех '{nameof(DeviceData)}'");
            return Context.DeviceData.ToList();
        }

        public void Delete(long id)
        {
            var entity = Context.DeviceData.FirstOrDefault(t => t.Id == id);
            Context.DeviceData.Remove(entity);
            Context.SaveChanges();
        }

        public void Post(DeviceData entity)
        {
            Context.DeviceData.Add(entity);
            Context.SaveChanges();
        }

        public void Put(long id, DeviceData entity)
        {
            Context.DeviceData.Update(entity);
            Context.SaveChanges();
        }

        #endregion Methods
    }
}
