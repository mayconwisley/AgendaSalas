﻿// <auto-generated />
using System;
using AgendaSalas.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AgendaSalas.API.Migrations
{
    [DbContext(typeof(AgendaContext))]
    [Migration("20230826214922_AddIndexNomeSala")]
    partial class AddIndexNomeSala
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AgendaSalas.API.Model.Agenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataFinal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(500)");

                    b.Property<bool>("PermitirChamar")
                        .HasColumnType("bit");

                    b.Property<bool>("PermitirLigar")
                        .HasColumnType("bit");

                    b.Property<int>("SalaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SalaId");

                    b.ToTable("Agendas");
                });

            modelBuilder.Entity("AgendaSalas.API.Model.Sala", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(15)");

                    b.Property<string>("Ramal")
                        .HasColumnType("VARCHAR(5)");

                    b.HasKey("Id");

                    b.HasIndex("Nome");

                    b.ToTable("Salas");
                });

            modelBuilder.Entity("AgendaSalas.API.Model.Agenda", b =>
                {
                    b.HasOne("AgendaSalas.API.Model.Sala", "Sala")
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
