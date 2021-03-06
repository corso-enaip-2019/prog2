/* Script creazione tabelle + Inserzione dati. */

USE [CS2019_BenNic]
GO

/****** Object:  Table [dbo].[x10Authors]    Script Date: 19/07/2019 16:57:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[x10Authors](
	[IDAuthor] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](24) NOT NULL,
 CONSTRAINT [PK_x10Authors] PRIMARY KEY CLUSTERED 
(
	[IDAuthor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[x10Books]    Script Date: 19/07/2019 16:57:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[x10Books](
	[IDBook] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](24) NOT NULL
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[x10BooksAuthors]    Script Date: 19/07/2019 16:57:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[x10BooksAuthors](
	[IDBook] [int] NOT NULL,
	[IDAuthor] [int] NOT NULL,
 CONSTRAINT [PK_x10BooksAuthors] PRIMARY KEY CLUSTERED 
(
	[IDBook] ASC,
	[IDAuthor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[x10Authors] ON 
GO
INSERT [dbo].[x10Authors] ([IDAuthor], [FullName]) VALUES (1, N'deLuca')
GO
INSERT [dbo].[x10Authors] ([IDAuthor], [FullName]) VALUES (2, N'Baricco')
GO
INSERT [dbo].[x10Authors] ([IDAuthor], [FullName]) VALUES (3, N'VanRoy')
GO
INSERT [dbo].[x10Authors] ([IDAuthor], [FullName]) VALUES (4, N'Haridi')
GO
SET IDENTITY_INSERT [dbo].[x10Authors] OFF
GO
SET IDENTITY_INSERT [dbo].[x10Books] ON 
GO
INSERT [dbo].[x10Books] ([IDBook], [Title]) VALUES (1, N'Oceano Mare')
GO
INSERT [dbo].[x10Books] ([IDBook], [Title]) VALUES (2, N'Monte di Dio')
GO
INSERT [dbo].[x10Books] ([IDBook], [Title]) VALUES (3, N'Iliade (Baricco)')
GO
INSERT [dbo].[x10Books] ([IDBook], [Title]) VALUES (4, N'Computer programming')
GO
SET IDENTITY_INSERT [dbo].[x10Books] OFF
GO

INSERT [dbo].[x10BooksAuthors] ([IDBook], [IDAuthor]) VALUES (1, 2)
GO
INSERT [dbo].[x10BooksAuthors] ([IDBook], [IDAuthor]) VALUES (2, 1)
GO
INSERT [dbo].[x10BooksAuthors] ([IDBook], [IDAuthor]) VALUES (3, 2)
GO
INSERT [dbo].[x10BooksAuthors] ([IDBook], [IDAuthor]) VALUES (4, 3)
GO
INSERT [dbo].[x10BooksAuthors] ([IDBook], [IDAuthor]) VALUES (4, 4)
GO

ALTER TABLE [dbo].[x10BooksAuthors]  WITH CHECK ADD  CONSTRAINT [FK_x10BooksAuthors_x10BooksAuthors] FOREIGN KEY([IDBook], [IDAuthor])
REFERENCES [dbo].[x10BooksAuthors] ([IDBook], [IDAuthor])
GO
ALTER TABLE [dbo].[x10BooksAuthors] CHECK CONSTRAINT [FK_x10BooksAuthors_x10BooksAuthors]
GO
ALTER TABLE [dbo].[x10BooksAuthors]  WITH CHECK ADD  CONSTRAINT [FK_x10BooksAuthors_x10BooksAuthors1] FOREIGN KEY([IDBook], [IDAuthor])
REFERENCES [dbo].[x10BooksAuthors] ([IDBook], [IDAuthor])
GO

ALTER TABLE [dbo].[x10BooksAuthors] CHECK CONSTRAINT [FK_x10BooksAuthors_x10BooksAuthors1]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contiene Autori.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'x10Authors'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contiene Libri.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'x10Books'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contiene il collegamento fra i Libre ed i loro Autori (un libro può avre più autori) e gl''Autori con i Libri da loro scritti (un autore può scrivere più libri); tabella per la RELAZIONE-MOLTI-A-MOLTI.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'x10BooksAuthors'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Author writes Book.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'x10BooksAuthors', @level2type=N'CONSTRAINT',@level2name=N'FK_x10BooksAuthors_x10BooksAuthors'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Book is written by Author.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'x10BooksAuthors', @level2type=N'CONSTRAINT',@level2name=N'FK_x10BooksAuthors_x10BooksAuthors1'
GO
