using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZXCStudentsInfo.Classes
{
    public class Specialnost
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        List<Students> Students { get; set; } = new List<Students>();
    }
}
