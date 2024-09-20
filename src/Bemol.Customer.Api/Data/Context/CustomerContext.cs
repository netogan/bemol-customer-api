using Microsoft.EntityFrameworkCore;

namespace Bemol.Customer.Api.Data.Context
{
    public class CustomerContext(DbContextOptions<CustomerContext> options) : DbContext(options)
    {
        public DbSet<Domain.Models.Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Domain.Models.Customer>(entity =>
                {
                    entity.HasKey(e => e.Id);
                    entity.Property(e => e.Id).ValueGeneratedOnAdd();
                    entity.Property(e => e.FullName).IsRequired().HasMaxLength(200);
                    entity.Property(e => e.DocumentNumber).IsRequired().HasMaxLength(11).IsFixedLength();
                    entity.Property(e => e.Email).IsRequired();
                    entity.Property(e => e.Address).IsRequired();
                    entity.Property(e => e.ZipCode).IsRequired().HasMaxLength(8).IsFixedLength();
                    entity.Property(e => e.CreateAt).IsRequired().HasColumnType("timestamp").HasDefaultValueSql("CURRENT_TIMESTAMP");
                    entity.Property(e => e.IsActive).IsRequired().HasDefaultValue(true);

                });
        }
    }
}
