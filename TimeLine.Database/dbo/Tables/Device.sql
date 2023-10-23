CREATE TABLE [dbo].[Device] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [SerialNumber] NVARCHAR (50) NULL,
    [Status]       NVARCHAR (50) NULL,
    [StartDate]    DATE          NULL,
    [EndDate]      DATE          NULL,
    CONSTRAINT [PK_Device] PRIMARY KEY CLUSTERED ([Id] ASC)
);

