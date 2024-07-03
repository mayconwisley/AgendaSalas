﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ScheduleRooms.API.Data;

#nullable disable

namespace ScheduleRooms.API.Migrations
{
    [DbContext(typeof(ScheduleContext))]
    [Migration("20240703180315_RemovendoUserId")]
    partial class RemovendoUserId
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ScheduleRooms.API.Model.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Description")
                        .HasColumnType("VARCHAR(500)");

                    b.Property<string>("Garden")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("VARCHAR(10)");

                    b.Property<bool>("Prospection")
                        .HasColumnType("bit");

                    b.Property<string>("Road")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("ScheduleRooms.API.Model.ClientContact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("ClientResponsibleId")
                        .HasColumnType("int");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ClientResponsibleId");

                    b.ToTable("ClientContacts");
                });

            modelBuilder.Entity("ScheduleRooms.API.Model.ClientResponsible", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("VARCHAR(500)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("VARCHAR(120)");

                    b.HasKey("Id");

                    b.ToTable("ClientResponsibles");
                });

            modelBuilder.Entity("ScheduleRooms.API.Model.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateFinal")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("VARCHAR(500)");

                    b.Property<bool>("MeetingType")
                        .HasColumnType("bit");

                    b.Property<bool>("Particular")
                        .HasColumnType("bit");

                    b.Property<bool>("StatusSchedule")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("ScheduleRooms.API.Model.ScheduleUser", b =>
                {
                    b.Property<int>("ScheduleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ScheduleId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("ScheduleUsers");
                });

            modelBuilder.Entity("ScheduleRooms.API.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("VARCHAR(500)");

                    b.Property<bool>("Manager")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            Description = "Administrador",
                            Manager = true,
                            Name = "Admin",
                            Password = "yhcVN+Dw3hU=",
                            Username = "Admin"
                        });
                });

            modelBuilder.Entity("ScheduleRooms.API.Model.UserContact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserContacts");
                });

            modelBuilder.Entity("ScheduleRooms.API.Model.ClientContact", b =>
                {
                    b.HasOne("ScheduleRooms.API.Model.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScheduleRooms.API.Model.ClientResponsible", "ClientResponsible")
                        .WithMany("ClientContacts")
                        .HasForeignKey("ClientResponsibleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("ClientResponsible");
                });

            modelBuilder.Entity("ScheduleRooms.API.Model.Schedule", b =>
                {
                    b.HasOne("ScheduleRooms.API.Model.Client", "Client")
                        .WithMany("ScheduleUsers")
                        .HasForeignKey("ClientId");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("ScheduleRooms.API.Model.ScheduleUser", b =>
                {
                    b.HasOne("ScheduleRooms.API.Model.Schedule", "Schedule")
                        .WithMany("ScheduleUsers")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScheduleRooms.API.Model.User", "User")
                        .WithMany("ScheduleUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Schedule");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ScheduleRooms.API.Model.UserContact", b =>
                {
                    b.HasOne("ScheduleRooms.API.Model.User", "User")
                        .WithMany("UserContacts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ScheduleRooms.API.Model.Client", b =>
                {
                    b.Navigation("ScheduleUsers");
                });

            modelBuilder.Entity("ScheduleRooms.API.Model.ClientResponsible", b =>
                {
                    b.Navigation("ClientContacts");
                });

            modelBuilder.Entity("ScheduleRooms.API.Model.Schedule", b =>
                {
                    b.Navigation("ScheduleUsers");
                });

            modelBuilder.Entity("ScheduleRooms.API.Model.User", b =>
                {
                    b.Navigation("ScheduleUsers");

                    b.Navigation("UserContacts");
                });
#pragma warning restore 612, 618
        }
    }
}
