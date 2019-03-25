CREATE TABLE [dbo].[tShop] (
    [ShopID]     INT           IDENTITY (1, 1) NOT NULL,
    [NameShop]   NVARCHAR (20) NOT NULL,
    [IsDeliver]  TINYINT       NOT NULL,
    [OpenHourID] INT           NULL,
    [AddressID]  INT           NULL,
    CONSTRAINT [PK_tShop_ShopID] PRIMARY KEY CLUSTERED ([ShopID] ASC)
);
GO
EXECUTE sp_addextendedproperty
	@name = N'MS_Description',
	@value = N'Information about the shop.',
	@level0type = N'SCHEMA',
	@level0name = N'dbo',
	@level1type = N'TABLE',
	@level1name = N'tShop';
GO
