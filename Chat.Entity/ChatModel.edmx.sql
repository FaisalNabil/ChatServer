
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/20/2017 13:11:08
-- Generated from EDMX file: F:\Codes\Chat Application\Chat\Chat.Entity\ChatModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ChatDB];
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

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserId] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(max)  NOT NULL,
    [UserEmail] nvarchar(max)  NOT NULL,
    [UserPassword] nvarchar(max)  NOT NULL,
    [dateCreated] nvarchar(max)  NOT NULL,
    [isActive] bit  NOT NULL
);
GO

-- Creating table 'Messages'
CREATE TABLE [dbo].[Messages] (
    [MessageId] int IDENTITY(1,1) NOT NULL,
    [SendDate] nvarchar(max)  NOT NULL,
    [MessageBody] nvarchar(max)  NOT NULL,
    [UserUserId] int  NOT NULL,
    [MessageThreadThreadId] int  NOT NULL
);
GO

-- Creating table 'MessageThreads'
CREATE TABLE [dbo].[MessageThreads] (
    [ThreadId] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'MessageReadStatus'
CREATE TABLE [dbo].[MessageReadStatus] (
    [MessageReadStatusId] int IDENTITY(1,1) NOT NULL,
    [ReadDate] nvarchar(max)  NOT NULL,
    [UserUserId] int  NOT NULL,
    [MessageMessageId] int  NOT NULL
);
GO

-- Creating table 'ThreadParticipants'
CREATE TABLE [dbo].[ThreadParticipants] (
    [ThreadParticipantId] int IDENTITY(1,1) NOT NULL,
    [UserUserId] int  NOT NULL,
    [MessageThreadThreadId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [UserId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [MessageId] in table 'Messages'
ALTER TABLE [dbo].[Messages]
ADD CONSTRAINT [PK_Messages]
    PRIMARY KEY CLUSTERED ([MessageId] ASC);
GO

-- Creating primary key on [ThreadId] in table 'MessageThreads'
ALTER TABLE [dbo].[MessageThreads]
ADD CONSTRAINT [PK_MessageThreads]
    PRIMARY KEY CLUSTERED ([ThreadId] ASC);
GO

-- Creating primary key on [MessageReadStatusId] in table 'MessageReadStatus'
ALTER TABLE [dbo].[MessageReadStatus]
ADD CONSTRAINT [PK_MessageReadStatus]
    PRIMARY KEY CLUSTERED ([MessageReadStatusId] ASC);
GO

-- Creating primary key on [ThreadParticipantId] in table 'ThreadParticipants'
ALTER TABLE [dbo].[ThreadParticipants]
ADD CONSTRAINT [PK_ThreadParticipants]
    PRIMARY KEY CLUSTERED ([ThreadParticipantId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserUserId] in table 'ThreadParticipants'
ALTER TABLE [dbo].[ThreadParticipants]
ADD CONSTRAINT [FK_UserThreadParticipant]
    FOREIGN KEY ([UserUserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserThreadParticipant'
CREATE INDEX [IX_FK_UserThreadParticipant]
ON [dbo].[ThreadParticipants]
    ([UserUserId]);
GO

-- Creating foreign key on [UserUserId] in table 'MessageReadStatus'
ALTER TABLE [dbo].[MessageReadStatus]
ADD CONSTRAINT [FK_UserMessageReadStatus]
    FOREIGN KEY ([UserUserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserMessageReadStatus'
CREATE INDEX [IX_FK_UserMessageReadStatus]
ON [dbo].[MessageReadStatus]
    ([UserUserId]);
GO

-- Creating foreign key on [UserUserId] in table 'Messages'
ALTER TABLE [dbo].[Messages]
ADD CONSTRAINT [FK_UserMessage]
    FOREIGN KEY ([UserUserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserMessage'
CREATE INDEX [IX_FK_UserMessage]
ON [dbo].[Messages]
    ([UserUserId]);
GO

-- Creating foreign key on [MessageMessageId] in table 'MessageReadStatus'
ALTER TABLE [dbo].[MessageReadStatus]
ADD CONSTRAINT [FK_MessageMessageReadStatus]
    FOREIGN KEY ([MessageMessageId])
    REFERENCES [dbo].[Messages]
        ([MessageId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MessageMessageReadStatus'
CREATE INDEX [IX_FK_MessageMessageReadStatus]
ON [dbo].[MessageReadStatus]
    ([MessageMessageId]);
GO

-- Creating foreign key on [MessageThreadThreadId] in table 'ThreadParticipants'
ALTER TABLE [dbo].[ThreadParticipants]
ADD CONSTRAINT [FK_MessageThreadThreadParticipant]
    FOREIGN KEY ([MessageThreadThreadId])
    REFERENCES [dbo].[MessageThreads]
        ([ThreadId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MessageThreadThreadParticipant'
CREATE INDEX [IX_FK_MessageThreadThreadParticipant]
ON [dbo].[ThreadParticipants]
    ([MessageThreadThreadId]);
GO

-- Creating foreign key on [MessageThreadThreadId] in table 'Messages'
ALTER TABLE [dbo].[Messages]
ADD CONSTRAINT [FK_MessageThreadMessage]
    FOREIGN KEY ([MessageThreadThreadId])
    REFERENCES [dbo].[MessageThreads]
        ([ThreadId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MessageThreadMessage'
CREATE INDEX [IX_FK_MessageThreadMessage]
ON [dbo].[Messages]
    ([MessageThreadThreadId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------