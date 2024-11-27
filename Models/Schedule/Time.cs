using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace total_test_1.Models.Schedule;

public partial class Time
{
    [Key]
    public int TimeId { get; set; }

    [Required]
    [Column("Time")]
    public TimeOnly Time1 { get; set; }

    [InverseProperty("Time")]
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
