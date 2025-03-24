using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazeProject
{
    public class Medication
    {

        public int medication_id {  get; set; }

        public string medication_name { get; set; }

        public Medication(int medication_id, string medication_name)
        {
            this.medication_name = medication_name;
            this.medication_id = medication_id;
        }
    }
}
