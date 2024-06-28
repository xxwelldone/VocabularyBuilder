using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VocabularyBuilder.Infra.Migrations
{
    /// <inheritdoc />
    public partial class addmeaning : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Meaning",
                table: "vocabularies",
                newName: "Phonetic");

            migrationBuilder.CreateTable(
                name: "meanings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VocabularyId = table.Column<int>(type: "integer", nullable: false),
                    PartOfSpeech = table.Column<string>(type: "text", nullable: false),
                    Definitions = table.Column<string>(type: "text", nullable: false),
                    Example = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_meanings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_meanings_vocabularies_VocabularyId",
                        column: x => x.VocabularyId,
                        principalTable: "vocabularies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_meanings_VocabularyId",
                table: "meanings",
                column: "VocabularyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "meanings");

            migrationBuilder.RenameColumn(
                name: "Phonetic",
                table: "vocabularies",
                newName: "Meaning");
        }
    }
}
