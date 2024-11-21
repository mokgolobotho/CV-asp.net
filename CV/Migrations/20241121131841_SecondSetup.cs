using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CV.Migrations
{
    /// <inheritdoc />
    public partial class SecondSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CVEntity_FilesEntity_fileId",
                table: "CVEntity");

            migrationBuilder.RenameColumn(
                name: "fileName",
                table: "FilesEntity",
                newName: "FileName");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "FilesEntity",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "skills",
                table: "CVEntity",
                newName: "Skills");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "CVEntity",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "fileId",
                table: "CVEntity",
                newName: "FileId");

            migrationBuilder.RenameColumn(
                name: "experience",
                table: "CVEntity",
                newName: "Experience");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "CVEntity",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "education",
                table: "CVEntity",
                newName: "Education");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "CVEntity",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "phone_number",
                table: "CVEntity",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "CVEntity",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "id_number",
                table: "CVEntity",
                newName: "IdNumber");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "CVEntity",
                newName: "FirstName");

            migrationBuilder.RenameIndex(
                name: "IX_CVEntity_fileId",
                table: "CVEntity",
                newName: "IX_CVEntity_FileId");

            migrationBuilder.AlterColumn<string>(
                name: "Skills",
                table: "CVEntity",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Experience",
                table: "CVEntity",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_CVEntity_FilesEntity_FileId",
                table: "CVEntity",
                column: "FileId",
                principalTable: "FilesEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CVEntity_FilesEntity_FileId",
                table: "CVEntity");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "FilesEntity",
                newName: "fileName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "FilesEntity",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Skills",
                table: "CVEntity",
                newName: "skills");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "CVEntity",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "FileId",
                table: "CVEntity",
                newName: "fileId");

            migrationBuilder.RenameColumn(
                name: "Experience",
                table: "CVEntity",
                newName: "experience");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "CVEntity",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Education",
                table: "CVEntity",
                newName: "education");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CVEntity",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "CVEntity",
                newName: "phone_number");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "CVEntity",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "IdNumber",
                table: "CVEntity",
                newName: "id_number");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "CVEntity",
                newName: "first_name");

            migrationBuilder.RenameIndex(
                name: "IX_CVEntity_FileId",
                table: "CVEntity",
                newName: "IX_CVEntity_fileId");

            migrationBuilder.AlterColumn<string>(
                name: "skills",
                table: "CVEntity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "experience",
                table: "CVEntity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CVEntity_FilesEntity_fileId",
                table: "CVEntity",
                column: "fileId",
                principalTable: "FilesEntity",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
