USE [master]
GO
/****** Object:  Database [LeMarchant_DB]    Script Date: 06/11/2026 12:45:39 a. m. ******/
CREATE DATABASE [LeMarchant_DB]
GO
ALTER DATABASE [LeMarchant_DB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LeMarchant_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LeMarchant_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LeMarchant_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LeMarchant_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LeMarchant_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LeMarchant_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [LeMarchant_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LeMarchant_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LeMarchant_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LeMarchant_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LeMarchant_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LeMarchant_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LeMarchant_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LeMarchant_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LeMarchant_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LeMarchant_DB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [LeMarchant_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LeMarchant_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LeMarchant_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LeMarchant_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LeMarchant_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LeMarchant_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LeMarchant_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LeMarchant_DB] SET RECOVERY FULL 
GO
ALTER DATABASE [LeMarchant_DB] SET  MULTI_USER 
GO
ALTER DATABASE [LeMarchant_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LeMarchant_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LeMarchant_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LeMarchant_DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LeMarchant_DB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LeMarchant_DB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'LeMarchant_DB', N'ON'
GO
ALTER DATABASE [LeMarchant_DB] SET QUERY_STORE = ON
GO
ALTER DATABASE [LeMarchant_DB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [LeMarchant_DB]
GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 06/11/2026 12:45:39 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bitacora](
	[Id_Evento] [int] IDENTITY(1,1) NOT NULL,
	[Login] [varchar](50) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Modulo] [varchar](50) NOT NULL,
	[Evento] [varchar](100) NOT NULL,
	[Criticidad] [int] NOT NULL,
	[DVH] [varchar](64) NOT NULL,
 CONSTRAINT [PK_Bitacora] PRIMARY KEY CLUSTERED 
(
	[Id_Evento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BitacoraCambiosCliente]    Script Date: 06/11/2026 12:45:39 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BitacoraCambiosCliente](
	[idCambio] [int] IDENTITY(1,1) NOT NULL,
	[idCliente] [int] NOT NULL,
	[dni] [varchar](8) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[telefono] [varchar](20) NOT NULL,
	[fechaInscripcion] [date] NOT NULL,
	[idNivel] [int] NOT NULL,
	[fechaCambio] [datetime] NOT NULL,
	[operacion] [varchar](10) NOT NULL,
	[usuario] [varchar](50) NOT NULL,
	[activo] [bit] NOT NULL,
 CONSTRAINT [PK_BitacoraCambiosCliente] PRIMARY KEY CLUSTERED 
(
	[idCambio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Canje]    Script Date: 06/11/2026 12:45:39 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Canje](
	[idCanje] [int] IDENTITY(1,1) NOT NULL,
	[nroCanje] [varchar](20) NOT NULL,
	[idCliente] [int] NOT NULL,
	[idPremio] [int] NOT NULL,
	[puntosRequeridos] [int] NOT NULL,
	[valorReferencia] [decimal](12, 2) NOT NULL,
	[fechaSolicitud] [datetime] NOT NULL,
	[estado] [varchar](12) NOT NULL,
	[dniVendedor] [varchar](20) NOT NULL,
	[dniSupervisor] [varchar](20) NULL,
	[motivoResolucion] [varchar](200) NULL,
	[fechaResolucion] [datetime] NULL,
	[fechaEntrega] [datetime] NULL,
	[dniAnulacion] [varchar](20) NULL,
	[motivoAnulacion] [varchar](200) NULL,
	[fechaAnulacion] [datetime] NULL,
	[DVH] [varchar](64) NOT NULL,
 CONSTRAINT [PK_Canje] PRIMARY KEY CLUSTERED 
(
	[idCanje] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 06/11/2026 12:45:39 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[idCategoria] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[multiplicador] [decimal](4, 2) NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[idCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 06/11/2026 12:45:39 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[idCliente] [int] IDENTITY(1,1) NOT NULL,
	[dni] [varchar](8) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[telefono] [varchar](20) NOT NULL,
	[fechaInscripcion] [date] NOT NULL,
	[idNivel] [int] NOT NULL,
	[DVH] [varchar](64) NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[idCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ControlDVV]    Script Date: 06/11/2026 12:45:39 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ControlDVV](
	[NombreTabla] [varchar](50) NOT NULL,
	[ColumnaNombre] [varchar](50) NOT NULL,
	[DVV] [varchar](64) NOT NULL,
 CONSTRAINT [PK_Control_Digitos] PRIMARY KEY CLUSTERED 
(
	[NombreTabla] ASC,
	[ColumnaNombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleCanje]    Script Date: 06/11/2026 12:45:39 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleCanje](
	[idDetalleCanje] [int] IDENTITY(1,1) NOT NULL,
	[idCanje] [int] NOT NULL,
	[idLote] [int] NOT NULL,
	[puntosDescontados] [int] NOT NULL,
	[DVH] [varchar](64) NOT NULL,
 CONSTRAINT [PK_DetalleCanje] PRIMARY KEY CLUSTERED 
(
	[idDetalleCanje] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleVenta]    Script Date: 06/11/2026 12:45:39 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleVenta](
	[idDetalle] [int] IDENTITY(1,1) NOT NULL,
	[idVenta] [int] NOT NULL,
	[idProducto] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[precioUnitario] [decimal](12, 2) NOT NULL,
	[subtotal] [decimal](12, 2) NOT NULL,
	[puntosCalculados] [int] NOT NULL,
	[DVH] [varchar](64) NOT NULL,
 CONSTRAINT [PK_DetalleVenta] PRIMARY KEY CLUSTERED 
(
	[idDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Familia]    Script Date: 06/11/2026 12:45:39 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Familia](
	[Nombre] [varchar](50) NOT NULL,
	[DVH] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Familia] PRIMARY KEY CLUSTERED 
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Familia_Familia]    Script Date: 06/11/2026 12:45:39 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Familia_Familia](
	[NombrePadre] [varchar](50) NOT NULL,
	[NombreHijo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Familia_Familia] PRIMARY KEY CLUSTERED 
(
	[NombrePadre] ASC,
	[NombreHijo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Familia_PermisoSimple]    Script Date: 06/11/2026 12:45:39 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Familia_PermisoSimple](
	[NombreFamilia] [varchar](50) NOT NULL,
	[NombrePermiso] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Familia_PermisoSimple] PRIMARY KEY CLUSTERED 
(
	[NombreFamilia] ASC,
	[NombrePermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Idioma]    Script Date: 06/11/2026 12:45:39 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Idioma](
	[UserName] [varchar](50) NOT NULL,
	[CodigoIdioma] [varchar](5) NOT NULL,
	[DVH] [varchar](64) NOT NULL,
 CONSTRAINT [PK_IdiomaUsuario] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LotePuntos]    Script Date: 06/11/2026 12:45:39 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LotePuntos](
	[idLote] [int] IDENTITY(1,1) NOT NULL,
	[idCliente] [int] NOT NULL,
	[idVenta] [int] NULL,
	[idReclamo] [int] NULL,
	[puntosOriginales] [int] NOT NULL,
	[puntosDisponibles] [int] NOT NULL,
	[fechaAcreditacion] [date] NOT NULL,
	[fechaVencimiento] [date] NOT NULL,
	[origen] [varchar](10) NOT NULL,
	[DVH] [varchar](64) NOT NULL,
 CONSTRAINT [PK_LotePuntos] PRIMARY KEY CLUSTERED 
(
	[idLote] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nivel]    Script Date: 06/11/2026 12:45:39 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nivel](
	[idNivel] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](20) NOT NULL,
	[puntosMinimos] [int] NOT NULL,
	[multiplicador] [decimal](4, 2) NOT NULL,
 CONSTRAINT [PK_Nivel] PRIMARY KEY CLUSTERED 
(
	[idNivel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Perfil]    Script Date: 06/11/2026 12:45:39 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Perfil](
	[Nombre] [varchar](50) NOT NULL,
	[DVH] [varchar](64) NOT NULL,
 CONSTRAINT [PK_Perfil] PRIMARY KEY CLUSTERED 
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Perfil_Familia]    Script Date: 06/11/2026 12:45:39 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Perfil_Familia](
	[NombrePerfil] [varchar](50) NOT NULL,
	[NombreFamilia] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Perfil_Familia] PRIMARY KEY CLUSTERED 
(
	[NombrePerfil] ASC,
	[NombreFamilia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Perfil_PermisoSimple]    Script Date: 06/11/2026 12:45:39 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Perfil_PermisoSimple](
	[NombrePerfil] [varchar](50) NOT NULL,
	[NombrePermiso] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Perfil_PermisoSimple] PRIMARY KEY CLUSTERED 
(
	[NombrePerfil] ASC,
	[NombrePermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PermisoSimple]    Script Date: 06/11/2026 12:45:39 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PermisoSimple](
	[Nombre] [varchar](50) NOT NULL,
	[DVH] [varchar](64) NOT NULL,
 CONSTRAINT [PK_PermisoSimple] PRIMARY KEY CLUSTERED 
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Premio]    Script Date: 06/11/2026 12:45:39 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Premio](
	[idPremio] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[descripcion] [varchar](200) NOT NULL,
	[puntosRequeridos] [int] NOT NULL,
	[stock] [int] NOT NULL,
	[valorReferencia] [decimal](12, 2) NOT NULL,
 CONSTRAINT [PK_Premio] PRIMARY KEY CLUSTERED 
(
	[idPremio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 06/11/2026 12:45:39 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[idProducto] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[precio] [decimal](12, 2) NOT NULL,
	[idCategoria] [int] NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[idProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProgramaPuntos]    Script Date: 06/11/2026 12:45:39 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProgramaPuntos](
	[idPrograma] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[montoPorPunto] [decimal](12, 2) NOT NULL,
	[mesesVencimiento] [int] NOT NULL,
	[plazoReclamoDias] [int] NOT NULL,
	[vigenciaDesde] [date] NOT NULL,
	[umbralAutorizacion] [decimal](12, 2) NOT NULL,
	[plazoAnulacionDias] [int] NOT NULL,
 CONSTRAINT [PK_ProgramaPuntos] PRIMARY KEY CLUSTERED 
(
	[idPrograma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reclamo]    Script Date: 06/11/2026 12:45:39 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reclamo](
	[idReclamo] [int] IDENTITY(1,1) NOT NULL,
	[idCliente] [int] NOT NULL,
	[idVenta] [int] NOT NULL,
	[fechaReclamo] [datetime] NOT NULL,
	[puntosReclamados] [int] NOT NULL,
	[motivo] [varchar](200) NOT NULL,
	[estado] [varchar](10) NOT NULL,
	[dniVendedor] [varchar](20) NOT NULL,
	[dniSupervisor] [varchar](20) NULL,
	[motivoResolucion] [varchar](200) NULL,
	[fechaResolucion] [datetime] NULL,
	[DVH] [varchar](64) NOT NULL,
 CONSTRAINT [PK_Reclamo] PRIMARY KEY CLUSTERED 
(
	[idReclamo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 06/11/2026 12:45:39 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[DNI] [varchar](20) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](100) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Bloqueado] [bit] NOT NULL,
	[Activo] [bit] NOT NULL,
	[Rol] [varchar](50) NOT NULL,
	[Intentos] [int] NOT NULL,
	[DVH] [varchar](64) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[DNI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Venta]    Script Date: 06/11/2026 12:45:39 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venta](
	[idVenta] [int] IDENTITY(1,1) NOT NULL,
	[nroComprobante] [varchar](20) NOT NULL,
	[fecha] [datetime] NOT NULL,
	[idCliente] [int] NULL,
	[dniVendedor] [varchar](20) NOT NULL,
	[total] [decimal](12, 2) NOT NULL,
	[puntosAcreditados] [int] NOT NULL,
	[DVH] [varchar](64) NOT NULL,
 CONSTRAINT [PK_Venta] PRIMARY KEY CLUSTERED 
(
	[idVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Bitacora] ON 

INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (170, N'Maria12', CAST(N'2026-07-02T16:27:36.047' AS DateTime), N'Idioma', N'Se guardo el idioma es', 5, N'8e3008a67bd6f2b3ff0e86d221bd759c185ce071b56139d4de1dd40374e93577')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (171, N'Maria12', CAST(N'2026-07-02T16:28:24.337' AS DateTime), N'Usuarios', N'Login exitoso', 1, N'd5fef960128bf2b1abb9a6040c613065389e4f7e14015c5eb089b61a0c9c7c23')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (172, N'Maria12', CAST(N'2026-07-02T16:29:58.090' AS DateTime), N'Idioma', N'Se guardo el idioma es', 5, N'a8538c40b00f5f035ba175fe99debefd97dea5cb0226c607ef361c8976db42a4')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (173, N'Maria12', CAST(N'2026-07-02T16:30:04.720' AS DateTime), N'Usuarios', N'Login exitoso', 1, N'dc906d41a0eb29c02ef53e9fa66eace915a2ca42240dd4ef5d065491fc9fc059')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (174, N'Maria12', CAST(N'2026-07-02T16:33:35.380' AS DateTime), N'Usuarios', N'Login exitoso', 1, N'94858fc1fb71dcb6c276f16448c5227fe13f99d09ed6016c7975589a5257cbaf')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (175, N'Maria12', CAST(N'2026-07-02T16:34:44.673' AS DateTime), N'Usuarios', N'Login exitoso', 1, N'4303fe886baa7dc17423b40b12dfb1e874c4c2fab7a68296ff82c20fc6bbb4d1')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (176, N'Maria12', CAST(N'2026-07-02T16:34:55.077' AS DateTime), N'DigitoVerificador', N'Recalculo de DVV y DVH realizado correctamente', 1, N'37a40b689f28aede2c62223ef6ad751318e36cc4b4cba2a7bad77574dd93c4f3')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (177, N'pepe', CAST(N'2026-07-02T17:39:52.697' AS DateTime), N'Usuarios', N'Login exitoso', 1, N'fe88c2eb4a721265ba77e664055f1cc4b72e0d9daf8e2e2bfa84dcfeb6d4f5b2')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (178, N'pepe', CAST(N'2026-07-02T19:01:06.957' AS DateTime), N'Usuarios', N'Login exitoso', 1, N'efebe8515e5130e70757d41ec7475ab2e214519de816ea0561d8f01c3df4986a')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (179, N'pepe', CAST(N'2026-07-02T20:15:15.810' AS DateTime), N'Usuarios', N'Crear usuario exitoso', 1, N'0acf64e9e3fa400068ffb250abaedc95c8ae82f89008fc82bb8264867611f362')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (180, N'pepe', CAST(N'2026-07-02T20:15:28.310' AS DateTime), N'Usuarios', N'Eliminar/Activar usuario exitoso', 1, N'8033f5863d5ace9cf11b3e5f23cbcec865925a8aca6fccaadd05f68f1f493a0d')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (181, N'pepe', CAST(N'2026-07-02T20:15:32.430' AS DateTime), N'Usuarios', N'Eliminar/Activar usuario exitoso', 1, N'3cfa7c9f6d9e0d7daec215460cf527398e3125a28c43bd94d25e4333035659f9')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (182, N'pepe', CAST(N'2026-07-03T04:16:43.010' AS DateTime), N'Usuarios', N'Crear usuario exitoso', 1, N'3913688a0a87aeb046bc7312fc335a6105902cec19f43ee898869a4b0a1c77e0')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (183, N'pepe', CAST(N'2026-07-03T04:17:39.733' AS DateTime), N'Usuarios', N'Login exitoso', 1, N'fa83d943a39fe6cf59ec197868ba8f5a57971a46b367f968c22a31e5a0cdb1a2')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (184, N'pepe', CAST(N'2026-07-03T04:26:44.520' AS DateTime), N'Usuarios', N'Login exitoso', 1, N'32cf519b55979429c44100bad1c2979913cbb8154cad3a11b9f6c7c84c998968')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (185, N'pepe', CAST(N'2026-07-03T04:27:37.117' AS DateTime), N'Perfiles', N'Asignación exitosa de Permiso Simple ''Activar Desactivar Usuario'' a la raíz ''ModuloUsuarios''', 1, N'3b76aea2232a10e6db688e2f510e1e4eeeafeda173c95acc8d85998e9817f098')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (186, N'pepe', CAST(N'2026-07-03T04:28:01.443' AS DateTime), N'Perfiles', N'Asignación exitosa de Permiso Simple ''Bloquear Usuario'' a la raíz ''ModuloUsuarios''', 1, N'a34e6af59c8645b3e69bc3053a713e2c6d8d5ac89415dfc3e8b9cc9109b4ac18')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (187, N'pepe', CAST(N'2026-07-03T04:28:34.430' AS DateTime), N'Perfiles', N'Asignación exitosa de Permiso Simple ''Desbloquear Usuario'' a la raíz ''ModuloUsuarios''', 1, N'f4ce84eddac8d8aea49130107c6dab4d8a58dfe229528918319103d756af67e0')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (188, N'pepe', CAST(N'2026-07-03T04:29:07.470' AS DateTime), N'Usuarios', N'Crear usuario exitoso', 1, N'6388eb8305c9a87947c3f1db4991d3c15fd6d3c8d5781f4bd23f53d27e5b3cbf')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (189, N'pepe', CAST(N'2026-07-03T04:29:49.720' AS DateTime), N'Perfiles', N'Eliminar contenedor jerárquico: flia1', 1, N'4f38e98fa9eedaee060b8fb7cdd5b78d35f91dab29bb45126cfce96c076b156e')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (190, N'pepe', CAST(N'2026-07-03T04:29:54.167' AS DateTime), N'Perfiles', N'Crear familia: flia1', 1, N'5d9aed0868fb8ac296c7fe68da6841546507dc018fb3292d271619807d4831fe')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (191, N'pepe', CAST(N'2026-07-03T04:33:09.363' AS DateTime), N'Usuarios', N'Login exitoso', 1, N'ee73afdf58574d2cd978cc0b913d587368c47404d3a1e1a9d91cca65c1f1b12e')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (192, N'pepe', CAST(N'2026-07-03T04:33:54.610' AS DateTime), N'Usuarios', N'Modificar Usuario exitoso', 1, N'e3f1e47a64c8b2af7c6a2b2d48fa7c1214ef914cf57863de6e59d2612249f9e6')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (193, N'pepe', CAST(N'2026-07-03T04:37:08.357' AS DateTime), N'Usuarios', N'Login exitoso', 1, N'619a75ae3b83b720e99b7a7312d21c6f42134daa0b827f1319fea0b3d144cc64')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (194, N'pepe', CAST(N'2026-07-03T04:38:43.390' AS DateTime), N'Usuarios', N'Login exitoso', 1, N'7ddb164262fff523bb257169654484ecd85805ffd13e99c08423d1d103db3402')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (195, N'pepe', CAST(N'2026-07-03T04:39:03.010' AS DateTime), N'Usuarios', N'Modificar Usuario exitoso', 1, N'3bafc5b837f22afaad15f79c26c3eeb0c4b3a3a1306b578274bf2be750334d39')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (196, N'pepe', CAST(N'2026-07-03T04:39:08.880' AS DateTime), N'Usuarios', N'Eliminar Usuario (Baja lógica) exitoso', 1, N'df35cd67903c980cad76f8256ba615ca1cd506c02ea07e55cf5a29e400da0b87')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (197, N'pepe', CAST(N'2026-07-03T04:39:22.793' AS DateTime), N'Usuarios', N'Activar Usuario (Baja lógica) exitoso', 1, N'329047355eaa08b0e655704c4ad860c262521908c5abc07e4abf9c763c5029f5')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (198, N'pepe', CAST(N'2026-07-03T04:39:28.713' AS DateTime), N'Usuarios', N'Desbloquear Usuario exitoso', 1, N'4abe6d56173904adad5a8390ade7ed9f40d9ef1e76088024d5ac15cd6353a92f')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (199, N'pepe', CAST(N'2026-07-03T04:39:56.567' AS DateTime), N'Perfiles', N'Asignación exitosa de Permiso Simple ''btnEliminarProducto'' a la raíz ''flia1''', 1, N'3a26bb1895cc92ca4cceb8a040f72941dca3992ef1f7a25d0bd30791531ceeb6')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (200, N'pepe', CAST(N'2026-07-03T04:40:13.420' AS DateTime), N'Perfiles', N'Mitigación de redundancia: Remoción del permiso ''btnEliminarProducto'' en subnodo ''flia1''', 2, N'63878cc0f7b8aef7d777d56e3123444562dbc3a75453858d3b76d4c33f709096')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (201, N'pepe', CAST(N'2026-07-03T04:40:13.447' AS DateTime), N'Perfiles', N'Asignación exitosa de Subfamilia ''flia2'' a la raíz ''flia1''', 1, N'71a6b902ab78c30266ef24a8c4f2d4144823fb35ebd5f0b00a6fe242a7009f88')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (202, N'pepe', CAST(N'2026-07-03T04:51:03.893' AS DateTime), N'Usuarios', N'Login exitoso', 1, N'2bd1f92d7ee35b4d120e95649da15d63c64a397e39bacc82a6c31c17ff3006d4')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (203, N'pepe', CAST(N'2026-07-03T04:58:27.423' AS DateTime), N'Usuarios', N'Eliminar/Activar usuario exitoso', 1, N'42172ec0c16305caa2b5e71ed80d9a4ae7759fcd98c6d3db68f1a71ff5f546ba')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (204, N'pepe', CAST(N'2026-09-24T10:56:28.787' AS DateTime), N'Usuarios', N'Login exitoso', 1, N'fd0221f825c916f89a606aeb9b044896814e0fb70c1f84406025127d6a1e9eb3')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (205, N'pepe', CAST(N'2026-09-24T10:57:43.717' AS DateTime), N'Usuarios', N'Login exitoso', 1, N'd85c7ec00fdb8262ea4a788954deb2099911d83a2700bc8508a9e8f379c316fa')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (206, N'pepe', CAST(N'2026-09-24T11:13:39.253' AS DateTime), N'Usuarios', N'Login exitoso', 1, N'5760bfc183cbd126d19d11abe35562e9caa2867f34b020a210355608f1cd9ae9')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (207, N'pepe', CAST(N'2026-09-24T11:16:00.717' AS DateTime), N'Usuarios', N'Login exitoso', 1, N'dd244862bb689173dede457132f8c6d51dbd0a6dbd1a59d202de267f4306db6d')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (208, N'pepe', CAST(N'2026-09-24T11:16:29.840' AS DateTime), N'Perfiles', N'Crear familia: FAMILIA', 1, N'96037dce5134ae9068f1d25acaaf16a2da35d8c08037ed8aacd428a6523efdab')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (209, N'pepe', CAST(N'2026-09-24T11:16:36.333' AS DateTime), N'Perfiles', N'Asignación exitosa de Subfamilia ''AccionesCriticas'' a la raíz ''FAMILIA''', 1, N'4f8950e49e4d0483195d90afee28bdf93341be4931b707b8edf8b03e6c9d3fd5')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (210, N'pepe', CAST(N'2026-09-24T11:16:39.113' AS DateTime), N'Perfiles', N'Asignación exitosa de Permiso Simple ''Bloquear Usuario'' a la raíz ''FAMILIA''', 1, N'4763cdac07de6b593049cc9c458f2407200ac656a0b56f7abcc1b667a4b1a2b5')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (211, N'pepe', CAST(N'2026-09-24T11:16:46.950' AS DateTime), N'Perfiles', N'Eliminar contenedor jerárquico: FAMILIA', 1, N'1507d4e541bac71eb7f0a34843616d25aadf2c6506d35bbd8ee208ec4c2486be')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (212, N'pepe', CAST(N'2026-09-24T17:09:30.857' AS DateTime), N'Usuarios', N'Login exitoso', 1, N'6b3b2abd51c26c18f3db757e3fff93c6741116f30032875415e8cc95fc261753')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (213, N'pepe', CAST(N'2026-09-24T17:16:06.197' AS DateTime), N'Usuarios', N'Login exitoso', 1, N'e229307d06834197d7a1039b752efcc3641bdc8031640259dd99c75743af3fd1')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (214, N'pepe', CAST(N'2026-09-24T17:16:50.430' AS DateTime), N'Usuarios', N'Login exitoso', 1, N'72ae35031021500e19e5ef415409a49ed453d367c0c1fc02450fabc95ad35667')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (215, N'pepe', CAST(N'2026-09-24T17:17:07.370' AS DateTime), N'Usuarios', N'Login exitoso', 1, N'108572bb6188795d495d0c468dd867a2afadf3fa46531eaa8f3431013d9d1639')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (216, N'pepe', CAST(N'2026-09-24T17:20:25.337' AS DateTime), N'DigitoVerificador', N'Recalculo de DVV y DVH realizado correctamente', 1, N'744bf060aa549ecb2d881ac00730d2f44dde71c33729082b8c55dc436e1a10fe')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (217, N'pepe', CAST(N'2026-09-24T17:20:29.443' AS DateTime), N'Usuarios', N'Login exitoso', 1, N'8b2faea68c6598aa2083fba7e4d5fc80804164c867394c6c8f6a33aca57a5459')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (218, N'pepe', CAST(N'2026-09-24T17:21:18.893' AS DateTime), N'Perfiles', N'Crear familia: RFN1', 1, N'760ee4a980b1a9a03d52d80e7c5445400822b03729f1f9709c2400a77fed2528')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (219, N'pepe', CAST(N'2026-09-24T17:21:42.203' AS DateTime), N'Perfiles', N'Asignación exitosa de Permiso Simple ''Gestionar Productos'' a la raíz ''RFN1''', 1, N'66389a68bd8e5083567c337254584ec62bd707ef0077c43b8c36c00071b47388')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (220, N'pepe', CAST(N'2026-09-24T17:21:42.220' AS DateTime), N'Perfiles', N'Asignación exitosa de Permiso Simple ''Gestionar Proveedores'' a la raíz ''RFN1''', 1, N'82aa7394231ef896c31be15c1d66ed183c78eaf76bde9963e6924005f203d100')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (221, N'pepe', CAST(N'2026-09-24T17:21:42.237' AS DateTime), N'Perfiles', N'Asignación exitosa de Permiso Simple ''Registrar Compra'' a la raíz ''RFN1''', 1, N'127ea32e411a8d7e3adbfba4e33e23e354bf0b8886cc91c4733dc41495615ebc')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (222, N'pepe', CAST(N'2026-09-24T17:21:48.007' AS DateTime), N'Perfiles', N'Asignación exitosa de Subfamilia ''RFN1'' a la raíz ''Administrador''', 1, N'df8b31416d6f83e629314f536780f433329e8a8217ece290389436766f41ec03')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (223, N'pepe', CAST(N'2026-09-24T17:25:13.427' AS DateTime), N'Usuarios', N'Login exitoso', 1, N'86fbf6b21a878a169ba44f752bbd99ddd43d000ad5ce2179c84cc219dd36cb6d')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (224, N'pepe', CAST(N'2026-09-24T17:25:44.650' AS DateTime), N'Usuarios', N'Login exitoso', 1, N'081ed403274e3c6bf925e7a65f5b156e808f491c66e77814991999a2f8b0a1d1')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (225, N'pepe', CAST(N'2026-09-24T17:27:05.367' AS DateTime), N'Usuarios', N'Login exitoso', 1, N'18f104ef65b1b4a91746a41f1602005dd2eecd70d3238701be947a4cb5ee86a0')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (226, N'pepe', CAST(N'2026-09-24T17:28:18.227' AS DateTime), N'Usuarios', N'Login exitoso', 1, N'5bbc4727ed247c2d7efc090079ead3db0344a1d8f54e5464c3838376f850d403')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (227, N'pepe', CAST(N'2026-09-24T20:31:18.687' AS DateTime), N'Usuarios', N'Login exitoso', 1, N'19a6057d122788b3e71f3108ccf80adf803b3d565f6f8e8e8657792d945d2673')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (228, N'pepe', CAST(N'2026-09-24T20:58:49.853' AS DateTime), N'Usuarios', N'Login exitoso', 1, N'dec3621b387582ced5d5921c61b74b09b5f15fda707c2ec3ef50a9e956e8fa1b')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (229, N'pepe', CAST(N'2026-09-24T21:02:31.040' AS DateTime), N'Usuarios', N'Login exitoso', 1, N'38b26c1782277e0ec62216362ff992257a8869a9225acc101d3557a96a39ddbe')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (230, N'pepe', CAST(N'2026-09-24T21:03:01.490' AS DateTime), N'DigitoVerificador', N'Recalculo de DVV y DVH realizado correctamente', 1, N'705286e885155c9ed970a6168ef7dc4117ce71679270b0a7e8e12a92b40961c2')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (231, N'pepe', CAST(N'2026-09-24T21:03:04.663' AS DateTime), N'Usuarios', N'Login exitoso', 1, N'004c4fdb18f1ca946773f4a6982e94bf4416655487b0e7af23e2247dc2a2cb50')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (232, N'pepe', CAST(N'2026-09-24T21:05:08.133' AS DateTime), N'DigitoVerificador', N'Recalculo de DVV y DVH realizado correctamente', 1, N'dd0a898454e11f23cfeae2852e98ca315537ca566fe6d573a9bd0bc5fc057868')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (233, N'Maria12', CAST(N'2026-09-24T21:06:51.567' AS DateTime), N'DigitoVerificador', N'Recalculo de DVV y DVH realizado correctamente', 1, N'35823bd056e84a74aeca69993174f5447bb953d001f0117f2eb2c8bed8d090ee')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (234, N'Maria12', CAST(N'2026-09-24T21:06:58.943' AS DateTime), N'Usuarios', N'Login exitoso', 1, N'206a7bbaa63556d7e519ec9da8e23eac660024fc90d089f372ab37ccd1b2d8b4')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (235, N'Maria12', CAST(N'2026-09-24T23:55:47.607' AS DateTime), N'Usuarios', N'Login exitoso', 1, N'7b006be96dcf97f8870c60de79d94b5cc5f852135bbe38b18599eedc456a75a2')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (236, N'Maria12', CAST(N'2026-09-25T00:00:41.153' AS DateTime), N'Usuarios', N'Login exitoso', 1, N'2eb58b6d9b1697184c6a73ffa34946e186a3cd9473148dba7e57213b26d92add')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (237, N'Maria12', CAST(N'2026-09-25T00:02:08.653' AS DateTime), N'Usuarios', N'Login exitoso', 1, N'6d14ef0fb12034762f3d2614f3ccf281bb09f1dd2a1c3d368d8eefb6e2fbf588')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (238, N'Maria12', CAST(N'2026-09-25T06:42:35.893' AS DateTime), N'Usuarios', N'Login exitoso', 1, N'4edc96afb1c602364e9b45b984f1e3c11b4ca57a7470b6e76ac75a06929855f9')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (239, N'Maria12', CAST(N'2026-10-12T18:58:16.120' AS DateTime), N'Usuarios', N'Login exitoso', 1, N'0f7f56199eea8c81d7fb5590e73ba61f0e85121c031e1e87e222fa6fbb3cce5b')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (240, N'Maria12', CAST(N'2026-10-12T18:58:38.387' AS DateTime), N'Usuarios', N'Desbloquear Usuario exitoso', 1, N'e3a11728f70bac4b958e18ea7b70d3c9247fcb046709d9877d1675582345df07')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (241, N'Maria12', CAST(N'2026-10-12T18:58:51.907' AS DateTime), N'Idioma', N'Se guardo el idioma es', 5, N'aa05606a2e603984ce91a888a9bfecfa572786471c4435f91352eb8b9b78e969')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (242, N'Maria12', CAST(N'2026-10-12T18:59:14.590' AS DateTime), N'DigitoVerificador', N'Recalculo de DVV y DVH realizado correctamente', 1, N'ad2fb689b0947afc9daffc8afbcb2e6c36d20c3d89bde1c8074e8e14e80a17c1')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (243, N'Maria12', CAST(N'2026-10-12T18:59:19.277' AS DateTime), N'Usuarios', N'Login exitoso', 1, N'd47e23e5ee6812649563da3d56e179b4eb3304676b798187d6421503c91811cd')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (244, N'pepe', CAST(N'2026-10-15T16:59:15.000' AS DateTime), N'Usuarios', N'Usuario bloqueado por intentos fallidos', 3, N'e11a2d819b5216d1ac150fe1558697a24a15960eeff60d5ca97a7c1e5b307d94')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (245, N'Maria12', CAST(N'2026-10-15T17:13:42.000' AS DateTime), N'Usuarios', N'Login exitoso', 1, N'4a3237af3875d69ccc4a4bf389c16368eeded9cb40808965b90b95aa41b6f618')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (246, N'vendedor1', CAST(N'2026-10-15T17:13:55.000' AS DateTime), N'Usuarios', N'Login exitoso', 1, N'be8619a83b44d6363f7e993f218ec93616ae7f98cbd9964d4140d1293def9b04')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (247, N'Maria12', CAST(N'2026-10-15T19:25:53.000' AS DateTime), N'Usuarios', N'Login exitoso', 1, N'b729763d3cd13dd5c916524c3b91edd40d9c4e81c7981dc028b7a18436ab9e10')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (248, N'Maria12', CAST(N'2026-10-15T19:26:21.000' AS DateTime), N'Perfiles', N'Desvincular Subfamilia ''RFN1'' del contenedor ''Administrador''', 1, N'9c9092de2fc4c9fcf686d71838cab30938772da9850fb694b82f78e573058340')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (249, N'Maria12', CAST(N'2026-10-15T19:26:35.000' AS DateTime), N'Perfiles', N'Asignación exitosa de Subfamilia ''RFN1'' a la raíz ''Administrador''', 1, N'dd360f43038e7880fbd0d3d68eb59a7b99e8caa259fa1dbeac2307df83aaa662')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (250, N'Maria12', CAST(N'2026-10-15T19:30:18.000' AS DateTime), N'Usuarios', N'Login exitoso', 1, N'58127a54c68b0ece031c36fdd7fafa9db889ff1659c8b6864f887abac1e67592')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (251, N'Maria12', CAST(N'2026-10-15T19:32:28.000' AS DateTime), N'Usuarios', N'Login exitoso', 1, N'49d22877129cba454355ffa7f7d086377ab087e970baf21dcabdc21ec1d2825f')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (252, N'Maria12', CAST(N'2026-10-15T19:34:19.000' AS DateTime), N'Usuarios', N'Login exitoso', 1, N'cfb22c50b1d298d9e45db56388243136bd05cf3d2bcce4c36f46a478db1fde0f')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (253, N'Maria12', CAST(N'2026-10-15T19:35:44.000' AS DateTime), N'Usuarios', N'Login exitoso', 1, N'e7f41e45c8eb142d3d8875502f3d79b516d07d0cb532cee504d3ffeaffbdfd14')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (254, N'Maria12', CAST(N'2026-10-15T19:36:03.000' AS DateTime), N'Ventas', N'Registrar venta V-00000001 sin cliente', 1, N'1c675f25a25b4892e49bae4787e69fdbb1f54f4b7f3a7dc0b0c382564c76de68')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (255, N'Maria12', CAST(N'2026-10-15T19:37:19.000' AS DateTime), N'Clientes', N'Registrar cliente DNI 12341234', 1, N'173fc399b42b8925b26dd5cf83d69148596aecdb2ee174010b5268be3bfb026a')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (256, N'Maria12', CAST(N'2026-10-15T19:37:52.000' AS DateTime), N'Ventas', N'Registrar venta V-00000002 cliente 12341234, 821 pts', 1, N'a434c4313936ab1e4c581c216e5b58c17f03e824b2fdadebd36a9da373f3f725')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (257, N'Maria12', CAST(N'2026-10-15T19:39:28.000' AS DateTime), N'Ventas', N'Registrar venta V-00000003 cliente 12341234, 320 pts', 1, N'3c858dcda2c63a1d12dfc2cd6f5141ad1a7d3627e2d33c5b35d3b473af5326f5')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (258, N'Maria12', CAST(N'2026-10-15T19:43:21.000' AS DateTime), N'Reclamos', N'Registrar reclamo 1 venta V-00000001 cliente 12341234', 1, N'391eceb2ad1785f436dcb2e38d799400ff68e91997b7d836c5f2eb4450467ce0')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (259, N'Maria12', CAST(N'2026-10-15T19:43:45.000' AS DateTime), N'Reclamos', N'Aprobar reclamo 1 (199 pts)', 2, N'5789f84a18d199b1f18f5d9ec0806d6c1536f82a7b53422e17e5cbe6bd486800')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (260, N'Maria12', CAST(N'2026-10-15T19:45:07.000' AS DateTime), N'Ventas', N'Registrar venta V-00000004 sin cliente', 1, N'2e62492fd95e759d99958cdf786bea8524440ecc0a7173c80242edadc6616413')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (261, N'Maria12', CAST(N'2026-10-15T19:46:15.000' AS DateTime), N'Reclamos', N'Registrar reclamo 2 venta V-00000004 cliente 12341234', 1, N'f5c353f51f279086ad33f35510b897d10fc65778706591cb34528ea20563de0b')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (262, N'Maria12', CAST(N'2026-10-15T19:46:28.000' AS DateTime), N'Reclamos', N'Aprobar reclamo 2 (199 pts)', 2, N'20adefcf24c26c3e4980c707e9805d831424c09542d218681d5e2eb7477f4ece')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (263, N'Maria12', CAST(N'2026-10-16T00:07:10.000' AS DateTime), N'Usuarios', N'Login exitoso', 1, N'28a1ecec442e9de642c9da841c177947a97b87dc1ec46e28c07995b415aca938')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (264, N'Maria12', CAST(N'2026-11-05T18:12:59.000' AS DateTime), N'Usuarios', N'Login exitoso', 1, N'3ae83c10199ca8ecb9f0556dcd216ab1cd5029edc03c7a8d9ff0e4773efdad01')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (265, N'Maria12', CAST(N'2026-11-05T18:20:15.000' AS DateTime), N'Usuarios', N'Login exitoso', 1, N'86a49879eb9e53b816cc2048dcccb706d8ed4d48392a753f10a6eaaef25f63c5')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (266, N'Maria12', CAST(N'2026-11-05T18:26:48.000' AS DateTime), N'Usuarios', N'Login exitoso', 1, N'd44a2ff6d141fa265751d11444c79d425839bf67773ada9da3a7488e99bc715c')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (267, N'Maria12', CAST(N'2026-11-05T23:21:34.000' AS DateTime), N'Usuarios', N'Login exitoso', 1, N'a30401fdf8e13aafc39a4138047a263ca5c51ad30ff235d8e88125d38b55bee7')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (268, N'Maria12', CAST(N'2026-11-05T23:21:58.000' AS DateTime), N'Usuarios', N'Eliminar Usuario (Baja lógica) exitoso', 1, N'd71af9f78816532553c0e6df1d6db7413d1a19513e0a94c8459baf355fd19931')
GO
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (269, N'Maria12', CAST(N'2026-11-05T23:22:07.000' AS DateTime), N'Usuarios', N'Activar Usuario (Baja lógica) exitoso', 1, N'ce9f8256d8ffd88d08e06f9a3d50cf6f59a683ed4625fed57bb76e29af0b8962')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (270, N'Maria12', CAST(N'2026-11-05T23:22:11.000' AS DateTime), N'Usuarios', N'Desbloquear Usuario exitoso', 1, N'1298d4dbd16809cbc141aebe717abc85631d5e0ae0fbd9bd1f9b89a36125089e')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (271, N'pepe', CAST(N'2026-11-05T23:22:45.000' AS DateTime), N'Usuarios', N'Login fallido', 2, N'4cbc62fe038849adfe5bbb5c51a37d484d7986db9ad2ff80b5565d2f2d7af9c0')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (272, N'pepe', CAST(N'2026-11-05T23:22:54.000' AS DateTime), N'Usuarios', N'Login fallido', 2, N'45bcf452662e28c499f8c293df50914d557f44c03334b13532b3d6e125f33a98')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (273, N'Maria12', CAST(N'2026-11-05T23:23:01.000' AS DateTime), N'Usuarios', N'Login exitoso', 1, N'791609381f5abbcdcac16c93243ca0265d1325dd95855320f2eb4078a6c54006')
INSERT [dbo].[Bitacora] ([Id_Evento], [Login], [Fecha], [Modulo], [Evento], [Criticidad], [DVH]) VALUES (274, N'pepe', CAST(N'2026-11-05T23:26:19.000' AS DateTime), N'Usuarios', N'Usuario bloqueado por intentos fallidos', 3, N'd7a9241b28c391d21eeedc46f9a4c2ae98211d67a3357f7079e4c70312c8f07c')
SET IDENTITY_INSERT [dbo].[Bitacora] OFF
GO
SET IDENTITY_INSERT [dbo].[BitacoraCambiosCliente] ON 

INSERT [dbo].[BitacoraCambiosCliente] ([idCambio], [idCliente], [dni], [nombre], [apellido], [email], [telefono], [fechaInscripcion], [idNivel], [fechaCambio], [operacion], [usuario], [activo]) VALUES (1, 1, N'30111222', N'Ana', N'Gómez', N'ana.gomez@mail.com', N'11 4555-1234', CAST(N'2026-08-01' AS Date), 3, CAST(N'2026-11-05T13:27:41.923' AS DateTime), N'INSERT', N'Carga inicial', 1)
INSERT [dbo].[BitacoraCambiosCliente] ([idCambio], [idCliente], [dni], [nombre], [apellido], [email], [telefono], [fechaInscripcion], [idNivel], [fechaCambio], [operacion], [usuario], [activo]) VALUES (2, 2, N'28999888', N'Carlos', N'Pérez', N'carlos.perez@mail.com', N'11 4777-8899', CAST(N'2026-09-03' AS Date), 1, CAST(N'2026-11-05T13:27:41.923' AS DateTime), N'INSERT', N'Carga inicial', 1)
INSERT [dbo].[BitacoraCambiosCliente] ([idCambio], [idCliente], [dni], [nombre], [apellido], [email], [telefono], [fechaInscripcion], [idNivel], [fechaCambio], [operacion], [usuario], [activo]) VALUES (3, 3, N'35444555', N'Lucía', N'Fernández', N'lucia.fernandez@mail.com', N'', CAST(N'2026-10-01' AS Date), 1, CAST(N'2026-11-05T13:27:41.923' AS DateTime), N'INSERT', N'Carga inicial', 1)
INSERT [dbo].[BitacoraCambiosCliente] ([idCambio], [idCliente], [dni], [nombre], [apellido], [email], [telefono], [fechaInscripcion], [idNivel], [fechaCambio], [operacion], [usuario], [activo]) VALUES (4, 4, N'99999999', N'Juan', N'Perez', N'juanperez@gmail.com', N'2342 2123', CAST(N'2026-11-05' AS Date), 1, CAST(N'2026-11-05T18:14:06.557' AS DateTime), N'INSERT', N'Maria12', 0)
INSERT [dbo].[BitacoraCambiosCliente] ([idCambio], [idCliente], [dni], [nombre], [apellido], [email], [telefono], [fechaInscripcion], [idNivel], [fechaCambio], [operacion], [usuario], [activo]) VALUES (5, 4, N'99999999', N'Juan', N'Perez', N'juanperez@gmail.com', N'2342 2123', CAST(N'2026-11-05' AS Date), 2, CAST(N'2026-11-05T18:14:29.797' AS DateTime), N'UPDATE', N'Maria12', 0)
INSERT [dbo].[BitacoraCambiosCliente] ([idCambio], [idCliente], [dni], [nombre], [apellido], [email], [telefono], [fechaInscripcion], [idNivel], [fechaCambio], [operacion], [usuario], [activo]) VALUES (6, 4, N'99999999', N'Juan', N'Perez', N'juanperez@gmail.com', N'2342 2123', CAST(N'2026-11-05' AS Date), 3, CAST(N'2026-11-05T18:34:28.143' AS DateTime), N'UPDATE', N'Maria12', 1)
SET IDENTITY_INSERT [dbo].[BitacoraCambiosCliente] OFF
GO
SET IDENTITY_INSERT [dbo].[Canje] ON 

INSERT [dbo].[Canje] ([idCanje], [nroCanje], [idCliente], [idPremio], [puntosRequeridos], [valorReferencia], [fechaSolicitud], [estado], [dniVendedor], [dniSupervisor], [motivoResolucion], [fechaResolucion], [fechaEntrega], [dniAnulacion], [motivoAnulacion], [fechaAnulacion], [DVH]) VALUES (1, N'C-00000001', 4, 6, 2500, CAST(32000.00 AS Decimal(12, 2)), CAST(N'2026-11-05T18:34:46.000' AS DateTime), N'rechazado', N'11111111', N'11111111', N'El termo no va', CAST(N'2026-11-05T18:35:29.000' AS DateTime), NULL, NULL, NULL, NULL, N'e9535fbd31de072a5d74bb624eecd19e597cf2ade8dccf5647994affac8a7511')
INSERT [dbo].[Canje] ([idCanje], [nroCanje], [idCliente], [idPremio], [puntosRequeridos], [valorReferencia], [fechaSolicitud], [estado], [dniVendedor], [dniSupervisor], [motivoResolucion], [fechaResolucion], [fechaEntrega], [dniAnulacion], [motivoAnulacion], [fechaAnulacion], [DVH]) VALUES (2, N'C-00000002', 4, 6, 2500, CAST(32000.00 AS Decimal(12, 2)), CAST(N'2026-11-05T18:36:08.000' AS DateTime), N'anulado', N'11111111', N'11111111', NULL, CAST(N'2026-11-05T18:37:05.000' AS DateTime), CAST(N'2026-11-05T18:37:31.000' AS DateTime), N'11111111', N'Esta roto', CAST(N'2026-11-05T18:38:20.000' AS DateTime), N'9898ae1590d27121dd17af82e4049465b155cfc06bbe247504a53f254028463b')
SET IDENTITY_INSERT [dbo].[Canje] OFF
GO
SET IDENTITY_INSERT [dbo].[Categoria] ON 

INSERT [dbo].[Categoria] ([idCategoria], [nombre], [multiplicador]) VALUES (1, N'Almacén', CAST(1.00 AS Decimal(4, 2)))
INSERT [dbo].[Categoria] ([idCategoria], [nombre], [multiplicador]) VALUES (2, N'Frescos', CAST(1.25 AS Decimal(4, 2)))
INSERT [dbo].[Categoria] ([idCategoria], [nombre], [multiplicador]) VALUES (3, N'Bebidas', CAST(1.00 AS Decimal(4, 2)))
INSERT [dbo].[Categoria] ([idCategoria], [nombre], [multiplicador]) VALUES (4, N'Limpieza', CAST(0.75 AS Decimal(4, 2)))
INSERT [dbo].[Categoria] ([idCategoria], [nombre], [multiplicador]) VALUES (5, N'Perfumería', CAST(0.75 AS Decimal(4, 2)))
INSERT [dbo].[Categoria] ([idCategoria], [nombre], [multiplicador]) VALUES (6, N'Productos Le Marchant', CAST(2.00 AS Decimal(4, 2)))
INSERT [dbo].[Categoria] ([idCategoria], [nombre], [multiplicador]) VALUES (7, N'Ofertas sin puntos', CAST(0.00 AS Decimal(4, 2)))
SET IDENTITY_INSERT [dbo].[Categoria] OFF
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT [dbo].[Cliente] ([idCliente], [dni], [nombre], [apellido], [email], [telefono], [fechaInscripcion], [idNivel], [DVH]) VALUES (1, N'30111222', N'Ana', N'Gómez', N'ana.gomez@mail.com', N'11 4555-1234', CAST(N'2026-08-01' AS Date), 3, N'8a48c2b1561e848290c36210acc25e41cee15908516f30cd91526823d680a883')
INSERT [dbo].[Cliente] ([idCliente], [dni], [nombre], [apellido], [email], [telefono], [fechaInscripcion], [idNivel], [DVH]) VALUES (2, N'28999888', N'Carlos', N'Pérez', N'carlos.perez@mail.com', N'11 4777-8899', CAST(N'2026-09-03' AS Date), 1, N'96113db435bae5a40c6572c276db17fd3434680c0061574f5228ee87d239d558')
INSERT [dbo].[Cliente] ([idCliente], [dni], [nombre], [apellido], [email], [telefono], [fechaInscripcion], [idNivel], [DVH]) VALUES (3, N'35444555', N'Lucía', N'Fernández', N'lucia.fernandez@mail.com', N'', CAST(N'2026-10-01' AS Date), 1, N'11fc318ac9127213bf73119a133dcb1faaf7900e4906de60e1ceb6bb1980a508')
INSERT [dbo].[Cliente] ([idCliente], [dni], [nombre], [apellido], [email], [telefono], [fechaInscripcion], [idNivel], [DVH]) VALUES (4, N'99999999', N'Juan', N'Perez', N'juanperez@gmail.com', N'2342 2123', CAST(N'2026-11-05' AS Date), 3, N'239d330ae358c4dfbd5a4a7517796de0ab079b6350361990a8752673732957ed')
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Bitacora', N'Criticidad', N'918d9bb30502bde582cbb240a99184df2e44752d13726c5be7f6f7fcab86953b')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Bitacora', N'Evento', N'ee5539746c9e0912a9306ad74cd376c2aa92f9ecef3d1a63a7caaf97c0beba4a')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Bitacora', N'Fecha', N'642175b2d4077fcdb4c768c3f730e6ee2786a227c5c9a87d29ec8cf1205262e4')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Bitacora', N'Login', N'4e2e58f6b79c07b5f91ee12141c3e19859bed95a70392db9a2f862f22d3e2d98')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Bitacora', N'Modulo', N'3814f165ed8cc004d3ce8625004a8c8440d415a6f2347288341b798d0ae1e0c4')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Bitacora', N'TOTAL_TABLA', N'1a4340f22c87a48a8d49ce67ef9d98c51bf207439a4e8d978e232287b08195f8')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Canje', N'dniAnulacion', N'481158954a8016f91ce324d01dfffca93a39fd2a0a67f217ab38607ecae82671')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Canje', N'dniSupervisor', N'db26614af7129cec14bf2c91e6ab713930af2df652d07af9ed75ee7021219cd1')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Canje', N'dniVendedor', N'db26614af7129cec14bf2c91e6ab713930af2df652d07af9ed75ee7021219cd1')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Canje', N'estado', N'e6aee94e33b0d6cce53f482740cf906db6f5a4b225c9f7886f20e4d1d765598e')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Canje', N'fechaAnulacion', N'e926c17f037b1ae854622f9d3e827322b52d7c9f65199ad9fdac39844b346fc6')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Canje', N'fechaEntrega', N'2da3f5f04916eebd11aa1aeaad7419d8c95766e66f7a42281775496c579e0a6f')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Canje', N'fechaResolucion', N'17c9b38afa6121b75e887c09a39e2470043de358d5570e0d0809efa1b2322051')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Canje', N'fechaSolicitud', N'5baa34661f05e8b6dff9679f8d958d1719354be8287319c9f30c645ef0ef9e92')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Canje', N'idCanje', N'e1a34e2c586d69650d09f21e71d8389eb9220ab59bee9a8fc299f9003e1db273')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Canje', N'idCliente', N'5f395d07369071a505ef926527de2ac53e8c29e103dc63398315bc276224b81a')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Canje', N'idPremio', N'3cb25825a619415e255ae83eb0cd9c26684de310fb3c377ac289362e043affe7')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Canje', N'motivoAnulacion', N'856c3be4fc5b2e62126a5bb73084f2ad3a3e6d147417fff9fdf4ed471685e4e1')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Canje', N'motivoResolucion', N'dbcddc9fa60aff7527185de62ef8fcb75893f329424a01513f865607ce8f7708')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Canje', N'nroCanje', N'ea9e7bb08a3c907a7596db99b1a83a323b8f230fcf9fa89a7a6b0edee8c8d974')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Canje', N'puntosRequeridos', N'36ed7b00ead1927d9b6265fec6f471a7c38cb1d7ba16477a6e532d57779b8d93')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Canje', N'TOTAL_TABLA', N'97b315fc626ab8d9759a56d9d21c2b14ba4183761f07362592333602675955f4')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Canje', N'valorReferencia', N'40878bc1af0a8a8cc334f4746545b72c75e885a97552301d34fa60a80221af99')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Cliente', N'apellido', N'137567d04d8529a5d79cf30cd473007ff8c0020e2853be1820955f970ecc8545')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Cliente', N'dni', N'b459dbf662750a307eb692fe49cdf632abb0550800ca2d7fc3412e1d4d5252ee')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Cliente', N'email', N'e8be4ce00db23c7c58fc0ee62288fcd048c0fd65fcc9003bbef6d7ec0a7830a5')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Cliente', N'fechaInscripcion', N'675b219bba683aa1f084c5064dee681c380fb9932e15517941cf42ce57b5103a')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Cliente', N'idCliente', N'c1fb7cdb79c3d28def2a81cb6574a555ad56671a59c5e48f055580081b161b69')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Cliente', N'idNivel', N'7e2d3c57eae2f1f40484536767a254948bf151b15507837e16c46186aa9512e6')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Cliente', N'nombre', N'8ef1c81c0ddd9ead8dbe086194d26a076624159a7b4ca2f8501c3ca5a6e1b52c')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Cliente', N'telefono', N'9b93689ed31ce10ea6d532e4b96b00fa44ebee056a95ae11ca49380ee982c519')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Cliente', N'TOTAL_TABLA', N'df1a902b26dca7e33df1e13618101c222d636a30b933b0fc5b6b6e7ebcef00a4')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'DetalleCanje', N'idCanje', N'b85bf0f7330be07933314afcfc04aa8e8bb33827eb03bdf2f65ff26fd32444f5')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'DetalleCanje', N'idDetalleCanje', N'e1a34e2c586d69650d09f21e71d8389eb9220ab59bee9a8fc299f9003e1db273')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'DetalleCanje', N'idLote', N'35041ec21b0be43fcc811118982e23e71df122c6732578cd8e7e1339890a97cf')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'DetalleCanje', N'puntosDescontados', N'682712b0592a9f1cb3c928addc864036ea01b3175d075033637c5460a907e688')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'DetalleCanje', N'TOTAL_TABLA', N'91ba0c5178db9130418f38049c82e5ac0f38673d0aa139b2116650179c497e79')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'DetalleVenta', N'cantidad', N'7d682f6c72e12fc0b397e3093b809636f9b6a2774ff0d295aabc571fa7822f32')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'DetalleVenta', N'idDetalle', N'c5952091c5c734582c0eb00356640ebb4bd751f100359707ea477c3360ff854f')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'DetalleVenta', N'idProducto', N'dc66fde0bc66d125b24dcf18923b5d8b0db1ff36f6c7c3e5bb83a55aa76253bd')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'DetalleVenta', N'idVenta', N'94297514c99334a5c1cb7bbedeeed91a5af19c8fbf7fe5c5cd54d64d36d58fc7')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'DetalleVenta', N'precioUnitario', N'7b797664ff91394b648a11785d0a90fef87506ccff908773a70f70e0de15aa90')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'DetalleVenta', N'puntosCalculados', N'26feb82ce05e9f9eb39101387e086acc53ece44cdd6ab37924fa3f029c75d46f')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'DetalleVenta', N'subtotal', N'a06026e44b56812aaae99d159e047d1ff0d687e0d9022579753bfb4e463826f9')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'DetalleVenta', N'TOTAL_TABLA', N'314a448ecff249174661b66225e6e28ff00319b2afd3d331655e2dee912aa8e1')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Familia', N'Nombre', N'8ffdf6c3f85889cc504242268a89c5f145132eb267452ae0b96dd561322d6c99')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Familia', N'TOTAL_TABLA', N'c4575f399cbd5493cba01cb57995c986e6068c76da1d651238c137148c2bc256')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Idioma', N'CodigoIdioma', N'8d33c9cd3dac767daa4b8d3891b5318deaae9eaf68a65881a7071e82e2243ee2')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Idioma', N'TOTAL_TABLA', N'3c9089bf66d1b52568b88035d678bbe2ad857c4f6d0c8bdf78e5090beed1f425')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Idioma', N'UserName', N'2273ba08b91ee96fb411c352913f6a261345fb8bafc04ff8b908187095938f06')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'LotePuntos', N'fechaAcreditacion', N'4c2e0f388b61e947d19a636ec26343c5ba32c3a7c9ff575ba31c19a13c96f920')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'LotePuntos', N'fechaVencimiento', N'ab7fa6e5e4bafb86787052687d6e8e013836f7fb8ff41c3c83b8d585ead825b4')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'LotePuntos', N'idCliente', N'3eceb88b3326f744d87061b8d9639380cf309a082ec3c2d80d5965ded9a728c4')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'LotePuntos', N'idLote', N'c0dfa082246e2a2ec22f143d46901665533dde9eeb8170abd6bad6705bd96e2c')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'LotePuntos', N'idReclamo', N'e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'LotePuntos', N'idVenta', N'fd85eb093b8d91582cb36bc4410e68329c7be6ab9a3a20ac8c4043e994c4be9a')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'LotePuntos', N'origen', N'a4d321e54ee837fb80bd42fddc36f12d255d0189032ccceaccabd158d5f3d29e')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'LotePuntos', N'puntosDisponibles', N'cc077812be2bd3d87c6b141ea10129e3b55e5788acd6fa1e990543b367ce582c')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'LotePuntos', N'puntosOriginales', N'cc077812be2bd3d87c6b141ea10129e3b55e5788acd6fa1e990543b367ce582c')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'LotePuntos', N'TOTAL_TABLA', N'8141ad6ade03968e23602afdbd23bde71bdf6e111bb03cbb9fc6e7b1829ff450')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Perfil', N'Nombre', N'3c7ba6cf2628768a45011211d240ac9afeff15d8c4d5491d8f73e5e2e78e70c1')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Perfil', N'TOTAL_TABLA', N'8e52efca75839269295b8146d311094575e6963913bb9e72d8fa14fa3d13a353')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'PermisoSimple', N'Nombre', N'8d18c21a7f5e0ca56085de32ec413f22d8bbb957b55e23bdd792db425e4b3207')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'PermisoSimple', N'TOTAL_TABLA', N'67aee261b5e57e999527c010b68d0fdf742cec04dc92ab212325ffdb48fdc514')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Reclamo', N'dniSupervisor', N'e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Reclamo', N'dniVendedor', N'481158954a8016f91ce324d01dfffca93a39fd2a0a67f217ab38607ecae82671')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Reclamo', N'estado', N'fef408d8139ee964ce60ae1679ed74964034ca2fd11b15d068e2926cc67c8f99')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Reclamo', N'fechaReclamo', N'0ad1e9e73f2f4c804513270ea5d1f47f69f03f089ad15e186d779b45d8ca0f59')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Reclamo', N'fechaResolucion', N'e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Reclamo', N'idCliente', N'86e50149658661312a9e0b35558d84f6c6d3da797f552a9657fe0558ca40cdef')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Reclamo', N'idReclamo', N'eb1e33e8a81b697b75855af6bfcdbcbf7cbbde9f94962ceaec1ed8af21f5a50f')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Reclamo', N'idVenta', N'0b918943df0962bc7a1824c0555a389347b4febdc7cf9d1254406d80ce44e3f9')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Reclamo', N'motivo', N'84bcb4959adaa0dc5673adb3d99ef7c923bd891666fe8cc98389643d970ea5c1')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Reclamo', N'motivoResolucion', N'e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Reclamo', N'puntosReclamados', N'84d133d968520db52e04cb76484e442b6d86a128557f2db2ab3fd28bc2a07d90')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Reclamo', N'TOTAL_TABLA', N'5d2815b80585ec9fbfb146cbd9539c80e8aa860a7a5b52c44a3b7b8bf30b2526')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'SISTEMA', N'TOTAL_BASE_DATOS', N'dd6a624534595d8a375e56c92774e9c5a0b20aea4e5ad742c8460b4195a3e858')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Usuario', N'Activo', N'cafecf77ff58dbd439928fb2603a37290a3e2c2e7c3b1ff22d7e26bc82960a69')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Usuario', N'Apellido', N'ee992b42ba4e27a2c139b77287d5cc7aaa983569abbcef98f8ae6e7ffff23f0b')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Usuario', N'Bloqueado', N'7eb83961d9ed941d13a0b540de97687ee98c1e2db076af390386bad35eeebe99')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Usuario', N'DNI', N'3b5ba367c00820b1555ba703aa9697284097091428d74fd09547ce54a354420d')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Usuario', N'Email', N'c5505167e7e46f9a29850c5d658a3ee2caacac1019c2657504136630d7dbcb2c')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Usuario', N'Intentos', N'ca51dac19d4295b1f604d3539b2661fe1c4caed23796d0134fbc36ceec622338')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Usuario', N'Nombre', N'a52656531ee3fcf2b4bfa9268b43604a0048c9a2fcef9c44deae56e5db892212')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Usuario', N'Password', N'51ac9dd412a0b87a180a8138090eca353b9610da904d309748ecd49ebccec63c')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Usuario', N'Rol', N'9fd608ffb582fc58ed90fee67125026e85ca2fb2e5e70daf61fa84e85ceed633')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Usuario', N'TOTAL_TABLA', N'da079d2a01f2ccbd57c755136f7b7246b54a126f1186206b7ce59ccb2b1afd41')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Usuario', N'UserName', N'ae05d3f4bd20aeb533f6ecd206189563628de16463d59523dc60d1cf027086b5')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Venta', N'dniVendedor', N'ef6e8a7aec473c03c8a4505976a0626bc91518a888d289c42b651ff0d9167a00')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Venta', N'fecha', N'02760a31af93344ec990567484d489305d8cafe2984af427658633ab648534c7')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Venta', N'idCliente', N'3eceb88b3326f744d87061b8d9639380cf309a082ec3c2d80d5965ded9a728c4')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Venta', N'idVenta', N'838e63f918657c754c1dc16594cca2e33b714b9bc0ebbb4037c871f6fe0fa318')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Venta', N'nroComprobante', N'a520af8540d99c9953c6e134b112125d07c6eb9a496a8f364a0dfc811e5217a4')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Venta', N'puntosAcreditados', N'3aba2383b7b91e35d36dd690668d17f68a6fc29263a00d3393a77acda8bb3026')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Venta', N'total', N'b79d7710f2a3831095d64cbc29f3a8e2b441d7d26bce6cfbafc568b446f4af96')
INSERT [dbo].[ControlDVV] ([NombreTabla], [ColumnaNombre], [DVV]) VALUES (N'Venta', N'TOTAL_TABLA', N'c3fa5ace4084a2e9835bb06a79fcb3a7315a322520ec5f1b83aa0d71a552eeec')
GO
SET IDENTITY_INSERT [dbo].[DetalleCanje] ON 

