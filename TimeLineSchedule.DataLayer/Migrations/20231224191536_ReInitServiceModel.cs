using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeLineSchedule.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class ReInitServiceModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCreated",
                table: "ClassDatas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCreated",
                table: "ClassDatas",
                type: "bit",
                nullable: true);
        }
    }
}
