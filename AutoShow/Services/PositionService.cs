using AutoShow.Models;
using AutoShow.Services.Interfaces;
using AutoShow.Views.UC;
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

        public int GetPositionIdByName(string name)
        {
            return _autoShowDb.Position.Where(n => n.name == name).Select(i => i.id).FirstOrDefault();
        }

        public List<PositionModel> GetPositions()
        {
            return _autoShowDb.Position.AsEnumerable().Select(position => new PositionModel(position)).ToList();
        }
        public string GetPositionNameById(int id)
        {
            return _autoShowDb.Position.Where(i => i.id == id).Select(i => i.name).FirstOrDefault();
        }

        public PositionModel GetPosition(int id)
        {
            return  new PositionModel(_autoShowDb.Position.Find(id));

        }
    }
}
