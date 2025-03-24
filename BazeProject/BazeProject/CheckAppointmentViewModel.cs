using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazeProject
{
    public class CheckAppointmentViewModel
    {
        private readonly DatabaseService _databaseService;



        public CheckAppointmentViewModel(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }


        public List<Patient> GetPatients()
        {
            return _databaseService.GetPatients();
        }


        public Appointment CheckAppointment(string patient_umcn, string date)
        {
            return _databaseService.CheckAppointment(patient_umcn, date);
        }
    }
}
