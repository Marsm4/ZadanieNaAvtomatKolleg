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
using System.Windows.Shapes;
using ZadanieNaAvtomatKolleg.Core;
using ZadanieNaAvtomatKolleg;

namespace ZadanieNaAvtomatKollegWPFNET1
{
    /// <summary>
    /// Логика взаимодействия для StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
       private Student _student;
        private CoreApplication _coreApp;
        public StudentWindow(Student student, CoreApplication coreApp)
        {
            InitializeComponent();
            _student = student;


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
