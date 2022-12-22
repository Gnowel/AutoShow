using AutoShow.Models.Base;
using DBAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoShow.Models
{
    public class ColourModel : ModelBase
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
        public ColourModel (Colour colour)
        {
            Id = colour.id;
            Name = colour.name;
        }
    }
}
