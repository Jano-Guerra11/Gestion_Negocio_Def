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
idUsuario_us int not null,
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
idProducto_pr int not null,
idNegocio_pr int not null,
nombre_pr varchar(30) not null,
idSeccion_pr int not null,
descripcion_pr varchar(100) null,
precio_pr money not null,
stock_pr int not null,
activo_pr bit not null,
 urlIMagen_pr varchar(50) null
constraint PK_Productos primary key (idProducto_pr,idNegocio_pr),
constraint FK_productos_negocios foreign key (idNegocio_pr) references negocios (idNegocio_n),
constraint FK_productos_secciones foreign key (idSeccion_pr) references secciones (idSeccion_sec) ON DELETE SET NULL,
)
go


create table proveedores
(
idProveedor_prov int not null,
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



create table permisos
(
idPermiso_Per int identity(1,1) not null,
NombrePermiso_Per varchar(30) not null
constraint PK_PERMISOS primary key (idPermiso_Per),
)
go

create table permisosXusuarios
(
idUsuario_PerXus int not null,
idPermiso_PerXus int not null,
TienePermiso_PerXus bit not null,
constraint PK_PERXUS primary key (idUsuario_PerXus,idPermiso_PerXus),
constraint FK_USUARIOS_PERXUS foreign key (idUsuario_PerXus) references usuarios (idUsuario_Us),
constraint FK_PERMISOS_PERXUS foreign key (idPermiso_PerXus) references permisos (idPermiso_Per)
)
go

use Gestion_de_Negocio
go

create table rolesXpermisos
(
idRol_rXp int not null,
idPermiso_rXp int not null,
tienePermiso_rXp int null,
constraint PK_RolesXPermisos primary key (idRol_rXp,idPermiso_rXp),
constraint FK_RxP_Roles foreign key (idRol_rXp) references roles (idRol_r),
constraint FL_RxP_Permisos foreign key (idPermiso_rXp) references permisos (idPermiso_Per)
)
go

create table productosXnegocios
(
idNegocio_prXneg int not null,
idProducto_prXneg int not null,
constraint PK_productosXnegocios primary key (idNegocio_prXneg,idProducto_prXneg),
constraint FK_prXneg_Negocios foreign key (idNegocio_prXneg) references negocios (idNegocio_n),
constraint FK_prXneg_Productos foreign key (idProducto_prXneg) references productos (idProducto_pr)
)
go


/*--- DATOS INICIALES PREDETERMINADOS -----*/	
insert into roles(nombre_r)
values('Administrador')
go

insert into usuarios(nombre_us,contrasenia_us,idRol_us,IdUsuario_us)
values('admin','admin',1,1)
go

insert into permisos(NombrePermiso_Per)
values
('Productos'),
('Inventario'),
('Ventas'),
('Reportes'),
('Administracion')
go

insert into permisosXusuarios(idUsuario_PerXus,idPermiso_PerXus,TienePermiso_PerXus)
values
(1,1,'true'),
(1,2,'true'),
(1,3,'true'),
(1,4,'true'),
(1,5,'true')
go

insert into negocios(nombre_n)
values('negocio')
go

insert into negociosXusuarios(idUsuario_nXu,idNegocio_nXu)
values(1,1)
go

insert into rolesXpermisos(idRol_rXp,idPermiso_rXp,tienePermiso_rXp)
values
(1,1,'true'),
(1,2,'true'),
(1,3,'true'),
(1,4,'true'),
(1,5,'true')
go