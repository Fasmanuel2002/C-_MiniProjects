using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentRestApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "DateOfBirth", "DepartmentId", "Email", "FirstName", "Gender", "LastName", "PhotoPath" },
                values: new object[,]
                {
                    { 1, new DateTime(1992, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "ernestoSalmantino@gmail.com", "Ernesto", 0, "Salmantino", "Images/Ernesto.png" },
                    { 2, new DateTime(1994, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "DeboraSalmantino@gmail.com", "Debora", 1, "Fuchibol", "Images/Debora.png" },
                    { 3, new DateTime(1970, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "JaviAvila@gmail.com", "Javi", 0, "Avila", "Images/Javi.png" },
                    { 4, new DateTime(1992, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "NoeliaSalmantina@gmail.com", "Noelia", 1, "Salmantina", "Images/Noelia.png" },
                    { 5, new DateTime(1990, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "LuisSalmantino@gmail.com", "Luis", 0, "Salmantino", "Images/Luis.png" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