INSERT [dbo].[DetalleCanje] ([idDetalleCanje], [idCanje], [idLote], [puntosDescontados], [DVH]) VALUES (1, 2, 7, 2202, N'f50ada7afd3115418556d28bad1f0c4482f526b4d4137ccbe70842095c46027f')
INSERT [dbo].[DetalleCanje] ([idDetalleCanje], [idCanje], [idLote], [puntosDescontados], [DVH]) VALUES (2, 2, 8, 298, N'aa78afe8cf92385bcaee939a89669aecd13815328aa1baebd0d359a7d2d18a7c')
SET IDENTITY_INSERT [dbo].[DetalleCanje] OFF
GO
SET IDENTITY_INSERT [dbo].[DetalleVenta] ON 

INSERT [dbo].[DetalleVenta] ([idDetalle], [idVenta], [idProducto], [cantidad], [precioUnitario], [subtotal], [puntosCalculados], [DVH]) VALUES (1, 1, 13, 3, CAST(9800.00 AS Decimal(12, 2)), CAST(29400.00 AS Decimal(12, 2)), 367, N'0ca97af9153fccc0eef97bbcf9ffded5eaea404d040dc6bf5d86ce8ed90a0633')
INSERT [dbo].[DetalleVenta] ([idDetalle], [idVenta], [idProducto], [cantidad], [precioUnitario], [subtotal], [puntosCalculados], [DVH]) VALUES (2, 1, 14, 2, CAST(14500.00 AS Decimal(12, 2)), CAST(29000.00 AS Decimal(12, 2)), 362, N'a2db0a270c810ff1fd97111da996ae6c9119a0aa8488449bd4b7cdd451c3982e')
INSERT [dbo].[DetalleVenta] ([idDetalle], [idVenta], [idProducto], [cantidad], [precioUnitario], [subtotal], [puntosCalculados], [DVH]) VALUES (3, 1, 23, 6, CAST(6500.00 AS Decimal(12, 2)), CAST(39000.00 AS Decimal(12, 2)), 390, N'91547c589f9b2d9dbc225f43ec5d53b50b2a73b42465f3042765c01ba54bc781')
INSERT [dbo].[DetalleVenta] ([idDetalle], [idVenta], [idProducto], [cantidad], [precioUnitario], [subtotal], [puntosCalculados], [DVH]) VALUES (4, 1, 34, 4, CAST(4900.00 AS Decimal(12, 2)), CAST(19600.00 AS Decimal(12, 2)), 392, N'1ee48fcbb068f8b652b062bdc015f89534204e70bc7d4846fa5eea5b7084d095')
INSERT [dbo].[DetalleVenta] ([idDetalle], [idVenta], [idProducto], [cantidad], [precioUnitario], [subtotal], [puntosCalculados], [DVH]) VALUES (5, 1, 1, 3, CAST(4800.00 AS Decimal(12, 2)), CAST(14400.00 AS Decimal(12, 2)), 144, N'eedec3aabbc20e9e3c1a8c87302ecd1dd586d914e9378475efdf416c43198145')
INSERT [dbo].[DetalleVenta] ([idDetalle], [idVenta], [idProducto], [cantidad], [precioUnitario], [subtotal], [puntosCalculados], [DVH]) VALUES (6, 2, 28, 4, CAST(9800.00 AS Decimal(12, 2)), CAST(39200.00 AS Decimal(12, 2)), 367, N'b305eb52c3c54d65c086d7f7ac502e4d8c5829eec952e3c802e4b25aee2618fe')
INSERT [dbo].[DetalleVenta] ([idDetalle], [idVenta], [idProducto], [cantidad], [precioUnitario], [subtotal], [puntosCalculados], [DVH]) VALUES (7, 2, 7, 4, CAST(5200.00 AS Decimal(12, 2)), CAST(20800.00 AS Decimal(12, 2)), 260, N'79b7a5fb3af883604673ac5229dcf2439d360eb5f8bbd01194ab63fb77b4a479')
INSERT [dbo].[DetalleVenta] ([idDetalle], [idVenta], [idProducto], [cantidad], [precioUnitario], [subtotal], [puntosCalculados], [DVH]) VALUES (8, 2, 35, 6, CAST(5900.00 AS Decimal(12, 2)), CAST(35400.00 AS Decimal(12, 2)), 885, N'd1cbcbc4f8ecd7b2bbcccaac81595ceed1bed5f3d4a9a1c5e75978495a0439f4')
INSERT [dbo].[DetalleVenta] ([idDetalle], [idVenta], [idProducto], [cantidad], [precioUnitario], [subtotal], [puntosCalculados], [DVH]) VALUES (9, 2, 22, 6, CAST(3300.00 AS Decimal(12, 2)), CAST(19800.00 AS Decimal(12, 2)), 247, N'613cb3c09c8ae635b5c43738876e95c016a80665e1aef3e9c0d5affe8c090742')
INSERT [dbo].[DetalleVenta] ([idDetalle], [idVenta], [idProducto], [cantidad], [precioUnitario], [subtotal], [puntosCalculados], [DVH]) VALUES (10, 2, 12, 4, CAST(3600.00 AS Decimal(12, 2)), CAST(14400.00 AS Decimal(12, 2)), 225, N'0b972f9fb7e8a0eccfb306851266aba16bce977abc87b180049427ef9d63ff87')
INSERT [dbo].[DetalleVenta] ([idDetalle], [idVenta], [idProducto], [cantidad], [precioUnitario], [subtotal], [puntosCalculados], [DVH]) VALUES (11, 2, 3, 4, CAST(1900.00 AS Decimal(12, 2)), CAST(7600.00 AS Decimal(12, 2)), 95, N'f7cac9bd6f6eca4c44d00e76b78a990cb640cac5a4b55994ef5276930d826cf3')
INSERT [dbo].[DetalleVenta] ([idDetalle], [idVenta], [idProducto], [cantidad], [precioUnitario], [subtotal], [puntosCalculados], [DVH]) VALUES (12, 3, 1, 2, CAST(4800.00 AS Decimal(12, 2)), CAST(9600.00 AS Decimal(12, 2)), 96, N'a0bed4d1bf3ac0600732953a28c15297528e2f737ef6be09ec90b9d9af2e86b4')
INSERT [dbo].[DetalleVenta] ([idDetalle], [idVenta], [idProducto], [cantidad], [precioUnitario], [subtotal], [puntosCalculados], [DVH]) VALUES (13, 3, 2, 6, CAST(1450.00 AS Decimal(12, 2)), CAST(8700.00 AS Decimal(12, 2)), 87, N'51e8129aec2373c9f81d86131652695759e4c8548a2ec53645749c9611cbd2a1')
INSERT [dbo].[DetalleVenta] ([idDetalle], [idVenta], [idProducto], [cantidad], [precioUnitario], [subtotal], [puntosCalculados], [DVH]) VALUES (14, 3, 4, 2, CAST(3900.00 AS Decimal(12, 2)), CAST(7800.00 AS Decimal(12, 2)), 78, N'fcb107ec39a3471288620da97bc5d68787e85c89ef10d5e23ded906ec437983d')
INSERT [dbo].[DetalleVenta] ([idDetalle], [idVenta], [idProducto], [cantidad], [precioUnitario], [subtotal], [puntosCalculados], [DVH]) VALUES (15, 3, 11, 3, CAST(2800.00 AS Decimal(12, 2)), CAST(8400.00 AS Decimal(12, 2)), 105, N'331050c31061435390f10404debd4f89a61632c1ed721892b147a3f9b6ec3203')
INSERT [dbo].[DetalleVenta] ([idDetalle], [idVenta], [idProducto], [cantidad], [precioUnitario], [subtotal], [puntosCalculados], [DVH]) VALUES (16, 3, 21, 6, CAST(1200.00 AS Decimal(12, 2)), CAST(7200.00 AS Decimal(12, 2)), 72, N'33a651d4fd5ec5d0fd3df51cc5b3755458d0afbe463f8a94dfb79fec9456a09d')
INSERT [dbo].[DetalleVenta] ([idDetalle], [idVenta], [idProducto], [cantidad], [precioUnitario], [subtotal], [puntosCalculados], [DVH]) VALUES (17, 3, 26, 2, CAST(2100.00 AS Decimal(12, 2)), CAST(4200.00 AS Decimal(12, 2)), 31, N'129b7f8d6bd9364cb439ce440c71f43538557857cc8ea80b4e0099ddfd9ef322')
INSERT [dbo].[DetalleVenta] ([idDetalle], [idVenta], [idProducto], [cantidad], [precioUnitario], [subtotal], [puntosCalculados], [DVH]) VALUES (18, 4, 13, 2, CAST(9800.00 AS Decimal(12, 2)), CAST(19600.00 AS Decimal(12, 2)), 306, N'58613a052f38ff08ead12a06241ab38c2dc21fc0432095bd1c83ab7da9d87a9f')
INSERT [dbo].[DetalleVenta] ([idDetalle], [idVenta], [idProducto], [cantidad], [precioUnitario], [subtotal], [puntosCalculados], [DVH]) VALUES (19, 4, 14, 2, CAST(14500.00 AS Decimal(12, 2)), CAST(29000.00 AS Decimal(12, 2)), 453, N'2b953aa093a6ce27a757cbcfd283c24efb6825ec6e8a41678d77e4da129db624')
INSERT [dbo].[DetalleVenta] ([idDetalle], [idVenta], [idProducto], [cantidad], [precioUnitario], [subtotal], [puntosCalculados], [DVH]) VALUES (20, 4, 36, 5, CAST(4200.00 AS Decimal(12, 2)), CAST(21000.00 AS Decimal(12, 2)), 525, N'f98d86874b00ddeed337d3d8f548159c3a3a4ac10b3260a1f32cd7fdd29769c1')
INSERT [dbo].[DetalleVenta] ([idDetalle], [idVenta], [idProducto], [cantidad], [precioUnitario], [subtotal], [puntosCalculados], [DVH]) VALUES (21, 4, 30, 3, CAST(4300.00 AS Decimal(12, 2)), CAST(12900.00 AS Decimal(12, 2)), 120, N'b793a6f3c5dcf93ab4f5cc7c16e52f32e084ac6b41f8a6f11459c30552935f03')
INSERT [dbo].[DetalleVenta] ([idDetalle], [idVenta], [idProducto], [cantidad], [precioUnitario], [subtotal], [puntosCalculados], [DVH]) VALUES (22, 4, 23, 4, CAST(6500.00 AS Decimal(12, 2)), CAST(26000.00 AS Decimal(12, 2)), 325, N'b0c3214ad2098d6afcdc91c61d8100611a5350978914d426a4183d211bf30478')
INSERT [dbo].[DetalleVenta] ([idDetalle], [idVenta], [idProducto], [cantidad], [precioUnitario], [subtotal], [puntosCalculados], [DVH]) VALUES (23, 4, 19, 3, CAST(3900.00 AS Decimal(12, 2)), CAST(11700.00 AS Decimal(12, 2)), 182, N'c3ec604af46a3366501f0ecafdbc39ff7684dd1d6603f0bb40ef382178aafa22')
INSERT [dbo].[DetalleVenta] ([idDetalle], [idVenta], [idProducto], [cantidad], [precioUnitario], [subtotal], [puntosCalculados], [DVH]) VALUES (24, 5, 11, 1, CAST(2800.00 AS Decimal(12, 2)), CAST(2800.00 AS Decimal(12, 2)), 35, N'cf84c056f4f73c0bf0168be89505a6209bfc545d8fcfba40537e70da233fc60b')
INSERT [dbo].[DetalleVenta] ([idDetalle], [idVenta], [idProducto], [cantidad], [precioUnitario], [subtotal], [puntosCalculados], [DVH]) VALUES (25, 5, 20, 4, CAST(1500.00 AS Decimal(12, 2)), CAST(6000.00 AS Decimal(12, 2)), 75, N'dc09833df2431f4972d159e88883dc68107117d777c975d36d00087d6726fad7')
INSERT [dbo].[DetalleVenta] ([idDetalle], [idVenta], [idProducto], [cantidad], [precioUnitario], [subtotal], [puntosCalculados], [DVH]) VALUES (26, 5, 15, 2, CAST(2200.00 AS Decimal(12, 2)), CAST(4400.00 AS Decimal(12, 2)), 55, N'6ff5245a3622899790c8b657a33b6268debdae83eb6b6623bcfbcf2ccd0d1196')
INSERT [dbo].[DetalleVenta] ([idDetalle], [idVenta], [idProducto], [cantidad], [precioUnitario], [subtotal], [puntosCalculados], [DVH]) VALUES (27, 5, 37, 1, CAST(900.00 AS Decimal(12, 2)), CAST(900.00 AS Decimal(12, 2)), 0, N'a29e505f4918f3cf86f3130c7e2824e84edeab1eac7a5e904e72f3f9b905323e')
INSERT [dbo].[DetalleVenta] ([idDetalle], [idVenta], [idProducto], [cantidad], [precioUnitario], [subtotal], [puntosCalculados], [DVH]) VALUES (28, 6, 13, 1, CAST(9800.00 AS Decimal(12, 2)), CAST(9800.00 AS Decimal(12, 2)), 122, N'a2410d6b00c033b5a862f7ab348a7936fad78f56345f53a2bd85db4dff31f43e')
INSERT [dbo].[DetalleVenta] ([idDetalle], [idVenta], [idProducto], [cantidad], [precioUnitario], [subtotal], [puntosCalculados], [DVH]) VALUES (29, 6, 34, 2, CAST(4900.00 AS Decimal(12, 2)), CAST(9800.00 AS Decimal(12, 2)), 196, N'6d1af4346171cdfaa7fc2a117506ee98991eb62931c1f45b4d9d674c888d2098')
INSERT [dbo].[DetalleVenta] ([idDetalle], [idVenta], [idProducto], [cantidad], [precioUnitario], [subtotal], [puntosCalculados], [DVH]) VALUES (30, 6, 24, 6, CAST(2900.00 AS Decimal(12, 2)), CAST(17400.00 AS Decimal(12, 2)), 174, N'3fbc0efaee6782747e2e893a31e6a67ca9b215443b573cc00d5d2f7d1943429f')
INSERT [dbo].[DetalleVenta] ([idDetalle], [idVenta], [idProducto], [cantidad], [precioUnitario], [subtotal], [puntosCalculados], [DVH]) VALUES (31, 6, 18, 3, CAST(2400.00 AS Decimal(12, 2)), CAST(7200.00 AS Decimal(12, 2)), 90, N'a3eb6f4c8344327d5b5b6c6390c09d15fd3cf5c1a620d622fcfafda4f5ab6a72')
INSERT [dbo].[DetalleVenta] ([idDetalle], [idVenta], [idProducto], [cantidad], [precioUnitario], [subtotal], [puntosCalculados], [DVH]) VALUES (32, 6, 12, 2, CAST(3600.00 AS Decimal(12, 2)), CAST(7200.00 AS Decimal(12, 2)), 90, N'06aee2cbbdd8f5fb039faa2b26349f9e545552dfc78b391d1a0ce9bed2a91449')
INSERT [dbo].[DetalleVenta] ([idDetalle], [idVenta], [idProducto], [cantidad], [precioUnitario], [subtotal], [puntosCalculados], [DVH]) VALUES (33, 7, 21, 2, CAST(1200.00 AS Decimal(12, 2)), CAST(2400.00 AS Decimal(12, 2)), 0, N'bf427d3032e54e261544336e517eb65fea9d2b4d9bb9bab1018d0a823c9b8d6b')
INSERT [dbo].[DetalleVenta] ([idDetalle], [idVenta], [idProducto], [cantidad], [precioUnitario], [subtotal], [puntosCalculados], [DVH]) VALUES (34, 7, 8, 1, CAST(1800.00 AS Decimal(12, 2)), CAST(1800.00 AS Decimal(12, 2)), 0, N'c7435e5d5e52b775e5afc6b3611285c8458730c9bf8c6baed9473a78b03bd037')
INSERT [dbo].[DetalleVenta] ([idDetalle], [idVenta], [idProducto], [cantidad], [precioUnitario], [subtotal], [puntosCalculados], [DVH]) VALUES (35, 8, 4, 2, CAST(3900.00 AS Decimal(12, 2)), CAST(7800.00 AS Decimal(12, 2)), 78, N'6584f1a72a7ec0db5b33efbe0c5435f9456602ee4970cf8c1de82c675f5c6247')
INSERT [dbo].[DetalleVenta] ([idDetalle], [idVenta], [idProducto], [cantidad], [precioUnitario], [subtotal], [puntosCalculados], [DVH]) VALUES (36, 8, 35, 18, CAST(5900.00 AS Decimal(12, 2)), CAST(106200.00 AS Decimal(12, 2)), 2124, N'5e57ec3fcc3305efc78ee5c33b9102ca03dc3825d90d49073cb07116b97e9249')
INSERT [dbo].[DetalleVenta] ([idDetalle], [idVenta], [idProducto], [cantidad], [precioUnitario], [subtotal], [puntosCalculados], [DVH]) VALUES (37, 9, 3, 1, CAST(1900.00 AS Decimal(12, 2)), CAST(1900.00 AS Decimal(12, 2)), 0, N'7ce2177f8cde97707dd77403c7dbbcb6d3f856e0bb8f72ec906bad475b0ed3cf')
INSERT [dbo].[DetalleVenta] ([idDetalle], [idVenta], [idProducto], [cantidad], [precioUnitario], [subtotal], [puntosCalculados], [DVH]) VALUES (38, 10, 34, 100, CAST(4900.00 AS Decimal(12, 2)), CAST(490000.00 AS Decimal(12, 2)), 0, N'f1e2c82b64278a9ac2cdaf9eaf2a873d01b093186f95abc186c91e16046d8007')
INSERT [dbo].[DetalleVenta] ([idDetalle], [idVenta], [idProducto], [cantidad], [precioUnitario], [subtotal], [puntosCalculados], [DVH]) VALUES (39, 10, 10, 1, CAST(2300.00 AS Decimal(12, 2)), CAST(2300.00 AS Decimal(12, 2)), 0, N'c8e6e4668cc44c0503194fedce382f6d121e3652d371af7c39e462f8640c7143')
INSERT [dbo].[DetalleVenta] ([idDetalle], [idVenta], [idProducto], [cantidad], [precioUnitario], [subtotal], [puntosCalculados], [DVH]) VALUES (40, 10, 36, 100, CAST(4200.00 AS Decimal(12, 2)), CAST(420000.00 AS Decimal(12, 2)), 0, N'04a939df768e7249f93f4b053a47e3450c38f40b4430fda7a811700c500ba38c')
INSERT [dbo].[DetalleVenta] ([idDetalle], [idVenta], [idProducto], [cantidad], [precioUnitario], [subtotal], [puntosCalculados], [DVH]) VALUES (41, 11, 36, 100, CAST(4200.00 AS Decimal(12, 2)), CAST(420000.00 AS Decimal(12, 2)), 10500, N'e071befee33bf7fb15a1221084109390283d6df7b0bee796052c705c26858444')
SET IDENTITY_INSERT [dbo].[DetalleVenta] OFF
GO
INSERT [dbo].[Familia] ([Nombre], [DVH]) VALUES (N'AccionesCriticas', N'c3465c31de98de487bd737fca31ae70a6195ca8260a8b71ce2f89b0aadfb071f')
INSERT [dbo].[Familia] ([Nombre], [DVH]) VALUES (N'Bitacora', N'2f0c6452ff5c43f6b0da930bf75a4152a7302c8d310ec914382e3ffe2f0e56b9')
INSERT [dbo].[Familia] ([Nombre], [DVH]) VALUES (N'flia1', N'99e5fac70b3713f5522edb712c742dd276a9e9ce83e483e51e4a4ea8fb68c618')
INSERT [dbo].[Familia] ([Nombre], [DVH]) VALUES (N'flia2', N'986ecaeb626d6dcc849b5377513beda064e7c638c12a5d1c312d6a3a44efd931')
INSERT [dbo].[Familia] ([Nombre], [DVH]) VALUES (N'ModuloDV', N'0e5e80824ddb092eb5acd0f3c409727d030f1f30088898a993aad84e499c5b4f')
INSERT [dbo].[Familia] ([Nombre], [DVH]) VALUES (N'ModuloUsuarios', N'64cf7c72eca360682f01ea5eb29bb1ec803b1d051f59529b3d2a941404dcbbaa')
INSERT [dbo].[Familia] ([Nombre], [DVH]) VALUES (N'ModuloVentas', N'2a87b5dceee418a27276970ebff99f21ca4a88240a5468d6828beda2ded78300')
INSERT [dbo].[Familia] ([Nombre], [DVH]) VALUES (N'Perfil', N'0429f70e6de9b05783865507ec6b446d3a249ef0e3f757bc54dcdf43b330fad7')
INSERT [dbo].[Familia] ([Nombre], [DVH]) VALUES (N'RFN1', N'50a2435b7bfdd8f54e14de830d70a25ab4e009b8bcec3afd15c11dda1b6f405a')
INSERT [dbo].[Familia] ([Nombre], [DVH]) VALUES (N'RFN1_Supervisor', N'bb0117b25bf441e3ce54300d949829985e0cde89c82f90e72a86245f69047c28')
INSERT [dbo].[Familia] ([Nombre], [DVH]) VALUES (N'RFN1_Vendedor', N'8ad792fc91ebde4af2c2569fec2ba935b8f623abfe87f1649da298f459fe54ee')
INSERT [dbo].[Familia] ([Nombre], [DVH]) VALUES (N'RFN2', N'1438594cba7daab62d9b4610529a84e0267cd17a9112522e4650b1278db02d10')
INSERT [dbo].[Familia] ([Nombre], [DVH]) VALUES (N'RFN2_Supervisor', N'49bed426fc68fefb50b83bc8a4fc4fb7fb98b4ff61e2d6aac88a88ef4587473a')
INSERT [dbo].[Familia] ([Nombre], [DVH]) VALUES (N'RFN2_Vendedor', N'682b9d8b7885426c6cc8b6f9c5442218c8e4a11c6b0219b53b4b702fca7eb05b')
GO
INSERT [dbo].[Familia_Familia] ([NombrePadre], [NombreHijo]) VALUES (N'flia1', N'flia2')
INSERT [dbo].[Familia_Familia] ([NombrePadre], [NombreHijo]) VALUES (N'ModuloUsuarios', N'AccionesCriticas')
INSERT [dbo].[Familia_Familia] ([NombrePadre], [NombreHijo]) VALUES (N'RFN1', N'RFN1_Supervisor')
INSERT [dbo].[Familia_Familia] ([NombrePadre], [NombreHijo]) VALUES (N'RFN1', N'RFN1_Vendedor')
INSERT [dbo].[Familia_Familia] ([NombrePadre], [NombreHijo]) VALUES (N'RFN2', N'RFN2_Supervisor')
INSERT [dbo].[Familia_Familia] ([NombrePadre], [NombreHijo]) VALUES (N'RFN2', N'RFN2_Vendedor')
GO
INSERT [dbo].[Familia_PermisoSimple] ([NombreFamilia], [NombrePermiso]) VALUES (N'AccionesCriticas', N'Crear Usuario')
INSERT [dbo].[Familia_PermisoSimple] ([NombreFamilia], [NombrePermiso]) VALUES (N'AccionesCriticas', N'Modificar Usuario')
INSERT [dbo].[Familia_PermisoSimple] ([NombreFamilia], [NombrePermiso]) VALUES (N'AccionesCriticas', N'Ver Respaldos')
INSERT [dbo].[Familia_PermisoSimple] ([NombreFamilia], [NombrePermiso]) VALUES (N'Bitacora', N'Bitacora de Cambios')
INSERT [dbo].[Familia_PermisoSimple] ([NombreFamilia], [NombrePermiso]) VALUES (N'Bitacora', N'Filtrar Bitacora')
INSERT [dbo].[Familia_PermisoSimple] ([NombreFamilia], [NombrePermiso]) VALUES (N'Bitacora', N'Imprimir Bitacora')
INSERT [dbo].[Familia_PermisoSimple] ([NombreFamilia], [NombrePermiso]) VALUES (N'Bitacora', N'Limpiar Bitacora')
INSERT [dbo].[Familia_PermisoSimple] ([NombreFamilia], [NombrePermiso]) VALUES (N'Bitacora', N'Ver Bitacora')
INSERT [dbo].[Familia_PermisoSimple] ([NombreFamilia], [NombrePermiso]) VALUES (N'ModuloDV', N'Gestionar DigitoVerificadores')
INSERT [dbo].[Familia_PermisoSimple] ([NombreFamilia], [NombrePermiso]) VALUES (N'ModuloUsuarios', N'Activar Desactivar Usuario')
INSERT [dbo].[Familia_PermisoSimple] ([NombreFamilia], [NombrePermiso]) VALUES (N'ModuloUsuarios', N'Bloquear Usuario')
INSERT [dbo].[Familia_PermisoSimple] ([NombreFamilia], [NombrePermiso]) VALUES (N'ModuloUsuarios', N'btnModificar')
INSERT [dbo].[Familia_PermisoSimple] ([NombreFamilia], [NombrePermiso]) VALUES (N'ModuloUsuarios', N'Desbloquear Usuario')
INSERT [dbo].[Familia_PermisoSimple] ([NombreFamilia], [NombrePermiso]) VALUES (N'ModuloUsuarios', N'navGestionUsuarios')
INSERT [dbo].[Familia_PermisoSimple] ([NombreFamilia], [NombrePermiso]) VALUES (N'ModuloUsuarios', N'Ver Usuarios')
INSERT [dbo].[Familia_PermisoSimple] ([NombreFamilia], [NombrePermiso]) VALUES (N'ModuloVentas', N'Ver Bitacora')
INSERT [dbo].[Familia_PermisoSimple] ([NombreFamilia], [NombrePermiso]) VALUES (N'Perfil', N'Asignar Familia Perfil')
INSERT [dbo].[Familia_PermisoSimple] ([NombreFamilia], [NombrePermiso]) VALUES (N'Perfil', N'Asignar Permiso Familia')
INSERT [dbo].[Familia_PermisoSimple] ([NombreFamilia], [NombrePermiso]) VALUES (N'Perfil', N'Asignar Permiso Perfil')
INSERT [dbo].[Familia_PermisoSimple] ([NombreFamilia], [NombrePermiso]) VALUES (N'Perfil', N'Asignar Subfamilia')
INSERT [dbo].[Familia_PermisoSimple] ([NombreFamilia], [NombrePermiso]) VALUES (N'Perfil', N'Crear Familia')
INSERT [dbo].[Familia_PermisoSimple] ([NombreFamilia], [NombrePermiso]) VALUES (N'Perfil', N'Crear Perfil')
INSERT [dbo].[Familia_PermisoSimple] ([NombreFamilia], [NombrePermiso]) VALUES (N'Perfil', N'Crear Permiso')
INSERT [dbo].[Familia_PermisoSimple] ([NombreFamilia], [NombrePermiso]) VALUES (N'Perfil', N'Eliminar Familia')
INSERT [dbo].[Familia_PermisoSimple] ([NombreFamilia], [NombrePermiso]) VALUES (N'Perfil', N'Eliminar Perfil')
INSERT [dbo].[Familia_PermisoSimple] ([NombreFamilia], [NombrePermiso]) VALUES (N'Perfil', N'Eliminar Permiso')
INSERT [dbo].[Familia_PermisoSimple] ([NombreFamilia], [NombrePermiso]) VALUES (N'Perfil', N'Quitar Familia Perfil')
INSERT [dbo].[Familia_PermisoSimple] ([NombreFamilia], [NombrePermiso]) VALUES (N'Perfil', N'Quitar Permiso Familia')
INSERT [dbo].[Familia_PermisoSimple] ([NombreFamilia], [NombrePermiso]) VALUES (N'Perfil', N'Quitar Permiso Perfil')
INSERT [dbo].[Familia_PermisoSimple] ([NombreFamilia], [NombrePermiso]) VALUES (N'Perfil', N'Quitar Subfamilia')
INSERT [dbo].[Familia_PermisoSimple] ([NombreFamilia], [NombrePermiso]) VALUES (N'Perfil', N'Ver Perfiles')
INSERT [dbo].[Familia_PermisoSimple] ([NombreFamilia], [NombrePermiso]) VALUES (N'RFN1_Supervisor', N'Gestionar Productos')
INSERT [dbo].[Familia_PermisoSimple] ([NombreFamilia], [NombrePermiso]) VALUES (N'RFN1_Supervisor', N'Resolver Reclamo')
INSERT [dbo].[Familia_PermisoSimple] ([NombreFamilia], [NombrePermiso]) VALUES (N'RFN1_Vendedor', N'Consultar Saldo')
INSERT [dbo].[Familia_PermisoSimple] ([NombreFamilia], [NombrePermiso]) VALUES (N'RFN1_Vendedor', N'Emitir Comprobante')
INSERT [dbo].[Familia_PermisoSimple] ([NombreFamilia], [NombrePermiso]) VALUES (N'RFN1_Vendedor', N'Registrar Cliente')
INSERT [dbo].[Familia_PermisoSimple] ([NombreFamilia], [NombrePermiso]) VALUES (N'RFN1_Vendedor', N'Registrar Reclamo')
INSERT [dbo].[Familia_PermisoSimple] ([NombreFamilia], [NombrePermiso]) VALUES (N'RFN1_Vendedor', N'Registrar Venta')
INSERT [dbo].[Familia_PermisoSimple] ([NombreFamilia], [NombrePermiso]) VALUES (N'RFN2_Supervisor', N'Anular Canje')
INSERT [dbo].[Familia_PermisoSimple] ([NombreFamilia], [NombrePermiso]) VALUES (N'RFN2_Supervisor', N'Autorizar Canje')
INSERT [dbo].[Familia_PermisoSimple] ([NombreFamilia], [NombrePermiso]) VALUES (N'RFN2_Supervisor', N'Gestionar Premios')
INSERT [dbo].[Familia_PermisoSimple] ([NombreFamilia], [NombrePermiso]) VALUES (N'RFN2_Vendedor', N'Consultar Premios')
INSERT [dbo].[Familia_PermisoSimple] ([NombreFamilia], [NombrePermiso]) VALUES (N'RFN2_Vendedor', N'Entregar Premio')
INSERT [dbo].[Familia_PermisoSimple] ([NombreFamilia], [NombrePermiso]) VALUES (N'RFN2_Vendedor', N'Registrar Canje')
GO
INSERT [dbo].[Idioma] ([UserName], [CodigoIdioma], [DVH]) VALUES (N'Jose384', N'es', N'ab179bae2498ac281da8707968a80d2757c2db2cd9f86da0a8ea1b18af9ae7c3')
INSERT [dbo].[Idioma] ([UserName], [CodigoIdioma], [DVH]) VALUES (N'Lucas99', N'es', N'910e8162605e6305b265dfe856f12410afacd3f7e496b3ee69f0e2c4fb72d034')
INSERT [dbo].[Idioma] ([UserName], [CodigoIdioma], [DVH]) VALUES (N'Maria12', N'es', N'4938910080877976aaf784c5ac9d56beeaac41a3ec14ad22bea5b8becf70e591')
INSERT [dbo].[Idioma] ([UserName], [CodigoIdioma], [DVH]) VALUES (N'messi', N'en', N'0f9d3cf265331027faef1d2d02b99cfc0d35a9dd22e0f2cc6b8113bf61613951')
INSERT [dbo].[Idioma] ([UserName], [CodigoIdioma], [DVH]) VALUES (N'Pedro443', N'es', N'25761bdeed1b7b40bcc64d2a30369fafc16f519f3023976cdc789b1a5f435535')
INSERT [dbo].[Idioma] ([UserName], [CodigoIdioma], [DVH]) VALUES (N'pepe', N'es', N'0e08433cea99e399946802df1bcf0781f519d1dd2b5255866a656007e0c038cb')
INSERT [dbo].[Idioma] ([UserName], [CodigoIdioma], [DVH]) VALUES (N'poop', N'en', N'a4498b82ef15612cd24295b2c63a3d35825cbb9bf84707efd85d0348a8845720')
GO
SET IDENTITY_INSERT [dbo].[LotePuntos] ON 

