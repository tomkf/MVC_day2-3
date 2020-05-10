﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Portfolio.Models;

namespace portfolio_mvc.Migrations
{
    [DbContext(typeof(PortfolioContext))]
    [Migration("20200510045203_AddInterviews")]
    partial class AddInterviews
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("Portfolio.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Title");

                    b.Property<string>("Url");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Portfolio.Models.Technology", b =>
                {
                    b.Property<string>("Name");

                    b.HasKey("Name");

                    b.ToTable("Technologies");
                });

            modelBuilder.Entity("Portfolio.Models.TechnologyProject", b =>
                {
                    b.Property<string>("TechnologyName");

                    b.Property<int>("ProjectId");

                    b.HasKey("TechnologyName", "ProjectId");

                    b.HasAlternateKey("ProjectId", "TechnologyName");

                    b.ToTable("TechnologyProjects");
                });

            modelBuilder.Entity("portfolio_mvc.Models.Company", b =>
                {
                    b.Property<string>("Name");

                    b.Property<string>("Contact");

                    b.Property<string>("Email");

                    b.Property<string>("Phone");

                    b.HasKey("Name");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("portfolio_mvc.Models.InterviewRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyName");

                    b.Property<string>("Location");

                    b.Property<DateTime>("Time");

                    b.HasKey("Id");

                    b.HasIndex("CompanyName");

                    b.ToTable("InterviewRequests");
                });

            modelBuilder.Entity("Portfolio.Models.TechnologyProject", b =>
                {
                    b.HasOne("Portfolio.Models.Project", "Project")
                        .WithMany("TechnologyProjects")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Portfolio.Models.Technology", "Technology")
                        .WithMany("TechnologyProjects")
                        .HasForeignKey("TechnologyName")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("portfolio_mvc.Models.InterviewRequest", b =>
                {
                    b.HasOne("portfolio_mvc.Models.Company", "Company")
                        .WithMany("InterviewRequests")
                        .HasForeignKey("CompanyName");
                });
#pragma warning restore 612, 618
        }
    }
}
