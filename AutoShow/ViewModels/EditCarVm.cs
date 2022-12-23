using AutoShow.Models;
using AutoShow.Services;
using AutoShow.Services.Interfaces;
using AutoShow.Utilities;
using AutoShow.ViewModels.Base;
using AutoShow.Views.UC;
using DBAccess.Entities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace AutoShow.ViewModels
{
    class EditCarVm : ViewModelBase
    {
        private readonly ICarService        _carService;
        private readonly IEquipmentService  _equipmentService;
        private readonly IColourService     _colourService;

        private RelayCommand _accessEditCommand;
        private RelayCommand _canselCommand;
        private RelayCommand _addPhotoCommand;


        private ColourModel     _selectedColour;
        private EquipmentModel  _selectedEquipment;
        private CarModel        _editCar;
        private int             _selectIndexEquipment;
        private int             _selectIndexColour;

        private void TakeCar(CarModel car)
        {
            EditCar             = car;

            SelectedEquipment   = _equipmentService.GetEquipment(car.EquipmentId);
            SelectedColour      = _colourService.GetColour(car.ColourId);

            SelectIndexEquipment = 0;
            SelectIndexColour = 0;
            foreach (var e in Equipments)
            {
                if (SelectedEquipment.Id == e.Id) break;
                SelectIndexEquipment++;
            }
            foreach(var c in Colours)
            {
                if(SelectedColour.Id == c.Id) break;
                SelectIndexColour++;
            }


            OnPropertyChanged(nameof(EditCar));
            OnPropertyChanged(nameof(SelectedEquipment));
            OnPropertyChanged(nameof(SelectedColour));
            OnPropertyChanged(nameof(SelectIndexEquipment));
            OnPropertyChanged(nameof(SelectIndexColour));
        }
        public List<EquipmentModel> Equipments { get; set; } 
        public List<ColourModel> Colours { get; set; }
        public CarModel EditCar 
        {
            get => _editCar;
            set
            {
                _editCar= value;
                OnPropertyChanged(nameof(EditCar));
            }
        }
        public ColourModel SelectedColour
        {
            get => _selectedColour;
            set
            {
                _selectedColour= value;
                OnPropertyChanged(nameof(SelectedColour));
            }
        }
        public EquipmentModel SelectedEquipment
        {
            get => _selectedEquipment;
            set
            {
                _selectedEquipment= value;
                OnPropertyChanged(nameof(SelectedEquipment));
            }
        }
        public int SelectIndexEquipment
        {
            get => _selectIndexEquipment;
            set
            {
                _selectIndexEquipment = value;
                OnPropertyChanged(nameof(SelectIndexEquipment));
            }
        }
        public int SelectIndexColour
        {
            get => _selectIndexColour;
            set
            {
                _selectIndexColour = value;
                OnPropertyChanged(nameof(SelectIndexColour));
            }
        }

        public EditCarVm()
        {
            _colourService = new ColourService();
            _carService = new CarService();
            _equipmentService = new EquipmentService();

            CarVM.Send += TakeCar;

            Colours = new List<ColourModel>(_colourService.GetColours());
            Equipments = new List<EquipmentModel>(_equipmentService.GetEquipments());
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

                        if (openFileDialog.ShowDialog().Value)
                        {
                            EditCar.PhotoBytes = File.ReadAllBytes(openFileDialog.FileName);

                            var random = new Random();

                            Brush Brush = new SolidColorBrush(Color.FromRgb((byte)random.Next(0, 255),
                                                                      (byte)random.Next(0, 255),
                            (byte)random.Next(0, 255)));

                            try
                            {
                                using (Stream StreamObj = new MemoryStream(EditCar.PhotoBytes))
                                {
                                    var image = new BitmapImage();

                                    image.BeginInit();
                                    image.CacheOption = BitmapCacheOption.OnLoad;
                                    image.StreamSource = StreamObj;
                                    image.EndInit();

                                    EditCar.ImageToShow = image;
                                }
                            }
                            catch
                            {
                                Debug.WriteLine($"Ошибка инициализации изображения пользователя {this}");
                            }
                        }
                    }));


            }
        }
        public RelayCommand AccessEditCommand
        {
            get
            {
                return _accessEditCommand ??
                    (_accessEditCommand = new RelayCommand(obj =>
                    {
                        EditCar.EquipmentId = SelectedEquipment.Id;
                        EditCar.ColourId= SelectedColour.Id;
                        _carService.EditCar(EditCar);
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
