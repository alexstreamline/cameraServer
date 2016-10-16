using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CameraServer.Models;

namespace CameraServer.Migrations
{
    [DbContext(typeof(MainContext))]
    partial class MainContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("CameraServer.Models.CameraPhoto", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FsLocation");

                    b.Property<string>("Name");

                    b.Property<DateTime>("TimeStamp");

                    b.HasKey("Id");

                    b.ToTable("CameraPhotos");
                });

            modelBuilder.Entity("CameraServer.Models.Devices.Device", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("CameraServer.Models.Devices.DeviceAction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ActionDayOfWeek");

                    b.Property<DateTime>("ActionTime");

                    b.Property<bool>("IsCamera1PhotoNeed");

                    b.Property<bool>("IsCamera2PhotoNeed");

                    b.Property<bool>("IsCamera3PhotoNeed");

                    b.Property<bool>("IsCamera4PhotoNeed");

                    b.Property<bool>("IsSensorDataNeed");

                    b.HasKey("Id");

                    b.ToTable("DeviceActions");
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
