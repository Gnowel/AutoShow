using AutoShow.Models.Base;
using DBAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoShow.Models
{
    class BrandModel : ModelBase
    {
        private string _name;

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
        public BrandModel() { }
        public BrandModel(Brand brand)
        {
            Id = brand.id;
            Name = brand.name;
        }
    }
}
