﻿// <auto-generated />
using System;
using Invest.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Invest.Persistence.Migrations
{
    [DbContext(typeof(InvestContext))]
    [Migration("20220719045414_CotistaSemOperacao")]
    partial class CotistaSemOperacao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("Invest.Domain.Cotista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cotistas");
                });

            modelBuilder.Entity("Invest.Domain.Operacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CotistaId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataOperacao")
                        .HasColumnType("TEXT");

                    b.Property<int>("QtdCotas")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TipoOperacao")
                        .HasColumnType("INTEGER");

                    b.Property<double>("ValorCota")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("CotistaId");

                    b.ToTable("Operacoes");
                });

            modelBuilder.Entity("Invest.Domain.Operacao", b =>
                {
                    b.HasOne("Invest.Domain.Cotista", "Cotista")
                        .WithMany("Operacoes")
                        .HasForeignKey("CotistaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cotista");
                });

            modelBuilder.Entity("Invest.Domain.Cotista", b =>
                {
                    b.Navigation("Operacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
