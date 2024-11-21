using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace total_test_1.Models.Reviews;

public partial class ReviewsContext : DbContext
{
    public ReviewsContext()
    {
    }

    public ReviewsContext(DbContextOptions<ReviewsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Rating> Ratings { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Reviewer> Reviewers { get; set; }
    public object Review { get; internal set; }
    public object DateOnly { get; internal set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=ReviewsConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Rating>(entity =>
        {
            entity.HasKey(e => e.RatingId).HasName("PK__Ratings__FCCDF87CEBDFA6BE");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Reviews__74BC79CE87BA467A");

            entity.HasOne(d => d.Rating).WithMany(p => p.Reviews).HasConstraintName("FK__Reviews__RatingI__45F365D3");

            entity.HasOne(d => d.Reviewer).WithMany(p => p.Reviews).HasConstraintName("FK__Reviews__Reviewe__44FF419A");
        });

        modelBuilder.Entity<Reviewer>(entity =>
        {
            entity.HasKey(e => e.ReviewerId).HasName("PK__Reviewer__1616CFDD52DD689C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
