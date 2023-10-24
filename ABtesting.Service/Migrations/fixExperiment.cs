﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ABtesting.Service.Migrations
{
    /// <inheritdoc />
    public partial class fixExperiment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DevicesExperiments_Devices_DeviceToken1",
                table: "DevicesExperiments");

            migrationBuilder.AlterColumn<Guid>(
                name: "DeviceToken1",
                table: "DevicesExperiments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DevicesExperiments_Devices_DeviceToken1",
                table: "DevicesExperiments",
                column: "DeviceToken1",
                principalTable: "Devices",
                principalColumn: "DeviceToken",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DevicesExperiments_Devices_DeviceToken1",
                table: "DevicesExperiments");

            migrationBuilder.AlterColumn<Guid>(
                name: "DeviceToken1",
                table: "DevicesExperiments",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_DevicesExperiments_Devices_DeviceToken1",
                table: "DevicesExperiments",
                column: "DeviceToken1",
                principalTable: "Devices",
                principalColumn: "DeviceToken");
        }
    }
}
