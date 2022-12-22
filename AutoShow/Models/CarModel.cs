using AutoShow.Models.Base;
using AutoShow.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AutoShow.Models
{

    public class CarModel : ModelBase , IDataErrorInfo
    {
        private decimal     _price;
        private string      _manufacture;
        private string      _year;
        private bool        _status;
        private int         _seat;
        private int?        _mileage;
        private string      _vin;
        private DateTime?   _dateArrival;
        private int         _equipmentId;
        private int         _colourId;
        private Brush       _brush;
        private ImageSource _imageToSource;

        private static readonly string[] ValidatedProperties = { "Price", "Manufacture", "Year", "Status", "Seat", "Mileage", "VIN", "DateArrival", "PhotoBytes", "EquipmentId", "ColourId" };
        public int Id { get; private set; }
        public decimal Price 
        { 
            get => _price; 
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
        public string Manufacture 
        {
            get => _manufacture;
            set
            {
                _manufacture = value;
                OnPropertyChanged(nameof(Manufacture));
            }
        }
        public string Year 
        { 
            get => _year; 
            set
            {
                _year = value;
                OnPropertyChanged(nameof(Year));
            }
        }
        public bool Status 
        { 
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }
        public int Seat 
        { 
            get => _seat; 
            set
            {
                _seat = value;
                OnPropertyChanged(nameof(Seat));
            }
        }
        public int? Mileage 
        {
            get => _mileage;
            set
            {
                _mileage = value;
                OnPropertyChanged(nameof(Mileage));
            }
        }
        public string VIN 
        {
            get => _vin;
            set
            {
                _vin = value;
                OnPropertyChanged(nameof(VIN));
            }
        }
        public DateTime? DateArrival 
        {
            get => _dateArrival;
            set
            {
                _dateArrival = value;
                OnPropertyChanged(nameof(DateArrival));
            }
        }
        public byte[] PhotoBytes;
        public int EquipmentId
        { 
            get => _equipmentId; 
            set
            {
                _equipmentId = value;
                OnPropertyChanged(nameof(EquipmentId));
            }
        }
        public int ColourId 
        {
            get => _colourId;
            set
            {
                _colourId = value;
                OnPropertyChanged(nameof(ColourId));
            }
        }
        public Brush Brush
        {
            get => _brush;
            set
            {
                _brush = value;
                OnPropertyChanged(nameof(Brush));
            }
        }
        public ImageSource ImageToShow
        {
            get => _imageToSource;
            set
            {
                _imageToSource = value;
                OnPropertyChanged(nameof(ImageToShow));
            }
        }


        #region Error

        public string Error => throw new NotImplementedException();

        public bool isValid
        {
            get
            {
                foreach(string property in ValidatedProperties)
                {
                    if(GetValidateError(property) != null)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        public string this[string columnName]
        {
            get
            {
                return GetValidateError(columnName);
            }
        }
        public string GetValidateError(string propertyName)
        {
            string error = null;

            switch (propertyName)
            {
                case "Price":
                    if(Price <= 0)
                    {
                        error = "Цена не может быть равна 0!";
                    }
                    //decimal decVal = 0;
                    //bool canConvert = decimal.TryParse(Convert.ToString(Price), out decVal);
                    //if(canConvert)
                    //{
                    //    return error = "Цена не может быть символами!";
                    //}
                    break;
            }
            return error;

        }
        #endregion
        public CarModel() { }
        public CarModel(DBAccess.Entities.Car car)
        {
            Id          = car.id;
            Price       = car.price;
            Manufacture = car.manufacture;
            Year        = car.year;
            Status      = car.status;
            Seat        = car.seat;
            Mileage     = car.mileage;
            VIN         = car.vin;
            DateArrival = car.date_arrival;
            PhotoBytes  = car.photo;
            EquipmentId = car.equipment_id;
            ColourId    = car.colour_id;

            var random = new Random();
            Brush = new SolidColorBrush(Color.FromRgb((byte)random.Next(0, 255),
                                                      (byte)random.Next(0, 255),
                                                      (byte)random.Next(0, 255)));

            try
            {
                using(Stream StreamObj = new MemoryStream(car.photo))
                {
                    var image = new BitmapImage();

                    image.BeginInit();
                    image.CacheOption   = BitmapCacheOption.OnLoad;
                    image.StreamSource  = StreamObj;
                    image.EndInit();

                    ImageToShow = image;
                }
            }
            catch
            {
                Debug.WriteLine($"Ошибка инициализации изображения пользователя {this}");
            }
        }
    }
}
