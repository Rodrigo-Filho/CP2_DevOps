using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAgroCare.Migrations
{
    /// <inheritdoc />
    public partial class five : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bovino_T_AGROCARE_AGROPECUARISTA_UserID",
                table: "Bovino");

            migrationBuilder.DropForeignKey(
                name: "FK_Bovino_T_AGROCARE_CONSULTAS_ConsultaID",
                table: "Bovino");

            migrationBuilder.DropForeignKey(
                name: "FK_T_AGROCARE_TRATAMENTO_Bovino_Idboi",
                table: "T_AGROCARE_TRATAMENTO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bovino",
                table: "Bovino");

            migrationBuilder.RenameTable(
                name: "Bovino",
                newName: "T_AGROCARE_BOVINO");

            migrationBuilder.RenameIndex(
                name: "IX_Bovino_UserID",
                table: "T_AGROCARE_BOVINO",
                newName: "IX_T_AGROCARE_BOVINO_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Bovino_ConsultaID",
                table: "T_AGROCARE_BOVINO",
                newName: "IX_T_AGROCARE_BOVINO_ConsultaID");

            migrationBuilder.AlterColumn<decimal>(
                name: "DoseMedicamentoML",
                table: "T_AGROCARE_TRATAMENTO",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_T_AGROCARE_BOVINO",
                table: "T_AGROCARE_BOVINO",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_T_AGROCARE_BOVINO_T_AGROCARE_AGROPECUARISTA_UserID",
                table: "T_AGROCARE_BOVINO",
                column: "UserID",
                principalTable: "T_AGROCARE_AGROPECUARISTA",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_T_AGROCARE_BOVINO_T_AGROCARE_CONSULTAS_ConsultaID",
                table: "T_AGROCARE_BOVINO",
                column: "ConsultaID",
                principalTable: "T_AGROCARE_CONSULTAS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_T_AGROCARE_TRATAMENTO_T_AGROCARE_BOVINO_Idboi",
                table: "T_AGROCARE_TRATAMENTO",
                column: "Idboi",
                principalTable: "T_AGROCARE_BOVINO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_AGROCARE_BOVINO_T_AGROCARE_AGROPECUARISTA_UserID",
                table: "T_AGROCARE_BOVINO");

            migrationBuilder.DropForeignKey(
                name: "FK_T_AGROCARE_BOVINO_T_AGROCARE_CONSULTAS_ConsultaID",
                table: "T_AGROCARE_BOVINO");

            migrationBuilder.DropForeignKey(
                name: "FK_T_AGROCARE_TRATAMENTO_T_AGROCARE_BOVINO_Idboi",
                table: "T_AGROCARE_TRATAMENTO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_T_AGROCARE_BOVINO",
                table: "T_AGROCARE_BOVINO");

            migrationBuilder.RenameTable(
                name: "T_AGROCARE_BOVINO",
                newName: "Bovino");

            migrationBuilder.RenameIndex(
                name: "IX_T_AGROCARE_BOVINO_UserID",
                table: "Bovino",
                newName: "IX_Bovino_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_T_AGROCARE_BOVINO_ConsultaID",
                table: "Bovino",
                newName: "IX_Bovino_ConsultaID");

            migrationBuilder.AlterColumn<decimal>(
                name: "DoseMedicamentoML",
                table: "T_AGROCARE_TRATAMENTO",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bovino",
                table: "Bovino",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bovino_T_AGROCARE_AGROPECUARISTA_UserID",
                table: "Bovino",
                column: "UserID",
                principalTable: "T_AGROCARE_AGROPECUARISTA",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bovino_T_AGROCARE_CONSULTAS_ConsultaID",
                table: "Bovino",
                column: "ConsultaID",
                principalTable: "T_AGROCARE_CONSULTAS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_T_AGROCARE_TRATAMENTO_Bovino_Idboi",
                table: "T_AGROCARE_TRATAMENTO",
                column: "Idboi",
                principalTable: "Bovino",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
