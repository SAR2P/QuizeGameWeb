using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quize_api.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "participants",
                columns: table => new
                {
                    ParticipantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    score = table.Column<int>(type: "int", nullable: false),
                    TimceTaken = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_participants", x => x.ParticipantId);
                });

            migrationBuilder.CreateTable(
                name: "questions",
                columns: table => new
                {
                    QnId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QnInWords = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    option1 = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    option2 = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    option3 = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    option4 = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Answre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questions", x => x.QnId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "participants");

            migrationBuilder.DropTable(
                name: "questions");
        }
    }
}
