﻿// <auto-generated />
using MicroserviceRestApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MicroserviceRestApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250204193534_AddPupilIdToExercises")]
    partial class AddPupilIdToExercises
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MicroserviceRestApi.Models.Exercises", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PupilId")
                        .HasColumnType("integer");

                    b.Property<int?>("PupilsId")
                        .HasColumnType("integer");

                    b.Property<int>("Reps")
                        .HasColumnType("integer");

                    b.Property<string>("Weight")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PupilsId");

                    b.ToTable("Exercises");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Comment = "brak",
                            Label = "Wyciskanie sztangi",
                            PupilId = 0,
                            Reps = 5,
                            Weight = "50"
                        },
                        new
                        {
                            Id = 2,
                            Comment = "brak",
                            Label = "Przysiady ze sztanga",
                            PupilId = 0,
                            Reps = 12,
                            Weight = "90"
                        });
                });

            modelBuilder.Entity("MicroserviceRestApi.Models.Pupils", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TrainerId")
                        .HasColumnType("integer");

                    b.Property<int?>("TrainersId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TrainersId");

                    b.ToTable("Pupils");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "mike.johnson@example.com",
                            Name = "Mike Johnson",
                            Password = "password789",
                            TrainerId = 1
                        },
                        new
                        {
                            Id = 2,
                            Email = "emily.davis@example.com",
                            Name = "Emily Davis",
                            Password = "password101",
                            TrainerId = 2
                        });
                });

            modelBuilder.Entity("MicroserviceRestApi.Models.Trainers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Trainers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "john.doe@example.com",
                            Name = "John Doe",
                            Password = "password123"
                        },
                        new
                        {
                            Id = 2,
                            Email = "jane.smith@example.com",
                            Name = "Jane Smith",
                            Password = "password456"
                        });
                });

            modelBuilder.Entity("MicroserviceRestApi.Models.Exercises", b =>
                {
                    b.HasOne("MicroserviceRestApi.Models.Pupils", null)
                        .WithMany("ExercisesList")
                        .HasForeignKey("PupilsId");
                });

            modelBuilder.Entity("MicroserviceRestApi.Models.Pupils", b =>
                {
                    b.HasOne("MicroserviceRestApi.Models.Trainers", null)
                        .WithMany("PupilsList")
                        .HasForeignKey("TrainersId");
                });

            modelBuilder.Entity("MicroserviceRestApi.Models.Pupils", b =>
                {
                    b.Navigation("ExercisesList");
                });

            modelBuilder.Entity("MicroserviceRestApi.Models.Trainers", b =>
                {
                    b.Navigation("PupilsList");
                });
#pragma warning restore 612, 618
        }
    }
}
