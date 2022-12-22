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
        public List<ColourModel> GetColours()
        {
            return _autoShowDb.Colour.AsEnumerable().Select(colour => new ColourModel(colour)).ToList();
        }
    }
}
