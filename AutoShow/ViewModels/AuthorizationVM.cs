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

        private RelayCommand _signInCommand;

        public event Action OnClosed;
        public EmployeeModel Employee { get; set; }
        public AuthorizationVM()
        {
            _employeeService = new EmployeeService();

            Employee = new EmployeeModel()
            {
                Login = "",
                Password = "  "
            };
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

                    if (currentEmployer != null)
                    {
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        OnClosed?.Invoke();
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль!");
                    }
                },
                (obj) => Employee.IsValid);
            }
        }
    }
}
