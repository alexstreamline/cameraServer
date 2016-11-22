using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CameraServer.Repositories
{
    using Models;
    using Models.HardwareTrasmittableData;

    /// <summary>
    /// Репозиторий PhotoTransmits
    /// </summary>
    public class PhotoTransmitsRepository : IRepository<PhotoTransmit>
    {
        #region Fields & Properties

        protected readonly MainContext Context;
        protected readonly ILogger Logger;

        #endregion Fields & Properties

        #region ctors

        public PhotoTransmitsRepository(MainContext context, ILoggerFactory loggerFactory) 
        {
            Context = context;
            Logger = loggerFactory.CreateLogger(nameof(PhotoTransmitsRepository));
        }

        #endregion ctors

        public PhotoTransmit Get(long id)
        {
            return Context.PhotoTransmits.First(t => t.Id == id);
        }

        public List<PhotoTransmit> GetAll()
        {
            Logger.LogCritical($"Получение всех '{nameof(PhotoTransmit)}'");
            return Context.PhotoTransmits.ToList();
        }

        public void Delete(long id)
        {
            var entity = Context.PhotoTransmits.First(t => t.Id == id);
            Context.PhotoTransmits.Remove(entity);
            Context.SaveChanges();
        }

        public void Post(PhotoTransmit transmit)
        {
            Context.PhotoTransmits.Add(transmit);
            Context.SaveChanges();
        }

        public void Put(long id, [FromBody]PhotoTransmit transmit)
        {
            Context.PhotoTransmits.Update(transmit);
            Context.SaveChanges();
        }
    }
}
