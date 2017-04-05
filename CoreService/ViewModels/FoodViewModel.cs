using CoreService.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreService.ViewModels
{
    public class FoodViewModel
    {

        public int ID { get; set; }
        public string Nombre { get; set; }

        public int CategoriaID { get; set; }

        public decimal Precio { get; set; }

        public int tipoID { get; set; }

        public int SelectedImage { get; set; }


        public SelectList Categories { get; set; }

        public SelectList Tipos { get; set; }

        public IEnumerable<FoodImages> ImagenesStock { get; set; }

        public IEnumerable<Categorias> CategoriasStock { get; set; }

        public IEnumerable<Tipos> TiposStock { get; set; }

        public List<SelectList> ImagenesSeleccionadas { get; set; }

        public string[] ImagenesProducto { get; set; }
    }
}
