using System.Collections.ObjectModel;

namespace losowanieUczniowKania
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<string> _klasy;

        public MainPage()
        {
            InitializeComponent();
            _klasy = new ObservableCollection<string>(ZapisOdczyt.OdczytajKlasy());
            ListaKlasView.ItemsSource = _klasy;
        }

        private void DodajKlase(object sender, EventArgs e)
        {
            var nazwaKlasy = NazwaKlasyEntry.Text;
            if (!string.IsNullOrEmpty(nazwaKlasy))
            {
                _klasy.Add(nazwaKlasy);
                NazwaKlasyEntry.Text = string.Empty;
                ZapisOdczyt.ZapiszKlasy(_klasy);
            }
        }

        private void UsunKlase(object sender, EventArgs e)
        {
            var wybranaKlasa = ListaKlasView.SelectedItem as string;
            if (wybranaKlasa != null)
            {
                _klasy.Remove(wybranaKlasa);

                ZapisOdczyt.ZapiszKlasy(_klasy);
            }
        }

        private async void WybierzKlase(object sender, SelectedItemChangedEventArgs e)
        {
            var wybranaKlasa = e.SelectedItem as string;
            if (wybranaKlasa != null)
            {
                await Navigation.PushAsync(new StronaSzczegolyKlasy(wybranaKlasa));
            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _klasy = new ObservableCollection<string>(ZapisOdczyt.OdczytajKlasy());
            ListaKlasView.ItemsSource = _klasy;
        }
    }
}