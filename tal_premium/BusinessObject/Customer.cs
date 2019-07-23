namespace BusinessObject
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Customer
    {        
        public int Id { get; set; }

        [Required]
        public long OccupationId { get; set; }

        [Required]
        [StringLength(127)]
        public string Name { get; set; }

        [Required]
        public DateTime DOB { get; set; }
             
        public string OccupationName { get; set; }

        [Required]
        public decimal InsuranceAmount { get; set; }
        public byte InsuranceType { get; set; }
           
    }
}
