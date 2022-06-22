using Microsoft.EntityFrameworkCore.Migrations;

namespace Test2.Migrations
{
    public partial class CompositePrimaryKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Confectionery_ClientOrder",
                table: "Confectionery_ClientOrder");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Confectionery_ClientOrder",
                table: "Confectionery_ClientOrder",
                columns: new[] { "IdClientOrder", "IdConfectionery" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Confectionery_ClientOrder",
                table: "Confectionery_ClientOrder");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Confectionery_ClientOrder",
                table: "Confectionery_ClientOrder",
                column: "IdClientOrder");
        }
    }
}
