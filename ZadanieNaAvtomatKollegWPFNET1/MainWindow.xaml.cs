using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZadanieNaAvtomatKolleg.Core;
using ZadanieNaAvtomatKolleg.Interfaces;
using ZadanieNaAvtomatKolleg.Services;
using ZadanieNaAvtomatKolleg;
using Unity;

namespace ZadanieNaAvtomatKollegWPFNET1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Инициализация Unity Container
            var container = new UnityContainer();
            container.RegisterType<IStudentService, StudentService>();
            container.RegisterType<IPrepodovatelService, PrepodovatelService>();
            container.RegisterType<IZavOtdeleniaService, ZavOtdeleniaService>();
            container.RegisterType<IRaspisanieService, RaspisanieService>();
            container.RegisterType<IEkzamensService, EkzamensService>();
            container.RegisterType<ApplicationDbContext, ApplicationDbContext>();
            container.RegisterType<INagruzkaService, NagruzkaService>();
            container.RegisterType<ApplicationDbContext, ApplicationDbContext>();

            _coreApp = container.Resolve<CoreApplication>();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string role = ((ComboBoxItem)RoleComboBox.SelectedItem).Content.ToString();
            string login = LoginTextBox.Text;
            string password = PasswordBox.Password;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пожалуйста, введите логин и пароль.");
                return;
            }

            switch (role)
            {
                case "Студент":
                    var student = _coreApp.GetAllStudents().FirstOrDefault(s => s.LoginStudent == login && s.PasswordStudent == password);
                    if (student != null)
                    {
                        // Открываем окно для студента
                        var studentWindow = new StudentWindow(student, _coreApp);
                        studentWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль.");
                    }
                    break;

                case "Преподаватель":
                    var prepodovatel = _coreApp.GetAllPrepodovatel().FirstOrDefault(p => p.Login_Prepod == login && p.Password_Prepod == password);
                    if (prepodovatel != null)
                    {
                        // Открываем окно для преподавателя
                        var prepodovatelWindow = new PrepodovatelWindow(prepodovatel, _coreApp);
                        prepodovatelWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль.");
                    }
                    break;

                case "Заведующий отделением":
                    var zavOtdelenia = _coreApp.GetAllZavOtdelenia().FirstOrDefault(z => z.Login_zaved == login && z.Passwors_zaved == password);
                    if (zavOtdelenia != null)
                    {
                        // Открываем окно для заведующего отделением
                        var zavOtdeleniaWindow = new ZavOtdeleniaWindow(zavOtdelenia, _coreApp);
                        zavOtdeleniaWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль.");
                    }
                    break;
            }
        }
    }
}
