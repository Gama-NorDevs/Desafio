-- Create a new database called 'nordtv'
-- Connect to the 'master' database to run this snippet
USE master
GO
-- Create the new database if it does not exist already
IF NOT EXISTS (
    SELECT name
        FROM sys.databases
        WHERE name = N'nordtv'
)
CREATE DATABASE nordtv
GO

use nordtv;

CREATE TABLE [dbo].[User]
(
    [id] [int] IDENTITY(1,1) NOT NULL,
    [name] [VARCHAR](255) NOT NULL,
    [email] [VARCHAR](255) NOT NULL UNIQUE,
    [password] [VARCHAR](255) NOT NULL,
    [profile] [VARCHAR](10) NOT NULL,
    CONSTRAINT PK_User_id PRIMARY KEY CLUSTERED (id)
);

CREATE TABLE [dbo].[Actor]
(
    [id] [int] IDENTITY(1,1) NOT NULL,
    [amount] [float] NOT NULL,
    [sex] [VARCHAR](1) NOT NULL,
    [id_user] [int] NOT NULL UNIQUE,
    CONSTRAINT PK_Actor_id PRIMARY KEY CLUSTERED (id),
    CONSTRAINT FK_User_id FOREIGN KEY (id_user)
        REFERENCES [dbo].[User] (id)
        ON DELETE CASCADE
        ON UPDATE CASCADE

)


CREATE TABLE [dbo].[Genre]
(
    [id] [int] IDENTITY(1,1) NOT NULL,
    [description] [VARCHAR](255) NOT NULL UNIQUE,
    CONSTRAINT PK_Genre_id PRIMARY KEY CLUSTERED (id)

)

CREATE TABLE [dbo].[Actor_Genre]
(
    [id] [int] IDENTITY(1,1) NOT NULL,
    [id_actor] [int] NOT NULL,
    [id_genre] [int] NOT NULL,
    CONSTRAINT PK_Actor_Genre_id PRIMARY KEY CLUSTERED (id),
    CONSTRAINT FK_Actor_id FOREIGN KEY (id_actor)
        REFERENCES [dbo].[Actor] (id)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
    CONSTRAINT FK_Genre_id FOREIGN KEY (id_genre)
        REFERENCES [dbo].[Genre] (id)
        ON DELETE CASCADE
        ON UPDATE CASCADE

)

CREATE TABLE [dbo].[Work]
(
    [id] [int] IDENTITY(1,1) NOT NULL,
    [name] [VARCHAR](255) not NULL,
    [budget] [real] not NULL,
    [date_start] [datetime] NOT NULL,
    [date_end] [datetime] NOT NULL,
    [id_admin] [int] NOT NULL,
    [id_genre] [int] NOT NULL,
    CONSTRAINT PK_Work_id PRIMARY KEY CLUSTERED (id),
    CONSTRAINT FK_User_Work_id FOREIGN KEY (id_admin)
        REFERENCES [dbo].[User] (id)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
    CONSTRAINT FK_Genre_Work_id FOREIGN KEY (id_genre)
        REFERENCES [dbo].[Genre] (id)
        ON DELETE CASCADE
        ON UPDATE CASCADE

)

CREATE TABLE [dbo].[Actor_Work]
(
    [id] [int] IDENTITY(1,1) NOT NULL,
    [id_actor] [int] NOT NULL,
    [id_work] [int] NOT NULL,
    CONSTRAINT PK_Actor_Work_id PRIMARY KEY CLUSTERED (id),
    CONSTRAINT FK_Actor_Actor_Work_id FOREIGN KEY (id_actor)
        REFERENCES [dbo].[Actor] (id)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
    CONSTRAINT FK_Work_Reverse_id FOREIGN KEY (id_work)
        REFERENCES [dbo].[Work] (id)

)