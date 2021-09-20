using System.Windows;
using Classes;

namespace SomeHospitalSoft
{
    public partial class LoggedAsDoctorWindow : Window
    {
        private Repository repository;
        public LoggedAsDoctorWindow()
        {
            InitializeComponent();
        }
        internal void SetRepository(Repository r)
        {
            repository = r;
            repository.OnAppointmentDataChanged += UpdateAppointmentList;

            textBlockGreeting.Text = $"Welcome {repository.CurrentDoctor.Name}!";
            listBoxAppointments.ItemsSource = repository.CurrentDoctor.Appointments;
        }
        void UpdateAppointmentList()
        {
            listBoxAppointments.ItemsSource = null;
            listBoxAppointments.ItemsSource = repository.CurrentDoctor.Appointments;
        }
    }
}
