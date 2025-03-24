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
    /// Interaction logic for RequestLaboratoryDoctor.xaml
    /// </summary>
    public partial class RequestLaboratoryDoctor : UserControl
    {

        private List<Doctor> tehnicians;
        private RequestLaboratoryDoctorViewModel viewModel;
        public RequestLaboratoryDoctor()
        {
            InitializeComponent();

            viewModel = new RequestLaboratoryDoctorViewModel(DatabaseService.Instance);

            tehnicians = viewModel.GetTehnicians();

            TehnicianCombo.ItemsSource = tehnicians;

            TehnicianCombo.DisplayMemberPath = "comboItem";

            TehnicianCombo.SelectedValuePath = "employee_id";

        }


        private void RequestLaboratory_Click(object sender, RoutedEventArgs e)
        {
            if(TehnicianCombo.SelectedItem == null || DescriptionBox.Text == "")
            {

                StatusLabel.Content = "Please fill in all data!";
                return;
            }

            if(viewModel.RequestLaboratory((int)TehnicianCombo.SelectedValue, App.current_employee.employee_id, App.selected_Patient.umcn, DescriptionBox.Text))
            {
                StatusLabel.Content = "Sucessfull!";
            }
        }
    }
}
