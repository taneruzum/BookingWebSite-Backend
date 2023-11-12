using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReminderApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Mig4ImageEntityChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 12, 16, 46, 56, 501, DateTimeKind.Local).AddTicks(8747),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 12, 13, 30, 17, 175, DateTimeKind.Local).AddTicks(2539));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Notifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 12, 16, 46, 56, 501, DateTimeKind.Local).AddTicks(8747),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 12, 13, 30, 17, 175, DateTimeKind.Local).AddTicks(2539));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Meetings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 12, 16, 46, 56, 501, DateTimeKind.Local).AddTicks(8747),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 12, 13, 30, 17, 175, DateTimeKind.Local).AddTicks(2539));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "MeetingItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 12, 16, 46, 56, 501, DateTimeKind.Local).AddTicks(8747),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 12, 13, 30, 17, 175, DateTimeKind.Local).AddTicks(2539));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 12, 16, 46, 56, 501, DateTimeKind.Local).AddTicks(8747),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 12, 13, 30, 17, 175, DateTimeKind.Local).AddTicks(2539));

            migrationBuilder.AddColumn<int>(
                name: "ContentType",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FileType",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "HubConnections",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 12, 16, 46, 56, 501, DateTimeKind.Local).AddTicks(8747),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 12, 13, 30, 17, 175, DateTimeKind.Local).AddTicks(2539));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "FileType",
                table: "Images");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 12, 13, 30, 17, 175, DateTimeKind.Local).AddTicks(2539),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 12, 16, 46, 56, 501, DateTimeKind.Local).AddTicks(8747));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Notifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 12, 13, 30, 17, 175, DateTimeKind.Local).AddTicks(2539),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 12, 16, 46, 56, 501, DateTimeKind.Local).AddTicks(8747));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Meetings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 12, 13, 30, 17, 175, DateTimeKind.Local).AddTicks(2539),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 12, 16, 46, 56, 501, DateTimeKind.Local).AddTicks(8747));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "MeetingItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 12, 13, 30, 17, 175, DateTimeKind.Local).AddTicks(2539),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 12, 16, 46, 56, 501, DateTimeKind.Local).AddTicks(8747));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 12, 13, 30, 17, 175, DateTimeKind.Local).AddTicks(2539),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 12, 16, 46, 56, 501, DateTimeKind.Local).AddTicks(8747));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "HubConnections",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 12, 13, 30, 17, 175, DateTimeKind.Local).AddTicks(2539),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 12, 16, 46, 56, 501, DateTimeKind.Local).AddTicks(8747));
        }
    }
}
