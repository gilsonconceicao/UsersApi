using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsersApiStudy.Migrations
{
    /// <inheritdoc />
    public partial class fixnamecontectstocontact : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contects_Users_UserId",
                table: "Contects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contects",
                table: "Contects");

            migrationBuilder.RenameTable(
                name: "Contects",
                newName: "Contacts");

            migrationBuilder.RenameIndex(
                name: "IX_Contects_UserId",
                table: "Contacts",
                newName: "IX_Contacts_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts",
                column: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Users_UserId",
                table: "Contacts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Users_UserId",
                table: "Contacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts");

            migrationBuilder.RenameTable(
                name: "Contacts",
                newName: "Contects");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_UserId",
                table: "Contects",
                newName: "IX_Contects_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contects",
                table: "Contects",
                column: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contects_Users_UserId",
                table: "Contects",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
