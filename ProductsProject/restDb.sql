USE [master]
GO

/****** Object:  Database [restaurantdb]    Script Date: 23/09/2022 03:31:06 PM ******/
CREATE DATABASE [restaurantdb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'restaurantdb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\restaurantdb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'restaurantdb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\restaurantdb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [restaurantdb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [restaurantdb] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [restaurantdb] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [restaurantdb] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [restaurantdb] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [restaurantdb] SET ARITHABORT OFF 
GO

ALTER DATABASE [restaurantdb] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [restaurantdb] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [restaurantdb] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [restaurantdb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [restaurantdb] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [restaurantdb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [restaurantdb] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [restaurantdb] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [restaurantdb] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [restaurantdb] SET  DISABLE_BROKER 
GO

ALTER DATABASE [restaurantdb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [restaurantdb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [restaurantdb] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [restaurantdb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [restaurantdb] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [restaurantdb] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [restaurantdb] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [restaurantdb] SET RECOVERY FULL 
GO

ALTER DATABASE [restaurantdb] SET  MULTI_USER 
GO

ALTER DATABASE [restaurantdb] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [restaurantdb] SET DB_CHAINING OFF 
GO

ALTER DATABASE [restaurantdb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [restaurantdb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [restaurantdb] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [restaurantdb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [restaurantdb] SET QUERY_STORE = OFF
GO

ALTER DATABASE [restaurantdb] SET  READ_WRITE 
GO
