using AutoShow.Utilities;
using AutoShow.ViewModels.Base;
using AutoShow.Views;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutoShow.ViewModels
{
    class NavigationVM : ViewModelBase
    {
        public delegate void SendHandler();
        public static event SendHandler Send;

        private object _currentView;

        private RelayCommand _logOutCommand;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public ICommand BrandCommand { get; set; }
        public ICommand EmployeeCommand { get;  set; }
        public ICommand CarCommand { get;   set; }
        public ICommand CarSaleCommand { get; set; }
        public ICommand AdditionalServiceCommand { get; set; }  
        public ICommand ClientCommand { get; set; }
        public RelayCommand LogOutCommand
        {
            get
            {
                return _logOutCommand ??
                    (_logOutCommand = new RelayCommand(obj =>
                    {
                        ((MainWindow)obj).Close();
                        Send?.Invoke();
                    }));


            }
        }

        private void Brand(object obj)      => CurrentView = new BrandVM();
        private void Employee(object obj)   => CurrentView = new EmployeeVM();
        private void Car(object obj)        => CurrentView = new CarVM();
        private void CarSale (object obj)   =>  CurrentView = new CarSaleVM();
        private void AdditionalService (object obj) => CurrentView = new AdditionalServiceVM();
        private void Client (object obj) => CurrentView = new ClientVM();    

        public NavigationVM()
        {
            BrandCommand                = new RelayCommand(Brand);
            CarCommand                  = new RelayCommand(Car);
            EmployeeCommand             = new RelayCommand(Employee);
            CarSaleCommand              = new RelayCommand(CarSale);
            AdditionalServiceCommand    = new RelayCommand(AdditionalService);
            ClientCommand               = new RelayCommand(Client);    

            CurrentView = new CarVM();
        }
    }
}
