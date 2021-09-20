using System.Windows;
using Classes;

namespace SomeHospitalSoft
{
    public partial class AppEditorWindow : Window
    {
        private Repository repository;
        private Appointment appointment;

        public AppEditorWindow()
        {
            InitializeComponent();
            DataContext = new Repository();
        }

        public AppEditorWindow(Repository repository, Appointment appointment) : this()
        {
            this.repository = repository;
            this.appointment = appointment;

            if (appointment != null)
            {
                cmbDoctors.SelectedItem = appointment.DoctorSpeciality;
                datePicker.SelectedDate = appointment.AppDate;
            }
        }
        private void ButtonUpdate_Click(object sender, RoutedEventArgs args)
        {
            var doctor = cmbDoctors.SelectedItem as userDoctor;
            var docSpeciality = doctor.Speciality;
            var appDate = datePicker.SelectedDate;

            if (string.IsNullOrEmpty(docSpeciality) ||  appDate == null)
                return;

            bool add = appointment == null;

            if (add)
                appointment = new Appointment();

            appointment.DoctorName = doctor.Name;
            appointment.DoctorSpeciality = docSpeciality;
            appointment.AppDate = appDate.Value;
            appointment.PacientName = repository.CurrentPacient.Name;

            if (add)
            {
                repository.AddAppointment(appointment);

                // addApp func to doctors.json
                foreach(var doc in repository.userDoctors)
                {
                    if (doc.NameAndSpecialty == doctor.NameAndSpecialty)
                    {
                        doc.Appointments.Add(appointment);
                    }
                }

            }
            Close();
        }
    }
}
