using SQLite;

namespace Baza1.Models;

public class Urlopy
{
    [PrimaryKey, AutoIncrement]
    public int Id_urlopu { get; set; }
    public DateTime Data_rozpoczecia { get; set; }
    public DateTime Data_zakonczenia { get; set; }
    public string Typ { get; set; }
    public string Status { get; set; }
}