using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotesApp.Domain.NoteAggregate;

namespace NotesApp.Infrastructure.Data.Config;

public class NoteConfiguration : IEntityTypeConfiguration<Note>
{
  public void Configure(EntityTypeBuilder<Note> builder)
  {
    builder.Property(p => p.Title)
      .HasMaxLength(100)
      .IsUnicode()
      .IsRequired();

    builder.Property(x => x.Content)
      .HasMaxLength(5000)
      .IsUnicode()
      .IsRequired();

    builder.Property(x => x.CreatedAt)
      .IsRequired();

    builder.Property(x => x.UpdatedAt);
  }
}
