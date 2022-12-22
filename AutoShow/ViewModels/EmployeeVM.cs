using AutoShow.Models;
using AutoShow.Services;
using AutoShow.Services.Interfaces;
using AutoShow.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AutoShow.ViewModels
{
    class EmployeeVM : ViewModelBase
    {
        private readonly IEmployeeService _employeeService;

        public ObservableCollection<EmployeeModel> Employes { get; set; }
        public EmployeeVM()
        {
            _employeeService = new EmployeeService();

            Employes = new ObservableCollection<EmployeeModel>(_employeeService.GetEmployees());

            foreach(var e in Employes)
            {
                e.PositionName = _employeeService.GetPositionNameById(e.Id);
            }
        }
    }
}
