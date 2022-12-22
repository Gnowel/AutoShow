using AutoShow.Models.Base;
using DBAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoShow.Models
{
    public class EquipmentModel : ModelBase
    {
        private string  _name;
        private int     _modelId;
        private int     _engineId;
        private int     _transmissionId;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public int ModelId
        {
            get => _modelId;
            set
            {
                _modelId = value;
                OnPropertyChanged(nameof(ModelId));
            }
        }
        public int EngineId
        {
            get => _engineId;
            set 
            {
                _engineId = value;
                OnPropertyChanged(nameof(EngineId));
            }
        }
        public int Id { get; private set; }
        public EquipmentModel() { }
        public EquipmentModel(Equipment equipment)
        {
            Id          = equipment.id;
            Name        = equipment.name;
            ModelId     = equipment.model_id;
            EngineId    = equipment.engine_id;
        }
    }
}
