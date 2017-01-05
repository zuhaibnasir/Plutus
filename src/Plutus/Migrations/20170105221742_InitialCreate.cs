using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Plutus.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MonthlyData",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CardID = table.Column<int>(nullable: false),
                    IsPaid = table.Column<bool>(nullable: false),
                    Month = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyData", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DailyData",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AvailableCredit = table.Column<decimal>(type: "money", nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    MonthlyDataID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyData", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DailyData_MonthlyData_MonthlyDataID",
                        column: x => x.MonthlyDataID,
                        principalTable: "MonthlyData",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Website",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CardID = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    URL = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Website", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    APR = table.Column<decimal>(nullable: false),
                    BankName = table.Column<string>(nullable: true),
                    CardName = table.Column<string>(nullable: true),
                    CreditLimit = table.Column<decimal>(type: "money", nullable: false),
                    DueDay = table.Column<int>(nullable: false),
                    WebsiteID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Card_Website_WebsiteID",
                        column: x => x.WebsiteID,
                        principalTable: "Website",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Card_WebsiteID",
                table: "Card",
                column: "WebsiteID");

            migrationBuilder.CreateIndex(
                name: "IX_DailyData_MonthlyDataID",
                table: "DailyData",
                column: "MonthlyDataID");

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyData_CardID",
                table: "MonthlyData",
                column: "CardID");

            migrationBuilder.CreateIndex(
                name: "IX_Website_CardID",
                table: "Website",
                column: "CardID");

            migrationBuilder.AddForeignKey(
                name: "FK_MonthlyData_Card_CardID",
                table: "MonthlyData",
                column: "CardID",
                principalTable: "Card",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Website_Card_CardID",
                table: "Website",
                column: "CardID",
                principalTable: "Card",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Card_Website_WebsiteID",
                table: "Card");

            migrationBuilder.DropTable(
                name: "DailyData");

            migrationBuilder.DropTable(
                name: "MonthlyData");

            migrationBuilder.DropTable(
                name: "Website");

            migrationBuilder.DropTable(
                name: "Card");
        }
    }
}
