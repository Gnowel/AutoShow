namespace DBAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SaleLines
    {
        public int id { get; set; }

        public int number { get; set; }

        public int additional_services_id { get; set; }

        public int sale_id { get; set; }

        public virtual AdditionalServices AdditionalServices { get; set; }

        public virtual Sale Sale { get; set; }
    }
}
