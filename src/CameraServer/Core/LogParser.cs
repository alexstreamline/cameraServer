using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using CameraServer.Models.Devices;
using CameraServer.Enums;
namespace CameraServer.Core
{
    public class LogParser
    {
            Dictionary<string, string> dateAndTrigger = new Dictionary<string, string>();
            public List<DeviceData> deviceDataFullList { get; private set; } = new List<DeviceData>();
            public void Parse(string path)
            {
                string strUsers = null;
            try
            {

                using (FileStream fUsers = new FileStream(path, FileMode.Open))
                {
                    using (StreamReader srUsers = new StreamReader(fUsers))
                    {
                        List<DeviceData> deviceDataList = new List<DeviceData>();
                        DeviceData devData = null;
                        while ((strUsers = srUsers.ReadLine()) != null)
                        {
                            Regex regex = new Regex(@"^(\d{2}):(\d{2}):(\d{2})--(\d{2})\.(\d{2})\.(\d{4})");
                            MatchCollection matches = regex.Matches(strUsers);

                            Regex triggerRegex = new Regex(@"Trigger:(\w*)");
                            MatchCollection triggerMatches = triggerRegex.Matches(strUsers);
                            string trigger = triggerMatches[0].Groups[1].Value;
                            string dateTime = matches[0].Groups[0].Value;

                            Regex sensorRegex = new Regex(@"Device:(\w+)");
                            MatchCollection sensorMatches = sensorRegex.Matches(strUsers);
                            string sensor = sensorMatches[0].Groups[1].Value;
                            if (dateAndTrigger.ContainsKey(dateTime) && dateAndTrigger[dateTime] == trigger)
                            {
                                // dateAndTrigger.Add(dateTime)
                                // string time = matches[0].Groups[1].Value;
                                // string date = matches[0].Groups[2].Value;
                                GetDeviceSensorName(sensor, strUsers, ref devData);
                            }
                            else
                            {
                                if (devData != null)
                                {
                                    deviceDataList.Add(devData);
                                }
                                devData = null;
                                if (sensor != "link")
                                {
                                    devData = new DeviceData();
                                    devData.Timestamp = new DateTime(Convert.ToInt32(matches[0].Groups[6].Value), Convert.ToInt32(matches[0].Groups[5].Value),
                                    Convert.ToInt32(matches[0].Groups[4].Value), Convert.ToInt32(matches[0].Groups[1].Value),
                                    Convert.ToInt32(matches[0].Groups[2].Value), Convert.ToInt32(matches[0].Groups[3].Value));
                                    devData.TriggerName = GetDeviceTriggerName(trigger);
                                    GetDeviceSensorName(sensor, strUsers, ref devData);
                                    dateAndTrigger.Add(dateTime, trigger);
                                }

                            }
                            //matches[0].

                            //strUsers - одна строка из лога

                            //if (!string.IsNullOrEmpty(strUsers.Trim()))
                            //{
                            //    string firstLineWord = strUsers.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0];
                            //    Console.WriteLine(firstLineWord);
                            //}
                        }
                        if (devData != null)
                        {
                            deviceDataList.Add(devData);
                        }
                        deviceDataFullList.AddRange(deviceDataList);
                    }
                }
            }
            catch (IOException e)
            {
                //Console.WriteLine("Не найден файл Users.txt");
                Console.WriteLine(e.ToString());

            }
            }

            public void ScanFile(string folderPath)
            {
                DirectoryInfo dir = new DirectoryInfo(folderPath);
                var filesList = dir.GetFiles();
                Regex regex = new Regex(@"DATA\d+\.LOG");
                foreach (var file in filesList)
                {
                    if (regex.IsMatch(file.Name))
                    {
                        Parse(file.FullName);
                    }
                }


            }

