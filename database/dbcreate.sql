create database peopleAPI
GO

create login peopleAPI with password = 'myP@ssw0rd'
GO

use peopleAPI;
create user peopleAPI for login peopleAPI
GO

EXEC sp_addrolemember N'db_owner', N'peopleAPI'
GO

USE [peopleAPI]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 6/4/2018 6:44:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[personId] [uniqueidentifier] NOT NULL,
	[firstName] [varchar](100) NOT NULL,
	[middleName] [varchar](50) NULL,
	[lastName] [varchar](100) NOT NULL,
	[Address] [varchar](100) NULL,
	[City] [varchar](50) NULL,
	[State] [varchar](50) NULL,
	[zipCode] [varchar](10) NULL,
	[workPhone] [varchar](12) NULL,
	[cellPhone] [varchar](12) NULL,
	[email] [varchar](250) NULL,
	[twitter] [varchar](100) NULL,
	[linkedin] [varchar](100) NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[personId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Person] ([personId], [firstName], [middleName], [lastName], [Address], [City], [State], [zipCode], [workPhone], [cellPhone], [email], [twitter], [linkedin]) VALUES (N'71ab7dfc-953f-4821-b221-dcb3cf135068', N'Dale', N'Edward', N'Bingham', NULL, N'Owings', N'Maryland', N'20736', N'301-555-1212', N'240-555-1212', N'dale.bingham@gmail.com', N'dale_bingham', N'DaleBingham')
/****** Object:  Index [IX_Person]    Script Date: 6/4/2018 6:44:35 AM ******/
CREATE NONCLUSTERED INDEX [IX_Person] ON [dbo].[Person]
(
	[personId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Person_lastname]    Script Date: 6/4/2018 6:44:35 AM ******/
CREATE NONCLUSTERED INDEX [IX_Person_lastname] ON [dbo].[Person]
(
	[lastName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Person_state]    Script Date: 6/4/2018 6:44:35 AM ******/
CREATE NONCLUSTERED INDEX [IX_Person_state] ON [dbo].[Person]
(
	[State] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
