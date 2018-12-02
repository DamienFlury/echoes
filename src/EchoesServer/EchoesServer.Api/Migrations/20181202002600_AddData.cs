using Microsoft.EntityFrameworkCore.Migrations;

namespace EchoesServer.Api.Migrations
{
    public partial class AddData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "Description", "Discriminator", "SchoolClassId", "Title" },
                values: new object[,]
                {
                    { 1, "This is an assignment.", "Assignment", null, "Assignment1" },
                    { 30, "This is an assignment.", "Assignment", null, "Assignment30" },
                    { 28, "This is an assignment.", "Assignment", null, "Assignment28" },
                    { 27, "This is an assignment.", "Assignment", null, "Assignment27" },
                    { 26, "This is an assignment.", "Assignment", null, "Assignment26" },
                    { 25, "This is an assignment.", "Assignment", null, "Assignment25" },
                    { 24, "This is an assignment.", "Assignment", null, "Assignment24" },
                    { 23, "This is an assignment.", "Assignment", null, "Assignment23" },
                    { 22, "This is an assignment.", "Assignment", null, "Assignment22" },
                    { 21, "This is an assignment.", "Assignment", null, "Assignment21" },
                    { 20, "This is an assignment.", "Assignment", null, "Assignment20" },
                    { 19, "This is an assignment.", "Assignment", null, "Assignment19" },
                    { 18, "This is an assignment.", "Assignment", null, "Assignment18" },
                    { 17, "This is an assignment.", "Assignment", null, "Assignment17" },
                    { 16, "This is an assignment.", "Assignment", null, "Assignment16" },
                    { 29, "This is an assignment.", "Assignment", null, "Assignment29" },
                    { 14, "This is an assignment.", "Assignment", null, "Assignment14" },
                    { 15, "This is an assignment.", "Assignment", null, "Assignment15" },
                    { 3, "This is an assignment.", "Assignment", null, "Assignment3" },
                    { 4, "This is an assignment.", "Assignment", null, "Assignment4" },
                    { 5, "This is an assignment.", "Assignment", null, "Assignment5" },
                    { 6, "This is an assignment.", "Assignment", null, "Assignment6" },
                    { 7, "This is an assignment.", "Assignment", null, "Assignment7" },
                    { 2, "This is an assignment.", "Assignment", null, "Assignment2" },
                    { 9, "This is an assignment.", "Assignment", null, "Assignment9" },
                    { 10, "This is an assignment.", "Assignment", null, "Assignment10" },
                    { 11, "This is an assignment.", "Assignment", null, "Assignment11" },
                    { 12, "This is an assignment.", "Assignment", null, "Assignment12" },
                    { 8, "This is an assignment.", "Assignment", null, "Assignment8" },
                    { 13, "This is an assignment.", "Assignment", null, "Assignment13" }
                });

            migrationBuilder.InsertData(
                table: "SchoolClasses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Class1" },
                    { 2, "Class2" },
                    { 3, "Class3" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "SchoolClassId" },
                values: new object[,]
                {
                    { 35, "Student35", "LastName35", null },
                    { 34, "Student34", "LastName34", null },
                    { 33, "Student33", "LastName33", null },
                    { 32, "Student32", "LastName32", null },
                    { 28, "Student28", "LastName28", null },
                    { 30, "Student30", "LastName30", null },
                    { 29, "Student29", "LastName29", null },
                    { 36, "Student36", "LastName36", null },
                    { 27, "Student27", "LastName27", null },
                    { 31, "Student31", "LastName31", null },
                    { 37, "Student37", "LastName37", null },
                    { 45, "Student45", "LastName45", null },
                    { 39, "Student39", "LastName39", null },
                    { 40, "Student40", "LastName40", null },
                    { 41, "Student41", "LastName41", null },
                    { 42, "Student42", "LastName42", null },
                    { 43, "Student43", "LastName43", null },
                    { 44, "Student44", "LastName44", null },
                    { 46, "Student46", "LastName46", null },
                    { 47, "Student47", "LastName47", null },
                    { 48, "Student48", "LastName48", null },
                    { 26, "Student26", "LastName26", null },
                    { 38, "Student38", "LastName38", null },
                    { 25, "Student25", "LastName25", null },
                    { 9, "Student9", "LastName9", null },
                    { 23, "Student23", "LastName23", null },
                    { 1, "Student1", "LastName1", null },
                    { 2, "Student2", "LastName2", null },
                    { 3, "Student3", "LastName3", null },
                    { 4, "Student4", "LastName4", null },
                    { 5, "Student5", "LastName5", null },
                    { 6, "Student6", "LastName6", null },
                    { 7, "Student7", "LastName7", null },
                    { 8, "Student8", "LastName8", null },
                    { 49, "Student49", "LastName49", null },
                    { 10, "Student10", "LastName10", null },
                    { 24, "Student24", "LastName24", null },
                    { 11, "Student11", "LastName11", null },
                    { 13, "Student13", "LastName13", null },
                    { 14, "Student14", "LastName14", null },
                    { 15, "Student15", "LastName15", null },
                    { 16, "Student16", "LastName16", null },
                    { 17, "Student17", "LastName17", null },
                    { 18, "Student18", "LastName18", null },
                    { 19, "Student19", "LastName19", null },
                    { 20, "Student20", "LastName20", null },
                    { 21, "Student21", "LastName21", null },
                    { 22, "Student22", "LastName22", null },
                    { 12, "Student12", "LastName12", null },
                    { 50, "Student50", "LastName50", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "SchoolClasses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SchoolClasses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SchoolClasses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 50);
        }
    }
}
