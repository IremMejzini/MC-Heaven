CREATE TABLE [dbo].[tOpenHour] (
    [OpenHourID] INT          IDENTITY (1, 1) NOT NULL,
    [FromO]      NVARCHAR (8) NOT NULL,
    [ToO]        NVARCHAR (8) NOT NULL,
    [IsSunday]   TINYINT      NOT NULL,
    [IsSaturday] TINYINT      NOT NULL,
    CONSTRAINT [PK_tOpenHour_OpenHourID] PRIMARY KEY CLUSTERED ([OpenHourID] ASC)
);

