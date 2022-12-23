using AutoShow.Models;
using DBAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoShow.Services.Interfaces
{
    public interface IEquipmentService
    {
        List<EquipmentModel> GetEquipments();
        string GetEquipmentNameById(int id);
        EquipmentModel GetEquipment(int id);
    }
}
