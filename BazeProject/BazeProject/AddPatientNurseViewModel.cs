using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazeProject
{
    public class AddPatientNurseViewModel
    {
        private DatabaseService databaseService;


        public AddPatientNurseViewModel(DatabaseService databaseService)
        {
            this.databaseService = databaseService;
        }

        public bool AddPatient(string umcn, string name, string lastname, string phone)
        {
            return databaseService.AddPatient(umcn, name, lastname, phone);
        }
    }
}
