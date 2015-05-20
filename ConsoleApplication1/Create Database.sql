﻿USE [master]


/****** Object:  Database [Search]    Script Date: 03/11/2015 10:07:59 ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'Search')
DROP DATABASE [Search]


USE [master]


/****** Object:  Database [Search]    Script Date: 03/11/2015 10:07:59 ******/
CREATE DATABASE [Search] ON  PRIMARY 
( NAME = N'Search', FILENAME = N'C:\temp\expressSearch.mdf' , SIZE = 7168KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Search_log', FILENAME = N'C:\temp\expressSearch.ldf' , SIZE = 2816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)


/*ALTER DATABASE [Search] SET COMPATIBILITY_LEVEL = 100
GO*/

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Search].[dbo].[sp_fulltext_database] @action = 'enable'
end


ALTER DATABASE [Search] SET ANSI_NULL_DEFAULT OFF 


ALTER DATABASE [Search] SET ANSI_NULLS OFF 


ALTER DATABASE [Search] SET ANSI_PADDING OFF 

ALTER DATABASE [Search] SET ANSI_WARNINGS OFF 

ALTER DATABASE [Search] SET ARITHABORT OFF 


ALTER DATABASE [Search] SET AUTO_CLOSE OFF 

ALTER DATABASE [Search] SET AUTO_CREATE_STATISTICS ON 

ALTER DATABASE [Search] SET AUTO_SHRINK OFF 

ALTER DATABASE [Search] SET AUTO_UPDATE_STATISTICS ON 

ALTER DATABASE [Search] SET CURSOR_CLOSE_ON_COMMIT OFF 

ALTER DATABASE [Search] SET CURSOR_DEFAULT  GLOBAL 

ALTER DATABASE [Search] SET CONCAT_NULL_YIELDS_NULL OFF 

ALTER DATABASE [Search] SET NUMERIC_ROUNDABORT OFF 

ALTER DATABASE [Search] SET QUOTED_IDENTIFIER OFF 

ALTER DATABASE [Search] SET RECURSIVE_TRIGGERS OFF 

ALTER DATABASE [Search] SET  DISABLE_BROKER 

ALTER DATABASE [Search] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 

ALTER DATABASE [Search] SET DATE_CORRELATION_OPTIMIZATION OFF 

ALTER DATABASE [Search] SET TRUSTWORTHY OFF 

ALTER DATABASE [Search] SET ALLOW_SNAPSHOT_ISOLATION OFF 

ALTER DATABASE [Search] SET PARAMETERIZATION SIMPLE 

ALTER DATABASE [Search] SET READ_COMMITTED_SNAPSHOT OFF 



ALTER DATABASE [Search] SET  READ_WRITE 
GO

ALTER DATABASE [Search] SET RECOVERY FULL 
GO

ALTER DATABASE [Search] SET  MULTI_USER 
GO

ALTER DATABASE [Search] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Search] SET DB_CHAINING OFF 
GO

