using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CameraServer.Models;

namespace CameraServer.Migrations
{
    [DbContext(typeof(MainContext))]
    [Migration("20161118152953_NewMainContextMigration")]
    partial class NewMainContextMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("CameraServer.Models.CameraPhoto", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CameraNumber");

                    b.Property<string>("FsLocation");

                    b.Property<string>("Name");

                    b.Property<DateTime>("TimeStamp");

                    b.HasKey("Id");

                    b.ToTable("CameraPhotos");
                });

            modelBuilder.Entity("CameraServer.Models.Devices.DeviceAction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ActionDayOfWeek");

                    b.Property<DateTime>("ActionTime");

                    b.Property<bool>("IsAccelerometerDataNeed");

                    b.Property<bool>("IsBarometerDataNeed");

                    b.Property<bool>("IsCamera1PhotoNeed");

                    b.Property<bool>("IsCamera2PhotoNeed");

                    b.Property<bool>("IsCamera3PhotoNeed");

                    b.Property<bool>("IsCamera4PhotoNeed");

                    b.Property<bool>("IsCompassDataNeed");

                    b.Property<bool>("IsGPSGLONASSDataNeed");

                    b.Property<bool>("IsGyroscopeDataNeed");

                    b.Property<bool>("IsMotionSensor1DataNeed");

                    b.Property<bool>("IsMotionSensor2DataNeed");

                    b.Property<bool>("IsMotionSensor3DataNeed");

                    b.Property<bool>("IsMotionSensor4DataNeed");

                    b.Property<bool>("IsPhotoNeedToServer");

                    b.Property<bool>("IsSensorDataNeed");

                    b.Property<bool>("IsThermometerDataNeed");

                    b.Property<bool>("IsWetSensorDataNeed");

                    b.HasKey("Id");

                    b.ToTable("DeviceActions");
                });

            modelBuilder.Entity("CameraServer.Models.Devices.TriggerDeviceAction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ActionDayOfWeek");

                    b.Property<bool>("IsAccelerometerDataNeed");

                    b.Property<bool>("IsBarometerDataNeed");

                    b.Property<bool>("IsCamera1PhotoNeed");

                    b.Property<bool>("IsCamera2PhotoNeed");

                    b.Property<bool>("IsCamera3PhotoNeed");

                    b.Property<bool>("IsCamera4PhotoNeed");

                    b.Property<bool>("IsCompassDataNeed");

                    b.Property<bool>("IsGPSGLONASSDataNeed");

                    b.Property<bool>("IsGyroscopeDataNeed");

                    b.Property<bool>("IsMotionSensor1DataNeed");

                    b.Property<bool>("IsMotionSensor2DataNeed");

                    b.Property<bool>("IsMotionSensor3DataNeed");

                    b.Property<bool>("IsMotionSensor4DataNeed");

                    b.Property<bool>("IsPhotoNeedToServer");

                    b.Property<bool>("IsSensorDataNeed");

                    b.Property<bool>("IsThermometerDataNeed");

                    b.Property<bool>("IsWetSensorDataNeed");

                    b.Property<string>("SensorName");

                    b.HasKey("Id");

                    b.ToTable("TriggerDeviceActions");
                });

            modelBuilder.Entity("CameraServer.Models.HardwareTrasmittableData.PhotoTransmit", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("PhotoTransmits");
                });

            modelBuilder.Entity("CameraServer.Models.Sensors.BaseSensor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("SensorInterrogationTime");

                    b.Property<int>("SensorTimeForGetReady");

                    b.Property<double>("SensorTriggeredValueLimit");

                    b.HasKey("Id");

                    b.ToTable("BaseSensors");
                });
        }
    }
}
