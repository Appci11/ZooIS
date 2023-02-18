﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZooIS.Server.Data;

#nullable disable

namespace ZooIS.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230218105658_AnimalTagRequire")]
    partial class AnimalTagRequire
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("ZooIS.Shared.Models.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DateAquired")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateOfDeparture")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("ZooIS.Shared.Models.AnimalTagRequire", b =>
                {
                    b.Property<int>("AnimalId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TagId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AnimalId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("AnimalTagRequire");
                });

            modelBuilder.Entity("ZooIS.Shared.Models.Bundle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfUse")
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<bool>("PurchaseFinalized")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Bundles");
                });

            modelBuilder.Entity("ZooIS.Shared.Models.BundleTicket", b =>
                {
                    b.Property<int>("BundleId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TicketId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("BundleId", "TicketId");

                    b.HasIndex("TicketId");

                    b.ToTable("BundleTickets");
                });

            modelBuilder.Entity("ZooIS.Shared.Models.RegisteredUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<bool>("DeletionRequested")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastLoginDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("PassChangeTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("RequestPasswordReset")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("RegisteredUsers");
                });

            modelBuilder.Entity("ZooIS.Shared.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("ZooIS.Shared.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("ZooIS.Shared.Models.UserSettings", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("DarkMode")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("UserSettings");
                });

            modelBuilder.Entity("ZooIS.Shared.Models.AnimalTagRequire", b =>
                {
                    b.HasOne("ZooIS.Shared.Models.Animal", "Animal")
                        .WithMany("TagsRequire")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ZooIS.Shared.Models.Tag", "Tag")
                        .WithMany("AnimalsRequire")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("ZooIS.Shared.Models.BundleTicket", b =>
                {
                    b.HasOne("ZooIS.Shared.Models.Bundle", "Bundle")
                        .WithMany("BundleTickets")
                        .HasForeignKey("BundleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ZooIS.Shared.Models.Ticket", "Ticket")
                        .WithMany("BundleTickets")
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bundle");

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("ZooIS.Shared.Models.UserSettings", b =>
                {
                    b.HasOne("ZooIS.Shared.Models.RegisteredUser", "RegisteredUser")
                        .WithOne("UserSettings")
                        .HasForeignKey("ZooIS.Shared.Models.UserSettings", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RegisteredUser");
                });

            modelBuilder.Entity("ZooIS.Shared.Models.Animal", b =>
                {
                    b.Navigation("TagsRequire");
                });

            modelBuilder.Entity("ZooIS.Shared.Models.Bundle", b =>
                {
                    b.Navigation("BundleTickets");
                });

            modelBuilder.Entity("ZooIS.Shared.Models.RegisteredUser", b =>
                {
                    b.Navigation("UserSettings")
                        .IsRequired();
                });

            modelBuilder.Entity("ZooIS.Shared.Models.Tag", b =>
                {
                    b.Navigation("AnimalsRequire");
                });

            modelBuilder.Entity("ZooIS.Shared.Models.Ticket", b =>
                {
                    b.Navigation("BundleTickets");
                });
#pragma warning restore 612, 618
        }
    }
}
