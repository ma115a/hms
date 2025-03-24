using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazeProject
{
    public class SharedDoctorViewModel : INotifyPropertyChanged
    {
        private Patient _sharedData;

        public Patient patient
        {
            get => _sharedData;
            set
            {
                _sharedData = value;
                OnPropertyChanged(nameof(patient));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
