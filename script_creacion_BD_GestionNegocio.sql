create database Gestion_de_Negocio
go

use Gestion_de_Negocio
go

create table roles
(
idRol_r int identity(1,1) not null,
nombre_r varchar(30) not null,
constraint PK_Roles primary key (idRol_r),
)
go
create table usuarios
(
idUsuario_us int identity(1,1) not null,
nombre_us varchar(30) not null,
contrasenia_us varchar(30) not null,
idRol_us int not null,
constraint PK_Usuarios primary key (idUsuario_us),
)
go

alter table usuarios
add dni varchar(8) not null
go
alter table usuarios
add constraint UQ_Usuarios unique (dni)
go

create table negocios
(
idNegocio_n int identity(1,1) not null,
nombre_n varchar(30) not null,
constraint PK_negocios primary key (idNegocio_n)
)
go

create table negociosXusuarios
(
idUsuario_nXu int not null,
idNegocio_nXu int not null,
constraint PK_negociosXusuarios primary key (idUsuario_nXu,idNegocio_nXu),
constraint FK_nXu_Usuarios foreign key (idUsuario_nXu) references usuarios (idUsuario_us),
constraint FK_nXu_Negocios foreign key (idNegocio_nXu) references negocios (idNegocio_n)
)
go

create table secciones
(
idSeccion_sec int identity(1,1) not null,
nombre_sec varchar(30) not null,
constraint PK_secciones primary key (idSeccion_sec),
)
go
create table productos
(
idProducto_pr int identity(1,1) not null,
idNegocio_pr int not null,
nombre_pr varchar(30) not null,
idSeccion_pr int not null,
categoria_pr varchar(30) null,
descripcion_pr varchar(100) null,
precio_pr money not null,
stock_pr int not null,
activo_pr bit not null,
constraint PK_Productos primary key (idProducto_pr,idNegocio_pr),
constraint FK_productos_negocios foreign key (idNegocio_pr) references negocios (idNegocio_n),
constraint FK_productos_secciones foreign key (idSeccion_pr) references secciones (idSeccion_sec),
)
go


create table proveedores
(
idProveedor_prov int identity(1,1) not null,
idNegocio_prov int not null,
nombre_prov varchar(30) not null,
razonSocial_prov varchar(50) null,
telefono_prov varchar(30) not null,
mail_prov varchar(50) null,
constraint PK_Proveedores primary key (idProveedor_prov,idNegocio_prov),
constraint FK_prov_negocios foreign key (idNegocio_prov) references negocios (idNegocio_n)
)
go

create table productosXproveedores
(
idProveedor_pXp int not null,
idProducto_pXp int not null,
idNegocio_pXp int not null,
constraint PK_productosXproveedores primary key (idProveedor_pXp,idProducto_pXp),
constraint FK_pXp_proveedores foreign key (idProveedor_pXp,idNegocio_pXp) references proveedores(idProveedor_prov,idNegocio_prov),
constraint FK_pXp_productos foreign key (idProducto_pXp,idNegocio_pXp) references productos(idProducto_pr,idNegocio_pr),
)
go

