using AutoShow.Models;
using AutoShow.Services;
using AutoShow.Services.Interfaces;
using AutoShow.Utilities;
using DBAccess.Entities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
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

        public AddCarVM(IColourService colourService)
        {
            _colourService = colourService;

            //Colours = new ObservableCollection<ColourModel>(_colourService.GetColours());
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
                        //CarModel carModel = new CarModel();
                        CreateCar.EquipmentId   = 2;
                        CreateCar.ColourId      = 2;
                        ((Window)obj).Close();
                        _carService.InsertCar(CreateCar, FileName);
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
