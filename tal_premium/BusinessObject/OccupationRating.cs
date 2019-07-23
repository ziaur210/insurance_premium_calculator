namespace BusinessObject
{

    public partial class OccupationRating
    {      
        public int RatingId { get; set; }                
        public string Name { get; set; }

        public double Factor { get; set; }
               
        public string Description { get; set; }
    }
}
