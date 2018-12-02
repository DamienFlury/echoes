using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EchoesServer.Api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    ClassId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                values: new object[,]
                {
                    { 1, "Class1" },
                    { 2, "Class2" },
                    { 3, "Class3" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ClassId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 27, null, "Student27", "LastName27" },
                    { 28, null, "Student28", "LastName28" },
                    { 29, null, "Student29", "LastName29" },
                    { 30, null, "Student30", "LastName30" },
                    { 31, null, "Student31", "LastName31" },
                    { 32, null, "Student32", "LastName32" },
                    { 33, null, "Student33", "LastName33" },
                    { 34, null, "Student34", "LastName34" },
                    { 35, null, "Student35", "LastName35" },
                    { 36, null, "Student36", "LastName36" },
                    { 37, null, "Student37", "LastName37" },
                    { 38, null, "Student38", "LastName38" },
                    { 39, null, "Student39", "LastName39" },
                    { 40, null, "Student40", "LastName40" },
                    { 41, null, "Student41", "LastName41" },
                    { 42, null, "Student42", "LastName42" },
                    { 43, null, "Student43", "LastName43" },
                    { 44, null, "Student44", "LastName44" },
                    { 45, null, "Student45", "LastName45" },
                    { 46, null, "Student46", "LastName46" },
                    { 47, null, "Student47", "LastName47" },
                    { 48, null, "Student48", "LastName48" },
                    { 26, null, "Student26", "LastName26" },
                    { 25, null, "Student25", "LastName25" },
                    { 24, null, "Student24", "LastName24" },
                    { 23, null, "Student23", "LastName23" },
                    { 1, null, "Student1", "LastName1" },
                    { 2, null, "Student2", "LastName2" },
                    { 3, null, "Student3", "LastName3" },
                    { 4, null, "Student4", "LastName4" },
                    { 5, null, "Student5", "LastName5" },
                    { 6, null, "Student6", "LastName6" },
                    { 7, null, "Student7", "LastName7" },
                    { 8, null, "Student8", "LastName8" },
                    { 9, null, "Student9", "LastName9" },
                    { 10, null, "Student10", "LastName10" },
                    { 49, null, "Student49", "LastName49" },
                    { 11, null, "Student11", "LastName11" },
                    { 13, null, "Student13", "LastName13" },
                    { 14, null, "Student14", "LastName14" },
                    { 15, null, "Student15", "LastName15" },
                    { 16, null, "Student16", "LastName16" },
                    { 17, null, "Student17", "LastName17" },
                    { 18, null, "Student18", "LastName18" },
                    { 19, null, "Student19", "LastName19" },
                    { 20, null, "Student20", "LastName20" },
                    { 21, null, "Student21", "LastName21" },
                    { 22, null, "Student22", "LastName22" },
                    { 12, null, "Student12", "LastName12" },
                    { 50, null, "Student50", "LastName50" }
                });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "ClassId", "Description", "Discriminator", "Title" },
                values: new object[,]
                {
                    { 2, 1, "This is an assignment.", "Assignment", "Assignment2" },
                    { 24, 3, "This is an assignment.", "Assignment", "Assignment24" },
                    { 21, 3, "This is an assignment.", "Assignment", "Assignment21" },
                    { 19, 3, "This is an assignment.", "Assignment", "Assignment19" },
                    { 14, 3, "This is an assignment.", "Assignment", "Assignment14" },
                    { 13, 3, "This is an assignment.", "Assignment", "Assignment13" },
                    { 11, 3, "This is an assignment.", "Assignment", "Assignment11" },
                    { 9, 3, "This is an assignment.", "Assignment", "Assignment9" },
                    { 8, 3, "This is an assignment.", "Assignment", "Assignment8" },
                    { 6, 3, "This is an assignment.", "Assignment", "Assignment6" },
                    { 3, 3, "This is an assignment.", "Assignment", "Assignment3" },
                    { 1, 3, "This is an assignment.", "Assignment", "Assignment1" },
                    { 30, 2, "This is an assignment.", "Assignment", "Assignment30" },
                    { 26, 2, "This is an assignment.", "Assignment", "Assignment26" },
                    { 25, 2, "This is an assignment.", "Assignment", "Assignment25" },
                    { 18, 2, "This is an assignment.", "Assignment", "Assignment18" },
                    { 16, 2, "This is an assignment.", "Assignment", "Assignment16" },
                    { 15, 2, "This is an assignment.", "Assignment", "Assignment15" },
                    { 12, 2, "This is an assignment.", "Assignment", "Assignment12" },
                    { 4, 2, "This is an assignment.", "Assignment", "Assignment4" },
                    { 28, 1, "This is an assignment.", "Assignment", "Assignment28" },
                    { 23, 1, "This is an assignment.", "Assignment", "Assignment23" },
                    { 22, 1, "This is an assignment.", "Assignment", "Assignment22" },
                    { 20, 1, "This is an assignment.", "Assignment", "Assignment20" },
                    { 17, 1, "This is an assignment.", "Assignment", "Assignment17" },
                    { 10, 1, "This is an assignment.", "Assignment", "Assignment10" },
                    { 7, 1, "This is an assignment.", "Assignment", "Assignment7" },
                    { 5, 1, "This is an assignment.", "Assignment", "Assignment5" },
                    { 27, 3, "This is an assignment.", "Assignment", "Assignment27" },
                    { 29, 3, "This is an assignment.", "Assignment", "Assignment29" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_ClassId",
                table: "Assignments",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssignment_AssignmentId",
                table: "StudentAssignment",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassId",
                table: "Students",
                column: "ClassId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentAssignment");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Classes");
        }
    }
}
