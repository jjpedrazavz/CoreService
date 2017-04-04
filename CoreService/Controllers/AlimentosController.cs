using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreService.Entities;
using CoreService.Models;
using CoreService.Contratos;

namespace CoreService.Controllers
{
    [Produces("application/json")]
    [Route("api/Alimentos")]
    public class AlimentosController : Controller
    {
        private readonly IRepository<Alimentos> _context;

        public AlimentosController(IRepository<Alimentos> context)
        {
            _context = context;
        }

        // GET: api/Alimentos
        [HttpGet]
        public async Task<IEnumerable<Alimentos>> GetAlimentos()
        {
            return await _context.GetAllAsync();
        }

        // GET: api/Alimentos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlimentos([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var alimento = await _context.GetOneAsync(id);

            if (alimento == null)
            {
                return NotFound();
            }

            return Ok(alimento);
        }

        // PUT: api/Alimentos/5
        //Actualizar
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlimentos([FromRoute] int id, [FromBody] Alimentos alimento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != alimento.Id)
            {
                return BadRequest();
            }

            await _context.SaveAsync(alimento);
   
            return NoContent();
        }

        // POST: api/Alimentos
        //Crear
        [HttpPost]
        public async Task<IActionResult> PostAlimentos([FromBody] Alimentos alimento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.AddAsync(alimento);

            return CreatedAtAction("GetAlimentos", new { id = alimento.Id }, alimento);
        }

        // DELETE: api/Alimentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlimentos([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var alimento = await _context.GetOneAsync(id);
            
            if (alimento == null)
            {
                return NotFound();
            }

             await _context.DeleteAsync(alimento);

            return Ok(alimento);
        }


        private bool AlimentosExists(int id)
        {
            var alimento = _context.GetOneAsync(id);

            return alimento == null ? false : true;
        }


    }
}