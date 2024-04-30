USE [CATALOGO_WEB_DB]
GO

/****** Object:  Table [dbo].[USERS]    Script Date: 30/4/2024 12:27:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[USERS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[pass] [varchar](20) NOT NULL,
	[nombre] [varchar](50) NULL,
	[apellido] [varchar](50) NULL,
	[urlImagenPerfil] [varchar](500) NULL,
	[admin] [bit] NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[USERS] ADD  DEFAULT ((0)) FOR [admin]
GO

