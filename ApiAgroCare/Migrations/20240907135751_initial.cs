using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAgroCare.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_AGROCARE_AGROPECUARISTA",
                columns: table => new
                {
                    ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Number = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    Endereco = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NumerosAnimais = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Password = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Status = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    Planos = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_AGROCARE_AGROPECUARISTA", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "T_AGROCARE_VETERINARIO",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NumCrmv = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Especialidade = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Telefone = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Password = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_AGROCARE_VETERINARIO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Avaliacoes",
                columns: table => new
                {
                    IdAvaliacoes = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    QtdEstrelas = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    MsgAvaliacao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataAvaliacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ConsultaID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    VeterinarioID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    UserID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacoes", x => x.IdAvaliacoes);
                    table.ForeignKey(
                        name: "FK_Avaliacoes_T_AGROCARE_AGROPECUARISTA_UserID",
                        column: x => x.UserID,
                        principalTable: "T_AGROCARE_AGROPECUARISTA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Avaliacoes_T_AGROCARE_VETERINARIO_VeterinarioID",
                        column: x => x.VeterinarioID,
                        principalTable: "T_AGROCARE_VETERINARIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bovino",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Saude = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    UltimoDiaAtualizacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    SaudeBoi = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    UserID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ConsultaID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bovino", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bovino_T_AGROCARE_AGROPECUARISTA_UserID",
                        column: x => x.UserID,
                        principalTable: "T_AGROCARE_AGROPECUARISTA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_AGROCARE_CONSULTAS",
                columns: table => new
                {
                    ID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Observacao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataConsulta = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    IdBoi = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    IdUser = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    IdVeterinario = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_AGROCARE_CONSULTAS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_T_AGROCARE_CONSULTAS_Bovino_IdBoi",
                        column: x => x.IdBoi,
                        principalTable: "Bovino",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_AGROCARE_CONSULTAS_T_AGROCARE_AGROPECUARISTA_IdUser",
                        column: x => x.IdUser,
                        principalTable: "T_AGROCARE_AGROPECUARISTA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_AGROCARE_CONSULTAS_T_AGROCARE_VETERINARIO_IdVeterinario",
                        column: x => x.IdVeterinario,
                        principalTable: "T_AGROCARE_VETERINARIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_AGROCARE_TRATAMENTO",
                columns: table => new
                {
                    IdTratamento = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TipoTratamento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NomeMedicamento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DoseMedicamentoML = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    DescricaoTratamento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ViaAdministracao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DuracaoTratamento = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EfeitoTratamento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ObservacaoTratamento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataTratamento = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    VeterinarioID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    ConsultaID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    UserID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_AGROCARE_TRATAMENTO", x => x.IdTratamento);
                    table.ForeignKey(
                        name: "FK_T_AGROCARE_TRATAMENTO_T_AGROCARE_AGROPECUARISTA_UserID",
                        column: x => x.UserID,
                        principalTable: "T_AGROCARE_AGROPECUARISTA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_AGROCARE_TRATAMENTO_T_AGROCARE_CONSULTAS_ConsultaID",
                        column: x => x.ConsultaID,
                        principalTable: "T_AGROCARE_CONSULTAS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_AGROCARE_TRATAMENTO_T_AGROCARE_VETERINARIO_VeterinarioID",
                        column: x => x.VeterinarioID,
                        principalTable: "T_AGROCARE_VETERINARIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_ConsultaID",
                table: "Avaliacoes",
                column: "ConsultaID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_UserID",
                table: "Avaliacoes",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_VeterinarioID",
                table: "Avaliacoes",
                column: "VeterinarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Bovino_ConsultaID",
                table: "Bovino",
                column: "ConsultaID");

            migrationBuilder.CreateIndex(
                name: "IX_Bovino_UserID",
                table: "Bovino",
                column: "UserID");

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
                name: "IX_T_AGROCARE_CONSULTAS_IdVeterinario",
                table: "T_AGROCARE_CONSULTAS",
                column: "IdVeterinario");

            migrationBuilder.CreateIndex(
                name: "IX_T_AGROCARE_TRATAMENTO_ConsultaID",
                table: "T_AGROCARE_TRATAMENTO",
                column: "ConsultaID");

            migrationBuilder.CreateIndex(
                name: "IX_T_AGROCARE_TRATAMENTO_UserID",
                table: "T_AGROCARE_TRATAMENTO",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_T_AGROCARE_TRATAMENTO_VeterinarioID",
                table: "T_AGROCARE_TRATAMENTO",
                column: "VeterinarioID");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacoes_T_AGROCARE_CONSULTAS_ConsultaID",
                table: "Avaliacoes",
                column: "ConsultaID",
                principalTable: "T_AGROCARE_CONSULTAS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bovino_T_AGROCARE_CONSULTAS_ConsultaID",
                table: "Bovino",
                column: "ConsultaID",
                principalTable: "T_AGROCARE_CONSULTAS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bovino_T_AGROCARE_AGROPECUARISTA_UserID",
                table: "Bovino");

            migrationBuilder.DropForeignKey(
                name: "FK_T_AGROCARE_CONSULTAS_T_AGROCARE_AGROPECUARISTA_IdUser",
                table: "T_AGROCARE_CONSULTAS");

            migrationBuilder.DropForeignKey(
                name: "FK_Bovino_T_AGROCARE_CONSULTAS_ConsultaID",
                table: "Bovino");

            migrationBuilder.DropTable(
                name: "Avaliacoes");

            migrationBuilder.DropTable(
                name: "T_AGROCARE_TRATAMENTO");

            migrationBuilder.DropTable(
                name: "T_AGROCARE_AGROPECUARISTA");

            migrationBuilder.DropTable(
                name: "T_AGROCARE_CONSULTAS");

            migrationBuilder.DropTable(
                name: "Bovino");

            migrationBuilder.DropTable(
                name: "T_AGROCARE_VETERINARIO");
        }
    }
}
