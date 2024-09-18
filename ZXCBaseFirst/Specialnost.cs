using System;
using System.Collections.Generic;

namespace ZXCBaseFirst
{
    public partial class Specialnost
    {
        public Specialnost()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
