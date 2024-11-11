using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace total_test_1.Models.Schedule;

public partial class Customer
{
    [Key]
    public int CustomerId { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string FirstName { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string LastName { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    public int PhoneNumber { get; set; }

    [InverseProperty("Customer")]
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
