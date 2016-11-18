using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace CameraServer.Repositories
{
    /// <summary>
    /// Интерфейс репозитория
    /// </summary>
    /// <typeparam name="T">Модель</typeparam>
    public interface IRepository<T>
    {
        #region Methods

        T Get(long id);
        List<T> GetAll();
        void Delete(long id);
        void Post(T data);
        void Put(long id, [FromBody] T data);

        #endregion Methods
    }
}
