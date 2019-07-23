namespace DataAccess
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("talCustomer")]
    public partial class talCustomer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(127)]
        public string Name { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DOB { get; set; }

        public long OccupationId { get; set; }

        public decimal InsuranceAmount { get; set; }

        public byte InsuranceType { get; set; }

        public byte CustomerStatus { get; set; }

        public long CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public long UpdatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
