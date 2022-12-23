using AutoShow.Models;
using AutoShow.Services.Interfaces;
using AutoShow.Utilities;
using AutoShow.ViewModels.Base;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AutoShow.ViewModels
{
    class EditCarVm : ViewModelBase
    {
        private readonly ICarService        _carService;
        private readonly IEquipmentService  _equipmentService;
        private readonly IColourService     _colourService;

        private RelayCommand _accesEditCommand;
        private RelayCommand _canselCommand;
        private RelayCommand _addPhotoCommand;


        private ColourModel     _selectedColour;
        private EquipmentModel  _selectedEquipment;
        private CarModel        _editCar;
        private int             _selectIndex;

        private void TakeCar(CarModel car)
        {
            EditCar = car;
            
        }

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
        public int SelectIndex
        {
            get => _selectIndex;
            set
            {
                _selectIndex= value;
                OnPropertyChanged(nameof(SelectIndex));
            }
        }

        public EditCarVm()
        {

            CarVM.Send += TakeCar;
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
                        }
                    }));


            }
        }
        
    }
}
