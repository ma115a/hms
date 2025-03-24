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
    /// Interaction logic for CheckAppointmentNurse.xaml
    /// </summary>
    public partial class CheckAppointmentNurse : UserControl
    {

        private List<Patient> patients;
        private CheckAppointmentViewModel viewModel;
        public CheckAppointmentNurse()
        {
            InitializeComponent();

            viewModel = new CheckAppointmentViewModel(DatabaseService.Instance);

            patients = viewModel.GetPatients();


            PatientCombo.ItemsSource = patients;
            PatientCombo.DisplayMemberPath = "comboItem";
            PatientCombo.SelectedValuePath = "umcn";
        }




        private void CheckAppointment_Click(object sender, RoutedEventArgs e)
        {
            if (PatientCombo.SelectedItem == null)
            {
                StatusLabel.Content = "Please fill in all the data!";
                return;
            }

            string patient_umcn = PatientCombo.SelectedValue.ToString();


            DateTime date = DatePicker.SelectedDate.Value;

            string dateFormat = date.ToString("yyyy-MM-dd");


            Appointment result = viewModel.CheckAppointment(patient_umcn, dateFormat);

            if (result != null)
            {
                StatusLabel.Content = "Appointment: " + result.doctor + " at: " + result.date;
            }
            else StatusLabel.Content = "No Appointment!";




        }
    }
}
