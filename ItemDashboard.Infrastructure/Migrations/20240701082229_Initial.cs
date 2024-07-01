using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ItemDashboard.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CreatedDate", "Description", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("13b845f5-7e8e-4704-aa8e-ce109e5d549d"), new DateTime(2024, 5, 24, 18, 25, 43, 511, DateTimeKind.Utc), "Suspendisse potenti. In eleifend quam a odio. In hac habitasse platea dictumst.", "Hube", new DateTime(2023, 8, 15, 18, 25, 43, 511, DateTimeKind.Utc) },
                    { new Guid("2347ec74-4868-4fe0-ae60-0f9c7b266b10"), new DateTime(2024, 5, 7, 18, 25, 43, 511, DateTimeKind.Utc), "In congue. Etiam justo. Etiam pretium iaculis justo.\\n\\nIn hac habitasse platea dictumst. Etiam faucibus cursus urna. Ut tellus.\\n\\nNulla ut erat Id mauris vulputate elementum. Nullam varius. Nulla facilisi.", "Sunny", new DateTime(2023, 8, 13, 18, 25, 43, 511, DateTimeKind.Utc) },
                    { new Guid("471d5e7b-e789-4890-96e7-aa2b17dde31e"), new DateTime(2024, 6, 4, 18, 25, 43, 511, DateTimeKind.Utc), "Duis aliquam convallis nunc. Proin at turpis a pede posuere nonummy. ", "Carolyn", new DateTime(2023, 7, 1, 18, 25, 43, 511, DateTimeKind.Utc) },
                    { new Guid("784e15f9-5989-4706-a719-63e9f188b151"), new DateTime(2023, 8, 23, 18, 25, 43, 511, DateTimeKind.Utc), "Praesent Id massa Id nisl venenatis lacinia. Aenean sit amet justo. Morbi ut odio.\\n\\nCras mi pede, malesuada in, imperdiet et, commodo vulputate, justo. In blandit ultrices enim. Lorem ipsum dolor sit amet, consectetuer adipiscing elit.", "Catarina", new DateTime(2023, 7, 12, 18, 25, 43, 511, DateTimeKind.Utc) },
                    { new Guid("980b0bab-49c4-4e64-8dbb-8666ac46f7e3"), new DateTime(2024, 2, 19, 18, 25, 43, 511, DateTimeKind.Utc), "Cras non velit nec nisi vulputate nonummy. Maecenas tincIdunt lacus at velit. Vivamus vel nulla eget eros elementum pellentesque.", "Alika", new DateTime(2024, 2, 11, 18, 25, 43, 511, DateTimeKind.Utc) },
                    { new Guid("ba2c4dab-945a-4329-8589-a433efa0b09e"), new DateTime(2024, 2, 20, 18, 25, 43, 511, DateTimeKind.Utc), "Sed sagittis. Nam congue, risus semper porta volutpat, quam pede lobortis ligula, sit amet eleifend pede libero quis orci. Nullam molestie nibh in lectus.\\n\\nPellentesque at nulla.", "Jeanelle", new DateTime(2023, 10, 19, 18, 25, 43, 511, DateTimeKind.Utc) },
                    { new Guid("c5ed85ca-728b-4b66-8599-6c48554f3c7c"), new DateTime(2024, 4, 30, 18, 25, 43, 511, DateTimeKind.Utc), "Fusce consequat. Nulla nisl. Nunc nisl.\\n\\nDuis bibendum, felis sed interdum venenatis, turpis enim blandit mi, in porttitor pede justo eu massa. Donec dapibus.", "Fannie", new DateTime(2024, 1, 5, 18, 25, 43, 511, DateTimeKind.Utc) },
                    { new Guid("e4939375-88a8-4368-bc50-0ad2d378a893"), new DateTime(2024, 3, 30, 18, 25, 43, 511, DateTimeKind.Utc), "Cras non velit nec nisi vulputate nonummy. Maecenas tincIdunt lacus at velit. Vivamus vel nulla eget eros elementum pellentesque.\\n\\nQuisque porta volutpat erat. Quisque erat eros, viverra eget, congue eget, semper rutrum, nulla. Nunc purus.", "Frederica", new DateTime(2024, 3, 22, 18, 25, 43, 511, DateTimeKind.Utc) },
                    { new Guid("e86c7ae6-5bcc-4a08-a95b-f870a8f2ca51"), new DateTime(2023, 12, 15, 18, 25, 43, 511, DateTimeKind.Utc), "Aliquam quis turpis eget elit sodales scelerisque. Mauris sit amet eros. Suspendisse accumsan tortor quis turpis.\\n\\nSed ante. Vivamus tortor. Duis mattis egestas metus.", "Lula", new DateTime(2023, 11, 2, 18, 25, 43, 511, DateTimeKind.Utc) },
                    { new Guid("eae41b7c-4833-4298-9898-329d737377cd"), new DateTime(2024, 5, 15, 18, 25, 43, 511, DateTimeKind.Utc), "Aenean lectus. Pellentesque eget nunc. Donec quis orci eget orci vehicula condimentum.\\n\\nCurabitur in libero ut massa volutpat convallis.", "Quintilla", new DateTime(2024, 6, 17, 18, 25, 43, 511, DateTimeKind.Utc) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
