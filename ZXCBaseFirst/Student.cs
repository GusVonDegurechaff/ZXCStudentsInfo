using System;
using System.Collections.Generic;

namespace ZXCBaseFirst
{
    public partial class Student
    {
        public int Id { get; set; }
        public string? Fio { get; set; }
        public int Age { get; set; }
        public int Kyrs { get; set; }
        public int SpecialnostId { get; set; }
        public string? DateBrithDay { get; set; }
        public string? NumberGroup { get; set; }
        public int Stipendiya { get; set; }
        public int YearPostypleniya { get; set; }

        public virtual Specialnost Specialnost { get; set; } = null!;
    }
}
