﻿// <auto-generated />
using Eform1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Eform1.Data.Migrations
{
    [DbContext(typeof(FormDbContext))]
    [Migration("20200618193840_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Eform1.models.table_1", b =>
                {
                    b.Property<int>("UID_F")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Created_On")
                        .HasColumnType("text");

                    b.Property<string>("Creator")
                        .HasColumnType("text");

                    b.Property<string>("Form_Name")
                        .HasColumnType("text");

                    b.HasKey("UID_F");

                    b.ToTable("table_1s");
                });

            modelBuilder.Entity("Eform1.models.table_2", b =>
                {
                    b.Property<int>("UID_Q")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Question")
                        .HasColumnType("text");

                    b.Property<string>("Question_Type")
                        .HasColumnType("text");

                    b.Property<int>("UID_F1")
                        .HasColumnType("int");

                    b.HasKey("UID_Q");

                    b.HasIndex("UID_F1");

                    b.ToTable("table_2s");
                });

            modelBuilder.Entity("Eform1.models.table_3", b =>
                {
                    b.Property<int>("ID_MCQ")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("F2")
                        .HasColumnType("int");

                    b.Property<string>("Options")
                        .HasColumnType("text");

                    b.Property<int>("UID_Q")
                        .HasColumnType("int");

                    b.HasKey("ID_MCQ");

                    b.HasIndex("UID_Q");

                    b.ToTable("table_3s");
                });

            modelBuilder.Entity("Eform1.models.table_2", b =>
                {
                    b.HasOne("Eform1.models.table_1", "table_1")
                        .WithMany("table_2")
                        .HasForeignKey("UID_F1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Eform1.models.table_3", b =>
                {
                    b.HasOne("Eform1.models.table_2", "table_2")
                        .WithMany("table_3")
                        .HasForeignKey("UID_Q")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
