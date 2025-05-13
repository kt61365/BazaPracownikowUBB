using SQLite;

namespace Baza1.Models;

public class Kwalifikacje
{
    [PrimaryKey, AutoIncrement]
    public int Id_kwalifikacji { get; set; }
    public string Stopien_naukowy { get; set; }
    public string Specjalizacja { get; set; }
    public string Uczelnia_uzyskania { get; set; }
}