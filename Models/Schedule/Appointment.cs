using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace total_test_1.Models.Schedule;

public partial class Appointment
{
    [Key]
    public int AppointmentId { get; set; }

    [Required]
    public int CustomerId { get; set; }

    [Required]
    public int CategoryId { get; set; }

    [Required]
    public int TimeId { get; set; }

    [Required]
    public DateOnly Date { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Appointments")]
    public virtual Category Category { get; set; } = null!;

    [ForeignKey("CustomerId")]
    [InverseProperty("Appointments")]
    public virtual Customer Customer { get; set; } = null!;

    [ForeignKey("TimeId")]
    [InverseProperty("Appointments")]
    public virtual Time Time { get; set; } = null!;
}
