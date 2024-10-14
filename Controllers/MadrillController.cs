using System;
using System.Collections.Generic;  // Required for IEnumerable<T>
using System.Linq;                 // Required for LINQ methods
using mandrilAPI.helpers;
using mandrilAPI.Models;
using mandrilAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace mandrilAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MandrilController : ControllerBase  // Corrected the controller name
    {
        // Basic Hello action
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello, Mandril!");  // Fixed typo in response message
        }

        // Action to get all Mandriles
        [HttpGet("mandriles")]
        public ActionResult<IEnumerable<Mandril>> GetMandriles()
        {
            return Ok(MandrilDataStore.Current.Mandriles);
        }

        // Action to get a Mandril by ID
        [HttpGet("{MandrilId}")]
        public IActionResult GetMandril(int MandrilId)
        {
            var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.Id == MandrilId);
            if (mandril == null)
                return NotFound(Mensajes.Mandril.NotFound);
            return Ok(mandril);
        }

        // Action to add a new Mandril
        [HttpPost]
        public ActionResult<Mandril> PostMandril(InsertMandril insertMandril)
        {
            var maxMandrilId = MandrilDataStore.Current.Mandriles.Max(x => x.Id);
            var newMandril = new Mandril()
            {
                Id = maxMandrilId + 1,
                Name = insertMandril.Name,
                Apellido = insertMandril.Apellido,
            };

            MandrilDataStore.Current.Mandriles.Add(newMandril);

            // Corrected the CreatedAtAction syntax
            return CreatedAtAction(
                nameof(GetMandril),
                new { MandrilId = newMandril.Id },
                newMandril
            );
        }

        [HttpPut("{MandrilId}")]

        public ActionResult<Mandril>  PutMandril(int MandrilId,  InsertMandril InsertMandril)
        {
            var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.Id == MandrilId);
            if (mandril == null)
                return NotFound(Mensajes.Mandril.NotFound);

            mandril.Name = InsertMandril.Name;
            mandril.Apellido = InsertMandril.Apellido;

            return NoContent(); 
        }

        [HttpDelete("{Delete}")]

        public ActionResult<Mandril> DeleteMandril(int MandrilId)
        {
            var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.Id == MandrilId);
            if (mandril == null)
                return NotFound(Mensajes.Mandril.NotFound);
            MandrilDataStore.Current.Mandriles.Remove(mandril);
            return NoContent();

        }
    }
}
