using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CameraServer.Migrations
{
    public partial class mainContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CameraPhotos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Autoincrement", true),
                    CameraNumber = table.Column<int>(nullable: false),
                    FsLocation = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    TimeStamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CameraPhotos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceActions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Autoincrement", true),
                    ActionDayOfWeek = table.Column<int>(nullable: false),
                    ActionTime = table.Column<DateTime>(nullable: false),
                    IsCamera1PhotoNeed = table.Column<bool>(nullable: false),
                    IsCamera2PhotoNeed = table.Column<bool>(nullable: false),
                    IsCamera3PhotoNeed = table.Column<bool>(nullable: false),
                    IsCamera4PhotoNeed = table.Column<bool>(nullable: false),
                    IsPhotoNeedToServer = table.Column<bool>(nullable: false),
                    IsSensorDataNeed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceActions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceData",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Autoincrement", true),
                    AccelerometerDataX = table.Column<float>(nullable: false),
                    AccelerometerDataY = table.Column<float>(nullable: false),
                    AccelerometerDataZ = table.Column<float>(nullable: false),
                    BarometerData = table.Column<float>(nullable: false),
                    CompassData = table.Column<float>(nullable: false),
                    GPSGLONASSDataLat = table.Column<float>(nullable: false),
                    GPSGLONASSDataLon = table.Column<float>(nullable: false),
                    GyroscopeDataX = table.Column<float>(nullable: false),
                    GyroscopeDataY = table.Column<float>(nullable: false),
                    GyroscopeDataZ = table.Column<float>(nullable: false),
                    ThermometerData = table.Column<float>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    VibrationSensorData = table.Column<float>(nullable: false),
                    WetSensorData = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceSensorSettings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Autoincrement", true),
                    AccelerometerLimitValue = table.Column<float>(nullable: false),
                    BarometerLimitValue = table.Column<float>(nullable: false),
                    CompasLimitValue = table.Column<float>(nullable: false),
                    EndTimeContinousMode = table.Column<DateTime>(nullable: false),
                    GPSGLONASSLimitValue = table.Column<float>(nullable: false),
                    GyroscopeLimitValue = table.Column<float>(nullable: false),
                    IsContinousModeEnable = table.Column<bool>(nullable: false),
                    MotionTimeLimit = table.Column<int>(nullable: false),
                    StartTimeContinousMode = table.Column<DateTime>(nullable: false),
                    ThermometerLimitValue = table.Column<float>(nullable: false),
                    WetSensorLimitValue = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceSensorSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TriggerDeviceActions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Autoincrement", true),
                    ActionDayOfWeek = table.Column<int>(nullable: false),
                    IsCamera1PhotoNeed = table.Column<bool>(nullable: false),
                    IsCamera2PhotoNeed = table.Column<bool>(nullable: false),
                    IsCamera3PhotoNeed = table.Column<bool>(nullable: false),
                    IsCamera4PhotoNeed = table.Column<bool>(nullable: false),
                    IsPhotoNeedToServer = table.Column<bool>(nullable: false),
                    IsSensorDataNeed = table.Column<bool>(nullable: false),
                    SensorName = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TriggerDeviceActions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhotoTransmits",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoTransmits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseSensors",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    SensorInterrogationTime = table.Column<int>(nullable: false),
                    SensorTimeForGetReady = table.Column<int>(nullable: false),
                    SensorTriggeredValueLimit = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseSensors", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CameraPhotos");

            migrationBuilder.DropTable(
                name: "DeviceActions");

            migrationBuilder.DropTable(
                name: "DeviceData");

            migrationBuilder.DropTable(
                name: "DeviceSensorSettings");

            migrationBuilder.DropTable(
                name: "TriggerDeviceActions");

            migrationBuilder.DropTable(
                name: "PhotoTransmits");

            migrationBuilder.DropTable(
                name: "BaseSensors");
        }
    }
}
