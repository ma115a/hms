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
    /// Interaction logic for HomePageDoctor.xaml
    /// </summary>
    public partial class HomePageDoctor : UserControl
    {

        public HomePageDoctor()
        {
            InitializeComponent();
            
            DynamicContentControl.Content = new DoctorHome();
            UsernameLabel.Content = "Username: " + App.current_employee.username;
            UserLabel.Content = "User: " + App.current_employee.name + " " + App.current_employee.lastname;

        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            DynamicContentControl.Content = new DoctorHome();
        }

        private void MedicalRecord_Click(object sender, RoutedEventArgs e)
        {
            DynamicContentControl.Content = new MedicalRecordDoctor();
        }


        private void MakePerscription_Click(object sender, RoutedEventArgs e)
        {
            DynamicContentControl.Content = new MakePerscriptionDoctor();
        }

        private void LaboratoryResults_Click(object sender, RoutedEventArgs e)
        {
            DynamicContentControl.Content = new LaboratoryResultsDoctor();
        }

        private void RequestLaboratory_Click(object sender, RoutedEventArgs e)
        {
            DynamicContentControl.Content = new RequestLaboratoryDoctor();
        }

        private void Surgeries_Click(object sender, RoutedEventArgs e)
        {
            DynamicContentControl.Content = new SurgeriesDoctor();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            App.current_employee = null;
            ((MainWindow)Application.Current.MainWindow).MainContent.Content = new LoginPage();
        }
    }
}
