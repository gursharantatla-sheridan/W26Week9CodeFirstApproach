using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace W26Week9CodeFirstApproach
{
    public class Student
    {
        // scalar properties
        public int StudentId { get; set; }

        [Column("Name")]
        public string? StudentName { get; set; }
        public int? StandardId { get; set; }

        // add a new scalar property
        public int? Age { get; set; }

        // navigation property
        public Standard? Standard { get; set; }
    }
}
