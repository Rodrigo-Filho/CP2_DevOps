using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAgroCare.Migrations
{
    /// <inheritdoc />
    public partial class fourteen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_AGROCARE_CONSULTAS_T_AGROCARE_AGROPECUARISTA_UserID",
                table: "T_AGROCARE_CONSULTAS");

            migrationBuilder.DropIndex(
                name: "IX_T_AGROCARE_CONSULTAS_UserID",
                table: "T_AGROCARE_CONSULTAS");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "T_AGROCARE_CONSULTAS");

            migrationBuilder.CreateIndex(
                name: "IX_T_AGROCARE_CONSULTAS_IdUser",
                table: "T_AGROCARE_CONSULTAS",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_T_AGROCARE_CONSULTAS_T_AGROCARE_AGROPECUARISTA_IdUser",
                table: "T_AGROCARE_CONSULTAS",
                column: "IdUser",
                principalTable: "T_AGROCARE_AGROPECUARISTA",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_AGROCARE_CONSULTAS_T_AGROCARE_AGROPECUARISTA_IdUser",
                table: "T_AGROCARE_CONSULTAS");

            migrationBuilder.DropIndex(
                name: "IX_T_AGROCARE_CONSULTAS_IdUser",
                table: "T_AGROCARE_CONSULTAS");

            migrationBuilder.AddColumn<long>(
                name: "UserID",
                table: "T_AGROCARE_CONSULTAS",
                type: "NUMBER(19)",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_T_AGROCARE_CONSULTAS_UserID",
                table: "T_AGROCARE_CONSULTAS",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_T_AGROCARE_CONSULTAS_T_AGROCARE_AGROPECUARISTA_UserID",
                table: "T_AGROCARE_CONSULTAS",
                column: "UserID",
                principalTable: "T_AGROCARE_AGROPECUARISTA",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
