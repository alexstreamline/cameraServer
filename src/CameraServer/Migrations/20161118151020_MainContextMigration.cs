using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CameraServer.Migrations
{
    public partial class MainContextMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.AddColumn<bool>(
                name: "IsAccelerometerDataNeed",
                table: "DeviceActions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsBarometerDataNeed",
                table: "DeviceActions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCompassDataNeed",
                table: "DeviceActions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsGPSGLONASSDataNeed",
                table: "DeviceActions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsGyroscopeDataNeed",
                table: "DeviceActions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsMotionSensor1DataNeed",
                table: "DeviceActions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsMotionSensor2DataNeed",
                table: "DeviceActions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsMotionSensor3DataNeed",
                table: "DeviceActions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsMotionSensor4DataNeed",
                table: "DeviceActions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPhotoNeedToServer",
                table: "DeviceActions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsThermometerDataNeed",
                table: "DeviceActions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsWetSensorDataNeed",
                table: "DeviceActions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CameraNumber",
                table: "CameraPhotos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAccelerometerDataNeed",
                table: "DeviceActions");

            migrationBuilder.DropColumn(
                name: "IsBarometerDataNeed",
                table: "DeviceActions");

            migrationBuilder.DropColumn(
                name: "IsCompassDataNeed",
                table: "DeviceActions");

            migrationBuilder.DropColumn(
                name: "IsGPSGLONASSDataNeed",
                table: "DeviceActions");

            migrationBuilder.DropColumn(
                name: "IsGyroscopeDataNeed",
                table: "DeviceActions");

            migrationBuilder.DropColumn(
                name: "IsMotionSensor1DataNeed",
                table: "DeviceActions");

            migrationBuilder.DropColumn(
                name: "IsMotionSensor2DataNeed",
                table: "DeviceActions");

            migrationBuilder.DropColumn(
                name: "IsMotionSensor3DataNeed",
                table: "DeviceActions");

            migrationBuilder.DropColumn(
                name: "IsMotionSensor4DataNeed",
                table: "DeviceActions");

            migrationBuilder.DropColumn(
                name: "IsPhotoNeedToServer",
                table: "DeviceActions");

            migrationBuilder.DropColumn(
                name: "IsThermometerDataNeed",
                table: "DeviceActions");

            migrationBuilder.DropColumn(
                name: "IsWetSensorDataNeed",
                table: "DeviceActions");

            migrationBuilder.DropColumn(
                name: "CameraNumber",
                table: "CameraPhotos");

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
        }
    }
}
