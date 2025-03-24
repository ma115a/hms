using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazeProject
{
    public class Surgery
    {
        public DateTime date {  get; set; }
        public string surgeon_name { get; set; }

        public Surgery(DateTime date, string surgeon_name)
        {
            this.date = date;
            this.surgeon_name = surgeon_name;
        }
    }
}
