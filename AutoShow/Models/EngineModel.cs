using AutoShow.ViewModels.Base;
using DBAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoShow.Models
{
    public class EngineModel : ViewModelBase
    {
        private double _volume;
        private int _power;
        private string _fuel;
        public int Id { get;  set; }
        public double Volume
        {
            get => _volume;
            set
            {
                _volume = value;
                OnPropertyChanged(nameof(Volume));
            }
        }
        public int Power
        {
            get => _power;
            set
            {
                _power = value;
                OnPropertyChanged(nameof(Power));
            }
        }
        public string Fuel
        {
            get => _fuel;
            set
            {
                _fuel = value;
                OnPropertyChanged(nameof(Fuel));
            }
        }
        public EngineModel() { }
        public EngineModel(Engine engine)
        {
            Id = engine.id;
            Volume = engine.volume;
            Power = engine.power;
            Fuel = engine.fuel;
        }
    }
}
