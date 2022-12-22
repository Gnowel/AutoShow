namespace DBAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ContractSale")]
    public partial class ContractSale
    {
        public int id { get; set; }

        [Column(TypeName = "date")]
        public DateTime date { get; set; }

        public int employee_id { get; set; }

        public int client_id { get; set; }

        public int car_id { get; set; }

        public virtual Car Car { get; set; }

        public virtual Client Client { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
