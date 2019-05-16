﻿// <auto-generated />
using System;
using BankOfBrabant.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BankOfBrabant.Migrations
{
    [DbContext(typeof(BankOfBrabantContext))]
    [Migration("20190516110048_initial5")]
    partial class initial5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BankOfBrabant.Models.Account", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountName");

                    b.Property<int>("AccountType");

                    b.Property<decimal>("Balance");

                    b.Property<int>("CreditLimit");

                    b.Property<float>("InterestRate");

                    b.Property<string>("Number");

                    b.Property<int>("PassNumber");

                    b.Property<int>("Pincode");

                    b.HasKey("ID");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("BankOfBrabant.Models.AccountHolder", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId");

                    b.Property<int>("ClientID");

                    b.Property<int>("HolderType");

                    b.HasKey("ID");

                    b.HasIndex("AccountId");

                    b.HasIndex("ClientID");

                    b.ToTable("AccountHolder");
                });

            modelBuilder.Entity("BankOfBrabant.Models.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<bool>("Blacklisted");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("Insertion");

                    b.Property<string>("KVKNumber");

                    b.Property<bool>("KVKPositive");

                    b.Property<string>("LastName");

                    b.Property<bool>("PassportCheck");

                    b.Property<int>("gender");

                    b.HasKey("ID");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("BankOfBrabant.Models.Employee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<int>("Gender");

                    b.Property<string>("Insertion");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.HasKey("ID");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("BankOfBrabant.Models.Products", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId");

                    b.Property<double>("CurrentLoan");

                    b.Property<double>("InterestRate");

                    b.Property<double>("LoanLimit");

                    b.Property<double>("MonthlyPayment");

                    b.Property<int>("ProductType");

                    b.HasKey("ID");

                    b.HasIndex("ClientId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("BankOfBrabant.Models.Transaction", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccountID");

                    b.Property<DateTime>("Date");

                    b.Property<double>("Euro");

                    b.Property<int>("ReceiverAccountId");

                    b.Property<int>("SenderAccountId");

                    b.Property<bool>("Verified");

                    b.HasKey("ID");

                    b.HasIndex("AccountID");

                    b.HasIndex("ReceiverAccountId");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("BankOfBrabant.Models.AccountHolder", b =>
                {
                    b.HasOne("BankOfBrabant.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BankOfBrabant.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BankOfBrabant.Models.Products", b =>
                {
                    b.HasOne("BankOfBrabant.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BankOfBrabant.Models.Transaction", b =>
                {
                    b.HasOne("BankOfBrabant.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountID");

                    b.HasOne("BankOfBrabant.Models.Account", "ReceiverAccount")
                        .WithMany()
                        .HasForeignKey("ReceiverAccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
