using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EchoesServer.Api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
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
                name: "StudentClasses",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    ClassId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentClasses", x => new { x.StudentId, x.ClassId });
                    table.ForeignKey(
                        name: "FK_StudentClasses_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentClasses_Students_StudentId",
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
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 27, "Student27", "LastName27", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 28, "Student28", "LastName28", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 29, "Student29", "LastName29", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 30, "Student30", "LastName30", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 31, "Student31", "LastName31", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 32, "Student32", "LastName32", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 33, "Student33", "LastName33", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 34, "Student34", "LastName34", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 35, "Student35", "LastName35", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 36, "Student36", "LastName36", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 37, "Student37", "LastName37", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 38, "Student38", "LastName38", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 39, "Student39", "LastName39", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 40, "Student40", "LastName40", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 41, "Student41", "LastName41", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 42, "Student42", "LastName42", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 43, "Student43", "LastName43", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 44, "Student44", "LastName44", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 45, "Student45", "LastName45", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 46, "Student46", "LastName46", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 47, "Student47", "LastName47", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 48, "Student48", "LastName48", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 26, "Student26", "LastName26", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 25, "Student25", "LastName25", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 24, "Student24", "LastName24", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 23, "Student23", "LastName23", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 1, "Student1", "LastName1", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 2, "Student2", "LastName2", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 3, "Student3", "LastName3", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 4, "Student4", "LastName4", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 5, "Student5", "LastName5", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 6, "Student6", "LastName6", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 7, "Student7", "LastName7", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 8, "Student8", "LastName8", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 9, "Student9", "LastName9", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 10, "Student10", "LastName10", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 49, "Student49", "LastName49", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 11, "Student11", "LastName11", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 13, "Student13", "LastName13", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 14, "Student14", "LastName14", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 15, "Student15", "LastName15", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 16, "Student16", "LastName16", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 17, "Student17", "LastName17", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 18, "Student18", "LastName18", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 19, "Student19", "LastName19", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 20, "Student20", "LastName20", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 21, "Student21", "LastName21", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 22, "Student22", "LastName22", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 12, "Student12", "LastName12", null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 50, "Student50", "LastName50", null });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 3, 1, "This is an assignment.", "Assignment", "Assignment3" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 29, 3, "This is an assignment.", "Assignment", "Assignment29" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 25, 3, "This is an assignment.", "Assignment", "Assignment25" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 21, 3, "This is an assignment.", "Assignment", "Assignment21" });

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
                values: new object[] { 17, 3, "This is an assignment.", "Assignment", "Assignment17" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 16, 3, "This is an assignment.", "Assignment", "Assignment16" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 2, 3, "This is an assignment.", "Assignment", "Assignment2" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 30, 2, "This is an assignment.", "Assignment", "Assignment30" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 27, 2, "This is an assignment.", "Assignment", "Assignment27" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 26, 2, "This is an assignment.", "Assignment", "Assignment26" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 23, 2, "This is an assignment.", "Assignment", "Assignment23" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 22, 2, "This is an assignment.", "Assignment", "Assignment22" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 13, 2, "This is an assignment.", "Assignment", "Assignment13" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 19, 2, "This is an assignment.", "Assignment", "Assignment19" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 28, 1, "This is an assignment.", "Assignment", "Assignment28" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 10, 2, "This is an assignment.", "Assignment", "Assignment10" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 8, 2, "This is an assignment.", "Assignment", "Assignment8" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 7, 2, "This is an assignment.", "Assignment", "Assignment7" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 6, 2, "This is an assignment.", "Assignment", "Assignment6" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 5, 2, "This is an assignment.", "Assignment", "Assignment5" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 4, 2, "This is an assignment.", "Assignment", "Assignment4" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 1, 2, "This is an assignment.", "Assignment", "Assignment1" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 12, 2, "This is an assignment.", "Assignment", "Assignment12" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 24, 1, "This is an assignment.", "Assignment", "Assignment24" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 15, 1, "This is an assignment.", "Assignment", "Assignment15" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 14, 1, "This is an assignment.", "Assignment", "Assignment14" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 11, 1, "This is an assignment.", "Assignment", "Assignment11" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[] { 9, 1, "This is an assignment.", "Assignment", "Assignment9" });

            migrationBuilder.InsertData(
                table: "StudentClasses",
                columns: new[] { "StudentId", "ClassId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "StudentClasses",
                columns: new[] { "StudentId", "ClassId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "StudentClasses",
                columns: new[] { "StudentId", "ClassId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "StudentClasses",
                columns: new[] { "StudentId", "ClassId" },
                values: new object[] { 2, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_ClassId",
                table: "Assignments",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssignment_AssignmentId",
                table: "StudentAssignment",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClasses_ClassId",
                table: "StudentClasses",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "StudentAssignment");

            migrationBuilder.DropTable(
                name: "StudentClasses");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
