using System;
using System.Windows;
using ZadanieNaAvtomatKolleg;
using ZadanieNaAvtomatKolleg.Core;

namespace ZadanieNaAvtomatKollegWPFNET1
{
    public partial class AddEkzamenWindow : Window
    {
        private CoreApplication _coreApp;

        public AddEkzamenWindow(CoreApplication coreApp)
        {
            InitializeComponent();
            _coreApp = coreApp;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(IDUchebnogoPlanaTextBox.Text, out int idUchebnogoPlana) ||
                !int.TryParse(IDPrepodovatelaTextBox.Text, out int idPrepodovatela) ||
                !int.TryParse(IDStudentaTextBox.Text, out int idStudenta) ||
                !int.TryParse(NomerKabinetaTextBox.Text, out int nomerKabineta) ||
                !int.TryParse(OcenkaTextBox.Text, out int ocenka) || ocenka < 2 || ocenka > 5)
            {
                MessageBox.Show("Пожалуйста, введите корректные данные.");
                return;
            }

            var newEkzamen = new Ekzamens
            {
                ID_Uhebnogo_Plana = idUchebnogoPlana,
                ID_Prepodovatela = idPrepodovatela,
                ID_Studenta = idStudenta,
                Data_Provedenia = DataProvedeniaDatePicker.SelectedDate ?? DateTime.Now,
                Nomer_Kabineta = nomerKabineta,
                Ocenka = ocenka
            };

            _coreApp.AddEkzamen(newEkzamen);
            MessageBox.Show("Экзамен успешно добавлен!");
            this.Close();
        }
    }
}