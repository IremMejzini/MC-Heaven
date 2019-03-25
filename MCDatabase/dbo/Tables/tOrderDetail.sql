CREATE TABLE [dbo].[tOrderDetail] (
    [OrderDID]  INT        IDENTITY (1, 1) NOT NULL,
    [Quantity]  INT        NOT NULL,
    [Price]     FLOAT (53) NOT NULL,
    [OrderID]   INT        NULL,
    [ReceiveID] INT        NULL,
    CONSTRAINT [PK_OrderDetail_OrderDID] PRIMARY KEY CLUSTERED ([OrderDID] ASC),
    CONSTRAINT [FK_tOrderDetail_tOrderID] FOREIGN KEY ([OrderID]) REFERENCES [dbo].[tOrder] ([OrderID]),
    CONSTRAINT [FK_tOrderDetail_tReceiveID] FOREIGN KEY ([ReceiveID]) REFERENCES [dbo].[tReceive] ([ReceiveID])
);

