using Baza1.Models;
using SQLite;

namespace Baza1.Services;

public class DatabaseService
{
    private SQLiteAsyncConnection _database;

    public DatabaseService()
    {
        InitializeDatabase();
    }

    private async void InitializeDatabase()
    {
        if (_database != null) return;

        var databasePath = Path.Combine(FileSystem.AppDataDirectory, "baza_UBB.db3");
        _database = new SQLiteAsyncConnection(databasePath);

        await _database.CreateTableAsync<Stanowisko>();
        await _database.CreateTableAsync<Wydzial>();
        await _database.CreateTableAsync<Pracownik>();
        await _database.CreateTableAsync<PracownikWydzial>();
        await _database.CreateTableAsync<Urlopy>();
        await _database.CreateTableAsync<PracownikUrlop>();
        await _database.CreateTableAsync<Wynagrodzenia>();
        await _database.CreateTableAsync<PracownikWynagrodzenie>();
        await _database.CreateTableAsync<Kwalifikacje>();
        await _database.CreateTableAsync<PracownikKwalifikacje>();
    }

    #region Pracownik CRUD
    public async Task<List<Pracownik>> GetPracownicyAsync()
    {
        return await _database.Table<Pracownik>().OrderBy(p => p.Nazwisko).ToListAsync();
    }

    public async Task<int> AddPracownikAsync(Pracownik pracownik)
    {
        return await _database.InsertAsync(pracownik);
    }

    public async Task<int> UpdatePracownikAsync(Pracownik pracownik)
    {
        return await _database.UpdateAsync(pracownik);
    }

    public async Task<int> DeletePracownikAsync(Pracownik pracownik)
    {
        return await _database.DeleteAsync(pracownik);
    }
    #endregion

    #region Stanowisko CRUD
    public async Task<List<Stanowisko>> GetStanowiskaAsync()
    {
        return await _database.Table<Stanowisko>().OrderBy(s => s.Nazwa).ToListAsync();
    }

    public async Task<int> AddStanowiskoAsync(Stanowisko stanowisko)
    {
        return await _database.InsertAsync(stanowisko);
    }
    #endregion

    #region Wydzial CRUD
    public async Task<List<Wydzial>> GetWydzialyAsync()
    {
        return await _database.Table<Wydzial>().OrderBy(w => w.Nazwa).ToListAsync();
    }

    public async Task<int> AddWydzialAsync(Wydzial wydzial)
    {
        return await _database.InsertAsync(wydzial);
    }
    #endregion

    // Analogiczne metody dla pozostałych tabel...
}