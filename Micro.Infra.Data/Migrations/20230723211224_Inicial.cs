using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Micro.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Programas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Alimento = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Tempo = table.Column<int>(type: "int", nullable: false),
                    Potencia = table.Column<int>(type: "int", nullable: false),
                    Instrucoes = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Aquece = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Programas",
                columns: new[] { "Id", "Alimento", "Aquece", "Instrucoes", "Nome", "Potencia", "Tempo" },
                values: new object[,]
                {
                    { 1, "Pipoca (de micro-ondas)", "$", "Observar o barulho de estouros do milho, caso houver um intervalo de mais de 10 segundos entre um estouro e outro, interrompa o aquecimento.", "Leite", 7, 180 },
                    { 2, "Leite", "*", "Cuidado com aquecimento de líquidos, o choque térmico aliado ao movimento do recipiente pode causar fervura imediata causando risco de queimaduras.", "Leite", 5, 300 },
                    { 3, "Carne em pedaço ou fatias", "%", "Interrompa o processo na metade e vire o conteúdo com a parte de baixo para cima para o descongelamento uniforme.", "Carnes de boi", 4, 840 },
                    { 4, "Frango (qualquer corte)", "#", ": Interrompa o processo na metade e vire o conteúdo com a parte de baixo para cima para o descongelamento uniforme.", "Frango", 7, 480 },
                    { 5, "Feijão congelado", "@", "Deixe o recipiente destampado e em casos de plástico, cuidado ao retirar o recipiente pois o mesmo pode perder resistência em altas temperaturas.", "Feijão", 9, 480 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Programas");
        }
    }
}
