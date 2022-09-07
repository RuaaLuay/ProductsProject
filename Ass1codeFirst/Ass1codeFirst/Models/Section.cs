using System.Collections.Generic;

namespace Ass1codeFirst.Models
{
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SectionUser> SectionUsers { get; set; }

    }
}
