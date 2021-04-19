using Microsoft.EntityFrameworkCore.Migrations;

namespace TowerDefense.Migrations
{
    public partial class tower : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AttackCount",
                table: "Towers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CordinateId",
                table: "Towers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Towers_CordinateId",
                table: "Towers",
                column: "CordinateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Towers_Route_CordinateId",
                table: "Towers",
                column: "CordinateId",
                principalTable: "Route",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Towers_Route_CordinateId",
                table: "Towers");

            migrationBuilder.DropIndex(
                name: "IX_Towers_CordinateId",
                table: "Towers");

            migrationBuilder.DropColumn(
                name: "AttackCount",
                table: "Towers");

            migrationBuilder.DropColumn(
                name: "CordinateId",
                table: "Towers");
        }
    }
}
