using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoggingProvider.Migrations
{
    /// <inheritdoc />
    public partial class AddedSessionIdcolumntoUserEventEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SessionId",
                table: "UserEvents",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "UserEvents");
        }
    }
}
