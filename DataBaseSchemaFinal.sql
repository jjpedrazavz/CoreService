CREATE TABLE Categorias(
CategoriaID int IDENTITY(1,1) PRIMARY KEY,
Nombre nvarchar(80) NOT NULL);

CREATE TABLE Tipos(
TipoID int IDENTITY(1,1) PRIMARY KEY,
Nombre nvarchar(80) NOT NULL);

CREATE TABLE Estado(
EstadoID int IDENTITY(1,1) PRIMARY KEY,
Descripcion nvarchar(20) NOT NULL);


CREATE TABLE Comensales(
ComensalID int IDENTITY(1,1) PRIMARY KEY,
Nombre nvarchar(80) NOT NULL,
Apellido nvarchar(80) NOT NULL,
Email nvarchar(200) NOT NULL);


CREATE TABLE FoodImages(
ID int IDENTITY(1,1),
NameFile nvarchar(120),
CONSTRAINT PK_FoodImages PRIMARY KEY(ID));


CREATE TABLE Alimentos(
ID int IDENTITY(1,1) PRIMARY KEY,
Nombre nvarchar(80) NOT NULL,
Descripcion nvarchar(200),
CategoriaID int NOT NULL,
Precio numeric(6,2) NOT NULL,
tipoID int NOT NULL,
CONSTRAINT FK_Categories_Alimentos FOREIGN KEY(CategoriaID) REFERENCES Categorias(CategoriaID),
CONSTRAINT FK_Tipos_Alimentos FOREIGN KEY(tipoID) REFERENCES Tipos(tipoID));


CREATE TABLE Ordenes(
OrdenID int IDENTITY(1,1) PRIMARY KEY,
OrdFecha DATETIME NOT NULL,
ComensalID int  NOT NULL,
EstadoID int  NOT NULL,
CONSTRAINT FK_Ordenes_Comensal FOREIGN KEY(ComensalID) REFERENCES Comensales(ComensalID),
CONSTRAINT FK_Ordenes_Estado FOREIGN KEY(EstadoID) REFERENCES Estado(EstadoID));


CREATE TABLE Menu(
MenuID int IDENTITY(1,1) PRIMARY KEY,
OrdenID int,
AlimentoID int,
Quantity int,
BundleID int,
CONSTRAINT FK_menu_ordenes FOREIGN KEY(OrdenID) REFERENCES Ordenes(OrdenID)
                                                ON DELETE CASCADE,
CONSTRAINT FK_menu_MenuBundle FOREIGN KEY(BundleID) REFERENCES MenuBundle(MenuBundleID)
                                                ON DELETE CASCADE,										
CONSTRAINT FK_menu_alimento FOREIGN KEY(AlimentoID) REFERENCES Alimentos(ID));


CREATE TABLE MenuBundle(
MenuBundleID int IDENTITY(1,1) PRIMARY KEY,
MenuBundleName NVARCHAR2(120),
Price DECIMAL(6,2),
MenuCategory NVARCHAR(50) CHECK (MenuCategory IN ('Desayunos','Comidas','Cenas'))
)


CREATE TABLE FoodImageMapping(
ID int IDENTITY(1,1),
AlimentosID int,
ImageNumber int,
AlimentosImageID int,
CONSTRAINT PK_FoodImageMapping PRIMARY KEY(ID),
CONSTRAINT FK_FoodImageMapping_Alimentos FOREIGN KEY(AlimentosID) REFERENCES Alimentos(ID)
                                                                  ON DELETE CASCADE,
CONSTRAINT FK_FOODImageMapping_FoodImage FOREIGN KEY(AlimentosImageID) REFERENCES FoodImages(ID));




Scaffold-DbContext "Data Source=DESKTOP-QU97L6I\SQLEXPRESS;Initial Catalog=HungryDb;Integrated Security=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models






