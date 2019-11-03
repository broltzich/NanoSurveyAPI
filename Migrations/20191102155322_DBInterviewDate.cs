using Microsoft.EntityFrameworkCore.Migrations;

namespace NanoSurveyAPI.Migrations
{
    public partial class DBInterviewDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "Interviews",
                newName: "Date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Interviews",
                newName: "BirthDate");
        }
    }
}
