using System;
using System.IO.Compression;
using System.Security.Cryptography.X509Certificates;
using mandrilAPI.Models;
using mandrilAPI.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc; 
using mandrilAPI.helpers;


namespace mandrilAPI.Controllers;

[ApiController]
[Route("api/mandril/{mandrilId}/[controller]")]
public class HabilidadControllers : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Habilidad>> GetHabilidades(int mandrilId)
    {
       var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.Id == mandrilId);
        if (mandril == null)
             return NotFound(Mensajes.Mandril.NotFound);

        return Ok(mandril.Habilidades);
    }
    
    [HttpGet("{habilidadId}")]
    public ActionResult<Habilidad> GetHabilidad(int mandrilId, int habilidadId)
    {
        var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.Id == mandrilId);

        if (mandril == null)
            return NotFound(Mensajes.Mandril.NotFound);

        var habilidad = mandril.Habilidades?.FirstOrDefault(h => h.Id == habilidadId);
        
        if (habilidad == null)
            return NotFound(Mensajes.Mandril.NotFound);
        
        return Ok(habilidad);
    }

    [HttpPost]
    public ActionResult<Habilidad> PostHabilidad(int mandrilId, HabilidadInsert habilidadInsert)
    {    
        var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.Id == mandrilId);
        if (mandril == null)
            return NotFound(Mensajes.Mandril.NotFound);  
        
        var habilidadExistente = mandril.Habilidades.FirstOrDefault(h => h.Nombre == habilidadInsert.Nombre);
        if (habilidadExistente != null)
            return BadRequest("Ya existe esta habilidad mi rey");
        
        var maxhabilidad = mandril.Habilidades.Max(h => h.Id);

        var habilidadNueva = new Habilidad() {
            Id = maxhabilidad + 1,
            Nombre = habilidadInsert.Nombre,
            Potencia = habilidadInsert.Potencia
        };
        
        mandril.Habilidades.Add(habilidadNueva);
        
        return CreatedAtAction(nameof(GetHabilidad), 
            new { mandrilId = mandrilId, habilidadId = habilidadNueva.Id },
            habilidadNueva
            );

    }
    [HttpPut]
    public ActionResult<Habilidad> PutHabilidad(int mandrilId, int habilidadId, HabilidadInsert habilidadInsert)  
    {
        var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.Id == mandrilId);
        if (mandril == null)
            return NotFound(Mensajes.Mandril.NotFound);

        var habilidadExistente = mandril.Habilidades?.FirstOrDefault(h => h.Id == habilidadId);
        if (habilidadExistente == null)
            return NotFound(Mensajes.Habilidad.NotFound);

        var habilidadMisNombre = mandril.Habilidades?
            .FirstOrDefault(h => h.Id != habilidadId && h.Nombre == habilidadInsert.Nombre);
        if (habilidadMisNombre != null)
            return BadRequest(Mensajes.Habilidad.NombreExistente );


        habilidadExistente.Nombre = habilidadInsert.Nombre;
        habilidadExistente.Potencia = habilidadInsert.Potencia;
        return NoContent();
    }

    [HttpDelete("{habilidadId}")]
    public ActionResult DeleteHabilidad(int mandrilId, int habilidadId)
    {
        var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.Id == mandrilId);
        if (mandril == null)
            return NotFound(Mensajes.Mandril.NotFound);
        
        var habilidadExistente = mandril.Habilidades?.FirstOrDefault(h => h.Id == habilidadId);
        if (habilidadExistente == null)
            return NotFound(Mensajes.Habilidad.NotFound);

        mandril.Habilidades.Remove(habilidadExistente);
        return NoContent();
    }

}
