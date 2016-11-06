using System;

namespace CameraServer.Core.Controller
{
    public class DateSinchronizationMessageBuilder
    {
        public byte[] GetDateNow()
        {
            byte[] dateMessage = new byte[9];
            var dateNow = DateTime.Now;
            dateMessage[0] = 0xAE;
            dateMessage[1] = (byte)dateNow.Day;
            dateMessage[2] = (byte)dateNow.Month;
            dateMessage[3] = (byte)dateNow.Year;  //todo год - разделить на два байта
            dateMessage[5] = (byte)dateNow.DayOfWeek;
            dateMessage[6] = (byte)dateNow.Hour;
            dateMessage[7] = (byte)dateNow.Minute;
            dateMessage[8] = 0xAE;
            return dateMessage;
        }
    }
}
