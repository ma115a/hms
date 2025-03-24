using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazeProject
{
    public class LaboratoryTestResultDoctorViewModel
    {
        DatabaseService databaseService;

        public LaboratoryTestResultDoctorViewModel(DatabaseService databaseService)
        {
            this.databaseService = databaseService;
        }

        public List<LabResult> GetLabResults(string patient_umcn)
        {
            return databaseService.GetLabResults(patient_umcn);
        }
    }
}
