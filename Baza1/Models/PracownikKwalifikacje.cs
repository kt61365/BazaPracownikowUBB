using SQLite;

namespace Baza1.Models;

public class PracownikKwalifikacje
{
    [Indexed]
    public int Id_pracownika { get; set; }

    [Indexed]
    public int Id_kwalifikacji { get; set; }
}