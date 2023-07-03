using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelProject.DataAccessLayer.Migrations
{
    public partial class mig_add_about_entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Count",
                table: "Abouts",
                newName: "Content");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Abouts",
                newName: "Count");
        }
    }
}
