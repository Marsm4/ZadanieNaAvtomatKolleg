using System.Linq;
using System.Windows;
using ZadanieNaAvtomatKolleg;
using ZadanieNaAvtomatKolleg.Core;
using ZadanieNaAvtomatKolleg.Interfaces;
using ZadanieNaAvtomatKolleg.Services;
using Unity;
using System.Windows.Controls;
using ZadanieNaAvtomatKolleg.Interfaces;
namespace ZadanieNaAvtomatKollegWPF
{
    public partial class MainWindow : Window
    {
        private CoreApplication _coreApp;

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