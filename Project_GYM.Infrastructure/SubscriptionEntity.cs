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
        public long SubscriptionId { get; set; }

        [Column("Start date")]
        [Required]
        [StringLength(2147483647)]
        public string StartDate { get; set; }

        [Column("End date")]
        [Required]
        [StringLength(2147483647)]
        public string EndDate { get; set; }

        [Column("Status ID")]
        public long StatusId { get; set; }

        public long SubscriptionTypeId { get; set; }

        [Column("ID Gym")]
        public long IdGym { get; set; }

        [Column("Client ID")]
        public long ClientId { get; set; }

        [Column("Trainer ID")]
        public long? TrainerId { get; set; }

        public virtual ClientEntity Client { get; set; }

        public virtual GymEntity Gym { get; set; }

        public virtual StatusEntity Status { get; set; }

        public virtual SubscriptionTypeEntity SubscriptionType { get; set; }

        public virtual TrainerEntity Trainer { get; set; }
    }
}