INSERT [dbo].[LotePuntos] ([idLote], [idCliente], [idVenta], [idReclamo], [puntosOriginales], [puntosDisponibles], [fechaAcreditacion], [fechaVencimiento], [origen], [DVH]) VALUES (1, 1, 1, NULL, 1656, 1656, CAST(N'2026-08-05' AS Date), CAST(N'2027-08-05' AS Date), N'venta', N'f61c339fad4fa08983c1bcf06c6fcc60b31c5487c55366331e1fc79121153496')
INSERT [dbo].[LotePuntos] ([idLote], [idCliente], [idVenta], [idReclamo], [puntosOriginales], [puntosDisponibles], [fechaAcreditacion], [fechaVencimiento], [origen], [DVH]) VALUES (2, 1, 2, NULL, 2080, 2080, CAST(N'2026-09-02' AS Date), CAST(N'2027-09-02' AS Date), N'venta', N'3152f44752e765749216286f7fc3703cbd068e4f2efcf7f809a441f6760098f1')
INSERT [dbo].[LotePuntos] ([idLote], [idCliente], [idVenta], [idReclamo], [puntosOriginales], [puntosDisponibles], [fechaAcreditacion], [fechaVencimiento], [origen], [DVH]) VALUES (3, 2, 3, NULL, 469, 469, CAST(N'2026-09-10' AS Date), CAST(N'2027-09-10' AS Date), N'venta', N'23eb3dd4ebc8a05306f88f4551ac9e5e4f061a1039b53c56f8b1b5525c6de95b')
INSERT [dbo].[LotePuntos] ([idLote], [idCliente], [idVenta], [idReclamo], [puntosOriginales], [puntosDisponibles], [fechaAcreditacion], [fechaVencimiento], [origen], [DVH]) VALUES (4, 1, 4, NULL, 1913, 1913, CAST(N'2026-10-02' AS Date), CAST(N'2027-10-02' AS Date), N'venta', N'92d2bc7fd4cd7f251ae037af285e9e26fb246ff4f325e96cd3ec11ee507d7ecb')
INSERT [dbo].[LotePuntos] ([idLote], [idCliente], [idVenta], [idReclamo], [puntosOriginales], [puntosDisponibles], [fechaAcreditacion], [fechaVencimiento], [origen], [DVH]) VALUES (5, 3, 5, NULL, 165, 165, CAST(N'2026-10-03' AS Date), CAST(N'2027-10-03' AS Date), N'venta', N'c5d9ffe98891f90e62dbc7b9c37ad26d48467ffd20aa3ba2635f4a5e03d1937d')
INSERT [dbo].[LotePuntos] ([idLote], [idCliente], [idVenta], [idReclamo], [puntosOriginales], [puntosDisponibles], [fechaAcreditacion], [fechaVencimiento], [origen], [DVH]) VALUES (6, 2, 6, NULL, 672, 672, CAST(N'2026-10-08' AS Date), CAST(N'2027-10-08' AS Date), N'venta', N'bfea5c5ff82a6eda969d1fe6491980a4ccf808df67a9cb1b6e2299368d065f8b')
INSERT [dbo].[LotePuntos] ([idLote], [idCliente], [idVenta], [idReclamo], [puntosOriginales], [puntosDisponibles], [fechaAcreditacion], [fechaVencimiento], [origen], [DVH]) VALUES (7, 4, 8, NULL, 2202, 2202, CAST(N'2026-11-05' AS Date), CAST(N'2027-11-05' AS Date), N'venta', N'1e5bc596ba3a1b7ebf2bf76e04ca172b2135fa42d9bf951df5df157752e2d638')
INSERT [dbo].[LotePuntos] ([idLote], [idCliente], [idVenta], [idReclamo], [puntosOriginales], [puntosDisponibles], [fechaAcreditacion], [fechaVencimiento], [origen], [DVH]) VALUES (8, 4, 11, NULL, 10500, 10500, CAST(N'2026-11-05' AS Date), CAST(N'2027-11-05' AS Date), N'venta', N'0d65815c9c006c1db6820cc70c99494d3d8a5ad3655baab66a26f143b36eaec0')
SET IDENTITY_INSERT [dbo].[LotePuntos] OFF
GO
SET IDENTITY_INSERT [dbo].[Nivel] ON 

