using System;
using System.Linq;
using System.Windows;
using WypozyczalniaSprzetu;

namespace WypozyczalniaGUI
{
    public partial class DodajKlientaWindow : Window
    {
        private KlientManager klientManager;

        public DodajKlientaWindow(KlientManager klientManager)
        {
            InitializeComponent();
            this.klientManager = klientManager;
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            // Sprawdzenie, czy wszystkie pola są wypełnione
            if (string.IsNullOrWhiteSpace(ImieTextBox.Text) ||
                string.IsNullOrWhiteSpace(NazwiskoTextBox.Text) ||
                string.IsNullOrWhiteSpace(PeselTextBox.Text))
            {
                MessageBox.Show("Wypełnij wszystkie pola!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Sprawdzenie poprawności PESEL (czy ma dokładnie 11 cyfr)
            if (!CzyPeselPoprawny(PeselTextBox.Text))
            {
                MessageBox.Show("PESEL musi zawierać dokładnie 11 cyfr!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return; // Użytkownik musi poprawić PESEL
            }

            // Jeśli dane są poprawne, dodaj klienta
            var nowyKlient = new Klient(ImieTextBox.Text, NazwiskoTextBox.Text, PeselTextBox.Text);
            klientManager.DodajKlienta(nowyKlient);

            // Zamyka okno, jeśli dodanie klienta było poprawne
            DialogResult = true;
            Close();
        }

        // Metoda sprawdzająca, czy PESEL ma 11 cyfr
        private bool CzyPeselPoprawny(string pesel)
        {
            // Sprawdzenie długości i czy zawiera tylko cyfry
            return pesel.Length == 11 && pesel.All(char.IsDigit);
        }
    }
}
