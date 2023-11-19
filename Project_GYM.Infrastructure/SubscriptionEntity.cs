namespace Project_GYM.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Subscription")]
    public partial class SubscriptionEntity
    {
        [Key]
        [Column("Subscription ID")]
        public long Subscription_ID { get; set; }

        [Column("Start date")]
        [Required]
        [StringLength(2147483647)]
        public string Start_date { get; set; }

        [Column("End date")]
        [Required]
        [StringLength(2147483647)]
        public string End_date { get; set; }

        [Column("Status ID")]
        public long Status_ID { get; set; }

        public long Subscription_type_ID { get; set; }

        [Column("ID Gym")]
        public long ID_Gym { get; set; }

        [Column("Client ID")]
        public long Client_ID { get; set; }

        [Column("Trainer ID")]
        public long? Trainer_ID { get; set; }

        public virtual ClientEntity Client { get; set; }

        public virtual GymEntity Gym { get; set; }

        public virtual StatusEntity Status { get; set; }

        public virtual SubscriptionTypeEntity Subscription_type { get; set; }

        public virtual TrainerEntity Trainer { get; set; }
    }
}
