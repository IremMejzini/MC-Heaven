CREATE TABLE [dbo].[tShop] (
    [ShopID]     INT           IDENTITY (1, 1) NOT NULL,
    [NameShop]   NVARCHAR (20) NOT NULL,
    [IsDeliver]  TINYINT       NOT NULL,
    [OpenHourID] INT           NULL,
    [AddressID]  INT           NULL,
    CONSTRAINT [PK_tShop_ShopID] PRIMARY KEY CLUSTERED ([ShopID] ASC)
);

