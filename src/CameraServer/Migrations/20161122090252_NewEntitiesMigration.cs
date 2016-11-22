using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CameraServer.Migrations
{
    public partial class NewEntitiesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    AccelerometerWorkMode = table.Column<int>(nullable: false),
                    BarometerLimitValue = table.Column<float>(nullable: false),
                    BarometerWorkMode = table.Column<int>(nullable: false),
                    CompasLimitValue = table.Column<float>(nullable: false),
                    CompasWorkMode = table.Column<int>(nullable: false),
                    GPSGLONASSLimitValue = table.Column<float>(nullable: false),
                    GPSGLONASSWorkMode = table.Column<int>(nullable: false),
                    GyroscopeLimitValue = table.Column<float>(nullable: false),
                    GyroscopeWorkMode = table.Column<int>(nullable: false),
                    ThermometerLimitValue = table.Column<float>(nullable: false),
                    ThermometerWorkMode = table.Column<int>(nullable: false),
                    WetSensorLimitValue = table.Column<float>(nullable: false),
                    WetSensorWorkMode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceSensorSettings", x => x.Id);
                });

            migrationBuilder.AddColumn<bool>(
                name: "IsVibrationSensorDataNeed",
                table: "TriggerDeviceActions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVibrationSensorDataNeed",
                table: "DeviceActions",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsVibrationSensorDataNeed",
                table: "TriggerDeviceActions");

            migrationBuilder.DropColumn(
                name: "IsVibrationSensorDataNeed",
                table: "DeviceActions");

            migrationBuilder.DropTable(
                name: "DeviceData");

            migrationBuilder.DropTable(
                name: "DeviceSensorSettings");
        }
    }
}
