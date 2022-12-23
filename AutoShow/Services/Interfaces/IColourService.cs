using AutoShow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoShow.Services.Interfaces
{
    public interface IColourService
    {
        List<ColourModel> GetColours();
        string GetColourNameById(int id);
        ColourModel GetColour(int id);
    }
}
