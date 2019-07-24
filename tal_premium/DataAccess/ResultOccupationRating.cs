using System;

namespace DataAccess
{
    public class ResultOccupationRating 
    {        
        public int OccupationId { get; set; }
        public string OccupationName { get; set; }       
        public int RatingId { get; set; }
        public string RatingName { get; set; }       
        public decimal RatingFactor { get; set; }

    }
}