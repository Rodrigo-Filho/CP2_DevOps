using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAgroCare.Migrations
{
    /// <inheritdoc />
    public partial class twelve : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_AGROCARE_CONSULTAS_T_AGROCARE_AGROPECUARISTA_IdUser",
                table: "T_AGROCARE_CONSULTAS");

            migrationBuilder.DropForeignKey(
                name: "FK_T_AGROCARE_CONSULTAS_T_AGROCARE_BOVINO_IdBoi",
                table: "T_AGROCARE_CONSULTAS");

            migrationBuilder.DropIndex(
                name: "IX_T_AGROCARE_CONSULTAS_IdBoi",
                table: "T_AGROCARE_CONSULTAS");

            migrationBuilder.DropIndex(
                name: "IX_T_AGROCARE_CONSULTAS_IdUser",
                table: "T_AGROCARE_CONSULTAS");

            migrationBuilder.DropIndex(
                name: "IX_T_AGROCARE_BOVINO_ConsultaID",
                table: "T_AGROCARE_BOVINO");

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

            migrationBuilder.CreateIndex(
                name: "IX_T_AGROCARE_BOVINO_ConsultaID",
                table: "T_AGROCARE_BOVINO",
                column: "ConsultaID",
                unique: true,
                filter: "\"ConsultaID\" IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_T_AGROCARE_CONSULTAS_T_AGROCARE_AGROPECUARISTA_UserID",
                table: "T_AGROCARE_CONSULTAS",
                column: "UserID",
                principalTable: "T_AGROCARE_AGROPECUARISTA",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_AGROCARE_CONSULTAS_T_AGROCARE_AGROPECUARISTA_UserID",
                table: "T_AGROCARE_CONSULTAS");

            migrationBuilder.DropIndex(
                name: "IX_T_AGROCARE_CONSULTAS_UserID",
                table: "T_AGROCARE_CONSULTAS");

            migrationBuilder.DropIndex(
                name: "IX_T_AGROCARE_BOVINO_ConsultaID",
                table: "T_AGROCARE_BOVINO");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "T_AGROCARE_CONSULTAS");

            migrationBuilder.CreateIndex(
                name: "IX_T_AGROCARE_CONSULTAS_IdBoi",
                table: "T_AGROCARE_CONSULTAS",
                column: "IdBoi",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_T_AGROCARE_CONSULTAS_IdUser",
                table: "T_AGROCARE_CONSULTAS",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_T_AGROCARE_BOVINO_ConsultaID",
                table: "T_AGROCARE_BOVINO",
                column: "ConsultaID");

            migrationBuilder.AddForeignKey(
                name: "FK_T_AGROCARE_CONSULTAS_T_AGROCARE_AGROPECUARISTA_IdUser",
                table: "T_AGROCARE_CONSULTAS",
                column: "IdUser",
                principalTable: "T_AGROCARE_AGROPECUARISTA",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_T_AGROCARE_CONSULTAS_T_AGROCARE_BOVINO_IdBoi",
                table: "T_AGROCARE_CONSULTAS",
                column: "IdBoi",
                principalTable: "T_AGROCARE_BOVINO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
