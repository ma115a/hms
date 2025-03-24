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
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : UserControl
    {
        public HomePage()
        {
            InitializeComponent();

            UsernameLabel.Content = "Username: " + App.current_employee.username;
            UserLabel.Content = "User: " + App.current_employee.name + " " + App.current_employee.lastname;
            DynamicContentControl.Content = new AddAppointmentNurse();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            DynamicContentControl.Content = new AddAppointmentNurse();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            App.current_employee = null;
            ((MainWindow)Application.Current.MainWindow).MainContent.Content = new LoginPage();

        }

        private void AddApointment_Click(object sender, RoutedEventArgs e)
        {
            DynamicContentControl.Content = new AddAppointmentNurse();
        }

        private void CheckAppointment_Click(object sender, RoutedEventArgs e)
        {
            DynamicContentControl.Content = new CheckAppointmentNurse();
        }

        private void AddPatient_Click(object sender, RoutedEventArgs e)
        {
            DynamicContentControl.Content = new AddPatientNurse();
        }
    }
}
