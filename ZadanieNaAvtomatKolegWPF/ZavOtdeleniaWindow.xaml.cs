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

namespace ZadanieNaAvtomatKolegWPF
{
    /// <summary>
    /// Логика взаимодействия для ZavOtdeleniaWindow.xaml
    /// </summary>
    public partial class ZavOtdeleniaWindow : Window
    {
        private Zav_Otdelenia _zavOtdelenia;
        private CoreApplication _coreApp;

        public ZavOtdeleniaWindow(Zav_Otdelenia zavOtdelenia, CoreApplication coreApp)
        {
            InitializeComponent();
            _zavOtdelenia = zavOtdelenia;
            _coreApp = coreApp;

            LoadData();
        }

        private void LoadData()
        {
            // Загрузка расписания
            var raspisanie = _coreApp.GetAllRaspisanie();
            RaspisanieListBox.ItemsSource = raspisanie.Select(r => $"Пара: {r.Nomer_para}, День: {r.ID_Day_Nedelia}, Кабинет: {r.Nomer_kabineta}");

            // Загрузка экзаменов
            var ekzamens = _coreApp.GetAllEkzamens();
            EkzamensListBox.ItemsSource = ekzamens.Select(e => $"Экзамен: {e.ID_Ekzamena}, Оценка: {e.Ocenka}");

            // Загрузка экзаменов для ComboBox
            EkzamenComboBox.ItemsSource = ekzamens;
        }

        private void AddEkzamenButton_Click(object sender, RoutedEventArgs e)
        {
            // Открываем окно для добавления нового экзамена
            var addEkzamenWindow = new AddEkzamenWindow(_coreApp);
            addEkzamenWindow.ShowDialog();

            // Обновляем данные после добавления
            LoadData();
        }

        private void UpdateOcenkaButton_Click(object sender, RoutedEventArgs e)
        {
            if (EkzamenComboBox.SelectedItem == null || string.IsNullOrEmpty(NewOcenkaTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, выберите экзамен и введите новую оценку.");
                return;
            }

            if (!int.TryParse(NewOcenkaTextBox.Text, out int newOcenka) || newOcenka < 2 || newOcenka > 5)
            {
                MessageBox.Show("Оценка должна быть числом от 2 до 5.");
                return;
            }

            var selectedEkzamen = (Ekzamens)EkzamenComboBox.SelectedItem;
            selectedEkzamen.Ocenka = newOcenka;

            // Обновляем оценку
            _coreApp.UpdateEkzamen(selectedEkzamen);
            MessageBox.Show("Оценка успешно изменена!");

            // Обновляем данные
            LoadData();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            // Закрываем текущее окно и возвращаемся к главному окну
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}