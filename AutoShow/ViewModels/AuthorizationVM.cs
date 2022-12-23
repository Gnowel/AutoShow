using AutoShow.Models;
using AutoShow.Services;
using AutoShow.Services.Interfaces;
using AutoShow.Utilities;
using AutoShow.ViewModels.Base;
using AutoShow.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AutoShow.ViewModels
{
    class AuthorizationVM : ViewModelBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IPositionService _positionService;

        private RelayCommand _signInCommand;

        private EmployeeModel _employee;

        public event Action OnClosed;
        public event Action OnActivated;
        public EmployeeModel Employee 
        {
            get => _employee;
            set
            {
                _employee= value;
                OnPropertyChanged(nameof(Employee));
            }
        }
        private void Show()
        {
            OnActivated?.Invoke();
            Employee = new EmployeeModel()
            {
                Login = "",
                Password = "  "
            };
            OnPropertyChanged(nameof(Employee));
        }
        public AuthorizationVM()
        {
            _employeeService = new EmployeeService();
            _positionService = new PositionService();

            Employee = new EmployeeModel()
            {
                Login = "",
                Password = "  "
            };

            NavigationVM.Send += Show;
        }
        public RelayCommand SignInCommand
        {
            get
            {
                return _signInCommand = new RelayCommand(obj =>
                {
                    var pass = ((PasswordBox)obj);
                    Employee.Password = ((PasswordBox)obj).Password;
                    var currentEmployer = _employeeService.SignIn(Employee.Login, Employee.Password);

                    ((PasswordBox)obj).Password = "";
                    if (currentEmployer != null)
                    {
                        currentEmployer.PositionName = _positionService.GetPositionNameById(currentEmployer.PositionId);

                        switch (currentEmployer.PositionName)
                        {
                            case "Администратор":
                                MainWindow mainWindow = new MainWindow();
                                mainWindow.Show();
                                break;
                            case "Продавец":
                                MainCommonWindow mainCommon = new MainCommonWindow();
                                mainCommon.Show();
                                break;
                        }

                        OnClosed?.Invoke();
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль!");
                    }
                },
                (obj) => Employee.IsValid)
                {

                };
            }
        }
    }
}
