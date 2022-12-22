using AutoShow.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutoShow.ViewModels
{
    class NavigationVM : ViewModelBase
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public ICommand BrandCommand { get; set; }
        public ICommand EmployeeCommand { get;  set; }
        public ICommand CarCommand { get;   set; }

        private void Brand(object obj)      => CurrentView = new BrandVM();
        private void Employee(object obj)  => CurrentView = new EmployeeVM();
        private void Car(object obj)        => CurrentView = new CarVM();

        public NavigationVM()
        {
            BrandCommand = new RelayCommand(Brand);
            CarCommand = new RelayCommand(Car);
            EmployeeCommand = new RelayCommand(Employee);
            //Начальная страница

            //CurrentView = new CarVM();
        }
    }
}
