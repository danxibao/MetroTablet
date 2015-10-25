using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_try
{
    public class Paper
    {
        public long id { get; set; }
        public string name { get; set; }
        public string desc { get; set; }

        public override string ToString()
        {
            return name;
        }
    }

    public class Problem
    {
        public long id { get; set; }
        public long paper_id { get; set; }
        public string title { get; set; }
        public string option1 { get; set; }
        public string option2 { get; set; }
        public string option3 { get; set; }
        public string option4 { get; set; }


        public override string ToString()
        {
            return title;
        }
    }
}
