using AutoShow.Models;
using AutoShow.Services;
using AutoShow.Services.Interfaces;
using AutoShow.Utilities;
using AutoShow.ViewModels.Base;
using AutoShow.Views.Dialogs;
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
        private readonly ICarService _carService;
        private RelayCommand _addCarCommand;
        public ObservableCollection <CarModel> Cars { get; set; }
        public CarVM()
        {
            _carService = new CarService();

            Cars = new ObservableCollection<CarModel>(_carService.GetCars());
        }
        public RelayCommand AddCarCommand
        {
            get
            {
                return _addCarCommand ??
                    (_addCarCommand = new RelayCommand(obje =>
                    {
                        NewCarDialog newCarDialog = new NewCarDialog();
                        newCarDialog.Closed += (obj, e) =>
                        {

                        };
                        newCarDialog.ShowDialog();
                    }));
            }
        }
    }
}
