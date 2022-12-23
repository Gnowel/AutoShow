using AutoShow.Models;
using AutoShow.Services;
using AutoShow.Services.Interfaces;
using AutoShow.Utilities;
using AutoShow.ViewModels.Base;
using DBAccess.Entities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AutoShow.ViewModels
{
    class AddCarVM : ViewModelBase
    {
        private readonly IColourService _colourService;
        private readonly IEquipmentService _equipmentService;
        private readonly ICarService _carService;

        private RelayCommand _addPhotoCommand;
        private RelayCommand _addCarCommand;
        private RelayCommand _canselCommand;

        private string _fileName;
        private EquipmentModel  _selectedEquipment;
        private ColourModel     _selectedColour;

        public CarModel CreateCar 
        {
            get; 
            set;
        }
        public List<ColourModel> Colours { get; set; }
        public List<EquipmentModel> Equipments { get; set; }
        public String FileName
        {
            get => _fileName;
            set
            {
                _fileName = value;
                OnPropertyChanged(nameof(FileName));
            }
        }
        public EquipmentModel SelectedEquipment
        {
            get => _selectedEquipment;
            set
            {
                _selectedEquipment = value;
                OnPropertyChanged(nameof(SelectedEquipment));
            }
        }
        public ColourModel SelectedColour
        {
            get => _selectedColour;
            set
            {
                _selectedColour = value;
                OnPropertyChanged(nameof(SelectedColour));
            }
        }
        public AddCarVM(IColourService colourService)
        {
            _colourService = colourService;

        }

        public AddCarVM() 
        {
            _colourService      = new ColourService();
            _carService         = new CarService();
            _equipmentService   = new EquipmentService();

            CreateCar = new CarModel();

            Colours     = new List<ColourModel>(_colourService.GetColours());
            Equipments  = new List<EquipmentModel>(_equipmentService.GetEquipments());
        }   

        
        public RelayCommand AddPhotoCommand
        {
            get
            {
                return _addPhotoCommand ??
                    (_addPhotoCommand = new RelayCommand(obj =>
                    {
                        OpenFileDialog openFileDialog = new OpenFileDialog();
                        openFileDialog.Filter = "Файлы рисунков (*.bmp, *.jpg)|*.bmp;*.jpg";
                        openFileDialog.DefaultExt = ".jpeg";
                            
                        if(openFileDialog.ShowDialog().Value)
                        {
                            FileName = openFileDialog.FileName;
                        }
                    }));


            }
        }
        public RelayCommand AddCarCommand
        {
            get
            {
                return _addCarCommand ??
                    (_addCarCommand = new RelayCommand(obj =>
                    {
                        CreateCar.EquipmentId   = SelectedEquipment.Id;
                        CreateCar.ColourId      = SelectedColour.Id;
                        _carService.InsertCar(CreateCar, FileName);
                        ((Window)obj).Close();
                    },
                    (obj) => CreateCar.isValid));
            }
        }
        public  RelayCommand CanselCommand
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
