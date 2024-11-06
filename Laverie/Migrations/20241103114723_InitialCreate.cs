using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Laverie.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proprietaires",
                columns: table => new
                {
                    _CIN = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Surnom = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proprietaires", x => x._CIN);
                });

            migrationBuilder.CreateTable(
                name: "Laveries",
                columns: table => new
                {
                    IdLaverie = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Capacite = table.Column<string>(type: "text", nullable: false),
                    Addresse = table.Column<string>(type: "text", nullable: false),
                    ProprietaireCIN = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laveries", x => x.IdLaverie);
                    table.ForeignKey(
                        name: "FK_Laveries_Proprietaires_ProprietaireCIN",
                        column: x => x.ProprietaireCIN,
                        principalTable: "Proprietaires",
                        principalColumn: "_CIN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    IdMachine = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Marque = table.Column<string>(type: "text", nullable: false),
                    Etat = table.Column<string>(type: "text", nullable: false),
                    IDLaverie = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.IdMachine);
                    table.ForeignKey(
                        name: "FK_Machines_Laveries_IDLaverie",
                        column: x => x.IDLaverie,
                        principalTable: "Laveries",
                        principalColumn: "IdLaverie",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cycles",
                columns: table => new
                {
                    IdCycle = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomDuCycle = table.Column<string>(type: "text", nullable: false),
                    DureeHeures = table.Column<int>(type: "integer", nullable: false),
                    IdMachine = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cycles", x => x.IdCycle);
                    table.ForeignKey(
                        name: "FK_Cycles_Machines_IdMachine",
                        column: x => x.IdMachine,
                        principalTable: "Machines",
                        principalColumn: "IdMachine",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tarifs",
                columns: table => new
                {
                    IdTarif = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cout = table.Column<int>(type: "integer", nullable: false),
                    IdCycle = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarifs", x => x.IdTarif);
                    table.ForeignKey(
                        name: "FK_Tarifs_Cycles_IdCycle",
                        column: x => x.IdCycle,
                        principalTable: "Cycles",
                        principalColumn: "IdCycle",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cycles_IdMachine",
                table: "Cycles",
                column: "IdMachine");

            migrationBuilder.CreateIndex(
                name: "IX_Laveries_ProprietaireCIN",
                table: "Laveries",
                column: "ProprietaireCIN");

            migrationBuilder.CreateIndex(
                name: "IX_Machines_IDLaverie",
                table: "Machines",
                column: "IDLaverie");

            migrationBuilder.CreateIndex(
                name: "IX_Tarifs_IdCycle",
                table: "Tarifs",
                column: "IdCycle");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarifs");

            migrationBuilder.DropTable(
                name: "Cycles");

            migrationBuilder.DropTable(
                name: "Machines");

            migrationBuilder.DropTable(
                name: "Laveries");

            migrationBuilder.DropTable(
                name: "Proprietaires");
        }
    }
}
