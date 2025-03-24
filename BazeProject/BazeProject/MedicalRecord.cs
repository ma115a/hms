using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazeProject
{
    public class MedicalRecord
    {



        public string doctor_name {  get; set; }

        public DateTime date { get; set; }

        public string diagnosis { get; set; }

        public string treatment { get; set; }

        public MedicalRecord(string doctor_name, DateTime date, string diagnosis, string treatment)
        {
            this.doctor_name = doctor_name;
            this.date = date;
            this.diagnosis = diagnosis;
            this.treatment = treatment;
        }
    }
}
