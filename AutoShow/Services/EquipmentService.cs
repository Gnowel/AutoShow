using AutoShow.Models;
using AutoShow.Services.Interfaces;
using DBAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoShow.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly AutoShowDb _autoShowDb;

        public EquipmentService()
        {
            _autoShowDb = new AutoShowDb();
        }
        public List<EquipmentModel> GetEquipments()
        {
            return _autoShowDb.Equipment.AsEnumerable().Select(equipment => new EquipmentModel(equipment)).ToList();
        }
    }
}
