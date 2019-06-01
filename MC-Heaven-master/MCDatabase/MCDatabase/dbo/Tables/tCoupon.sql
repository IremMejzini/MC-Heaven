CREATE TABLE [dbo].[tCoupon] (
    [CouponID]   INT           IDENTITY (1, 1) NOT NULL,
    [TypeCoupon] NVARCHAR (20) NOT NULL,
    CONSTRAINT [PK_tCoupon_CouponID] PRIMARY KEY CLUSTERED ([CouponID] ASC)
);

