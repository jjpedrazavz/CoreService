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
using CoreService.ViewModels.ClientMovil;
using CoreService.Modelos;

namespace CoreService.Controllers
{
    [Produces("application/json")]
    [Route("api/ClientMenu")]
    public class ClientController : Controller
    {
        private readonly Hungry4Context _context;
        private readonly IRepository<Menu> _contextMenu;
        private readonly IRepository<Alimentos> _contextAlimentos;
        private readonly IRepository<MenuBundle> _contextMenuBundle;
        private readonly IRepository<Ordenes> _contextOrdenes;

        public ClientController(Hungry4Context context, IRepository<Menu> contextMenu, IRepository<Alimentos> contextAlimentos, IRepository<MenuBundle> contextMenuBundle, IRepository<Ordenes> contextOrdenes)
        {
            _context = context;
            _contextMenu = contextMenu;
            _contextAlimentos = contextAlimentos;
            _contextMenuBundle = contextMenuBundle;
            _contextOrdenes = contextOrdenes;
        }

        // GET: api/ClientMenu
        [HttpGet("GetBuildInMenus")]
        public async Task<IEnumerable<DetailedBuiltInMenuViewModel>> GetBuildInMenus()
        {

            var Alimentos = await _contextAlimentos.GetAllAsync();
            var Menus = await _contextMenu.GetAllAsync();
            var BuiltInMenusID = await _contextMenuBundle.GetAllAsync();

            
            List<DetailedBuiltInMenuViewModel> menus = new List<DetailedBuiltInMenuViewModel>();


            foreach (var item in BuiltInMenusID)
            {

                DetailedBuiltInMenuViewModel viewModel = new DetailedBuiltInMenuViewModel();

                var builtMenu = (from element in Menus
                                where element.BundleId == item.MenuBundleId
                                select new { Alimento = element.Alimento, Tipo = element.Alimento.TipoId}).ToList();


                foreach (var alimento in builtMenu)
                {

                    switch (alimento.Tipo)
                    {
                        case 1:
                            viewModel.SopaNombre = alimento.Alimento.Nombre;
                            break;
                        case 2:
                            viewModel.BebidaNombre = alimento.Alimento.Nombre;
                            break;
                        case 3:
                            viewModel.PlatoFuerteNombre = alimento.Alimento.Nombre;
                            break;
                        case 4:
                            viewModel.PostreNombre = alimento.Alimento.Nombre;
                            break;
                        case 5:
                            viewModel.ComplementoNombre = alimento.Alimento.Nombre;
                            break;
                        default:
                            break;
                    }


                }

                viewModel.precio = (double)item.Price;
                viewModel.BundleId = item.MenuBundleId;
                viewModel.NameMenu = item.MenuBundleIdName;
                viewModel.MenuCategory = item.MenuCategory;
                menus.Add(viewModel);
            }


            return menus;
        }

        // GET: api/ClientMenu/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenu([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var menu = await _context.Menu.SingleOrDefaultAsync(m => m.MenuId == id);

            if (menu == null)
            {
                return NotFound();
            }

            return Ok(menu);
        }


        [HttpGet("GetCreateOrder")]
        public async Task<IActionResult> GetCreateOrder()
        {
            ClientOrdersViewModel viewModel = new ClientOrdersViewModel();
            viewModel.AlimentosList = await _contextAlimentos.GetAllAsync();

            return Ok(viewModel);
        }


        // PUT: api/ClientMenu/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenu([FromRoute] int id, [FromBody] Menu menu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != menu.MenuId)
            {
                return BadRequest();
            }

            _context.Entry(menu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ClientMenu
        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder([FromBody] ClientOrdersViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Ordenes orden = new Ordenes();
            orden.ComensalId = 1;
            orden.EstadoId = 1;
            orden.OrdFecha = DateTime.Now;
            orden.Menu = new List<Menu>();

            foreach (var item in viewModel.menuSeleccionado)
            {

                System.Diagnostics.Debug.WriteLine("BundleId: "+item.BundleId);

                if (item.BundleId ==0)
                {
                    orden.Menu.Add(new Menu { AlimentoId = item.AlimentoID, Quantity = item.Cantidad });
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Entrado al else: "+item.BundleId);

                    var MenusList = await _contextMenu.GetAllAsync();

                    var BundleItems = (from elem in MenusList
                                       where elem.OrdenId == null && elem.BundleId ==item.BundleId
                                       select elem).ToList();

                    System.Diagnostics.Debug.WriteLine("Tamaño de Bundle " + BundleItems.Count);

                    foreach (var element in BundleItems)
                    {
                        orden.Menu.Add(new Menu { AlimentoId = element.AlimentoId, BundleId = item.BundleId, Quantity = item.Cantidad });
                    }
                }

            }

            try
            {
                await _contextOrdenes.AddAsync(orden);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status409Conflict);
            }

            return StatusCode(StatusCodes.Status201Created);

        }

        // DELETE: api/ClientMenu/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenu([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var menu = await _context.Menu.SingleOrDefaultAsync(m => m.MenuId == id);
            if (menu == null)
            {
                return NotFound();
            }

            _context.Menu.Remove(menu);
            await _context.SaveChangesAsync();

            return Ok(menu);
        }

        private bool MenuExists(int id)
        {
            return _context.Menu.Any(e => e.MenuId == id);
        }
    }
}