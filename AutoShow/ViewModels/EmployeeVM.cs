using AutoShow.Models;
using AutoShow.Services;
using AutoShow.Services.Interfaces;
using AutoShow.Utilities;
using AutoShow.ViewModels.Base;
using AutoShow.Views.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AutoShow.ViewModels
{
    class EmployeeVM : ViewModelBase
    {
        private readonly IEmployeeService _employeeService;
        private RelayCommand _addEmployeeCommand;

        public List<EmployeeModel> Employes { get; set; }
        public EmployeeVM()
        {
            _employeeService = new EmployeeService();

            Employes = new List<EmployeeModel>(_employeeService.GetEmployees());

            foreach(var e in Employes)
            {
                e.PositionName = _employeeService.GetPositionNameById(e.Id);
            }
        }
        public RelayCommand AddEmployeeCommand
        {
            get
            {
                return _addEmployeeCommand ??
                    (_addEmployeeCommand = new RelayCommand(obj =>
                    {
                        NewEmployeeDialog newEmployeeDialog = new NewEmployeeDialog();

                        newEmployeeDialog.Closed += (obj, e) =>
                        {
                            //Employes = _employeeService.GetEmployees();
                        };
                        newEmployeeDialog.ShowDialog();
                        Employes = _employeeService.GetEmployees();
                    }));
            }
        }
    }
}
