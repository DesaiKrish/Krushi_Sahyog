using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulkyWeb.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    createdat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    photopath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    admin_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    adminrights = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.admin_id);
                    table.ForeignKey(
                        name: "FK_Admin_User_user_id",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Crop",
                columns: table => new
                {
                    c_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    farmerid = table.Column<int>(type: "int", nullable: false),
                    cname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    baseprice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    auctiondeadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    desp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    photopath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crop", x => x.c_id);
                    table.ForeignKey(
                        name: "FK_Crop_User_farmerid",
                        column: x => x.farmerid,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bids",
                columns: table => new
                {
                    b_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_id = table.Column<int>(type: "int", nullable: false),
                    buyer_id = table.Column<int>(type: "int", nullable: false),
                    bidamount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    bidtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cropc_id = table.Column<int>(type: "int", nullable: false),
                    Buyerid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bids", x => x.b_id);
                    table.ForeignKey(
                        name: "FK_Bids_Crop_Cropc_id",
                        column: x => x.Cropc_id,
                        principalTable: "Crop",
                        principalColumn: "c_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bids_User_Buyerid",
                        column: x => x.Buyerid,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admin_user_id",
                table: "Admin",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_Buyerid",
                table: "Bids",
                column: "Buyerid");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_Cropc_id",
                table: "Bids",
                column: "Cropc_id");

            migrationBuilder.CreateIndex(
                name: "IX_Crop_farmerid",
                table: "Crop",
                column: "farmerid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Bids");

            migrationBuilder.DropTable(
                name: "Crop");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
