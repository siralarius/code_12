using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace code_12.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Symbol",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    high = table.Column<float>(type: "REAL", nullable: false),
                    highest = table.Column<float>(type: "REAL", nullable: false),
                    low = table.Column<float>(type: "REAL", nullable: false),
                    lowest = table.Column<float>(type: "REAL", nullable: false),
                    reading = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Symbol", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Symbol");
        }
    }
}
