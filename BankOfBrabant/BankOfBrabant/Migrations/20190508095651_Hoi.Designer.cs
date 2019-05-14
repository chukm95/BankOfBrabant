﻿// <auto-generated />
using BankOfBrabant.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BankOfBrabant.Migrations
{
    [DbContext(typeof(BankOfBrabantContext))]
    [Migration("20190508095651_Hoi")]
    partial class Hoi
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BankOfBrabant.Models.RekeningOverzicht", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naam");

                    b.Property<int>("Rekeningnummer");

                    b.Property<string>("Rentepercentage");

                    b.Property<int>("Saldo");

                    b.Property<int>("TypeRekening");

                    b.HasKey("ID");

                    b.ToTable("RekeningOverzicht");
                });
#pragma warning restore 612, 618
        }
    }
}