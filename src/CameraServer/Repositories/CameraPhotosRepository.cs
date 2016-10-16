using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CameraServer.Repositories
{
    using Models;

    /// <summary>
    /// Репозиторий CameraPhotos
    /// </summary>
    public class CameraPhotosRepository : Repository<CameraPhoto>
    {
        public CameraPhotosRepository(MainContext context, ILoggerFactory loggerFactory)
            :base(context, loggerFactory)
        {

        }

        #region Methods

        public override CameraPhoto Get(long id)
        {
            return Context.CameraPhotos.First(t => t.Id == id);
        }

        public override List<CameraPhoto> GetAll()
        {
            Logger.LogCritical("Получение всех 'CameraPhotos'");
            return Context.CameraPhotos.ToList();
        }

        public override void Delete(long id)
        {
            var entity = Context.CameraPhotos.First(t => t.Id == id);
            Context.CameraPhotos.Remove(entity);
            Context.SaveChanges();
        }

        public override void Post(CameraPhoto photo)
        {
            Context.CameraPhotos.Add(photo);
            Context.SaveChanges();
        }

        public override void Put(long id, [FromBody]CameraPhoto photo)
        {
            Context.CameraPhotos.Update(photo);
            Context.SaveChanges();
        }

        #endregion Methods
    }
}
