﻿// <auto-generated />
using System;
using CoodeshTest.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CoodeshTest.Infra.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230522131622_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CoodeshTest.Domain.Entities.Affiliated", b =>
                {
                    b.Property<int>("AffiliatedId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AffiliatedId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AffiliatedId");

                    b.ToTable("Affiliates");
                });

            modelBuilder.Entity("CoodeshTest.Domain.Entities.Collaborator", b =>
                {
                    b.Property<int>("CollaboratorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CollaboratorId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CollaboratorId");

                    b.ToTable("Collaborators");
                });

            modelBuilder.Entity("CoodeshTest.Domain.Entities.Creator", b =>
                {
                    b.Property<int>("CreatorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CreatorId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CreatorId");

                    b.ToTable("Creators");
                });

            modelBuilder.Entity("CoodeshTest.Domain.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int?>("CreatorId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("ProductId");

                    b.HasIndex("CreatorId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("CoodeshTest.Domain.Entities.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionId"));

                    b.Property<int?>("AffiliatedId")
                        .HasColumnType("int");

                    b.Property<int?>("CreatorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTransaction")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("TransactionId");

                    b.HasIndex("AffiliatedId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("ProductId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("CoodeshTest.Domain.Entities.Product", b =>
                {
                    b.HasOne("CoodeshTest.Domain.Entities.Creator", "Creator")
                        .WithMany("Products")
                        .HasForeignKey("CreatorId");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("CoodeshTest.Domain.Entities.Transaction", b =>
                {
                    b.HasOne("CoodeshTest.Domain.Entities.Affiliated", "Affiliated")
                        .WithMany("Transactions")
                        .HasForeignKey("AffiliatedId");

                    b.HasOne("CoodeshTest.Domain.Entities.Creator", "Creator")
                        .WithMany("Transactions")
                        .HasForeignKey("CreatorId");

                    b.HasOne("CoodeshTest.Domain.Entities.Product", "Product")
                        .WithMany("Transactions")
                        .HasForeignKey("ProductId");

                    b.Navigation("Affiliated");

                    b.Navigation("Creator");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("CoodeshTest.Domain.Entities.Affiliated", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("CoodeshTest.Domain.Entities.Creator", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("CoodeshTest.Domain.Entities.Product", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
