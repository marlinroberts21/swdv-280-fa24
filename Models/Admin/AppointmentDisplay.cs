using Microsoft.EntityFrameworkCore;
using total_test_1.Models.Schedule;

namespace total_test_1.Models.Admin
{
    public class AppointmentDisplay
    {
        //public DbSet<Appointment> Appointment {  get; set; }
        //public DbSet<Customer> Customer { get; set; }
        //public DbSet<Time> Time { get; set; }
        public int Id { get; set; }
        public TimeOnly? Time {  get; set; }
        public string? FirstName {  get; set; }
        public string? LastName { get; set; }
        public AppointmentDisplay(int id, TimeOnly? time, string? firstName, string? lastName)
        {
            Id = id;
            Time = time;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
