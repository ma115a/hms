using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazeProject
{
    public class Employee
    {
        public int employee_id { get; set; }
        public string username { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public string role { get; set; }

        public Employee(int employee_id, string username, string name, string lastname, string role)
        {
            this.employee_id = employee_id;
            this.username = username;
            this.name = name;
            this.lastname = lastname;
            this.role = role;
        }

    }
}
