using Baza1.Models;
using Baza1.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Baza1;

public partial class DeletePage : ContentPage
{
    private readonly DatabaseService _databaseService;
    public ObservableCollection<SelectablePracownik> Pracownicy { get; } = new();

    public class SelectablePracownik : INotifyPropertyChanged
    {
        public Pracownik Pracownik { get; set; }

        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged(nameof(IsSelected));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public DeletePage(DatabaseService databaseService)
    {
        InitializeComponent();
        _databaseService = databaseService;
        BindingContext = this;
        LoadPracownicy();
    }

    private async void LoadPracownicy()
    {
        var pracownicy = await _databaseService.GetPracownicyAsync();
        Pracownicy.Clear();

        foreach (var pracownik in pracownicy)
        {
            Pracownicy.Add(new SelectablePracownik { Pracownik = pracownik });
        }

        pracownicyCollection.ItemsSource = Pracownicy;
    }

    private async void OnDeleteSelectedClicked(object sender, EventArgs e)
    {
        var selectedPracownicy = Pracownicy.Where(p => p.IsSelected).ToList();

        if (!selectedPracownicy.Any())
        {
            await DisplayAlert("Błąd", "Nie wybrano żadnych pracowników do usunięcia", "OK");
            return;
        }

        bool confirm = await DisplayAlert("Potwierdzenie",
            $"Czy na pewno chcesz usunąć {selectedPracownicy.Count} pracowników?",
            "Tak", "Nie");

        if (confirm)
        {
            foreach (var selectable in selectedPracownicy)
            {
                await _databaseService.DeletePracownikAsync(selectable.Pracownik);
            }

            await DisplayAlert("Sukces", "Pracownicy zostali usunięci", "OK");
            await Navigation.PopAsync();
        }
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}