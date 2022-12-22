namespace DBAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [Key]
        public int id_product { get; set; }

        public double price { get; set; }

        [Required]
        [StringLength(10)]
        public string name { get; set; }
    }
}
