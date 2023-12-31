using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeLineSchedule.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitTBL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUpdated",
                table: "ClassDatas");

            migrationBuilder.CreateTable(
                name: "settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefreshTime = table.Column<int>(type: "int", nullable: false),
                    ChangeBoxTime = table.Column<int>(type: "int", nullable: false)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "settings");

            migrationBuilder.AddColumn<bool>(
                name: "IsUpdated",
                table: "ClassDatas",
                type: "bit",
                nullable: true);
        }
    }
}
