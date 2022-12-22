using AutoShow.Models;
using AutoShow.Services.Interfaces;
using AutoShow.Services;
using AutoShow.Utilities;
using AutoShow.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Linq.Expressions;
using System.Diagnostics;

namespace AutoShow.ViewModels
{
    class EditEmployeeVM : ViewModelBase
    {

        private readonly IEmployeeService _employeeService;
        private readonly IPositionService _positionService;


        private RelayCommand _accesEditCommand;
        private RelayCommand _canselCommand;

        private PositionModel   _selectedPosition;
        private EmployeeModel   _editEmployee;
        private int             _selectIndex;
        public EmployeeModel EditEmployee 
        {
            get => _editEmployee; 
            set
            {
                _editEmployee = value;
                OnPropertyChanged(nameof(EditEmployee));
            }
        }
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
        public int SelectedIndex
        {
            get => _selectIndex;
            set
            {
                _selectIndex = value;
                OnPropertyChanged(nameof(SelectedIndex));
            }
        }
        private void TakeEmployee(EmployeeModel employee)
        {
            EditEmployee = employee;
            SelectedPosition = _positionService.GetPosition(employee.PositionId);

            int index = 0;

            foreach(var p in Positions)
            {
                if (SelectedPosition.Id == p.Id)
                    break;
                index++;
            }
            SelectedIndex = index;

            OnPropertyChanged(nameof(SelectedPosition));
            OnPropertyChanged(nameof(EditEmployee));
            OnPropertyChanged(nameof(SelectedIndex));
        }
        public EditEmployeeVM()
        {
            _employeeService = new EmployeeService();
            _positionService = new PositionService();

            EmployeeVM.Send += TakeEmployee;
            Positions = new List<PositionModel>(_positionService.GetPositions());
        }

        public RelayCommand AcceEditCommand
        {
            get
            {
                return _accesEditCommand ??
                    (_accesEditCommand = new RelayCommand(obj =>
                    {
                        EditEmployee.PositionId = SelectedPosition.Id;
                        _employeeService.EditEmployee(EditEmployee);
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
