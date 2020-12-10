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
                name: "UserInfo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 30, nullable: true),
                    LastName = table.Column<string>(maxLength: 30, nullable: true),
                    UserName = table.Column<string>(maxLength: 30, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 20, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.Id);
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
                    { 1L, new DateTime(2020, 12, 3, 11, 9, 44, 554, DateTimeKind.Local).AddTicks(900), "Juan Toy" },
                    { 28L, new DateTime(2020, 12, 10, 0, 28, 15, 111, DateTimeKind.Local).AddTicks(5267), "Annette Mohr" },
                    { 29L, new DateTime(2020, 12, 4, 10, 17, 30, 743, DateTimeKind.Local).AddTicks(7212), "Terri Farrell" },
                    { 30L, new DateTime(2020, 12, 8, 17, 19, 51, 736, DateTimeKind.Local).AddTicks(9708), "Nellie Ruecker" },
                    { 31L, new DateTime(2020, 12, 8, 1, 32, 39, 850, DateTimeKind.Local).AddTicks(2047), "Eleanor Rodriguez" },
                    { 32L, new DateTime(2020, 12, 7, 5, 50, 11, 1, DateTimeKind.Local).AddTicks(5815), "Mabel Bogisich" },
                    { 33L, new DateTime(2020, 12, 9, 21, 39, 17, 710, DateTimeKind.Local).AddTicks(728), "Evelyn Pfeffer" },
                    { 34L, new DateTime(2020, 12, 6, 20, 57, 41, 349, DateTimeKind.Local).AddTicks(7708), "Erik Wolf" },
                    { 35L, new DateTime(2020, 12, 5, 12, 33, 57, 604, DateTimeKind.Local).AddTicks(1009), "Lila Moore" },
                    { 36L, new DateTime(2020, 12, 6, 12, 30, 46, 653, DateTimeKind.Local).AddTicks(2632), "Emilio O'Connell" },
                    { 37L, new DateTime(2020, 12, 4, 18, 29, 55, 46, DateTimeKind.Local).AddTicks(4888), "Jaime Greenholt" },
                    { 27L, new DateTime(2020, 12, 6, 23, 4, 20, 902, DateTimeKind.Local).AddTicks(2066), "Francis Herzog" },
                    { 39L, new DateTime(2020, 12, 4, 3, 18, 54, 46, DateTimeKind.Local).AddTicks(4533), "Matt Moen" },
                    { 41L, new DateTime(2020, 12, 6, 11, 2, 41, 558, DateTimeKind.Local).AddTicks(1827), "Pat Thiel" },
                    { 42L, new DateTime(2020, 12, 8, 20, 3, 49, 572, DateTimeKind.Local).AddTicks(851), "Angel Wyman" },
                    { 43L, new DateTime(2020, 12, 8, 15, 18, 50, 749, DateTimeKind.Local).AddTicks(5656), "Marcella Reichel" },
                    { 44L, new DateTime(2020, 12, 6, 1, 32, 13, 460, DateTimeKind.Local).AddTicks(9317), "Mae Koepp" },
                    { 45L, new DateTime(2020, 12, 6, 4, 29, 14, 310, DateTimeKind.Local).AddTicks(6423), "Nina Bergstrom" },
                    { 46L, new DateTime(2020, 12, 6, 21, 40, 29, 459, DateTimeKind.Local).AddTicks(7131), "Vanessa Kub" },
                    { 47L, new DateTime(2020, 12, 4, 3, 38, 17, 953, DateTimeKind.Local).AddTicks(1365), "Francis Hayes" },
                    { 48L, new DateTime(2020, 12, 3, 20, 29, 40, 965, DateTimeKind.Local).AddTicks(2022), "Lucia Lebsack" },
                    { 49L, new DateTime(2020, 12, 4, 4, 9, 57, 451, DateTimeKind.Local).AddTicks(7945), "Luther Hudson" },
                    { 50L, new DateTime(2020, 12, 9, 12, 42, 47, 471, DateTimeKind.Local).AddTicks(6438), "Mack Pfeffer" },
                    { 40L, new DateTime(2020, 12, 5, 1, 51, 8, 212, DateTimeKind.Local).AddTicks(9003), "Vanessa Roberts" },
                    { 26L, new DateTime(2020, 12, 3, 23, 25, 22, 298, DateTimeKind.Local).AddTicks(5001), "Sheila Thompson" },
                    { 38L, new DateTime(2020, 12, 3, 19, 15, 50, 275, DateTimeKind.Local).AddTicks(503), "Kellie Padberg" },
                    { 24L, new DateTime(2020, 12, 5, 19, 3, 44, 980, DateTimeKind.Local).AddTicks(6878), "Kyle Klein" },
                    { 25L, new DateTime(2020, 12, 7, 1, 44, 11, 763, DateTimeKind.Local).AddTicks(6360), "Cheryl Walter" },
                    { 2L, new DateTime(2020, 12, 8, 12, 34, 12, 478, DateTimeKind.Local).AddTicks(4990), "Dominic Haag" },
                    { 3L, new DateTime(2020, 12, 5, 10, 48, 31, 717, DateTimeKind.Local).AddTicks(3798), "Grady Tromp" },
                    { 4L, new DateTime(2020, 12, 6, 5, 1, 41, 328, DateTimeKind.Local).AddTicks(5105), "Tasha Block" },
                    { 5L, new DateTime(2020, 12, 3, 19, 2, 1, 262, DateTimeKind.Local).AddTicks(4679), "Israel Hand" },
                    { 6L, new DateTime(2020, 12, 9, 8, 20, 30, 697, DateTimeKind.Local).AddTicks(9461), "Kevin Deckow" },
                    { 7L, new DateTime(2020, 12, 7, 21, 5, 25, 816, DateTimeKind.Local).AddTicks(1400), "Michelle Paucek" },
                    { 8L, new DateTime(2020, 12, 3, 13, 31, 7, 453, DateTimeKind.Local).AddTicks(3530), "Terence Zulauf" },
                    { 10L, new DateTime(2020, 12, 4, 17, 11, 23, 55, DateTimeKind.Local).AddTicks(4072), "Mindy Klocko" },
                    { 11L, new DateTime(2020, 12, 4, 11, 10, 33, 802, DateTimeKind.Local).AddTicks(7200), "Tyrone Haag" },
                    { 12L, new DateTime(2020, 12, 9, 15, 34, 9, 775, DateTimeKind.Local).AddTicks(3699), "Steven Volkman" },
                    { 9L, new DateTime(2020, 12, 6, 9, 10, 0, 374, DateTimeKind.Local).AddTicks(241), "Kathryn Murray" },
                    { 22L, new DateTime(2020, 12, 9, 19, 36, 46, 64, DateTimeKind.Local).AddTicks(8006), "Ruben Lubowitz" },
                    { 14L, new DateTime(2020, 12, 4, 2, 3, 52, 96, DateTimeKind.Local).AddTicks(6391), "Lorenzo Senger" },
                    { 15L, new DateTime(2020, 12, 5, 16, 29, 40, 676, DateTimeKind.Local).AddTicks(8230), "Pat Cummerata" },
                    { 16L, new DateTime(2020, 12, 8, 23, 45, 20, 149, DateTimeKind.Local).AddTicks(603), "Ann Pfeffer" },
                    { 17L, new DateTime(2020, 12, 8, 23, 14, 49, 702, DateTimeKind.Local).AddTicks(8710), "Albert Gerlach" },
                    { 18L, new DateTime(2020, 12, 4, 17, 10, 16, 989, DateTimeKind.Local).AddTicks(4806), "Glenda Barrows" },
                    { 19L, new DateTime(2020, 12, 3, 12, 45, 56, 860, DateTimeKind.Local).AddTicks(3404), "Mack Howell" },
                    { 20L, new DateTime(2020, 12, 7, 14, 47, 26, 150, DateTimeKind.Local).AddTicks(4095), "Blanca Brakus" },
                    { 21L, new DateTime(2020, 12, 3, 16, 26, 24, 567, DateTimeKind.Local).AddTicks(5337), "Jim Mayer" },
                    { 13L, new DateTime(2020, 12, 9, 15, 17, 33, 130, DateTimeKind.Local).AddTicks(6914), "Christina Roob" },
                    { 23L, new DateTime(2020, 12, 4, 7, 25, 8, 234, DateTimeKind.Local).AddTicks(6562), "Lila Nienow" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 13L, "Sleek Wooden Shoes", 27 },
                    { 14L, "Unbranded Rubber Cheese", 146 },
                    { 15L, "Practical Granite Tuna", 96 },
                    { 16L, "Gorgeous Metal Hat", 67 },
                    { 20L, "Licensed Concrete Table", 212 },
                    { 18L, "Ergonomic Concrete Sausages", 171 },
                    { 19L, "Intelligent Fresh Shirt", 105 },
                    { 12L, "Ergonomic Steel Bacon", 88 },
                    { 17L, "Licensed Granite Fish", 92 },
                    { 11L, "Licensed Concrete Ball", 205 },
                    { 1L, "Generic Plastic Chips", 133 },
                    { 9L, "Small Fresh Table", 94 },
                    { 8L, "Ergonomic Steel Fish", 270 },
                    { 7L, "Licensed Wooden Soap", 177 },
                    { 6L, "Awesome Wooden Salad", 158 },
                    { 5L, "Small Metal Cheese", 52 },
                    { 4L, "Intelligent Rubber Towels", 44 },
                    { 3L, "Gorgeous Granite Table", 231 },
                    { 2L, "Sleek Fresh Bike", 179 },
                    { 10L, "Intelligent Granite Table", 264 }
                });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "Id", "CreatedDate", "Email", "FirstName", "LastName", "Password", "UserName" },
                values: new object[,]
                {
                    { 4L, new DateTime(2020, 12, 3, 20, 12, 9, 616, DateTimeKind.Local).AddTicks(4428), "Arne42@gmail.com", "Clair", "Ziemann", "1_Qd1c0x5d", "Breana_Boyle" },
                    { 1L, new DateTime(2020, 12, 3, 23, 19, 14, 324, DateTimeKind.Local).AddTicks(4877), "Cara.Kemmer48@hotmail.com", "Fiona", "O'Keefe", "rPHSr8F5Ug", "Xander_Gaylord20" },
                    { 2L, new DateTime(2020, 12, 4, 3, 12, 43, 155, DateTimeKind.Local).AddTicks(3056), "Rick_Schneider@yahoo.com", "Nova", "Mitchell", "51QiQ4tUk2", "Frederick29" },
                    { 3L, new DateTime(2020, 12, 10, 4, 23, 2, 657, DateTimeKind.Local).AddTicks(8530), "Korey.Kassulke@gmail.com", "Emile", "Bogan", "mYWPvNaiNs", "Burley64" },
                    { 5L, new DateTime(2020, 12, 4, 0, 36, 4, 58, DateTimeKind.Local).AddTicks(6463), "Luciano39@yahoo.com", "Bill", "Conn", "HCu7rSuVME", "Bret_Windler46" }
                });

            migrationBuilder.InsertData(
                table: "OrderDetail",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 6L, 38L, 1L, 143 },
                    { 8L, 1L, 19L, 73 },
                    { 5L, 4L, 19L, 38 },
                    { 2L, 32L, 19L, 183 },
                    { 9L, 12L, 18L, 81 },
                    { 11L, 9L, 17L, 90 },
                    { 12L, 6L, 16L, 198 },
                    { 7L, 2L, 16L, 74 },
                    { 19L, 38L, 13L, 77 },
                    { 17L, 16L, 11L, 75 },
                    { 16L, 49L, 10L, 21 },
                    { 4L, 4L, 9L, 141 },
                    { 20L, 26L, 8L, 3 },
                    { 14L, 8L, 6L, 177 },
                    { 18L, 15L, 2L, 139 },
                    { 15L, 24L, 2L, 187 },
                    { 10L, 20L, 2L, 119 },
                    { 3L, 3L, 2L, 190 },
                    { 1L, 32L, 20L, 22 },
                    { 13L, 41L, 20L, 57 }
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
                name: "UserInfo");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
