using SQLite;

namespace Baza1.Models;

public class Stanowisko
{
    [PrimaryKey, AutoIncrement]
    public int Id_stanowiska { get; set; }
    public string Nazwa { get; set; }
    public string Poziom { get; set; }
    public decimal Min_wynagrodzenie { get; set; }
}