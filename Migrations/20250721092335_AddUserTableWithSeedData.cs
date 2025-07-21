using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceIntegrationAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddUserTableWithSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$wWrc16nFQvW3V4svB/EqEuCQVwVpnh3s1xHjS3OCgGvnxplPMslyW\r\n");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$MQsIq0gzyFQDHc.hyKniYukJqNzwhMpX21rudIXuLIOINBtJmtRle");
        }
    }
}
