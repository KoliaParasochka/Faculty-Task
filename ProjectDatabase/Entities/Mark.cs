
namespace ProjectDatabase.Entities
{
    public class Mark
    {
        public int Id { get; set; }
        public int Grade { get; set; }

        public int? CourseId { get; set; }
        public int? StudentId { get; set; }
    }
}
