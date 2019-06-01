CREATE TABLE [dbo].[tIngredian] (
    [IngredianID]   INT           IDENTITY (1, 1) NOT NULL,
    [NameIngredian] NVARCHAR (20) NOT NULL,
    [Price]         FLOAT (53)    NOT NULL,
    CONSTRAINT [PK_tIngredian_IngredianID] PRIMARY KEY CLUSTERED ([IngredianID] ASC)
);

