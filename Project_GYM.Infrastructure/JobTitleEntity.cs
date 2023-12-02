namespace Project_GYM.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Job title")]
    public partial class JobTitleEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public JobTitleEntity()
        {
            Employee = new HashSet<EmployeeEntity>();
        }

        [Key]
        [Column("Job title ID")]
        public long JobTitleId { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string Title { get; set; }

        public decimal Salary { get; set; }

        [Column("Work schedule")]
        public string WorkSchedule { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeEntity> Employee { get; set; }
    }
}
