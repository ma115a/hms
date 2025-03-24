using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BazeProject
{
    /// <summary>
    /// Interaction logic for AddAppointmentNurse.xaml
    /// </summary>
    public partial class AddAppointmentNurse : UserControl
    {
        private AddAppointmentViewModel _viewModel;
        List<Patient> patients;
        List<Doctor> doctors;
        public AddAppointmentNurse()
        {
            _viewModel = new AddAppointmentViewModel(DatabaseService.Instance);
            InitializeComponent();


            patients = _viewModel.ListAllPatients();
            doctors = _viewModel.ListAllDoctors();



           PatientCombo.ItemsSource = patients;
            PatientCombo.DisplayMemberPath = "comboItem";
            PatientCombo.SelectedValuePath = "umcn";

           DoctorCombo.ItemsSource = doctors;
            DoctorCombo.DisplayMemberPath = "comboItem";
            DoctorCombo.SelectedValuePath = "employee_id";
        }

        private void AddAppointment_Click(object sender, RoutedEventArgs e)
        {
            if (PatientCombo.SelectedItem == null || DoctorCombo.SelectedItem == null || Hour.SelectedItem == null || Minute.SelectedItem == null)
            {
                ErrorLabel.Content = "Please fill all the fields!";
                return;
            }    
            string patient = PatientCombo.SelectedValue as string;

            var doctor = DoctorCombo.SelectedValue;

            DateTime date = DatePicker.SelectedDate.Value;


            string hour = (Hour.SelectedItem as ComboBoxItem).Content.ToString();
            string minute = (Minute.SelectedItem as ComboBoxItem).Content.ToString();
            string dateFormat = date.ToString("yyyy-MM-dd") + " " + hour + ":" + minute + ":00";

            Console.WriteLine(patient + " " + doctor  + " " + dateFormat);

            ErrorLabel.Content =  _viewModel.AddAppointment(patient, (int)doctor, dateFormat);
            
        }
    }
}
