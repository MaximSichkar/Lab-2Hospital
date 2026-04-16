using Microsoft.EntityFrameworkCore;

namespace Hospital
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Doctor> Doctors
        {
            get; set;
        }
        public DbSet<Patient> Patients
        {
            get; set;
        }
        public DbSet<Appointment> Appointments
        {
            get; set;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseNpgsql("Host=192.168.50.10;Port=5432;Database=Hospital;Username=postgres;Password=1234;Ssl Mode=Disable");
    }
}
