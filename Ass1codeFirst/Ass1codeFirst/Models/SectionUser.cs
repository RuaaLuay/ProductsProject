namespace Ass1codeFirst.Models
{
    public class SectionUser
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User user { get; set; }
        public int SectionId { get; set; }
        public Section section { get; set; }
    }
}
