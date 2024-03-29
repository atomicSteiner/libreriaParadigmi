USE [master]
GO
/****** Object:  Database [Libreria]    Script Date: 16/03/2024 17:28:31 ******/
CREATE DATABASE [Libreria]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Libreria', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Libreria.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Libreria_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Libreria_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Libreria] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Libreria].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Libreria] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Libreria] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Libreria] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Libreria] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Libreria] SET ARITHABORT OFF 
GO
ALTER DATABASE [Libreria] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Libreria] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Libreria] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Libreria] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Libreria] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Libreria] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Libreria] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Libreria] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Libreria] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Libreria] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Libreria] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Libreria] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Libreria] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Libreria] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Libreria] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Libreria] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Libreria] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Libreria] SET RECOVERY FULL 
GO
ALTER DATABASE [Libreria] SET  MULTI_USER 
GO
ALTER DATABASE [Libreria] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Libreria] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Libreria] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Libreria] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Libreria] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Libreria] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Libreria', N'ON'
GO
ALTER DATABASE [Libreria] SET QUERY_STORE = ON
GO
ALTER DATABASE [Libreria] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Libreria]
GO
/****** Object:  User [admin]    Script Date: 16/03/2024 17:28:32 ******/
CREATE USER [admin] FOR LOGIN [admin] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [admin]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 16/03/2024 17:28:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [nchar](100) NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CategoriaLibro]    Script Date: 16/03/2024 17:28:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoriaLibro](
	[categoriaid] [int] NOT NULL,
	[libroid] [int] NOT NULL,
 CONSTRAINT [PK_LibroCategoria] PRIMARY KEY CLUSTERED 
(
	[categoriaid] ASC,
	[libroid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Libro]    Script Date: 16/03/2024 17:28:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Libro](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [nchar](100) NULL,
	[autore] [nchar](100) NULL,
	[editore] [nchar](100) NULL,
	[dataPubblicazione] [datetime] NULL,
 CONSTRAINT [PK_Libro] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utente]    Script Date: 16/03/2024 17:28:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utente](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [nchar](100) NULL,
	[cognome] [nchar](100) NULL,
	[email] [nchar](100) NULL,
	[password] [nchar](100) NULL,
 CONSTRAINT [PK_Utente] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CategoriaLibro]  WITH CHECK ADD  CONSTRAINT [FK_CategoriaLibro_Libro] FOREIGN KEY([libroid])
REFERENCES [dbo].[Libro] ([id])
GO
ALTER TABLE [dbo].[CategoriaLibro] CHECK CONSTRAINT [FK_CategoriaLibro_Libro]
GO
ALTER TABLE [dbo].[CategoriaLibro]  WITH CHECK ADD  CONSTRAINT [FK_LibroCategoria_Categoria] FOREIGN KEY([libroid])
REFERENCES [dbo].[Libro] ([id])
GO
ALTER TABLE [dbo].[CategoriaLibro] CHECK CONSTRAINT [FK_LibroCategoria_Categoria]
GO
USE [master]
GO
ALTER DATABASE [Libreria] SET  READ_WRITE 
GO
