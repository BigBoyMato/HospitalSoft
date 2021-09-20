using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Classes;


namespace SomeHospitalSoft
{
    public partial class LoggedAsPacientWindow : Window
    {
        private Repository repository;

        public LoggedAsPacientWindow()
        {
            InitializeComponent();
        }
        internal void SetRepository(Repository r)
        {
            repository = r;
            repository.OnAppointmentDataChanged += UpdateAppointmentList;

            textBlockGreeting.Text = $"Welcome {repository.CurrentPacient.Name}!";
            listBoxAppointments.ItemsSource = repository.CurrentPacient.Appointments;
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs args)
        {
            var appEditorWindow = new AppEditorWindow(repository, null);
            appEditorWindow.Owner = this;
            appEditorWindow.ShowDialog();
        }
        private void ButtonDelete_Click(object sender, RoutedEventArgs args)
        {
            var exuserDoctors = repository.ReadList<userDoctor>(repository.filePathDoctors);
            if (listBoxAppointments.SelectedItem is Appointment selectedAppointment)
            {
                // used file repository // NOT FINISHED
                // repository.DeleteDataDoctors(selectedAppointment);

                repository.RemoveAppointment(selectedAppointment);
            }
        }
        void UpdateAppointmentList()
        {
            listBoxAppointments.ItemsSource = null;
            listBoxAppointments.ItemsSource = repository.CurrentPacient.Appointments;
        }
        
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show("Appoinments updated in databases");
            repository.SaveData(repository.userDoctors, repository.userPacients);
            
        }
    }
}
