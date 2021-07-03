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
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 7, 2, 21, 43, 10, 904, DateTimeKind.Utc).AddTicks(3901)),
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
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 7, 2, 21, 43, 10, 965, DateTimeKind.Utc).AddTicks(6863)),
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
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 7, 2, 21, 43, 10, 982, DateTimeKind.Utc).AddTicks(8455)),
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
                    RegionGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Region = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 7, 2, 21, 43, 10, 942, DateTimeKind.Utc).AddTicks(4150)),
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
                });

            migrationBuilder.CreateTable(
                name: "Event",
                schema: "Odds",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Category = table.Column<Guid>(type: "uuid", nullable: false),
                    EventStatus = table.Column<int>(type: "integer", nullable: false),
                    competitionGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    Competition = table.Column<Guid>(type: "uuid", nullable: false),
                    Label = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    StartTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 7, 2, 21, 43, 10, 953, DateTimeKind.Utc).AddTicks(9374)),
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
                        name: "FK_Event_Competition_competitionGuid",
                        column: x => x.competitionGuid,
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
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 7, 2, 21, 43, 10, 977, DateTimeKind.Utc).AddTicks(7718)),
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
                    EventGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    MarketStatus = table.Column<int>(type: "integer", nullable: false),
                    Endtime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Event = table.Column<Guid>(type: "uuid", nullable: false),
                    Label = table.Column<string>(type: "text", nullable: false),
                    MarketTemplate = table.Column<Guid>(type: "uuid", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 7, 2, 21, 43, 10, 961, DateTimeKind.Utc).AddTicks(5669)),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Market", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Market_Event_EventGuid",
                        column: x => x.EventGuid,
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
                    MarketGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    Index = table.Column<int>(type: "integer", nullable: false),
                    MarketId = table.Column<Guid>(type: "uuid", nullable: false),
                    Odds = table.Column<decimal>(type: "numeric", nullable: false),
                    ParticipantLabel = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 7, 2, 21, 43, 10, 986, DateTimeKind.Utc).AddTicks(9507)),
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
                name: "IX_Event_Category",
                schema: "Odds",
                table: "Event",
                column: "Category");

            migrationBuilder.CreateIndex(
                name: "IX_Event_competitionGuid",
                schema: "Odds",
                table: "Event",
                column: "competitionGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Event_EventStatus",
                schema: "Odds",
                table: "Event",
                column: "EventStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Market_EventGuid",
                schema: "Odds",
                table: "Market",
                column: "EventGuid");

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
