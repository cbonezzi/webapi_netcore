CREATE TABLE [dbo].[UserInfo] (
    [UserId]    UNIQUEIDENTIFIER NOT NULL,
    [Firstname] NVARCHAR (20)    NOT NULL,
    [Middle]    CHAR (1)         NOT NULL,
    [Lastname]  NVARCHAR (20)    NOT NULL,
    [Phone]     NVARCHAR (10)    NOT NULL,
    CONSTRAINT [PK_UserInfo] PRIMARY KEY CLUSTERED ([UserId] ASC)
);

