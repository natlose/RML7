CREATE SCHEMA [Keszlet]
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
	[fi_mozgas] [int] NOT NULL,
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
ALTER TABLE [Keszlet].[Karton]  WITH CHECK ADD  CONSTRAINT [FK_Karton_Polc] FOREIGN KEY([fi_Polc])
REFERENCES [Keszlet].[Polc] ([id])
GO
ALTER TABLE [Keszlet].[Karton] CHECK CONSTRAINT [FK_Karton_Polc]
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
