using System.Data.Entity;

namespace DataAccess
{
    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
        }       

        public virtual DbSet<talCustomer> talCustomers { get; set; }
        public virtual DbSet<talOccupation> talOccupations { get; set; }
        public virtual DbSet<talRating> talRatings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<talCustomer>()
                .Property(e => e.InsuranceAmount)
                .HasPrecision(18, 3);
            modelBuilder.Entity<talRating>()
               .Property(e => e.Factor)
               .HasPrecision(18, 2);
        }

    } // class
}
