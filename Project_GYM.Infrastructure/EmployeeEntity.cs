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
        public long EmployeeId { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string Surname { get; set; }

        [Column("First name")]
        [Required]
        [StringLength(2147483647)]
        public string FirstName { get; set; }

        [StringLength(2147483647)]
        public string Patronymic { get; set; }

        [Column("Date of birth")]
        [StringLength(2147483647)]
        public string DateOfBirth { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string Gender { get; set; }

        [Column("Length of service")]
        public decimal LengthOfService { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string Password { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string Login { get; set; }

        [Column("Job_title_ID")]
        public long JobTitleId { get; set; }

        [Column("ID Gym")]
        public long IdGym { get; set; }

        public virtual JobTitleEntity JobTitle { get; set; }

        public virtual GymEntity Gym { get; set; }
    }
}