INSERT [dbo].[Nivel] ([idNivel], [nombre], [puntosMinimos], [multiplicador]) VALUES (1, N'Bronce', 0, CAST(1.00 AS Decimal(4, 2)))
INSERT [dbo].[Nivel] ([idNivel], [nombre], [puntosMinimos], [multiplicador]) VALUES (2, N'Plata', 1500, CAST(1.25 AS Decimal(4, 2)))
INSERT [dbo].[Nivel] ([idNivel], [nombre], [puntosMinimos], [multiplicador]) VALUES (3, N'Oro', 4000, CAST(1.50 AS Decimal(4, 2)))
SET IDENTITY_INSERT [dbo].[Nivel] OFF
GO
INSERT [dbo].[Perfil] ([Nombre], [DVH]) VALUES (N'Administrador', N'97294c573733bc312f40750a8c0384bf91f7d3440763f1ae99d5d93a91803bb2')
INSERT [dbo].[Perfil] ([Nombre], [DVH]) VALUES (N'agente', N'96c14d746e37d6bf16a6eabd25a117a8a2e5f57d03b96eb1bba0ac78e0f08afa')
INSERT [dbo].[Perfil] ([Nombre], [DVH]) VALUES (N'Asesino', N'3c18cd525e8be5337e3d1b7517f81a7f316f5e4942b3823fb72a5e11def227a5')
INSERT [dbo].[Perfil] ([Nombre], [DVH]) VALUES (N'Cliente', N'102f370e73d4f9735eec7c224d713a085eaa9ea08899e0181ac0f2aefd13b21e')
INSERT [dbo].[Perfil] ([Nombre], [DVH]) VALUES (N'Jugador', N'b5c2ed135a0db4684b75e55ddd9ecabbcca24b4a02dacc2cbdc29adf640ee481')
INSERT [dbo].[Perfil] ([Nombre], [DVH]) VALUES (N'Operador', N'bb3146921973f45678e5961e84a07377cedaa5c589a0745b192b00e47c9a75bc')
INSERT [dbo].[Perfil] ([Nombre], [DVH]) VALUES (N'Supervisor', N'0d5454c368f1b83d91c6dd62fc729f4e9e5a72d857e5690fb74cd945c61690ef')
INSERT [dbo].[Perfil] ([Nombre], [DVH]) VALUES (N'Vendedor', N'b8075a6077b712c6ae76767df8963ac8555415fc2be2a6e999ebfd63fb284cce')
GO
INSERT [dbo].[Perfil_Familia] ([NombrePerfil], [NombreFamilia]) VALUES (N'Administrador', N'Bitacora')
INSERT [dbo].[Perfil_Familia] ([NombrePerfil], [NombreFamilia]) VALUES (N'Administrador', N'ModuloDV')
INSERT [dbo].[Perfil_Familia] ([NombrePerfil], [NombreFamilia]) VALUES (N'Administrador', N'ModuloUsuarios')
INSERT [dbo].[Perfil_Familia] ([NombrePerfil], [NombreFamilia]) VALUES (N'Administrador', N'Perfil')
INSERT [dbo].[Perfil_Familia] ([NombrePerfil], [NombreFamilia]) VALUES (N'Administrador', N'RFN1')
INSERT [dbo].[Perfil_Familia] ([NombrePerfil], [NombreFamilia]) VALUES (N'Administrador', N'RFN2')
INSERT [dbo].[Perfil_Familia] ([NombrePerfil], [NombreFamilia]) VALUES (N'agente', N'flia2')
INSERT [dbo].[Perfil_Familia] ([NombrePerfil], [NombreFamilia]) VALUES (N'Asesino', N'ModuloVentas')
INSERT [dbo].[Perfil_Familia] ([NombrePerfil], [NombreFamilia]) VALUES (N'Supervisor', N'ModuloVentas')
INSERT [dbo].[Perfil_Familia] ([NombrePerfil], [NombreFamilia]) VALUES (N'Supervisor', N'RFN1_Supervisor')
INSERT [dbo].[Perfil_Familia] ([NombrePerfil], [NombreFamilia]) VALUES (N'Supervisor', N'RFN2_Supervisor')
INSERT [dbo].[Perfil_Familia] ([NombrePerfil], [NombreFamilia]) VALUES (N'Vendedor', N'RFN1_Vendedor')
INSERT [dbo].[Perfil_Familia] ([NombrePerfil], [NombreFamilia]) VALUES (N'Vendedor', N'RFN2_Vendedor')
GO
INSERT [dbo].[PermisoSimple] ([Nombre], [DVH]) VALUES (N'Activar Desactivar Usuario', N'ff6e418d8667bc9f5690bc54e9ed2f1a42ce87eae6c4b48db68db9e58fcd141e')
INSERT [dbo].[PermisoSimple] ([Nombre], [DVH]) VALUES (N'Anular Canje', N'5143125ad017e3fb9006ef086e7718b0191d8eb369bbed453b28c85f6b4b9ec7')
INSERT [dbo].[PermisoSimple] ([Nombre], [DVH]) VALUES (N'Asignar Familia Perfil', N'71835dff6ace4e849db27fc47e940f9cfcf595ccc885af1fbaabc61800c0b6e9')
INSERT [dbo].[PermisoSimple] ([Nombre], [DVH]) VALUES (N'Asignar Permiso Familia', N'1076a4b32b1698e8454fd384e7976c4c1d7827801bf963be98dcb6236e4b1c3c')
INSERT [dbo].[PermisoSimple] ([Nombre], [DVH]) VALUES (N'Asignar Permiso Perfil', N'2ade7c6140ae52700038a042644ba8a73e33e313fec046a995899516fed4d2e9')
INSERT [dbo].[PermisoSimple] ([Nombre], [DVH]) VALUES (N'Asignar Subfamilia', N'b26019809d6289117a8211081b0c74344f72c64b4048bd9f23ed81f6306c9182')
INSERT [dbo].[PermisoSimple] ([Nombre], [DVH]) VALUES (N'Autorizar Canje', N'71c7d2560da9af7bffb9f9d1b331247816c54d39ce1ef7be173eb24b19619770')
INSERT [dbo].[PermisoSimple] ([Nombre], [DVH]) VALUES (N'Bitacora de Cambios', N'ba644749b0ced64ba5a86a5f05a287c9bc5aab1460305f2285e8ba8434237971')
INSERT [dbo].[PermisoSimple] ([Nombre], [DVH]) VALUES (N'Bloquear Usuario', N'c942742445c79feea74596d30aa094afb24339306ffa32b7a54c9f9e3b988f3b')
INSERT [dbo].[PermisoSimple] ([Nombre], [DVH]) VALUES (N'btnCambiarClave', N'15c8953e18c72ecf1899d3bc95063ea17419e103bc351cb85e13acc0346ebc34')
INSERT [dbo].[PermisoSimple] ([Nombre], [DVH]) VALUES (N'btnModificar', N'3413b2193cd32a41d060896ad1581ef04b518661cf6696abd1a9f496522d7c92')
INSERT [dbo].[PermisoSimple] ([Nombre], [DVH]) VALUES (N'Consultar Premios', N'5642b566dfa73cfcc226ca497270e6f764a2aa71d8b575bbcdd339a66e15cbf0')
INSERT [dbo].[PermisoSimple] ([Nombre], [DVH]) VALUES (N'Consultar Saldo', N'8acb76739925ebb3b206f6bb99d382c0d8357ada55f21d772361edceb27b663d')
INSERT [dbo].[PermisoSimple] ([Nombre], [DVH]) VALUES (N'Crear Familia', N'5081214843b5042557f008f0544c90638a2e6ea1467ed67dafd5ea6349fdb077')
INSERT [dbo].[PermisoSimple] ([Nombre], [DVH]) VALUES (N'Crear Perfil', N'ef0bad5893197b1613adcd36d22b4b03f262ac82ec5907015e07641b5b75edfd')
INSERT [dbo].[PermisoSimple] ([Nombre], [DVH]) VALUES (N'Crear Permiso', N'19053b43185641017a711f8cc7c99d4a51d8bd4d3f5af298abb5fc79517d9bb2')
INSERT [dbo].[PermisoSimple] ([Nombre], [DVH]) VALUES (N'Crear Usuario', N'c0bbf8790af993d6e4d158aea8adc1a041177ccf378cc0fd3a3f8a646194a52d')
INSERT [dbo].[PermisoSimple] ([Nombre], [DVH]) VALUES (N'Desbloquear Usuario', N'f37328497c2c93b666fc12566581e16ee9a9ba5f4c50b4b512d8e88b069e0758')
INSERT [dbo].[PermisoSimple] ([Nombre], [DVH]) VALUES (N'Eliminar Familia', N'95b0e30ed330b9be107a44218dc7b806785fec31dff2c870174f16093a64e0dd')
INSERT [dbo].[PermisoSimple] ([Nombre], [DVH]) VALUES (N'Eliminar Perfil', N'188ae9adfd15b1de85cd6ecea272ec9df8fccc034f2c1e3865bde02a73747389')
INSERT [dbo].[PermisoSimple] ([Nombre], [DVH]) VALUES (N'Eliminar Permiso', N'b983787266a20a733635e3caf0fa96858f07040635cbf024f9fe9cc744e20159')
INSERT [dbo].[PermisoSimple] ([Nombre], [DVH]) VALUES (N'Emitir Comprobante', N'11e43019b33be1dc584126e32d233430c51e0030f642e7358ae3cddbdca80abb')
INSERT [dbo].[PermisoSimple] ([Nombre], [DVH]) VALUES (N'Entregar Premio', N'c00909995162d2a92802b59b475961eae099f32f5c604fa002470642fa48cef2')
INSERT [dbo].[PermisoSimple] ([Nombre], [DVH]) VALUES (N'Filtrar Bitacora', N'1650074d88f23e0195b6a68a963a0681255400c3601d4efc0d32418743541350')
INSERT [dbo].[PermisoSimple] ([Nombre], [DVH]) VALUES (N'Gestionar DigitoVerificadores', N'b21e474d01456029ad092f4acc5a4620ce5c4ac4893815379eedc1a35caf6a52')
INSERT [dbo].[PermisoSimple] ([Nombre], [DVH]) VALUES (N'Gestionar Premios', N'ef3df86ace82f47a07299253a70b22048789af59507b99abd662e6aa3c966aa8')
INSERT [dbo].[PermisoSimple] ([Nombre], [DVH]) VALUES (N'Gestionar Productos', N'51f39d1af6f7858a00ca304f87b6295e401c99dd03bdeb66628e42943543a1d2')
INSERT [dbo].[PermisoSimple] ([Nombre], [DVH]) VALUES (N'Imprimir Bitacora', N'5d7704023c0bcfcfe6d5648d213239ea4e0f198ffb425400ec0f8f26d3a5edf2')
INSERT [dbo].[PermisoSimple] ([Nombre], [DVH]) VALUES (N'Limpiar Bitacora', N'ce9f396a5fd44f9243e61d49728d1905a6b6230cad46a2a620c20e726ce31372')
INSERT [dbo].[PermisoSimple] ([Nombre], [DVH]) VALUES (N'Modificar Usuario', N'a5ebe884cc1afe5f99df493d10dd9a828007f9ed8cf7b2897c8bb70497fc2932')
INSERT [dbo].[PermisoSimple] ([Nombre], [DVH]) VALUES (N'navGestionUsuarios', N'8163b71bce68dac74184c635c6209a7e626b6dfea445a788d42b5fbed65b3913')
INSERT [dbo].[PermisoSimple] ([Nombre], [DVH]) VALUES (N'Quitar Familia Perfil', N'c6dc732188e21fa2629994d47d40e483a8ee1dc17449ad2f1da2805da253e827')
INSERT [dbo].[PermisoSimple] ([Nombre], [DVH]) VALUES (N'Quitar Permiso Familia', N'df7bf463fd132c59ed8fa767f46baec99c9bb1ddaf51228fd18b3123d8745d8d')
INSERT [dbo].[PermisoSimple] ([Nombre], [DVH]) VALUES (N'Quitar Permiso Perfil', N'8d7c3f54224a104c56ca9ad63e05b9ff8fce13fa17c0d2355378c3fcd2618f99')
INSERT [dbo].[PermisoSimple] ([Nombre], [DVH]) VALUES (N'Quitar Subfamilia', N'8918e18c7613de32a23d2a90e5ab319f88ddf3201f1f0fdf5212ed532714afe0')
INSERT [dbo].[PermisoSimple] ([Nombre], [DVH]) VALUES (N'Registrar Canje', N'810221fb8e53af6c2c7a1aa0b9a73db0cfaa12c4e188661e10cc9a0a43a1182c')
INSERT [dbo].[PermisoSimple] ([Nombre], [DVH]) VALUES (N'Registrar Cliente', N'2089b49126d07d4ed22b873d7b48987a513ecffce4737e728440ada4ec441bbe')
INSERT [dbo].[PermisoSimple] ([Nombre], [DVH]) VALUES (N'Registrar Reclamo', N'dc28aa129c53f90e3e073c0cb174b20e3024db98814361ab168acebeaf14abde')
INSERT [dbo].[PermisoSimple] ([Nombre], [DVH]) VALUES (N'Registrar Venta', N'69c985d6d7d4286b5e340ffb4e83c80734a52b4e146b8010dae93f8ac99ab3e1')
INSERT [dbo].[PermisoSimple] ([Nombre], [DVH]) VALUES (N'Resolver Reclamo', N'2c31ac390ba15d85aeaa763ff2be888512f7fa27b53c96de438e8e1e7cac3d90')
INSERT [dbo].[PermisoSimple] ([Nombre], [DVH]) VALUES (N'Ver Bitacora', N'8d8a5d6970cfb2a28d52fccfa6bf5a28c9eca7db28ccd325c3776e2e3517ba88')
INSERT [dbo].[PermisoSimple] ([Nombre], [DVH]) VALUES (N'Ver Perfiles', N'df71166616a67a63998462e55fef6e8e1f4817d27390e0e579bc222be64f4687')
INSERT [dbo].[PermisoSimple] ([Nombre], [DVH]) VALUES (N'Ver Respaldos', N'd2a793f7203e23be776d5fe47c4d2beae4112d2ca0d11a9ae256eac6f2acf120')
INSERT [dbo].[PermisoSimple] ([Nombre], [DVH]) VALUES (N'Ver Usuarios', N'cd114a867294204a2d2e53efc6521f5d789de5889d16b437110eb59359347cc0')
GO
SET IDENTITY_INSERT [dbo].[Premio] ON 

