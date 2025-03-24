using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazeProject
{
    public class MedicalRecordDoctorViewModel
    {

        DatabaseService databaseService;

        public MedicalRecordDoctorViewModel(DatabaseService databaseService)
        {
            this.databaseService = databaseService;
        }


        public List<MedicalRecord> GetMedicalRecord(string patient_umcn)
        {
            return databaseService.getMedicalRecord(patient_umcn);
        }


        public bool AddMedicalRecord(string patient_umcn, int doctor_id, string date, string diagnosis, string treatment)
        {
            return databaseService.AddMedicalRecord(patient_umcn, doctor_id, date, diagnosis, treatment);
        }
    }
}
