SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Partner](
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
 CONSTRAINT [PK_Partner] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [PostaCim](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
	[Tipus] [nvarchar](1) NOT NULL,
	[Orszag] [nvarchar](2) NULL,
	[Irsz] [nvarchar](15) NULL,
	[Helyseg] [nvarchar](30) NULL,
	[Sor1] [nvarchar](30) NULL,
	[Sor2] [nvarchar](30) NULL,
	[fiPartner] [int] NOT NULL,
 CONSTRAINT [PK_PostaCim] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [PostaCim]  WITH CHECK ADD  CONSTRAINT [FK_PostaCim_Partner_fiPartner] FOREIGN KEY([fiPartner])
REFERENCES [Partner] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [PostaCim] CHECK CONSTRAINT [FK_PostaCim_Partner_fiPartner]
GO
