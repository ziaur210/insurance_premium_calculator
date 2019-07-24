namespace DataAccess
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("talRating")]
    public partial class talRating
    {
        [Key]
        public int RatingId { get; set; }

        [Required]
        [StringLength(127)]
        public string Name { get; set; }

        public decimal Factor { get; set; }

        [Required]
        [StringLength(127)]
        public string Description { get; set; }
    }
}
