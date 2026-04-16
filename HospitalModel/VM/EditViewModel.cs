using Hospital;

namespace HospitalModel.VM
{
    public class EditViewModel : BaseViewModel
    {
        private AppointmentService service = new AppointmentService();

        public Appointment Appointment
        {
            get; set;
        }

        public List<Doctor> Doctors
        {
            get; set;
        }
        public List<Patient> Patients
        {
            get; set;
        }

        public Doctor SelectedDoctor
        {
            get; set;
        }
        public Patient SelectedPatient
        {
            get; set;
        }

        public EditViewModel(Appointment appointment = null)
        {
            var db = new ApplicationDbContext();

            Doctors = db.Doctors.ToList();
            Patients = db.Patients.ToList();

            Appointment = appointment ?? new Appointment { DateTime = DateTime.Now };

            if (appointment != null)
            {
                SelectedDoctor = Doctors.FirstOrDefault(d => d.Id == appointment.DoctorId);
                SelectedPatient = Patients.FirstOrDefault(p => p.Id == appointment.PatientId);
            }
        }

        public void Save()
        {
            Appointment.DoctorId = SelectedDoctor.Id;
            Appointment.PatientId = SelectedPatient.Id;

            Appointment.DateTime = Appointment.DateTime.ToUniversalTime();

            if (Appointment.Id == 0)
                service.Add(Appointment);
            else
                service.Update(Appointment);
        }
    }
}
