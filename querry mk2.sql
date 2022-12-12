USE [master]
GO
/****** Object:  Database [ProjetoR]    Script Date: 05/12/2022 15:20:00 ******/
CREATE DATABASE [ProjetoR]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProjetoR', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ProjetoR.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProjetoR_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ProjetoR_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ProjetoR] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProjetoR].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProjetoR] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProjetoR] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProjetoR] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProjetoR] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProjetoR] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProjetoR] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProjetoR] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProjetoR] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProjetoR] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProjetoR] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProjetoR] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProjetoR] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProjetoR] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProjetoR] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProjetoR] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProjetoR] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProjetoR] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProjetoR] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProjetoR] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProjetoR] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProjetoR] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProjetoR] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProjetoR] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ProjetoR] SET  MULTI_USER 
GO
ALTER DATABASE [ProjetoR] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProjetoR] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProjetoR] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProjetoR] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProjetoR] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ProjetoR] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ProjetoR] SET QUERY_STORE = OFF
GO
USE [ProjetoR]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 05/12/2022 15:20:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[Descricao] [nvarchar](500) NOT NULL,
	[Imediato] [bit] NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 05/12/2022 15:20:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MesaId] [int] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 05/12/2022 15:20:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[Nome] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[Nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Menu] SET (LOCK_ESCALATION = AUTO)
