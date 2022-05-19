using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp2.model;
using AnimatedGif;


namespace WpfApp2.pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonEnter_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxLogin.Text) || string.IsNullOrEmpty(PasswordBox.Password))
            {
                MessageBox.Show("Введите пароль и логин");
                return;
            }

            using (var db = new Entities())
            {
                var user = db.users
                    .AsNoTracking()
                    .FirstOrDefault(u => u.login == TextBoxLogin.Text && u.password == PasswordBox.Password);
                if(user== null)
                {
                    MessageBox.Show("Пользователь не найден");
                    return;
                }
                MessageBox.Show("wellcome");

                switch (user.idrole)

                {
                    case 1:
                        NavigationService?.Navigate(new Menu());
                        break;

                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
