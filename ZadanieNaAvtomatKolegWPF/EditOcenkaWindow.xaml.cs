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
    /// Логика взаимодействия для EditOcenkaWindow.xaml
    /// </summary>
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