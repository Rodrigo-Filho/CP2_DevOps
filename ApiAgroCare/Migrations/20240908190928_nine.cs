using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAgroCare.Migrations
{
    /// <inheritdoc />
    public partial class nine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_T_AGROCARE_CONSULTAS_IdUser",
                table: "T_AGROCARE_CONSULTAS");

            migrationBuilder.DropIndex(
                name: "IX_T_AGROCARE_BOVINO_ConsultaID",
                table: "T_AGROCARE_BOVINO");

            migrationBuilder.CreateIndex(
                name: "IX_T_AGROCARE_CONSULTAS_IdUser",
                table: "T_AGROCARE_CONSULTAS",
                column: "IdUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_T_AGROCARE_BOVINO_ConsultaID",
                table: "T_AGROCARE_BOVINO",
                column: "ConsultaID");

            migrationBuilder.AddForeignKey(
                name: "FK_T_AGROCARE_CONSULTAS_T_AGROCARE_BOVINO_IdUser",
                table: "T_AGROCARE_CONSULTAS",
                column: "IdUser",
                principalTable: "T_AGROCARE_BOVINO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_AGROCARE_CONSULTAS_T_AGROCARE_BOVINO_IdUser",
                table: "T_AGROCARE_CONSULTAS");

            migrationBuilder.DropIndex(
                name: "IX_T_AGROCARE_CONSULTAS_IdUser",
                table: "T_AGROCARE_CONSULTAS");

            migrationBuilder.DropIndex(
                name: "IX_T_AGROCARE_BOVINO_ConsultaID",
                table: "T_AGROCARE_BOVINO");

            migrationBuilder.CreateIndex(
                name: "IX_T_AGROCARE_CONSULTAS_IdUser",
                table: "T_AGROCARE_CONSULTAS",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_T_AGROCARE_BOVINO_ConsultaID",
                table: "T_AGROCARE_BOVINO",
                column: "ConsultaID",
                unique: true);
        }
    }
}
