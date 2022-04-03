﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Practic.Migrations
{
    public partial class CreateCaruselTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Corusels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Persent = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Header = table.Column<string>(nullable: true),
                    Main = table.Column<string>(nullable: true),
                    Footer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corusels", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Corusels");
        }
    }
}
