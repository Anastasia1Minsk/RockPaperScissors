﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RockPaperScissors.Data;

#nullable disable

namespace RockPaperScissors.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230731172810_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RockPaperScissors.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FirstPlayerId")
                        .HasColumnType("int");

                    b.Property<bool>("IsFinished")
                        .HasColumnType("bit");

                    b.Property<int?>("SecondPlayerId")
                        .HasColumnType("int");

                    b.Property<int?>("WinnerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FirstPlayerId");

                    b.HasIndex("SecondPlayerId");

                    b.HasIndex("WinnerId");

                    b.ToTable("Games", (string)null);
                });

            modelBuilder.Entity("RockPaperScissors.Models.Round", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("FirstPlayerFigure")
                        .HasColumnType("int");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<int>("RoundNumber")
                        .HasColumnType("int");

                    b.Property<int?>("SecondPlayerFigure")
                        .HasColumnType("int");

                    b.Property<int?>("WinnerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("WinnerId");

                    b.ToTable("Rounds", (string)null);
                });

            modelBuilder.Entity("RockPaperScissors.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("RockPaperScissors.Models.Game", b =>
                {
                    b.HasOne("RockPaperScissors.Models.User", "FirstPlayer")
                        .WithMany("FirstPlayers")
                        .HasForeignKey("FirstPlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RockPaperScissors.Models.User", "SecondPlayer")
                        .WithMany("SecondPlayers")
                        .HasForeignKey("SecondPlayerId");

                    b.HasOne("RockPaperScissors.Models.User", "Winner")
                        .WithMany("GameWinners")
                        .HasForeignKey("WinnerId");

                    b.Navigation("FirstPlayer");

                    b.Navigation("SecondPlayer");

                    b.Navigation("Winner");
                });

            modelBuilder.Entity("RockPaperScissors.Models.Round", b =>
                {
                    b.HasOne("RockPaperScissors.Models.Game", "Game")
                        .WithMany("Rounds")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RockPaperScissors.Models.User", "Winner")
                        .WithMany("RoundWinners")
                        .HasForeignKey("WinnerId");

                    b.Navigation("Game");

                    b.Navigation("Winner");
                });

            modelBuilder.Entity("RockPaperScissors.Models.Game", b =>
                {
                    b.Navigation("Rounds");
                });

            modelBuilder.Entity("RockPaperScissors.Models.User", b =>
                {
                    b.Navigation("FirstPlayers");

                    b.Navigation("GameWinners");

                    b.Navigation("RoundWinners");

                    b.Navigation("SecondPlayers");
                });
#pragma warning restore 612, 618
        }
    }
}
