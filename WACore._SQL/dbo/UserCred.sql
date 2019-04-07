CREATE TABLE [dbo].[UserCred] (
    [UserId]    UNIQUEIDENTIFIER CONSTRAINT [DF_UserCred_UserId] DEFAULT (newsequentialid()) NOT NULL,
    [Expire]    VARCHAR (8)      NOT NULL,
    [Username]  VARCHAR (50)     NOT NULL,
    [Phone]     VARCHAR (12)     NULL,
    [Firstname] VARCHAR (20)     NULL,
    [Lastname]  VARCHAR (20)     NULL,
    CONSTRAINT [PK_UserCred] PRIMARY KEY CLUSTERED ([UserId] ASC)
);

