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
        public long ClientId { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string Surname { get; set; }

        [Column("First name")]
        [Required]
        [StringLength(2147483647)]
        public string FirstName { get; set; }

        [StringLength(2147483647)]
        public string Patronymic { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string Gender { get; set; }

        [Column("Date of birth")]
        [Required]
        [StringLength(2147483647)]
        public string DateOfBirth { get; set; }

        [Column("Discount ID")]
        public long DiscountId { get; set; }

        [Column("ID Gym")]
        public long IdGym { get; set; }

        public virtual DiscountEntity Discount { get; set; }

        public virtual GymEntity Gym { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SubscriptionEntity> Subscription { get; set; }
    }
}
