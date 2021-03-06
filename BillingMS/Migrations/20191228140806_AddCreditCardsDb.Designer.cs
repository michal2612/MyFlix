﻿// <auto-generated />
using System;
using BillingMS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BillingMS.Migrations
{
    [DbContext(typeof(CreditCardContext))]
    [Migration("20191228140806_AddCreditCardsDb")]
    partial class AddCreditCardsDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BillingMS.Models.CreditCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CardNumber");

                    b.Property<string>("CardOwner");

                    b.Property<int>("CvvNumber");

                    b.Property<DateTime>("ExpiryDate");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("CreditCards");
                });
#pragma warning restore 612, 618
        }
    }
}
