﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using tda_proj.Data;

#nullable disable

namespace tda_proj.Migrations
{
    [DbContext(typeof(tdaContext))]
    partial class tda_proj_ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("tda_proj.Model.Claims", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<Guid>("LectorUUID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("LectorUUID");

                    b.ToTable("Claims");
                });

            modelBuilder.Entity("tda_proj.Model.Contact", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<Guid>("LectorUUID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("LectorUUID")
                        .IsUnique();

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("tda_proj.Model.ContactEmail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("ContactID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ContactID");

                    b.ToTable("Emails");
                });

            modelBuilder.Entity("tda_proj.Model.ContactTelNumber", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("ContactID")
                        .HasColumnType("int");

                    b.Property<string>("TelNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ContactID");

                    b.ToTable("TelNumbers");
                });

            modelBuilder.Entity("tda_proj.Model.Lector", b =>
                {
                    b.Property<Guid>("UUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("bio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("middleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pictureUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("pricePerHour")
                        .HasColumnType("float");

                    b.HasKey("UUID");

                    b.ToTable("Lectors");
                });

            modelBuilder.Entity("tda_proj.Model.LectorTag", b =>
                {
                    b.Property<Guid>("LectorTagUUID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LectorUUID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LectorTagUUID", "LectorUUID");

                    b.HasIndex("LectorUUID");

                    b.ToTable("LectorTags");
                });

            modelBuilder.Entity("tda_proj.Model.Tag", b =>
                {
                    b.Property<Guid>("TagUUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TagUUID");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("tda_proj.Model.TitleAfter", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<Guid>("LectorUUID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("LectorUUID");

                    b.ToTable("TitlesAfter");
                });

            modelBuilder.Entity("tda_proj.Model.TitleBefore", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<Guid>("LectorUUID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("LectorUUID");

                    b.ToTable("TitlesBefore");
                });

            modelBuilder.Entity("tda_proj.Model.Claims", b =>
                {
                    b.HasOne("tda_proj.Model.Lector", "Lector")
                        .WithMany("claims")
                        .HasForeignKey("LectorUUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lector");
                });

            modelBuilder.Entity("tda_proj.Model.Contact", b =>
                {
                    b.HasOne("tda_proj.Model.Lector", "Lector")
                        .WithOne("Contact")
                        .HasForeignKey("tda_proj.Model.Contact", "LectorUUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lector");
                });

            modelBuilder.Entity("tda_proj.Model.ContactEmail", b =>
                {
                    b.HasOne("tda_proj.Model.Contact", "Contact")
                        .WithMany("Emails")
                        .HasForeignKey("ContactID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("tda_proj.Model.ContactTelNumber", b =>
                {
                    b.HasOne("tda_proj.Model.Contact", "Contact")
                        .WithMany("TelNumbers")
                        .HasForeignKey("ContactID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("tda_proj.Model.LectorTag", b =>
                {
                    b.HasOne("tda_proj.Model.Tag", "Tag")
                        .WithMany("Tags")
                        .HasForeignKey("LectorTagUUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tda_proj.Model.Lector", "Lector")
                        .WithMany("lectorTags")
                        .HasForeignKey("LectorUUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lector");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("tda_proj.Model.TitleAfter", b =>
                {
                    b.HasOne("tda_proj.Model.Lector", "lector")
                        .WithMany("titlesAfter")
                        .HasForeignKey("LectorUUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("lector");
                });

            modelBuilder.Entity("tda_proj.Model.TitleBefore", b =>
                {
                    b.HasOne("tda_proj.Model.Lector", "lector")
                        .WithMany("titlesBefore")
                        .HasForeignKey("LectorUUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("lector");
                });

            modelBuilder.Entity("tda_proj.Model.Contact", b =>
                {
                    b.Navigation("Emails");

                    b.Navigation("TelNumbers");
                });

            modelBuilder.Entity("tda_proj.Model.Lector", b =>
                {
                    b.Navigation("Contact")
                        .IsRequired();

                    b.Navigation("claims");

                    b.Navigation("lectorTags");

                    b.Navigation("titlesAfter");

                    b.Navigation("titlesBefore");
                });

            modelBuilder.Entity("tda_proj.Model.Tag", b =>
                {
                    b.Navigation("Tags");
                });
#pragma warning restore 612, 618
        }
    }
}
