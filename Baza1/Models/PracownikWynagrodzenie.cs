using SQLite;

namespace Baza1.Models;

public class PracownikWynagrodzenie
{
    [Indexed]
    public int Id_pracownika { get; set; }

    [Indexed]
    public int Id_wynagrodzenia { get; set; }
}