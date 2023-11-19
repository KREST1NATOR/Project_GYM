namespace Project_GYM.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class EmployeeEntity
    {
        [Key]
        [Column("Employee ID")]
        public long Employee_ID { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string Surname { get; set; }

        [Column("First name")]
        [Required]
        [StringLength(2147483647)]
        public string First_name { get; set; }

        [StringLength(2147483647)]
        public string Patronymic { get; set; }

        [Column("Date of birth")]
        [StringLength(2147483647)]
        public string Date_of_birth { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string Gender { get; set; }

        [Column("Length of service")]
        public decimal Length_of_service { get; set; }

        public long Job_title_ID { get; set; }

        [Column("ID Gym")]
        public long ID_Gym { get; set; }

        public virtual JobTitleEntity Job_title { get; set; }

        public virtual GymEntity Gym { get; set; }
    }
}
