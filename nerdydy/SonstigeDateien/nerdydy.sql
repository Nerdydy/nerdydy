/* ---------------------------------------------------- */
/*  Generated by Enterprise Architect Version 12.0 		*/
/*  Created On : 11-Feb-2018 12:25:26 				*/
/*  DBMS       : SQL Server 2012 						*/
/* ---------------------------------------------------- */

/* Drop Foreign Key Constraints */

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_UserRole_Role]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [UserRole] DROP CONSTRAINT [FK_UserRole_Role]
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_UserRole_User]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [UserRole] DROP CONSTRAINT [FK_UserRole_User]
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_GameMedia_Game]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [GameMedia] DROP CONSTRAINT [FK_GameMedia_Game]
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_GameMedia_MediaType]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [GameMedia] DROP CONSTRAINT [FK_GameMedia_MediaType]
GO

/* Drop Tables */

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[UserRole]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [UserRole]
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[User]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [User]
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Role]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Role]
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[MediaType]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [MediaType]
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[GameMedia]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [GameMedia]
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Game]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Game]
GO

/* Create Tables */

CREATE TABLE [UserRole]
(
	[UserID] nvarchar(128) NOT NULL,
	[RoleID] nvarchar(128) NOT NULL,
	[Id] nvarchar(128) NULL
)
GO

CREATE TABLE [User]
(
	[Id] nvarchar(128) NOT NULL,
	[Firstname] nvarchar(256) NOT NULL,
	[Name] nvarchar(256) NOT NULL,
	[Email] nvarchar(256) NOT NULL,
	[PasswordHash] nvarchar(max) NOT NULL,
	[UserName] nvarchar(256) NOT NULL
)
GO

CREATE TABLE [Role]
(
	[Id] nvarchar(128) NOT NULL,
	[Name] nvarchar(256) NOT NULL
)
GO

CREATE TABLE [MediaType]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[Name] nvarchar(256) NOT NULL
)
GO

CREATE TABLE [GameMedia]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[Name] nvarchar(256) NOT NULL,
	[Description] nvarchar(max) NULL,
	[Date] date NOT NULL,
	[Filepath] nvarchar(max) NOT NULL,
	[MediaTypeId] int NOT NULL,
	[GameId] int NOT NULL
)
GO

CREATE TABLE [Game]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[Name] nvarchar(256) NOT NULL,
	[Description] nvarchar(max) NOT NULL
)
GO

/* Create Primary Keys, Indexes, Uniques, Checks */

ALTER TABLE [UserRole] 
 ADD CONSTRAINT [PK_UserRole]
	PRIMARY KEY CLUSTERED ([UserID],[RoleID])
GO

CREATE INDEX [IXFK_UserRole_Role] 
 ON [UserRole] ([Id] ASC)
GO

CREATE INDEX [IXFK_UserRole_User] 
 ON [UserRole] ([Id] ASC)
GO

ALTER TABLE [User] 
 ADD CONSTRAINT [PK_User]
	PRIMARY KEY CLUSTERED ([Id])
GO

ALTER TABLE [Role] 
 ADD CONSTRAINT [PK_Role]
	PRIMARY KEY CLUSTERED ([Id])
GO

ALTER TABLE [MediaType] 
 ADD CONSTRAINT [PK_MediaType]
	PRIMARY KEY CLUSTERED ([Id])
GO

ALTER TABLE [GameMedia] 
 ADD CONSTRAINT [PK_GameMedia]
	PRIMARY KEY CLUSTERED ([Id])
GO

CREATE INDEX [IXFK_GameMedia_Game] 
 ON [GameMedia] ([Id] ASC)
GO

CREATE INDEX [IXFK_GameMedia_MediaType] 
 ON [GameMedia] ([Id] ASC)
GO

ALTER TABLE [Game] 
 ADD CONSTRAINT [PK_Game]
	PRIMARY KEY CLUSTERED ([Id])
GO

/* Create Foreign Key Constraints */

ALTER TABLE [UserRole] ADD CONSTRAINT [FK_UserRole_Role]
	FOREIGN KEY ([Id]) REFERENCES [Role] ([Id]) ON DELETE No Action ON UPDATE Cascade
GO

ALTER TABLE [UserRole] ADD CONSTRAINT [FK_UserRole_User]
	FOREIGN KEY ([Id]) REFERENCES [User] ([Id]) ON DELETE No Action ON UPDATE Cascade
GO

ALTER TABLE [GameMedia] ADD CONSTRAINT [FK_GameMedia_Game]
	FOREIGN KEY ([Id]) REFERENCES [Game] ([Id]) ON DELETE No Action ON UPDATE Cascade
GO

ALTER TABLE [GameMedia] ADD CONSTRAINT [FK_GameMedia_MediaType]
	FOREIGN KEY ([Id]) REFERENCES [MediaType] ([Id]) ON DELETE No Action ON UPDATE Cascade
GO
