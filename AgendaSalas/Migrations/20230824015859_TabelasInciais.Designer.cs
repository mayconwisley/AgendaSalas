﻿// <auto-generated />
using System;
using AgendaSalas.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AgendaSalas.Migrations
{
    [DbContext(typeof(AgendaContext))]
    [Migration("20230824015859_TabelasInciais")]
    partial class TabelasInciais
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("AgendaSalas.Models.Reuniao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(1000)");

                    b.Property<bool>("PermitirChamar")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("PermitirLigar")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SalaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SalaId");

                    b.ToTable("Reunioes");
                });

            modelBuilder.Entity("AgendaSalas.Models.Sala", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .HasColumnType("VARCHAR(1000)");

                    b.Property<string>("Ramal")
                        .HasColumnType("VARCHAR(5)");

                    b.Property<string>("SalaReuniao")
                        .HasColumnType("VARCHAR(500)");

                    b.HasKey("Id");

                    b.ToTable("Salas");
                });

            modelBuilder.Entity("AgendaSalas.Models.Reuniao", b =>
                {
                    b.HasOne("AgendaSalas.Models.Sala", "Sala")
                        .WithMany()
                        .HasForeignKey("SalaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sala");
                });
#pragma warning restore 612, 618
        }
    }
}
