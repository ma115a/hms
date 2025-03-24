using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BazeProject
{
    public class Doctor
    {

        public int employee_id {get; set;}
        public string name {get; set;}
        public string role {get; set;}
        public string comboItem {get; set;}


        public Doctor(int employee_id, string name, string role)
        {
            this.employee_id = employee_id;
            this.name = name;
            this.role = role;
            this.comboItem = name + " " + role;
        }
    }
}
