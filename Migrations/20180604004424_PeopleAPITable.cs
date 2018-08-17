using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace peopleapi.Migrations
{
    public partial class PeopleAPITable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    personId = table.Column<Guid>(nullable: false),
                    Address = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    cellPhone = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    City = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    email = table.Column<string>(unicode: false, maxLength: 250, nullable: true),
                    firstName = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    lastName = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    linkedin = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    middleName = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    State = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    twitter = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    workPhone = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    zipCode = table.Column<string>(unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.personId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Person_lastname",
                table: "Person",
                column: "lastName");

            migrationBuilder.CreateIndex(
                name: "IX_Person",
                table: "Person",
                column: "personId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_state",
                table: "Person",
                column: "State");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
