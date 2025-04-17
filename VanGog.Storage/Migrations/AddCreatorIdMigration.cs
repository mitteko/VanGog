﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace VanGog.Storage.Migrations
{
    public partial class AddCreatorIdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Добавляем колонку CreatorId в таблицу Events
            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "Events",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Удаляем колонку CreatorId из таблицы Events при откате миграции
            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Events");
        }
    }
}
