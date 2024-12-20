using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Notes.Application.interfaces;
using Notes.Domain;
using Notes.Persistence.EntityTypeConfiguration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Notes.Persistence;

public class NoteDbontext : DbContext, INotesDbContext
{
    public DbSet<Note> Notes { get; set; }

    public NoteDbontext(DbContextOptions<NoteDbontext> options) :base(options)
    {
        Database.EnsureCreated();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new NoteConfiguration());
        base.OnModelCreating(modelBuilder);
    }

    public Task<int> SaveChangeAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
