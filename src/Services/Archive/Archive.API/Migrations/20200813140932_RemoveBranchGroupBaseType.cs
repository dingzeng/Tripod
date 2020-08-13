using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Archive.API.Migrations
{
    public partial class RemoveBranchGroupBaseType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateOperName",
                table: "BranchGroup");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "BranchGroup");

            migrationBuilder.DropColumn(
                name: "LastUpdateOperId",
                table: "BranchGroup");

            migrationBuilder.DropColumn(
                name: "LastUpdateOperName",
                table: "BranchGroup");

            migrationBuilder.DropColumn(
                name: "LastUpdateTime",
                table: "BranchGroup");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreateOperName",
                table: "BranchGroup",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "BranchGroup",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "LastUpdateOperId",
                table: "BranchGroup",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "LastUpdateOperName",
                table: "BranchGroup",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateTime",
                table: "BranchGroup",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
