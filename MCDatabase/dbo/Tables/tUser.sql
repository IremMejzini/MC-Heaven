CREATE TABLE [dbo].[tUser] (
    [UserID]      INT            IDENTITY (1, 1) NOT NULL,
    [UserLogin]   NVARCHAR (8)   NOT NULL,
    [Pass]        NVARCHAR (12)  NOT NULL,
    [FirstName]   NVARCHAR (25)  NOT NULL,
    [LastName]    NVARCHAR (25)  NOT NULL,
    [Age]         INT            NOT NULL,
    [Email]       NVARCHAR (100) NOT NULL,
    [PhoneNumber] NVARCHAR (11)  NULL,
    [AddressID]   INT            NULL,
    CONSTRAINT [PK_tUser_UserID] PRIMARY KEY CLUSTERED ([UserID] ASC),
    CONSTRAINT [FK_tUser_tAddressID] FOREIGN KEY ([AddressID]) REFERENCES [dbo].[tAddress] ([AddressID]),
    CONSTRAINT [AK_tUser_UserLogin] UNIQUE NONCLUSTERED ([UserLogin] ASC)
);

