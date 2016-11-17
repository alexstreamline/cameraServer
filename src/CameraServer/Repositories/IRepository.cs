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
    public interface IRepository<T>
    {
        //#region Fields & Properties

        //protected readonly MainContext Context;
        //protected readonly ILogger Logger;

        //#endregion Fields & Properties

        //protected Repository(MainContext context, ILoggerFactory loggerFactory)
        //{
        //    Context = context;
        //    Logger = loggerFactory.CreateLogger(nameof(T));
        //}

        #region Methods

        T Get(long id);
        List<T> GetAll();
        void Delete(long id);
        void Post(T data);
        void Put(long id, [FromBody] T data);

        #endregion Methods
    }
}
