using AutoShow.Models.Base;
using DBAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoShow.Models
{
    class ModelM : ModelBase
    {
        private string _name;
        private int _brandId;
        private int _typeId;

        public int Id { get; private set; }
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public int BrandId
        {
            get => _brandId;
            set
            {
                _brandId = value;
                OnPropertyChanged(nameof(BrandId));
            }
        }
        public int TypeId
        {
            get => _typeId;
            set
            {
                _typeId = value;
                OnPropertyChanged(nameof(TypeId));
            }
        }
        public ModelM(Model model)
        {
            Id      = model.id;
            Name    = model.name;
            BrandId = model.brand_id;
            TypeId  = model.type_id;
        }
    }
}
