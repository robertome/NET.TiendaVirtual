
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/11/2019 01:02:01
-- Generated from EDMX file: E:\UPM\MIW\workspace\NET\NET.TiendaVirtual\TiendaVirtualWeb\Data\TiendaVirtualDbContext.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
--USE [TiendaVirtualDb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Address_Street] nvarchar(max)  NOT NULL,
    [Address_City] nvarchar(max)  NOT NULL,
    [Address_Country] nvarchar(max)  NOT NULL,
    [Address_ZipCode] nvarchar(max)  NOT NULL,
    [Address_State] nvarchar(max)  NOT NULL,
    [Date] datetimeoffset  NOT NULL,
    [Price] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'Articles'
CREATE TABLE [dbo].[Articles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [PictureUri] nvarchar(max)  NOT NULL,
    [Price] decimal(18,0)  NOT NULL,
    [Stock] int  NOT NULL
);
GO

-- Creating table 'OrderItems'
CREATE TABLE [dbo].[OrderItems] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Quantity] int  NOT NULL,
    [UnitPrice] decimal(18,0)  NOT NULL,
    [Article_Id] int  NOT NULL,
    [OrderOrderItem_OrderItem_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Articles'
ALTER TABLE [dbo].[Articles]
ADD CONSTRAINT [PK_Articles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrderItems'
ALTER TABLE [dbo].[OrderItems]
ADD CONSTRAINT [PK_OrderItems]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Article_Id] in table 'OrderItems'
ALTER TABLE [dbo].[OrderItems]
ADD CONSTRAINT [FK_OrderItemArticle]
    FOREIGN KEY ([Article_Id])
    REFERENCES [dbo].[Articles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderItemArticle'
CREATE INDEX [IX_FK_OrderItemArticle]
ON [dbo].[OrderItems]
    ([Article_Id]);
GO

-- Creating foreign key on [OrderOrderItem_OrderItem_Id] in table 'OrderItems'
ALTER TABLE [dbo].[OrderItems]
ADD CONSTRAINT [FK_OrderOrderItem]
    FOREIGN KEY ([OrderOrderItem_OrderItem_Id])
    REFERENCES [dbo].[Orders]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderOrderItem'
CREATE INDEX [IX_FK_OrderOrderItem]
ON [dbo].[OrderItems]
    ([OrderOrderItem_OrderItem_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------