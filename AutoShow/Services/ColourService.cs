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
    public class ColourService : IColourService
    {
        private readonly AutoShowDb _autoShowDb;

        public ColourService()
        {
            _autoShowDb = new AutoShowDb();

        }

        public string GetColourNameById(int id)
        {
            return _autoShowDb.Colour.Where(i => i.id == id).Select(i => i.name).FirstOrDefault();
        }

        public List<ColourModel> GetColours()
        {
            return _autoShowDb.Colour.AsEnumerable().Select(colour => new ColourModel(colour)).ToList();
        }

    }
}
