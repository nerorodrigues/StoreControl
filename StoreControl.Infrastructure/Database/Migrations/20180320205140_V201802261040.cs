using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace StoreControl.Infrastructure.Database.Migrations
{
    public partial class V201802261040 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerAccounts",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CPF = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    LastDateTimeUpdate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAccounts", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerAccounts");
        }
    }
}