INSERT [dbo].[Premio] ([idPremio], [nombre], [descripcion], [puntosRequeridos], [stock], [valorReferencia]) VALUES (1, N'Bolsa reutilizable Le Marchant', N'Bolsa de tela con el logo del mercado', 150, 40, CAST(900.00 AS Decimal(12, 2)))
INSERT [dbo].[Premio] ([idPremio], [nombre], [descripcion], [puntosRequeridos], [stock], [valorReferencia]) VALUES (2, N'Taza Le Marchant', N'Taza de cerámica 350 ml', 400, 25, CAST(4500.00 AS Decimal(12, 2)))
INSERT [dbo].[Premio] ([idPremio], [nombre], [descripcion], [puntosRequeridos], [stock], [valorReferencia]) VALUES (3, N'Vale de compra $ 5.000', N'Vale para usar en cualquier compra del mercado', 500, 50, CAST(5000.00 AS Decimal(12, 2)))
INSERT [dbo].[Premio] ([idPremio], [nombre], [descripcion], [puntosRequeridos], [stock], [valorReferencia]) VALUES (4, N'Kit de limpieza', N'Detergente, lavandina, esponjas y paño', 700, 15, CAST(8000.00 AS Decimal(12, 2)))
INSERT [dbo].[Premio] ([idPremio], [nombre], [descripcion], [puntosRequeridos], [stock], [valorReferencia]) VALUES (5, N'Canasta de frescos', N'Frutas y verduras de estación', 1200, 10, CAST(15000.00 AS Decimal(12, 2)))
INSERT [dbo].[Premio] ([idPremio], [nombre], [descripcion], [puntosRequeridos], [stock], [valorReferencia]) VALUES (6, N'Termo de acero 1 l', N'Termo de acero inoxidable con pico cebador', 2500, 8, CAST(32000.00 AS Decimal(12, 2)))
INSERT [dbo].[Premio] ([idPremio], [nombre], [descripcion], [puntosRequeridos], [stock], [valorReferencia]) VALUES (7, N'Licuadora', N'Licuadora de 600 W con vaso de vidrio', 4500, 4, CAST(60000.00 AS Decimal(12, 2)))
INSERT [dbo].[Premio] ([idPremio], [nombre], [descripcion], [puntosRequeridos], [stock], [valorReferencia]) VALUES (8, N'Freidora de aire', N'Freidora de aire de 4 litros', 9000, 2, CAST(120000.00 AS Decimal(12, 2)))
SET IDENTITY_INSERT [dbo].[Premio] OFF
GO
SET IDENTITY_INSERT [dbo].[Producto] ON 

