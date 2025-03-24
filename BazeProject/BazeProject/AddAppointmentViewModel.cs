using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazeProject
{
    public class AddAppointmentViewModel
    {

        private readonly DatabaseService _databaseService;



        public AddAppointmentViewModel(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }


        public List<Patient> ListAllPatients()
        {
            return _databaseService.GetPatients();
        }

        public List<Doctor> ListAllDoctors()
        {
            return _databaseService.GetDoctors();
        }

        public string AddAppointment(string patient_umcn, int doctor_id, string dateTime)
        {
            return _databaseService.InsertAppointment(doctor_id, patient_umcn, dateTime);
        }
    }
}
