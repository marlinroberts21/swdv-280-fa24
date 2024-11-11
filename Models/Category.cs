using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace total_test_1.Models;

public partial class Category
{
    [Key]
    public int CategoryId { get; set; }

    [Column("Category")]
    [StringLength(255)]
    [Unicode(false)]
    public string Category1 { get; set; } = null!;

    [InverseProperty("Category")]
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
