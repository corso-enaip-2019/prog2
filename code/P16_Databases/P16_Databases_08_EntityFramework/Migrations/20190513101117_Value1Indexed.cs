using Microsoft.EntityFrameworkCore.Migrations;

namespace P16_Databases_08_EntityFramework.Migrations
{
    public partial class Value1Indexed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Value1",
                table: "Models",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Models_Value1",
                table: "Models",
                column: "Value1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Models_Value1",
                table: "Models");

            migrationBuilder.AlterColumn<string>(
                name: "Value1",
                table: "Models",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
