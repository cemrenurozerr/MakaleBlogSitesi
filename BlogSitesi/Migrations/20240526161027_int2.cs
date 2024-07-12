using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogSitesi.Migrations
{
    /// <inheritdoc />
    public partial class int2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OkunmaSayisi",
                table: "Makaleler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "597ed2a6-cd7d-4042-b6a4-b51b0009fd77");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "34f3b022-89dc-4c4f-a88b-124e1c3cbef2", "AQAAAAIAAYagAAAAELuP2PJIEiCcnpSpFCYnB9m+0yblZwrEvWFQar+j57Y4eBkCm5uzVwOfQY9zRTg0yw==", "5e130fca-16b4-473c-97f7-0427ba357f74" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OkunmaSayisi",
                table: "Makaleler");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "ab0d7d03-db9e-4860-8662-17f9ea95ece6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8e7f219a-cebc-4320-8966-be9d80c8a525", "AQAAAAIAAYagAAAAEC72rqR+J+Ie/0Y1Cx3SYd641MT4E1IVZIQRCrQgjVOMRVoovKgyqy5CSqVWkRfNHQ==", "43d8a924-e541-4a6c-a0a4-121cbb324b06" });
        }
    }
}
