using AutoShow.Models;
using AutoShow.Services.Interfaces;
using DBAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoShow.Services
{
    public class PositionService : IPositionService
    {
        private readonly AutoShowDb _autoShowDb;
        public PositionService()
        {
            _autoShowDb = new AutoShowDb();
        }

        public int GetIdByName(string name)
        {
            return _autoShowDb.Position.Where(n => n.name == name).Select(i => i.id).FirstOrDefault();
        }

        public List<PositionModel> GetPositions()
        {
            return _autoShowDb.Position.AsEnumerable().Select(position => new PositionModel(position)).ToList();
        }
    }
}
