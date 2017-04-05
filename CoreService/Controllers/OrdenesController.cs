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
using CoreService.ViewModels;

namespace CoreService.Controllers
{
    [Produces("application/json")]
    [Route("api/Ordenes")]
    public class OrdenesController : Controller
    {
        private readonly IRepository<Ordenes> _context;
        private readonly IRepository<Alimentos> _contextFood;

        public OrdenesController(IRepository<Ordenes> context, IRepository<Alimentos> contextFood)
        {
            _context = context;
            _contextFood = contextFood;
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
                  SlimOrders.Add(new SlimOrderViewModel { OrdenID = item.OrdenId, ComensalID = item.ComensalId, EstadoDescripcion = item.Estado.Descripcion });
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

            var MenuActual = orden.Menu.FirstOrDefault();
            DetailedOrderViewModel detailedOrder = new DetailedOrderViewModel();
            detailedOrder.OrdenID = orden.OrdenId;
            detailedOrder.ComensalID = orden.ComensalId;
            detailedOrder.comensal = orden.Comensal;
            detailedOrder.estado = orden.Estado;

            #region TesstIF
            /*
             if(MenuActual != null)
             {

               if (MenuActual.BebidaId != null)
               {
                   var alimento = _contextFood.GetOne(MenuActual.BebidaId.Value);
                    detailedOrder.bebida.Id = alimento.Id;
                    detailedOrder.bebida.Nombre = alimento.Nombre;
                    detailedOrder.bebida.Precio = alimento.Precio;
                   detailedOrder.totalMenu += (double)detailedOrder.bebida.Precio;
               }


               if (MenuActual.SopaId != null)
               {
                    var alimento = _contextFood.GetOne(MenuActual.SopaId.Value);
                    detailedOrder.sopa.Id = alimento.Id;
                    detailedOrder.sopa.Nombre = alimento.Nombre;
                    detailedOrder.sopa.Precio = alimento.Precio;
                    detailedOrder.totalMenu += (double)detailedOrder.sopa.Precio;
               }


               if (MenuActual.PlatoFuerteId != null)
               {
                    var alimento = _contextFood.GetOne(MenuActual.PlatoFuerteId.Value);
                    detailedOrder.platoFuerte.Id = alimento.Id;
                    detailedOrder.platoFuerte.Nombre = alimento.Nombre;
                    detailedOrder.platoFuerte.Precio = alimento.Precio;
                   detailedOrder.totalMenu += (double)detailedOrder.platoFuerte.Precio;
               }

               if (MenuActual.PostreId != null)
               {
                    var alimento = _contextFood.GetOne(MenuActual.PostreId.Value);
                    detailedOrder.postre.Id = alimento.Id;
                    detailedOrder.postre.Nombre = alimento.Nombre;
                    detailedOrder.postre.Precio = alimento.Precio;
                   detailedOrder.totalMenu += (double)detailedOrder.postre.Precio;
               }

               if (MenuActual.BocadilloId != null)
               {
                    var alimento = _contextFood.GetOne(MenuActual.BocadilloId.Value);
                    detailedOrder.bocadillo.Id = alimento.Id;
                    detailedOrder.bocadillo.Nombre = alimento.Nombre;
                    detailedOrder.bocadillo.Precio = alimento.Precio;
                   detailedOrder.totalMenu += (double)detailedOrder.bocadillo.Precio;
               }


               if (MenuActual.ComplementoId != null)
               {
                    var alimento = _contextFood.GetOne(MenuActual.ComplementoId.Value);
                    detailedOrder.complemento.Id = alimento.Id;
                    detailedOrder.complemento.Nombre = alimento.Nombre;
                    detailedOrder.complemento.Precio = alimento.Precio;
                   detailedOrder.totalMenu += (double)detailedOrder.complemento.Precio;
               }
             }
             */
            #endregion

            if (MenuActual != null)
            {

                if (MenuActual.BebidaId != null)
                {
                    detailedOrder.bebida = _contextFood.GetOne(MenuActual.BebidaId.Value);
                    detailedOrder.totalMenu += (double)detailedOrder.bebida.Precio;
                }


                if (MenuActual.SopaId != null)
                {
                    detailedOrder.sopa = _contextFood.GetOne(MenuActual.SopaId.Value);
                    detailedOrder.totalMenu += (double)detailedOrder.sopa.Precio;
                }


                if (MenuActual.PlatoFuerteId != null)
                {
                    detailedOrder.platoFuerte = _contextFood.GetOne(MenuActual.PlatoFuerteId.Value);
                    detailedOrder.totalMenu += (double)detailedOrder.platoFuerte.Precio;
                }

                if (MenuActual.PostreId != null)
                {
                    detailedOrder.postre = _contextFood.GetOne(MenuActual.PostreId.Value);
                    detailedOrder.totalMenu += (double)detailedOrder.postre.Precio;
                }

                if (MenuActual.BocadilloId != null)
                {
                    detailedOrder.bocadillo = _contextFood.GetOne(MenuActual.BocadilloId.Value);
                    detailedOrder.totalMenu += (double)detailedOrder.bocadillo.Precio;
                }


                if (MenuActual.ComplementoId != null)
                {
                    detailedOrder.complemento = _contextFood.GetOne(MenuActual.ComplementoId.Value);
                    detailedOrder.totalMenu += (double)detailedOrder.complemento.Precio;
                }
            }



            return Ok(detailedOrder);
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
        //crearOrden
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


    }
}