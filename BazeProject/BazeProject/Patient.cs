using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazeProject
{
    public class Patient
    {
        public string umcn {  get; set; }
        public string name { get; set; }
        public string phone { get; set; }

        public string comboItem { get; set; }


        public Patient(string umcn, string name, string phone)
        {
            this.umcn = umcn;
            this.name = name;
            this.phone = phone;
            this.comboItem = umcn + " " + name;
        }
    }
}
