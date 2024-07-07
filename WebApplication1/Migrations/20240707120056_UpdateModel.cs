﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JsonPost.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Posts",
                newName: "Postid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Postid",
                table: "Posts",
                newName: "id");
        }
    }
}
