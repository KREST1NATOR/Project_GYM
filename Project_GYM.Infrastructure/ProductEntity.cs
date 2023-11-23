namespace Project_GYM.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class ProductEntity
    {
        [Key]
        [Column("Product ID")]
        public long ProductId { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public decimal Quantity { get; set; }

        [Column("Expiration date")]
        [Required]
        [StringLength(2147483647)]
        public string ExpirationDate { get; set; }

        [Column("Product category ID")]
        public long ProductCategoryId { get; set; }

        [Column("ID Gym")]
        public long IdGym { get; set; }

        public virtual GymEntity Gym { get; set; }

        public virtual ProductCategoryEntity ProductCategory { get; set; }
    }
}
