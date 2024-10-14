using static mandrilAPI.Models.Habilidad;


namespace mandrilAPI.Models;

public class HabilidadInsert
{
    public string Nombre { get; set; } = string.Empty;

    public EPotencia Potencia {get; set; }
}
