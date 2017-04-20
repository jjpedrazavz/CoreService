USE [Hungry11];


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


INSERT INTO dbo.Alimentos(Nombre,CategoriaID,Precio,tipoID,estatus,Descripcion) VALUES

                  ('Crema Zanahoria',1,70.99, 1,1,'Crema de Zanahoria 100% natural'),
                  ('Sopa Cangrejo',7,125.88,1,1,'Crema de Zanahoria 100% natural'),
                  ('Arroz',2,99.99,1,1,'Crema de Zanahoria 100% natural'),
                  ('spaghetti',3,70.99,1,1,'Delicioso spaghetti a la boloñesa con salsa casera'),

                  ('Agua Melon',2,13.99,2,1,'Agua del melo chino endulzada con splenda'),
                  ('Coca Cola',2,15.88,2,1,'Crema de Zanahoria 100% natural'),
                  ('Indio Oscura',2,35.99,2,1,'Crema de Zanahoria 100% natural'),
                  ('Agua Simple',2,12.99,2,1,'Crema de Zanahoria 100% natural'),

                  ('Papas fritas',17,20,6,1,'Crema de Zanahoria 100% natural'),
                  ('Gomitas',15,20,6,1,'gomitas de la marca ricolino'),
                  ('Galleta Choclate',16,20,6,1,'Crema de Zanahoria 100% natural'),
                  ('Bombones',15,20,6,1,'Crema de Zanahoria 100% natural'),

                  ('huevo frito',18,10,5,1,'Crema de Zanahoria 100% natural'),
                  ('platano macho',18,10,5,1,'Crema de Zanahoria 100% natural'),
                  ('guacamole',18,25,5,1,'Crema de Zanahoria 100% natural'),
                  ('totopos',18,30,5,1,'Crema de Zanahoria 100% natural'),


                  ('Arrachera',4,100.99,3,1,'Crema de Zanahoria 100% natural'),
                  ('Caldo de rez',4,80,3,1,'Crema de Zanahoria 100% natural'),
                  ('Pollo con mole',5,99.99,3,1,'Crema de Zanahoria 100% natural'),
                  ('Filete relleno de camarones', 7,130.99,3,1,'Crema de Zanahoria 100% natural'),

                  ('Helado Fresa', 12,25.99,4,1,'Crema de Zanahoria 100% natural'),
                  ('Gelatina', 14,15,4,1,'Crema de Zanahoria 100% natural'),
                  ('Flan Napolitano', 14,25.99 ,4,1,'Crema de Zanahoria 100% natural'),
                  ('Bombones', 15,8.99 ,4,1,'Crema de Zanahoria 100% natural')


INSERT INTO dbo.FoodImages(NameFile) VALUES
                                   ('arroz_rojo3.jpeg'),
								   ('caldo_res3.jpg'),
								   ('coca_cola600ml.jpg'),
								   ('crema_z.jpg'),
								   ('galletaChocolate3.jpg'),
								   ('helado_fresa3.jpg'),
								   ('huevo_frito3.jpg'),
								   ('platanoFrito3.jpg'),
								   ('pollo_mole3.jpg'),
								   ('spa2.jpg')

								   					   
INSERT INTO dbo.MenuBundle(MenuBundleIdName,Price,MenuCategory) VALUES('Especial del mar',150,'Comidas'),
                                                         ('Especial Fitness',120,'Comidas'),
										                 ('Cuando toca... toca',90,'Comidas'),
														 ('Desayuno Norteño',77.99,'Desayunos'),
                                                         ('HotCakes Family',45.99,'Desayunos'),
														 ('Molletes Aplastados',89.99,'Cenas'),
														 ('Especial SlimFit',130.00,'Cenas');
														 
														 
														 
INSERT INTO dbo.FoodImageMapping(AlimentosID,AlimentosImageID,ImageNumber) VALUES
                                                                          (1,4,1),
																		  (3,1,1),
																		  (4,10,1),
																		  (6,3,1),
																		  (7,11,1),
																		  (11,5,1),
																		  (13,7,1),
																		  (14,8,1),
																		  (18,2,1),
																		  (19,9,1),
																		  (21,6,1),
																		  
																		  
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