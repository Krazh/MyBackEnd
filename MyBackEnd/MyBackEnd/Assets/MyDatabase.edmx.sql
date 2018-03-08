
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/08/2018 15:03:43
-- Generated from EDMX file: D:\Code Projects\MyBackEnd\MyBackEnd\MyBackEnd\Assets\MyDatabase.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SalesComm];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserAccessRights]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserSet] DROP CONSTRAINT [FK_UserAccessRights];
GO
IF OBJECT_ID(N'[dbo].[FK_ItemBrand]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ItemSet] DROP CONSTRAINT [FK_ItemBrand];
GO
IF OBJECT_ID(N'[dbo].[FK_BusinessTypeAss]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BusinessSet] DROP CONSTRAINT [FK_BusinessTypeAss];
GO
IF OBJECT_ID(N'[dbo].[FK_ChainBusiness]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BusinessSet] DROP CONSTRAINT [FK_ChainBusiness];
GO
IF OBJECT_ID(N'[dbo].[FK_UserBusiness]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserSet] DROP CONSTRAINT [FK_UserBusiness];
GO
IF OBJECT_ID(N'[dbo].[FK_CampaignItemCampaign]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ItemCampaignSet] DROP CONSTRAINT [FK_CampaignItemCampaign];
GO
IF OBJECT_ID(N'[dbo].[FK_UserCampaign]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CampaignSet] DROP CONSTRAINT [FK_UserCampaign];
GO
IF OBJECT_ID(N'[dbo].[FK_ErrorUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ErrorSet] DROP CONSTRAINT [FK_ErrorUser];
GO
IF OBJECT_ID(N'[dbo].[FK_ItemCampaignItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ItemCampaignSet] DROP CONSTRAINT [FK_ItemCampaignItem];
GO
IF OBJECT_ID(N'[dbo].[FK_ChainCampaign_CampaignSet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChainCampaign] DROP CONSTRAINT [FK_ChainCampaign_CampaignSet];
GO
IF OBJECT_ID(N'[dbo].[FK_ChainCampaign_ChainSet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChainCampaign] DROP CONSTRAINT [FK_ChainCampaign_ChainSet];
GO
IF OBJECT_ID(N'[dbo].[FK_ItemBusiness_BusinessSet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ItemBusiness] DROP CONSTRAINT [FK_ItemBusiness_BusinessSet];
GO
IF OBJECT_ID(N'[dbo].[FK_ItemBusiness_ItemSet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ItemBusiness] DROP CONSTRAINT [FK_ItemBusiness_ItemSet];
GO
IF OBJECT_ID(N'[dbo].[FK_CityBusiness]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BusinessSet] DROP CONSTRAINT [FK_CityBusiness];
GO
IF OBJECT_ID(N'[dbo].[FK_CityUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserSet] DROP CONSTRAINT [FK_CityUser];
GO
IF OBJECT_ID(N'[dbo].[FK_CityChain]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChainSet] DROP CONSTRAINT [FK_CityChain];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AccessRightsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccessRightsSet];
GO
IF OBJECT_ID(N'[dbo].[BrandSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BrandSet];
GO
IF OBJECT_ID(N'[dbo].[BusinessSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BusinessSet];
GO
IF OBJECT_ID(N'[dbo].[BusinessTypeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BusinessTypeSet];
GO
IF OBJECT_ID(N'[dbo].[CampaignSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CampaignSet];
GO
IF OBJECT_ID(N'[dbo].[ChainSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChainSet];
GO
IF OBJECT_ID(N'[dbo].[ErrorSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ErrorSet];
GO
IF OBJECT_ID(N'[dbo].[ItemCampaignSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ItemCampaignSet];
GO
IF OBJECT_ID(N'[dbo].[ItemSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ItemSet];
GO
IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO
IF OBJECT_ID(N'[dbo].[Cities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cities];
GO
IF OBJECT_ID(N'[dbo].[ChainCampaign]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChainCampaign];
GO
IF OBJECT_ID(N'[dbo].[ItemBusiness]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ItemBusiness];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AccessRightsSet'
CREATE TABLE [dbo].[AccessRightsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [Level] int  NOT NULL
);
GO

-- Creating table 'BrandSet'
CREATE TABLE [dbo].[BrandSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [ImgURL] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'BusinessSet'
CREATE TABLE [dbo].[BusinessSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [BusinessTypeId] int  NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [CVR] nvarchar(max)  NULL,
    [ChainId] int  NOT NULL,
    [CityId] int  NOT NULL
);
GO

-- Creating table 'BusinessTypeSet'
CREATE TABLE [dbo].[BusinessTypeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CampaignSet'
CREATE TABLE [dbo].[CampaignSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StartDate] datetime  NOT NULL,
    [EndDate] datetime  NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [DateCreated] datetime  NOT NULL,
    [CreatedByUserId] int  NOT NULL
);
GO

-- Creating table 'ChainSet'
CREATE TABLE [dbo].[ChainSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [ProMode] bit  NOT NULL,
    [Address] nvarchar(max)  NULL,
    [CityId] int  NOT NULL
);
GO

-- Creating table 'ErrorSet'
CREATE TABLE [dbo].[ErrorSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProcessName] nvarchar(max)  NOT NULL,
    [Page] nvarchar(max)  NULL,
    [Message] nvarchar(max)  NOT NULL,
    [Time] datetime  NOT NULL,
    [UserId] int  NOT NULL
);
GO

-- Creating table 'ItemCampaignSet'
CREATE TABLE [dbo].[ItemCampaignSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ItemId] int  NOT NULL,
    [CampaignId] int  NOT NULL,
    [Discount] int  NOT NULL,
    [Description] nvarchar(max)  NULL
);
GO

-- Creating table 'ItemSet'
CREATE TABLE [dbo].[ItemSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [ImgURL] nvarchar(max)  NOT NULL,
    [BrandId] int  NOT NULL,
    [ProOnly] bit  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Price] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AccessRightsId] int  NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NULL,
    [PhoneNumber] nvarchar(max)  NOT NULL,
    [BusinessId] int  NULL,
    [FullName] nvarchar(max)  NOT NULL,
    [UserName] nvarchar(max)  NULL,
    [Email] nvarchar(max)  NULL,
    [CityId] int  NULL,
    [PasswordId] int  NULL
);
GO

-- Creating table 'Cities'
CREATE TABLE [dbo].[Cities] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [ZipCode] nvarchar(max)  NOT NULL,
    [Country] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Passwords'
CREATE TABLE [dbo].[Passwords] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Hash] nvarchar(max)  NOT NULL,
    [UserId] nvarchar(max)  NOT NULL,
    [DateCreated] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ChainCampaign'
CREATE TABLE [dbo].[ChainCampaign] (
    [CampaignSet_Id] int  NOT NULL,
    [ChainSet_Id] int  NOT NULL
);
GO

-- Creating table 'ItemBusiness'
CREATE TABLE [dbo].[ItemBusiness] (
    [BusinessSet_Id] int  NOT NULL,
    [ItemSet_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'AccessRightsSet'
ALTER TABLE [dbo].[AccessRightsSet]
ADD CONSTRAINT [PK_AccessRightsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BrandSet'
ALTER TABLE [dbo].[BrandSet]
ADD CONSTRAINT [PK_BrandSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BusinessSet'
ALTER TABLE [dbo].[BusinessSet]
ADD CONSTRAINT [PK_BusinessSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BusinessTypeSet'
ALTER TABLE [dbo].[BusinessTypeSet]
ADD CONSTRAINT [PK_BusinessTypeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CampaignSet'
ALTER TABLE [dbo].[CampaignSet]
ADD CONSTRAINT [PK_CampaignSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ChainSet'
ALTER TABLE [dbo].[ChainSet]
ADD CONSTRAINT [PK_ChainSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ErrorSet'
ALTER TABLE [dbo].[ErrorSet]
ADD CONSTRAINT [PK_ErrorSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ItemCampaignSet'
ALTER TABLE [dbo].[ItemCampaignSet]
ADD CONSTRAINT [PK_ItemCampaignSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ItemSet'
ALTER TABLE [dbo].[ItemSet]
ADD CONSTRAINT [PK_ItemSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Cities'
ALTER TABLE [dbo].[Cities]
ADD CONSTRAINT [PK_Cities]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Passwords'
ALTER TABLE [dbo].[Passwords]
ADD CONSTRAINT [PK_Passwords]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [CampaignSet_Id], [ChainSet_Id] in table 'ChainCampaign'
ALTER TABLE [dbo].[ChainCampaign]
ADD CONSTRAINT [PK_ChainCampaign]
    PRIMARY KEY CLUSTERED ([CampaignSet_Id], [ChainSet_Id] ASC);
GO

-- Creating primary key on [BusinessSet_Id], [ItemSet_Id] in table 'ItemBusiness'
ALTER TABLE [dbo].[ItemBusiness]
ADD CONSTRAINT [PK_ItemBusiness]
    PRIMARY KEY CLUSTERED ([BusinessSet_Id], [ItemSet_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AccessRightsId] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [FK_UserAccessRights]
    FOREIGN KEY ([AccessRightsId])
    REFERENCES [dbo].[AccessRightsSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserAccessRights'
CREATE INDEX [IX_FK_UserAccessRights]
ON [dbo].[UserSet]
    ([AccessRightsId]);
GO

-- Creating foreign key on [BrandId] in table 'ItemSet'
ALTER TABLE [dbo].[ItemSet]
ADD CONSTRAINT [FK_ItemBrand]
    FOREIGN KEY ([BrandId])
    REFERENCES [dbo].[BrandSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ItemBrand'
CREATE INDEX [IX_FK_ItemBrand]
ON [dbo].[ItemSet]
    ([BrandId]);
GO

-- Creating foreign key on [BusinessTypeId] in table 'BusinessSet'
ALTER TABLE [dbo].[BusinessSet]
ADD CONSTRAINT [FK_BusinessTypeAss]
    FOREIGN KEY ([BusinessTypeId])
    REFERENCES [dbo].[BusinessTypeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BusinessTypeAss'
CREATE INDEX [IX_FK_BusinessTypeAss]
ON [dbo].[BusinessSet]
    ([BusinessTypeId]);
GO

-- Creating foreign key on [ChainId] in table 'BusinessSet'
ALTER TABLE [dbo].[BusinessSet]
ADD CONSTRAINT [FK_ChainBusiness]
    FOREIGN KEY ([ChainId])
    REFERENCES [dbo].[ChainSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ChainBusiness'
CREATE INDEX [IX_FK_ChainBusiness]
ON [dbo].[BusinessSet]
    ([ChainId]);
GO

-- Creating foreign key on [BusinessId] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [FK_UserBusiness]
    FOREIGN KEY ([BusinessId])
    REFERENCES [dbo].[BusinessSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserBusiness'
CREATE INDEX [IX_FK_UserBusiness]
ON [dbo].[UserSet]
    ([BusinessId]);
GO

-- Creating foreign key on [CampaignId] in table 'ItemCampaignSet'
ALTER TABLE [dbo].[ItemCampaignSet]
ADD CONSTRAINT [FK_CampaignItemCampaign]
    FOREIGN KEY ([CampaignId])
    REFERENCES [dbo].[CampaignSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CampaignItemCampaign'
CREATE INDEX [IX_FK_CampaignItemCampaign]
ON [dbo].[ItemCampaignSet]
    ([CampaignId]);
GO

-- Creating foreign key on [CreatedByUserId] in table 'CampaignSet'
ALTER TABLE [dbo].[CampaignSet]
ADD CONSTRAINT [FK_UserCampaign]
    FOREIGN KEY ([CreatedByUserId])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserCampaign'
CREATE INDEX [IX_FK_UserCampaign]
ON [dbo].[CampaignSet]
    ([CreatedByUserId]);
GO

-- Creating foreign key on [UserId] in table 'ErrorSet'
ALTER TABLE [dbo].[ErrorSet]
ADD CONSTRAINT [FK_ErrorUser]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ErrorUser'
CREATE INDEX [IX_FK_ErrorUser]
ON [dbo].[ErrorSet]
    ([UserId]);
GO

-- Creating foreign key on [ItemId] in table 'ItemCampaignSet'
ALTER TABLE [dbo].[ItemCampaignSet]
ADD CONSTRAINT [FK_ItemCampaignItem]
    FOREIGN KEY ([ItemId])
    REFERENCES [dbo].[ItemSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ItemCampaignItem'
CREATE INDEX [IX_FK_ItemCampaignItem]
ON [dbo].[ItemCampaignSet]
    ([ItemId]);
GO

-- Creating foreign key on [CampaignSet_Id] in table 'ChainCampaign'
ALTER TABLE [dbo].[ChainCampaign]
ADD CONSTRAINT [FK_ChainCampaign_CampaignSet]
    FOREIGN KEY ([CampaignSet_Id])
    REFERENCES [dbo].[CampaignSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ChainSet_Id] in table 'ChainCampaign'
ALTER TABLE [dbo].[ChainCampaign]
ADD CONSTRAINT [FK_ChainCampaign_ChainSet]
    FOREIGN KEY ([ChainSet_Id])
    REFERENCES [dbo].[ChainSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ChainCampaign_ChainSet'
CREATE INDEX [IX_FK_ChainCampaign_ChainSet]
ON [dbo].[ChainCampaign]
    ([ChainSet_Id]);
GO

-- Creating foreign key on [BusinessSet_Id] in table 'ItemBusiness'
ALTER TABLE [dbo].[ItemBusiness]
ADD CONSTRAINT [FK_ItemBusiness_BusinessSet]
    FOREIGN KEY ([BusinessSet_Id])
    REFERENCES [dbo].[BusinessSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ItemSet_Id] in table 'ItemBusiness'
ALTER TABLE [dbo].[ItemBusiness]
ADD CONSTRAINT [FK_ItemBusiness_ItemSet]
    FOREIGN KEY ([ItemSet_Id])
    REFERENCES [dbo].[ItemSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ItemBusiness_ItemSet'
CREATE INDEX [IX_FK_ItemBusiness_ItemSet]
ON [dbo].[ItemBusiness]
    ([ItemSet_Id]);
GO

-- Creating foreign key on [CityId] in table 'BusinessSet'
ALTER TABLE [dbo].[BusinessSet]
ADD CONSTRAINT [FK_CityBusiness]
    FOREIGN KEY ([CityId])
    REFERENCES [dbo].[Cities]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CityBusiness'
CREATE INDEX [IX_FK_CityBusiness]
ON [dbo].[BusinessSet]
    ([CityId]);
GO

-- Creating foreign key on [CityId] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [FK_CityUser]
    FOREIGN KEY ([CityId])
    REFERENCES [dbo].[Cities]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CityUser'
CREATE INDEX [IX_FK_CityUser]
ON [dbo].[UserSet]
    ([CityId]);
GO

-- Creating foreign key on [CityId] in table 'ChainSet'
ALTER TABLE [dbo].[ChainSet]
ADD CONSTRAINT [FK_CityChain]
    FOREIGN KEY ([CityId])
    REFERENCES [dbo].[Cities]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CityChain'
CREATE INDEX [IX_FK_CityChain]
ON [dbo].[ChainSet]
    ([CityId]);
GO

-- Creating foreign key on [PasswordId] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [FK_PasswordUser]
    FOREIGN KEY ([PasswordId])
    REFERENCES [dbo].[Passwords]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PasswordUser'
CREATE INDEX [IX_FK_PasswordUser]
ON [dbo].[UserSet]
    ([PasswordId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------