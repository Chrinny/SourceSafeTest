ALTER TABLE [dbo].[APP_ChartWizardTags] DROP CONSTRAINT FK_APP_ChartWizardTags_APP_ChartWizardEngineeringUnits
GO

ALTER TABLE [dbo].[APP_ChartWizardTags] DROP CONSTRAINT FK_APP_ChartWizardTags_APP_ChartWizardFactoryAreaNames
GO

ALTER TABLE [dbo].[APP_ChartWizardLoops] DROP CONSTRAINT FK_APP_ChartWizardLoops_APP_ChartWizardTags
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[APP_ChartWizardEngineeringUnits]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[APP_ChartWizardEngineeringUnits]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[APP_ChartWizardFactoryAreaNames]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[APP_ChartWizardFactoryAreaNames]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[APP_ChartWizardLoops]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[APP_ChartWizardLoops]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[APP_ChartWizardTags]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[APP_ChartWizardTags]
GO

CREATE TABLE [dbo].[APP_ChartWizardEngineeringUnits] (
	[EngineeringUnitCode] [smallint] NOT NULL ,
	[EngineeringUnitName] [char] (15) NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[APP_ChartWizardFactoryAreaNames] (
	[FactoryAreaCode] [smallint] NOT NULL ,
	[FactoryAreaName] [char] (20) NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[APP_ChartWizardLoops] (
	[ATimeStamp] [smalldatetime] NOT NULL ,
	[TagID] [smallint] NOT NULL ,
	[AValue] [real] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[APP_ChartWizardTags] (
	[Tag] [nvarchar] (255) NOT NULL ,
	[Description] [nvarchar] (255) NOT NULL ,
	[LogInterval] [smallint] NOT NULL ,
	[TagID] [smallint] NOT NULL ,
	[EngineeringUnits] [smallint] NULL ,
	[FactoryAreaCode] [smallint] NULL ,
	[RecordOnlyOnChange] [bit] NULL ,
	[DifferenceBeforeChangeIsRecorded] [real] NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[APP_ChartWizardEngineeringUnits] WITH NOCHECK ADD 
	CONSTRAINT [PK_APP_ChartWizardEngineeringUnits] PRIMARY KEY  CLUSTERED 
	(
		[EngineeringUnitCode]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[APP_ChartWizardFactoryAreaNames] WITH NOCHECK ADD 
	CONSTRAINT [PK_APP_ChartWizardFactoryAreaNames] PRIMARY KEY  CLUSTERED 
	(
		[FactoryAreaCode]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[APP_ChartWizardLoops] WITH NOCHECK ADD 
	CONSTRAINT [PK_APP_ChartWizardLoops] PRIMARY KEY  CLUSTERED 
	(
		[ATimeStamp],
		[TagID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[APP_ChartWizardTags] WITH NOCHECK ADD 
	CONSTRAINT [PK_APP_ChartWizardTags] PRIMARY KEY  CLUSTERED 
	(
		[TagID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[APP_ChartWizardTags] WITH NOCHECK ADD 
	CONSTRAINT [DF_APP_ChartWizardTags_EngineeringUnits] DEFAULT (0) FOR [EngineeringUnits],
	CONSTRAINT [DF_APP_ChartWizardTags_FactoryAreaCode] DEFAULT (0) FOR [FactoryAreaCode],
	CONSTRAINT [DF_APP_ChartWizardTags_RecordOnlyOnChange] DEFAULT (0) FOR [RecordOnlyOnChange],
	CONSTRAINT [DF_APP_ChartWizardTags_DifferenceBeforeChangeIsRecorded] DEFAULT (0) FOR [DifferenceBeforeChangeIsRecorded]
GO

 CREATE  UNIQUE  INDEX [IX_APP_ChartWizardLoops] ON [dbo].[APP_ChartWizardLoops]([TagID], [ATimeStamp]) ON [PRIMARY]
GO

ALTER TABLE [dbo].[APP_ChartWizardLoops] ADD 
	CONSTRAINT [FK_APP_ChartWizardLoops_APP_ChartWizardTags] FOREIGN KEY 
	(
		[TagID]
	) REFERENCES [dbo].[APP_ChartWizardTags] (
		[TagID]
	)
GO

ALTER TABLE [dbo].[APP_ChartWizardTags] ADD 
	CONSTRAINT [FK_APP_ChartWizardTags_APP_ChartWizardEngineeringUnits] FOREIGN KEY 
	(
		[EngineeringUnits]
	) REFERENCES [dbo].[APP_ChartWizardEngineeringUnits] (
		[EngineeringUnitCode]
	),
	CONSTRAINT [FK_APP_ChartWizardTags_APP_ChartWizardFactoryAreaNames] FOREIGN KEY 
	(
		[FactoryAreaCode]
	) REFERENCES [dbo].[APP_ChartWizardFactoryAreaNames] (
		[FactoryAreaCode]
	)
GO

