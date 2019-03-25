CREATE TABLE [dbo].[tOrder] (
    [OrderID]    INT        IDENTITY (1, 1) NOT NULL,
    [TotalPrice] FLOAT (53) NOT NULL,
    [AddressID]  INT        NULL,
    [ShopID]     INT        NULL,
    [PaymentMID] INT        NULL,
    [CouponID]   INT        NULL,
    CONSTRAINT [PK_tOrder_OrderID] PRIMARY KEY CLUSTERED ([OrderID] ASC),
    CONSTRAINT [FK_tOrder_tAddressID] FOREIGN KEY ([AddressID]) REFERENCES [dbo].[tAddress] ([AddressID]),
    CONSTRAINT [FK_tOrder_tCouponID] FOREIGN KEY ([CouponID]) REFERENCES [dbo].[tCoupon] ([CouponID]),
    CONSTRAINT [FK_tOrder_tPaymentMID] FOREIGN KEY ([PaymentMID]) REFERENCES [dbo].[tPaymentMethod] ([PaymentMID]),
    CONSTRAINT [FK_tOrder_tShopID] FOREIGN KEY ([ShopID]) REFERENCES [dbo].[tShop] ([ShopID])
);
GO
EXECUTE sp_addextendedproperty
	@name = N'MS_Description',
	@value = N'What drinks customers ordered.',
	@level0type = N'SCHEMA',
	@level0name = N'dbo',
	@level1type = N'TABLE',
	@level1name = N'tOrder';
GO
