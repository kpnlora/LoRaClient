using Microsoft.EntityFrameworkCore.Migrations;


namespace Betabit.Lora.Nuget.Example.Migrations
{
    public partial class ExtendedDeviceWithLoRaProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Device_Room_RoomID", table: "Devices");
            migrationBuilder.AddColumn<string>(
                name: "DeviceAddress",
                table: "Devices",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "NetworkAddress",
                table: "Devices",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "NetworkKey",
                table: "Devices",
                nullable: true);
            migrationBuilder.AddForeignKey(
                name: "FK_Device_Room_RoomId",
                table: "Devices",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Rooms",
                newName: "Id");
            migrationBuilder.RenameColumn(
                name: "RoomID",
                table: "Devices",
                newName: "RoomId");
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Devices",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Device_Room_RoomId", table: "Devices");
            migrationBuilder.DropColumn(name: "DeviceAddress", table: "Devices");
            migrationBuilder.DropColumn(name: "NetworkAddress", table: "Devices");
            migrationBuilder.DropColumn(name: "NetworkKey", table: "Devices");
            migrationBuilder.AddForeignKey(
                name: "FK_Device_Room_RoomID",
                table: "Devices",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Rooms",
                newName: "ID");
            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Devices",
                newName: "RoomID");
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Devices",
                newName: "ID");
        }
    }
}