INSERT [dbo].[Producto] ([idProducto], [nombre], [precio], [idCategoria]) VALUES (1, N'Yerba mate 1 kg', CAST(4800.00 AS Decimal(12, 2)), 1)
INSERT [dbo].[Producto] ([idProducto], [nombre], [precio], [idCategoria]) VALUES (2, N'Fideos tirabuzón 500 g', CAST(1450.00 AS Decimal(12, 2)), 1)
INSERT [dbo].[Producto] ([idProducto], [nombre], [precio], [idCategoria]) VALUES (3, N'Arroz largo fino 1 kg', CAST(1900.00 AS Decimal(12, 2)), 1)
INSERT [dbo].[Producto] ([idProducto], [nombre], [precio], [idCategoria]) VALUES (4, N'Aceite de girasol 1,5 l', CAST(3900.00 AS Decimal(12, 2)), 1)
INSERT [dbo].[Producto] ([idProducto], [nombre], [precio], [idCategoria]) VALUES (5, N'Azúcar 1 kg', CAST(1350.00 AS Decimal(12, 2)), 1)
INSERT [dbo].[Producto] ([idProducto], [nombre], [precio], [idCategoria]) VALUES (6, N'Harina 0000 1 kg', CAST(1100.00 AS Decimal(12, 2)), 1)
INSERT [dbo].[Producto] ([idProducto], [nombre], [precio], [idCategoria]) VALUES (7, N'Café molido 250 g', CAST(5200.00 AS Decimal(12, 2)), 1)
INSERT [dbo].[Producto] ([idProducto], [nombre], [precio], [idCategoria]) VALUES (8, N'Galletitas de agua 300 g', CAST(1800.00 AS Decimal(12, 2)), 1)
INSERT [dbo].[Producto] ([idProducto], [nombre], [precio], [idCategoria]) VALUES (9, N'Dulce de leche 400 g', CAST(2600.00 AS Decimal(12, 2)), 1)
INSERT [dbo].[Producto] ([idProducto], [nombre], [precio], [idCategoria]) VALUES (10, N'Atún en lata 170 g', CAST(2300.00 AS Decimal(12, 2)), 1)
INSERT [dbo].[Producto] ([idProducto], [nombre], [precio], [idCategoria]) VALUES (11, N'Pan francés 1 kg', CAST(2800.00 AS Decimal(12, 2)), 2)
INSERT [dbo].[Producto] ([idProducto], [nombre], [precio], [idCategoria]) VALUES (12, N'Medialunas x 6', CAST(3600.00 AS Decimal(12, 2)), 2)
INSERT [dbo].[Producto] ([idProducto], [nombre], [precio], [idCategoria]) VALUES (13, N'Queso cremoso 1 kg', CAST(9800.00 AS Decimal(12, 2)), 2)
INSERT [dbo].[Producto] ([idProducto], [nombre], [precio], [idCategoria]) VALUES (14, N'Jamón cocido 1 kg', CAST(14500.00 AS Decimal(12, 2)), 2)
INSERT [dbo].[Producto] ([idProducto], [nombre], [precio], [idCategoria]) VALUES (15, N'Banana 1 kg', CAST(2200.00 AS Decimal(12, 2)), 2)
INSERT [dbo].[Producto] ([idProducto], [nombre], [precio], [idCategoria]) VALUES (16, N'Tomate 1 kg', CAST(2500.00 AS Decimal(12, 2)), 2)
INSERT [dbo].[Producto] ([idProducto], [nombre], [precio], [idCategoria]) VALUES (17, N'Papa 1 kg', CAST(1300.00 AS Decimal(12, 2)), 2)
INSERT [dbo].[Producto] ([idProducto], [nombre], [precio], [idCategoria]) VALUES (18, N'Manzana roja 1 kg', CAST(2400.00 AS Decimal(12, 2)), 2)
INSERT [dbo].[Producto] ([idProducto], [nombre], [precio], [idCategoria]) VALUES (19, N'Huevos x 12', CAST(3900.00 AS Decimal(12, 2)), 2)
INSERT [dbo].[Producto] ([idProducto], [nombre], [precio], [idCategoria]) VALUES (20, N'Leche entera 1 l', CAST(1500.00 AS Decimal(12, 2)), 2)
INSERT [dbo].[Producto] ([idProducto], [nombre], [precio], [idCategoria]) VALUES (21, N'Agua mineral 2 l', CAST(1200.00 AS Decimal(12, 2)), 3)
INSERT [dbo].[Producto] ([idProducto], [nombre], [precio], [idCategoria]) VALUES (22, N'Gaseosa cola 2,25 l', CAST(3300.00 AS Decimal(12, 2)), 3)
INSERT [dbo].[Producto] ([idProducto], [nombre], [precio], [idCategoria]) VALUES (23, N'Vino Malbec 750 ml', CAST(6500.00 AS Decimal(12, 2)), 3)
INSERT [dbo].[Producto] ([idProducto], [nombre], [precio], [idCategoria]) VALUES (24, N'Cerveza rubia 1 l', CAST(2900.00 AS Decimal(12, 2)), 3)
INSERT [dbo].[Producto] ([idProducto], [nombre], [precio], [idCategoria]) VALUES (25, N'Jugo de naranja 1 l', CAST(2100.00 AS Decimal(12, 2)), 3)
INSERT [dbo].[Producto] ([idProducto], [nombre], [precio], [idCategoria]) VALUES (26, N'Detergente 750 ml', CAST(2100.00 AS Decimal(12, 2)), 4)
INSERT [dbo].[Producto] ([idProducto], [nombre], [precio], [idCategoria]) VALUES (27, N'Lavandina 2 l', CAST(1600.00 AS Decimal(12, 2)), 4)
INSERT [dbo].[Producto] ([idProducto], [nombre], [precio], [idCategoria]) VALUES (28, N'Jabón en polvo 3 kg', CAST(9800.00 AS Decimal(12, 2)), 4)
INSERT [dbo].[Producto] ([idProducto], [nombre], [precio], [idCategoria]) VALUES (29, N'Papel higiénico x 4', CAST(2800.00 AS Decimal(12, 2)), 4)
INSERT [dbo].[Producto] ([idProducto], [nombre], [precio], [idCategoria]) VALUES (30, N'Shampoo 400 ml', CAST(4300.00 AS Decimal(12, 2)), 5)
INSERT [dbo].[Producto] ([idProducto], [nombre], [precio], [idCategoria]) VALUES (31, N'Jabón de tocador x 3', CAST(2500.00 AS Decimal(12, 2)), 5)
INSERT [dbo].[Producto] ([idProducto], [nombre], [precio], [idCategoria]) VALUES (32, N'Pasta dental 90 g', CAST(2200.00 AS Decimal(12, 2)), 5)
INSERT [dbo].[Producto] ([idProducto], [nombre], [precio], [idCategoria]) VALUES (33, N'Desodorante 150 ml', CAST(3600.00 AS Decimal(12, 2)), 5)
INSERT [dbo].[Producto] ([idProducto], [nombre], [precio], [idCategoria]) VALUES (34, N'Mermelada artesanal Le Marchant 450 g', CAST(4900.00 AS Decimal(12, 2)), 6)
INSERT [dbo].[Producto] ([idProducto], [nombre], [precio], [idCategoria]) VALUES (35, N'Granola Le Marchant 500 g', CAST(5900.00 AS Decimal(12, 2)), 6)
INSERT [dbo].[Producto] ([idProducto], [nombre], [precio], [idCategoria]) VALUES (36, N'Pan de campo Le Marchant', CAST(4200.00 AS Decimal(12, 2)), 6)
INSERT [dbo].[Producto] ([idProducto], [nombre], [precio], [idCategoria]) VALUES (37, N'Bolsa reutilizable', CAST(900.00 AS Decimal(12, 2)), 7)
INSERT [dbo].[Producto] ([idProducto], [nombre], [precio], [idCategoria]) VALUES (38, N'Hielo 2 kg', CAST(1500.00 AS Decimal(12, 2)), 7)
SET IDENTITY_INSERT [dbo].[Producto] OFF
GO
SET IDENTITY_INSERT [dbo].[ProgramaPuntos] ON 

