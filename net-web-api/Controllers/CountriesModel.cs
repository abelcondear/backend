namespace WebAPI.Controllers
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CountriesModel : DbContext
    {
        public CountriesModel()
            : base("name=Model13")
        {
        }

        public virtual DbSet<border> border { get; set; }
        public virtual DbSet<coordinate> coordinate { get; set; }
        public virtual DbSet<country> country { get; set; }
        public virtual DbSet<language> language { get; set; }
        public virtual DbSet<timezone> timezone { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<border>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<country>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<country>()
                .Property(e => e.capital)
                .IsUnicode(false);

            modelBuilder.Entity<country>()
                .Property(e => e.region)
                .IsUnicode(false);

            modelBuilder.Entity<country>()
                .Property(e => e.subregion)
                .IsUnicode(false);

            modelBuilder.Entity<country>()
                .Property(e => e.currency)
                .IsUnicode(false);

            modelBuilder.Entity<country>()
                .Property(e => e.flag)
                .IsUnicode(false);

            modelBuilder.Entity<country>()
                .HasMany(e => e.border)
                .WithOptional(e => e.country)
                .HasForeignKey(e => e.country_id);

            modelBuilder.Entity<country>()
                .HasMany(e => e.coordinate)
                .WithOptional(e => e.country)
                .HasForeignKey(e => e.country_id);

            modelBuilder.Entity<country>()
                .HasMany(e => e.language)
                .WithOptional(e => e.country)
                .HasForeignKey(e => e.country_id);

            modelBuilder.Entity<country>()
                .HasMany(e => e.timezone)
                .WithOptional(e => e.country)
                .HasForeignKey(e => e.country_id);

            modelBuilder.Entity<language>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<timezone>()
                .Property(e => e.name)
                .IsUnicode(false);
        }
    }
}
