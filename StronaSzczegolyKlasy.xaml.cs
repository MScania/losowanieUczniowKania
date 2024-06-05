using System.Collections.ObjectModel;

namespace losowanieUczniowKania
{
    public partial class StronaSzczegolyKlasy : ContentPage
    {
        private string _nazwaKlasy;
        private ObservableCollection<string> _uczniowie;

        public StronaSzczegolyKlasy(string nazwaKlasy)
        {
            InitializeComponent();
            _nazwaKlasy = nazwaKlasy;
            NazwaKlasyLabel.Text = nazwaKlasy;
            _uczniowie = new ObservableCollection<string>(ZapisOdczyt.OdczytajUczniow(nazwaKlasy));
            ListaUczniowView.ItemsSource = _uczniowie;
        }

        private void DodajUcznia(object sender, EventArgs e)
        {
            var imieUcznia = ImieUczniaEntry.Text;
            if (!string.IsNullOrEmpty(imieUcznia))
            {
                _uczniowie.Add(imieUcznia);
                ImieUczniaEntry.Text = string.Empty;
                ZapisOdczyt.ZapiszUczniow(_nazwaKlasy, _uczniowie);
            }
        }

        private void UsunUcznia(object sender, EventArgs e)
        {
            var wybranyUczen = ListaUczniowView.SelectedItem as string;
            if (wybranyUczen != null)
            {
                _uczniowie.Remove(wybranyUczen);
                ZapisOdczyt.ZapiszUczniow(_nazwaKlasy, _uczniowie);
            }
        }

        private void LosujUcznia(object sender, EventArgs e)
        {
            if (_uczniowie.Any())
            {
                var random = new Random();
                var wylosowanyUczen = _uczniowie[random.Next(_uczniowie.Count)];
                WylosowanyUczenLabel.Text = $"Wylosowany uczeñ: {wylosowanyUczen}";
            }
            else
            {
                WylosowanyUczenLabel.Text = "Lista uczniów jest pusta";
            }
        }
    }
}