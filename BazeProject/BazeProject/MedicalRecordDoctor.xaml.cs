using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for MedicalRecordDoctor.xaml
    /// </summary>
    public partial class MedicalRecordDoctor : UserControl
    {
        private MedicalRecordDoctorViewModel viewModel;
        private List<MedicalRecord> records;
        private SharedDoctorViewModel sharedDoctorViewModel;
        public MedicalRecordDoctor()
        {
            InitializeComponent();
            viewModel = new MedicalRecordDoctorViewModel(DatabaseService.Instance);

            if(App.selected_Patient != null)
            {
                records = viewModel.GetMedicalRecord(App.selected_Patient.umcn);


                MedicalRecordGrid.ItemsSource = records;
            }

        }


        private void AddMedical_Click(object sender, RoutedEventArgs e)
        {

            string diagnosis = DiagnosisBox.Text;
            string treatment = TreatmentBox.Text;

            if(diagnosis == "" || treatment == "")
            {
                StatusLabel.Content = "Please fill in both diagnosis and treatment!";
                return;
            }

            if(viewModel.AddMedicalRecord(App.selected_Patient.umcn, App.current_employee.employee_id, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), diagnosis, treatment))
            {
                StatusLabel.Content = "Medical record added!";
                DiagnosisBox.Text = "";
                TreatmentBox.Text = "";
            }
        }
    }
}
