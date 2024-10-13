﻿// <auto-generated />
using MeichuHackaThon2024Model.ContextModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MeichuHackaThon2024Model.Migrations
{
    [DbContext(typeof(MeichuHackaThonDBContext))]
    [Migration("20241013010602_Update_Path_Detail")]
    partial class Update_Path_Detail
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MeichuHackaThon2024Model.Models.PathDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("CostTime")
                        .HasColumnType("float");

                    b.Property<int>("Crowding")
                        .HasColumnType("int");

                    b.Property<string>("Destination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PathDetailId")
                        .HasColumnType("int");

                    b.Property<int>("PathId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Paths");
                });
#pragma warning restore 612, 618
        }
    }
}
