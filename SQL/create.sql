CREATE SCHEMA [Cikk]
GO
CREATE SCHEMA [Keszlet]
GO
CREATE SCHEMA [Mozgas]
GO
CREATE SCHEMA [Partner]
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
	[megys] [nvarchar](50) NOT NULL,
	[gyartoi_cikkszam] [varchar](50) NULL,
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
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Keszlet].[Karton](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[rv] [timestamp] NOT NULL,
	[fi_Polc] [int] NOT NULL,
	[fi_Cikk] [int] NOT NULL,
	[kelt] [datetime] NOT NULL,
	[meny] [decimal](11, 2) NOT NULL,
	[mozgasnem] [varchar](10) NOT NULL,
	[fi_Mozgas] [int] NOT NULL,
 CONSTRAINT [PK_Karton] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Keszlet].[Keszlet](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[rv] [timestamp] NOT NULL,
	[fi_Polc] [int] NOT NULL,
	[fi_Cikk] [int] NOT NULL,
	[meny] [decimal](11, 2) NOT NULL,
 CONSTRAINT [PK_Keszlet] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Keszlet].[Polc](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[rv] [timestamp] NOT NULL,
	[fi_Raktar] [int] NOT NULL,
	[kod] [varchar](15) NOT NULL,
	[megjegyzes] [nvarchar](50) NULL,
 CONSTRAINT [PK_Polc] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Keszlet].[Raktar](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[rv] [timestamp] NOT NULL,
	[nev] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Raktar] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Mozgas].[MozgasFej](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[rv] [timestamp] NOT NULL,
	[piszkozat] [char](1) NOT NULL,
	[mozgasnem] [varchar](10) NOT NULL,
	[irany] [smallint] NOT NULL,
	[kelt] [datetime] NULL,
	[sorszam] [varchar](15) NULL,
	[fi_Partner] [int] NULL,
	[fi_Ktgh] [int] NULL,
 CONSTRAINT [PK_MozgasFej] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Mozgas].[MozgasTetel](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[rv] [timestamp] NOT NULL,
	[fi_MozgasFej] [int] NOT NULL,
	[bsrsz] [smallint] NOT NULL,
	[fi_Cikk] [int] NOT NULL,
	[meny] [decimal](11, 2) NOT NULL,
	[egysar] [decimal](11, 2) NULL,
 CONSTRAINT [PK__MozgasTetel] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

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
CREATE TABLE [Partner].[Ktgh](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[rv] [timestamp] NOT NULL,
	[nev] [nvarchar](30) NOT NULL,
	[megjegyzes] [nvarchar](50) NULL,
 CONSTRAINT [PK_Ktgh] PRIMARY KEY CLUSTERED 
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
CREATE NONCLUSTERED INDEX [IX_Karton_Cikk_Kelt] ON [Keszlet].[Karton]
(
	[fi_Cikk] ASC,
	[kelt] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Keszlet_Polc_Cikk] ON [Keszlet].[Keszlet]
(
	[fi_Polc] ASC,
	[fi_Cikk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Polc_Kod] ON [Keszlet].[Polc]
(
	[fi_Raktar] ASC,
	[kod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_MozgasTetel_Fej_Bsrsz] ON [Mozgas].[MozgasTetel]
(
	[fi_MozgasFej] ASC,
	[bsrsz] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
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
ALTER TABLE [Keszlet].[Karton]  WITH CHECK ADD  CONSTRAINT [FK_Karton_Cikk] FOREIGN KEY([fi_Cikk])
REFERENCES [Cikk].[Cikk] ([id])
GO
ALTER TABLE [Keszlet].[Karton] CHECK CONSTRAINT [FK_Karton_Cikk]
GO
ALTER TABLE [Keszlet].[Karton]  WITH CHECK ADD  CONSTRAINT [FK_Karton_Polc] FOREIGN KEY([fi_Polc])
REFERENCES [Keszlet].[Polc] ([id])
GO
ALTER TABLE [Keszlet].[Karton] CHECK CONSTRAINT [FK_Karton_Polc]
GO
ALTER TABLE [Keszlet].[Keszlet]  WITH CHECK ADD  CONSTRAINT [FK_Keszlet_Cikk] FOREIGN KEY([fi_Cikk])
REFERENCES [Cikk].[Cikk] ([id])
GO
ALTER TABLE [Keszlet].[Keszlet] CHECK CONSTRAINT [FK_Keszlet_Cikk]
GO
ALTER TABLE [Keszlet].[Keszlet]  WITH CHECK ADD  CONSTRAINT [FK_Keszlet_Polc] FOREIGN KEY([fi_Polc])
REFERENCES [Keszlet].[Polc] ([id])
GO
ALTER TABLE [Keszlet].[Keszlet] CHECK CONSTRAINT [FK_Keszlet_Polc]
GO
ALTER TABLE [Keszlet].[Polc]  WITH CHECK ADD  CONSTRAINT [FK_Polc_Raktar] FOREIGN KEY([fi_Raktar])
REFERENCES [Keszlet].[Raktar] ([id])
GO
ALTER TABLE [Keszlet].[Polc] CHECK CONSTRAINT [FK_Polc_Raktar]
GO
ALTER TABLE [Mozgas].[MozgasFej]  WITH CHECK ADD  CONSTRAINT [FK_MozgasFej_Ktgh] FOREIGN KEY([fi_Ktgh])
REFERENCES [Partner].[Ktgh] ([id])
GO
ALTER TABLE [Mozgas].[MozgasFej] CHECK CONSTRAINT [FK_MozgasFej_Ktgh]
GO
ALTER TABLE [Mozgas].[MozgasFej]  WITH CHECK ADD  CONSTRAINT [FK_MozgasFej_Partner] FOREIGN KEY([fi_Partner])
REFERENCES [Partner].[Partner] ([Id])
GO
ALTER TABLE [Mozgas].[MozgasFej] CHECK CONSTRAINT [FK_MozgasFej_Partner]
GO
ALTER TABLE [Mozgas].[MozgasTetel]  WITH CHECK ADD  CONSTRAINT [FK_MozgasTetel_Cikk] FOREIGN KEY([fi_Cikk])
REFERENCES [Cikk].[Cikk] ([id])
GO
ALTER TABLE [Mozgas].[MozgasTetel] CHECK CONSTRAINT [FK_MozgasTetel_Cikk]
GO
ALTER TABLE [Mozgas].[MozgasTetel]  WITH CHECK ADD  CONSTRAINT [FK_MozgasTetel_MozgasFej] FOREIGN KEY([fi_MozgasFej])
REFERENCES [Mozgas].[MozgasFej] ([id])
GO
ALTER TABLE [Mozgas].[MozgasTetel] CHECK CONSTRAINT [FK_MozgasTetel_MozgasFej]
GO
ALTER TABLE [Partner].[PostaCim]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PostaCim_dbo.Partner_fiPartner] FOREIGN KEY([fiPartner])
REFERENCES [Partner].[Partner] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [Partner].[PostaCim] CHECK CONSTRAINT [FK_dbo.PostaCim_dbo.Partner_fiPartner]
GO
ALTER TABLE [Mozgas].[MozgasFej]  WITH CHECK ADD  CONSTRAINT [CK_MozgasFej_Irany] CHECK  (([Irany]=(-1) OR [Irany]=(1)))
GO
ALTER TABLE [Mozgas].[MozgasFej] CHECK CONSTRAINT [CK_MozgasFej_Irany]
GO
ALTER TABLE [Mozgas].[MozgasFej]  WITH CHECK ADD  CONSTRAINT [CK_MozgasFej_Mozgasnem] CHECK  (([mozgasnem]='BE' OR [mozgasnem]='KI' OR [mozgasnem]='ATH' OR [mozgasnem]='HT' OR [mozgasnem]='SELEJT'))
GO
ALTER TABLE [Mozgas].[MozgasFej] CHECK CONSTRAINT [CK_MozgasFej_Mozgasnem]
GO
ALTER TABLE [Mozgas].[MozgasFej]  WITH CHECK ADD  CONSTRAINT [CK_MozgasFej_Piszkozat] CHECK  (([piszkozat]='I' OR [piszkozat]='N'))
GO
ALTER TABLE [Mozgas].[MozgasFej] CHECK CONSTRAINT [CK_MozgasFej_Piszkozat]
GO
ALTER TABLE [Mozgas].[MozgasFej]  WITH CHECK ADD  CONSTRAINT [CK_MozgasFej_Sorszam] CHECK  (([piszkozat]='I' AND [sorszam] IS NULL OR [piszkozat]='N' AND [sorszam] IS NOT NULL))
GO
ALTER TABLE [Mozgas].[MozgasFej] CHECK CONSTRAINT [CK_MozgasFej_Sorszam]
GO
