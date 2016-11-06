using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace CameraServer.Core.Controller
{
    public class DeviceConnectionController
    {
        private TcpListener _serverListner;
        public void StartServer()
        {
           _serverListner.Start(); 
        }


        void AcceptClients()
        {
            while (true)
            {
                try
                {

                    var newConnection = _serverListner.AcceptTcpClient();
                    var endPoint = (IPEndPoint)newConnection.Client.RemoteEndPoint;
                    
                        
                        Thread readThread = new Thread(ReceiveRun);
                        // readThread.Start(_countClient);
                        readThread.Start(endPoint.Port);
                        ClientsPortEnum enumDisplayStatus = (ClientsPortEnum)endPoint.Port;
                        // string stringValue = enumDisplayStatus.ToString();
                        LogString += "Подключился  " + enumDisplayStatus + "  c порта №  " + endPoint.Port + "\n";
                        // _countClient++;
                        SendConfigToClient(endPoint.Port);

                        // Данный метод, хотя и вызывается в отдельном потоке (не в главном),
                        // но находит родительский поток и выполняет делегат указанный в качестве параметра 
                        // в главном потоке, безопасно обновляя интерфейс формы.
                        //Invoke(new UpdateClientsDisplayDelegate(UpdateClientsDisplay));
                    

                }
                catch (Exception ex)
                {

                   // LogString += "Ошибка при приеме нового подключения - " + ex.Message + "\n";
                }


                if (_stopFlag)
                {
                    break;
                }

            }
        }

        void ReceiveRun(object port)
        {
            bool _localstopFlag = false;
            while (!_localstopFlag)
            {
                try
                {
                    string s = null;
                    // NetworkStream ns = clients[(int)num].GetStream();
                    NetworkStream ns = clientDictionary[(int)port].GetStream();
                    while (ns.DataAvailable)
                    {
                        // Определить точный размер буфера приема позволяет свойство класса TcpClient - Available
                        byte[] buffer = new byte[clientDictionary[(int)port].Available];
                        ns.Read(buffer, 0, buffer.Length);
                        s += Encoding.Default.GetString(buffer);
                    }

                    if (s != null)
                    {
                        // Данный метод, хотя и вызывается в отдельном потоке (не в главном),
                        // но находит родительский поток и выполняет делегат указанный в качестве параметра 
                        // в главном потоке, безопасно обновляя интерфейс формы.
                        Console.WriteLine("Text - " + s);
                        // Invoke(new UpdateReceiveDisplayDelegate(UpdateReceiveDisplay), new object[] { (int)num, s });
                       // LogString += s + "\n";
                        // Принятое сообщение от клиента перенаправляем всем клиентам
                        // кроме текущего.
                        // s = "№" + ((int)num).ToString() + ": " + s; todo нумерация и подсчет присланных-пересланных сообщений
                        
                        s = String.Empty;
                    }

                    // Вынужденная строчка для экономия ресурсов процессора.
                    // Неизящный способ.
                    Thread.Sleep(200);
                }
                catch (Exception ex)
                {
                    LogString += "Ошибка (отправление) - " + ex.Message + "\n";
                    _localstopFlag = true;
                    // Перехватим возможные исключения
                    //ErrorSound();
                }


                if (_localstopFlag == true) break;

            }
        }


    }
}
