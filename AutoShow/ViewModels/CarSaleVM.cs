using AutoShow.Models;
using AutoShow.Services;
using AutoShow.Services.Interfaces;
using AutoShow.Utilities;
using AutoShow.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Text;
using System.Windows;

namespace AutoShow.ViewModels
{
    class CarSaleVM : ViewModelBase
    {
        private ICarService         _carService;
        private IEquipmentService   _equipmentService;
        private IColourService      _colourService;
        private IEngineService      _engineService;

        private CarModel _selectedCar;

        private RelayCommand _buyCar;

        private void RefreshCar()
        {
            Cars = new ObservableCollection<CarModel>(_carService.GetCars());
            EngineModel engine;
            foreach(var c in Cars)
            {
                c.BrandName     = _equipmentService.GetBrandName(c.EquipmentId);
                c.ModelName     = _equipmentService.GetModelName(c.EquipmentId);
                c.TypeName      = _equipmentService.GetTypeName(c.EquipmentId);
                c.ColourName    = _colourService.GetColourNameById(c.ColourId);
                engine          = _engineService.GetEngine(c.EquipmentId);
                
                c.PowerName = engine.Power.ToString();
                c.FuelName  = engine.Fuel;
                c.GearName = _equipmentService.GetGearName(c.EquipmentId);

                if (c.Mileage == null)
                    c.MileageName = $"0 км";
                else
                    c.MileageName = $"{c.Mileage} км";
                c.PowerName += " л.с.";
                c.Name = $"{c.BrandName} {c.ModelName} {c.Year}";
            }

            OnPropertyChanged(nameof(Cars));
        }

        public ObservableCollection<CarModel> Cars { get; set; }

        public List<EngineModel> Engines { get; set; }
    
        public CarModel SelectedCar
        {
            get => _selectedCar;
            set
            {
                _selectedCar= value;
                OnPropertyChanged(nameof(SelectedCar));
            }
        }
        public CarSaleVM()
        {
            _carService         = new CarService();
            _equipmentService   = new EquipmentService();
            _colourService      = new ColourService();
            _engineService      = new EngineService();

            RefreshCar();
        }

        public RelayCommand BuyCar
        {
            get
            {
                return _buyCar ?? (
                    _buyCar = new RelayCommand(obj =>
                    {
                        if (SelectedCar.DateArrival != null)
                        {

                            RefreshCar();
                        }
                        else 
                        {
                            MessageBox.Show("Машины нет в наличии!");
                        }

                    }));
            }
        }
    }
}
