﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using QIMSchoolPro.Thesis.Persistence;

#nullable disable

namespace QIMSchoolPro.Thesis.Persistence.Migrations
{
    [DbContext(typeof(ThesisDbContext))]
    [Migration("20231102203041_SubmissionHistory")]
    partial class SubmissionHistory
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("QIMSchoolPro.Thesis.Domain.Entities.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DocumentType")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OtherProperty")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OtherProperty1")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SubmissionId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SubmissionId");

                    b.ToTable("Document", (string)null);
                });

            modelBuilder.Entity("QIMSchoolPro.Thesis.Domain.Entities.Submission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Abstract")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OtherProperty")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OtherProperty1")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StudentNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("SubmissionDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TransitionState")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Submission", (string)null);
                });

            modelBuilder.Entity("QIMSchoolPro.Thesis.Domain.Entities.SubmissionHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Activity")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("ActivityDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("OtherProperty")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OtherProperty1")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PartyId")
                        .HasColumnType("integer");

                    b.Property<int>("SubmissionId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("SubmissionHistory", (string)null);
                });

            modelBuilder.Entity("QIMSchoolPro.Thesis.Domain.Entities.Version", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DocumentId")
                        .HasColumnType("integer");

                    b.Property<int>("Index")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OtherProperty")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OtherProperty1")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DocumentId");

                    b.ToTable("Version", (string)null);
                });

            modelBuilder.Entity("QIMSchoolPro.Thesis.Domain.Entities.Document", b =>
                {
                    b.HasOne("QIMSchoolPro.Thesis.Domain.Entities.Submission", null)
                        .WithMany("Documents")
                        .HasForeignKey("SubmissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Qface.Domain.Shared.ValueObjects.Audit", "Audit", b1 =>
                        {
                            b1.Property<int>("DocumentId")
                                .HasColumnType("integer");

                            b1.Property<DateTime>("Created")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<string>("CreatedBy")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("EntityStatus")
                                .HasColumnType("text");

                            b1.Property<string>("EntityStatusCreateBy")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<DateTime?>("EntityStatusCreated")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<DateTime?>("EntityStatusLastModified")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<string>("EntityStatusLastModifiedBy")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<DateTime?>("LastModified")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<string>("LastModifiedBy")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("DocumentId");

                            b1.ToTable("Document");

                            b1.WithOwner()
                                .HasForeignKey("DocumentId");
                        });

                    b.Navigation("Audit")
                        .IsRequired();
                });

            modelBuilder.Entity("QIMSchoolPro.Thesis.Domain.Entities.Submission", b =>
                {
                    b.OwnsOne("Qface.Domain.Shared.ValueObjects.Audit", "Audit", b1 =>
                        {
                            b1.Property<int>("SubmissionId")
                                .HasColumnType("integer");

                            b1.Property<DateTime>("Created")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<string>("CreatedBy")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("EntityStatus")
                                .HasColumnType("text");

                            b1.Property<string>("EntityStatusCreateBy")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<DateTime?>("EntityStatusCreated")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<DateTime?>("EntityStatusLastModified")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<string>("EntityStatusLastModifiedBy")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<DateTime?>("LastModified")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<string>("LastModifiedBy")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("SubmissionId");

                            b1.ToTable("Submission");

                            b1.WithOwner()
                                .HasForeignKey("SubmissionId");
                        });

                    b.OwnsOne("QIMSchoolPro.Thesis.Domain.ValueObjects.AcademicPeriod", "AcademicPeriod", b1 =>
                        {
                            b1.Property<int>("SubmissionId")
                                .HasColumnType("integer");

                            b1.Property<int>("LowerYear")
                                .HasColumnType("integer");

                            b1.Property<int>("Semester")
                                .HasColumnType("integer");

                            b1.Property<int>("UpperYear")
                                .HasColumnType("integer");

                            b1.HasKey("SubmissionId");

                            b1.ToTable("Submission");

                            b1.WithOwner()
                                .HasForeignKey("SubmissionId");
                        });

                    b.Navigation("AcademicPeriod")
                        .IsRequired();

                    b.Navigation("Audit")
                        .IsRequired();
                });

            modelBuilder.Entity("QIMSchoolPro.Thesis.Domain.Entities.SubmissionHistory", b =>
                {
                    b.OwnsOne("Qface.Domain.Shared.ValueObjects.Audit", "Audit", b1 =>
                        {
                            b1.Property<int>("SubmissionHistoryId")
                                .HasColumnType("integer");

                            b1.Property<DateTime>("Created")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<string>("CreatedBy")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("EntityStatus")
                                .HasColumnType("text");

                            b1.Property<string>("EntityStatusCreateBy")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<DateTime?>("EntityStatusCreated")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<DateTime?>("EntityStatusLastModified")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<string>("EntityStatusLastModifiedBy")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<DateTime?>("LastModified")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<string>("LastModifiedBy")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("SubmissionHistoryId");

                            b1.ToTable("SubmissionHistory");

                            b1.WithOwner()
                                .HasForeignKey("SubmissionHistoryId");
                        });

                    b.Navigation("Audit")
                        .IsRequired();
                });

            modelBuilder.Entity("QIMSchoolPro.Thesis.Domain.Entities.Version", b =>
                {
                    b.HasOne("QIMSchoolPro.Thesis.Domain.Entities.Document", null)
                        .WithMany("Versions")
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Qface.Domain.Shared.ValueObjects.Audit", "Audit", b1 =>
                        {
                            b1.Property<int>("VersionId")
                                .HasColumnType("integer");

                            b1.Property<DateTime>("Created")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<string>("CreatedBy")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("EntityStatus")
                                .HasColumnType("text");

                            b1.Property<string>("EntityStatusCreateBy")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<DateTime?>("EntityStatusCreated")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<DateTime?>("EntityStatusLastModified")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<string>("EntityStatusLastModifiedBy")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<DateTime?>("LastModified")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<string>("LastModifiedBy")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("VersionId");

                            b1.ToTable("Version");

                            b1.WithOwner()
                                .HasForeignKey("VersionId");
                        });

                    b.Navigation("Audit")
                        .IsRequired();
                });

            modelBuilder.Entity("QIMSchoolPro.Thesis.Domain.Entities.Document", b =>
                {
                    b.Navigation("Versions");
                });

            modelBuilder.Entity("QIMSchoolPro.Thesis.Domain.Entities.Submission", b =>
                {
                    b.Navigation("Documents");
                });
#pragma warning restore 612, 618
        }
    }
}