using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestTask.Sql.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BondExchangeTradedAssets",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    AssetClass = table.Column<byte>(type: "smallint", nullable: false),
                    Ticker = table.Column<string>(type: "text", nullable: true),
                    Isin = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CurrencyBase = table.Column<string>(type: "text", nullable: true),
                    LotSize = table.Column<int>(type: "integer", nullable: false),
                    BondType = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BondExchangeTradedAssets", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "StockExchangeTradedAssets",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    AssetClass = table.Column<byte>(type: "smallint", nullable: false),
                    Ticker = table.Column<string>(type: "text", nullable: true),
                    Isin = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CurrencyBase = table.Column<string>(type: "text", nullable: true),
                    LotSize = table.Column<int>(type: "integer", nullable: false),
                    StockType = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockExchangeTradedAssets", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "Emitents",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Country = table.Column<string>(type: "text", nullable: true),
                    Branch = table.Column<byte>(type: "smallint", nullable: false),
                    BondExchangeTradedAssetId = table.Column<Guid>(type: "uuid", nullable: false),
                    StockExchangeTradedAssetId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emitents", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_Emitents_BondExchangeTradedAssets_BondExchangeTradedAssetId",
                        column: x => x.BondExchangeTradedAssetId,
                        principalTable: "BondExchangeTradedAssets",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Emitents_StockExchangeTradedAssets_StockExchangeTradedAsset~",
                        column: x => x.StockExchangeTradedAssetId,
                        principalTable: "StockExchangeTradedAssets",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exchanges",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    BondExchangeTradedAssetId = table.Column<Guid>(type: "uuid", nullable: false),
                    StockExchangeTradedAssetId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exchanges", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_Exchanges_BondExchangeTradedAssets_BondExchangeTradedAssetId",
                        column: x => x.BondExchangeTradedAssetId,
                        principalTable: "BondExchangeTradedAssets",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exchanges_StockExchangeTradedAssets_StockExchangeTradedAsse~",
                        column: x => x.StockExchangeTradedAssetId,
                        principalTable: "StockExchangeTradedAssets",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emitents_BondExchangeTradedAssetId",
                table: "Emitents",
                column: "BondExchangeTradedAssetId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Emitents_StockExchangeTradedAssetId",
                table: "Emitents",
                column: "StockExchangeTradedAssetId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exchanges_BondExchangeTradedAssetId",
                table: "Exchanges",
                column: "BondExchangeTradedAssetId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exchanges_StockExchangeTradedAssetId",
                table: "Exchanges",
                column: "StockExchangeTradedAssetId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emitents");

            migrationBuilder.DropTable(
                name: "Exchanges");

            migrationBuilder.DropTable(
                name: "BondExchangeTradedAssets");

            migrationBuilder.DropTable(
                name: "StockExchangeTradedAssets");
        }
    }
}
