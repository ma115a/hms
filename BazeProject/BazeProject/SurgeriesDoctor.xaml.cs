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
    /// Interaction logic for SurgeriesDoctor.xaml
    /// </summary>
    public partial class SurgeriesDoctor : UserControl
    {
        private SurgeriesDoctorViewModel viewModel;
        private List<Surgery> surgeries;
        public SurgeriesDoctor()
        {
            InitializeComponent();

            viewModel = new SurgeriesDoctorViewModel(DatabaseService.Instance);

            if(App.selected_Patient != null)
            {
                surgeries = viewModel.GetSurgeries(App.selected_Patient.umcn);

                SurgeriesGrid.ItemsSource = surgeries;

            }
        }
    }
}
