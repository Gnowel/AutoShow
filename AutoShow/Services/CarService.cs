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
        private  AutoShowDb _autoShowDb;

            //        using(_autoShowDb = new AutoShowDb())
            //{

            //}

        public CarService()
        {
            _autoShowDb = new AutoShowDb();
        }

        public void DeleteCar(int id)
        {
            using (_autoShowDb = new AutoShowDb())
            {
                var currentCar = _autoShowDb.Car.Find(id);

                if(currentCar != null)
                {
                    _autoShowDb.Car.Remove(currentCar);
                    _autoShowDb.SaveChanges();
                }
            }
        }

        public void EditCar(CarModel carModel)
        {
            using(_autoShowDb = new AutoShowDb())
            {

                var editCar = _autoShowDb.Car.SingleOrDefault(c => c.id == carModel.Id);

                if(editCar != null)
                {
                    editCar.price           = carModel.Price;
                    editCar.manufacture     = carModel.Manufacture;
                    editCar.year            = carModel.Year;
                    editCar.status          = carModel.Status;
                    editCar.seat            = carModel.Seat;
                    editCar.mileage         = carModel.Mileage;
                    editCar.vin             = carModel.VIN;
                    editCar.date_arrival    = carModel.DateArrival;
                    editCar.photo           = carModel.PhotoBytes;
                    editCar.equipment_id    = carModel.EquipmentId;
                    editCar.colour_id       = carModel.ColourId;

                    _autoShowDb.SaveChanges();
                }
            }
        }

        public List<CarModel> GetCars()
        {
            _autoShowDb = new AutoShowDb();
            return _autoShowDb.Car.AsEnumerable().Select(car => new CarModel(car)).ToList();
            
        }

        public void InsertCar(CarModel carModel, string photoUri)
        {
            using (_autoShowDb = new AutoShowDb())
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
}
