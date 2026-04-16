using Hospital;
using Microsoft.EntityFrameworkCore;

namespace HospitalModel
{
    public class AppointmentService
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public List<Appointment> GetAll()
            => db.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .ToList();

        public void Add(Appointment a)
        {
            db.Appointments.Add(a);
            db.SaveChanges();
        }

        public void Update(Appointment a)
        {
            db.Appointments.Update(a);
            db.SaveChanges();
        }

        public void Delete(Appointment a)
        {
            db.Appointments.Remove(a);
            db.SaveChanges();
        }
    }
}
