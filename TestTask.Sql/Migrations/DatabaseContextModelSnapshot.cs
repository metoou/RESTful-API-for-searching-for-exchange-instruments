﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TestTask.Sql;

namespace TestTask.Sql.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("TestTask.Entities.BondExchangeTradedAssetEntity", b =>
                {
                    b.Property<Guid>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<byte>("AssetClass")
                        .HasColumnType("smallint");

                    b.Property<byte>("BondType")
                        .HasColumnType("smallint");

                    b.Property<string>("CurrencyBase")
                        .HasColumnType("text");

                    b.Property<Guid>("EmitentId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("ExchangeId")
                        .HasColumnType("uuid");

                    b.Property<string>("Isin")
                        .HasColumnType("text");

                    b.Property<int>("LotSize")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Ticker")
                        .HasColumnType("text");

                    b.HasKey("EntityId");

                    b.ToTable("BondExchangeTradedAssets");
                });

            modelBuilder.Entity("TestTask.Entities.EmitentEntity", b =>
                {
                    b.Property<Guid>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<byte>("Branch")
                        .HasColumnType("smallint");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("EntityId");

                    b.ToTable("Emitents");
                });

            modelBuilder.Entity("TestTask.Entities.ExchangeEntity", b =>
                {
                    b.Property<Guid>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("EntityId");

                    b.ToTable("Exchanges");
                });

            modelBuilder.Entity("TestTask.Entities.StockExchangeTradedAssetEntity", b =>
                {
                    b.Property<Guid>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<byte>("AssetClass")
                        .HasColumnType("smallint");

                    b.Property<string>("CurrencyBase")
                        .HasColumnType("text");

                    b.Property<Guid>("EmitentId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("ExchangeId")
                        .HasColumnType("uuid");

                    b.Property<string>("Isin")
                        .HasColumnType("text");

                    b.Property<int>("LotSize")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<byte>("StockType")
                        .HasColumnType("smallint");

                    b.Property<string>("Ticker")
                        .HasColumnType("text");

                    b.HasKey("EntityId");

                    b.ToTable("StockExchangeTradedAssets");
                });
#pragma warning restore 612, 618
        }
    }
}
