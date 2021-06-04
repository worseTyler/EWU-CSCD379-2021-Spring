﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SecretSanta.Data;

namespace SecretSanta.Data.Migrations
{
    [DbContext(typeof(DbContext))]
    [Migration("20210604043525_Update1")]
    partial class Update1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("GroupUser", b =>
                {
                    b.Property<int>("GroupsGroupId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsersUserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("GroupsGroupId", "UsersUserId");

                    b.HasIndex("UsersUserId");

                    b.ToTable("GroupUser");
                });

            modelBuilder.Entity("SecretSanta.Data.Assignment", b =>
                {
                    b.Property<int>("AssignmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("GiverUserId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("GroupId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ReceiverUserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AssignmentId");

                    b.HasIndex("GiverUserId");

                    b.HasIndex("GroupId");

                    b.HasIndex("ReceiverUserId");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("SecretSanta.Data.Gift", b =>
                {
                    b.Property<int>("GiftId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Priority")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("GiftId");

                    b.HasIndex("UserId");

                    b.ToTable("Gifts");
                });

            modelBuilder.Entity("SecretSanta.Data.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("GroupId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("SecretSanta.Data.GroupUser", b =>
                {
                    b.Property<int>("GroupId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("GroupId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("GroupUsers");
                });

            modelBuilder.Entity("SecretSanta.Data.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GroupUser", b =>
                {
                    b.HasOne("SecretSanta.Data.Group", null)
                        .WithMany()
                        .HasForeignKey("GroupsGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SecretSanta.Data.User", null)
                        .WithMany()
                        .HasForeignKey("UsersUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SecretSanta.Data.Assignment", b =>
                {
                    b.HasOne("SecretSanta.Data.User", "Giver")
                        .WithMany()
                        .HasForeignKey("GiverUserId");

                    b.HasOne("SecretSanta.Data.Group", null)
                        .WithMany("Assignments")
                        .HasForeignKey("GroupId");

                    b.HasOne("SecretSanta.Data.User", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverUserId");

                    b.Navigation("Giver");

                    b.Navigation("Receiver");
                });

            modelBuilder.Entity("SecretSanta.Data.Gift", b =>
                {
                    b.HasOne("SecretSanta.Data.User", null)
                        .WithMany("Gifts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SecretSanta.Data.GroupUser", b =>
                {
                    b.HasOne("SecretSanta.Data.Group", "Group")
                        .WithMany("GroupUser")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SecretSanta.Data.User", "User")
                        .WithMany("GroupUser")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SecretSanta.Data.Group", b =>
                {
                    b.Navigation("Assignments");

                    b.Navigation("GroupUser");
                });

            modelBuilder.Entity("SecretSanta.Data.User", b =>
                {
                    b.Navigation("Gifts");

                    b.Navigation("GroupUser");
                });
#pragma warning restore 612, 618
        }
    }
}
