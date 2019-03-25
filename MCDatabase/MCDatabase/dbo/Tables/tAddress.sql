CREATE TABLE [dbo].[tAddress] (
    [AddressID]   INT           IDENTITY (1, 1) NOT NULL,
    [Street]      NVARCHAR (30) NOT NULL,
    [HouseNumber] NVARCHAR (6)  NOT NULL,
    [FlatNumber]  NVARCHAR (6)  NULL,
    [PostalCode]  CHAR (4)      NOT NULL,
    [City]        NVARCHAR (30) NOT NULL,
    CONSTRAINT [PK_tAddress_AddressID] PRIMARY KEY CLUSTERED ([AddressID] ASC)
);
EXECUTE sp_addextendedproperty
	@name = N'MS_Description',
	@value = N'Contains all addresses for clients and employees.',
	@level0type = N'SCHEMA',
	@level0name = N'dbo',
	@level1type = N'TABLE',
	@level1name = N'tAddress';
GO
