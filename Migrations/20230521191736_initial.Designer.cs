﻿// <auto-generated />
using System;
using IssaWPF6.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IssaWPF6.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230521191736_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("IssaWPF6.Models.Colon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Age")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AnalInspection")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Assistant")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ClinicalData")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ColonDetails")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Conclusion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Endoscopist")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FileNo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Ileum")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PRExam")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Premedication")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Preparation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Rectum")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ReferredDoctor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Scope")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Colons");
                });

            modelBuilder.Entity("IssaWPF6.Models.Stomach", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Age")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Assistant")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ClinicalData")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Conclusion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("D1")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("D2")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Endoscopist")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Esophagus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FileNo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("GEJ")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Premedication")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ReferredDoctor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Scope")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StomachDetails")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Stomaches");
                });
#pragma warning restore 612, 618
        }
    }
}
