//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using total_test_1.Models;
//using Microsoft.Data.SqlClient;

//namespace total_test_1.Services
//{
//    public class ScheduleDbContext : DbContext
//    {

//        public ScheduleDbContext(DbContextOptions<ScheduleDbContext> options) : base(options)
//        {

//        }

//        public DbSet<Customer> Customers { get; set; }

//        public IQueryable<Customer> GetCustomers()
//        {
//            return this.Customers.FromSqlRaw("EXECUTE GetCustomers");
//        }


        //    public void ConfigureServices(IServiceCollection services)
        //    {
        //        services.AddDbContext<ScheduleDbContext>(options =>
        //        options.UseSqlServer(
        //            Configuration.GetConnectionString("MovieContext")));
        //    }

        //public class ApplicationDbContext : IdentityDbContext<AdminUser>
        //{
        //    public ApplicationDbContext(DbContextOptions options) : base(options)
        //    {

        //    }



//    }
//}
