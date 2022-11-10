using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiProyect.Migrations
{
    public partial class SeederAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "AccessFailedCount", "CodPostal", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "apellidos", "nombre" },
                values: new object[,]
                {
                    { "0b8131f6-07cd-4dd5-b928-3667534a1469", 0, 38007, "b2293295-5868-4e76-a365-208ba332dc0f", "Admin@disquera.com", true, false, null, "ADMIN@DISQUERA.COM", "ADMIN@DISQUERA.COM", "AQAAAAEAACcQAAAAEHaleWYt0i0kw8BirIEajeIm+wAlAAGuhJ1zT+jXtEzBNvIuz6IvuPpYlGPcStEnqQ==", null, false, "d1b6eaea-b3e1-48aa-92de-86919c5ebf64", false, "Admin@disquera.com", "Bartolome Navarro", "Cesar" },
                    { "4991e722-5286-42f9-9b83-fb845fc45476", 0, 38010, "3c0ed9aa-8d87-4411-894c-6543ea82d266", "User1@disquera.com", true, false, null, "USER1@DISQUERA.COM", "USER1@DISQUERA.COM", "AQAAAAEAACcQAAAAEK0A/ifzrR44TeFHGAEum28T1oWosJBC81zkEcZhybLa+Nb2+BPsLctH3EQDJpgxzQ==", null, false, "12926cb3-7180-4efa-b596-468c2189b980", false, "User1@disquera.com", "Martin Hernandez", "Manolo" },
                    { "835b79fe-7cd3-4b74-a971-651eb7af3ca5", 0, 38010, "da06f163-02f7-4d63-a763-d5aedd1f764f", "Manager@disquera.com", true, false, null, "MANAGER@DISQUERA.COM", "MANAGER@DISQUERA.COM", "AQAAAAEAACcQAAAAEDFijBkXETpDqEyHUzknakN4OW6qQS6uWZois0JqC8tFIrP8AEovjVHvRB38f+NX7A==", null, false, "233ec672-69af-45a0-8bdb-ee76e88f44ed", false, "Manager@disquera.com", "Gomez Gil", "Pepe" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "101853e5-5c97-4c85-b222-3fd679738049", "d199e815-b418-47f6-b73d-e48aab1bbb3f", "default", "DEFAULT" },
                    { "6957cd5a-e68a-4b31-8b51-ee5653651367", "4aa34c48-d8e6-410d-9d8c-26e75b284261", "Manager", "MANAGER" },
                    { "6d134e3c-3172-4999-85c5-8b944d66007b", "725c786d-d369-4a1d-ab77-c6e5d6e9fccb", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6d134e3c-3172-4999-85c5-8b944d66007b", "0b8131f6-07cd-4dd5-b928-3667534a1469" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "101853e5-5c97-4c85-b222-3fd679738049", "4991e722-5286-42f9-9b83-fb845fc45476" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6957cd5a-e68a-4b31-8b51-ee5653651367", "835b79fe-7cd3-4b74-a971-651eb7af3ca5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6d134e3c-3172-4999-85c5-8b944d66007b", "0b8131f6-07cd-4dd5-b928-3667534a1469" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "101853e5-5c97-4c85-b222-3fd679738049", "4991e722-5286-42f9-9b83-fb845fc45476" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6957cd5a-e68a-4b31-8b51-ee5653651367", "835b79fe-7cd3-4b74-a971-651eb7af3ca5" });

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: "0b8131f6-07cd-4dd5-b928-3667534a1469");

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: "4991e722-5286-42f9-9b83-fb845fc45476");

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: "835b79fe-7cd3-4b74-a971-651eb7af3ca5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "101853e5-5c97-4c85-b222-3fd679738049");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6957cd5a-e68a-4b31-8b51-ee5653651367");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d134e3c-3172-4999-85c5-8b944d66007b");
        }
    }
}
