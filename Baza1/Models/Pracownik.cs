using SQLite;

namespace Baza1.Models;

public class Pracownik
{
    [PrimaryKey, AutoIncrement]
    public int Id_pracownika { get; set; }
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public string Pesel { get; set; }
    public DateTime Data_urodzenia { get; set; }
    public string Email { get; set; }
    public string Telefon { get; set; }
    public DateTime Data_zatrudnienia { get; set; }
    public string Typ_umowy { get; set; }

    [Indexed]
    public int Id_stanowiska { get; set; }
}