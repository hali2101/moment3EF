﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using moment3EF.Data;

#nullable disable

namespace moment3EF.Migrations
{
    [DbContext(typeof(RecordContext))]
    [Migration("20230208131840_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("moment3EF.Models.Album", b =>
                {
                    b.Property<int>("AlbumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AlbumName")
                        .HasColumnType("TEXT");

                    b.Property<int>("ArtistId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("YearOfRelease")
                        .HasColumnType("INTEGER");

                    b.HasKey("AlbumId");

                    b.HasIndex("ArtistId");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("moment3EF.Models.Artist", b =>
                {
                    b.Property<int>("ArtistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("ArtistId");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("moment3EF.Models.Album", b =>
                {
                    b.HasOne("moment3EF.Models.Artist", "Artist")
                        .WithMany("Album")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("moment3EF.Models.Artist", b =>
                {
                    b.Navigation("Album");
                });
#pragma warning restore 612, 618
        }
    }
}
