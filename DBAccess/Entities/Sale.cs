namespace DBAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sale")]
    public partial class Sale
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sale()
        {
            SaleLines = new HashSet<SaleLines>();
        }

        public int id { get; set; }

        [Column(TypeName = "date")]
        public DateTime date { get; set; }

        public int? client_id { get; set; }

        public int employee_id { get; set; }

        public virtual Client Client { get; set; }

        public virtual Employee Employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SaleLines> SaleLines { get; set; }
    }
}
