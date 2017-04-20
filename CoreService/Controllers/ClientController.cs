using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoreService.Models;
using CoreService.Contratos;
using CoreService.ViewModels.ClientMovil;
using CoreService.Modelos;
using CoreService.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CoreService.Controllers
{
    [Produces("application/json")]
    [Route("api/ClientMenu")]
    public class ClientController : Controller
    {
        private readonly IRepository<Menu> _contextMenu;
        private readonly IRepository<Alimentos> _contextAlimentos;
        private readonly IRepository<MenuBundle> _contextMenuBundle;
        private readonly IRepository<Ordenes> _contextOrdenes;

        public ClientController(IRepository<Menu> contextMenu, IRepository<Alimentos> contextAlimentos, IRepository<MenuBundle> contextMenuBundle, IRepository<Ordenes> contextOrdenes)
        {
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

      
        [HttpGet("GetCreateOrder")]
        public async Task<IActionResult> GetCreateOrder()
        {
            ClientOrdersViewModel viewModel = new ClientOrdersViewModel();

            var stock = await _contextAlimentos.GetAllAsync();

            viewModel.AlimentosList = stock.Where(p => p.estatus == true).ToList();

            return Ok(viewModel);
        }


        [HttpGet("GetClientOrders/{comensalID}")]
        public async Task<IEnumerable<SlimOrderViewModel>> GetOrders([FromRoute]int comensalID)
        {
            if (ModelState.IsValid)
            {
                var ordenes = await _contextOrdenes.GetAllAsync();

                var ClientOrders = (from element in ordenes
                                    where element.ComensalId == comensalID
                                    select element).ToList();

                List<SlimOrderViewModel> slimOrders = new List<SlimOrderViewModel>();

                foreach (var item in ClientOrders)
                {
                    slimOrders.Add(new SlimOrderViewModel { ComensalID = comensalID, OrdenID = item.OrdenId, OrdenFecha = item.OrdFecha, EstadoDescripcion = item.Estado.Descripcion });

                }


                return slimOrders;

            }

            return null;

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

    }
}