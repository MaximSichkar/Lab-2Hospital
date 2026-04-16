using Hospital;
using System.Collections.ObjectModel;

namespace HospitalModel
{
    public class MainViewModel : BaseViewModel
    {
        private AppointmentService service = new AppointmentService();

        public ObservableCollection<Appointment> Appointments
        {
            get; set;
        }

        private Appointment selectedAppointment;
        public Appointment SelectedAppointment
        {
            get => selectedAppointment;
            set
            {
                selectedAppointment = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            LoadData();
        }

        public void LoadData()
        {
            Appointments = new ObservableCollection<Appointment>(service.GetAll());
            OnPropertyChanged(nameof(Appointments));
        }

        public void Delete()
        {
            if (SelectedAppointment != null)
            {
                service.Delete(SelectedAppointment);
                LoadData();
            }
        }
    }
}
