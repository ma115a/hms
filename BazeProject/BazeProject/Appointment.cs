using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazeProject
{
    public class Appointment
    {

        public string doctor {  get; set; }
        public string date { get; set; }

        public Appointment(string doctor, string date)
        {
            this.doctor = doctor;
            this.date = date;
        }
    }
}
