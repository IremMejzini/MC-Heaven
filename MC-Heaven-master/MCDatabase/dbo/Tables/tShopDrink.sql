CREATE TABLE [dbo].[tShopDrink] (
    [DrinkID] INT NOT NULL,
    [ShopID]  INT NOT NULL,
    CONSTRAINT [PK_tShopDrink_tDrink_tShop] PRIMARY KEY CLUSTERED ([DrinkID] ASC, [ShopID] ASC),
    CONSTRAINT [FK_tShopDrink_tDrinkID] FOREIGN KEY ([DrinkID]) REFERENCES [dbo].[tDrink] ([DrinkID]),
    CONSTRAINT [FK_tShopDrink_tShopID] FOREIGN KEY ([ShopID]) REFERENCES [dbo].[tShop] ([ShopID])
);
GO
EXECUTE sp_addextendedproperty
	@name = N'MS_Description',
	@value = N'Information about the drinks in the shop.',
	@level0type = N'SCHEMA',
	@level0name = N'dbo',
	@level1type = N'TABLE',
	@level1name = N'tShopDrink';
GO
