using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazeProject
{
    public class MakePerscriptionViewModel
    {
        DatabaseService databaseService;


        public MakePerscriptionViewModel(DatabaseService databaseService)
        {
            this.databaseService = databaseService;
        }


        public List<Medication> GetMedication()
        {
            return databaseService.GetMedication();
        }

        public bool MakePrescription(string patient_umcn, int doctor_id, int medication_id, string dosage, string frequency)
        {
            return databaseService.MakePerscription(patient_umcn, doctor_id, medication_id, dosage, frequency);
        }
    }
}
