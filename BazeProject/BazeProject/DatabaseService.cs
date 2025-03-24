using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using MySql.Data.MySqlClient;

namespace BazeProject
{
    public class DatabaseService
    {
        private readonly string _connectionString;
        private static DatabaseService _instance;


        public DatabaseService()
        {
            _connectionString = "Server=localhost;Database=hms;User ID=malisa;Password=malisa;";
        }

        public static DatabaseService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DatabaseService();
                }
                return _instance;
            }
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }


        public Employee ValidateEmployee(string username, string password)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                string query = "select employee_id, username, name, lastname from employee where username = @username and password = @password";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    using (var reader = command.ExecuteReader()) {
                        if (reader.Read()) {

                            return new Employee(reader.GetInt32("employee_id"), reader.GetString("username"), reader.GetString("name"), reader.GetString("lastname"), GetEmployeeRole(reader.GetInt32("employee_id")));
                        }
                    }
                }
            }
            return null;
        }

        private string GetEmployeeRole(int employee_id)
        {
            List<string> tables = new List<string>();
            tables.Add("doctor");
            tables.Add("nurse");
            tables.Add("surgeon");
            tables.Add("laboratory_tehnician");

            using (var connection = GetConnection())
            {
                connection.Open();

                foreach (var item in tables)
                {
                    string query = $"select count(*) from `{item}` where employee_id = @id";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", employee_id);


                        if (Convert.ToInt32(command.ExecuteScalar()) > 0)
                        {

                            return item;
                        }
                    }
                }
            }
                return null;

        }

        public List<Patient> GetPatients()
        {
            List<Patient> patients = new List<Patient>();

            using (var connection = GetConnection())
            {
                connection.Open();

                string query = "select umcn, name, phone, lastname from patient";

                using(var command = new MySqlCommand(query, connection))
                {
                    using(var reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            patients.Add(new Patient(reader.GetString("umcn"), reader.GetString("name") + " " + reader.GetString("lastname"), reader.GetString("phone")));
                        }
                    }
                }
            }

            return patients;
        }

        public List<Doctor> GetDoctors()
        {
            List<Doctor> doctors = new List<Doctor>();

            using(var connection = GetConnection())
            {
                connection.Open();

                string query = "select employee.employee_id, employee.name, employee.lastname, doctor.specialty\r\nfrom employee\r\njoin doctor on employee.employee_id = doctor.employee_id";

                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            doctors.Add(new Doctor(reader.GetInt32("employee_id"), reader.GetString("name") + " " + reader.GetString("lastname"), reader.GetString("specialty")));
                        }
                    }
                }
            }


            return doctors;
        }

        public string InsertAppointment(int doctor_id, string patient_umcn, string date)
        {

            using (var connection = GetConnection())
            {
                try
                {
                    connection.Open();

                    //string query = "insert into appointment(doctor_id, date, patient_umcn) values (@doctor_id, @date, @patient_umcn)";
                    string query = "call ScheduleAppointment(@doctor_id, @date, @patient_umcn)";
                    using(var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("doctor_id", doctor_id);
                        command.Parameters.AddWithValue("date", date);
                        command.Parameters.AddWithValue("patient_umcn", patient_umcn);

                        command.ExecuteNonQuery();
                    }
                    

                } catch (MySqlException e)
                {
                    if(e.Number == 1644)
                    {
                        return e.Message;
                    }
                }
                return "Appointment added!";
            }
        }

        public Appointment CheckAppointment(string patient_umcn, string date)
        {
            using(var connection = GetConnection())
            {
                connection.Open();

                //string query = "select e.name as doctor_name, e.lastname as doctor_lastname, a.date from appointment a join doctor d on a.doctor_id = d.employee_id join employee e on d.employee_id = e.employee_id where date(a.date) = @date and a.patient_umcn = @patient_umcn";
                string query = "SELECT * from view_appointment_details where date(date) = @date AND patient_umcn = @patient_umcn";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("date", date);
                    command.Parameters.AddWithValue("patient_umcn", patient_umcn);

                    using(var reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            return new Appointment(reader.GetString("doctor_name") + " " + reader.GetString("doctor_lastname"), reader.GetDateTime("date").ToString());
                        }
                    }


                }
            }

            return null;
        }

        public bool AddPatient(string umcn, string name, string lastname, string phone)
        {
            using(var connection = GetConnection())
            {
                connection.Open();

                //string query = "insert into patient(umcn, name, lastname, phone) values (@umcn, @name, @lastname, @phone)";
                string query = "call RegisterNewPatient(@name, @lastname, @umcn, @phone)";
                using( var command = new MySqlCommand(query,connection))
                {
                    command.Parameters.AddWithValue("umcn", umcn);
                    command.Parameters.AddWithValue ("name", name);
                    command.Parameters.AddWithValue("lastname", lastname);
                    command.Parameters.AddWithValue("phone", phone);

                    int rowsAffected = command.ExecuteNonQuery();

                    if(rowsAffected > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        public List<MedicalRecord> getMedicalRecord(string patient_umcn)
        {
            List<MedicalRecord> records  = new List<MedicalRecord>();
            using (var connection = GetConnection())
            {
                connection.Open();

                //string query = "select m.date, m.diagnosis, m.treatment, e.name, e.lastname from medical_record m join  doctor d on m.doctor_id = d.employee_id join employee e on d.employee_id = e.employee_id where m.patient_umcn = @patient_umcn";
                string query = "select * from view_patient_medical_records where patient_umcn = @patient_umcn";

                using (var command  = new MySqlCommand (query,connection))
                {
                    command.Parameters.AddWithValue("patient_umcn", patient_umcn);
                    using (var reader = command.ExecuteReader()) {


                        while(reader.Read())
                        {
                            records.Add(new MedicalRecord(reader.GetString("name") + " " + reader.GetString("lastname") ,reader.GetDateTime("date"), reader.GetString("diagnosis"), reader.GetString("treatment")));
                        }
                    }
                }
            }

            return records;
        }

        public bool AddMedicalRecord(string patient_umcn, int doctor_id, string date, string diagnosis, string treatment)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                string query = "insert into medical_record(patient_umcn, doctor_id, date, diagnosis, treatment) values (@patient_umcn, @doctor_id, @date, @diagnosis, @treatment)";

                using(var command = new MySqlCommand (query, connection))
                {
                    command.Parameters.AddWithValue("patient_umcn", patient_umcn);
                    command.Parameters.AddWithValue("doctor_id", doctor_id);
                    command.Parameters.AddWithValue("date", date);
                    command.Parameters.AddWithValue("diagnosis", diagnosis);
                    command.Parameters.AddWithValue("treatment", treatment);

                    int affectedRows = command.ExecuteNonQuery();

                    if(affectedRows > 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public List<Medication> GetMedication()
        {
            List<Medication> medications = new List<Medication>();

            using(var connection = GetConnection())
            {
                connection.Open();

                string query = "select * from medication";

                using(var command = new MySqlCommand (query,connection))
                {
                    using(var reader = command.ExecuteReader())
                    {

                        while(reader.Read())
                        {
                            medications.Add(new Medication(reader.GetInt32("medication_id"), reader.GetString("name")));
                        }
                    }
                }
            }


            return medications;
        }

        public bool MakePerscription(string patient_umcn, int doctor_id, int medication_id, string dosage, string frequency)
        {
            using(var connection = GetConnection())
            {
                connection.Open();

                string query = "insert into prescription(patient_umcn, doctor_id, medication_id, dosage, frequency) values (@patient_umcn, @doctor_id, @medication_id, @dosage, @frequency)";

                using(var command = new MySqlCommand(query,connection))
                {
                    command.Parameters.AddWithValue("patient_umcn", patient_umcn);
                    command.Parameters.AddWithValue("doctor_id", doctor_id);
                    command.Parameters.AddWithValue("medication_id", medication_id);
                    command.Parameters.AddWithValue("dosage", dosage);
                    command.Parameters.AddWithValue("frequency", frequency);

                    int affectedRows = command.ExecuteNonQuery();

                    if(affectedRows > 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public List<Surgery> GetSurgeries(string patient_umcn)
        {
            List<Surgery> surgeries = new List<Surgery>();

            using(var connection = GetConnection())
            {
                connection.Open();

                string query = "select surgery.date, employee.name, employee.lastname from surgery surgery join employee employee on employee.employee_id = surgery.surgeon_id where surgery.patient_umcn = @patient_umcn";

                using(var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("patient_umcn", patient_umcn);

                    using(var reader  = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            surgeries.Add(new Surgery(reader.GetDateTime("date"), reader.GetString("name") + " " + reader.GetString("lastname")));
                        }
                    }
                }
            }


            return surgeries;
        }

        public List<Doctor> GetTehnicians()
        {
            List<Doctor> doctors = new List<Doctor>();

            using (var connection = GetConnection())
            {
                connection.Open();

                string query = "select employee.employee_id, employee.name, employee.lastname\r\nfrom employee\r\njoin laboratory_tehnician on employee.employee_id = laboratory_tehnician.employee_id";

                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            doctors.Add(new Doctor(reader.GetInt32("employee_id"), reader.GetString("name") + " " + reader.GetString("lastname"), ""));
                        }
                    }
                }
            }


            return doctors;
        }

        public bool RequestLaboratory(int laboratory_tehnician_id, int doctor_id, string patient_umcn, string description)
        {
            using(var connection = GetConnection())
            {
                connection.Open();

                string query = "insert into laboratory_test(laboratory_tehnician_id, doctor_id, patient_umcn, description) values (@laboratory_tehnician_id, @doctor_id, @patient_umcn, @description)";

                using(var command = new MySqlCommand(query,connection))
                {
                    command.Parameters.AddWithValue("laboratory_tehnician_id", laboratory_tehnician_id);
                    command.Parameters.AddWithValue("doctor_id", doctor_id);
                    command.Parameters.AddWithValue("patient_umcn", patient_umcn);
                    command.Parameters.AddWithValue("description", description);

                    int affectedRows = command.ExecuteNonQuery();

                    if(affectedRows > 0)
                    {
                        return true;
                    }
                }

            }
            return false;
        }

        public List<LabResult> GetLabResults(string patient_umcn)
        {
            List<LabResult> labResults = new List<LabResult>();
            using(var connection = GetConnection())
            {
                connection.Open();

                //string query = "select emp_tech.name as tech_name, emp_tech.lastname as tech_lastname, emp_doc.name as doc_name, emp_doc.lastname as doc_lastname, lab_result.result_data, lab_result.date from laboratory_test_result as lab_result \r\njoin laboratory_test as lab_test on lab_result.laboratory_test_id = lab_test.laboratory_test_id\r\njoin laboratory_tehnician as lab_tech on lab_test.laboratory_tehnician_id = lab_tech.employee_id\r\njoin employee as emp_tech on lab_tech.employee_id = emp_tech.employee_id\r\njoin doctor as lab_doc on lab_test.doctor_id = lab_doc.employee_id\r\njoin employee as emp_doc on lab_doc.employee_id = emp_doc.employee_id where lab_test.patient_umcn = @patient_umcn";
                string query = "select *FROM view_lab_test_details where patient_umcn = @patient_umcn";

                using (var command = new MySqlCommand (query,connection))
                {
                    command.Parameters.AddWithValue("patient_umcn", patient_umcn);

                    using(var reader =  command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            labResults.Add(new LabResult(reader.GetString("doc_name") + " " + reader.GetString("doc_lastname"), reader.GetString("tech_name") + " " + reader.GetString("doc_lastname"), reader.GetDateTime("date"), reader.GetString("result_data")));
                        }
                    }


                }
            }

            return labResults;
        }
    }
}
