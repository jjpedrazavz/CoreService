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
using CoreService.enums;

namespace CoreService.Controllers
{
    [Produces("application/json")]
    [Route("api/Ordenes")]
    public class OrdenesController : Controller
    {
        private readonly IRepository<Ordenes> _context;

        public OrdenesController(IRepository<Ordenes> context)
        {
            _context = context;
        }

        // GET: api/Ordenes
        [HttpGet]
        public async Task<IEnumerable<Ordenes>> GetOrdenes()
        {
            return  await _context.GetAllAsync();
        }

        // GET: api/Ordenes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrdenes([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ordenes = await _context.GetOneAsync(id);

            if (ordenes == null)
            {
                return NotFound();
            }

            return Ok(ordenes);
        }

        // PUT: api/Ordenes/5
        //actualizar Orden
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdenes([FromRoute] int id, [FromBody] Ordenes orden)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orden.OrdenId)
            {
                return BadRequest();
            }

                await _context.SaveAsync(orden);
        

            return NoContent();
        }

        // POST: api/Ordenes
        [HttpPost]
        public async Task<IActionResult> PostOrdenes([FromBody] Ordenes orden)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (OrdenesExists(orden.OrdenId))
            {
                return BadRequest(RequestsOrdenes.OrdenExistente.ToString());
            }
            else
            {
                await _context.AddAsync(orden);
            }


            return CreatedAtAction("GetOrdenes", new { id = orden.OrdenId }, orden);
        }

        // DELETE: api/Ordenes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdenes([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ordenes = await _context.GetOneAsync(id);

            if (ordenes == null)
            {
                return NotFound();
            }

            await _context.DeleteAsync(ordenes);

            return Ok(ordenes);
        }

        private bool OrdenesExists(int id)
        {
            var element = _context.GetOne(id);
            return element == null ? false : true;

        }

        private bool hola()
        {
            return false;
        }


    }
}