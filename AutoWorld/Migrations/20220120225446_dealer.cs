using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoWorld.Migrations
{
    public partial class dealer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DealerAutoID",
                table: "Car",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DealerID",
                table: "Car",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DealerAuto",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DealerAuto", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_DealerAutoID",
                table: "Car",
                column: "DealerAutoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_DealerAuto_DealerAutoID",
                table: "Car",
                column: "DealerAutoID",
                principalTable: "DealerAuto",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_DealerAuto_DealerAutoID",
                table: "Car");

            migrationBuilder.DropTable(
                name: "DealerAuto");

            migrationBuilder.DropIndex(
                name: "IX_Car_DealerAutoID",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "DealerAutoID",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "DealerID",
                table: "Car");
        }
    }
}
