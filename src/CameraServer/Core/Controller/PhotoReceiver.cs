using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CameraServer.Core.Controller
{
    public class PhotoReceiver
    {
        public async void ReceivePhotoFromDevice(string fileName, byte[] photoData)
        {
            FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite);
            var photoFile = await fileStream.WriteAsync(photoData, 0, photoData.Lenght).Result;  
        }
    }
}
