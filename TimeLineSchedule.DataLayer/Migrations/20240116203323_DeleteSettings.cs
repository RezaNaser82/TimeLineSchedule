using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeLineSchedule.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class DeleteSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "settings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChangeBoxTime = table.Column<int>(type: "int", nullable: false),
                    RefreshTime = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_settings", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "settings",
                columns: new[] { "Id", "ChangeBoxTime", "RefreshTime" },
                values: new object[] { 1, 10, 1 });
        }
    }
}
