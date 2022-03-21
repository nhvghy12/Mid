﻿// <auto-generated />
using System;
using BackEnd.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackEnd.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20220320051518_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BackEnd.Data.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Summary")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Book", (string)null);
                });

            modelBuilder.Entity("BackEnd.Data.Entities.BookBorrowingRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateRequested")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ProcessedByUserId")
                        .HasColumnType("int");

                    b.Property<int>("RequestedByUserId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProcessedByUserId");

                    b.HasIndex("RequestedByUserId");

                    b.ToTable("BookBorrowingRequest", (string)null);
                });

            modelBuilder.Entity("BackEnd.Data.Entities.BookBorrowingRequestDetails", b =>
                {
                    b.Property<int>("BookBorrowingRequestId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.HasKey("BookBorrowingRequestId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("BookBorrowingRequestDetail", (string)null);
                });

            modelBuilder.Entity("BackEnd.Data.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Category", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Novel"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Comic"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Poem"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Textbook"
                        });
                });

            modelBuilder.Entity("BackEnd.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("Password")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool?>("isSuperUser")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("BackEnd.Data.Entities.Book", b =>
                {
                    b.HasOne("BackEnd.Data.Entities.Category", "Category")
                        .WithMany("Books")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("BackEnd.Data.Entities.BookBorrowingRequest", b =>
                {
                    b.HasOne("BackEnd.Data.Entities.User", "ProcessedBy")
                        .WithMany("ProssedRequests")
                        .HasForeignKey("ProcessedByUserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("BackEnd.Data.Entities.User", "RequestedBy")
                        .WithMany("BookBorrowingRequests")
                        .HasForeignKey("RequestedByUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ProcessedBy");

                    b.Navigation("RequestedBy");
                });

            modelBuilder.Entity("BackEnd.Data.Entities.BookBorrowingRequestDetails", b =>
                {
                    b.HasOne("BackEnd.Data.Entities.BookBorrowingRequest", "BookBorrowingRequest")
                        .WithMany("Details")
                        .HasForeignKey("BookBorrowingRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEnd.Data.Entities.Book", "Book")
                        .WithMany("Details")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("BookBorrowingRequest");
                });

            modelBuilder.Entity("BackEnd.Data.Entities.Book", b =>
                {
                    b.Navigation("Details");
                });

            modelBuilder.Entity("BackEnd.Data.Entities.BookBorrowingRequest", b =>
                {
                    b.Navigation("Details");
                });

            modelBuilder.Entity("BackEnd.Data.Entities.Category", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("BackEnd.Data.Entities.User", b =>
                {
                    b.Navigation("BookBorrowingRequests");

                    b.Navigation("ProssedRequests");
                });
#pragma warning restore 612, 618
        }
    }
}