using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Admin.Data.Migrations
{
    /// <inheritdoc />
    public partial class AuctionsDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auctions",
                columns: table => new
                {
                    AuctionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyerId = table.Column<int>(type: "int", nullable: false),
                    HighestBids = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuctionName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AuctionStartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    AuctionStartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    TimeBtwItemChange = table.Column<TimeSpan>(type: "time", nullable: false),
                    AuctionItems = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuctionStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auctions", x => x.AuctionId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auctions");
        }
    }
}
