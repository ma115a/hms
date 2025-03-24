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
    /// Interaction logic for MakePerscriptionDoctor.xaml
    /// </summary>
    public partial class MakePerscriptionDoctor : UserControl
    {
        private List<Medication> medications;
        private MakePerscriptionViewModel viewModel;
        public MakePerscriptionDoctor()
        {
            InitializeComponent();
            viewModel = new MakePerscriptionViewModel(DatabaseService.Instance);
            medications = viewModel.GetMedication();

            MedicationCombo.ItemsSource = medications;

            MedicationCombo.DisplayMemberPath = "medication_name";
            MedicationCombo.SelectedValuePath = "medication_id";
        }




        private void MakePerscription_Click(object sender, RoutedEventArgs e)
        {
            if (MedicationCombo.SelectedItem == null || DosageBox.Text == "" || FrequencyBox.Text == "")
            {
                StatusLabel.Content = "Please fill in all the fields!";
                return;
            }


            var medication_id = MedicationCombo.SelectedValue;

            if(viewModel.MakePrescription(App.selected_Patient.umcn, App.current_employee.employee_id, (int)medication_id, DosageBox.Text, FrequencyBox.Text))
            {
                StatusLabel.Content = "Made sucessfully!";
                DosageBox.Text = "";
                FrequencyBox.Text = "";
                MedicationCombo.SelectedItem = null;
            }


        }
    }
}
