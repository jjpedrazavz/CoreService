using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreService.Entities;
using CoreService.Contratos;
using CoreService.enums;
using CoreService.ViewModels;
using System.Diagnostics;
using CoreService.Models;

namespace CoreService.Controllers
{
    [Produces("application/json")]
    [Route("api/Ordenes")]
    public class OrdenesController : Controller
    {
        private readonly IRepository<Ordenes> _context;
        private readonly IRepository<Alimentos> _contextFood;
        private readonly IRepository<Estado> _contextEstado;
        private readonly IRepository<Menu> _contextmenu;

        public OrdenesController(IRepository<Ordenes> context, IRepository<Alimentos> contextFood, IRepository<Estado> contextEstado, IRepository<Menu> contextmenu)
        {
            _context = context;
            _contextFood = contextFood;
            _contextEstado = contextEstado;
            _contextmenu = contextmenu;
        }

        // GET: api/Ordenes
        //Devuelve unicamente OrdenID y ComensalID
        [HttpGet]
        public async Task<IEnumerable<SlimOrderViewModel>> GetOrdenes()
        {
          var Orders =  await _context.GetAllAsync();

            List<SlimOrderViewModel> SlimOrders = new List<SlimOrderViewModel>();

            Task<List<SlimOrderViewModel>> result = Task.Run(() =>
          {
              foreach (var item in Orders)
              {
                  SlimOrders.Add(new SlimOrderViewModel { OrdenID = item.OrdenId, ComensalID = item.ComensalId, EstadoDescripcion = item.Estado.Descripcion, OrdenFecha=item.OrdFecha });
              }

              return SlimOrders;

          });

            return result.Result;
        }

        // GET: api/Ordenes/5
        //devolvemos una orden detallada
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrdenes([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orden = await _context.GetOneAsync(id);

            if (orden == null)
            {
                return NotFound();
            }

            DetailedOrderViewModel detailedOrder = new DetailedOrderViewModel();

            detailedOrder.OrdenID = orden.OrdenId;
            detailedOrder.ComensalID = orden.ComensalId;
            detailedOrder.comensal = orden.Comensal;
            detailedOrder.estado = orden.Estado;
            detailedOrder.estadosList = await _contextEstado.GetAllAsync();
            detailedOrder.menu = await _contextmenu.getAllAsync(orden.OrdenId);

            foreach (var item in detailedOrder.menu)
            {
                var price = item.Alimento.Precio;
                detailedOrder.totalMenu += (double)(price * item.Quantity);

            }

            return Ok(detailedOrder);
        }

        // PUT: api/Ordenes
        //actualizar Orden
        [HttpPut("OrdenEdit")]
        public async Task<IActionResult> OrdenEdit([FromBody] DetailedOrderViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orden = await _context.GetOneAsync(viewModel.OrdenID);

            if(orden != null)
            {
                orden.EstadoId = viewModel.EstadoID;
            }
            else
            {
                return NotFound("No se encontro el objeto");
            }
            

            try
            {
                await _context.SaveAsync(orden);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status304NotModified);
            }
            

            return NoContent();
        }


        [HttpGet("PostOrdenes")]
        public async Task<IActionResult> PostOrdenes()
        {
            OrderViewModel viewModel = new OrderViewModel();

            viewModel.AlimentosList = await _contextFood.GetAllAsync();
            viewModel.EstadosList = await _contextEstado.GetAllAsync();

            return Ok(viewModel);


        }
        
        // POST: api/Ordenes
        //crearOrden
        [HttpPost("PostOrdenes")]
        public async Task<IActionResult> PostOrdenes([FromBody] OrderViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                Ordenes orden = new Ordenes();
                orden.ComensalId = viewModel.ComensalID;
                orden.EstadoId = 1;
                orden.OrdFecha = DateTime.Now;
                orden.Menu = new List<Menu>();

                foreach (var item in viewModel.menuSeleccionado)
                {
                    orden.Menu.Add(new Menu
                    {
                        AlimentoId = item.AlimentoID,
                        Quantity = item.Cantidad
                    });
                }
                try
                {
                    await _context.AddAsync(orden);
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }

            }
            

            return StatusCode(StatusCodes.Status201Created);
        }

        // DELETE: api/Ordenes/5
        [HttpDelete("DeleteOrdenes/{id}")]
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

            try
            {
                await _context.DeleteAsync(ordenes);
            }
            catch (Exception)
            {
                return BadRequest();
                
            }

            return StatusCode(StatusCodes.Status204NoContent);
        }

        private bool OrdenesExists(int id)
        {
            var element = _context.GetOne(id);
            return element == null ? false : true;

        }


    }
}