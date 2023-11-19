namespace Project_GYM.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Client")]
    public partial class ClientEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ClientEntity()
        {
            Subscription = new HashSet<SubscriptionEntity>();
        }

        [Key]
        [Column("Client ID")]
        public long Client_ID { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string Surname { get; set; }

        [Column("First name")]
        [Required]
        [StringLength(2147483647)]
        public string First_name { get; set; }

        [StringLength(2147483647)]
        public string Patronymic { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string Gender { get; set; }

        [Column("Date of birth")]
        [Required]
        [StringLength(2147483647)]
        public string Date_of_birth { get; set; }

        [Column("Discount ID")]
        public long Discount_ID { get; set; }

        [Column("ID Gym")]
        public long ID_Gym { get; set; }

        public virtual DiscountEntity Discount { get; set; }

        public virtual GymEntity Gym { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SubscriptionEntity> Subscription { get; set; }
    }
}
