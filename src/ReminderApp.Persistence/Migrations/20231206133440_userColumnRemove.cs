using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReminderApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class userColumnRemove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fullname",
                table: "Users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 6, 16, 34, 39, 596, DateTimeKind.Local).AddTicks(94),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 13, 0, 1, 3, 359, DateTimeKind.Local).AddTicks(1321));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Notifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 6, 16, 34, 39, 596, DateTimeKind.Local).AddTicks(94),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 13, 0, 1, 3, 359, DateTimeKind.Local).AddTicks(1321));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Meetings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 6, 16, 34, 39, 596, DateTimeKind.Local).AddTicks(94),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 13, 0, 1, 3, 359, DateTimeKind.Local).AddTicks(1321));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "MeetingItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 6, 16, 34, 39, 596, DateTimeKind.Local).AddTicks(94),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 13, 0, 1, 3, 359, DateTimeKind.Local).AddTicks(1321));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 6, 16, 34, 39, 596, DateTimeKind.Local).AddTicks(94),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 13, 0, 1, 3, 359, DateTimeKind.Local).AddTicks(1321));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "HubConnections",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 6, 16, 34, 39, 596, DateTimeKind.Local).AddTicks(94),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 13, 0, 1, 3, 359, DateTimeKind.Local).AddTicks(1321));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 6, 16, 34, 39, 596, DateTimeKind.Local).AddTicks(94),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 13, 0, 1, 3, 359, DateTimeKind.Local).AddTicks(1321));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 13, 0, 1, 3, 359, DateTimeKind.Local).AddTicks(1321),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 6, 16, 34, 39, 596, DateTimeKind.Local).AddTicks(94));

            migrationBuilder.AddColumn<string>(
                name: "Fullname",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Notifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 13, 0, 1, 3, 359, DateTimeKind.Local).AddTicks(1321),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 6, 16, 34, 39, 596, DateTimeKind.Local).AddTicks(94));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Meetings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 13, 0, 1, 3, 359, DateTimeKind.Local).AddTicks(1321),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 6, 16, 34, 39, 596, DateTimeKind.Local).AddTicks(94));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "MeetingItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 13, 0, 1, 3, 359, DateTimeKind.Local).AddTicks(1321),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 6, 16, 34, 39, 596, DateTimeKind.Local).AddTicks(94));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 13, 0, 1, 3, 359, DateTimeKind.Local).AddTicks(1321),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 6, 16, 34, 39, 596, DateTimeKind.Local).AddTicks(94));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "HubConnections",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 13, 0, 1, 3, 359, DateTimeKind.Local).AddTicks(1321),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 6, 16, 34, 39, 596, DateTimeKind.Local).AddTicks(94));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 13, 0, 1, 3, 359, DateTimeKind.Local).AddTicks(1321),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 6, 16, 34, 39, 596, DateTimeKind.Local).AddTicks(94));
        }
    }
}
