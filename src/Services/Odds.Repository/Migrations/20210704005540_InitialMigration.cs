using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Odds.Repository.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Odds");

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "Odds",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    ParentGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedByUser = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 7, 4, 0, 55, 40, 340, DateTimeKind.Utc).AddTicks(7290)),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Category_Category_ParentGuid",
                        column: x => x.ParentGuid,
                        principalSchema: "Odds",
                        principalTable: "Category",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventStatus",
                schema: "Odds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MarketStatus",
                schema: "Odds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MarketTemplate",
                schema: "Odds",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    FriendlyName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 7, 4, 0, 55, 40, 386, DateTimeKind.Utc).AddTicks(1069)),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketTemplate", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                schema: "Odds",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 7, 4, 0, 55, 40, 401, DateTimeKind.Utc).AddTicks(2118)),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Region_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Odds",
                        principalTable: "Category",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Competition",
                schema: "Odds",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    RegionGuid1 = table.Column<Guid>(type: "uuid", nullable: false),
                    RegionGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 7, 4, 0, 55, 40, 367, DateTimeKind.Utc).AddTicks(6300)),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competition", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Competition_Region_RegionGuid",
                        column: x => x.RegionGuid,
                        principalSchema: "Odds",
                        principalTable: "Region",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Competition_Region_RegionGuid1",
                        column: x => x.RegionGuid1,
                        principalSchema: "Odds",
                        principalTable: "Region",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                schema: "Odds",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Category = table.Column<Guid>(type: "uuid", nullable: false),
                    EventStatus = table.Column<int>(type: "integer", nullable: false),
                    Competition = table.Column<Guid>(type: "uuid", nullable: false),
                    Label = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    StartTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 7, 4, 0, 55, 40, 377, DateTimeKind.Utc).AddTicks(9525)),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Event_Category_Category",
                        column: x => x.Category,
                        principalSchema: "Odds",
                        principalTable: "Category",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Event_Competition_Competition",
                        column: x => x.Competition,
                        principalSchema: "Odds",
                        principalTable: "Competition",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Event_EventStatus_EventStatus",
                        column: x => x.EventStatus,
                        principalSchema: "Odds",
                        principalTable: "EventStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Participant",
                schema: "Odds",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    CompetitionId = table.Column<Guid>(type: "uuid", nullable: true),
                    _name = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 7, 4, 0, 55, 40, 398, DateTimeKind.Utc).AddTicks(4046)),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participant", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Participant_Competition_CompetitionId",
                        column: x => x.CompetitionId,
                        principalSchema: "Odds",
                        principalTable: "Competition",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Market",
                schema: "Odds",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Event = table.Column<Guid>(type: "uuid", nullable: false),
                    MarketStatus = table.Column<int>(type: "integer", nullable: false),
                    Endtime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Label = table.Column<string>(type: "text", nullable: false),
                    MarketTemplate = table.Column<Guid>(type: "uuid", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 7, 4, 0, 55, 40, 383, DateTimeKind.Utc).AddTicks(6295)),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Market", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Market_Event_Event",
                        column: x => x.Event,
                        principalSchema: "Odds",
                        principalTable: "Event",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Market_MarketStatus_MarketStatus",
                        column: x => x.MarketStatus,
                        principalSchema: "Odds",
                        principalTable: "MarketStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParticipantDetail",
                schema: "Odds",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    ParticipantId = table.Column<Guid>(type: "uuid", nullable: false),
                    EventId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Index = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantDetail", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_ParticipantDetail_Event_EventId",
                        column: x => x.EventId,
                        principalSchema: "Odds",
                        principalTable: "Event",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParticipantDetail_Participant_ParticipantId",
                        column: x => x.ParticipantId,
                        principalSchema: "Odds",
                        principalTable: "Participant",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Selection",
                schema: "Odds",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    SelectionStatus = table.Column<int>(type: "integer", nullable: false),
                    MarketGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    Index = table.Column<int>(type: "integer", nullable: false),
                    Odds = table.Column<decimal>(type: "numeric", nullable: false),
                    ParticipantLabel = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 7, 4, 0, 55, 40, 404, DateTimeKind.Utc).AddTicks(1780)),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Selection", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Selection_Market_MarketGuid",
                        column: x => x.MarketGuid,
                        principalSchema: "Odds",
                        principalTable: "Market",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Selection_MarketStatus_SelectionStatus",
                        column: x => x.SelectionStatus,
                        principalSchema: "Odds",
                        principalTable: "MarketStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentGuid",
                schema: "Odds",
                table: "Category",
                column: "ParentGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Competition_RegionGuid",
                schema: "Odds",
                table: "Competition",
                column: "RegionGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Competition_RegionGuid1",
                schema: "Odds",
                table: "Competition",
                column: "RegionGuid1");

            migrationBuilder.CreateIndex(
                name: "IX_Event_Category",
                schema: "Odds",
                table: "Event",
                column: "Category");

            migrationBuilder.CreateIndex(
                name: "IX_Event_Competition",
                schema: "Odds",
                table: "Event",
                column: "Competition");

            migrationBuilder.CreateIndex(
                name: "IX_Event_EventStatus",
                schema: "Odds",
                table: "Event",
                column: "EventStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Market_Event",
                schema: "Odds",
                table: "Market",
                column: "Event");

            migrationBuilder.CreateIndex(
                name: "IX_Market_MarketStatus",
                schema: "Odds",
                table: "Market",
                column: "MarketStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_CompetitionId",
                schema: "Odds",
                table: "Participant",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantDetail_EventId",
                schema: "Odds",
                table: "ParticipantDetail",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantDetail_ParticipantId",
                schema: "Odds",
                table: "ParticipantDetail",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_Region_CategoryId",
                schema: "Odds",
                table: "Region",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Selection_MarketGuid",
                schema: "Odds",
                table: "Selection",
                column: "MarketGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Selection_SelectionStatus",
                schema: "Odds",
                table: "Selection",
                column: "SelectionStatus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarketTemplate",
                schema: "Odds");

            migrationBuilder.DropTable(
                name: "ParticipantDetail",
                schema: "Odds");

            migrationBuilder.DropTable(
                name: "Selection",
                schema: "Odds");

            migrationBuilder.DropTable(
                name: "Participant",
                schema: "Odds");

            migrationBuilder.DropTable(
                name: "Market",
                schema: "Odds");

            migrationBuilder.DropTable(
                name: "Event",
                schema: "Odds");

            migrationBuilder.DropTable(
                name: "MarketStatus",
                schema: "Odds");

            migrationBuilder.DropTable(
                name: "Competition",
                schema: "Odds");

            migrationBuilder.DropTable(
                name: "EventStatus",
                schema: "Odds");

            migrationBuilder.DropTable(
                name: "Region",
                schema: "Odds");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "Odds");
        }
    }
}
