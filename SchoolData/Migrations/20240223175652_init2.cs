using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolData.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskResponsesResult_Tasks_TaskId",
                table: "TaskResponsesResult");

            migrationBuilder.DropIndex(
                name: "IX_TaskResponsesResult_TaskId",
                table: "TaskResponsesResult");

            migrationBuilder.AddColumn<int>(
                name: "TaskResponseId",
                table: "TaskResponsesResult",
                type: "integer",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BornDate", "CreatedDateTime", "FirstName", "LastName", "PasswordHash", "PhotoUrl", "UserName", "UserRole" },
                values: new object[] { new Guid("560da73e-9277-49bc-a9d1-91336802a7e4"), "2002-31-10", new DateTime(2024, 2, 23, 22, 56, 52, 187, DateTimeKind.Local).AddTicks(3222), "Maruf", "Berdiev", "password123", null, "fuga_02", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_TaskResponsesResult_TaskResponseId",
                table: "TaskResponsesResult",
                column: "TaskResponseId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskResponsesResult_TaskResponses_TaskResponseId",
                table: "TaskResponsesResult",
                column: "TaskResponseId",
                principalTable: "TaskResponses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskResponsesResult_TaskResponses_TaskResponseId",
                table: "TaskResponsesResult");

            migrationBuilder.DropIndex(
                name: "IX_TaskResponsesResult_TaskResponseId",
                table: "TaskResponsesResult");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("560da73e-9277-49bc-a9d1-91336802a7e4"));

            migrationBuilder.DropColumn(
                name: "TaskResponseId",
                table: "TaskResponsesResult");

            migrationBuilder.CreateIndex(
                name: "IX_TaskResponsesResult_TaskId",
                table: "TaskResponsesResult",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskResponsesResult_Tasks_TaskId",
                table: "TaskResponsesResult",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
