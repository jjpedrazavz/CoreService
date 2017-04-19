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
    [Route("api/FoodImages")]
    public class FoodImagesController : Controller
    {
        private readonly IRepository<FoodImages> _contextImages;
        private readonly IRepository<FoodImageMapping> _contextMapping;


        public FoodImagesController(IRepository<FoodImages> contextImages, IRepository<FoodImageMapping> contextMapping)
        {
            _contextImages = contextImages;
            _contextMapping = contextMapping;
        }

        // GET: api/FoodImages
        [HttpGet]
        public async Task<IEnumerable<FoodImages>> GetFoodImages()
        {
            return await _contextImages.GetAllAsync();
        }

        // GET: api/FoodImages/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFoodImages([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var foodImages = await _contextImages.GetOneAsync(id);

            if (foodImages == null)
            {
                return NotFound();
            }

            return Ok(foodImages);
        }

        // PUT: api/FoodImages/5
        //Actualizar Imagen
        [HttpPut("PutFoodImages")]
        public async Task<IActionResult> PutFoodImages([FromBody] FoodImages foodImages)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

               await _contextImages.SaveAsync(foodImages);

            return NoContent();
        }

        // POST: api/FoodImages
        [HttpPost]
        public async Task<IActionResult> PostFoodImages([FromBody] FoodImages foodImages)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int value =  await _contextImages.AddAsync(foodImages);

            if (value > 0)
            {
                return StatusCode(StatusCodes.Status201Created);
            }

            return StatusCode(StatusCodes.Status400BadRequest);

        }

        // DELETE: api/FoodImages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFoodImages([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var foodImages = await _contextImages.GetOneAsync(id);

            if (foodImages == null)
            {
                return NotFound();
            }

            try
            {
               await _contextImages.DeleteAsync(foodImages);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpGet("GetMaapings")]
        public async Task<IEnumerable<FoodImageMapping>> GetMaapings([FromRoute]int id)
        {
            return await _contextMapping.getAllAsync(id);
        }





    }
}