CREATE SCHEMA [Partner]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Partner].[Irszam](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
	[orszagkod] [char](2) NOT NULL,
	[irszam] [nchar](8) NOT NULL,
	[helyseg] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Irszam] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Partner].[Orszag](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[rowversion] [timestamp] NOT NULL,
	[iso] [char](2) NOT NULL,
	[nev] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Orszag] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Partner].[Partner](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
	[MJ] [nvarchar](1) NOT NULL,
	[MVezeteknev] [nvarchar](30) NULL,
	[MKeresztnev] [nvarchar](30) NULL,
	[JRovidnev] [nvarchar](30) NULL,
	[JCegjegyzekszam] [nvarchar](30) NULL,
	[JAdoszam] [nvarchar](30) NULL,
	[JOrszag] [nvarchar](2) NULL,
	[Telefon] [nvarchar](20) NULL,
	[Mobil] [nvarchar](20) NULL,
	[Email] [nvarchar](50) NULL,
	[Nev]  AS (case [MJ] when 'M' then (isnull([MVezeteknev],'')+' ')+isnull([MKeresztnev],'') when 'J' then isnull([JRovidnev],'')  end),
 CONSTRAINT [PK_dbo.Partner] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Partner].[PostaCim](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
	[Tipus] [nvarchar](1) NOT NULL,
	[Orszag] [nvarchar](2) NULL,
	[Irsz] [nvarchar](15) NULL,
	[Helyseg] [nvarchar](30) NULL,
	[Sor1] [nvarchar](30) NULL,
	[Sor2] [nvarchar](30) NULL,
	[fiPartner] [int] NOT NULL,
 CONSTRAINT [PK_dbo.PostaCim] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Orszag_iso] ON [Partner].[Orszag]
(
	[iso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_fiPartner] ON [Partner].[PostaCim]
(
	[fiPartner] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [Partner].[PostaCim]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PostaCim_dbo.Partner_fiPartner] FOREIGN KEY([fiPartner])
REFERENCES [Partner].[Partner] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [Partner].[PostaCim] CHECK CONSTRAINT [FK_dbo.PostaCim_dbo.Partner_fiPartner]
GO
