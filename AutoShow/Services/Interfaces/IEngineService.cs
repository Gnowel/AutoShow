using AutoShow.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoShow.Services.Interfaces
{
    public interface IEngineService
    {
        EngineModel GetEngine(int id);
    }
}
