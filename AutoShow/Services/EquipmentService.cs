using AutoShow.Models;
using AutoShow.Services.Interfaces;
using DBAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace AutoShow.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly AutoShowDb _autoShowDb;

        public EquipmentService()
        {
            _autoShowDb = new AutoShowDb();
        }

        public class Date
        {
            public string name;
            public int Id;
        }

        public string GetModelName(int id)
        {
            var resutl = _autoShowDb.Equipment.Join(
                _autoShowDb.Model,
                e => e.model_id,
                m => m.id,
                (e, m) => new Date
                {
                    name = m.name,
                    Id = e.id
                }).Where(e => e.Id == id).FirstOrDefault();

            return resutl.name;
        }

        public EquipmentModel GetEquipment(int id)
        {
            return new EquipmentModel(_autoShowDb.Equipment.Find(id));
        }

        public string GetEquipmentNameById(int id)
        {
            return _autoShowDb.Equipment.Where(i => i.id == id).Select(i => i.name).FirstOrDefault();
        }

        public List<EquipmentModel> GetEquipments()
        {
            return _autoShowDb.Equipment.AsEnumerable().Select(equipment => new EquipmentModel(equipment)).ToList();
        }

        public string GetBrandName(int id)
        {
            var resutl = _autoShowDb.Equipment.Join(
                _autoShowDb.Model,
                e => e.model_id,
                m => m.id,
                (e, m) => new { e, m })
                .Join(
                _autoShowDb.Brand,
                ma => ma.m.brand_id,
                b => b.id,
                (ma, b) => new Date
                {
                    Id = ma.e.id,
                    name= b.name,
                }).Where(e => e.Id == id).FirstOrDefault();

            return resutl.name;
        }

        public string GetTypeName(int id)
        {
            var resutl = _autoShowDb.Equipment.Join(
                _autoShowDb.Model,
                e => e.model_id,
                m => m.id,
                (e, m) => new { e, m })
                .Join(
                _autoShowDb.Type,
                ma => ma.m.type_id,
                t => t.id,
                (ma, t) => new Date
                {
                    Id = ma.e.id,
                    name = t.name,
                }).Where(e => e.Id == id).FirstOrDefault();

            return resutl.name;
        }

        public string GetGearName(int id)
        {
            var resutl = _autoShowDb.Equipment.Join(
                _autoShowDb.Transmission,
                e => e.transmission_id,
                m => m.id,
                (e, m) => new Date
                {
                    name = m.gear,
                    Id = e.id
                }).Where(e => e.Id == id).FirstOrDefault();

            return resutl.name;
        }
    }
}
