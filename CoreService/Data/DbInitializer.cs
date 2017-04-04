using System;
using CoreService.Entities;
using CoreService.Repository;
using System.Collections.Generic;
using CoreService.Models;

namespace CoreService.Data
{
    /// <summary>
    /// Clase encargada de llenar la bd con datos de pruebas
    /// </summary>
    public static class DbInitializer
    {

       /*
        internal static void Init(HungryDbContext context)
        {
            //nos aseguramos de crear la Bd si no existe.
            context.Database.EnsureCreated();
            
            //verificamos si no existen ya datos en la tabla.
            if(context.Categorias.Local.Count == 0)
            {

                var listCategories = new Categorias[]
                {
                   new Categorias{ CategoriaId="1", Nombre="Cremas"},
                   new Categorias{ CategoriaId="2", Nombre="Sopa Aguada"},
                   new Categorias{ CategoriaId="3", Nombre="Pastas"},
                   new Categorias{ CategoriaId="4", Nombre="Carne Roja"},
                   new Categorias{ CategoriaId="5", Nombre="Carne Blanca"},
                   new Categorias{ CategoriaId="6", Nombre="Carne Cerdo"},
                   new Categorias{ CategoriaId="7", Nombre="Pescados/Mariscos"},
                   new Categorias{ CategoriaId="8", Nombre="Refrescos"},
                   new Categorias{ CategoriaId="9", Nombre="Aguas Naturales"},
                   new Categorias{ CategoriaId="10", Nombre="Cerveza"},
                   new Categorias{ CategoriaId="11", Nombre="Pasteles"},
                   new Categorias{ CategoriaId="12", Nombre="Helados"},
                   new Categorias{ CategoriaId="13", Nombre="Crepas"},
                   new Categorias{ CategoriaId="14", Nombre="Gelatinas"},
                   new Categorias{ CategoriaId="15", Nombre="Caramelos"},
                   new Categorias{ CategoriaId="16", Nombre="Galletas"},
                   new Categorias{ CategoriaId="17", Nombre="Frituras"},
                   new Categorias{ CategoriaId="18", Nombre="Varios"},

                };

                foreach (Categorias item in listCategories)
                {
                    context.Categorias.Add(item);
                }

                context.SaveChanges();

            }

            if (context.Tipos.Local.Count == 0)
            {
                var tipos = new Tipos[]
                {
                    new Tipos{TipoId="1",Nombre="Sopa" },
                    new Tipos{TipoId="2",Nombre="Bebida" },
                    new Tipos{TipoId="3",Nombre="PlatoFuerte" },
                    new Tipos{TipoId="4",Nombre="Postre" },
                    new Tipos{TipoId="5",Nombre="Complemento" },
                    new Tipos{TipoId="6",Nombre="Bocadillo" },

                };

                foreach (Tipos item in tipos)
                {
                    context.Tipos.Add(item);
                }

                context.SaveChanges();


            }


            if (context.Estados.Local.Count == 0)
            {
                var estadosLista = new Estados[]
               {
                   new Estados{EstadoId="1",Descripcion="Iniciado" },
                    new Estados{EstadoId="2",Descripcion="Confirmado" },
                    new Estados{EstadoId="3",Descripcion="Cancelado" },
                    new Estados{EstadoId="4",Descripcion="Terminado" }
               };

                foreach (Estados item in estadosLista)
                {
                    context.Estados.Add(item);
                }

                context.SaveChanges();

            }

            if (context.Alimentos.Local.Count == 0)
            {
                

                var Alimentoslist = new Alimentos[]
                {
                  
                  new Alimentos{Id = Guid.NewGuid().ToString(),Nombre = "Crema Zanahoria",CategoriaId="1",Precio=70.99M,TipoId="1" },
                  new Alimentos{Id = Guid.NewGuid().ToString(),Nombre = "Sopa Cangrejo",CategoriaId="7",Precio=125.88M,TipoId="1" },
                  new Alimentos{Id = Guid.NewGuid().ToString(),Nombre = "Arroz",CategoriaId="1",Precio=99.99M,TipoId="1" },
                  new Alimentos{Id = Guid.NewGuid().ToString(),Nombre = "spaghetti",CategoriaId="3",Precio=70.99M,TipoId="1" },

                  new Alimentos{Id = Guid.NewGuid().ToString(), Nombre="Agua Melon",CategoriaId="9",Precio=13.99M,TipoId="2" },
                  new Alimentos{Id = Guid.NewGuid().ToString(), Nombre = "Coca Cola",CategoriaId="8",Precio=15.88M,TipoId="2" },
                  new Alimentos{Id = Guid.NewGuid().ToString(), Nombre = "Indio Oscura",CategoriaId="10",Precio=35.99M,TipoId="2" },
                  new Alimentos{Id = Guid.NewGuid().ToString(), Nombre = "Agua Simple",CategoriaId="9",Precio=12.99M,TipoId="2" },


                  new Alimentos{Id = Guid.NewGuid().ToString(),Nombre = "Papas fritas",CategoriaId= "17",Precio=20,TipoId="6"},
                  new Alimentos{Id = Guid.NewGuid().ToString(),Nombre = "Gomitas",CategoriaId= "15",Precio=20,TipoId="6"},
                  new Alimentos{Id = Guid.NewGuid().ToString(),Nombre = "Galleta Choclate",CategoriaId= "16",Precio=20,TipoId="6"},
                  new Alimentos{Id = Guid.NewGuid().ToString(),Nombre = "Bombones",CategoriaId= "15",Precio=20,TipoId="6"},


                  new Alimentos{Id = Guid.NewGuid().ToString(),Nombre = "huevo frito",CategoriaId= "18",Precio=10,TipoId="5"},
                  new Alimentos{Id = Guid.NewGuid().ToString(),Nombre = "platano macho",CategoriaId= "18",Precio=10,TipoId="5"},
                  new Alimentos{Id = Guid.NewGuid().ToString(),Nombre = "guacamole",CategoriaId= "18",Precio=25,TipoId="5"},
                  new Alimentos{Id = Guid.NewGuid().ToString(),Nombre = "totopos",CategoriaId= "18",Precio=30,TipoId="5"},


                  new Alimentos{Id = Guid.NewGuid().ToString(),Nombre = "Arrachera",CategoriaId= "4",Precio=100.99M,TipoId="3" },
                  new Alimentos{Id = Guid.NewGuid().ToString(),Nombre = "Caldo de rez",CategoriaId= "5",Precio=80,TipoId="3" },
                  new Alimentos{Id = Guid.NewGuid().ToString(),Nombre = "Pollo con mole",CategoriaId= "5",Precio=99.99M,TipoId="3" },
                  new Alimentos{Id = Guid.NewGuid().ToString(), Nombre = "Filete relleno de camarones", CategoriaId = "7",Precio=130.99M,TipoId="3" },


                  new Alimentos{Id = Guid.NewGuid().ToString(),Nombre = "Helado Fresa",CategoriaId=  "12",Precio=25.99M,TipoId="4" },
                  new Alimentos{Id = Guid.NewGuid().ToString(),Nombre = "Gelatina",CategoriaId=  "14",Precio=15,TipoId="4" },
                  new Alimentos{Id = Guid.NewGuid().ToString(),Nombre = "Flan Napolitano",CategoriaId=  "14",Precio=25.99M ,TipoId="4"},
                  new Alimentos{Id = Guid.NewGuid().ToString(), Nombre = "Bombones",CategoriaId=  "15",Precio=8.99M ,TipoId="4"},

                };


                foreach (Alimentos item in Alimentoslist)
                {
                    context.Alimentos.Add(item);
                }

                context.SaveChanges();

            }


            if(context.Comensales.Local.Count == 0)
            {

                var Clients = new Comensales[]
                {

                    new Comensales{ ComensalId="123456789", Apellido="smith", Nombre="john",Email="john@john.com" },
                    new Comensales{ ComensalId="123456", Apellido="karl", Nombre="jeremy",Email="jeremy@john.com" },
                    new Comensales{ ComensalId="1234567", Apellido="green", Nombre="marcus",Email="marcus@john.com" },
                    new Comensales{ ComensalId="12345678", Apellido="tusk", Nombre="Elena",Email="Elena@john.com" },

                };

                foreach (Comensales item in Clients)
                {
                    context.Comensales.Add(item);
                }

                context.SaveChanges();


            }
            
            
            
            if (context.Ordenes.Local.Count == 0)
            {
                var Ordeneslist = new Ordenes[]
                {

                    new Ordenes{OrdenId="123456",ComensalId="1234567", EstadoId="11", Menu = new List<Menu>
                       {

                             new Menu
                             {
                                 SopaId ="0b8ac6d5-419b-424b-a46f-1540e41ba662",
                                 BebidaId ="11403217-2dbb-4619-a0c3-b791a50c279f",
                                 PlatoFuerteId ="72e73878-ac40-4365-8a1c-86b52e5e6430",
                                 PostreId="2d415d56-cdc5-46a4-aa7f-192d7ae325d0",
                                 ComplementoId ="1b742d5b-db24-42dc-aa36-fa1c25a7474d",
                                 BocadilloId="34513722-9ce2-473e-808d-3a5fd36313d9",
                                 
                             }
                       }
                    }
                };


                foreach (Ordenes item in Ordeneslist)
                {
                    context.Ordenes.Add(item);
                }

                context.SaveChanges();

            }
            


        }
        
        */
        
    }
    

}