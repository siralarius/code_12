﻿// <auto-generated />
using code_12.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;

namespace code_12.Migrations
{
    [DbContext(typeof(SymbolContext))]
    [Migration("20180702133114_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("code_12.Models.Symbol", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<float>("high");

                    b.Property<float>("highest");

                    b.Property<float>("low");

                    b.Property<float>("lowest");

                    b.Property<DateTime>("reading");

                    b.HasKey("ID");

                    b.ToTable("Symbol");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Symbol");
                });

            modelBuilder.Entity("code_12.Models.Bitcoin", b =>
                {
                    b.HasBaseType("code_12.Models.Symbol");


                    b.ToTable("Bitcoin");

                    b.HasDiscriminator().HasValue("Bitcoin");
                });
#pragma warning restore 612, 618
        }
    }
}
