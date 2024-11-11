using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace total_test_1.Models;

public partial class Customer
{
    [Key]
    public int CustomerId { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    [Required(ErrorMessage = "Please enter a first name.")]
    [RegularExpression("^[a-zA-Z0-9+$",
        ErrorMessage ="First name may not contain special characters.")]
    public string FirstName { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    [Required(ErrorMessage = "Please enter a last name.")]
    [RegularExpression("^[a-zA-Z0-9+$",
        ErrorMessage = "Last name may not contain special characters.")]
    public string LastName { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    [Required(ErrorMessage = "Please enter a Email.")]
    [RegularExpression("^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$\"",
        ErrorMessage = "Incorrect email formatting.")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Please enter a Phone Number.")]
    [RegularExpression("^(?([0-9]{3}))?[-.●]?([0-9]{3})[-.●]?([0-9]{4})$",
        ErrorMessage = "Incorrect phone number formatting.")]
    public int PhoneNumber { get; set; }

    [InverseProperty("Customer")]
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