INSERT [dbo].[ProgramaPuntos] ([idPrograma], [nombre], [montoPorPunto], [mesesVencimiento], [plazoReclamoDias], [vigenciaDesde], [umbralAutorizacion], [plazoAnulacionDias]) VALUES (1, N'Le Marchant Puntos', CAST(100.00 AS Decimal(12, 2)), 12, 30, CAST(N'2026-01-01' AS Date), CAST(25000.00 AS Decimal(12, 2)), 7)
SET IDENTITY_INSERT [dbo].[ProgramaPuntos] OFF
GO
SET IDENTITY_INSERT [dbo].[Reclamo] ON 

INSERT [dbo].[Reclamo] ([idReclamo], [idCliente], [idVenta], [fechaReclamo], [puntosReclamados], [motivo], [estado], [dniVendedor], [dniSupervisor], [motivoResolucion], [fechaResolucion], [DVH]) VALUES (1, 4, 9, CAST(N'2026-11-05T18:30:57.000' AS DateTime), 23, N'Cosas que pasan', N'pendiente', N'11111111', NULL, NULL, NULL, N'486803dada149c41339dc21a245256dd67b09f4dfca3fb3343b9f1a6cad6d7d3')
SET IDENTITY_INSERT [dbo].[Reclamo] OFF
GO
INSERT [dbo].[Usuario] ([DNI], [Nombre], [Apellido], [UserName], [Password], [Email], [Bloqueado], [Activo], [Rol], [Intentos], [DVH]) VALUES (N'11111111', N'Lauti', N'Juan', N'Maria12', N'03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', N'maria@mail.com', 0, 1, N'Administrador', 0, N'14bda88289ef52b035662d33b10ae5b0503569614a8ab19359467686ec7b16ba')
INSERT [dbo].[Usuario] ([DNI], [Nombre], [Apellido], [UserName], [Password], [Email], [Bloqueado], [Activo], [Rol], [Intentos], [DVH]) VALUES (N'12341234', N'lucas', N'poeta', N'1234', N'bef1e639c2964c52ecbfa41c9976962aae789af737f97b6226fd7fc542918512', N'asdf@gmail.com', 0, 0, N'Asesino', 2, N'190a7e343efefbc4863658fa1062a956ddd48e383412e73f19e7ef8d586ba3b1')
INSERT [dbo].[Usuario] ([DNI], [Nombre], [Apellido], [UserName], [Password], [Email], [Bloqueado], [Activo], [Rol], [Intentos], [DVH]) VALUES (N'12344321', N'Final', N'Solucion', N'idolo', N'493bc2746e664e087d7b275c0ecd453073edc2d1427d98dbe34af335054ac93f', N'a@gmail.com', 0, 1, N'Administrador', 0, N'718dff4d54df99c7deb14489b2eaacd01100c96b88219d2b10b765cc0152f99d')
INSERT [dbo].[Usuario] ([DNI], [Nombre], [Apellido], [UserName], [Password], [Email], [Bloqueado], [Activo], [Rol], [Intentos], [DVH]) VALUES (N'12345678', N'POOOOP', N'Rodriguez', N'Jose384', N'03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', N'jose@mail.com', 0, 1, N'Administrador', 3, N'9df1c8d9fee629cdb884050c31b9b9a6d6dab71a4da30441720151de38c1edd8')
INSERT [dbo].[Usuario] ([DNI], [Nombre], [Apellido], [UserName], [Password], [Email], [Bloqueado], [Activo], [Rol], [Intentos], [DVH]) VALUES (N'12398321', N'Porcelo', N'Olmedos', N'poop', N'4f520dcdc04ed157cbcef3d73a7efd5717fd56e1a884dd57473d7e8a315c7d59', N'ppppq@gmail.com', 0, 1, N'agente', 0, N'ceff1d7117f958e20da12af909d1076677c297a4c658d333b093827ce68eea89')
INSERT [dbo].[Usuario] ([DNI], [Nombre], [Apellido], [UserName], [Password], [Email], [Bloqueado], [Activo], [Rol], [Intentos], [DVH]) VALUES (N'22222222', N'Lucas', N'Perez', N'Lucas99', N'7629520225e502fda13e7da14849be22e317e3e3c9db1b25ca98f9637f67f2b8', N'lucas@mail.com', 0, 1, N'Vendedor', 0, N'758aeacaac23d80536ee8356ddfec746eff45cddb57b3d0cd49736cb2bb5aed7')
INSERT [dbo].[Usuario] ([DNI], [Nombre], [Apellido], [UserName], [Password], [Email], [Bloqueado], [Activo], [Rol], [Intentos], [DVH]) VALUES (N'33333333', N'Prueba', N'Vendedor', N'vendedor1', N'03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', N'vendedor1@mail.com', 0, 1, N'Vendedor', 0, N'4cf791842d3f048465e82643b12560fe4b9aa19a56f0ae44b07e48d49a012780')
INSERT [dbo].[Usuario] ([DNI], [Nombre], [Apellido], [UserName], [Password], [Email], [Bloqueado], [Activo], [Rol], [Intentos], [DVH]) VALUES (N'87654321', N'Pedro', N'Gomez', N'Pedro443', N'03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', N'pedro@mail.com', 0, 1, N'Supervisor', 0, N'28cd643beae0d0215fe520f8de573532aa8a4238ce7ac01e55416cfb288b1e8b')
INSERT [dbo].[Usuario] ([DNI], [Nombre], [Apellido], [UserName], [Password], [Email], [Bloqueado], [Activo], [Rol], [Intentos], [DVH]) VALUES (N'95141012', N'Lionel', N'Messi', N'messi', N'044df85a948e16326ab2528df6fee63b97473d18478fe66051fb8e1375a7f241', N'lione@gmail.com', 0, 1, N'Jugador', 0, N'2b128503f8219a346fae448d00b75951118ef28912e80536a4cce362dbcc6d30')
INSERT [dbo].[Usuario] ([DNI], [Nombre], [Apellido], [UserName], [Password], [Email], [Bloqueado], [Activo], [Rol], [Intentos], [DVH]) VALUES (N'99999999', N'Pepe', N'Argento', N'pepe', N'e60f8b61deee334140d239a70ac458acfc429174ccdc15130676ef2c52b76b34', N'pepe@mail.com', 1, 1, N'Administrador', 3, N'ba547cb3e313a940d88e8352464e621af79a73ed1b84507d886c7851fc8befb8')
GO
SET IDENTITY_INSERT [dbo].[Venta] ON 

INSERT [dbo].[Venta] ([idVenta], [nroComprobante], [fecha], [idCliente], [dniVendedor], [total], [puntosAcreditados], [DVH]) VALUES (1, N'V-00000001', CAST(N'2026-08-05T10:12:30.000' AS DateTime), 1, N'22222222', CAST(131400.00 AS Decimal(12, 2)), 1656, N'f28c7b0869a928a360651299af2e8667363dc2a019bc9062db78d0673df2c1ec')
INSERT [dbo].[Venta] ([idVenta], [nroComprobante], [fecha], [idCliente], [dniVendedor], [total], [puntosAcreditados], [DVH]) VALUES (2, N'V-00000002', CAST(N'2026-09-02T18:40:05.000' AS DateTime), 1, N'22222222', CAST(137200.00 AS Decimal(12, 2)), 2080, N'cb612fd76206bd4b54ae04b939504e9f1f0f6208706bdb040e47a0c02d69b14a')
INSERT [dbo].[Venta] ([idVenta], [nroComprobante], [fecha], [idCliente], [dniVendedor], [total], [puntosAcreditados], [DVH]) VALUES (3, N'V-00000003', CAST(N'2026-09-10T09:30:00.000' AS DateTime), 2, N'22222222', CAST(45900.00 AS Decimal(12, 2)), 469, N'22abaceb6e1e6affaa6e1eac8e76653483a11a39412005f47a767f9a2fd76937')
INSERT [dbo].[Venta] ([idVenta], [nroComprobante], [fecha], [idCliente], [dniVendedor], [total], [puntosAcreditados], [DVH]) VALUES (4, N'V-00000004', CAST(N'2026-10-02T11:05:44.000' AS DateTime), 1, N'22222222', CAST(120200.00 AS Decimal(12, 2)), 1913, N'fba7e5709961d86eb9b7ea77702e8320192a68f18ce360cb301b9d7e1553e30a')
INSERT [dbo].[Venta] ([idVenta], [nroComprobante], [fecha], [idCliente], [dniVendedor], [total], [puntosAcreditados], [DVH]) VALUES (5, N'V-00000005', CAST(N'2026-10-03T12:00:10.000' AS DateTime), 3, N'22222222', CAST(14100.00 AS Decimal(12, 2)), 165, N'7c8a43c521b1984dac2dd7c452a7e45a42a3ae9c1a332c6e5f6c70c21609e0e8')
INSERT [dbo].[Venta] ([idVenta], [nroComprobante], [fecha], [idCliente], [dniVendedor], [total], [puntosAcreditados], [DVH]) VALUES (6, N'V-00000006', CAST(N'2026-10-08T17:15:20.000' AS DateTime), 2, N'22222222', CAST(51400.00 AS Decimal(12, 2)), 672, N'3118d21781e73d95f5c2d1a75e496c0cef600cb23df2517bfcbe9d9fc46e3558')
INSERT [dbo].[Venta] ([idVenta], [nroComprobante], [fecha], [idCliente], [dniVendedor], [total], [puntosAcreditados], [DVH]) VALUES (7, N'V-00000007', CAST(N'2026-10-09T19:22:00.000' AS DateTime), NULL, N'22222222', CAST(4200.00 AS Decimal(12, 2)), 0, N'2f63f64e76156d74b9f1cc95e9cb4987357c230d9baed8d48bbe363344b3bd88')
INSERT [dbo].[Venta] ([idVenta], [nroComprobante], [fecha], [idCliente], [dniVendedor], [total], [puntosAcreditados], [DVH]) VALUES (8, N'V-00000008', CAST(N'2026-11-05T18:14:29.000' AS DateTime), 4, N'11111111', CAST(114000.00 AS Decimal(12, 2)), 2202, N'bdb2a6e775591f0aefa6b9757cba21310365439899208065b4e9dcb7458972f8')
INSERT [dbo].[Venta] ([idVenta], [nroComprobante], [fecha], [idCliente], [dniVendedor], [total], [puntosAcreditados], [DVH]) VALUES (9, N'V-00000009', CAST(N'2026-11-05T18:29:37.000' AS DateTime), NULL, N'11111111', CAST(1900.00 AS Decimal(12, 2)), 0, N'fe059a9d67f294f2970e1c573fb5ae2ae2166f0cfa7d50e40a5ed8c2d421a39a')
INSERT [dbo].[Venta] ([idVenta], [nroComprobante], [fecha], [idCliente], [dniVendedor], [total], [puntosAcreditados], [DVH]) VALUES (10, N'V-00000010', CAST(N'2026-11-05T18:34:06.000' AS DateTime), NULL, N'11111111', CAST(912300.00 AS Decimal(12, 2)), 0, N'9e389605b4f231cba640156029de40e2760d12f65aba6ff5acce05a57a6e21ca')
INSERT [dbo].[Venta] ([idVenta], [nroComprobante], [fecha], [idCliente], [dniVendedor], [total], [puntosAcreditados], [DVH]) VALUES (11, N'V-00000011', CAST(N'2026-11-05T18:34:28.000' AS DateTime), 4, N'11111111', CAST(420000.00 AS Decimal(12, 2)), 10500, N'05043f888e53cee6157652e7d469e4e280fc10bd532903f32bbd1fd5e931bc91')
SET IDENTITY_INSERT [dbo].[Venta] OFF
GO
/****** Object:  Index [IX_BitacoraCambiosCliente_idCliente]    Script Date: 06/11/2026 12:45:40 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_BitacoraCambiosCliente_idCliente] ON [dbo].[BitacoraCambiosCliente]
(
	[idCliente] ASC,
	[activo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Canje_nroCanje]    Script Date: 06/11/2026 12:45:40 a. m. ******/
