namespace ApiServer.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // ESTA FALTA → agrégala
        public int Age { get; set; }
    }
}