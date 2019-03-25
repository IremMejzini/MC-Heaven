CREATE TABLE [dbo].[tOpenHour] (
    [OpenHourID] INT          IDENTITY (1, 1) NOT NULL,
    [FromO]      NVARCHAR (8) NOT NULL,
    [ToO]        NVARCHAR (8) NOT NULL,
    [IsSunday]   TINYINT      NOT NULL,
    [IsSaturday] TINYINT      NOT NULL,
    CONSTRAINT [PK_tOpenHour_OpenHourID] PRIMARY KEY CLUSTERED ([OpenHourID] ASC)
);
GO
EXECUTE sp_addextendedproperty
	@name = N'MS_Description',
	@value = N'Information about the opening hours.',
	@level0type = N'SCHEMA',
	@level0name = N'dbo',
	@level1type = N'TABLE',
	@level1name = N'tOpenHour';
GO
