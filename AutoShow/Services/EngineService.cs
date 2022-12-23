using AutoShow.Models;
using AutoShow.Services.Interfaces;
using DBAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static AutoShow.Services.EquipmentService;

namespace AutoShow.Services
{
    public class EngineService : IEngineService
    {
        private readonly AutoShowDb _autoShowDb;
        public EngineService() 
        {
            _autoShowDb = new AutoShowDb();
        }
        public class DateEngine
        {
            public int idE;
            public int id;
            public string fuel;
            public double volume;
            public int power;
        }

        public EngineModel GetEngine(int id)
        {
            var res = _autoShowDb.Equipment.Join(
                        _autoShowDb.Engine,
                        e => e.engine_id,
                        m => m.id,
                        (e, m) => new DateEngine
                        {
                            idE = e.id,
                            id = m.id,
                            volume = m.volume,
                            fuel= m.fuel,
                            power= m.power,
                        }).Where(e => e.idE == id).FirstOrDefault();
            return new EngineModel()
            {
                Id      = res.id,
                Volume  = res.volume,
                Power   = res.power,
                Fuel    = res.fuel,
            };

        }
    }
}
