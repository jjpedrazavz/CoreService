USE [Hungry10];


INSERT INTO dbo.Categorias (Nombre) VALUES
               ('Cremas'),
               ('Sopa Aguada'),
               ('Pastas'),
               ('Carne Roja'),
               ('Carne Blanca'),
               ('Carne Cerdo'),
               ('Pescados/Mariscos'),
               ('Refrescos'),
               ('Aguas Naturales'),
               ('Cerveza'),
               ('Pasteles'),
               ('Helados'),
               ('Crepas'),
               ('Gelatinas'),
               ('Caramelos'),
               ('Galletas'),
               ('Frituras'),
               ('Varios')

INSERT INTO dbo.Tipos(Nombre) VALUES
                    ('Sopa'),
                    ('Bebida'),
                    ('PlatoFuerte'),
                    ('Postre'),
                    ('Complemento'),
                    ('Bocadillo')


INSERT INTO dbo.Estado(Descripcion) VALUES
                    ('Iniciado'),
                    ('Confirmado'),
                    ('Cancelado'),
                    ('Terminado')



INSERT INTO dbo.Comensales(Apellido,Nombre,Email) VALUES
					   ('smith','john','john@john.com'),
                       ('karl','jeremy','jeremy@john.com'),
                       ('green','marcus','marcus@john.com'),
                       ('tusk','Elena','Elena@john.com')


INSERT INTO dbo.Alimentos(Nombre,CategoriaID,Precio,tipoID) VALUES

                  ('Crema Zanahoria',1,70.99, 1),
                  ('Sopa Cangrejo',7,125.88,1),
                  ('Arroz',2,99.99,1),
                  ('spaghetti',3,70.99,1),

                  ('Agua Melon',2,13.99,2),
                  ('Coca Cola',2,15.88,2),
                  ('Indio Oscura',2,35.99,2),
                  ('Agua Simple',2,12.99,2),

                  ('Papas fritas',17,20,6),
                  ('Gomitas',15,20,6),
                  ('Galleta Choclate',16,20,6),
                  ('Bombones',15,20,6),

                  ('huevo frito',18,10,5),
                  ('platano macho',18,10,5),
                  ('guacamole',18,25,5),
                  ('totopos',18,30,5),


                  ('Arrachera',4,100.99,3),
                  ('Caldo de rez',4,80,3),
                  ('Pollo con mole',5,99.99,3),
                  ('Filete relleno de camarones', 7,130.99,3),

                  ('Helado Fresa', 12,25.99,4),
                  ('Gelatina', 14,15,4),
                  ('Flan Napolitano', 14,25.99 ,4),
                  ('Bombones', 15,8.99 ,4)


INSERT INTO dbo.FoodImages(NameFile) VALUES
                                   ('indio_cerbeza.jpeg'),
								   ('coca_cola600ml.jpg'),
								   ('galletaChocolate.jpg'),
								   ('huevo_frito.jpg'),
								   ('platanoFrito.jpg'),
								   ('pollo_mole.jpg'),
								   ('caldo_res.jpg'),
								   ('helado_fresa.jpg'),
								   ('arroz_rojo.jpeg'),
								   ('crema_zanahoria.jpg')
								   
								   
INSERT INTO dbo.MenuBundle(MenuBundleIdName,Price,MenuCategory) VALUES('Especial del mar',150,'Comidas'),
                                                         ('Especial Fitness',120,'Comidas'),
										                 ('Cuando toca... toca',90,'Comidas')
														 ('Desayuno Norteño',77.99,'Desayunos'),
                                                         ('HotCakes Family',45.99,'Desayunos'),
														 ('Molletes Aplastados',89.99,'Cenas'),
														 ('Especial SlimFit',130.00,'Cenas');
								 
--Insertar menu prefabricado.								 
INSERT INTO Menu(AlimentoID,Quantity,BundleId) VALUES
                                               (2,1,1),
											   (20,1,1),
											   (7,1,1),
											   (23,1,1),
                                               (1,1,2),
											   (18,1,2),
											   (8,1,2),
											   (21,1,2),
                                               (3,1,3),
											   (19,1,3),
											   (6,1,3),
											   (24,1,3)