CREATE TABLE [dbo].[tPaymentMethod] (
    [PaymentMID]  INT           IDENTITY (1, 1) NOT NULL,
    [TypePayment] NVARCHAR (20) NOT NULL,
    CONSTRAINT [PK_tPaymentMethod_PaymentMID] PRIMARY KEY CLUSTERED ([PaymentMID] ASC)
);
GO
EXECUTE sp_addextendedproperty
	@name = N'MS_Description',
	@value = N'Information about the payment method.',
	@level0type = N'SCHEMA',
	@level0name = N'dbo',
	@level1type = N'TABLE',
	@level1name = N'tPaymentMethod';
GO
