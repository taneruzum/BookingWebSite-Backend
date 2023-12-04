using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReminderApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Mig5CommentAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 13, 0, 1, 3, 359, DateTimeKind.Local).AddTicks(1321),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 12, 16, 46, 56, 501, DateTimeKind.Local).AddTicks(8747));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Notifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 13, 0, 1, 3, 359, DateTimeKind.Local).AddTicks(1321),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 12, 16, 46, 56, 501, DateTimeKind.Local).AddTicks(8747));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Meetings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 13, 0, 1, 3, 359, DateTimeKind.Local).AddTicks(1321),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 12, 16, 46, 56, 501, DateTimeKind.Local).AddTicks(8747));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "MeetingItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 13, 0, 1, 3, 359, DateTimeKind.Local).AddTicks(1321),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 12, 16, 46, 56, 501, DateTimeKind.Local).AddTicks(8747));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 13, 0, 1, 3, 359, DateTimeKind.Local).AddTicks(1321),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 12, 16, 46, 56, 501, DateTimeKind.Local).AddTicks(8747));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "HubConnections",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 13, 0, 1, 3, 359, DateTimeKind.Local).AddTicks(1321),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 12, 16, 46, 56, 501, DateTimeKind.Local).AddTicks(8747));

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserComment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Star = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 11, 13, 0, 1, 3, 359, DateTimeKind.Local).AddTicks(1321))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 12, 16, 46, 56, 501, DateTimeKind.Local).AddTicks(8747),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 13, 0, 1, 3, 359, DateTimeKind.Local).AddTicks(1321));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Notifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 12, 16, 46, 56, 501, DateTimeKind.Local).AddTicks(8747),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 13, 0, 1, 3, 359, DateTimeKind.Local).AddTicks(1321));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Meetings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 12, 16, 46, 56, 501, DateTimeKind.Local).AddTicks(8747),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 13, 0, 1, 3, 359, DateTimeKind.Local).AddTicks(1321));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "MeetingItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 12, 16, 46, 56, 501, DateTimeKind.Local).AddTicks(8747),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 13, 0, 1, 3, 359, DateTimeKind.Local).AddTicks(1321));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 12, 16, 46, 56, 501, DateTimeKind.Local).AddTicks(8747),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 13, 0, 1, 3, 359, DateTimeKind.Local).AddTicks(1321));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "HubConnections",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 12, 16, 46, 56, 501, DateTimeKind.Local).AddTicks(8747),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 13, 0, 1, 3, 359, DateTimeKind.Local).AddTicks(1321));
        }
    }
}
