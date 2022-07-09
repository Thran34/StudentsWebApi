using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentsWebApi.Infrastructure.Migrations
{
    public partial class AddedOneToManyRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LessonId",
                table: "Lessons",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Lessons",
                newName: "LessonId");
        }
    }
}
