using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeLineSchedule.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitClassData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ScheduledDate",
                table: "ClassDatas",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScheduledDate",
                table: "ClassDatas");
        }
    }
}
