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
    [Migration("20241009043246_remote_Table")]
    partial class remote_Table
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MeichuHackaThon2024Model.Models.Path", b =>
                {
                    b.Property<int>("Sysno")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Sysno"));

                    b.Property<int>("AttractionsEnumType")
                        .HasColumnType("int");

                    b.Property<float>("CostTime")
                        .HasColumnType("real");

                    b.Property<int>("CrowdingEnumType")
                        .HasColumnType("int");

                    b.Property<float>("Distance")
                        .HasColumnType("real");

                    b.Property<int>("TransportCompEnumType")
                        .HasColumnType("int");

                    b.HasKey("Sysno");

                    b.ToTable("Paths");
                });
#pragma warning restore 612, 618
        }
    }
}
