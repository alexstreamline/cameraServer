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
        private int localport = 52000;
        IPAddress localIpAddress = IPAddress.Parse("193.124.113.169"); 
        public void StartServer()
        {
            _serverListner = new TcpListener(localIpAddress,localport );
           _serverListner.Start();
            Thread acceptThread = new Thread(AcceptClients);
            acceptThread.Start();
        }


        void AcceptClients()
        {
            while (true)
            {
                try
                {

                    var newConnection = _serverListner.AcceptTcpClientAsync().Result;
                    
                        Thread readThread = new Thread(ReceiveRun);
                        // readThread.Start(_countClient);
                        readThread.Start(newConnection);
                        
                       

                }
                catch (Exception ex)
                {

                   // LogString += "Ошибка при приеме нового подключения - " + ex.Message + "\n";
                }

            }
        }

        void ReceiveRun(object connect)
        {
            bool _localstopFlag = false;
            while (!_localstopFlag)
            {
                try
                {
                    string s = null;
                    var connection = (TcpClient) connect;
                    // NetworkStream ns = clients[(int)num].GetStream();
                    NetworkStream ns = connection.GetStream();
                    while (ns.DataAvailable)
                    {
                        // Определить точный размер буфера приема позволяет свойство класса TcpClient - Available
                        byte[] buffer = new byte[connection.Available];
                        ns.Read(buffer, 0, buffer.Length);
                        s += Encoding.Unicode.GetString(buffer);
                        
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
                   // LogString += "Ошибка (отправление) - " + ex.Message + "\n";
                    _localstopFlag = true;
                    // Перехватим возможные исключения
                    //ErrorSound();
                }


                if (_localstopFlag == true) break;

            }
        }

        public void PacketAnalyzer(byte[] packet)
        {
            
        }


    }
}
