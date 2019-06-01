CREATE TABLE [dbo].[tDrink] (
    [DrinkID]       INT           IDENTITY (1, 1) NOT NULL,
    [DrinkName]     NVARCHAR (20) NOT NULL,
    [Price]         FLOAT (53)    NOT NULL,
    [ParentDrinkID] INT           NOT NULL,
    [SizeID]        INT           NULL,
    [IngredianID]   INT           NULL,
    CONSTRAINT [PK_tDrink_DrinkID] PRIMARY KEY CLUSTERED ([DrinkID] ASC),
    CONSTRAINT [FK_tDrink_tIngredianID] FOREIGN KEY ([IngredianID]) REFERENCES [dbo].[tIngredian] ([IngredianID]),
    CONSTRAINT [FK_tDrink_tSizeID] FOREIGN KEY ([SizeID]) REFERENCES [dbo].[tSize] ([SizeID]),
    CONSTRAINT [AK_tDrink_DrinkName] UNIQUE NONCLUSTERED ([DrinkName] ASC)
);

