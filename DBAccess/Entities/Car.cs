namespace DBAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Car")]
    public partial class Car
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Car()
        {
            ContractSale = new HashSet<ContractSale>();
        }

        public int id { get; set; }

        public decimal price { get; set; }

        [Required]
        [StringLength(50)]
        public string manufacture { get; set; }

        [Required]
        [StringLength(4)]
        public string year { get; set; }

        public bool status { get; set; }

        public int seat { get; set; }

        public int? mileage { get; set; }

        [Required]
        [StringLength(17)]
        public string vin { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date_arrival { get; set; }

        [Required]
        public byte[] photo { get; set; }

        public int equipment_id { get; set; }

        public int colour_id { get; set; }

        public virtual Colour Colour { get; set; }

        public virtual Equipment Equipment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContractSale> ContractSale { get; set; }
    }
}
