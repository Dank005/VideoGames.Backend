﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VideoGames.Persistence;

namespace VideoGames.Persistence.Migrations
{
    [DbContext(typeof(VideoGamesDbContext))]
    partial class VideoGamesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("VideoGames.Domain.GameGenre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("GameGenres");
                });

            modelBuilder.Entity("VideoGames.Domain.VideoGame", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("DeveloperStudio")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("VideoGames");
                });

            modelBuilder.Entity("VideoGames.Domain.VideoGame_Genre", b =>
                {
                    b.Property<Guid>("VideoGameId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("GameGenreId")
                        .HasColumnType("TEXT");

                    b.HasKey("VideoGameId", "GameGenreId");

                    b.HasIndex("GameGenreId");

                    b.ToTable("VideoGame_Genre");
                });

            modelBuilder.Entity("VideoGames.Domain.VideoGame_Genre", b =>
                {
                    b.HasOne("VideoGames.Domain.GameGenre", "GameGenre")
                        .WithMany("VideoGame_Genres")
                        .HasForeignKey("GameGenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VideoGames.Domain.VideoGame", "VideoGame")
                        .WithMany("VideoGame_Genres")
                        .HasForeignKey("VideoGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameGenre");

                    b.Navigation("VideoGame");
                });

            modelBuilder.Entity("VideoGames.Domain.GameGenre", b =>
                {
                    b.Navigation("VideoGame_Genres");
                });

            modelBuilder.Entity("VideoGames.Domain.VideoGame", b =>
                {
                    b.Navigation("VideoGame_Genres");
                });
#pragma warning restore 612, 618
        }
    }
}
