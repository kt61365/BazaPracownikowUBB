using SQLite;

namespace Baza1.Models;

public class PracownikWydzial
{
    [Indexed]
    public int Id_pracownika { get; set; }

    [Indexed]
    public int Id_wydzialu { get; set; }
}