using System;
using System.Collections.Generic;
using ITHelpdeskTicketSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ITHelpdeskTicketSystem.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comments__3214EC075F1866C6");

            entity.Property(e => e.PostedOn).HasDefaultValueSql("(sysdatetime())");

            entity.HasOne(d => d.Ticket).WithMany(p => p.Comments).HasConstraintName("FK_Comments_Tickets");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tickets__3214EC079C734A65");

            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Status).HasDefaultValue(1);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
