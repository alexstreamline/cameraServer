using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CameraServer.Models.Sensors
{
    /// <summary>
    /// Перечисление для значений периодичности опроса датчиков. 
    /// Возможно, проще (и полезнее) будет заменить на просто значение в секундах
    /// но пока так
    /// </summary>
    public enum InterrogationTime
    {
       Auto = 0,

       CustomValue = 10
    }
}
