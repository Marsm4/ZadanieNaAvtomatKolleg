using System.Linq;
using System.Windows;
using ZadanieNaAvtomatKolleg;
using ZadanieNaAvtomatKolleg.Core;
using ZadanieNaAvtomatKolleg.Interfaces;

namespace ZadanieNaAvtomatKollegWPF
{
    public partial class PrepodovatelWindow : Window
    {
        private readonly Prepodovatel _prepodovatel;
        private readonly CoreApplication _coreApp;

        public PrepodovatelWindow(Prepodovatel prepodovatel, CoreApplication coreApp)
        {
            InitializeComponent();

            _prepodovatel = prepodovatel;
            _coreApp = coreApp;

            LoadRaspisanie();
            LoadEkzamens();
            LoadNagruzka();
        }

        private void LoadRaspisanie()
        {
            // Загрузка расписания для преподавателя
            var raspisanie = _coreApp.GetAllRaspisanie()
                                     .Where(r => r.ID_Prepodovatela == _prepodovatel.ID_Prepodovatela)
                                     .ToList();
            RaspisanieDataGrid.ItemsSource = raspisanie;
        }

        private void LoadEkzamens()
        {
            // Загрузка экзаменов для преподавателя
            var ekzamens = _coreApp.GetAllEkzamens()
                                   .Where(e => e.ID_Prepodovatela == _prepodovatel.ID_Prepodovatela)
                                   .ToList();
            EkzamensDataGrid.ItemsSource = ekzamens;
        }

        private void LoadNagruzka()
        {
            // Загрузка нагрузки для преподавателя
            var nagruzka = _coreApp.GetAllNagruzka()
                                   .Where(n => n.ID_Prepodovatela == _prepodovatel.ID_Prepodovatela)
                                   .ToList();
            NagruzkaDataGrid.ItemsSource = nagruzka;
        }

        private void EditOcenka_Click(object sender, RoutedEventArgs e)
        {
            // Получаем выбранный экзамен
            var ekzamen = EkzamensDataGrid.SelectedItem as Ekzamens;
            if (ekzamen == null)
            {
                MessageBox.Show("Выберите экзамен для изменения оценки.");
                return;
            }

            // Открываем окно для изменения оценки
            var editOcenkaWindow = new EditOcenkaWindow(ekzamen, _coreApp);
            editOcenkaWindow.ShowDialog();

            // Обновляем данные в таблице
            LoadEkzamens();
        }
    }
}