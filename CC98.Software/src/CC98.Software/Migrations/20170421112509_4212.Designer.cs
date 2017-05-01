﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CC98.Software.Data;

namespace CC98.Software.Migrations
{
    [DbContext(typeof(SoftwareDbContext))]
    [Migration("20170421112509_4212")]
    partial class _4212
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CC98.Software.Data.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("ParentId");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("CC98.Software.Data.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CommentBelongtoId");

                    b.Property<DateTimeOffset>("Commenttime");

                    b.Property<string>("Contents");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CommentBelongtoId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("CC98.Software.Data.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Message");

                    b.Property<string>("ReceiverName");

                    b.Property<string>("SenderName");

                    b.Property<DateTimeOffset>("Time");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("CC98.Software.Data.Manager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("CC98.Software.Data.Software", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ClassId");

                    b.Property<int>("DownloadNum");

                    b.Property<string>("FileLocation");

                    b.Property<string>("Introduction");

                    b.Property<bool>("IsAccepted");

                    b.Property<bool>("IsFrequent");

                    b.Property<bool>("IsRecommended");

                    b.Property<string>("Name");

                    b.Property<string>("PhotoLocation");

                    b.Property<int>("Platform");

                    b.Property<long>("Size");

                    b.Property<DateTimeOffset>("UpdateTime");

                    b.Property<string>("UploaderName");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.ToTable("Softwares");
                });

            modelBuilder.Entity("CC98.Software.Data.Category", b =>
                {
                    b.HasOne("CC98.Software.Data.Category", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("CC98.Software.Data.Comment", b =>
                {
                    b.HasOne("CC98.Software.Data.Software", "CommentBelongto")
                        .WithMany("Comments")
                        .HasForeignKey("CommentBelongtoId");
                });

            modelBuilder.Entity("CC98.Software.Data.Software", b =>
                {
                    b.HasOne("CC98.Software.Data.Category", "Class")
                        .WithMany("Softwares")
                        .HasForeignKey("ClassId");
                });
        }
    }
}