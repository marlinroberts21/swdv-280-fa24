using Microsoft.EntityFrameworkCore;
using total_test_1.Models.Schedule;

namespace total_test_1.Models.Admin
{
    public class AppointmentDisplay
    {
        //public DbSet<Appointment> Appointment {  get; set; }
        //public DbSet<Customer> Customer { get; set; }
        //public DbSet<Time> Time { get; set; }
        public string Time {  get; set; }
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public AppointmentDisplay(string time, string firstName, string lastName)
        {

        }
    }
}
