using Microsoft.EntityFrameworkCore.Migrations;

namespace P16_Databases_08_EntityFramework.Migrations
{
    public partial class AddedPropertyNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Models",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "Models");
        }
    }
}
