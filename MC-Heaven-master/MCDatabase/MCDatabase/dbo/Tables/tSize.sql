CREATE TABLE [dbo].[tSize] (
    [SizeID]   INT           IDENTITY (1, 1) NOT NULL,
    [TypeSize] NVARCHAR (20) NOT NULL,
    CONSTRAINT [PK_tSize_SizeID] PRIMARY KEY CLUSTERED ([SizeID] ASC)
);

