using AutoShow.Models.Base;
using DBAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoShow.Models
{
    class TypeModel : ModelBase
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
        public TypeModel(DBAccess.Entities.Type type)
        {
            Id = type.id;
            Name = type.name;
        }
    }
}
