﻿// <auto-generated />
using System;
using ItemDashboard.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ItemDashboard.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ItemDashboard.Core.Domain.Entities.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Items", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("471d5e7b-e789-4890-96e7-aa2b17dde31e"),
                            CreatedDate = new DateTime(2024, 6, 4, 18, 25, 43, 511, DateTimeKind.Utc),
                            Description = "Duis aliquam convallis nunc. Proin at turpis a pede posuere nonummy. ",
                            Name = "Carolyn",
                            UpdatedDate = new DateTime(2023, 7, 1, 18, 25, 43, 511, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("e86c7ae6-5bcc-4a08-a95b-f870a8f2ca51"),
                            CreatedDate = new DateTime(2023, 12, 15, 18, 25, 43, 511, DateTimeKind.Utc),
                            Description = "Aliquam quis turpis eget elit sodales scelerisque. Mauris sit amet eros. Suspendisse accumsan tortor quis turpis.\\n\\nSed ante. Vivamus tortor. Duis mattis egestas metus.",
                            Name = "Lula",
                            UpdatedDate = new DateTime(2023, 11, 2, 18, 25, 43, 511, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("784e15f9-5989-4706-a719-63e9f188b151"),
                            CreatedDate = new DateTime(2023, 8, 23, 18, 25, 43, 511, DateTimeKind.Utc),
                            Description = "Praesent Id massa Id nisl venenatis lacinia. Aenean sit amet justo. Morbi ut odio.\\n\\nCras mi pede, malesuada in, imperdiet et, commodo vulputate, justo. In blandit ultrices enim. Lorem ipsum dolor sit amet, consectetuer adipiscing elit.",
                            Name = "Catarina",
                            UpdatedDate = new DateTime(2023, 7, 12, 18, 25, 43, 511, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("e4939375-88a8-4368-bc50-0ad2d378a893"),
                            CreatedDate = new DateTime(2024, 3, 30, 18, 25, 43, 511, DateTimeKind.Utc),
                            Description = "Cras non velit nec nisi vulputate nonummy. Maecenas tincIdunt lacus at velit. Vivamus vel nulla eget eros elementum pellentesque.\\n\\nQuisque porta volutpat erat. Quisque erat eros, viverra eget, congue eget, semper rutrum, nulla. Nunc purus.",
                            Name = "Frederica",
                            UpdatedDate = new DateTime(2024, 3, 22, 18, 25, 43, 511, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("eae41b7c-4833-4298-9898-329d737377cd"),
                            CreatedDate = new DateTime(2024, 5, 15, 18, 25, 43, 511, DateTimeKind.Utc),
                            Description = "Aenean lectus. Pellentesque eget nunc. Donec quis orci eget orci vehicula condimentum.\\n\\nCurabitur in libero ut massa volutpat convallis.",
                            Name = "Quintilla",
                            UpdatedDate = new DateTime(2024, 6, 17, 18, 25, 43, 511, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("2347ec74-4868-4fe0-ae60-0f9c7b266b10"),
                            CreatedDate = new DateTime(2024, 5, 7, 18, 25, 43, 511, DateTimeKind.Utc),
                            Description = "In congue. Etiam justo. Etiam pretium iaculis justo.\\n\\nIn hac habitasse platea dictumst. Etiam faucibus cursus urna. Ut tellus.\\n\\nNulla ut erat Id mauris vulputate elementum. Nullam varius. Nulla facilisi.",
                            Name = "Sunny",
                            UpdatedDate = new DateTime(2023, 8, 13, 18, 25, 43, 511, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("ba2c4dab-945a-4329-8589-a433efa0b09e"),
                            CreatedDate = new DateTime(2024, 2, 20, 18, 25, 43, 511, DateTimeKind.Utc),
                            Description = "Sed sagittis. Nam congue, risus semper porta volutpat, quam pede lobortis ligula, sit amet eleifend pede libero quis orci. Nullam molestie nibh in lectus.\\n\\nPellentesque at nulla.",
                            Name = "Jeanelle",
                            UpdatedDate = new DateTime(2023, 10, 19, 18, 25, 43, 511, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("980b0bab-49c4-4e64-8dbb-8666ac46f7e3"),
                            CreatedDate = new DateTime(2024, 2, 19, 18, 25, 43, 511, DateTimeKind.Utc),
                            Description = "Cras non velit nec nisi vulputate nonummy. Maecenas tincIdunt lacus at velit. Vivamus vel nulla eget eros elementum pellentesque.",
                            Name = "Alika",
                            UpdatedDate = new DateTime(2024, 2, 11, 18, 25, 43, 511, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("c5ed85ca-728b-4b66-8599-6c48554f3c7c"),
                            CreatedDate = new DateTime(2024, 4, 30, 18, 25, 43, 511, DateTimeKind.Utc),
                            Description = "Fusce consequat. Nulla nisl. Nunc nisl.\\n\\nDuis bibendum, felis sed interdum venenatis, turpis enim blandit mi, in porttitor pede justo eu massa. Donec dapibus.",
                            Name = "Fannie",
                            UpdatedDate = new DateTime(2024, 1, 5, 18, 25, 43, 511, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("13b845f5-7e8e-4704-aa8e-ce109e5d549d"),
                            CreatedDate = new DateTime(2024, 5, 24, 18, 25, 43, 511, DateTimeKind.Utc),
                            Description = "Suspendisse potenti. In eleifend quam a odio. In hac habitasse platea dictumst.",
                            Name = "Hube",
                            UpdatedDate = new DateTime(2023, 8, 15, 18, 25, 43, 511, DateTimeKind.Utc)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}