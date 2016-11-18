using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CameraServer.Migrations
{
    public partial class NewMainContextMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TriggerDeviceActions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Autoincrement", true),
                    ActionDayOfWeek = table.Column<int>(nullable: false),
                    IsAccelerometerDataNeed = table.Column<bool>(nullable: false),
                    IsBarometerDataNeed = table.Column<bool>(nullable: false),
                    IsCamera1PhotoNeed = table.Column<bool>(nullable: false),
                    IsCamera2PhotoNeed = table.Column<bool>(nullable: false),
                    IsCamera3PhotoNeed = table.Column<bool>(nullable: false),
                    IsCamera4PhotoNeed = table.Column<bool>(nullable: false),
                    IsCompassDataNeed = table.Column<bool>(nullable: false),
                    IsGPSGLONASSDataNeed = table.Column<bool>(nullable: false),
                    IsGyroscopeDataNeed = table.Column<bool>(nullable: false),
                    IsMotionSensor1DataNeed = table.Column<bool>(nullable: false),
                    IsMotionSensor2DataNeed = table.Column<bool>(nullable: false),
                    IsMotionSensor3DataNeed = table.Column<bool>(nullable: false),
                    IsMotionSensor4DataNeed = table.Column<bool>(nullable: false),
                    IsPhotoNeedToServer = table.Column<bool>(nullable: false),
                    IsSensorDataNeed = table.Column<bool>(nullable: false),
                    IsThermometerDataNeed = table.Column<bool>(nullable: false),
                    IsWetSensorDataNeed = table.Column<bool>(nullable: false),
                    SensorName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TriggerDeviceActions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TriggerDeviceActions");
        }
    }
}
