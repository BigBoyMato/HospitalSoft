using System.Windows;
using System.Windows.Input;
using Classes;

namespace SomeHospitalSoft
{
    public partial class LoginAsPacientWindow : Window
    {

        public LoginAsPacientWindow()
        {
            InitializeComponent();
            textBoxLogin.Focus();
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            var login = textBoxLogin.Text;
            var password = passwordBox.Password;
            var r = new Repository();
            if (r.AuthorizePacient(login, password))
            {
                var loggedAsPacientWindow = new LoggedAsPacientWindow();
                loggedAsPacientWindow.SetRepository(r);
                loggedAsPacientWindow.Show();
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
