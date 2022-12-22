using AutoShow.Models.Base;
using DBAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoShow.Models
{
    public class PositionModel : ModelBase
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
        public PositionModel() { }
        public PositionModel(Position position)
        {
            Id = position.id;
            Name = position.name;
        }
    }
}
