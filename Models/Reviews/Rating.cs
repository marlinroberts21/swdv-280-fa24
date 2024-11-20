using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace total_test_1.Models.Reviews;

public partial class Rating
{
    [Key]
    public int RatingId { get; set; }

    [Column("Rating")]

    [Required(ErrorMessage ="Rating is required")]
    [Range(1, 5, ErrorMessage ="Rating must be 1 through 5")]
    public int Rating1 { get; set; }

    [InverseProperty("Rating")]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
