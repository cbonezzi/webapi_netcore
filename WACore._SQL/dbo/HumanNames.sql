CREATE TABLE [dbo].[HumanNames] (
    [Id]        UNIQUEIDENTIFIER CONSTRAINT [DF_HumanNames_Id] DEFAULT (newsequentialid()) NOT NULL,
    [Firstname] VARCHAR (50)     NOT NULL,
    [Lastname]  VARCHAR (50)     NULL,
    [Sex]       CHAR (1)         NULL,
    CONSTRAINT [PK_HumanNames] PRIMARY KEY CLUSTERED ([Id] ASC)
);



