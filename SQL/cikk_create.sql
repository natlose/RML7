CREATE SCHEMA [Cikk]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Cikk].[AlCsoport](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[rv] [timestamp] NOT NULL,
	[fi_FoCsoport] [int] NOT NULL,
	[nev] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_AlCsoport] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Cikk].[Cikk](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[rv] [timestamp] NOT NULL,
	[fi_AlCsoport] [int] NULL,
	[cikkszam] [varchar](50) NOT NULL,
	[nev] [nvarchar](50) NOT NULL,
	[gyartoi_cikkszam] [varchar](50) NULL,
	[megys] [nvarchar](50) NOT NULL,
	[angol_nev] [nvarchar](50) NULL,
 CONSTRAINT [PK_Cikk] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Cikk].[FoCsoport](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[rv] [timestamp] NOT NULL,
	[nev] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_FoCsoport] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [Cikk].[AlCsoport]  WITH CHECK ADD  CONSTRAINT [FK_AlCsoport_FoCsoport] FOREIGN KEY([fi_FoCsoport])
REFERENCES [Cikk].[FoCsoport] ([id])
GO
ALTER TABLE [Cikk].[AlCsoport] CHECK CONSTRAINT [FK_AlCsoport_FoCsoport]
GO
ALTER TABLE [Cikk].[Cikk]  WITH CHECK ADD  CONSTRAINT [FK_Cikk_AlCsoport] FOREIGN KEY([fi_AlCsoport])
REFERENCES [Cikk].[AlCsoport] ([id])
GO
ALTER TABLE [Cikk].[Cikk] CHECK CONSTRAINT [FK_Cikk_AlCsoport]
GO
