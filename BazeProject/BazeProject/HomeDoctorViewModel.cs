using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazeProject
{
    public class HomeDoctorViewModel
    {
        private DatabaseService _databaseService;

        public HomeDoctorViewModel(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }


        public List<Patient> GetPatients()
        {
            return _databaseService.GetPatients();
        }
    }
}
