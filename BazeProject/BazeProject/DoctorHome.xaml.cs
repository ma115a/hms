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
    /// Interaction logic for DoctorHome.xaml
    /// </summary>
    public partial class DoctorHome : UserControl
    {
        private HomeDoctorViewModel viewModel;
        List<Patient> patients;
        public DoctorHome()
        {
            InitializeComponent();
            viewModel = new HomeDoctorViewModel(DatabaseService.Instance);


            patients = viewModel.GetPatients();

            PatientCombo.ItemsSource = patients;
            PatientCombo.DisplayMemberPath = "comboItem";
            PatientCombo.SelectedValuePath = "umcn";
            
            
        }

        private void SelectPatient_Click(object sender, RoutedEventArgs e)
        {
            if(PatientCombo.SelectedItem == null)
            {
                ErrorLabel.Content = "Please select patient!";
                return;
            }

            string patient_umcn = PatientCombo.SelectedValue.ToString();

            ErrorLabel.Content = "Patient selected!";
            App.selected_Patient = patients.FirstOrDefault(p => p.umcn == patient_umcn);





        }
    }
}
