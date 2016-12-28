using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using CameraServer.Enums;

namespace CameraServer.Migrations
{
    public partial class mainContext_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TriggerName",
                table: "DeviceData",
                nullable: false,
                defaultValue: DeviceTriggerName.Motion1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TriggerName",
                table: "DeviceData");
        }
    }
}
