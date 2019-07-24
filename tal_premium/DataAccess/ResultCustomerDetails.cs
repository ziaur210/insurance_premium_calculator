using System;

namespace DataAccess
{
    public class ResultCustomerDetails 
    {        
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public int OccupationId { get; set; }
        public string OccupationName { get; set; }
        public decimal InsuranceAmount { get; set; }
        public byte InsuranceType { get; set; }
        public byte CustomerStatus { get; set; }
        public int RatingId { get; set; }
        public string RatingName { get; set; }
        public decimal RatingFactor { get; set; }

    }
}