namespace DBAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AdditionalServices
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AdditionalServices()
        {
            SaleLines = new HashSet<SaleLines>();
            Model = new HashSet<Model>();
        }

        public int id { get; set; }

        [Required]
        public string name { get; set; }

        public int? number { get; set; }

        public decimal price { get; set; }

        [Required]
        public byte[] photo { get; set; }

        public int category_services_id { get; set; }

        public virtual CategoryServices CategoryServices { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SaleLines> SaleLines { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Model> Model { get; set; }
    }
}
