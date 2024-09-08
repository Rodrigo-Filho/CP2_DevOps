using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAgroCare.Migrations
{
    /// <inheritdoc />
    public partial class ten : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_AGROCARE_BOVINO_T_AGROCARE_CONSULTAS_ConsultaID",
                table: "T_AGROCARE_BOVINO");

            migrationBuilder.AlterColumn<long>(
                name: "ConsultaID",
                table: "T_AGROCARE_BOVINO",
                type: "NUMBER(19)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "NUMBER(19)");

            migrationBuilder.AddForeignKey(
                name: "FK_T_AGROCARE_BOVINO_T_AGROCARE_CONSULTAS_ConsultaID",
                table: "T_AGROCARE_BOVINO",
                column: "ConsultaID",
                principalTable: "T_AGROCARE_CONSULTAS",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_AGROCARE_BOVINO_T_AGROCARE_CONSULTAS_ConsultaID",
                table: "T_AGROCARE_BOVINO");

            migrationBuilder.AlterColumn<long>(
                name: "ConsultaID",
                table: "T_AGROCARE_BOVINO",
                type: "NUMBER(19)",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "NUMBER(19)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_T_AGROCARE_BOVINO_T_AGROCARE_CONSULTAS_ConsultaID",
                table: "T_AGROCARE_BOVINO",
                column: "ConsultaID",
                principalTable: "T_AGROCARE_CONSULTAS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
