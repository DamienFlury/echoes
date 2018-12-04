using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EchoesServer.Api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_ApplicationUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ClassId = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assignments_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentClass",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    ClassId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentClass", x => new { x.StudentId, x.ClassId });
                    table.ForeignKey(
                        name: "FK_StudentClass_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentClass_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentAssignment",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    AssignmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAssignment", x => new { x.StudentId, x.AssignmentId });
                    table.ForeignKey(
                        name: "FK_StudentAssignment_Assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentAssignment_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Class1" });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Class2" });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Class3" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName" },
                values: new object[] { 27, null, "Student27", "LastName27" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName" },
                values: new object[] { 28, null, "Student28", "LastName28" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName" },
                values: new object[] { 29, null, "Student29", "LastName29" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName" },
                values: new object[] { 30, null, "Student30", "LastName30" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName" },
                values: new object[] { 31, null, "Student31", "LastName31" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName" },
                values: new object[] { 32, null, "Student32", "LastName32" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName" },
                values: new object[] { 33, null, "Student33", "LastName33" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName" },
                values: new object[] { 34, null, "Student34", "LastName34" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName" },
                values: new object[] { 35, null, "Student35", "LastName35" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName" },
                values: new object[] { 36, null, "Student36", "LastName36" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName" },
                values: new object[] { 37, null, "Student37", "LastName37" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName" },
                values: new object[] { 38, null, "Student38", "LastName38" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName" },
                values: new object[] { 39, null, "Student39", "LastName39" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName" },
                values: new object[] { 40, null, "Student40", "LastName40" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName" },
                values: new object[] { 41, null, "Student41", "LastName41" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName" },
                values: new object[] { 42, null, "Student42", "LastName42" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName" },
                values: new object[] { 43, null, "Student43", "LastName43" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName" },
                values: new object[] { 44, null, "Student44", "LastName44" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName" },
                values: new object[] { 45, null, "Student45", "LastName45" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName" },
                values: new object[] { 46, null, "Student46", "LastName46" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName" },
                values: new object[] { 47, null, "Student47", "LastName47" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName" },
                values: new object[] { 48, null, "Student48", "LastName48" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName" },
                values: new object[] { 26, null, "Student26", "LastName26" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName" },
                values: new object[] { 25, null, "Student25", "LastName25" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName" },
                values: new object[] { 24, null, "Student24", "LastName24" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName" },
                values: new object[] { 23, null, "Student23", "LastName23" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName" },
                values: new object[] { 1, null, "Student1", "LastName1" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName" },
                values: new object[] { 2, null, "Student2", "LastName2" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName" },
                values: new object[] { 3, null, "Student3", "LastName3" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName" },
                values: new object[] { 4, null, "Student4", "LastName4" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName" },
                values: new object[] { 5, null, "Student5", "LastName5" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName" },
                values: new object[] { 6, null, "Student6", "LastName6" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName" },
                values: new object[] { 7, null, "Student7", "LastName7" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName" },
                values: new object[] { 8, null, "Student8", "LastName8" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName" },
                values: new object[] { 9, null, "Student9", "LastName9" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName" },
                values: new object[] { 10, null, "Student10", "LastName10" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName" },
                values: new object[] { 49, null, "Student49", "LastName49" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName" },
                values: new object[] { 11, null, "Student11", "LastName11" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName" },
                values: new object[] { 13, null, "Student13", "LastName13" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName" },
                values: new object[] { 14, null, "Student14", "LastName14" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName" },
                values: new object[] { 15, null, "Student15", "LastName15" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName" },
                values: new object[] { 16, null, "Student16", "LastName16" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName" },
                values: new object[] { 17, null, "Student17", "LastName17" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName" },
                values: new object[] { 18, null, "Student18", "LastName18" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName" },
                values: new object[] { 19, null, "Student19", "LastName19" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName" },
                values: new object[] { 20, null, "Student20", "LastName20" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName" },
                values: new object[] { 21, null, "Student21", "LastName21" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName" },
                values: new object[] { 22, null, "Student22", "LastName22" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName" },
                values: new object[] { 12, null, "Student12", "LastName12" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ApplicationUserId", "FirstName", "LastName" },
                values: new object[] { 50, null, "Student50", "LastName50" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 1, 1, "This is an assignment.", "Assignment", "Assignment1" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 28, 3, "This is an assignment.", "Assignment", "Assignment28" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 27, 3, "This is an assignment.", "Assignment", "Assignment27" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 24, 3, "This is an assignment.", "Assignment", "Assignment24" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 23, 3, "This is an assignment.", "Assignment", "Assignment23" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 22, 3, "This is an assignment.", "Assignment", "Assignment22" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 20, 3, "This is an assignment.", "Assignment", "Assignment20" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 18, 3, "This is an assignment.", "Assignment", "Assignment18" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 16, 3, "This is an assignment.", "Assignment", "Assignment16" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 10, 3, "This is an assignment.", "Assignment", "Assignment10" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 6, 3, "This is an assignment.", "Assignment", "Assignment6" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 4, 3, "This is an assignment.", "Assignment", "Assignment4" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 30, 2, "This is an assignment.", "Assignment", "Assignment30" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 29, 2, "This is an assignment.", "Assignment", "Assignment29" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 21, 2, "This is an assignment.", "Assignment", "Assignment21" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 26, 2, "This is an assignment.", "Assignment", "Assignment26" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 19, 1, "This is an assignment.", "Assignment", "Assignment19" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 13, 2, "This is an assignment.", "Assignment", "Assignment13" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 11, 2, "This is an assignment.", "Assignment", "Assignment11" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 9, 2, "This is an assignment.", "Assignment", "Assignment9" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 7, 2, "This is an assignment.", "Assignment", "Assignment7" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 5, 2, "This is an assignment.", "Assignment", "Assignment5" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 3, 2, "This is an assignment.", "Assignment", "Assignment3" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 25, 1, "This is an assignment.", "Assignment", "Assignment25" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 14, 2, "This is an assignment.", "Assignment", "Assignment14" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 17, 1, "This is an assignment.", "Assignment", "Assignment17" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 15, 1, "This is an assignment.", "Assignment", "Assignment15" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 12, 1, "This is an assignment.", "Assignment", "Assignment12" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 8, 1, "This is an assignment.", "Assignment", "Assignment8" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 2, 1, "This is an assignment.", "Assignment", "Assignment2" });

            migrationBuilder.InsertData(
                table: "StudentClass",
                columns: new[] { "StudentId", "ClassId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "StudentClass",
                columns: new[] { "StudentId", "ClassId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "StudentClass",
                columns: new[] { "StudentId", "ClassId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "StudentClass",
                columns: new[] { "StudentId", "ClassId" },
                values: new object[] { 2, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_ClassId",
                table: "Assignments",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssignment_AssignmentId",
                table: "StudentAssignment",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClass_ClassId",
                table: "StudentClass",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ApplicationUserId",
                table: "Students",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentAssignment");

            migrationBuilder.DropTable(
                name: "StudentClass");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "ApplicationUser");
        }
    }
}
