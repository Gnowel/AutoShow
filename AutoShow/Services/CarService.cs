using AutoShow.Models;
using AutoShow.Services.Interfaces;
using DBAccess.Entities;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;


namespace AutoShow.Services
{
    public class CarService : ICarService
    {
        private readonly AutoShowDb _autoShowDb;

        public CarService()
        {
            _autoShowDb = new AutoShowDb();
        }

        public List<CarModel> GetCars()
        {
            return _autoShowDb.Car.AsEnumerable().Select(car => new CarModel(car)).ToList();
        }

        public void InsertCar(CarModel carModel, string photoUri)
        {
            var newCar = new Car()
            {
                price           = carModel.Price,
                manufacture     = carModel.Manufacture,
                year            = carModel.Year,
                status          = carModel.Status,
                seat            = carModel.Seat,
                mileage         = carModel.Mileage,
                vin             = carModel.VIN,
                date_arrival    = carModel.DateArrival,
                equipment_id    = carModel.EquipmentId,
                colour_id       = carModel.ColourId
            };

            try
            {
                newCar.photo = File.ReadAllBytes(photoUri);
            }
            catch
            {

            }
            _autoShowDb.Car.Add(newCar);
            _autoShowDb.SaveChanges();
        }
    }
}
