using System.Linq;
using System.Windows;
using ZadanieNaAvtomatKolleg;
using ZadanieNaAvtomatKolleg.Core;

namespace ZadanieNaAvtomatKollegWPF
{
    public partial class StudentWindow : Window
    {
        private Student _student;
        private CoreApplication _coreApp;

        public StudentWindow(Student student, CoreApplication coreApp)
        {
            InitializeComponent();
            _student = student;
            _coreApp = coreApp;

            LoadData();
        }

        private void LoadData()
        {
            // Загрузка расписания
            var raspisanie = _coreApp.GetAllRaspisanie().Where(r => r.ID_Gruppa == _student.ID_Gruppa);
            RaspisanieListBox.ItemsSource = raspisanie.Select(r => $"Пара: {r.Nomer_para}, День: {r.ID_Day_Nedelia}, Кабинет: {r.Nomer_kabineta}");

            // Загрузка экзаменов
            var ekzamens = _coreApp.GetAllEkzamens().Where(e => e.ID_Studenta == _student.ID_Studenta);
            EkzamensListBox.ItemsSource = ekzamens.Select(e => $"Экзамен: {e.ID_Ekzamena}, Оценка: {e.Ocenka}");
        }
    }
}