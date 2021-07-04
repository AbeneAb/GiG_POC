using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Odds.Repository.Migrations
{
    public partial class SelectionMarket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Odds",
                table: "Selection",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 4, 1, 28, 8, 712, DateTimeKind.Utc).AddTicks(8671),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 7, 4, 0, 55, 40, 404, DateTimeKind.Utc).AddTicks(1780));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Odds",
                table: "Region",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 4, 1, 28, 8, 709, DateTimeKind.Utc).AddTicks(6907),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 7, 4, 0, 55, 40, 401, DateTimeKind.Utc).AddTicks(2118));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Odds",
                table: "Participant",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 4, 1, 28, 8, 705, DateTimeKind.Utc).AddTicks(176),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 7, 4, 0, 55, 40, 398, DateTimeKind.Utc).AddTicks(4046));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Odds",
                table: "MarketTemplate",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 4, 1, 28, 8, 693, DateTimeKind.Utc).AddTicks(9805),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 7, 4, 0, 55, 40, 386, DateTimeKind.Utc).AddTicks(1069));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Odds",
                table: "Market",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 4, 1, 28, 8, 689, DateTimeKind.Utc).AddTicks(8743),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 7, 4, 0, 55, 40, 383, DateTimeKind.Utc).AddTicks(6295));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Odds",
                table: "Event",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 4, 1, 28, 8, 683, DateTimeKind.Utc).AddTicks(491),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 7, 4, 0, 55, 40, 377, DateTimeKind.Utc).AddTicks(9525));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Odds",
                table: "Competition",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 4, 1, 28, 8, 671, DateTimeKind.Utc).AddTicks(9402),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 7, 4, 0, 55, 40, 367, DateTimeKind.Utc).AddTicks(6300));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Odds",
                table: "Category",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 4, 1, 28, 8, 641, DateTimeKind.Utc).AddTicks(5199),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 7, 4, 0, 55, 40, 340, DateTimeKind.Utc).AddTicks(7290));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Odds",
                table: "Selection",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 4, 0, 55, 40, 404, DateTimeKind.Utc).AddTicks(1780),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 7, 4, 1, 28, 8, 712, DateTimeKind.Utc).AddTicks(8671));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Odds",
                table: "Region",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 4, 0, 55, 40, 401, DateTimeKind.Utc).AddTicks(2118),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 7, 4, 1, 28, 8, 709, DateTimeKind.Utc).AddTicks(6907));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Odds",
                table: "Participant",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 4, 0, 55, 40, 398, DateTimeKind.Utc).AddTicks(4046),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 7, 4, 1, 28, 8, 705, DateTimeKind.Utc).AddTicks(176));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Odds",
                table: "MarketTemplate",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 4, 0, 55, 40, 386, DateTimeKind.Utc).AddTicks(1069),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 7, 4, 1, 28, 8, 693, DateTimeKind.Utc).AddTicks(9805));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Odds",
                table: "Market",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 4, 0, 55, 40, 383, DateTimeKind.Utc).AddTicks(6295),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 7, 4, 1, 28, 8, 689, DateTimeKind.Utc).AddTicks(8743));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Odds",
                table: "Event",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 4, 0, 55, 40, 377, DateTimeKind.Utc).AddTicks(9525),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 7, 4, 1, 28, 8, 683, DateTimeKind.Utc).AddTicks(491));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Odds",
                table: "Competition",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 4, 0, 55, 40, 367, DateTimeKind.Utc).AddTicks(6300),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 7, 4, 1, 28, 8, 671, DateTimeKind.Utc).AddTicks(9402));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Odds",
                table: "Category",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 4, 0, 55, 40, 340, DateTimeKind.Utc).AddTicks(7290),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2021, 7, 4, 1, 28, 8, 641, DateTimeKind.Utc).AddTicks(5199));
        }
    }
}
