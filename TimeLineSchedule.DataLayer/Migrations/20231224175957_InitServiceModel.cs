using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeLineSchedule.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitServiceModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCreated",
                table: "ClassDatas",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsUpdated",
                table: "ClassDatas",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCreated",
                table: "ClassDatas");

            migrationBuilder.DropColumn(
                name: "IsUpdated",
                table: "ClassDatas");
        }
    }
}
