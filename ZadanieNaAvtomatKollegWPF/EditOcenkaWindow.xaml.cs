using System.Windows;
using ZadanieNaAvtomatKolleg;
using ZadanieNaAvtomatKolleg.Core;

namespace ZadanieNaAvtomatKollegWPF
{
    public partial class EditOcenkaWindow : Window
    {
        private readonly Ekzamens _ekzamen;
        private readonly CoreApplication _coreApp;

        public EditOcenkaWindow(Ekzamens ekzamen, CoreApplication coreApp)
        {
            InitializeComponent();

            _ekzamen = ekzamen;
            _coreApp = coreApp;

            // Устанавливаем текущую оценку
            OcenkaTextBox.Text = _ekzamen.Ocenka.ToString();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(OcenkaTextBox.Text, out int newOcenka))
            {
                // Обновляем оценку
                _ekzamen.Ocenka = newOcenka;
                _coreApp.UpdateEkzamen(_ekzamen);

                MessageBox.Show("Оценка успешно изменена!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Введите корректное значение оценки.");
            }
        }
    }
}