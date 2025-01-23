using System;
using System.Windows;
using System.Windows.Controls;
using WypozyczalniaSprzetu; // Importujemy klasy sprzętu

namespace WypozyczalniaGUI
{
    public partial class DodajSprzetWindow : Window
    {
        public string Rodzaj { get; private set; }
        public string TypSprzetu { get; private set; }
        public int Rozmiar { get; private set; } // Zmieniono typ na int
        public string StanTechniczny { get; private set; }
        public bool CzyDodano { get; private set; } = false;
        private SprzetManager sprzetManager;

        public DodajSprzetWindow(SprzetManager manager)
        {
            InitializeComponent();
            sprzetManager = manager;
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            // Sprawdzenie wyboru rodzaju sprzętu
            if (RodzajComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                Rodzaj = selectedItem.Content.ToString();
            }
            else
            {
                MessageBox.Show("Wybierz rodzaj sprzętu!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Sprawdzenie czy użytkownik podał typ sprzętu
            if (string.IsNullOrWhiteSpace(TypSprzetuTextBox.Text))
            {
                MessageBox.Show("Podaj typ sprzętu!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Sprawdzenie czy rozmiar jest liczbą oraz czy jest większy od 0
            if (!int.TryParse(RozmiarTextBox.Text, out int rozmiar) || rozmiar <= 0)
            {
                MessageBox.Show("Podaj poprawny rozmiar!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Rozmiar = rozmiar; // Przypisanie poprawnego rozmiaru
            TypSprzetu = TypSprzetuTextBox.Text;
            StanTechniczny = StanTextBox.Text;

            SprzetNarciarski nowySprzet;
            if (Rodzaj == "Narty")
            {
                nowySprzet = new Narty(TypSprzetu, Rozmiar, StanTechniczny, false);
            }
            else if (Rodzaj == "Snowboard")
            {
                nowySprzet = new Snowboard(TypSprzetu, Rozmiar, StanTechniczny, false);
            }
            else
            {
                MessageBox.Show("Nieznany rodzaj sprzętu!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Dodaj sprzęt do SprzetManager
            sprzetManager.DodajSprzet(nowySprzet);
            DataManager.ZapiszSprzet(sprzetManager.GetSprzet()); 

            CzyDodano = true;

            DialogResult = true;
            Close();
        }
    }
}
