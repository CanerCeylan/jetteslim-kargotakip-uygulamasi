USE [master]
GO
/****** Object:  Database [DbKargoTakip]    Script Date: 13.09.2023 20:44:57 ******/
CREATE DATABASE [DbKargoTakip]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DbKargoTakip', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DbKargoTakip.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DbKargoTakip_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DbKargoTakip_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 COLLATE Turkish_CI_AS
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DbKargoTakip] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DbKargoTakip].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DbKargoTakip] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DbKargoTakip] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DbKargoTakip] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DbKargoTakip] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DbKargoTakip] SET ARITHABORT OFF 
GO
ALTER DATABASE [DbKargoTakip] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DbKargoTakip] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DbKargoTakip] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DbKargoTakip] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DbKargoTakip] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DbKargoTakip] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DbKargoTakip] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DbKargoTakip] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DbKargoTakip] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DbKargoTakip] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DbKargoTakip] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DbKargoTakip] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DbKargoTakip] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DbKargoTakip] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DbKargoTakip] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DbKargoTakip] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DbKargoTakip] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DbKargoTakip] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DbKargoTakip] SET  MULTI_USER 
GO
ALTER DATABASE [DbKargoTakip] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DbKargoTakip] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DbKargoTakip] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DbKargoTakip] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DbKargoTakip] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DbKargoTakip] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [DbKargoTakip] SET QUERY_STORE = OFF
GO
USE [DbKargoTakip]
GO
/****** Object:  Table [dbo].[Adres]    Script Date: 13.09.2023 20:44:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Adres](
	[il] [nvarchar](50) COLLATE Turkish_CI_AS NOT NULL,
	[ilçe] [nvarchar](50) COLLATE Turkish_CI_AS NOT NULL,
	[semt_bucak_belde] [nvarchar](50) COLLATE Turkish_CI_AS NOT NULL,
	[Mahalle] [nvarchar](100) COLLATE Turkish_CI_AS NOT NULL,
	[PK] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Çalışan]    Script Date: 13.09.2023 20:44:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Çalışan](
	[çalışanId] [int] IDENTITY(1,1) NOT NULL,
	[çalışanAd] [nvarchar](50) COLLATE Turkish_CI_AS NOT NULL,
	[çalışanSoyad] [nvarchar](50) COLLATE Turkish_CI_AS NOT NULL,
	[çalışanTelefon] [nvarchar](20) COLLATE Turkish_CI_AS NOT NULL,
	[çalışanEmail] [nvarchar](50) COLLATE Turkish_CI_AS NOT NULL,
	[TCNo] [nvarchar](20) COLLATE Turkish_CI_AS NOT NULL,
	[çalışanParola] [nvarchar](50) COLLATE Turkish_CI_AS NOT NULL,
	[doğumTarihi] [nvarchar](20) COLLATE Turkish_CI_AS NOT NULL,
	[pozisyon] [nvarchar](50) COLLATE Turkish_CI_AS NOT NULL,
	[çalışanİl] [nvarchar](50) COLLATE Turkish_CI_AS NOT NULL,
	[çalışanİlçe] [nvarchar](50) COLLATE Turkish_CI_AS NOT NULL,
	[çalışanMahalle] [nvarchar](100) COLLATE Turkish_CI_AS NOT NULL,
	[çalışanSokak] [nvarchar](100) COLLATE Turkish_CI_AS NOT NULL,
	[çalışanBinaNo] [nvarchar](10) COLLATE Turkish_CI_AS NOT NULL,
	[çalışanDaire] [nvarchar](10) COLLATE Turkish_CI_AS NOT NULL,
	[çalışanAktif] [bit] NOT NULL,
	[çalışanŞube] [int] NOT NULL,
 CONSTRAINT [PK_Çalışan] PRIMARY KEY CLUSTERED 
(
	[çalışanId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gönderi]    Script Date: 13.09.2023 20:44:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gönderi](
	[kargoTakipNo] [nvarchar](50) COLLATE Turkish_CI_AS NOT NULL,
	[göndericiAdı] [nvarchar](50) COLLATE Turkish_CI_AS NOT NULL,
	[göndericiSoyadı] [nvarchar](50) COLLATE Turkish_CI_AS NOT NULL,
	[göndericiTC] [nvarchar](20) COLLATE Turkish_CI_AS NOT NULL,
	[göndericiDoğum] [nvarchar](20) COLLATE Turkish_CI_AS NOT NULL,
	[göndericiTelefon] [nvarchar](20) COLLATE Turkish_CI_AS NOT NULL,
	[göndericiEmail] [nvarchar](50) COLLATE Turkish_CI_AS NOT NULL,
	[göndericiİl] [nvarchar](50) COLLATE Turkish_CI_AS NOT NULL,
	[göndericiİlçe] [nvarchar](50) COLLATE Turkish_CI_AS NOT NULL,
	[göndericiMahalle] [nvarchar](100) COLLATE Turkish_CI_AS NOT NULL,
	[göndericiSokak] [nvarchar](100) COLLATE Turkish_CI_AS NOT NULL,
	[göndericiBinaNo] [nvarchar](10) COLLATE Turkish_CI_AS NOT NULL,
	[göndericiDaire] [nvarchar](10) COLLATE Turkish_CI_AS NOT NULL,
	[alıcıAdı] [nvarchar](50) COLLATE Turkish_CI_AS NOT NULL,
	[alıcıSoyadı] [nvarchar](50) COLLATE Turkish_CI_AS NOT NULL,
	[alıcıTC] [nvarchar](20) COLLATE Turkish_CI_AS NOT NULL,
	[alıcıDoğum] [nvarchar](20) COLLATE Turkish_CI_AS NOT NULL,
	[alıcıTelefon] [nvarchar](20) COLLATE Turkish_CI_AS NOT NULL,
	[alıcıEmail] [nvarchar](50) COLLATE Turkish_CI_AS NOT NULL,
	[alıcıİl] [nvarchar](50) COLLATE Turkish_CI_AS NOT NULL,
	[alıcıİlçe] [nvarchar](50) COLLATE Turkish_CI_AS NOT NULL,
	[alıcıMahalle] [nvarchar](100) COLLATE Turkish_CI_AS NOT NULL,
	[alıcıSokak] [nvarchar](100) COLLATE Turkish_CI_AS NOT NULL,
	[alıcıBinaNo] [nvarchar](10) COLLATE Turkish_CI_AS NOT NULL,
	[alıcıDaire] [nvarchar](10) COLLATE Turkish_CI_AS NOT NULL,
	[çıkışŞubeId] [int] NOT NULL,
	[varışŞubeId] [int] NOT NULL,
	[şubedenTeslim] [bit] NOT NULL,
	[alıcıÖdemeli] [bit] NOT NULL,
	[ücret] [nvarchar](10) COLLATE Turkish_CI_AS NOT NULL,
	[girişTarihi] [smalldatetime] NOT NULL,
	[sonİşlemTarihi] [smalldatetime] NOT NULL,
	[durum] [nvarchar](50) COLLATE Turkish_CI_AS NOT NULL,
	[kuryeId] [int] NULL,
	[geriKabul] [bit] NOT NULL,
	[aktif] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Şube]    Script Date: 13.09.2023 20:44:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Şube](
	[şubeId] [int] IDENTITY(1,1) NOT NULL,
	[şubeAdı] [nvarchar](50) COLLATE Turkish_CI_AS NOT NULL,
	[telefon] [nvarchar](20) COLLATE Turkish_CI_AS NOT NULL,
	[il] [nvarchar](50) COLLATE Turkish_CI_AS NOT NULL,
	[ilçe] [nvarchar](50) COLLATE Turkish_CI_AS NOT NULL,
	[mahalle] [nvarchar](100) COLLATE Turkish_CI_AS NOT NULL,
	[sokak] [nvarchar](100) COLLATE Turkish_CI_AS NOT NULL,
	[binaNo] [nvarchar](10) COLLATE Turkish_CI_AS NOT NULL,
	[aktif] [bit] NOT NULL,
 CONSTRAINT [PK_Şube] PRIMARY KEY CLUSTERED 
(
	[şubeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [DbKargoTakip] SET  READ_WRITE 
GO
