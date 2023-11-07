using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReminderApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RandomMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 6, 22, 34, 9, 720, DateTimeKind.Local).AddTicks(1141),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 5, 19, 35, 37, 92, DateTimeKind.Local).AddTicks(936));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Notifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 6, 22, 34, 9, 720, DateTimeKind.Local).AddTicks(1141),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 5, 19, 35, 37, 92, DateTimeKind.Local).AddTicks(936));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Meetings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 6, 22, 34, 9, 720, DateTimeKind.Local).AddTicks(1141),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 5, 19, 35, 37, 92, DateTimeKind.Local).AddTicks(936));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "MeetingItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 6, 22, 34, 9, 720, DateTimeKind.Local).AddTicks(1141),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 5, 19, 35, 37, 92, DateTimeKind.Local).AddTicks(936));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "HubConnections",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 6, 22, 34, 9, 720, DateTimeKind.Local).AddTicks(1141),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 5, 19, 35, 37, 92, DateTimeKind.Local).AddTicks(936));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 5, 19, 35, 37, 92, DateTimeKind.Local).AddTicks(936),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 6, 22, 34, 9, 720, DateTimeKind.Local).AddTicks(1141));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Notifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 5, 19, 35, 37, 92, DateTimeKind.Local).AddTicks(936),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 6, 22, 34, 9, 720, DateTimeKind.Local).AddTicks(1141));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Meetings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 5, 19, 35, 37, 92, DateTimeKind.Local).AddTicks(936),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 6, 22, 34, 9, 720, DateTimeKind.Local).AddTicks(1141));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "MeetingItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 5, 19, 35, 37, 92, DateTimeKind.Local).AddTicks(936),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 6, 22, 34, 9, 720, DateTimeKind.Local).AddTicks(1141));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "HubConnections",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 5, 19, 35, 37, 92, DateTimeKind.Local).AddTicks(936),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 6, 22, 34, 9, 720, DateTimeKind.Local).AddTicks(1141));
        }
    }
}
