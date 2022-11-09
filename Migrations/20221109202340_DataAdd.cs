using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiProyect.Migrations
{
    public partial class DataAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "AccessFailedCount", "CodPostal", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "apellidos", "nombre" },
                values: new object[,]
                {
                    { "338ea642-53d1-4d25-84aa-4917d4c3cd17", 0, 38010, "3cf3d5d9-886d-42a8-bfa9-40bc8c09ad7f", "Manager@disquera.com", true, false, null, "MANAGER@DISQUERA.COM", "MANAGER@DISQUERA.COM", "AQAAAAEAACcQAAAAEA5Cy/bJodvANg+6Ynk0ej+w4asGN898q+rBO5ffaBb3rvWdSTu+y1CL6Gq7Ci63nQ==", null, false, "4089f78c-1f6f-4e07-9370-0084809aece2", false, "Manager@disquera.com", "Gomez Gil", "Pepe" },
                    { "43f94c8a-72fb-4d5c-9d3b-cce4b252ac64", 0, 38007, "6b35ae13-2007-48d0-affc-b3a56d9bf006", "Admin@disquera.com", true, false, null, "ADMIN@DISQUERA.COM", "ADMIN@DISQUERA.COM", "AQAAAAEAACcQAAAAELQujZPtRVP587EewFHypeJoLD/ji1c2wvfQYbd95HPzVpSRb1h8wWTiO4TEY1Wu7A==", null, false, "0e18e0a8-9ca6-4d64-94aa-6d4bc42c7ff1", false, "Admin@disquera.com", "Bartolome Navarro", "Cesar" },
                    { "871212fb-9bf6-4bf7-b0f6-8f66b9c4e1a8", 0, 38010, "8fb688b5-e4e5-43d6-90ac-ba6e9e22f2e1", "User1@disquera.com", true, false, null, "USER1@DISQUERA.COM", "USER1@DISQUERA.COM", "AQAAAAEAACcQAAAAEO8Tc1E73Qd+cJf/UJuaGkWTAQQWX2jfJI2EeTwo1wFDhcb6FV+yFD7LZGiE+XWW3w==", null, false, "2c1a968e-f6ab-49c9-9770-5c9b357968d7", false, "User1@disquera.com", "Martin Hernandez", "Manolo" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "66658887-ecd8-4b24-a514-1851519a2b0d", "d12af09b-383b-4724-b8a4-82b8b80bc6bd", "Admin", "ADMIN" },
                    { "6959cc7a-d816-49e2-86db-07b1d1f0d8b5", "ae656a9c-e697-45a3-af13-2a07be04e7cd", "default", "DEFAULT" },
                    { "c6b0de03-868b-4ced-b532-01dce807cc25", "113e1e5b-e51b-44ae-bc04-324bc54d9d50", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c6b0de03-868b-4ced-b532-01dce807cc25", "338ea642-53d1-4d25-84aa-4917d4c3cd17" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "66658887-ecd8-4b24-a514-1851519a2b0d", "43f94c8a-72fb-4d5c-9d3b-cce4b252ac64" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6959cc7a-d816-49e2-86db-07b1d1f0d8b5", "871212fb-9bf6-4bf7-b0f6-8f66b9c4e1a8" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c6b0de03-868b-4ced-b532-01dce807cc25", "338ea642-53d1-4d25-84aa-4917d4c3cd17" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "66658887-ecd8-4b24-a514-1851519a2b0d", "43f94c8a-72fb-4d5c-9d3b-cce4b252ac64" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6959cc7a-d816-49e2-86db-07b1d1f0d8b5", "871212fb-9bf6-4bf7-b0f6-8f66b9c4e1a8" });

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: "338ea642-53d1-4d25-84aa-4917d4c3cd17");

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: "43f94c8a-72fb-4d5c-9d3b-cce4b252ac64");

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: "871212fb-9bf6-4bf7-b0f6-8f66b9c4e1a8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66658887-ecd8-4b24-a514-1851519a2b0d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6959cc7a-d816-49e2-86db-07b1d1f0d8b5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6b0de03-868b-4ced-b532-01dce807cc25");
        }
    }
}
