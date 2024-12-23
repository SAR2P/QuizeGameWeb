﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Quize_api.Models;

#nullable disable

namespace Quize_api.Migrations
{
    [DbContext(typeof(QuizeDbContext))]
    [Migration("20240309094001_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Quize_api.Models.Participant", b =>
                {
                    b.Property<int>("ParticipantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ParticipantId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TimceTaken")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("score")
                        .HasColumnType("int");

                    b.HasKey("ParticipantId");

                    b.ToTable("participants");
                });

            modelBuilder.Entity("Quize_api.Models.Question", b =>
                {
                    b.Property<int>("QnId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QnId"));

                    b.Property<int>("Answre")
                        .HasColumnType("int");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("QnInWords")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("option1")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("option2")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("option3")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("option4")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("QnId");

                    b.ToTable("questions");
                });
#pragma warning restore 612, 618
        }
    }
}
