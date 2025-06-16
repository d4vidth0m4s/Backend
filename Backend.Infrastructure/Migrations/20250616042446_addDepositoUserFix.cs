using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addDepositoUserFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Depositos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Depositos_UserId",
                table: "Depositos",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Depositos_Usuarios_UserId",
                table: "Depositos",
                column: "UserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Depositos_Usuarios_UserId",
                table: "Depositos");

            migrationBuilder.DropIndex(
                name: "IX_Depositos_UserId",
                table: "Depositos");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Depositos");
        }
    }
}
