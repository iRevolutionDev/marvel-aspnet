﻿// <auto-generated />
using System;
using Marvel.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Marvel.Infra.Data.Migrations
{
    [DbContext(typeof(MarvelDbContext))]
    partial class MarvelDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("Marvel.Domain.Entities.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ComicsId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("ResourceUri")
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<int?>("StoriesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ComicsId");

                    b.HasIndex("StoriesId");

                    b.ToTable("Characters", (string)null);
                });

            modelBuilder.Entity("Marvel.Domain.Entities.ComicList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Available")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CollectionUri")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<int>("Returned")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("ComicLists", (string)null);
                });

            modelBuilder.Entity("Marvel.Domain.Entities.ComicSummary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ComicListId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ResourceUri")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ComicListId");

                    b.ToTable("ComicSummaries", (string)null);
                });

            modelBuilder.Entity("Marvel.Domain.Entities.StoriesList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Available")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CollectionUri")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<int>("Returned")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("StoriesLists", (string)null);
                });

            modelBuilder.Entity("Marvel.Domain.Entities.StorySummary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ResourceUri")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("StoriesListId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("StoriesListId");

                    b.ToTable("StorySummaries", (string)null);
                });

            modelBuilder.Entity("Marvel.Domain.Entities.Thumbnail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Thumbnails", (string)null);
                });

            modelBuilder.Entity("Marvel.Domain.Entities.Character", b =>
                {
                    b.HasOne("Marvel.Domain.Entities.ComicList", "Comics")
                        .WithMany()
                        .HasForeignKey("ComicsId");

                    b.HasOne("Marvel.Domain.Entities.StoriesList", "Stories")
                        .WithMany()
                        .HasForeignKey("StoriesId");

                    b.Navigation("Comics");

                    b.Navigation("Stories");
                });

            modelBuilder.Entity("Marvel.Domain.Entities.ComicSummary", b =>
                {
                    b.HasOne("Marvel.Domain.Entities.ComicList", null)
                        .WithMany("Items")
                        .HasForeignKey("ComicListId");
                });

            modelBuilder.Entity("Marvel.Domain.Entities.StorySummary", b =>
                {
                    b.HasOne("Marvel.Domain.Entities.StoriesList", null)
                        .WithMany("Items")
                        .HasForeignKey("StoriesListId");
                });

            modelBuilder.Entity("Marvel.Domain.Entities.Thumbnail", b =>
                {
                    b.HasOne("Marvel.Domain.Entities.Character", null)
                        .WithOne("Thumbnail")
                        .HasForeignKey("Marvel.Domain.Entities.Thumbnail", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Marvel.Domain.Entities.Character", b =>
                {
                    b.Navigation("Thumbnail");
                });

            modelBuilder.Entity("Marvel.Domain.Entities.ComicList", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Marvel.Domain.Entities.StoriesList", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
