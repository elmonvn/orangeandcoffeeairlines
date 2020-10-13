using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OCAirLines.Database.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false),
                    Sobrenome = table.Column<string>(nullable: false),
                    TpIdentificacao = table.Column<string>(nullable: false),
                    NrIdentificacao = table.Column<string>(nullable: false),
                    Sexo = table.Column<string>(nullable: true),
                    Endereco = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    UF = table.Column<string>(nullable: true),
                    Pais = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Telefone1 = table.Column<string>(nullable: false),
                    Telefone2 = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cartoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(nullable: false),
                    Bandeira = table.Column<string>(nullable: false),
                    Numero = table.Column<string>(nullable: false),
                    CodSeguranca = table.Column<string>(nullable: false),
                    Vencimento = table.Column<string>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cartoes_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favoritas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(nullable: false),
                    EmpresaId = table.Column<int>(nullable: false),
                    Empresa = table.Column<string>(nullable: false),
                    OrigemId = table.Column<int>(nullable: false),
                    Origem = table.Column<string>(nullable: false),
                    DestinoId = table.Column<int>(nullable: false),
                    Destino = table.Column<string>(nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    DtSaida = table.Column<DateTime>(nullable: false),
                    DtChegada = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favoritas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favoritas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pesquisas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(nullable: false),
                    EmpresaId = table.Column<int>(nullable: false),
                    Empresa = table.Column<string>(nullable: false),
                    OrigemId = table.Column<int>(nullable: false),
                    Origem = table.Column<string>(nullable: false),
                    DestinoId = table.Column<int>(nullable: false),
                    Destino = table.Column<string>(nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    DtSaida = table.Column<DateTime>(nullable: false),
                    DtChegada = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pesquisas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pesquisas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(nullable: false),
                    CartaoId = table.Column<int>(nullable: false),
                    DtCompra = table.Column<DateTime>(nullable: false),
                    QtdParcela = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compras_Cartoes_CartaoId",
                        column: x => x.CartaoId,
                        principalTable: "Cartoes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Compras_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CompraItens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompraId = table.Column<int>(nullable: false),
                    EmpresaId = table.Column<int>(nullable: false),
                    Empresa = table.Column<string>(nullable: false),
                    OrigemId = table.Column<int>(nullable: false),
                    Origem = table.Column<string>(nullable: false),
                    DestinoId = table.Column<int>(nullable: false),
                    Destino = table.Column<string>(nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    DtSaida = table.Column<DateTime>(nullable: false),
                    DtChegada = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompraItens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompraItens_Compras_CompraId",
                        column: x => x.CompraId,
                        principalTable: "Compras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cartoes_UsuarioId",
                table: "Cartoes",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_CompraItens_CompraId",
                table: "CompraItens",
                column: "CompraId");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_CartaoId",
                table: "Compras",
                column: "CartaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_UsuarioId",
                table: "Compras",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Favoritas_UsuarioId",
                table: "Favoritas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Pesquisas_UsuarioId",
                table: "Pesquisas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompraItens");

            migrationBuilder.DropTable(
                name: "Favoritas");

            migrationBuilder.DropTable(
                name: "Pesquisas");

            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "Cartoes");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
