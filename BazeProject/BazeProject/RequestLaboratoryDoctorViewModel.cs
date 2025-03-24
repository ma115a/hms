using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazeProject
{
    public class RequestLaboratoryDoctorViewModel
    {
        DatabaseService databaseService;

        public RequestLaboratoryDoctorViewModel(DatabaseService databaseService)
        {
            this.databaseService = databaseService;
        }



        public List<Doctor> GetTehnicians()
        {
            return databaseService.GetTehnicians();
        }

        public bool RequestLaboratory(int laboratory_tehnician_id, int doctor_id, string patient_umcn, string description)
        {
            return databaseService.RequestLaboratory(laboratory_tehnician_id, doctor_id, patient_umcn, description);
        }
    }
}
