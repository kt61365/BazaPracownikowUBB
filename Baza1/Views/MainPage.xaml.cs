using Baza1.Models;
using Baza1.Services;

namespace Baza1;

public partial class MainPage : ContentPage
{
    private readonly DatabaseService _databaseService;

    public MainPage(DatabaseService databaseService)
    {
        InitializeComponent();
        _databaseService = databaseService;
        LoadPracownicy();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadPracownicy();
    }

    private async void LoadPracownicy()
    {
        var pracownicy = await _databaseService.GetPracownicyAsync();
        pracownicyCollection.ItemsSource = pracownicy;
    }

    private async void OnAddPracownikClicked(object sender, EventArgs e)
    {
        string imie = await DisplayPromptAsync("Nowy pracownik", "Podaj imię:");
        if (string.IsNullOrWhiteSpace(imie)) return;

        string nazwisko = await DisplayPromptAsync("Nowy pracownik", "Podaj nazwisko:");
        if (string.IsNullOrWhiteSpace(nazwisko)) return;

        string pesel = await DisplayPromptAsync("Nowy pracownik", "Podaj PESEL:");
        if (string.IsNullOrWhiteSpace(pesel)) return;

        string typUmowy = await DisplayPromptAsync("Nowy pracownik", "Podaj typ umowy:");
        if (string.IsNullOrWhiteSpace(typUmowy)) return;

        var newPracownik = new Pracownik
        {
            Imie = imie,
            Nazwisko = nazwisko,
            Pesel = pesel,
            Data_zatrudnienia = DateTime.Now,
            Typ_umowy = typUmowy,
            Id_stanowiska = 1 // Domyślnie pierwsze stanowisko
        };

        await _databaseService.AddPracownikAsync(newPracownik);
        LoadPracownicy();
    }

    private async void OnAddTestClicked(object sender, EventArgs e)
    {
        var testPracownik = new Pracownik
        {
            Imie = "Jan",
            Nazwisko = "Kowalski",
            Pesel = "12345678901",
            Data_zatrudnienia = DateTime.Now.AddYears(-5),
            Typ_umowy = "Etat",
            Id_stanowiska = 1
        };

        await _databaseService.AddPracownikAsync(testPracownik);
        LoadPracownicy();

        await DisplayAlert("Sukces", "Dodano testowego pracownika Jana Kowalskiego", "OK");
    }

    private async void OnDeletePracownicyClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DeletePage(_databaseService));
    }

    private async void OnPracownikTapped(object sender, EventArgs e)
    {
        if (sender is BindableObject bindable && bindable.BindingContext is Pracownik pracownik)
        {
            await DisplayAlert("Szczegóły pracownika",
                $"{pracownik.Imie} {pracownik.Nazwisko}\n" +
                $"PESEL: {pracownik.Pesel}\n" +
                $"Data urodzenia: {(pracownik.Data_urodzenia == DateTime.MinValue ? "brak danych" : pracownik.Data_urodzenia.ToString("dd.MM.yyyy"))}\n" +
                $"Email: {pracownik.Email ?? "brak danych"}\n" +
                $"Telefon: {pracownik.Telefon ?? "brak danych"}\n" +
                $"Data zatrudnienia: {pracownik.Data_zatrudnienia:dd.MM.yyyy}\n" +
                $"Typ umowy: {pracownik.Typ_umowy}",
                "OK");
        }
    }
}