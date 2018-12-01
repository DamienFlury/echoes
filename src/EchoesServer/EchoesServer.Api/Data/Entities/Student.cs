namespace EchoesServer.Api.Data.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public SchoolClass SchoolClass { get; set; }
    }
}