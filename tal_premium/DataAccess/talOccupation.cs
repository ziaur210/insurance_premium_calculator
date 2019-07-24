namespace DataAccess
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("talOccupation")]
    public partial class talOccupation
    {
        [Key]
        public int OccupationId { get; set; }

        [Required]
        [StringLength(127)]
        public string Name { get; set; }

        public int RatingId { get; set; }

        [Required]
        [StringLength(127)]
        public string Description { get; set; }

        public byte Status { get; set; }
    }
}
