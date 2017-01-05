using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Plutus.Data;

namespace Plutus.Migrations
{
    [DbContext(typeof(PlutusContext))]
    [Migration("20170105221742_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Plutus.Models.Card", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("APR");

                    b.Property<string>("BankName");

                    b.Property<string>("CardName");

                    b.Property<decimal>("CreditLimit")
                        .HasColumnType("money");

                    b.Property<int>("DueDay");

                    b.Property<int>("WebsiteID");

                    b.HasKey("ID");

                    b.HasIndex("WebsiteID");

                    b.ToTable("Card");
                });

            modelBuilder.Entity("Plutus.Models.DailyData", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("AvailableCredit")
                        .HasColumnType("money");

                    b.Property<DateTime>("Date");

                    b.Property<int>("MonthlyDataID");

                    b.HasKey("ID");

                    b.HasIndex("MonthlyDataID");

                    b.ToTable("DailyData");
                });

            modelBuilder.Entity("Plutus.Models.MonthlyData", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CardID");

                    b.Property<bool>("IsPaid");

                    b.Property<int>("Month");

                    b.HasKey("ID");

                    b.HasIndex("CardID");

                    b.ToTable("MonthlyData");
                });

            modelBuilder.Entity("Plutus.Models.Website", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CardID");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<int>("Type");

                    b.Property<string>("URL");

                    b.Property<string>("UserName");

                    b.HasKey("ID");

                    b.HasIndex("CardID");

                    b.ToTable("Website");
                });

            modelBuilder.Entity("Plutus.Models.Card", b =>
                {
                    b.HasOne("Plutus.Models.Website", "Website")
                        .WithMany()
                        .HasForeignKey("WebsiteID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Plutus.Models.DailyData", b =>
                {
                    b.HasOne("Plutus.Models.MonthlyData", "MonthlyData")
                        .WithMany("DailyRecords")
                        .HasForeignKey("MonthlyDataID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Plutus.Models.MonthlyData", b =>
                {
                    b.HasOne("Plutus.Models.Card", "Card")
                        .WithMany()
                        .HasForeignKey("CardID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Plutus.Models.Website", b =>
                {
                    b.HasOne("Plutus.Models.Card")
                        .WithMany("UsedBy")
                        .HasForeignKey("CardID");
                });
        }
    }
}
