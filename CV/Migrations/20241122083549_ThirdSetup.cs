using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CV.Migrations
{
    /// <inheritdoc />
    public partial class ThirdSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CVEntity_FilesEntity_FileId",
                table: "CVEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilesEntity",
                table: "FilesEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CVEntity",
                table: "CVEntity");

            migrationBuilder.RenameTable(
                name: "FilesEntity",
                newName: "Files");

            migrationBuilder.RenameTable(
                name: "CVEntity",
                newName: "CV");

            migrationBuilder.RenameIndex(
                name: "IX_CVEntity_FileId",
                table: "CV",
                newName: "IX_CV_FileId");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "CV",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Files",
                table: "Files",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CV",
                table: "CV",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CV_Files_FileId",
                table: "CV",
                column: "FileId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CV_Files_FileId",
                table: "CV");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Files",
                table: "Files");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CV",
                table: "CV");

            migrationBuilder.RenameTable(
                name: "Files",
                newName: "FilesEntity");

            migrationBuilder.RenameTable(
                name: "CV",
                newName: "CVEntity");

            migrationBuilder.RenameIndex(
                name: "IX_CV_FileId",
                table: "CVEntity",
                newName: "IX_CVEntity_FileId");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "CVEntity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilesEntity",
                table: "FilesEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CVEntity",
                table: "CVEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CVEntity_FilesEntity_FileId",
                table: "CVEntity",
                column: "FileId",
                principalTable: "FilesEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
