

CREATE TABLE [dbo].[Partner](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[mj] [char](1) NOT NULL,
	[vezeteknev] [nvarchar](30) NOT NULL,
	[keresztnev] [nvarchar](30) NULL,
 CONSTRAINT [PK_Partner] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Partner] ADD  CONSTRAINT [DF_Partner_mj]  DEFAULT ('M') FOR [mj]
GO

ALTER TABLE [dbo].[Partner]  WITH CHECK ADD  CONSTRAINT [CK_Partner_MJ] CHECK  (([mj]='M' OR [mj]='J'))
GO
