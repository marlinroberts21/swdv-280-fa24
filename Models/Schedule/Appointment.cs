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

    public int CustomerId { get; set; }

    public int CategoryId { get; set; }

    public int TimeId { get; set; }

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
