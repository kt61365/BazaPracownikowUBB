using SQLite;

namespace Baza1.Models;

public class PracownikUrlop
{
    [Indexed]
    public int Id_pracownika { get; set; }

    [Indexed]
    public int Id_urlopu { get; set; }
}