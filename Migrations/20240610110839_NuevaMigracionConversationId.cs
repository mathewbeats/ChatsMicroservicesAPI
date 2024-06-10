using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatMicroserviceAPI.Migrations
{
    /// <inheritdoc />
    public partial class NuevaMigracionConversationId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConversationId",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConversationId",
                table: "Messages");
        }
    }
}
