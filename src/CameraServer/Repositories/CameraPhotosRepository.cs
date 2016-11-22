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
    public class CameraPhotosRepository : IRepository<CameraPhoto>
    {
        #region Fields & Properties

        protected readonly MainContext Context;
        protected readonly ILogger Logger;

        #endregion Fields & Properties

        #region ctors

        public CameraPhotosRepository(MainContext context, ILoggerFactory loggerFactory)
        {
            Context = context;
            Logger = loggerFactory.CreateLogger(nameof(CameraPhotosRepository));
        }

        #endregion ctors

        #region Methods

        public CameraPhoto Get(long id)
        {
            return Context.CameraPhotos.First(t => t.Id == id);
        }

        public List<CameraPhoto> GetAll()
        {
            Logger.LogCritical($"Получение всех '{nameof(CameraPhoto)}'");
            return Context.CameraPhotos.ToList();
        }

        public void Delete(long id)
        {
            var entity = Context.CameraPhotos.First(t => t.Id == id);
            Context.CameraPhotos.Remove(entity);
            Context.SaveChanges();
        }

        public void Post(CameraPhoto photo)
        {
            Context.CameraPhotos.Add(photo);
            Context.SaveChanges();
        }

        public void Put(long id, [FromBody]CameraPhoto photo)
        {
            Context.CameraPhotos.Update(photo);
            Context.SaveChanges();
        }

        #endregion Methods
    }
}
