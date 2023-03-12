using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NajotEdu.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedIsDoneForLesson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDone",
                table: "Lessons",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDone",
                table: "Lessons");
        }
    }
}
