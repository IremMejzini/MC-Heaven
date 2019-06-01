CREATE TABLE [dbo].[tCoupon] (
    [CouponID]   INT           IDENTITY (1, 1) NOT NULL,
    [TypeCoupon] NVARCHAR (20) NOT NULL,
    CONSTRAINT [PK_tCoupon_CouponID] PRIMARY KEY CLUSTERED ([CouponID] ASC)
);
GO
EXECUTE sp_addextendedproperty
	@name = N'MS_Description',
	@value = N'Information about the coupons of the customers.',
	@level0type = N'SCHEMA',
	@level0name = N'dbo',
	@level1type = N'TABLE',
	@level1name = N'tCoupon';
GO
