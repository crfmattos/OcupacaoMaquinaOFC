﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OcupacaoMaquinaOFC.Data;

#nullable disable

namespace OcupacaoMaquinaOFC.Migrations
{
    [DbContext(typeof(OcupacaoMaquinaOFCContext))]
    [Migration("20231009125354_corrigindoDoubleToDecimal")]
    partial class corrigindoDoubleToDecimal
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("OcupacaoMaquinaOFC.Models.AlocacaoHoras", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("maquinaid")
                        .HasColumnType("int");

                    b.Property<int>("projetoid")
                        .HasColumnType("int");

                    b.Property<int>("qtdHoraPorMaquina")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("maquinaid");

                    b.HasIndex("projetoid");

                    b.ToTable("AlocacaoHoras");
                });

            modelBuilder.Entity("OcupacaoMaquinaOFC.Models.Maquina", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<decimal>("limiteHoras")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("valorHora")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("valorMaquina")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("id");

                    b.ToTable("Maquina");
                });

            modelBuilder.Entity("OcupacaoMaquinaOFC.Models.Projeto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<DateTime>("dataConclusao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dataInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("lider")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Projeto");
                });

            modelBuilder.Entity("OcupacaoMaquinaOFC.Models.AlocacaoHoras", b =>
                {
                    b.HasOne("OcupacaoMaquinaOFC.Models.Maquina", "maquina")
                        .WithMany()
                        .HasForeignKey("maquinaid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OcupacaoMaquinaOFC.Models.Projeto", "projeto")
                        .WithMany()
                        .HasForeignKey("projetoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("maquina");

                    b.Navigation("projeto");
                });
#pragma warning restore 612, 618
        }
    }
}
