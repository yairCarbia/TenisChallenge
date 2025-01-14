using System.Text.Json;
using TorneoTenis.Helpers;
using TorneoTenis.TDA.TorneoTenis.DTOs.TorneoTenis.TDA;
namespace TorneoTenis.Resources;

public static class JsonHelper
{
    /// <summary>
    /// Lee una lista de jugadores desde un archivo JSON.
    /// </summary>
    /// <param name="rutaArchivo">Ruta al archivo JSON.</param>
    /// <returns>Lista de jugadores.</returns>
    public static List<Jugador> GetJugadoresFromJson(string rutaArchivo)
    {
        if (!File.Exists(rutaArchivo))
            throw new FileNotFoundException(Messages.MESSAGES_ERROR_NO_SE_ENCONTRO_EL_ARCHIVO_JSON.Format(rutaArchivo));

        string json = File.ReadAllText(rutaArchivo);
        return JsonSerializer.Deserialize<List<Jugador>>(json) ?? new List<Jugador>();
    }
}
