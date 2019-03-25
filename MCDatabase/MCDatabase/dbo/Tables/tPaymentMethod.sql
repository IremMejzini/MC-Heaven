CREATE TABLE [dbo].[tPaymentMethod] (
    [PaymentMID]  INT           IDENTITY (1, 1) NOT NULL,
    [TypePayment] NVARCHAR (20) NOT NULL,
    CONSTRAINT [PK_tPaymentMethod_PaymentMID] PRIMARY KEY CLUSTERED ([PaymentMID] ASC)
);

