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
using CoreService.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreService.Controllers
{
    [Produces("application/json")]
    [Route("api/Alimentos")]
    public class AlimentosController : Controller
    {
        private readonly IRepository<Alimentos> _context;
        private readonly IRepository<FoodImageMapping> _contextFoodImagesMap;
        private readonly IRepository<FoodImages> _contextFoodImages;
        private readonly IRepository<Categorias> _contextCategories;
        private readonly IRepository<Tipos> _contextTipos;




        public AlimentosController(IRepository<Alimentos> context, IRepository<FoodImageMapping> contextFoodImagesMap, IRepository<FoodImages> contextFoodImages, IRepository<Categorias> contextCategories, IRepository<Tipos> contextTipos)
        {
            _context = context;
            _contextFoodImagesMap = contextFoodImagesMap;
            _contextFoodImages = contextFoodImages;
            _contextCategories = contextCategories;
            _contextTipos = contextTipos;
        }

        // GET: api/Alimentos
        [HttpGet]
        public async Task<IEnumerable<Alimentos>> GetAlimentos()
        {
            return await _context.GetAllAsync();
        }

        // GET: api/Alimentos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlimento([FromRoute] int id)
        {
            var alimento = await _context.GetOneAsync(id);

            FoodViewModel viewModel = new FoodViewModel();

            if (alimento != null)
            {
                  viewModel.CategoriasStock = _contextCategories.GetAll();
                  viewModel.TiposStock = _contextTipos.GetAll();
                  viewModel.SelectedImage = alimento.FoodImageMapping.FirstOrDefault().AlimentosImageId.Value;
                  viewModel.ImagenesStock = _contextFoodImages.GetAll();
                  viewModel.ID = alimento.Id;
                  viewModel.Nombre = alimento.Nombre;
                  viewModel.Precio = alimento.Precio;
                  viewModel.CategoriaID = alimento.CategoriaId;
                  viewModel.tipoID = alimento.TipoId;
            }
            else
            {
                return NotFound();
            }

            return Ok(viewModel);
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