﻿// <auto-generated />
using System;
using EasyMeterAPP.InfraEstrutura.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EasyMeterAPP.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EasyMeterAPP.Entities.Entity.Bloco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CondominioId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CondominioId");

                    b.ToTable("BLOCO");
                });

            modelBuilder.Entity("EasyMeterAPP.Entities.Entity.Condominio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CONDOMINIO");
                });

            modelBuilder.Entity("EasyMeterAPP.Entities.Entity.Medicao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataHoraMedicao")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("MedicaoAtual")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Prefixo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UnidadeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UnidadeId");

                    b.ToTable("MEDICAO");
                });

            modelBuilder.Entity("EasyMeterAPP.Entities.Entity.Unidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BlocoId")
                        .HasColumnType("int");

                    b.Property<int>("CondominioId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BlocoId");

                    b.HasIndex("CondominioId");

                    b.ToTable("UNIDADE");
                });

            modelBuilder.Entity("EasyMeterAPP.Entities.Entity.Bloco", b =>
                {
                    b.HasOne("EasyMeterAPP.Entities.Entity.Condominio", "Condominio")
                        .WithMany()
                        .HasForeignKey("CondominioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Condominio");
                });

            modelBuilder.Entity("EasyMeterAPP.Entities.Entity.Medicao", b =>
                {
                    b.HasOne("EasyMeterAPP.Entities.Entity.Unidade", "Unidade")
                        .WithMany()
                        .HasForeignKey("UnidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Unidade");
                });

            modelBuilder.Entity("EasyMeterAPP.Entities.Entity.Unidade", b =>
                {
                    b.HasOne("EasyMeterAPP.Entities.Entity.Bloco", "Bloco")
                        .WithMany()
                        .HasForeignKey("BlocoId");

                    b.HasOne("EasyMeterAPP.Entities.Entity.Condominio", "Condominio")
                        .WithMany()
                        .HasForeignKey("CondominioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bloco");

                    b.Navigation("Condominio");
                });
#pragma warning restore 612, 618
        }
    }
}
