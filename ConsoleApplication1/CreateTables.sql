USE [Search]

/****** Object:  Table [dbo].[base_social]    Script Date: 03/11/2015 10:15:49 ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[base_social](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SUITABILIT] [nvarchar](255) NULL,
	[OCCUP_MALE] [nvarchar](255) NULL,
	[OCCUP_FEMA] [nvarchar](255) NULL,
	[DELETE] [nvarchar](255) NULL,
	[geom] [geometry] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

/****** Object:  Table [dbo].[base_risk]    Script Date: 03/11/2015 10:15:49 ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[base_risk](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CLASS] [nvarchar](255) NULL,
	[Risk] [float] NULL,
	[geom] [geometry] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

/****** Object:  Table [dbo].[base_release]    Script Date: 03/11/2015 10:15:49 ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[base_release](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RELEASESIT] [real] NULL,
	[MALES] [real] NULL,
	[FEMS] [real] NULL,
	[geom] [geometry] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

/****** Object:  Table [dbo].[base_move]    Script Date: 03/11/2015 10:15:49 ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[base_move](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CLASS] [nvarchar](255) NULL,
	[MVL] [float] NULL,
	[MSL] [bigint] NULL,
	[ENERGYUSED] [float] NULL,
	[CROSSING] [float] NULL,
	[PR_X] [float] NULL,
	[geom] [geometry] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

/****** Object:  Table [dbo].[base_food]    Script Date: 03/11/2015 10:15:49 ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[base_food](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CLASS] [nvarchar](255) NULL,
	[PROBCAP] [float] NULL,
	[X_SIZE] [bigint] NULL,
	[SD_SIZE] [bigint] NULL,
	[geom] [geometry] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

/****** Object:  Table [dbo].[AnimalPath]    Script Date: 03/11/2015 10:15:49 ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[AnimalPath](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CurrLocation] [geometry] NOT NULL,
	[TimeStep] [int] NOT NULL,
	[AnimalID] [int] NOT NULL,
	[Suitable] [bit] NULL
) ON [PRIMARY]

/****** Object:  Table [dbo].[Animal]    Script Date: 03/11/2015 10:15:49 ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

SET ANSI_PADDING ON

CREATE TABLE [dbo].[Animal](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Sex] [varchar](10) NULL,
	[CurrLocation] [geometry] NULL
) ON [PRIMARY]

SET ANSI_PADDING OFF

