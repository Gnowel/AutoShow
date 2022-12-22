using AutoShow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoShow.Services.Interfaces
{
    public interface ICarService
    {
        List<CarModel> GetCars();
        void InsertCar(CarModel carModel, string photoUri);
    }
}
