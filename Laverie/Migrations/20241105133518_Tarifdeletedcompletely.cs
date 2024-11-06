using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Laverie.Migrations
{
    /// <inheritdoc />
    public partial class Tarifdeletedcompletely : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarifs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tarifs",
                columns: table => new
                {
                    IdTarif = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CycleIdCycle = table.Column<int>(type: "integer", nullable: true),
                    Cout = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarifs", x => x.IdTarif);
                    table.ForeignKey(
                        name: "FK_Tarifs_Cycles_CycleIdCycle",
                        column: x => x.CycleIdCycle,
                        principalTable: "Cycles",
                        principalColumn: "IdCycle");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tarifs_CycleIdCycle",
                table: "Tarifs",
                column: "CycleIdCycle");
        }
    }
}
