﻿using AutoShow.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoShow.Services.Interfaces
{
    public interface IPositionService
    {
        List<PositionModel> GetPositions();
        int GetPositionIdByName(string name);
        //fddd
        string GetPositionNameById(int id);
        PositionModel GetPosition(int id);
    }
}
