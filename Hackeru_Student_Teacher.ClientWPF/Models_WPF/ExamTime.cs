using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackeru_Student_Teacher.ClientWPF.Models_WPF
{
    public class ExamTime
    {
        // Properties
        public int Hours { get; set; } = 0;
        public int Minutes { get; set; } = 0;


        // C'tor
        public ExamTime(int hours, int minutes)
        {
            Hours = hours;
            Minutes = minutes;
        }


        // Functions
        public override string ToString()
        {
            return $"{Hours}:{Minutes}";
        }
    }
}
