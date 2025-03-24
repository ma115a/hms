using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazeProject
{
    public class SurgeriesDoctorViewModel
    {
        private DatabaseService databaseService;

        public SurgeriesDoctorViewModel(DatabaseService databaseService)
        {
            this.databaseService = databaseService;
        }

        public List<Surgery> GetSurgeries(string patient_umcn)
        {
            return databaseService.GetSurgeries(patient_umcn);
        }
    }
}
