﻿// <auto-generated />
using CarPartsService.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ProviderService.Migrations
{
    [DbContext(typeof(CarPartContext))]
    [Migration("20190617153829_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085");

            modelBuilder.Entity("CarPartsService.DAL.Models.CarPart", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ManufacturerName");

                    b.Property<string>("PartDescription");

                    b.Property<string>("PartName");

                    b.Property<int>("PartNumber");

                    b.HasKey("ID");

                    b.ToTable("CarParts");
                });
#pragma warning restore 612, 618
        }
    }
}