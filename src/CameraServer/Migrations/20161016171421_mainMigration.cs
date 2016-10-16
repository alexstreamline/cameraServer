using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CameraServer.Migrations
{
    public partial class mainMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CameraPhotos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Autoincrement", true),
                    FsLocation = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    TimeStamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CameraPhotos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
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
                    IsSensorDataNeed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceActions", x => x.Id);
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
                name: "Devices");

            migrationBuilder.DropTable(
                name: "DeviceActions");

            migrationBuilder.DropTable(
                name: "PhotoTransmits");

            migrationBuilder.DropTable(
                name: "BaseSensors");
        }
    }
}
