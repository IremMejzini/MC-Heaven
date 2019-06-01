CREATE TABLE [dbo].[tIngredian] (
    [IngredianID]   INT           IDENTITY (1, 1) NOT NULL,
    [NameIngredian] NVARCHAR (20) NOT NULL,
    [Price]         FLOAT (53)    NOT NULL,
    CONSTRAINT [PK_tIngredian_IngredianID] PRIMARY KEY CLUSTERED ([IngredianID] ASC)
);
GO
EXECUTE sp_addextendedproperty
	@name = N'MS_Description',
	@value = N'Contains all the ingredians.',
	@level0type = N'SCHEMA',
	@level0name = N'dbo',
	@level1type = N'TABLE',
	@level1name = N'tIngredian';
GO
