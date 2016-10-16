using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CameraServer.Repositories
{
    using Models;

    /// <summary>
    /// Абстрактный репозиторий
    /// </summary>
    /// <typeparam name="T">Модель</typeparam>
    public abstract class Repository<T>
    {
        #region Fields & Properties

        protected readonly MainContext Context;
        protected readonly ILogger Logger;

        #endregion Fields & Properties

        protected Repository(MainContext context, ILoggerFactory loggerFactory)
        {
            Context = context;
            Logger = loggerFactory.CreateLogger(nameof(T));
        }

        #region Methods

        public abstract T Get(long id);
        public abstract List<T> GetAll();
        public abstract void Delete(long id);
        public abstract void Post(T data);
        public abstract void Put(long id, [FromBody] T data);

        #endregion Methods
    }
}
