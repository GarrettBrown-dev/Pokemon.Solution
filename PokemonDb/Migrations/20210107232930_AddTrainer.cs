using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PokemonDb.Migrations
{
    public partial class AddTrainer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrainerId",
                table: "Pokemons",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    TrainerId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TrainerName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.TrainerId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_TrainerId",
                table: "Pokemons",
                column: "TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemons_Trainers_TrainerId",
                table: "Pokemons",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "TrainerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemons_Trainers_TrainerId",
                table: "Pokemons");

            migrationBuilder.DropTable(
                name: "Trainers");

            migrationBuilder.DropIndex(
                name: "IX_Pokemons_TrainerId",
                table: "Pokemons");

            migrationBuilder.DropColumn(
                name: "TrainerId",
                table: "Pokemons");
        }
    }
}
