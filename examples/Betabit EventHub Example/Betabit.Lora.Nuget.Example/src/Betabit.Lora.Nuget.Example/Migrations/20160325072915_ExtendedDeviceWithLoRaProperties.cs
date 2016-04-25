using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace Betabit.Lora.Nuget.Example.Migrations
{
    public partial class ExtendedDeviceWithLoRaProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Device_Room_RoomID", table: "Device");
            migrationBuilder.AddColumn<string>(
                name: "DeviceAddress",
                table: "Device",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "NetworkAddress",
                table: "Device",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "NetworkKey",
                table: "Device",
                nullable: true);
            migrationBuilder.AddForeignKey(
                name: "FK_Device_Room_RoomId",
                table: "Device",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Room",
                newName: "Id");
            migrationBuilder.RenameColumn(
                name: "RoomID",
                table: "Device",
                newName: "RoomId");
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Device",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Device_Room_RoomId", table: "Device");
            migrationBuilder.DropColumn(name: "DeviceAddress", table: "Device");
            migrationBuilder.DropColumn(name: "NetworkAddress", table: "Device");
            migrationBuilder.DropColumn(name: "NetworkKey", table: "Device");
            migrationBuilder.AddForeignKey(
                name: "FK_Device_Room_RoomID",
                table: "Device",
                column: "RoomID",
                principalTable: "Room",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Room",
                newName: "ID");
            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Device",
                newName: "RoomID");
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Device",
                newName: "ID");
        }
    }
}