ALTER TABLE [dbo].[Canje] ADD  CONSTRAINT [UQ_Canje_nroCanje] UNIQUE NONCLUSTERED 
(
	[nroCanje] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Canje_estado]    Script Date: 06/11/2026 12:45:40 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_Canje_estado] ON [dbo].[Canje]
(
	[estado] ASC,
	[idCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Categoria_nombre]    Script Date: 06/11/2026 12:45:40 a. m. ******/
ALTER TABLE [dbo].[Categoria] ADD  CONSTRAINT [UQ_Categoria_nombre] UNIQUE NONCLUSTERED 
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Cliente_dni]    Script Date: 06/11/2026 12:45:40 a. m. ******/
ALTER TABLE [dbo].[Cliente] ADD  CONSTRAINT [UQ_Cliente_dni] UNIQUE NONCLUSTERED 
(
	[dni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_LotePuntos_idCliente]    Script Date: 06/11/2026 12:45:40 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_LotePuntos_idCliente] ON [dbo].[LotePuntos]
(
	[idCliente] ASC,
	[fechaVencimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UX_LotePuntos_idReclamo]    Script Date: 06/11/2026 12:45:40 a. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [UX_LotePuntos_idReclamo] ON [dbo].[LotePuntos]
(
	[idReclamo] ASC
)
WHERE ([idReclamo] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UX_LotePuntos_idVenta]    Script Date: 06/11/2026 12:45:40 a. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [UX_LotePuntos_idVenta] ON [dbo].[LotePuntos]
(
	[idVenta] ASC
)
WHERE ([idVenta] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Nivel_nombre]    Script Date: 06/11/2026 12:45:40 a. m. ******/
ALTER TABLE [dbo].[Nivel] ADD  CONSTRAINT [UQ_Nivel_nombre] UNIQUE NONCLUSTERED 
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Premio_nombre]    Script Date: 06/11/2026 12:45:40 a. m. ******/
ALTER TABLE [dbo].[Premio] ADD  CONSTRAINT [UQ_Premio_nombre] UNIQUE NONCLUSTERED 
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Producto_nombre]    Script Date: 06/11/2026 12:45:40 a. m. ******/
ALTER TABLE [dbo].[Producto] ADD  CONSTRAINT [UQ_Producto_nombre] UNIQUE NONCLUSTERED 
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Reclamo_idVenta]    Script Date: 06/11/2026 12:45:40 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_Reclamo_idVenta] ON [dbo].[Reclamo]
(
	[idVenta] ASC,
	[estado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Usuario_UserName]    Script Date: 06/11/2026 12:45:40 a. m. ******/
ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [UQ_Usuario_UserName] UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Venta_nroComprobante]    Script Date: 06/11/2026 12:45:40 a. m. ******/
ALTER TABLE [dbo].[Venta] ADD  CONSTRAINT [UQ_Venta_nroComprobante] UNIQUE NONCLUSTERED 
(
	[nroComprobante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DetalleVenta] ADD  CONSTRAINT [DF_DetalleVenta_puntos]  DEFAULT ((0)) FOR [puntosCalculados]
GO
ALTER TABLE [dbo].[Premio] ADD  CONSTRAINT [DF_Premio_descripcion]  DEFAULT ('') FOR [descripcion]
GO
ALTER TABLE [dbo].[Reclamo] ADD  CONSTRAINT [DF_Reclamo_estado]  DEFAULT ('pendiente') FOR [estado]
GO
ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [DF_Usuario_Intentos]  DEFAULT ((0)) FOR [Intentos]
GO
ALTER TABLE [dbo].[Venta] ADD  CONSTRAINT [DF_Venta_puntos]  DEFAULT ((0)) FOR [puntosAcreditados]
GO
ALTER TABLE [dbo].[BitacoraCambiosCliente]  WITH CHECK ADD  CONSTRAINT [FK_BitacoraCambiosCliente_Cliente] FOREIGN KEY([idCliente])
REFERENCES [dbo].[Cliente] ([idCliente])
GO
ALTER TABLE [dbo].[BitacoraCambiosCliente] CHECK CONSTRAINT [FK_BitacoraCambiosCliente_Cliente]
GO
ALTER TABLE [dbo].[Canje]  WITH CHECK ADD  CONSTRAINT [FK_Canje_Anulacion] FOREIGN KEY([dniAnulacion])
REFERENCES [dbo].[Usuario] ([DNI])
GO
ALTER TABLE [dbo].[Canje] CHECK CONSTRAINT [FK_Canje_Anulacion]
GO
ALTER TABLE [dbo].[Canje]  WITH CHECK ADD  CONSTRAINT [FK_Canje_Cliente] FOREIGN KEY([idCliente])
REFERENCES [dbo].[Cliente] ([idCliente])
GO
ALTER TABLE [dbo].[Canje] CHECK CONSTRAINT [FK_Canje_Cliente]
GO
ALTER TABLE [dbo].[Canje]  WITH CHECK ADD  CONSTRAINT [FK_Canje_Premio] FOREIGN KEY([idPremio])
REFERENCES [dbo].[Premio] ([idPremio])
GO
ALTER TABLE [dbo].[Canje] CHECK CONSTRAINT [FK_Canje_Premio]
GO
ALTER TABLE [dbo].[Canje]  WITH CHECK ADD  CONSTRAINT [FK_Canje_Supervisor] FOREIGN KEY([dniSupervisor])
REFERENCES [dbo].[Usuario] ([DNI])
GO
ALTER TABLE [dbo].[Canje] CHECK CONSTRAINT [FK_Canje_Supervisor]
GO
ALTER TABLE [dbo].[Canje]  WITH CHECK ADD  CONSTRAINT [FK_Canje_Vendedor] FOREIGN KEY([dniVendedor])
REFERENCES [dbo].[Usuario] ([DNI])
GO
ALTER TABLE [dbo].[Canje] CHECK CONSTRAINT [FK_Canje_Vendedor]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Nivel] FOREIGN KEY([idNivel])
REFERENCES [dbo].[Nivel] ([idNivel])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_Nivel]
GO
ALTER TABLE [dbo].[DetalleCanje]  WITH CHECK ADD  CONSTRAINT [FK_DetalleCanje_Canje] FOREIGN KEY([idCanje])
REFERENCES [dbo].[Canje] ([idCanje])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DetalleCanje] CHECK CONSTRAINT [FK_DetalleCanje_Canje]
GO
ALTER TABLE [dbo].[DetalleCanje]  WITH CHECK ADD  CONSTRAINT [FK_DetalleCanje_Lote] FOREIGN KEY([idLote])
REFERENCES [dbo].[LotePuntos] ([idLote])
GO
ALTER TABLE [dbo].[DetalleCanje] CHECK CONSTRAINT [FK_DetalleCanje_Lote]
GO
ALTER TABLE [dbo].[DetalleVenta]  WITH CHECK ADD  CONSTRAINT [FK_DetalleVenta_Producto] FOREIGN KEY([idProducto])
REFERENCES [dbo].[Producto] ([idProducto])
GO
ALTER TABLE [dbo].[DetalleVenta] CHECK CONSTRAINT [FK_DetalleVenta_Producto]
GO
ALTER TABLE [dbo].[DetalleVenta]  WITH CHECK ADD  CONSTRAINT [FK_DetalleVenta_Venta] FOREIGN KEY([idVenta])
REFERENCES [dbo].[Venta] ([idVenta])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DetalleVenta] CHECK CONSTRAINT [FK_DetalleVenta_Venta]
GO
ALTER TABLE [dbo].[LotePuntos]  WITH CHECK ADD  CONSTRAINT [FK_LotePuntos_Cliente] FOREIGN KEY([idCliente])
REFERENCES [dbo].[Cliente] ([idCliente])
GO
ALTER TABLE [dbo].[LotePuntos] CHECK CONSTRAINT [FK_LotePuntos_Cliente]
GO
ALTER TABLE [dbo].[LotePuntos]  WITH CHECK ADD  CONSTRAINT [FK_LotePuntos_Reclamo] FOREIGN KEY([idReclamo])
REFERENCES [dbo].[Reclamo] ([idReclamo])
GO
ALTER TABLE [dbo].[LotePuntos] CHECK CONSTRAINT [FK_LotePuntos_Reclamo]
GO
ALTER TABLE [dbo].[LotePuntos]  WITH CHECK ADD  CONSTRAINT [FK_LotePuntos_Venta] FOREIGN KEY([idVenta])
REFERENCES [dbo].[Venta] ([idVenta])
GO
ALTER TABLE [dbo].[LotePuntos] CHECK CONSTRAINT [FK_LotePuntos_Venta]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Categoria] FOREIGN KEY([idCategoria])
REFERENCES [dbo].[Categoria] ([idCategoria])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Categoria]
GO
ALTER TABLE [dbo].[Reclamo]  WITH CHECK ADD  CONSTRAINT [FK_Reclamo_Cliente] FOREIGN KEY([idCliente])
REFERENCES [dbo].[Cliente] ([idCliente])
GO
ALTER TABLE [dbo].[Reclamo] CHECK CONSTRAINT [FK_Reclamo_Cliente]
GO
ALTER TABLE [dbo].[Reclamo]  WITH CHECK ADD  CONSTRAINT [FK_Reclamo_Supervisor] FOREIGN KEY([dniSupervisor])
REFERENCES [dbo].[Usuario] ([DNI])
GO
ALTER TABLE [dbo].[Reclamo] CHECK CONSTRAINT [FK_Reclamo_Supervisor]
GO
ALTER TABLE [dbo].[Reclamo]  WITH CHECK ADD  CONSTRAINT [FK_Reclamo_Vendedor] FOREIGN KEY([dniVendedor])
REFERENCES [dbo].[Usuario] ([DNI])
GO
ALTER TABLE [dbo].[Reclamo] CHECK CONSTRAINT [FK_Reclamo_Vendedor]
GO
ALTER TABLE [dbo].[Reclamo]  WITH CHECK ADD  CONSTRAINT [FK_Reclamo_Venta] FOREIGN KEY([idVenta])
REFERENCES [dbo].[Venta] ([idVenta])
GO
ALTER TABLE [dbo].[Reclamo] CHECK CONSTRAINT [FK_Reclamo_Venta]
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [FK_Venta_Cliente] FOREIGN KEY([idCliente])
REFERENCES [dbo].[Cliente] ([idCliente])
GO
ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [FK_Venta_Cliente]
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [FK_Venta_Usuario] FOREIGN KEY([dniVendedor])
REFERENCES [dbo].[Usuario] ([DNI])
GO
ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [FK_Venta_Usuario]
GO
ALTER TABLE [dbo].[BitacoraCambiosCliente]  WITH CHECK ADD  CONSTRAINT [CK_BitacoraCambiosCliente_operacion] CHECK  (([operacion]='UPDATE' OR [operacion]='INSERT'))
GO
ALTER TABLE [dbo].[BitacoraCambiosCliente] CHECK CONSTRAINT [CK_BitacoraCambiosCliente_operacion]
GO
ALTER TABLE [dbo].[Canje]  WITH CHECK ADD  CONSTRAINT [CK_Canje_estado] CHECK  (([estado]='anulado' OR [estado]='entregado' OR [estado]='rechazado' OR [estado]='autorizado' OR [estado]='pendiente'))
GO
ALTER TABLE [dbo].[Canje] CHECK CONSTRAINT [CK_Canje_estado]
GO
ALTER TABLE [dbo].[Canje]  WITH CHECK ADD  CONSTRAINT [CK_Canje_puntos] CHECK  (([puntosRequeridos]>(0) AND [valorReferencia]>=(0)))
GO
ALTER TABLE [dbo].[Canje] CHECK CONSTRAINT [CK_Canje_puntos]
GO
ALTER TABLE [dbo].[Categoria]  WITH CHECK ADD  CONSTRAINT [CK_Categoria_multiplicador] CHECK  (([multiplicador]>=(0)))
GO
ALTER TABLE [dbo].[Categoria] CHECK CONSTRAINT [CK_Categoria_multiplicador]
GO
ALTER TABLE [dbo].[DetalleCanje]  WITH CHECK ADD  CONSTRAINT [CK_DetalleCanje_puntos] CHECK  (([puntosDescontados]>(0)))
GO
ALTER TABLE [dbo].[DetalleCanje] CHECK CONSTRAINT [CK_DetalleCanje_puntos]
GO
ALTER TABLE [dbo].[DetalleVenta]  WITH CHECK ADD  CONSTRAINT [CK_DetalleVenta_cantidad] CHECK  (([cantidad]>(0)))
GO
ALTER TABLE [dbo].[DetalleVenta] CHECK CONSTRAINT [CK_DetalleVenta_cantidad]
GO
ALTER TABLE [dbo].[LotePuntos]  WITH CHECK ADD  CONSTRAINT [CK_LotePuntos_fuente] CHECK  (([origen]='venta' AND [idVenta] IS NOT NULL AND [idReclamo] IS NULL OR [origen]='reclamo' AND [idReclamo] IS NOT NULL AND [idVenta] IS NULL))
GO
ALTER TABLE [dbo].[LotePuntos] CHECK CONSTRAINT [CK_LotePuntos_fuente]
GO
ALTER TABLE [dbo].[LotePuntos]  WITH CHECK ADD  CONSTRAINT [CK_LotePuntos_origen] CHECK  (([origen]='reclamo' OR [origen]='venta'))
GO
ALTER TABLE [dbo].[LotePuntos] CHECK CONSTRAINT [CK_LotePuntos_origen]
GO
ALTER TABLE [dbo].[LotePuntos]  WITH CHECK ADD  CONSTRAINT [CK_LotePuntos_puntos] CHECK  (([puntosOriginales]>(0) AND ([puntosDisponibles]>=(0) AND [puntosDisponibles]<=[puntosOriginales])))
GO
ALTER TABLE [dbo].[LotePuntos] CHECK CONSTRAINT [CK_LotePuntos_puntos]
GO
ALTER TABLE [dbo].[Nivel]  WITH CHECK ADD  CONSTRAINT [CK_Nivel_multiplicador] CHECK  (([multiplicador]>(0)))
GO
ALTER TABLE [dbo].[Nivel] CHECK CONSTRAINT [CK_Nivel_multiplicador]
GO
ALTER TABLE [dbo].[Nivel]  WITH CHECK ADD  CONSTRAINT [CK_Nivel_puntosMinimos] CHECK  (([puntosMinimos]>=(0)))
GO
ALTER TABLE [dbo].[Nivel] CHECK CONSTRAINT [CK_Nivel_puntosMinimos]
GO
ALTER TABLE [dbo].[Premio]  WITH CHECK ADD  CONSTRAINT [CK_Premio_valores] CHECK  (([puntosRequeridos]>(0) AND [stock]>=(0) AND [valorReferencia]>=(0)))
GO
ALTER TABLE [dbo].[Premio] CHECK CONSTRAINT [CK_Premio_valores]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [CK_Producto_precio] CHECK  (([precio]>=(0)))
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [CK_Producto_precio]
GO
ALTER TABLE [dbo].[ProgramaPuntos]  WITH CHECK ADD  CONSTRAINT [CK_ProgramaPuntos_valores] CHECK  (([montoPorPunto]>(0) AND [mesesVencimiento]>(0) AND [plazoReclamoDias]>(0) AND [umbralAutorizacion]>=(0) AND [plazoAnulacionDias]>=(0)))
GO
ALTER TABLE [dbo].[ProgramaPuntos] CHECK CONSTRAINT [CK_ProgramaPuntos_valores]
GO
ALTER TABLE [dbo].[Reclamo]  WITH CHECK ADD  CONSTRAINT [CK_Reclamo_estado] CHECK  (([estado]='rechazado' OR [estado]='aprobado' OR [estado]='pendiente'))
GO
ALTER TABLE [dbo].[Reclamo] CHECK CONSTRAINT [CK_Reclamo_estado]
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [CK_Venta_total] CHECK  (([total]>=(0) AND [puntosAcreditados]>=(0)))
GO
ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [CK_Venta_total]
GO
CREATE TRIGGER [dbo].[TR_Cliente_Insert] ON [dbo].[Cliente] AFTER INSERT AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO [dbo].[BitacoraCambiosCliente] (idCliente, dni, nombre, apellido, email, telefono, fechaInscripcion, idNivel, fechaCambio, operacion, usuario, activo)
    SELECT i.idCliente, i.dni, i.nombre, i.apellido, i.email, i.telefono, i.fechaInscripcion, i.idNivel,
           GETDATE(), 'INSERT', ISNULL(CONVERT(varchar(50), SESSION_CONTEXT(N'usuario')), SUSER_SNAME()), 1
    FROM inserted i;
END
GO
CREATE TRIGGER [dbo].[TR_Cliente_Update] ON [dbo].[Cliente] AFTER UPDATE AS
BEGIN
    SET NOCOUNT ON;
    IF CONVERT(int, SESSION_CONTEXT(N'restaurando')) = 1 RETURN;

    DECLARE @cambiados TABLE (idCliente int PRIMARY KEY);
    INSERT INTO @cambiados (idCliente)
    SELECT i.idCliente
    FROM inserted i
    INNER JOIN deleted d ON d.idCliente = i.idCliente
    WHERE EXISTS (SELECT i.dni, i.nombre, i.apellido, i.email, i.telefono, i.fechaInscripcion, i.idNivel
                  EXCEPT
                  SELECT d.dni, d.nombre, d.apellido, d.email, d.telefono, d.fechaInscripcion, d.idNivel);

    UPDATE b SET activo = 0
    FROM [dbo].[BitacoraCambiosCliente] b
    INNER JOIN @cambiados c ON c.idCliente = b.idCliente
    WHERE b.activo = 1;

    INSERT INTO [dbo].[BitacoraCambiosCliente] (idCliente, dni, nombre, apellido, email, telefono, fechaInscripcion, idNivel, fechaCambio, operacion, usuario, activo)
    SELECT i.idCliente, i.dni, i.nombre, i.apellido, i.email, i.telefono, i.fechaInscripcion, i.idNivel,
           GETDATE(), 'UPDATE', ISNULL(CONVERT(varchar(50), SESSION_CONTEXT(N'usuario')), SUSER_SNAME()), 1
    FROM inserted i
    INNER JOIN @cambiados c ON c.idCliente = i.idCliente;
END
GO
USE [master]
GO
ALTER DATABASE [LeMarchant_DB] SET  READ_WRITE 
GO
