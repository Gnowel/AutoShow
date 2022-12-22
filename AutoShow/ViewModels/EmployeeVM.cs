using AutoShow.Models;
using AutoShow.Services;
using AutoShow.Services.Interfaces;
using AutoShow.Utilities;
using AutoShow.ViewModels.Base;
using AutoShow.Views.Dialogs;
using DBAccess.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Policy;
using System.Text;
using System.Xml;

namespace AutoShow.ViewModels
{
    class EmployeeVM : ViewModelBase
    {
        public delegate void SendHandler(EmployeeModel employee);
        public static event SendHandler Send;

        private readonly IEmployeeService _employeeService;
        private readonly IPositionService _positionService;

        private EmployeeModel   _selectedEmployee;
        private int             _selectedIndex;

        private RelayCommand _addEmployeeCommand;
        private RelayCommand _deleteEmployeCommand;
        private RelayCommand _editEmployeeCommand;
        
        private void RefreshEmployees()
        {
            Employes = new ObservableCollection<EmployeeModel>(_employeeService.GetEmployees());
            OnPropertyChanged(nameof(Employes));
            foreach (var e in Employes)
            {
                int id = e.PositionId;
                e.PositionName = _positionService.GetPositionNameById(id);
            }
        }
        public EmployeeModel SelectedEmploye
        {
            get => _selectedEmployee;
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged(nameof(SelectedEmploye));
            }
        }
        
        public ObservableCollection<EmployeeModel> Employes { get; set; }
        public EmployeeVM()
        {
            _employeeService = new EmployeeService();
            _positionService = new PositionService();

            Employes = new ObservableCollection<EmployeeModel>(_employeeService.GetEmployees());

            RefreshEmployees();
        }

        public RelayCommand AddEmployeeCommand
        {
            get
            {
                return _addEmployeeCommand ??
                    (_addEmployeeCommand = new RelayCommand(obj =>
                    {
                        NewEmployeeDialog newEmployeeDialog = new NewEmployeeDialog();
                        newEmployeeDialog.ShowDialog();
                        RefreshEmployees();
                    }));
            }
        }
        public RelayCommand DeleteEmployeeCommand
        {
            get
            {
                return _deleteEmployeCommand ??
                    (_deleteEmployeCommand = new RelayCommand(obj =>
                    {
                        if(SelectedEmploye != null)
                        {
                            _employeeService.DeleteEmployee(SelectedEmploye.Id);
                            Employes.Remove(SelectedEmploye);
                        }
                    }));
            }
        }
        public RelayCommand EditEmployeeCommand
        {
            get
            {
                return _editEmployeeCommand ??
                    (_editEmployeeCommand = new RelayCommand(obj =>
                    {
                        EditEmployeeDialog editEmployeeDialog = new EditEmployeeDialog();
                        Send?.Invoke(SelectedEmploye);
                        editEmployeeDialog.ShowDialog();
                        RefreshEmployees();
                    }));
                   
            }
        }
    }
}
