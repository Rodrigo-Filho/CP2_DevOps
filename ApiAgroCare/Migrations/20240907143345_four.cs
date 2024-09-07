using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAgroCare.Migrations
{
    /// <inheritdoc />
    public partial class four : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "DoseMedicamentoML",
                table: "T_AGROCARE_TRATAMENTO",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AddColumn<long>(
                name: "Idboi",
                table: "T_AGROCARE_TRATAMENTO",
                type: "NUMBER(19)",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_T_AGROCARE_TRATAMENTO_Idboi",
                table: "T_AGROCARE_TRATAMENTO",
                column: "Idboi");

            migrationBuilder.AddForeignKey(
                name: "FK_T_AGROCARE_TRATAMENTO_Bovino_Idboi",
                table: "T_AGROCARE_TRATAMENTO",
                column: "Idboi",
                principalTable: "Bovino",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_AGROCARE_TRATAMENTO_Bovino_Idboi",
                table: "T_AGROCARE_TRATAMENTO");

            migrationBuilder.DropIndex(
                name: "IX_T_AGROCARE_TRATAMENTO_Idboi",
                table: "T_AGROCARE_TRATAMENTO");

            migrationBuilder.DropColumn(
                name: "Idboi",
                table: "T_AGROCARE_TRATAMENTO");

            migrationBuilder.AlterColumn<decimal>(
                name: "DoseMedicamentoML",
                table: "T_AGROCARE_TRATAMENTO",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");
        }
    }
}
