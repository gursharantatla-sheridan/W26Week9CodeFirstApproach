using System;
using System.Collections.Generic;
using System.Text;

namespace W26Week9CodeFirstApproach
{
    public class Standard
    {
        // scalar properties
        public int StandardId { get; set; }
        public string? StandardName { get; set; }

        // navigation property
        public ICollection<Student>? Students { get; set; }
    }
}
