using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ZXCStudentsInfo.Classes
{
    public class Students
    {
        public Students(string FIO, int Age, int Kyrs,int SpecialnostId,  string DateBrithDay, string NumberGroup, int Stipendiya, int YearPostypleniya)
        {
            this.FIO = FIO;
            this.Age = Age;
            this.Kyrs = Kyrs;
            
            this.SpecialnostId = SpecialnostId;
            this.DateBrithDay = DateBrithDay;
            this.NumberGroup = NumberGroup;
            this.Stipendiya = Stipendiya;
            this.YearPostypleniya = YearPostypleniya;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string? FIO { get; set; }
        public int Age { get; set; }
        public int Kyrs { get; set; }
        public int SpecialnostId { get; set; }
     
        public string? DateBrithDay { get; set; }
        public string? NumberGroup { get; set; }
        public int Stipendiya { get; set; }
        public int YearPostypleniya { get; set; }
        public Specialnost? Specialnosts { get; set; }
    }
    
}
