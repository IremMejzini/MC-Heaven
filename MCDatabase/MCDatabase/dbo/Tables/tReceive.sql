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

