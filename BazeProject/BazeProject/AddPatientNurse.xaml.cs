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
    /// Interaction logic for AddPatientNurse.xaml
    /// </summary>
    public partial class AddPatientNurse : UserControl
    {
        private AddPatientNurseViewModel viewModel;
        public AddPatientNurse()
        {
            InitializeComponent();
            viewModel = new AddPatientNurseViewModel(DatabaseService.Instance);
        }


        private void AddPatient_Click(object e,  RoutedEventArgs e2)
        {
            if(Umcn.Text == "" || Name.Text == "" || Lastname.Text == "" || Phone.Text == "")
            {
                StatusLabel.Content = "Please fill in all the fields!";
                return;
            }

            if(Umcn.Text.Length != 13)
            {
                StatusLabel.Content = "Umcn must be 13 characters!";
                return;
            }

            bool result = viewModel.AddPatient(Umcn.Text, Name.Text, Lastname.Text, Phone.Text);

            if (result)
            {
                StatusLabel.Content = "Patient added sucessfully!";
                Umcn.Text = "";
                Name.Text = "";
                Lastname.Text = "";
                Phone.Text = "";
            }
            else StatusLabel.Content = "Patient already exists!";

        }
    }
}
