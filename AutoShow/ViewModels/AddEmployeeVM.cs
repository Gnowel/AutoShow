using AutoShow.Models;
using AutoShow.Services;
using AutoShow.Services.Interfaces;
using AutoShow.Utilities;
using AutoShow.ViewModels.Base;
using DBAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace AutoShow.ViewModels
{
    class AddEmployeeVM :  ViewModelBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IPositionService _positionService;

        private RelayCommand _addEmployeeCommand;
        private RelayCommand _canselCommand;

        private PositionModel _selectedPosition;

        //public event Action
        public EmployeeModel CreateEmployee { get; set; }
        public List<PositionModel> Positions { get; set; }
  
        public PositionModel SelectedPosition
        {
            get => _selectedPosition;
            set
            {
                _selectedPosition = value;
                OnPropertyChanged(nameof(SelectedPosition));
            }
        }
        public AddEmployeeVM()
        {
            _employeeService    = new EmployeeService();
            _positionService    = new PositionService();

            Positions           = new List<PositionModel>(_positionService.GetPositions());
            CreateEmployee      = new EmployeeModel() { Phone = "7"};
        }

        public RelayCommand AddEmployeeCommand
        {
            get
            {
                return _addEmployeeCommand ??
                    (_addEmployeeCommand = new RelayCommand(obj =>
                    {
                        CreateEmployee.PositionId = SelectedPosition.Id;
                        _employeeService.InsertEmployee(CreateEmployee);
                        ((Window)obj).Close();
                    }));
            }
        }
        public RelayCommand CanselCommand
        {
            get 
            {
                return _canselCommand ??
                    (_canselCommand = new RelayCommand(obj =>
                    {
                        ((Window)obj).Close();
                    }));
            }
        }
    }
}
