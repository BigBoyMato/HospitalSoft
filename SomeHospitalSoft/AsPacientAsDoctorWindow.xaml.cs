using System.Windows;


namespace SomeHospitalSoft
{
    /// <summary>
    /// Interaction logic for AsPacientAsDoctorWindow.xaml
    /// </summary>
    public partial class AsPacientAsDoctorWindow : Window
    {
        public AsPacientAsDoctorWindow()
        {
            InitializeComponent();
        }
        private void ButtonLogDoctor_Click(object sender, RoutedEventArgs args)
        {
            var loginAsDoctorWindow = new LoginAsDoctorWindow();
            this.Hide();
            loginAsDoctorWindow.Show();
            Close();
        }
        private void ButtonLogPacient_Click(object sender, RoutedEventArgs args)
        {
            var loginAsPacientWindow = new LoginAsPacientWindow();
            this.Hide();
            loginAsPacientWindow.Show();
            Close();
        }
    }
}
