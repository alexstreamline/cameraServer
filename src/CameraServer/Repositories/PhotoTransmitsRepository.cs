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
    public class PhotoTransmitsRepository : Repository<PhotoTransmit>
    {
        public PhotoTransmitsRepository(MainContext context, ILoggerFactory loggerFactory) 
            : base(context, loggerFactory)
        {

        }

        public override PhotoTransmit Get(long id)
        {
            return Context.PhotoTransmits.First(t => t.Id == id);
        }

        public override List<PhotoTransmit> GetAll()
        {
            Logger.LogCritical("Получение всех 'PhotoTransmits'");
            return Context.PhotoTransmits.ToList();
        }

        public override void Delete(long id)
        {
            var entity = Context.PhotoTransmits.First(t => t.Id == id);
            Context.PhotoTransmits.Remove(entity);
            Context.SaveChanges();
        }

        public override void Post(PhotoTransmit transmit)
        {
            Context.PhotoTransmits.Add(transmit);
            Context.SaveChanges();
        }

        public override void Put(long id, [FromBody]PhotoTransmit transmit)
        {
            Context.PhotoTransmits.Update(transmit);
            Context.SaveChanges();
        }
    }
}
