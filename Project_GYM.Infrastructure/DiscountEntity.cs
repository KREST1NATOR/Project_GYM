namespace Project_GYM.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Discount")]
    public partial class DiscountEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DiscountEntity()
        {
            Client = new HashSet<ClientEntity>();
        }

        [Key]
        [Column("Discount ID")]
        public long Discount_ID { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string Name { get; set; }

        public decimal Value { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientEntity> Client { get; set; }
    }
}
