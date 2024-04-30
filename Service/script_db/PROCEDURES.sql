


USE [CATALOGO_WEB_DB]
GO

/****** Object:  StoredProcedure [dbo].[insertarNuevo]    Script Date: 30/4/2024 12:40:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[insertarNuevo]
@email varchar(50),
@pass varchar (50)
as
insert into USERS (email, pass, admin) output inserted.Id values (@email, @pass, 0)
GO


USE [CATALOGO_WEB_DB]
GO

/****** Object:  StoredProcedure [dbo].[storedModificarArticulo]    Script Date: 30/4/2024 12:41:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[storedModificarArticulo]
@id int,
@codigo varchar(50),
@nombre varchar(50),
@descripcion varchar(150),
@idMarca int,
@idCategoria int,
@imagenUrl varchar(1000),
@precio money
as
update ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, 
ImagenUrl = @imagenUrl, IdMarca = @idMarca, IdCategoria = @idCategoria, Precio = @precio
where Id = @id
GO

USE [CATALOGO_WEB_DB]
GO

/****** Object:  StoredProcedure [dbo].[storedListar]    Script Date: 30/4/2024 12:41:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[storedListar] as
select A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, ImagenUrl, Precio, A.IdMarca, A.IdCategoria 
from ARTICULOS A, MARCAS M, CATEGORIAS C 
where M.Id = A.IdMarca and C.Id = A.IdCategoria
GO

USE [CATALOGO_WEB_DB]
GO

/****** Object:  StoredProcedure [dbo].[storedAltaArticulo]    Script Date: 30/4/2024 12:41:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[storedAltaArticulo]
@codigo varchar(50),
@nombre varchar(50),
@descripcion varchar(150),
@idMarca int,
@idCategoria int,
@imagenUrl varchar(1000),
@precio money  
as
insert into ARTICULOS values (@codigo, @nombre, @descripcion, @idMarca, @idCategoria, @imagenUrl, @precio)
GO