GO
/****** Object:  Table [dbo].[MenuItem]    Script Date: 05/12/2022 15:20:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MenuNome] [nvarchar](50) NOT NULL,
	[ProdutoId] [int] NOT NULL,
 CONSTRAINT [PK_MenuItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mesa]    Script Date: 05/12/2022 15:20:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mesa](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ocupada] [bit] NOT NULL,
 CONSTRAINT [PK_Mesa] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedido]    Script Date: 05/12/2022 15:20:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClienteId] [int] NOT NULL,
	[PrecoProdutos] [numeric](6, 2) NOT NULL,
	[Emissao] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PedidoItem]    Script Date: 05/12/2022 15:20:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PedidoItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PedidoId] [int] NOT NULL,
	[ProdutoId] [int] NOT NULL,
	[Observacoes] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_PedidoItem_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Produto]    Script Date: 05/12/2022 15:20:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[Descricao] [nvarchar](500) NOT NULL,
	[Categoria] [int] NOT NULL,
	[Preco] [decimal](6, 2) NOT NULL,
 CONSTRAINT [PK_Produto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categoria] ON 
GO
INSERT [dbo].[Categoria] ([Id], [Nome], [Descricao], [Imediato]) VALUES (1, N'Refrigerantes', N'Bebidas não alcoólicas gaseificadas', 1)
GO
INSERT [dbo].[Categoria] ([Id], [Nome], [Descricao], [Imediato]) VALUES (2, N'Saladas', N'Verduras e leguminosas', 0)
GO
INSERT [dbo].[Categoria] ([Id], [Nome], [Descricao], [Imediato]) VALUES (19, N'Carnes', N'Carnes em geral', 0)
GO
SET IDENTITY_INSERT [dbo].[Categoria] OFF
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 
GO
INSERT [dbo].[Cliente] ([Id], [MesaId]) VALUES (47, 1)
GO
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
INSERT [dbo].[Menu] ([Nome]) VALUES (N'Menu Completo')
GO
SET IDENTITY_INSERT [dbo].[MenuItem] ON 
GO
INSERT [dbo].[MenuItem] ([Id], [MenuNome], [ProdutoId]) VALUES (4, N'Menu Completo', 1)
GO
INSERT [dbo].[MenuItem] ([Id], [MenuNome], [ProdutoId]) VALUES (13, N'Menu Completo', 10)
GO
INSERT [dbo].[MenuItem] ([Id], [MenuNome], [ProdutoId]) VALUES (14, N'Menu Completo', 2)
GO
INSERT [dbo].[MenuItem] ([Id], [MenuNome], [ProdutoId]) VALUES (15, N'Menu Completo', 8)
GO
INSERT [dbo].[MenuItem] ([Id], [MenuNome], [ProdutoId]) VALUES (18, N'Menu Completo', 9)
GO
INSERT [dbo].[MenuItem] ([Id], [MenuNome], [ProdutoId]) VALUES (19, N'Menu Completo', 16)
GO
SET IDENTITY_INSERT [dbo].[MenuItem] OFF
GO
SET IDENTITY_INSERT [dbo].[Mesa] ON 
GO
INSERT [dbo].[Mesa] ([Id], [Ocupada]) VALUES (1, 1)
GO
INSERT [dbo].[Mesa] ([Id], [Ocupada]) VALUES (2, 0)
GO
INSERT [dbo].[Mesa] ([Id], [Ocupada]) VALUES (3, 0)
GO
INSERT [dbo].[Mesa] ([Id], [Ocupada]) VALUES (4, 0)
GO
INSERT [dbo].[Mesa] ([Id], [Ocupada]) VALUES (5, 0)
GO
INSERT [dbo].[Mesa] ([Id], [Ocupada]) VALUES (6, 0)
GO
INSERT [dbo].[Mesa] ([Id], [Ocupada]) VALUES (7, 0)
GO
INSERT [dbo].[Mesa] ([Id], [Ocupada]) VALUES (8, 0)
GO
INSERT [dbo].[Mesa] ([Id], [Ocupada]) VALUES (9, 0)
GO
INSERT [dbo].[Mesa] ([Id], [Ocupada]) VALUES (10, 0)
GO
INSERT [dbo].[Mesa] ([Id], [Ocupada]) VALUES (11, 0)
GO
INSERT [dbo].[Mesa] ([Id], [Ocupada]) VALUES (12, 0)
GO
SET IDENTITY_INSERT [dbo].[Mesa] OFF
GO
SET IDENTITY_INSERT [dbo].[Pedido] ON 
GO
INSERT [dbo].[Pedido] ([Id], [ClienteId], [PrecoProdutos], [Emissao], [Status]) VALUES (37, 47, CAST(14.98 AS Numeric(6, 2)), CAST(N'2022-12-03T13:49:34.863' AS DateTime), 0)
GO
SET IDENTITY_INSERT [dbo].[Pedido] OFF
GO
SET IDENTITY_INSERT [dbo].[PedidoItem] ON 
GO
INSERT [dbo].[PedidoItem] ([Id], [PedidoId], [ProdutoId], [Observacoes]) VALUES (58, 37, 1, N'Sem observações')
GO
INSERT [dbo].[PedidoItem] ([Id], [PedidoId], [ProdutoId], [Observacoes]) VALUES (59, 37, 9, N'Sem observações')
GO
SET IDENTITY_INSERT [dbo].[PedidoItem] OFF
GO
SET IDENTITY_INSERT [dbo].[Produto] ON 
GO
INSERT [dbo].[Produto] ([Id], [Nome], [Descricao], [Categoria], [Preco]) VALUES (1, N'Guaraná Antartica 350ml', N'Refrigerante de guaraná em latinha', 1, CAST(6.99 AS Decimal(6, 2)))
GO
INSERT [dbo].[Produto] ([Id], [Nome], [Descricao], [Categoria], [Preco]) VALUES (2, N'Salada de legumes', N'Cenoura, batata inglesa, vagem, azeitona e temperos', 2, CAST(6.99 AS Decimal(6, 2)))
GO
INSERT [dbo].[Produto] ([Id], [Nome], [Descricao], [Categoria], [Preco]) VALUES (8, N'Torre de Carne', N'Nome é intuitivo', 19, CAST(79.99 AS Decimal(6, 2)))
GO
INSERT [dbo].[Produto] ([Id], [Nome], [Descricao], [Categoria], [Preco]) VALUES (9, N'Coca-Cola 350ml', N'Refrigerante de cola em latinha', 1, CAST(7.99 AS Decimal(6, 2)))
GO
INSERT [dbo].[Produto] ([Id], [Nome], [Descricao], [Categoria], [Preco]) VALUES (10, N'Amendoa', N'Amendoa poxa', 2, CAST(11.99 AS Decimal(6, 2)))
GO
INSERT [dbo].[Produto] ([Id], [Nome], [Descricao], [Categoria], [Preco]) VALUES (16, N'Sprite 300ml', N'Refrigerante de ??? em latinha', 1, CAST(5.99 AS Decimal(6, 2)))
GO
SET IDENTITY_INSERT [dbo].[Produto] OFF
GO
USE [master]
GO
ALTER DATABASE [ProjetoR] SET  READ_WRITE 
GO
