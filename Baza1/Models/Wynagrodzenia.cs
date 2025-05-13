using SQLite;

namespace Baza1.Models;

public class Wynagrodzenia
{
    [PrimaryKey, AutoIncrement]
    public int Id_wynagrodzenia { get; set; }
    public decimal Kwota { get; set; }
    public decimal Premia { get; set; }
    public string Info { get; set; }
}