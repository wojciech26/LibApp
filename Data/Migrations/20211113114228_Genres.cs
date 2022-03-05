using Microsoft.EntityFrameworkCore.Migrations;

namespace LibApp.Data.Migrations
{
    public partial class Genres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Genre (Id, Name) VALUES (1, 'Thriller')");
            migrationBuilder.Sql("INSERT INTO Genre (Id, Name) VALUES (2, 'Mystery')");
            migrationBuilder.Sql("INSERT INTO Genre (Id, Name) VALUES (3, 'Horror')");
            migrationBuilder.Sql("INSERT INTO Genre (Id, Name) VALUES (4, 'Biography')");
            migrationBuilder.Sql("INSERT INTO Genre (Id, Name) VALUES (5, 'Criminal')");
            migrationBuilder.Sql("INSERT INTO Genre (Id, Name) VALUES (6, 'Sci - Fi')");
            migrationBuilder.Sql("INSERT INTO Genre (Id, Name) VALUES (7, 'Romance')");
            migrationBuilder.Sql("INSERT INTO Genre (Id, Name) VALUES (8, 'Fantasy')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
