using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAgroCare.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_AGROCARE_CONSULTAS_Bovino_IdBoi",
                table: "T_AGROCARE_CONSULTAS");

            migrationBuilder.DropIndex(
                name: "IX_T_AGROCARE_CONSULTAS_IdBoi",
                table: "T_AGROCARE_CONSULTAS");

            migrationBuilder.DropIndex(
                name: "IX_Bovino_ConsultaID",
                table: "Bovino");

            migrationBuilder.AlterColumn<decimal>(
                name: "DoseMedicamentoML",
                table: "T_AGROCARE_TRATAMENTO",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.CreateIndex(
                name: "IX_Bovino_ConsultaID",
                table: "Bovino",
                column: "ConsultaID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bovino_ConsultaID",
                table: "Bovino");

            migrationBuilder.AlterColumn<decimal>(
                name: "DoseMedicamentoML",
                table: "T_AGROCARE_TRATAMENTO",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.CreateIndex(
                name: "IX_T_AGROCARE_CONSULTAS_IdBoi",
                table: "T_AGROCARE_CONSULTAS",
                column: "IdBoi",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bovino_ConsultaID",
                table: "Bovino",
                column: "ConsultaID");

            migrationBuilder.AddForeignKey(
                name: "FK_T_AGROCARE_CONSULTAS_Bovino_IdBoi",
                table: "T_AGROCARE_CONSULTAS",
                column: "IdBoi",
                principalTable: "Bovino",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
