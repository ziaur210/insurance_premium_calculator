namespace BusinessObject
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Customer
    {        
        public int Id { get; set; }
                       
        [Required]
        [StringLength(127)]
        public string Name { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        public decimal InsuranceAmount { get; set; }
        public byte InsuranceType { get; set; }

       [Required]
        public int OccupationId { get; set; }
        public string OccupationName { get; set; }
        public int OccupationRatingId { get; set; }
        public string OccupationRatingName { get; set; }
        public decimal OccupationRatingFactor { get; set; }

    }// class
}
