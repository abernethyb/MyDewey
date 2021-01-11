USE [master]

IF db_id('MyDewey') IS NULl
  CREATE DATABASE [MyDewey]
GO

USE [MyDewey]
GO

DROP TABLE IF EXISTS [UserProfile];
DROP TABLE IF EXISTS [Friend];
DROP TABLE IF EXISTS [UserType];
DROP TABLE IF EXISTS [Category];
DROP TABLE IF EXISTS [Item];
DROP TABLE IF EXISTS [Checkout];
DROP TABLE IF EXISTS [CheckoutRemark];
DROP TABLE IF EXISTS [Message];
DROP TABLE IF EXISTS [AdminMessage];
GO

CREATE TABLE [UserProfile] (
  [Id] integer PRIMARY KEY IDENTITY,
  [FirebaseUserId] nvarchar(28) NOT NULL,
  [UserTypeId] integer NOT NULL,
  [Username] nvarchar(255) NOT NULL,
  [FirstName] nvarchar(255),
  [LastName] nvarchar(255),
  [Image] nvarchar(4000),
  [Email] nvarchar(255) NOT NULL,
  [City] nvarchar(255) NOT NULL,
  [Region] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [Friend] (
  [Id] integer PRIMARY KEY IDENTITY,
  [RequestingUserProfileId] integer NOT NULL,
  [AcceptingUserProfileId] integer NOT NULL,
  [RequestDate] datetime NOT NULL,
  [BeginDate] datetime,
  [EndDate] datetime
)
GO

CREATE TABLE [UserType] (
  [Id] integer PRIMARY KEY IDENTITY,
  [Name] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [Category] (
  [Id] integer PRIMARY KEY IDENTITY,
  [Name] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [Item] (
  [Id] integer PRIMARY KEY IDENTITY,
  [UserProfileId] integer NOT NULL,
  [CategoryId] integer NOT NULL,
  [Available] boolean,
  [Private] boolean,
  [Image] nvarchar(4000),
  [Name] nvarchar(255),
  [Author] nvarchar(255),
  [Maker] nvarchar(255),
  [Model] nvarchar(255),
  [YearMade] integer,
  [notes] nvarchar(255),
  [ExternalId] nvarchar(255)
)
GO

CREATE TABLE [Checkout] (
  [Id] integer PRIMARY KEY IDENTITY,
  [UserProfileId] integer NOT NULL,
  [ItemId] integer NOT NULL,
  [RequestDate] datetime NOT NULL,
  [CheckoutDate] datetime,
  [DueDate] datetime,
  [CheckinDate] datetime,
  [ReturnVerifiedDate] datetime,
  [Declined] boolean,
  [Hidden] boolean
)
GO

CREATE TABLE [CheckoutRemark] (
  [Id] integer PRIMARY KEY IDENTITY,
  [UserProfileId] integer NOT NULL,
  [CheckoutId] integer NOT NULL,
  [Datetime] datetime NOT NULL,
  [Image] nvarchar(4000),
  [Remark] nvarchar(4000) NOT NULL
)
GO

CREATE TABLE [CheckoutMessage] (
  [Id] integer PRIMARY KEY IDENTITY,
  [UserProfileId] integer NOT NULL,
  [CheckoutId] integer NOT NULL,
  [Datetime] datetime NOT NULL,
  [Content] nvarchar(4000) NOT NULL
)
GO

CREATE TABLE [AdminMessage] (
  [Id] integer PRIMARY KEY IDENTITY,
  [UserProfileId] integer NOT NULL,
  [Datetime] datetime NOT NULL,
  [Content] nvarchar(4000) NOT NULL
)
GO

ALTER TABLE [Item] ADD FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id])
GO

ALTER TABLE [UserProfile] ADD FOREIGN KEY ([UserTypeId]) REFERENCES [UserType] ([Id])
GO

ALTER TABLE [Item] ADD FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([Id])
GO

ALTER TABLE [CheckoutRemark] ADD FOREIGN KEY ([CheckoutId]) REFERENCES [Checkout] ([Id])
GO

ALTER TABLE [CheckoutMessage] ADD FOREIGN KEY ([CheckoutId]) REFERENCES [Checkout] ([Id])
GO

ALTER TABLE [Checkout] ADD FOREIGN KEY ([ItemId]) REFERENCES [Item] ([Id])
GO

ALTER TABLE [Checkout] ADD FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id])
GO

ALTER TABLE [CheckoutRemark] ADD FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id])
GO

ALTER TABLE [CheckoutMessage] ADD FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id])
GO

ALTER TABLE [Friend] ADD FOREIGN KEY ([RequestingUserProfileId]) REFERENCES [UserProfile] ([Id])
GO

ALTER TABLE [Friend] ADD FOREIGN KEY ([AcceptingUserProfileId]) REFERENCES [UserProfile] ([Id])
GO

ALTER TABLE [AdminMessage] ADD FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id])
GO
