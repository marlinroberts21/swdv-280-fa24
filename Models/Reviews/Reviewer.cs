using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace total_test_1.Models.Reviews;

public partial class Reviewer
{
    [Key]
    public int ReviewerId { get; set; }

    [Required(ErrorMessage = "First name is required")]
    [StringLength(255)]
    [Unicode(false)]
    public string FirstName { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string? LastName { get; set; }

    [InverseProperty("Reviewer")]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
