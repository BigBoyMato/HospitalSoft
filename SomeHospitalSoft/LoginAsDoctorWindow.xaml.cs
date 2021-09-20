using System.Windows;
using System.Windows.Input;
using Classes;


namespace SomeHospitalSoft
{
    public partial class LoginAsDoctorWindow : Window
    {
        public LoginAsDoctorWindow()
        {
            InitializeComponent();
            textBoxLogin.Focus();
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            var login = textBoxLogin.Text;
            var password = passwordBox.Password;
            var r = new Repository();
            if (r.AuthorizeDocotor(login, password))
            {
                var loggedAsDoctorWindow = new LoggedAsDoctorWindow();
                loggedAsDoctorWindow.SetRepository(r);
                loggedAsDoctorWindow.Show();
                this.Close();
            }
        }
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                ButtonLogin_Click(sender, e);
        }
    }
}
