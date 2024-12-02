using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace total_test_1.Models.Reviews;

public partial class Review
{
    [Key]
    public int ReviewId { get; set; }

    public int? ReviewerId { get; set; }

    public int? RatingId { get; set; }

    public DateOnly DateCreated { get; set; }

    [StringLength(1000, ErrorMessage = "Review text cannot exceed 1000 characters")]
    [Unicode(false)]
    public string? ReviewText { get; set; } = null!;

    [ForeignKey("RatingId")]
    [InverseProperty("Reviews")]
    public virtual Rating? Rating { get; set; }

    [ForeignKey("ReviewerId")]
    [InverseProperty("Reviews")]
    public virtual Reviewer? Reviewer { get; set; }
}
