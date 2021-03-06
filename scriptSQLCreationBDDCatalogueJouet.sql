USE [nomBDD]
GO
/****** Object:  Table [dbo].[trancheAge]    Script Date: 04/17/2016 22:43:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[trancheAge](
	[code] [int] NOT NULL,
	[ageMin] [int] NULL,
	[ageMax] [int] NULL,
 CONSTRAINT [PK_trancheAge] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[jouet]    Script Date: 04/17/2016 22:43:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[jouet](
	[numero] [int] NOT NULL,
	[libelle] [nvarchar](20) NULL,
	[idCategorie] [int] NOT NULL,
	[idTrancheAge] [int] NOT NULL,
 CONSTRAINT [PK_jouet] PRIMARY KEY CLUSTERED 
(
	[numero] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[enfant]    Script Date: 04/17/2016 22:43:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[enfant](
	[id] [int] NOT NULL,
	[nom] [nchar](20) NULL,
	[prenom] [nchar](20) NULL,
	[age] [int] NULL,
	[idParent] [int] NOT NULL,
	[idJouet] [int] NULL,
 CONSTRAINT [PK_enfant] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[employe]    Script Date: 04/17/2016 22:43:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employe](
	[id] [int] NULL,
	[login] [nchar](10) NOT NULL,
	[mdp] [nchar](10) NULL,
	[nom] [nchar](20) NULL,
	[prenom] [nchar](20) NULL,
	[admin] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[categorie]    Script Date: 04/17/2016 22:43:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categorie](
	[code] [int] NOT NULL,
	[libelle] [nvarchar](10) NULL,
 CONSTRAINT [PK_categorie] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
