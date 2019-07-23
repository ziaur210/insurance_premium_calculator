namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblOccupation")]
    public partial class talOccupation
    {
        [Key]
        public int OccupationId { get; set; }

        [Required]
        [StringLength(127)]
        public string Name { get; set; }

        public long RattingId { get; set; }

        [Required]
        [StringLength(127)]
        public string Description { get; set; }

        public byte Status { get; set; }
    }
}
