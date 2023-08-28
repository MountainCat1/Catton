using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Conventions.Infrastructure.DataEntities
{
    public class TicketTemplateData
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool Available { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public Guid AuthorId { get; set; }
        public Guid? LastEditAuthorId { get; set; }
    }

    public class TicketTemplateEntityConfiguration : IEntityTypeConfiguration<TicketTemplateData>
    {
        public void Configure(EntityTypeBuilder<TicketTemplateData> builder)
        {
            builder.ToTable("TicketTemplates");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(t => t.Description)
                .HasMaxLength(500);

            builder.Property(t => t.Price)
                .IsRequired();

            builder.Property(t => t.Available)
                .IsRequired();

            builder.Property(t => t.CreateDate)
                .IsRequired();

            builder.Property(t => t.LastUpdateDate)
                .IsRequired();

            // Configure relationships, indexes, etc.
        }
    }
}