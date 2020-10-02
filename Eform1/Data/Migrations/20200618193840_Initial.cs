using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace Eform1.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "table_1s",
                columns: table => new
                {
                    UID_F = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Form_Name = table.Column<string>(nullable: true),
                    Creator = table.Column<string>(nullable: true),
                    Created_On = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_table_1s", x => x.UID_F);
                });

            migrationBuilder.CreateTable(
                name: "table_2s",
                columns: table => new
                {
                    UID_Q = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UID_F1 = table.Column<int>(nullable: false),
                    Question_Type = table.Column<string>(nullable: true),
                    Question = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_table_2s", x => x.UID_Q);
                    table.ForeignKey(
                        name: "FK_table_2s_table_1s_UID_F1",
                        column: x => x.UID_F1,
                        principalTable: "table_1s",
                        principalColumn: "UID_F",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "table_3s",
                columns: table => new
                {
                    ID_MCQ = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    F2 = table.Column<int>(nullable: false),
                    UID_Q = table.Column<int>(nullable: false),
                    Options = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_table_3s", x => x.ID_MCQ);
                    table.ForeignKey(
                        name: "FK_table_3s_table_2s_UID_Q",
                        column: x => x.UID_Q,
                        principalTable: "table_2s",
                        principalColumn: "UID_Q",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_table_2s_UID_F1",
                table: "table_2s",
                column: "UID_F1");

            migrationBuilder.CreateIndex(
                name: "IX_table_3s_UID_Q",
                table: "table_3s",
                column: "UID_Q");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "table_3s");

            migrationBuilder.DropTable(
                name: "table_2s");

            migrationBuilder.DropTable(
                name: "table_1s");
        }
    }
}
