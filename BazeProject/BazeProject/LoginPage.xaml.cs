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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : UserControl
    {
        private readonly LoginViewModel _viewModel;
        public LoginPage()
        {
            InitializeComponent();
            _viewModel = new LoginViewModel(DatabaseService.Instance);
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {

            
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Password;
            if(username == "" || password == "")
            {
                ErrorLabelLogin.Content = "Please fill all fields!";
                return;
            }
            Employee result = _viewModel.Login(username, password);
            if (result == null)
            {
                ErrorLabelLogin.Content = "Please check your credentials!";
                return;
            }

            App.current_employee = result;

            Console.WriteLine("Logged in as: " + result.role);

            if (App.current_employee.role == "doctor")
            {
                ((MainWindow)Application.Current.MainWindow).MainContent.Content = new HomePageDoctor();
            }
            else if (App.current_employee.role == "nurse") ((MainWindow)Application.Current.MainWindow).MainContent.Content = new HomePage();
            else ErrorLabelLogin.Content = "Not yet implemented!";

        }
    }
}
