using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace StoreControl.Infrastructure.Database.Migrations
{
    public partial class V201803210032 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerAccounts",
                table: "CustomerAccounts");

            migrationBuilder.RenameTable(
                name: "CustomerAccounts",
                newName: "CustomerAccount");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CustomerAccount",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "CustomerAccount",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "CustomerAccount",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerAccount",
                table: "CustomerAccount",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerAccount",
                table: "CustomerAccount");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "CustomerAccount");

            migrationBuilder.RenameTable(
                name: "CustomerAccount",
                newName: "CustomerAccounts");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CustomerAccounts",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "CustomerAccounts",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerAccounts",
                table: "CustomerAccounts",
                column: "ID");
        }
    }
}
