﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TwitterCloneAPI.Data;

#nullable disable

namespace TwitterCloneAPI.Migrations
{
    [DbContext(typeof(TwitterCloneDbContext))]
    [Migration("20220126161645_RemovedQuoteTweets")]
    partial class RemovedQuoteTweets
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TwitterCloneAPI.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(280)
                        .HasColumnType("nvarchar(280)");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TweetId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TweetId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("TwitterCloneAPI.Models.Tweet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<int>("Retweets")
                        .HasColumnType("int");

                    b.Property<DateTime>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<string>("TweetContent")
                        .IsRequired()
                        .HasMaxLength(280)
                        .HasColumnType("nvarchar(280)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Tweets");
                });

            modelBuilder.Entity("TwitterCloneAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("handle")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("profileImgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TwitterCloneAPI.Models.Comment", b =>
                {
                    b.HasOne("TwitterCloneAPI.Models.Tweet", null)
                        .WithMany("Comments")
                        .HasForeignKey("TweetId");
                });

            modelBuilder.Entity("TwitterCloneAPI.Models.Tweet", b =>
                {
                    b.HasOne("TwitterCloneAPI.Models.User", null)
                        .WithMany("Tweets")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("TwitterCloneAPI.Models.Tweet", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("TwitterCloneAPI.Models.User", b =>
                {
                    b.Navigation("Tweets");
                });
#pragma warning restore 612, 618
        }
    }
}
