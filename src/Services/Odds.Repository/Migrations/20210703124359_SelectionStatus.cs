using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Odds.Repository.Migrations
{
    public partial class SelectionStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Odds",
                table: "Selection",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 3, 12, 43, 59, 154, DateTimeKind.Utc).AddTicks(2104),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 7, 2, 21, 43, 10, 986, DateTimeKind.Utc).AddTicks(9507));

            migrationBuilder.AddColumn<int>(
                name: "SelectionStatus",
                schema: "Odds",
                table: "Selection",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Odds",
                table: "Region",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 3, 12, 43, 59, 151, DateTimeKind.Utc).AddTicks(6529),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 7, 2, 21, 43, 10, 982, DateTimeKind.Utc).AddTicks(8455));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Odds",
                table: "Participant",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 3, 12, 43, 59, 148, DateTimeKind.Utc).AddTicks(2391),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 7, 2, 21, 43, 10, 977, DateTimeKind.Utc).AddTicks(7718));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Odds",
                table: "MarketTemplate",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 3, 12, 43, 59, 134, DateTimeKind.Utc).AddTicks(6007),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 7, 2, 21, 43, 10, 965, DateTimeKind.Utc).AddTicks(6863));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Odds",
                table: "Market",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 3, 12, 43, 59, 131, DateTimeKind.Utc).AddTicks(2522),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 7, 2, 21, 43, 10, 961, DateTimeKind.Utc).AddTicks(5669));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Odds",
                table: "Event",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 3, 12, 43, 59, 123, DateTimeKind.Utc).AddTicks(5381),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 7, 2, 21, 43, 10, 953, DateTimeKind.Utc).AddTicks(9374));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Odds",
                table: "Competition",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 3, 12, 43, 59, 114, DateTimeKind.Utc).AddTicks(5731),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 7, 2, 21, 43, 10, 942, DateTimeKind.Utc).AddTicks(4150));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Odds",
                table: "Category",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 3, 12, 43, 59, 82, DateTimeKind.Utc).AddTicks(3516),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 7, 2, 21, 43, 10, 904, DateTimeKind.Utc).AddTicks(3901));

            migrationBuilder.CreateIndex(
                name: "IX_Selection_SelectionStatus",
                schema: "Odds",
                table: "Selection",
                column: "SelectionStatus");

            migrationBuilder.AddForeignKey(
                name: "FK_Selection_MarketStatus_SelectionStatus",
                schema: "Odds",
                table: "Selection",
                column: "SelectionStatus",
                principalSchema: "Odds",
                principalTable: "MarketStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Selection_MarketStatus_SelectionStatus",
                schema: "Odds",
                table: "Selection");

            migrationBuilder.DropIndex(
                name: "IX_Selection_SelectionStatus",
                schema: "Odds",
                table: "Selection");

            migrationBuilder.DropColumn(
                name: "SelectionStatus",
                schema: "Odds",
                table: "Selection");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Odds",
                table: "Selection",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 2, 21, 43, 10, 986, DateTimeKind.Utc).AddTicks(9507),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 7, 3, 12, 43, 59, 154, DateTimeKind.Utc).AddTicks(2104));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Odds",
                table: "Region",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 2, 21, 43, 10, 982, DateTimeKind.Utc).AddTicks(8455),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 7, 3, 12, 43, 59, 151, DateTimeKind.Utc).AddTicks(6529));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Odds",
                table: "Participant",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 2, 21, 43, 10, 977, DateTimeKind.Utc).AddTicks(7718),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 7, 3, 12, 43, 59, 148, DateTimeKind.Utc).AddTicks(2391));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Odds",
                table: "MarketTemplate",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 2, 21, 43, 10, 965, DateTimeKind.Utc).AddTicks(6863),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 7, 3, 12, 43, 59, 134, DateTimeKind.Utc).AddTicks(6007));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Odds",
                table: "Market",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 2, 21, 43, 10, 961, DateTimeKind.Utc).AddTicks(5669),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 7, 3, 12, 43, 59, 131, DateTimeKind.Utc).AddTicks(2522));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Odds",
                table: "Event",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 2, 21, 43, 10, 953, DateTimeKind.Utc).AddTicks(9374),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 7, 3, 12, 43, 59, 123, DateTimeKind.Utc).AddTicks(5381));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Odds",
                table: "Competition",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 2, 21, 43, 10, 942, DateTimeKind.Utc).AddTicks(4150),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 7, 3, 12, 43, 59, 114, DateTimeKind.Utc).AddTicks(5731));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Odds",
                table: "Category",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 2, 21, 43, 10, 904, DateTimeKind.Utc).AddTicks(3901),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 7, 3, 12, 43, 59, 82, DateTimeKind.Utc).AddTicks(3516));
        }
    }
}
