using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExerciseA.Implementation.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(nullable: false),
                    OrderId = table.Column<long>(nullable: false),
                    ProductId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "CreatedDate", "CustomerName" },
                values: new object[,]
                {
                    { 1L, new DateTime(2020, 12, 10, 1, 42, 35, 652, DateTimeKind.Local).AddTicks(5080), "Esther Littel" },
                    { 28L, new DateTime(2020, 12, 7, 17, 1, 19, 41, DateTimeKind.Local).AddTicks(5093), "Keith Grimes" },
                    { 29L, new DateTime(2020, 12, 5, 7, 55, 41, 823, DateTimeKind.Local).AddTicks(9831), "Melanie Armstrong" },
                    { 30L, new DateTime(2020, 12, 3, 14, 39, 22, 143, DateTimeKind.Local).AddTicks(6880), "Isaac Mraz" },
                    { 31L, new DateTime(2020, 12, 3, 9, 46, 35, 112, DateTimeKind.Local).AddTicks(8528), "Justin Kautzer" },
                    { 32L, new DateTime(2020, 12, 8, 18, 42, 49, 596, DateTimeKind.Local).AddTicks(2956), "Wilbert Bayer" },
                    { 33L, new DateTime(2020, 12, 3, 6, 36, 50, 911, DateTimeKind.Local).AddTicks(8478), "Gilbert Raynor" },
                    { 34L, new DateTime(2020, 12, 3, 23, 38, 30, 843, DateTimeKind.Local).AddTicks(7269), "Myrtle Funk" },
                    { 36L, new DateTime(2020, 12, 7, 10, 18, 7, 383, DateTimeKind.Local).AddTicks(8306), "Regina Davis" },
                    { 37L, new DateTime(2020, 12, 4, 0, 21, 4, 412, DateTimeKind.Local).AddTicks(6933), "Bryant Schmidt" },
                    { 38L, new DateTime(2020, 12, 4, 16, 14, 17, 864, DateTimeKind.Local).AddTicks(9293), "Hilda Reynolds" },
                    { 27L, new DateTime(2020, 12, 3, 19, 46, 5, 564, DateTimeKind.Local).AddTicks(659), "Bertha Nader" },
                    { 39L, new DateTime(2020, 12, 7, 19, 43, 28, 227, DateTimeKind.Local).AddTicks(816), "Leslie Conroy" },
                    { 41L, new DateTime(2020, 12, 4, 22, 52, 40, 47, DateTimeKind.Local).AddTicks(6540), "Yvette Aufderhar" },
                    { 42L, new DateTime(2020, 12, 7, 14, 40, 27, 678, DateTimeKind.Local).AddTicks(6837), "Lindsay Greenholt" },
                    { 43L, new DateTime(2020, 12, 8, 14, 58, 4, 809, DateTimeKind.Local).AddTicks(5959), "Jackie Luettgen" },
                    { 44L, new DateTime(2020, 12, 7, 8, 59, 43, 486, DateTimeKind.Local).AddTicks(3839), "Kara Dare" },
                    { 45L, new DateTime(2020, 12, 3, 14, 3, 37, 723, DateTimeKind.Local).AddTicks(9332), "Carl Dickens" },
                    { 46L, new DateTime(2020, 12, 6, 8, 46, 21, 147, DateTimeKind.Local).AddTicks(8956), "Archie Schaden" },
                    { 47L, new DateTime(2020, 12, 3, 13, 57, 8, 125, DateTimeKind.Local).AddTicks(4659), "Jean Langworth" },
                    { 48L, new DateTime(2020, 12, 3, 13, 2, 17, 88, DateTimeKind.Local).AddTicks(6800), "Tracey Romaguera" },
                    { 49L, new DateTime(2020, 12, 10, 3, 7, 16, 720, DateTimeKind.Local).AddTicks(5368), "Lorenzo Ondricka" },
                    { 50L, new DateTime(2020, 12, 8, 19, 30, 20, 28, DateTimeKind.Local).AddTicks(3791), "Christina Lowe" },
                    { 40L, new DateTime(2020, 12, 3, 14, 8, 25, 700, DateTimeKind.Local).AddTicks(8806), "Curtis Ullrich" },
                    { 26L, new DateTime(2020, 12, 9, 15, 49, 57, 539, DateTimeKind.Local).AddTicks(7465), "Larry Gleichner" },
                    { 35L, new DateTime(2020, 12, 8, 13, 51, 33, 94, DateTimeKind.Local).AddTicks(5351), "Kristi Parker" },
                    { 24L, new DateTime(2020, 12, 4, 10, 57, 48, 905, DateTimeKind.Local).AddTicks(1270), "Priscilla Kreiger" },
                    { 2L, new DateTime(2020, 12, 8, 11, 59, 11, 923, DateTimeKind.Local).AddTicks(7271), "Noah Hilpert" },
                    { 3L, new DateTime(2020, 12, 9, 4, 27, 7, 245, DateTimeKind.Local).AddTicks(7975), "Caleb Zieme" },
                    { 25L, new DateTime(2020, 12, 3, 16, 15, 51, 436, DateTimeKind.Local).AddTicks(8454), "Wade Stracke" },
                    { 5L, new DateTime(2020, 12, 7, 16, 9, 12, 475, DateTimeKind.Local).AddTicks(5372), "Penny Gottlieb" },
                    { 6L, new DateTime(2020, 12, 7, 2, 7, 31, 336, DateTimeKind.Local).AddTicks(9916), "Gwen Corwin" },
                    { 7L, new DateTime(2020, 12, 5, 2, 41, 21, 610, DateTimeKind.Local).AddTicks(8874), "Flora Schowalter" },
                    { 8L, new DateTime(2020, 12, 6, 8, 48, 46, 178, DateTimeKind.Local).AddTicks(3660), "Cory Nienow" },
                    { 9L, new DateTime(2020, 12, 4, 22, 21, 54, 452, DateTimeKind.Local).AddTicks(2518), "Jody Reynolds" },
                    { 10L, new DateTime(2020, 12, 7, 22, 5, 11, 407, DateTimeKind.Local).AddTicks(962), "Yvette Bednar" },
                    { 11L, new DateTime(2020, 12, 8, 3, 4, 35, 652, DateTimeKind.Local).AddTicks(6707), "Jerome Blanda" },
                    { 12L, new DateTime(2020, 12, 3, 17, 53, 42, 194, DateTimeKind.Local).AddTicks(853), "Silvia Schaden" },
                    { 4L, new DateTime(2020, 12, 9, 20, 42, 25, 687, DateTimeKind.Local).AddTicks(6986), "Lula O'Connell" },
                    { 14L, new DateTime(2020, 12, 3, 14, 8, 58, 855, DateTimeKind.Local).AddTicks(3008), "Jason Torphy" },
                    { 13L, new DateTime(2020, 12, 4, 9, 28, 28, 533, DateTimeKind.Local).AddTicks(9717), "Alton Labadie" },
                    { 23L, new DateTime(2020, 12, 3, 7, 26, 44, 337, DateTimeKind.Local).AddTicks(7414), "Gwen Mills" },
                    { 21L, new DateTime(2020, 12, 6, 4, 28, 19, 107, DateTimeKind.Local).AddTicks(7975), "Carroll Heidenreich" },
                    { 20L, new DateTime(2020, 12, 8, 7, 7, 47, 317, DateTimeKind.Local).AddTicks(47), "Sonya Bailey" },
                    { 19L, new DateTime(2020, 12, 8, 19, 20, 13, 571, DateTimeKind.Local).AddTicks(4278), "Latoya Morar" },
                    { 22L, new DateTime(2020, 12, 10, 1, 15, 55, 701, DateTimeKind.Local).AddTicks(9724), "Gerald Donnelly" },
                    { 17L, new DateTime(2020, 12, 5, 15, 47, 24, 22, DateTimeKind.Local).AddTicks(3608), "Phillip Schamberger" },
                    { 16L, new DateTime(2020, 12, 8, 2, 48, 7, 961, DateTimeKind.Local).AddTicks(7449), "Casey Nicolas" },
                    { 15L, new DateTime(2020, 12, 5, 17, 16, 55, 249, DateTimeKind.Local).AddTicks(4879), "Cody Franecki" },
                    { 18L, new DateTime(2020, 12, 5, 12, 40, 3, 288, DateTimeKind.Local).AddTicks(2429), "Darrell Bode" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 18L, "Licensed Rubber Car", 135 },
                    { 11L, "Sleek Cotton Gloves", 260 },
                    { 17L, "Small Wooden Chips", 36 },
                    { 16L, "Refined Granite Bacon", 159 },
                    { 15L, "Fantastic Plastic Salad", 95 },
                    { 14L, "Incredible Metal Shirt", 234 },
                    { 13L, "Fantastic Cotton Chicken", 36 },
                    { 12L, "Small Concrete Ball", 105 },
                    { 10L, "Unbranded Granite Tuna", 110 },
                    { 5L, "Tasty Cotton Chair", 290 },
                    { 8L, "Tasty Plastic Shoes", 294 },
                    { 7L, "Generic Steel Gloves", 201 },
                    { 6L, "Handmade Cotton Tuna", 27 },
                    { 4L, "Handcrafted Cotton Table", 285 },
                    { 3L, "Refined Granite Keyboard", 69 },
                    { 2L, "Fantastic Wooden Mouse", 239 },
                    { 1L, "Rustic Steel Shirt", 151 },
                    { 19L, "Licensed Metal Shoes", 91 },
                    { 9L, "Gorgeous Rubber Towels", 270 },
                    { 20L, "Ergonomic Soft Computer", 100 }
                });

            migrationBuilder.InsertData(
                table: "OrderDetail",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 3L, 46L, 2L, 46 },
                    { 14L, 50L, 18L, 182 },
                    { 11L, 11L, 16L, 8 },
                    { 4L, 19L, 16L, 50 },
                    { 18L, 8L, 15L, 134 },
                    { 1L, 11L, 14L, 133 },
                    { 2L, 50L, 13L, 198 },
                    { 8L, 2L, 11L, 2 },
                    { 5L, 9L, 11L, 26 },
                    { 17L, 45L, 10L, 137 },
                    { 10L, 17L, 10L, 59 },
                    { 9L, 4L, 10L, 115 },
                    { 6L, 9L, 8L, 17 },
                    { 16L, 1L, 6L, 190 },
                    { 7L, 26L, 6L, 29 },
                    { 19L, 33L, 4L, 73 },
                    { 13L, 17L, 2L, 21 },
                    { 12L, 42L, 2L, 173 },
                    { 15L, 29L, 19L, 186 },
                    { 20L, 21L, 19L, 33 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderId",
                table: "OrderDetail",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ProductId",
                table: "OrderDetail",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
