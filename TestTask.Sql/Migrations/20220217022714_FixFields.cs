using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestTask.Sql.Migrations
{
    public partial class FixFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emitents_BondExchangeTradedAssets_BondExchangeTradedAssetId",
                table: "Emitents");

            migrationBuilder.DropForeignKey(
                name: "FK_Emitents_StockExchangeTradedAssets_StockExchangeTradedAsset~",
                table: "Emitents");

            migrationBuilder.DropForeignKey(
                name: "FK_Exchanges_BondExchangeTradedAssets_BondExchangeTradedAssetId",
                table: "Exchanges");

            migrationBuilder.DropForeignKey(
                name: "FK_Exchanges_StockExchangeTradedAssets_StockExchangeTradedAsse~",
                table: "Exchanges");

            migrationBuilder.DropIndex(
                name: "IX_Exchanges_BondExchangeTradedAssetId",
                table: "Exchanges");

            migrationBuilder.DropIndex(
                name: "IX_Exchanges_StockExchangeTradedAssetId",
                table: "Exchanges");

            migrationBuilder.DropIndex(
                name: "IX_Emitents_BondExchangeTradedAssetId",
                table: "Emitents");

            migrationBuilder.DropIndex(
                name: "IX_Emitents_StockExchangeTradedAssetId",
                table: "Emitents");

            migrationBuilder.DropColumn(
                name: "BondExchangeTradedAssetId",
                table: "Exchanges");

            migrationBuilder.DropColumn(
                name: "StockExchangeTradedAssetId",
                table: "Exchanges");

            migrationBuilder.DropColumn(
                name: "BondExchangeTradedAssetId",
                table: "Emitents");

            migrationBuilder.DropColumn(
                name: "StockExchangeTradedAssetId",
                table: "Emitents");

            migrationBuilder.AddColumn<Guid>(
                name: "EmitentId",
                table: "StockExchangeTradedAssets",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ExchangeId",
                table: "StockExchangeTradedAssets",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "EmitentId",
                table: "BondExchangeTradedAssets",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ExchangeId",
                table: "BondExchangeTradedAssets",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmitentId",
                table: "StockExchangeTradedAssets");

            migrationBuilder.DropColumn(
                name: "ExchangeId",
                table: "StockExchangeTradedAssets");

            migrationBuilder.DropColumn(
                name: "EmitentId",
                table: "BondExchangeTradedAssets");

            migrationBuilder.DropColumn(
                name: "ExchangeId",
                table: "BondExchangeTradedAssets");

            migrationBuilder.AddColumn<Guid>(
                name: "BondExchangeTradedAssetId",
                table: "Exchanges",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "StockExchangeTradedAssetId",
                table: "Exchanges",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "BondExchangeTradedAssetId",
                table: "Emitents",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "StockExchangeTradedAssetId",
                table: "Emitents",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.AddForeignKey(
                name: "FK_Emitents_BondExchangeTradedAssets_BondExchangeTradedAssetId",
                table: "Emitents",
                column: "BondExchangeTradedAssetId",
                principalTable: "BondExchangeTradedAssets",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Emitents_StockExchangeTradedAssets_StockExchangeTradedAsset~",
                table: "Emitents",
                column: "StockExchangeTradedAssetId",
                principalTable: "StockExchangeTradedAssets",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exchanges_BondExchangeTradedAssets_BondExchangeTradedAssetId",
                table: "Exchanges",
                column: "BondExchangeTradedAssetId",
                principalTable: "BondExchangeTradedAssets",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exchanges_StockExchangeTradedAssets_StockExchangeTradedAsse~",
                table: "Exchanges",
                column: "StockExchangeTradedAssetId",
                principalTable: "StockExchangeTradedAssets",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
