CREATE TABLE [dbo].[tSize] (
    [SizeID]   INT           IDENTITY (1, 1) NOT NULL,
    [TypeSize] NVARCHAR (20) NOT NULL,
    CONSTRAINT [PK_tSize_SizeID] PRIMARY KEY CLUSTERED ([SizeID] ASC)
);
GO
EXECUTE sp_addextendedproperty
	@name = N'MS_Description',
	@value = N'Sizes about the drinks.',
	@level0type = N'SCHEMA',
	@level0name = N'dbo',
	@level1type = N'TABLE',
	@level1name = N'tSize';
GO
