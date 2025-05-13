using SQLite;

namespace Baza1.Models;

public class Wydzial
{
    [PrimaryKey, AutoIncrement]
    public int Id_wydzialu { get; set; }
    public string Nazwa { get; set; }
}