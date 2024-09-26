﻿// <auto-generated />
using System;
using CidadeInteligente.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace CidadeInteligente.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240627184314_MudancaNomeColunaMonitorAcidenteViolacao")]
    partial class MudancaNomeColunaMonitorAcidenteViolacao
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CidadeInteligente.Models.AcidenteModel", b =>
                {
                    b.Property<int>("AcidenteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AcidenteId"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("Dia")
                        .HasColumnType("date");

                    b.Property<string>("Local")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("MonitorId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Severidade")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("AcidenteId");

                    b.HasIndex("MonitorId");

                    b.ToTable("Acidentes_Reportados", (string)null);
                });

            modelBuilder.Entity("CidadeInteligente.Models.MonitorModel", b =>
                {
                    b.Property<int>("MonitorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MonitorId"));

                    b.Property<int>("ContVeic")
                        .HasColumnType("NUMBER(10)");

                    b.Property<DateTime>("Dia")
                        .HasColumnType("date");

                    b.Property<string>("Local")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<double>("VelMedia")
                        .HasColumnType("BINARY_DOUBLE");

                    b.HasKey("MonitorId");

                    b.ToTable("Monitor_Trafego", (string)null);
                });

            modelBuilder.Entity("CidadeInteligente.Models.SemaforoModel", b =>
                {
                    b.Property<int>("SemaforoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SemaforoId"));

                    b.Property<int>("Duracao")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("SemaforoId");

                    b.ToTable("Dados_Semaforo", (string)null);
                });

            modelBuilder.Entity("CidadeInteligente.Models.UsuarioModel", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("UsuarioNome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios", (string)null);
                });

            modelBuilder.Entity("CidadeInteligente.Models.ViolacaoModel", b =>
                {
                    b.Property<int>("ViolacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ViolacaoId"));

                    b.Property<DateTime>("Dia")
                        .HasColumnType("date");

                    b.Property<string>("Local")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("MonitorId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("ViolacaoId");

                    b.HasIndex("MonitorId");

                    b.ToTable("Violacoes", (string)null);
                });

            modelBuilder.Entity("CidadeInteligente.Models.AcidenteModel", b =>
                {
                    b.HasOne("CidadeInteligente.Models.MonitorModel", "Monitor")
                        .WithMany("Acidentes")
                        .HasForeignKey("MonitorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Monitor");
                });

            modelBuilder.Entity("CidadeInteligente.Models.ViolacaoModel", b =>
                {
                    b.HasOne("CidadeInteligente.Models.MonitorModel", "Monitor")
                        .WithMany("Violacoes")
                        .HasForeignKey("MonitorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Monitor");
                });

            modelBuilder.Entity("CidadeInteligente.Models.MonitorModel", b =>
                {
                    b.Navigation("Acidentes");

                    b.Navigation("Violacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
