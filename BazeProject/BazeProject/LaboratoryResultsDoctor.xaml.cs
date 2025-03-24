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
    /// Interaction logic for LaboratoryResultsDoctor.xaml
    /// </summary>
    public partial class LaboratoryResultsDoctor : UserControl
    {
        private LaboratoryTestResultDoctorViewModel viewModel;
        private List<LabResult> labResults;
        public LaboratoryResultsDoctor()
        {
            InitializeComponent();

            viewModel = new LaboratoryTestResultDoctorViewModel(DatabaseService.Instance);
            
            if(App.selected_Patient != null)
            {
                labResults = viewModel.GetLabResults(App.selected_Patient.umcn);


                LabResultGrid.ItemsSource = labResults;
            }
        }
    }
}
