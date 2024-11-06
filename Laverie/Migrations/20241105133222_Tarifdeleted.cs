using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laverie.Migrations
{
    /// <inheritdoc />
    public partial class Tarifdeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarifs_Cycles_IdCycle",
                table: "Tarifs");

            migrationBuilder.RenameColumn(
                name: "IdCycle",
                table: "Tarifs",
                newName: "CycleIdCycle");

            migrationBuilder.RenameIndex(
                name: "IX_Tarifs_IdCycle",
                table: "Tarifs",
                newName: "IX_Tarifs_CycleIdCycle");

            migrationBuilder.AlterColumn<string>(
                name: "Capacite",
                table: "Laveries",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Addresse",
                table: "Laveries",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<double>(
                name: "Cout",
                table: "Cycles",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarifs_Cycles_CycleIdCycle",
                table: "Tarifs",
                column: "CycleIdCycle",
                principalTable: "Cycles",
                principalColumn: "IdCycle");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarifs_Cycles_CycleIdCycle",
                table: "Tarifs");

            migrationBuilder.DropColumn(
                name: "Cout",
                table: "Cycles");

            migrationBuilder.RenameColumn(
                name: "CycleIdCycle",
                table: "Tarifs",
                newName: "IdCycle");

            migrationBuilder.RenameIndex(
                name: "IX_Tarifs_CycleIdCycle",
                table: "Tarifs",
                newName: "IX_Tarifs_IdCycle");

            migrationBuilder.AlterColumn<string>(
                name: "Capacite",
                table: "Laveries",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Addresse",
                table: "Laveries",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarifs_Cycles_IdCycle",
                table: "Tarifs",
                column: "IdCycle",
                principalTable: "Cycles",
                principalColumn: "IdCycle",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
