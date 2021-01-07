using Microsoft.EntityFrameworkCore.Migrations;

namespace PokemonDb.Migrations
{
    public partial class AddPokemonLevelAndMethod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PokemonLevel",
                table: "Pokemons",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PokemonLevel",
                table: "Pokemons");
        }
    }
}
