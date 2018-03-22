using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace StoreControl.Infrastructure.Database.Migrations
{
    public partial class V201803211959 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Purchase",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Amount = table.Column<float>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CustomerAccountID = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    LastDateTimeUpdate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Purchase_CustomerAccount_CustomerAccountID",
                        column: x => x.CustomerAccountID,
                        principalTable: "CustomerAccount",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_CustomerAccountID",
                table: "Purchase",
                column: "CustomerAccountID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purchase");
        }
    }
}
