namespace WebAppVideojuegos.Models;

public class Videojuego
{
    public int IdVideojuego { get; set; }
    public string? Titulo { get; set; }
    public string? Descripcion { get; set; }
    public short? Año { get; set;}
    public short? Calificacion { get; set;}
    public bool? Estatus  { get; set;}
    public short? IdConsola { get; set;}
    public short? IdGenero { get; set;}
}