            public DeviceTriggerName GetDeviceTriggerName(string triggerName)
            {
                DeviceTriggerName devTrigName = DeviceTriggerName.Motion1;
                switch (triggerName)
                {
                    case "motion1":
                        devTrigName = DeviceTriggerName.Motion1;
                        break;
                    case "motion2":
                        devTrigName = DeviceTriggerName.Motion2;
                        break;
                    case "motion3":
                        devTrigName = DeviceTriggerName.Motion3;
                        break;
                    case "motion4":
                        devTrigName = DeviceTriggerName.Motion4;
                        break;
                    case "compass":
                        devTrigName = DeviceTriggerName.Compass;
                        break;
                    case "gyroscope":
                        devTrigName = DeviceTriggerName.Gyroscope;
                        break;
                    case "accelerometer":
                        devTrigName = DeviceTriggerName.Accelerometer;
                        break;
                    case "barometer":
                        devTrigName = DeviceTriggerName.Barometer;
                        break;
                    case "gps":
                        devTrigName = DeviceTriggerName.Gps;
                        break;
                    case "temperature":
                        devTrigName = DeviceTriggerName.Temperature;
                        break;
                    case "humidity":
                        devTrigName = DeviceTriggerName.Humidity;
                        break;
                    case "vibration":
                        devTrigName = DeviceTriggerName.Vibration;
                        break;
                    case "time":
                        devTrigName = DeviceTriggerName.Time;
                        break;
                }
                return devTrigName;
            }
            public void GetDeviceSensorName(string sensorName, string matchString, ref DeviceData devData)
            {
                try
                {
                    // DeviceTriggerName devTrigName = DeviceTriggerName.Motion1;
                    Regex regex = new Regex("");
                    MatchCollection matches;
                    string data = string.Empty;
                    switch (sensorName)
                    {
                        case "compass":
                            regex = new Regex(@"Data:([+-]{1}\d+\.\d+)\s{1}");
                            matches = regex.Matches(matchString);
                            data = matches[0].Groups[1].Value;
                            data = data.Replace('.', ',');
                            devData.CompassData = Convert.ToSingle(data);
                            break;
                        case "gyroscope":
                            regex = new Regex(@"Data:([+-]{1}\d+\.\d+)\s{1}grad/s\s{1}([+-]{1}\d+\.\d+)\s{1}grad/s\s{1}([+-]{1}\d+\.\d+)");
                            matches = regex.Matches(matchString);
                            string data1 = matches[0].Groups[1].Value;
                            data1 = data1.Replace('.', ',');
                            string data2 = matches[0].Groups[2].Value;
                            data2 = data2.Replace('.', ',');
                            string data3 = matches[0].Groups[3].Value;
                            data3 = data3.Replace('.', ',');
                            devData.GyroscopeDataX = Convert.ToSingle(data1);
                            devData.GyroscopeDataY = Convert.ToSingle(data2);
                            devData.GyroscopeDataZ = Convert.ToSingle(data3);
                            break;

                        case "accelerometer":
                            regex = new Regex(@"([+-]{1}\d+\.\d+)\s{1}"); //m/s^2\s{2}m/s^2\s{2}([+-]{1}\d+\.\d+)
                            matches = regex.Matches(matchString);
                            data1 = matches[0].Groups[1].Value;
                            data1 = data1.Replace('.', ',');
                            data2 = matches[1].Groups[1].Value;
                            data2 = data2.Replace('.', ',');
                            data3 = matches[2].Groups[1].Value;
                            data3 = data3.Replace('.', ',');
                            devData.AccelerometerDataX = Convert.ToSingle(data1);
                            devData.AccelerometerDataY = Convert.ToSingle(data2);
                            devData.AccelerometerDataZ = Convert.ToSingle(data3);
                            break;
                        case "barometer":
                            regex = new Regex(@"Data:([+-]{1}\d+\.\d+)\s{1}");
                            matches = regex.Matches(matchString);
                            data = matches[0].Groups[1].Value;
                            data = data.Replace('.', ',');
                            devData.BarometerData = Convert.ToSingle(data);
                            break;
                        case "gps":
                            regex = new Regex(@"Data:([+-]{1}\d+\.\d+)\s{1}grad\s{3}([+-]{1}\d+\.\d+)\s{1}");
                            matches = regex.Matches(matchString);
                            data1 = matches[0].Groups[1].Value;
                            data1 = data1.Replace('.', ',');
                            data2 = matches[0].Groups[2].Value;
                            data2 = data2.Replace('.', ',');

                            devData.GPSGLONASSDataLat = Convert.ToSingle(data1);
                            devData.GPSGLONASSDataLon = Convert.ToSingle(data2);

                            break;
                        case "temperature":
                            regex = new Regex(@"Data:([+-]{1}\d+\.\d+)\s{1}");
                            matches = regex.Matches(matchString);
                            data = matches[0].Groups[1].Value;
                            data = data.Replace('.', ',');
                            devData.ThermometerData = Convert.ToSingle(data);
                            break;
                        case "humidity":
                            regex = new Regex(@"Data:([+-]{1}\d+\.\d+)\s{1}");
                            matches = regex.Matches(matchString);
                            data = matches[0].Groups[1].Value;
                            data = data.Replace('.', ',');
                            devData.WetSensorData = Convert.ToSingle(data);
                            break;
                    }
                }
                catch (Exception ex)
                {

                }


            }
        }
    }



