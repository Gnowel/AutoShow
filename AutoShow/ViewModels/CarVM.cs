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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutoShow.ViewModels
{
    class CarVM : ViewModelBase
    {
        public delegate void SendHandler(CarModel ca);
        public static event SendHandler Send;

        private readonly ICarService        _carService;
        private readonly IEquipmentService  _equipmentService;
        private readonly IColourService     _colourService;

        private RelayCommand _addCarCommand;
        private RelayCommand _editCarCommand;
        private RelayCommand _deleteCarCommand;

        private CarModel _selectedCar;
        private void RefreshCars()
        {
            Cars = new ObservableCollection<CarModel>(_carService.GetCars());
            OnPropertyChanged(nameof(Cars));
            foreach(var e in Cars)
            {
                e.EquipmentName = _equipmentService.GetEquipmentNameById(e.EquipmentId);
                e.ColourName    = _colourService.GetColourNameById(e.ColourId);
            }

        }
        public ObservableCollection <CarModel> Cars { get; set; }
        public CarModel SelectedCar
        {
            get => _selectedCar;
            set
            {
                _selectedCar = value;
                OnPropertyChanged(nameof(SelectedCar));
            }
        }
        public CarVM()
        {
            _carService         = new CarService();
            _equipmentService   = new EquipmentService();
            _colourService      = new ColourService();

            RefreshCars();
        }
        public RelayCommand AddCarCommand
        {
            get
            {
                return _addCarCommand ??
                    (_addCarCommand = new RelayCommand(obje =>
                    {
                        NewCarDialog newCarDialog = new NewCarDialog();
                        newCarDialog.ShowDialog();
                        RefreshCars();
                    }));
            }
        }
        public RelayCommand DeleteCarCommand
        {
            get
            {
                return _deleteCarCommand ??
                    (_deleteCarCommand = new RelayCommand(obj =>
                    {
                        if (SelectedCar != null)
                        {
                            _carService.DeleteCar(SelectedCar.Id);
                            Cars.Remove(SelectedCar);
                        }
                    }));
            }
        }
        public RelayCommand EditCarCommand
        {
            get
            {
                return _editCarCommand ??
                    (_editCarCommand = new RelayCommand(obje =>
                    {
                        EditCarDialog editCarDialog = new EditCarDialog();
                        Send?.Invoke(SelectedCar);
                        editCarDialog.ShowDialog();
                        RefreshCars();
                    }));
            }
        }

    }
}
