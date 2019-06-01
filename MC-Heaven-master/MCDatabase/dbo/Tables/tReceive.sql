CREATE TABLE [dbo].[tReceive] (
    [ReceiveID]  INT IDENTITY (1, 1) NOT NULL,
    [ShopID]     INT NULL,
    [OrderID]    INT NULL,
    [PaymentMID] INT NULL,
    CONSTRAINT [PK_Receive_ReceiveID] PRIMARY KEY CLUSTERED ([ReceiveID] ASC),
    CONSTRAINT [FK_tReceive_tOrderID] FOREIGN KEY ([OrderID]) REFERENCES [dbo].[tOrder] ([OrderID]),
    CONSTRAINT [FK_tReceive_tPaymentMID] FOREIGN KEY ([PaymentMID]) REFERENCES [dbo].[tPaymentMethod] ([PaymentMID]),
    CONSTRAINT [FK_tReceive_tShopID] FOREIGN KEY ([ShopID]) REFERENCES [dbo].[tShop] ([ShopID])
);
GO
EXECUTE sp_addextendedproperty
	@name = N'MS_Description',
	@value = N'Details about the receive.',
	@level0type = N'SCHEMA',
	@level0name = N'dbo',
	@level1type = N'TABLE',
	@level1name = N'tReceive';
GO
