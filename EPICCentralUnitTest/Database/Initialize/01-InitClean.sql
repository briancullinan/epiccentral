/****** VIEWS ******/

/****** Object: View [dbo].[Random] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ===========================================================================
-- Author:		L. Kurth
-- Create date: 10/10/12
-- Description:	SQL Server 2012 does not allow the Crypt_Gen_Random function
--				in a user-defined function. This is a workaround. It can be
--				used in a view. So this view will return a random number and
--				the view referenced by the function
-- ===========================================================================
CREATE VIEW [dbo].[Random]
AS
	SELECT Crypt_Gen_Random(4) AS R
GO



/****** FUNCTIONS ******/

/****** Object:  UserDefinedFunction [dbo].[GetUidQualifier]    Script Date: 10/04/2012 13:41:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ===========================================================================
-- Author:		L. Kurth
-- Create date: 06/18/12
-- Description:	Returns a random integer between 256 (inclusive) to 0x1000000
--              (exclusive) which does not exist in the UidQualifier column of
--				the Device table. This function is to be invoked when a new
--				Device row is created to set the UidQualifier column to a
--				random but unique value.
-- ===========================================================================
CREATE FUNCTION [dbo].[GetUidQualifier] ()
RETURNS int
AS
BEGIN
	-- The new qualifier value to be returned.
	DECLARE @Qualifier int
	SET @Qualifier = 0

	-- Add the T-SQL statements to compute the return value here
	WHILE (@Qualifier < 256 OR (SELECT COUNT(*) FROM [dbo].[Device] WHERE [UidQualifier] = @Qualifier) > 0)
	BEGIN
		SET @Qualifier = ABS(CAST((SELECT R FROM Random) as int)) % 0x1000000
	END

	-- Return the qualifier.
	RETURN @Qualifier

END
GO



/****** TABLES ******/


/****** Object:  Table [dbo].[AccountRestriction]    Script Date: 10/04/2012 13:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AccountRestriction](
	[AccountRestrictionId] [int] IDENTITY(1,1) NOT NULL,
	[AccountRestrictionType] [smallint] NOT NULL,
	[RestrictionKey] [varchar](128) NOT NULL,
	[EmailAddress] [varchar](128) NOT NULL,
	[Parameters] [varchar](128) NULL,
	[IPAddress] [varchar](32) NOT NULL,
	[CreatedBy] [int] NULL,
	[CreationTime] [datetime] NOT NULL,
	[RemovalTime] [datetime] NULL,
	[IsActive] [tinyint] NOT NULL,
 CONSTRAINT [PK_AccountRestriction] PRIMARY KEY CLUSTERED 
(
	[AccountRestrictionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO


/****** Object:  Table [dbo].[ActiveOrganization]    Script Date: 10/04/2012 13:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActiveOrganization](
	[ActiveOrganizationId] [int] IDENTITY(1,1) NOT NULL,
	[LocationId] [int] NOT NULL,
	[ActivityTypeId] [smallint] NOT NULL,
	[ActivityTime] [datetime] NULL,
 CONSTRAINT [PK_ActiveOrganization] PRIMARY KEY CLUSTERED 
(
	[ActiveOrganizationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[ActivityType]    Script Date: 10/04/2012 13:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ActivityType](
	[ActivityTypeId] [smallint] NOT NULL,
	[Name] [varchar](40) NOT NULL,
	[Description] [varchar](80) NULL
CONSTRAINT [PK_ActivityType] PRIMARY KEY CLUSTERED 
(
	[ActivityTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[ActivityType] ([ActivityTypeId], [Name], [Description]) VALUES (0, N'Device Ping', NULL)
INSERT [dbo].[ActivityType] ([ActivityTypeId], [Name], [Description]) VALUES (1, N'New Purchase', NULL)
INSERT [dbo].[ActivityType] ([ActivityTypeId], [Name], [Description]) VALUES (2, N'New Scan', NULL)
INSERT [dbo].[ActivityType] ([ActivityTypeId], [Name], [Description]) VALUES (3, N'New Exception', NULL)
INSERT [dbo].[ActivityType] ([ActivityTypeId], [Name], [Description]) VALUES (4, N'New Support Request', NULL)
GO


/****** Object:  Table [dbo].[AnalysisResult]    Script Date: 10/04/2012 13:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AnalysisResult](
	[AnalysisResultID] [bigint] IDENTITY(1,1) NOT NULL,
	[TreatmentId] [bigint] NOT NULL,
	[AnalysisTime] [datetime] NOT NULL,
	[IsFiltered] [tinyint] NOT NULL,
	[FingerDesc] [varchar](50) NULL,
	[FingerType] [int] NOT NULL,
	[SectorNumber] [int] NOT NULL,
	[StartAngle] [int] NOT NULL,
	[EndAngle] [int] NOT NULL,
	[SectorArea] [float] NOT NULL,
	[IntegralArea] [float] NOT NULL,
	[NormalizedArea] [float] NOT NULL,
	[AverageIntensity] [float] NOT NULL,
	[Entropy] [float] NOT NULL,
	[FormCoefficient] [float] NOT NULL,
	[FractalCoefficient] [float] NOT NULL,
	[JsInteger] [float] NOT NULL,
	[CenterX] [float] NOT NULL,
	[CenterY] [float] NOT NULL,
	[RadiusMin] [float] NOT NULL,
	[RadiusMax] [float] NOT NULL,
	[AngleOfRotation] [float] NOT NULL,
	[Form2] [float] NOT NULL,
	[NoiseLevel] [int] NOT NULL,
	[BreakCoefficient] [float] NOT NULL,
	[SoftwareVersion] [varchar](20) NULL,
	[AI1] [float] NOT NULL,
	[AI2] [float] NOT NULL,
	[AI3] [float] NOT NULL,
	[AI4] [float] NOT NULL,
	[Form1_1] [float] NOT NULL,
	[Form1_2] [float] NOT NULL,
	[Form1_3] [float] NOT NULL,
	[Form1_4] [float] NOT NULL,
	[RingThickness] [float] NOT NULL,
	[RingIntensity] [float] NOT NULL,
	[Form2Prime] [float] NOT NULL,
	[UserName] [varchar](20) NOT NULL,
 CONSTRAINT [PK_AnalysisResult] PRIMARY KEY CLUSTERED 
(
	[AnalysisResultID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO


/****** Object:  Table [dbo].[Audit]    Script Date: 10/04/2012 13:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Audit](
	[AuditId] [bigint] IDENTITY(1,1) NOT NULL,
	[Table] [varchar](128) NOT NULL,
	[Key] [varchar](256) NOT NULL,
	[Field] [varchar](128) NOT NULL,
	[OldData] [varchar](max) NULL,
	[NewData] [varchar](max) NULL,
	[CreatedBy] [varchar](80) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Audit] PRIMARY KEY CLUSTERED 
(
	[AuditId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO


/****** Object:  Table [dbo].[CalculationDebugData]    Script Date: 10/04/2012 13:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CalculationDebugData](
	[CalculationDebugDataId] [bigint] IDENTITY(1,1) NOT NULL,
	[TreatmentId] [bigint] NOT NULL,
	[FingerSector] [varchar](20) NOT NULL,
	[IsFiltered] [bit] NOT NULL,
	[OrganComponent] [smallint] NOT NULL,
	[Entropy] [decimal](16, 4) NOT NULL,
	[Form] [decimal](16, 4) NOT NULL,
	[Form2] [decimal](16, 4) NOT NULL,
	[Form1_1] [decimal](16, 4) NOT NULL,
	[Form1_2] [decimal](16, 4) NOT NULL,
	[Form1_3] [decimal](16, 4) NOT NULL,
	[Form1_4] [decimal](16, 4) NOT NULL,
	[Area] [decimal](16, 4) NOT NULL,
	[AverageIntensity] [decimal](16, 4) NOT NULL,
	[AI1] [decimal](16, 4) NOT NULL,
	[AI2] [decimal](16, 4) NOT NULL,
	[AI3] [decimal](16, 4) NOT NULL,
	[AI4] [decimal](16, 4) NOT NULL,
	[NS] [decimal](16, 4) NOT NULL,
	[Fractal] [decimal](16, 4) NOT NULL,
	[RingThickness] [decimal](16, 4) NOT NULL,
	[RingIntensity] [decimal](16, 4) NOT NULL,
	[BreakCoefficient] [decimal](16, 4) NULL,
	[EPICBaseScore] [decimal](16, 4) NOT NULL,
	[EPICBonusScore] [decimal](16, 4) NOT NULL,
	[EPICScore] [decimal](16, 4) NOT NULL,
	[EPICRank] [int] NOT NULL,
	[EPICScaledScore] [decimal](16, 4) NOT NULL,
	[SumZScore] [decimal](16, 4) NOT NULL,
	[LRScore] [decimal](16, 4) NOT NULL,
	[LRRank] [int] NOT NULL,
	[LRScaledScore] [decimal](16, 4) NOT NULL,
	[Form2Prime] [decimal](16, 4) NOT NULL,
 CONSTRAINT [PK_CalculationDebugData] PRIMARY KEY CLUSTERED 
(
	[CalculationDebugDataId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO


/****** Object:  Table [dbo].[Calibration]    Script Date: 10/04/2012 13:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Calibration](
	[CalibrationId] [bigint] IDENTITY(1,1) NOT NULL,
	[DeviceId] [int] NOT NULL,
	[UniqueIdentifier] [varchar](48) NOT NULL,
	[CalibrationTime] [datetime] NOT NULL,
	[PerformedBy] [varchar](80) NOT NULL,
	[ImageSetId] [bigint] NOT NULL,
	[ReceivedTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Calibration] PRIMARY KEY CLUSTERED 
(
	[CalibrationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO


/****** Object:  Table [dbo].[Contact]    Script Date: 10/04/2012 13:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Contact](
	[ContactId] [int] IDENTITY(1,1) NOT NULL,
	[OrganizationId] [int] NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[EmailAddress] [varchar](128) NOT NULL,
	[PhoneNumber] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[ContactId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO


/****** Object:  Table [dbo].[CreditCard]    Script Date: 10/04/2012 13:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[CreditCard](
	[CreditCardId] [int] IDENTITY(1,1) NOT NULL,
	[AuthorizeId] [varchar](20) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[AccountNumber] [char](4) NULL,
	[Address] [varchar](64) NULL
CONSTRAINT [PK_CreditCard] PRIMARY KEY CLUSTERED 
(
	[CreditCardId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO


/****** Object:  Table [dbo].[Device]    Script Date: 10/04/2012 13:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Device](
	[DeviceId] [int] IDENTITY(1,1) NOT NULL,
	[LocationId] [int] NOT NULL,
	[UniqueIdentifier] [varchar](48) NOT NULL,
	[AuthenticationToken] [binary](64) NULL,
	[UidQualifier] [int] NOT NULL,
	[DeviceState] [smallint] NOT NULL,
	[SerialNumber] [varchar](40) NOT NULL,
	[DateIssued] [datetime] NOT NULL,
	[RevisionLevel] [varchar](5) NOT NULL,
	[ScansAvailable] [int] NOT NULL,
	[ScansCompleted] [int] NOT NULL,
	[CurrentStatus] [varchar](50) NOT NULL,
	[LastReportTime] [datetime] NULL,
 CONSTRAINT [PK_Device] PRIMARY KEY CLUSTERED 
(
	[DeviceId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO


/****** Object:  Table [dbo].[DeviceEvent]    Script Date: 10/04/2012 13:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeviceEvent](
	[DeviceEventId] [bigint] IDENTITY(1,1) NOT NULL,
	[DeviceId] [int] NOT NULL,
	[EventType] [smallint] NOT NULL,
	[EventTime] [datetime] NOT NULL,
	[ReceivedTime] [datetime] NOT NULL,
 CONSTRAINT [PK_DeviceEvent] PRIMARY KEY CLUSTERED 
(
	[DeviceEventId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[DeviceMessage]    Script Date: 10/04/2012 13:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeviceMessage](
	[DeviceId] [int] NOT NULL,
	[MessageId] [bigint] NOT NULL,
	[DeliveryTime] [datetime] NULL,
 CONSTRAINT [PK_DeviceMessage] PRIMARY KEY CLUSTERED 
(
	[DeviceId] ASC,
	[MessageId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[DeviceStateTracking]    Script Date: 10/04/2012 13:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DeviceStateTracking](
	[DeviceStateTrackingId] [bigint] IDENTITY(1,1) NOT NULL,
	[DeviceId] [int] NOT NULL,
	[CurrentState] [smallint] NOT NULL,
	[PreviousState] [smallint] NOT NULL,
	[ChangeReason] [varchar](512) NOT NULL,
	[ChangeTime] [datetime] NOT NULL,
 CONSTRAINT [PK_DeviceStateTracking] PRIMARY KEY CLUSTERED 
(
	[DeviceStateTrackingId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO


/****** Object:  Table [dbo].[ImageSet]    Script Date: 10/04/2012 17:22:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ImageSet](
	[ImageSetId] [bigint] IDENTITY(1,1) NOT NULL,
	[UniqueIdentifier] [varchar](48) NOT NULL,
	[Images] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_ImageSet] PRIMARY KEY CLUSTERED 
(
	[ImageSetId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO


/****** Object:  Table [dbo].[ImageCache]    Script Date: 10/04/2012 17:22:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ImageCache](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[LookupKey] [bigint] NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[Image] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_ImageCache] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO


/****** Object:  Table [dbo].[ExceptionLog]    Script Date: 10/04/2012 13:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ExceptionLog](
	[ExceptionLogId] [bigint] IDENTITY(1,1) NOT NULL,
	[DeviceId] [int] NOT NULL,
	[RemoteExceptionLogId] [bigint] NOT NULL,
	[Title] [varchar](1024) NULL,
	[Message] [varchar](1024) NOT NULL,
	[StackTrace] [varchar](max) NOT NULL,
	[LogTime] [datetime] NOT NULL,
	[User] [varchar](50) NULL,
	[FormName] [varchar](50) NULL,
	[MachineName] [varchar](50) NULL,
	[MachineOS] [varchar](50) NULL,
	[ApplicationVersion] [varchar](40) NULL,
	[CLRVersion] [varchar](50) NULL,
	[MemoryUsage] [varchar](40) NULL,
	[ReceivedTime] [datetime] NOT NULL,
 CONSTRAINT [PK_ExceptionLog] PRIMARY KEY CLUSTERED 
(
	[ExceptionLogId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO


/****** Object:  Table [dbo].[LicenseOrganSystem]    Script Date: 10/04/2012 13:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LicenseOrganSystem](
	[LicenseOrganSystemId] [smallint] IDENTITY(1,1) NOT NULL,
	[LicenseMode] [smallint] NOT NULL,
	[OrganSystemId] [smallint] NOT NULL,
	[ReportOrder] [smallint] NOT NULL,
 CONSTRAINT [PK_LicenseOrganSystem] PRIMARY KEY CLUSTERED 
(
	[LicenseOrganSystemId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[LicenseOrganSystem] ON
INSERT [dbo].[LicenseOrganSystem] ([LicenseOrganSystemId], [LicenseMode], [OrganSystemId], [ReportOrder]) VALUES (1, 1, 1, 3)
INSERT [dbo].[LicenseOrganSystem] ([LicenseOrganSystemId], [LicenseMode], [OrganSystemId], [ReportOrder]) VALUES (2, 1, 2, 4)
INSERT [dbo].[LicenseOrganSystem] ([LicenseOrganSystemId], [LicenseMode], [OrganSystemId], [ReportOrder]) VALUES (3, 1, 4, 1)
INSERT [dbo].[LicenseOrganSystem] ([LicenseOrganSystemId], [LicenseMode], [OrganSystemId], [ReportOrder]) VALUES (4, 1, 5, 2)
INSERT [dbo].[LicenseOrganSystem] ([LicenseOrganSystemId], [LicenseMode], [OrganSystemId], [ReportOrder]) VALUES (5, 1, 6, 5)
INSERT [dbo].[LicenseOrganSystem] ([LicenseOrganSystemId], [LicenseMode], [OrganSystemId], [ReportOrder]) VALUES (6, 2, 1, 4)
INSERT [dbo].[LicenseOrganSystem] ([LicenseOrganSystemId], [LicenseMode], [OrganSystemId], [ReportOrder]) VALUES (7, 2, 2, 5)
INSERT [dbo].[LicenseOrganSystem] ([LicenseOrganSystemId], [LicenseMode], [OrganSystemId], [ReportOrder]) VALUES (8, 2, 3, 1)
INSERT [dbo].[LicenseOrganSystem] ([LicenseOrganSystemId], [LicenseMode], [OrganSystemId], [ReportOrder]) VALUES (9, 2, 4, 2)
INSERT [dbo].[LicenseOrganSystem] ([LicenseOrganSystemId], [LicenseMode], [OrganSystemId], [ReportOrder]) VALUES (10, 2, 5, 3)
INSERT [dbo].[LicenseOrganSystem] ([LicenseOrganSystemId], [LicenseMode], [OrganSystemId], [ReportOrder]) VALUES (11, 2, 6, 6)
SET IDENTITY_INSERT [dbo].[LicenseOrganSystem] OFF
GO


/****** Object:  Table [dbo].[Location]    Script Date: 10/04/2012 13:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Location](
	[LocationId] [int] IDENTITY(1,1) NOT NULL,
	[OrganizationId] [int] NOT NULL,
	[UniqueIdentifier] [varchar](48) NOT NULL,
	[Name] [varchar](80) NOT NULL,
	[AddressLine1] [varchar](80) NOT NULL,
	[AddressLine2] [varchar](80) NULL,
	[City] [varchar](40) NOT NULL,
	[State] [varchar](2) NOT NULL,
	[Country] [varchar](2) NOT NULL,
	[PostalCode] [varchar](10) NOT NULL,
	[PhoneNumber] [varchar](20) NOT NULL,
	[Latitude] [numeric](18, 7) NULL,
	[Longitude] [numeric](18, 7) NULL,
	[IsActive] [tinyint] NOT NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[LocationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Location] ON
INSERT [dbo].[Location] ([LocationId], [OrganizationId], [UniqueIdentifier], [Name], [AddressLine1], [AddressLine2], [City], [State], [Country], [PostalCode], [PhoneNumber], [Latitude], [Longitude], [IsActive])
VALUES (1, 1, N'000020-' + LOWER(NEWID()), N'Host Site', N'8501 E. Princess Drive', N'Suite 100', N'Scottsdale', N'AZ', N'US', N'85255', N'4804775242', CAST(33.6441900 AS Numeric(18, 7)), CAST(-111.8967120 AS Numeric(18, 7)), 1)
SET IDENTITY_INSERT [dbo].[Location] OFF
GO


/****** Object:  Table [dbo].[Message]    Script Date: 10/04/2012 13:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Message](
	[MessageId] [bigint] IDENTITY(1,1) NOT NULL,
	[MessageType] [smallint] NOT NULL,
	[Title] [varchar](255) NOT NULL,
	[Body] [varchar](4096) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NULL,
	[IsActive] [tinyint] NOT NULL,
 CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED 
(
	[MessageId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO


/****** Object:  Table [dbo].[NBAnalysisResult]    Script Date: 10/04/2012 13:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NBAnalysisResult](
	[NBAnalysisResultId] [bigint] IDENTITY(1,1) NOT NULL,
	[TreatmentId] [bigint] NOT NULL,
	[OrganSystemId] [smallint] NOT NULL,
	[ResultScoreFiltered] [numeric](16, 4) NOT NULL,
	[ResultScoreUnfiltered] [numeric](16, 4) NOT NULL,
	[ProbabilityFiltered] [numeric](16, 4) NOT NULL,
	[ProbabilityUnfiltered] [numeric](16, 4) NOT NULL,
 CONSTRAINT [PK_NBAnalysisResult] PRIMARY KEY CLUSTERED 
(
	[NBAnalysisResultId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[Organ]    Script Date: 10/04/2012 13:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Organ](
	[OrganId] [smallint] NOT NULL,
	[OrganComponent] [smallint] NOT NULL,
	[Description] [varchar](128) NOT NULL,
	[RComp] [varchar](10) NULL,
	[LComp] [varchar](10) NULL,
 CONSTRAINT [PK_Organ] PRIMARY KEY CLUSTERED 
(
	[OrganId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (2, 17, N'Descending Colon', NULL, N'1L-1')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (3, 16, N'Ascending Colon', N'2R-8', NULL)
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (4, 18, N'Sigmoid Colon', NULL, N'2L-2')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (5, 20, N'Rectum', NULL, N'2L-3')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (6, 23, N'Blind Gut', N'2R-6', NULL)
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (7, 27, N'Appendix', N'2R-7', NULL)
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (8, 22, N'Abdominal Region', NULL, N'3L-4')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (10, 26, N'Jejunum', NULL, N'5L-4')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (11, 24, N'Duodenum', N'5R-1', NULL)
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (12, 25, N'Ileum', N'5R-2', NULL)
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (19, 65, N'Cervical Spine - Right', N'2R-1', N'2L-8')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (20, 19, N'Transverse Colon - Left', N'2R-9', N'2L-9')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (23, 13, N'Ear/Nose/Sinus (R) - Right', N'1R-2', N'1L-2')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (24, 10, N'Ear/Nose/Sinus (L) - Left', N'1R-6', N'1L-6')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (26, 68, N'Jaw/Teeth (R) - Right', N'1R-3', N'1L-3')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (27, 60, N'Jaw/Teeth (L) - Left', N'1R-5', N'1L-5')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (30, 9, N'Cervical Vascular System - Right', N'1R-4', N'1L-4')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (31, 56, N'Thyroid - Right', N'4R-2', N'4L-7')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (33, 6, N'Cardiovascular Circulation (whole body) - Right', N'3R-6', N'3L-1')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (35, 38, N'Urokidney - Left', N'5R-4', N'5L-2')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (36, 39, N'Urokidney - Right', N'5R-4', N'5L-2')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (38, 30, N'Immune System - Right', N'3R-2', N'3L-5')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (39, 12, N'Thorax Respiratory - Left', N'3R-1', N'3L-6')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (41, 43, N'Hypothalamus - Left', N'4R-8', N'4L-1')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (42, 55, N'Pituitary - Right', N'4R-1', N'4L-8')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (43, 70, N'Nervous System - Right', N'4R-7', N'4L-2')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (45, 34, N'Genitourinary System - Left', N'4R-5', N'4L-4')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (47, 45, N'Pancreas - Left', N'4R-3', N'4L-6')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (48, 47, N'Pituitary - Left', N'4R-1', N'4L-8')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (49, 54, N'Pineal - Right', N'4R-9', N'4L-9')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (51, 8, N'Heart (right side)', NULL, N'5L-5')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (54, 11, N'Respiratory/Mammary - Left', N'5R-3', N'5L-3')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (56, 15, N'Thorax Respiratory - Right', N'3R-1', N'3L-6')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (65, 48, N'Thyroid - Left', N'4R-2', N'4L-7')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (67, 5, N'Cervical Vascular System - Left', N'1R-4', N'1L-4')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (70, 1, N'Heart (muscles)', N'5R-5', NULL)
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (78, 3, N'Coronary Vessels - Left', N'5R-6', N'5L-6')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (79, 7, N'Coronary Vessels - Right', N'5R-6', N'5L-6')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (96, 32, N'Adrenal - Left', N'4R-4', N'4L-5')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (97, 35, N'Adrenal - Right', N'4R-4', N'4L-5')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (100, 33, N'Kidney (L)', N'3R-5', N'3L-2')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (101, 36, N'Kidney (R)', N'3R-5', N'3L-2')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (106, 52, N'Liver - Right', N'3R-4', N'3L-3')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (108, 44, N'Liver - Left', N'3R-4', N'3L-3')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (120, 40, N'Gallbladder', N'3R-3', NULL)
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (122, 21, N'Transverse Colon - Right', N'2R-9', N'2L-9')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (142, 57, N'Cervical Spine - Left', N'2R-1', N'2L-8')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (144, 64, N'Thoracic Spine - Left', N'2R-2', N'2L-7')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (145, 72, N'Thoracic Spine - Right', N'2R-2', N'2L-7')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (146, 61, N'Lumbar Spine - Left', N'2R-3', N'2L-6')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (147, 69, N'Lumbar Spine - Right', N'2R-3', N'2L-6')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (148, 63, N'Sacrum - Left', N'2R-4', N'2L-5')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (149, 71, N'Sacrum - Right', N'2R-4', N'2L-5')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (150, 58, N'Coccyx/Pelvis - Left', N'2R-5', N'2L-4')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (151, 66, N'Coccyx/Pelvis - Right', N'2R-5', N'2L-4')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (152, 37, N'Genitourinary System - Right', N'4R-5', N'4L-4')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (155, 2, N'Cardiovascular Circulation (whole body) - Left', N'3R-6', N'3L-1')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (159, 28, N'Immune System - Left', N'3R-2', N'3L-5')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (161, 4, N'Heart (left side)', NULL, N'5L-1')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (162, 62, N'Nervous System - Left', N'4R-7', N'4L-2')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (169, 53, N'Pancreas - Right', N'4R-3', N'4L-6')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (172, 29, N'Spleen - Left', N'4R-6', N'4L-3')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (173, 31, N'Spleen - Right', N'4R-6', N'4L-3')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (174, 14, N'Respiratory/Mammary - Right', N'5R-3', N'5L-3')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (196, 42, N'Cerebral Vessels - Left', N'3R-7', N'3L-7')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (197, 50, N'Cerebral Vessels - Right', N'3R-7', N'3L-7')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (198, 46, N'Pineal - Left', N'4R-9', N'4L-9')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (200, 41, N'Cerebral Cortex - Left', N'1R-8', N'1L-8')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (201, 49, N'Cerebral Cortex - Right', N'1R-8', N'1L-8')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (202, 51, N'Hypothalamus - Right', N'4R-8', N'4L-1')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (204, 59, N'Eye (L) - Left', N'1R-7', N'1L-7')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (205, 77, N'Eye (L) - Right', N'1R-7', N'1L-7')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (206, 67, N'Eye (R) - Right', N'1R-1', N'1L-1')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (207, 78, N'Eye (R) - Left', N'1R-1', N'1L-1')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (208, 74, N'Ear/Nose/Sinus (L) - Right', N'1R-6', N'1L-6')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (209, 73, N'Ear/Nose/Sinus (R) - Left', N'1R-2', N'1L-2')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (210, 75, N'Jaw/Teeth (L) - Right', N'1R-5', N'1L-5')
INSERT [dbo].[Organ] ([OrganId], [OrganComponent], [Description], [RComp], [LComp]) VALUES (211, 76, N'Jaw/Teeth (R) - Left', N'1R-3', N'1L-3')
GO


/****** Object:  Table [dbo].[Organization]    Script Date: 10/04/2012 13:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Organization](
	[OrganizationId] [int] IDENTITY(1,1) NOT NULL,
	[OrganizationType] [smallint] NOT NULL,
	[Name] [varchar](128) NOT NULL,
	[UniqueIdentifier] [varchar](48) NOT NULL,
	[IsActive] [tinyint] NOT NULL,
 CONSTRAINT [PK_Organization] PRIMARY KEY CLUSTERED 
(
	[OrganizationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Organization] ON
INSERT [dbo].[Organization] ([OrganizationId], [OrganizationType], [Name], [UniqueIdentifier], [IsActive]) VALUES (1, 1, N'EPIC Central', N'000010-' + LOWER(NEWID()), 1)
SET IDENTITY_INSERT [dbo].[Organization] OFF
GO


/****** Object:  Table [dbo].[OrganSystem]    Script Date: 10/04/2012 13:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OrganSystem](
	[OrganSystemId] [smallint] NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_OrganSystem] PRIMARY KEY CLUSTERED 
(
	[OrganSystemId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[OrganSystem] ([OrganSystemId], [Description]) VALUES (1, N'Gastrointestinal & Endocrine Systems')
INSERT [dbo].[OrganSystem] ([OrganSystemId], [Description]) VALUES (2, N'Hepatic System')
INSERT [dbo].[OrganSystem] ([OrganSystemId], [Description]) VALUES (3, N'Sensory & Skeletal Systems')
INSERT [dbo].[OrganSystem] ([OrganSystemId], [Description]) VALUES (4, N'Cardiovascular System')
INSERT [dbo].[OrganSystem] ([OrganSystemId], [Description]) VALUES (5, N'Respiratory System')
INSERT [dbo].[OrganSystem] ([OrganSystemId], [Description]) VALUES (6, N'Renal & Reproductive Systems')
GO


/****** Object:  Table [dbo].[OrganSystemOrgan]    Script Date: 10/04/2012 13:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrganSystemOrgan](
	[OrganId] [smallint] NOT NULL,
	[LicenseOrganSystemId] [smallint] NOT NULL,
	[ReportOrder] [smallint] NOT NULL,
 CONSTRAINT [PK_OrganSystemOrgan] PRIMARY KEY CLUSTERED 
(
	[OrganId] ASC,
	[LicenseOrganSystemId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (2, 1, 9)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (2, 6, 9)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (3, 1, 7)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (3, 6, 7)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (4, 1, 10)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (4, 6, 10)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (5, 1, 11)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (5, 6, 11)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (6, 1, 4)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (6, 6, 4)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (7, 1, 6)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (7, 6, 6)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (8, 1, 5)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (8, 6, 5)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (10, 1, 2)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (10, 6, 2)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (11, 1, 1)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (11, 6, 1)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (12, 1, 3)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (12, 6, 3)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (19, 4, 9)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (19, 8, 7)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (20, 1, 8)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (20, 6, 8)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (23, 4, 4)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (23, 8, 4)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (24, 4, 3)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (24, 8, 3)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (26, 4, 6)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (26, 8, 6)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (27, 4, 5)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (27, 8, 5)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (30, 3, 1)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (30, 4, 0)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (30, 9, 1)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (30, 10, 1)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (31, 2, 4)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (31, 7, 5)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (33, 3, 6)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (33, 9, 6)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (35, 5, 4)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (35, 11, 5)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (36, 5, 4)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (36, 11, 5)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (38, 2, 6)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (38, 7, 8)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (39, 4, 2)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (39, 10, 3)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (41, 2, 8)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (41, 7, 2)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (42, 2, 9)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (42, 7, 3)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (43, 2, 7)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (43, 7, 1)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (45, 5, 5)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (45, 11, 4)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (47, 2, 3)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (47, 7, 10)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (48, 2, 9)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (48, 7, 3)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (49, 2, 10)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (49, 7, 4)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (51, 3, 5)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (51, 9, 5)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (54, 4, 1)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (54, 10, 2)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (56, 4, 2)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (56, 10, 3)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (65, 2, 4)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (65, 7, 5)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (67, 3, 1)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (67, 4, 0)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (67, 9, 1)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (67, 10, 1)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (70, 3, 3)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (70, 9, 3)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (78, 3, 2)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (78, 9, 2)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (79, 3, 2)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (79, 9, 2)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (96, 5, 1)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (96, 11, 3)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (97, 5, 1)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (97, 11, 3)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (100, 5, 2)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (100, 11, 1)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (101, 5, 3)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (101, 11, 2)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (106, 2, 1)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (106, 7, 11)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (108, 2, 1)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (108, 7, 11)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (120, 2, 2)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (120, 7, 12)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (122, 1, 8)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (122, 6, 8)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (142, 4, 9)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (142, 8, 7)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (144, 3, 7)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (144, 8, 8)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (145, 3, 7)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (145, 8, 8)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (146, 1, 12)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (146, 8, 9)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (147, 1, 12)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (147, 8, 9)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (148, 5, 6)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (148, 8, 10)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (149, 5, 6)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (149, 8, 10)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (150, 5, 7)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (150, 8, 11)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (151, 5, 7)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (151, 8, 11)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (152, 5, 5)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (152, 11, 4)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (155, 3, 6)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (155, 9, 6)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (159, 2, 6)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (159, 7, 8)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (161, 3, 4)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (161, 9, 4)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (162, 2, 7)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (162, 7, 1)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (169, 2, 3)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (169, 7, 10)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (172, 2, 5)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (172, 7, 9)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (173, 2, 5)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (173, 7, 9)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (174, 4, 1)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (174, 10, 2)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (196, 2, 12)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (196, 7, 7)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (197, 2, 12)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (197, 7, 7)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (198, 2, 10)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (198, 7, 4)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (200, 2, 11)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (200, 7, 6)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (201, 2, 11)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (201, 7, 6)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (202, 2, 8)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (202, 7, 2)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (204, 4, 7)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (204, 8, 1)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (205, 4, 7)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (205, 8, 1)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (206, 4, 8)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (206, 8, 2)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (207, 4, 8)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (207, 8, 2)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (208, 4, 3)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (208, 8, 3)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (209, 4, 4)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (209, 8, 4)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (210, 4, 5)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (210, 8, 5)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (211, 4, 6)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (211, 8, 6)
GO


/****** Object:  Table [dbo].[Patient]    Script Date: 10/04/2012 13:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Patient](
	[PatientId] [int] IDENTITY(1,1) NOT NULL,
	[UniqueIdentifier] [varchar](48) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[MiddleInitial] [char](1) NULL,
	[PhoneNumber] [varchar](20) NULL,
	[EmailAddress] [varchar](128) NULL,
	[BirthDate] [datetime] NOT NULL,
	[Gender] [smallint] NOT NULL,
	[LocationId] [int] NOT NULL,
	[ReceivedTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Patient] PRIMARY KEY CLUSTERED 
(
	[PatientId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO


/****** Object:  Table [dbo].[PatientPrescanQuestion]    Script Date: 10/04/2012 13:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PatientPrescanQuestion](
	[TreatmentId] [bigint] NOT NULL,
	[AlcoholQuestion] [bit] NOT NULL,
	[WheatQuestion] [bit] NOT NULL,
	[CaffeineQuestion] [bit] NOT NULL,
 CONSTRAINT [PK_PatientPrescanQuestion] PRIMARY KEY CLUSTERED 
(
	[TreatmentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[PurchaseHistory]    Script Date: 10/04/2012 13:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PurchaseHistory](
	[PurchaseHistoryId] [int] IDENTITY(1,1) NOT NULL,
	[LocationId] [int] NOT NULL,
	[DeviceId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[PurchaseTime] [datetime] NOT NULL,
	[ScansPurchased] [int] NULL,
	[AmountPaid] [money] NOT NULL,
	[TransactionId] [varchar](64) NOT NULL,
	[PurchaseNotes] [varchar](2048) NOT NULL,
 CONSTRAINT [PK_PurchaseHistory] PRIMARY KEY CLUSTERED 
(
	[PurchaseHistoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO


/****** Object:  Table [dbo].[Role]    Script Date: 10/04/2012 13:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](80) NOT NULL,
	[Description] [varchar](512) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON
INSERT [dbo].[Role] ([RoleId], [Name], [Description]) VALUES (1, N'Service Administrator', N'EPIC Central administrator with full control of the service')
INSERT [dbo].[Role] ([RoleId], [Name], [Description]) VALUES (2, N'Organization Administrator', N'Organization administrator with full control of the organization')
INSERT [dbo].[Role] ([RoleId], [Name], [Description]) VALUES (3, N'Simple User', N'Simple, non-administrator user with limited rights')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO


/****** Object:  Table [dbo].[ScanHistory]    Script Date: 10/04/2012 13:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScanHistory](
	[ScanHistoryId] [bigint] IDENTITY(1,1) NOT NULL,
	[DeviceId] [int] NOT NULL,
	[ScanType] [smallint] NOT NULL,
	[ScanStartTime] [datetime] NOT NULL,
 CONSTRAINT [PK_ScanHistory] PRIMARY KEY CLUSTERED 
(
	[ScanHistoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[ScanRate]    Script Date: 10/04/2012 13:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScanRate](
	[ScanRateId] [int] IDENTITY(1,1) NOT NULL,
	[ScanType] [smallint] NOT NULL,
	[RatePerScan] [money] NOT NULL,
	[MinCountForRate] [int] NOT NULL,
	[MaxCountForRate] [int] NOT NULL,
	[EffectiveDate] [datetime] NOT NULL,
	[IsActive] [tinyint] NOT NULL,
 CONSTRAINT [PK_ScanRate] PRIMARY KEY CLUSTERED 
(
	[ScanRateId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[SchemaVersion]    Script Date: 10/04/2012 13:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SchemaVersion](
	[Version] [smallint] NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[SchemaVersion] ([Version]) VALUES (1)
GO

/****** Object:  Table [dbo].[Severity]    Script Date: 10/04/2012 13:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Severity](
	[SeverityId] [bigint] IDENTITY(1,1) NOT NULL,
	[TreatmentId] [bigint] NOT NULL,
	[OrganId] [smallint] NOT NULL,
	[PhysicalRight] [int] NULL,
	[PhysicalLeft] [int] NULL,
	[MentalRight] [int] NULL,
	[MentalLeft] [int] NULL,
 CONSTRAINT [PK_Severity] PRIMARY KEY CLUSTERED 
(
	[SeverityId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[SupportArea]    Script Date: 10/04/2012 13:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SupportArea](
	[SupportAreaId] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](40) NOT NULL,
	[Description] [varchar](80) NULL,
	[IsActive] [tinyint] NOT NULL,
 CONSTRAINT [PK_SupportArea] PRIMARY KEY CLUSTERED 
(
	[SupportAreaId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[SupportArea] ON
INSERT [dbo].[SupportArea] ([SupportAreaId], [Name], [Description], [IsActive]) VALUES (1, N'General', NULL, 1)
SET IDENTITY_INSERT [dbo].[SupportArea] OFF
GO


/****** Object:  Table [dbo].[SupportIssue]    Script Date: 10/04/2012 13:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SupportIssue](
	[SupportIssueId] [int] IDENTITY(1,1) NOT NULL,
	[ParentId] [int] NOT NULL,
	[SupportAreaId] [smallint] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[ToUserId] [int] NULL,
	[FromUserId] [int] NULL,
	[Subject] [varchar](512) NOT NULL,
	[Body] [varchar](6144) NOT NULL,
	[Status] [varchar](128) NOT NULL,
	[Priority] [smallint] NOT NULL,
	[IsPublic] [tinyint] NOT NULL,
	[IsClosedByToUser] [tinyint] NOT NULL,
	[IsClosedByFromUser] [tinyint] NOT NULL,
	[IsActive] [tinyint] NOT NULL,
 CONSTRAINT [PK_SupportIssue] PRIMARY KEY CLUSTERED 
(
	[SupportIssueId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO


/****** Object:  Table [dbo].[SystemSetting]    Script Date: 10/04/2012 13:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SystemSetting](
	[Name] [varchar](50) NOT NULL,
	[Value] [varchar](2048) NOT NULL,
 CONSTRAINT [PK_EC_System] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[SystemSetting] ([Name], [Value]) VALUES (N'Enabled', N'True')
INSERT [dbo].[SystemSetting] ([Name], [Value]) VALUES (N'EnforcePasswordComplexity', N'1')
GO


/****** Object:  Table [dbo].[Treatment]    Script Date: 10/04/2012 13:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Treatment](
	[TreatmentId] [bigint] IDENTITY(1,1) NOT NULL,
	[PatientId] [int] NOT NULL,
	[CalibrationId] [bigint] NOT NULL,
	[UniqueIdentifier] [varchar](48) NOT NULL,
	[TreatmentType] [smallint] NOT NULL,
	[TreatmentTime] [datetime] NOT NULL,
	[PerformedBy] [varchar](80) NOT NULL,
	[EnergizedImageSetId] [bigint] NOT NULL,
	[FingerImageSetId] [bigint] NULL,
	[SoftwareVersion] [varchar](20) NOT NULL,
	[FirmwareVersion] [varchar](50) NOT NULL,
	[AnalysisTime] [datetime] NOT NULL,
	[ReceivedTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Treatment] PRIMARY KEY CLUSTERED 
(
	[TreatmentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO


/****** Object:  Table [dbo].[UpdateStatus]    Script Date: 10/04/2012 13:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UpdateStatus](
	[Controller] [varchar](512) NOT NULL,
	[Action] [varchar](128) NOT NULL,
	[Method] [varchar](16) NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_UpdateStatus] PRIMARY KEY CLUSTERED 
(
	[Controller] ASC,
	[Action] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO


/****** Object:  Table [dbo].[User]    Script Date: 10/04/2012 13:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[OrganizationId] [int] NOT NULL,
	[Username] [varchar](80) NOT NULL,
	[Password] [varchar](512) NOT NULL,
	[EmailAddress] [varchar](128) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[LastLoginTime] [datetime] NULL,
	[LastActivityTime] [datetime] NULL,
	[LastPasswordChangeTime] [datetime] NULL,
	[LastLockoutTime] [datetime] NULL,
	[IsActive] [tinyint] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON
INSERT [dbo].[User] ([UserId], [OrganizationId], [Username], [Password], [EmailAddress], [FirstName], [LastName], [CreateTime], [LastLoginTime], [LastActivityTime], [LastPasswordChangeTime], [LastLockoutTime], [IsActive]) VALUES (1, 1, N'echost', N'12ff9c301bc06fe2ab52d5a3b07faa7a5bac41caf0d45b91e5b4158adafb31211bba6f9a34bc20030021efc1dd82ee2883bce34fb3f56c3cf281e520d3031ba5', N'lkurth@epicdiagnostics.com', N'Service', N'Host', CAST(0x0000A06E0155BD50 AS DateTime), CAST(0x0000A0DE011E068A AS DateTime), CAST(0x0000A0E00137C47F AS DateTime), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[User] OFF
GO


/****** Object:  Table [dbo].[UserAccountRestriction]    Script Date: 10/04/2012 13:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAccountRestriction](
	[UserId] [int] NOT NULL,
	[AccountRestrictionId] [int] NOT NULL,
 CONSTRAINT [PK_UserAccountRestriction] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[AccountRestrictionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[UserAssignedLocation]    Script Date: 10/04/2012 13:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAssignedLocation](
	[UserId] [int] NOT NULL,
	[LocationId] [int] NOT NULL,
 CONSTRAINT [PK_UserAssignedLocation] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LocationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[UserCreditCard]    Script Date: 10/04/2012 13:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserCreditCard](
	[UserId] [int] NOT NULL,
	[CreditCardId] [int] NOT NULL,
 CONSTRAINT [PK_UserCreditCard] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[CreditCardId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[UserRole]    Script Date: 10/04/2012 13:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[UserId] [int] NOT NULL,
	[RoleId] [smallint] NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[UserRole] ([UserId], [RoleId]) VALUES (1, 1)
GO


/****** Object:  Table [dbo].[UserSalt]    Script Date: 10/04/2012 13:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserSalt](
	[UserId] [int] NOT NULL,
	[Salt] [varchar](4096) NOT NULL,
 CONSTRAINT [PK_UserSalt] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[UserSalt] ([UserId], [Salt]) VALUES (1, N'BA76E730F8D9559D8729AEB2C480B7AB8710E0D4BDC2C2074E043D2410F3573393B0768FC54EA975087339C33E450B031C89882165164AC50C71F979AFF0347A26A89BA0851F8D52F93DFE3EAC7A9E1478ECD253D8C791DAB7B7D78BC9D41F32CD86B5AC3916B54A5B9E76B48FAAF77CC5B44E69A4BE9594B2A9E669E078776A8852C7B49825D2C920F567338879799B202E3C4F323EFBE8BC836A15192A34925F90C9213D4DBADAE4084B72F35959985064AB3B6938F642CE519D9E4A70B7844549B051205DC59F30DAB98DEFBFD918BDC4A167237E008208526BB19592CCBEE188185B47F5D25213CADB6781889E03366C6839CE157107285F8F36BEA48FFEFE6D761E96A062A999F922C2A631782E1033F4AEB6086B340B7F86BC3A259714A87A669BDB1F4A84D09109278BA536A17084319A967686982FB138F7243E2E1FADF0D7772E16F4EDCC4CE85D496BBEABD0B0608A36C4658CD492513F60850C882DDF6B70A3A7B244B2C7751EC1F04A7FD50EFD2D870C618C2BD314BA493538C64BEF7B7F6A2759D277D52840C12B9E3C537E7D877FD392A861162176B2622308DDDC40A731E90580A014E5965EB679BBA2AD3B79DAFADF543C4B3B2A54068E9699A402368E127B3B30D2DFCF2E02D6772AD7E5D5E8C477A8C76F39E1219AA39EA370DAD3F0C419232C6625DE7F81FD5E94E87BDB6E7BA6D04C85206CB1C6BCCA2C131F10AD9B4B54EF7166750B38ECAC19E419BE3308C9576B78A496A07049D3E3232F3A398EE5AF4534E92154F1A71C481EF95099A5E066F7E104FA0532D45CCEECC913AB32353EB2AEFFED37EBB82A5E48F5F94356DEB3BB731DA0EF0929D06A61284573A2AA31100CAA49733B590444BDB2337249F14ADE0445F8EBA8B392D9170F01A308B45C0722A8276531A65AD1194877F726A5C89DA6551E1444480B03346177BBA4AD33D7AD5ECCA1131149978544FCEE04DBA664010C3C6DFFC57417C2ED3818EDAF4F688F1D5B8154AC91BD882CC0CAA807C6CA25A96964B7D39553EECCE97D937FC81B7FBA9919385F50E0510D2966100BC989E62DF5C4B87DE9DA2BBEF754BB6CCFB212DAF864DDF19CABBDA2BD570C36C32521A450451D6C65152EB87EC9FB7E47ED118F7AB5C0C05534D2CE615E08F7E8DFBBC3BE8F047322D784736D4576116CACF25A6FE73EDDBD99C529A9DD07493CB64F8BD7A7424DBDDC77F5E7F09126D54442FC304B16AC4A88134B38E6175E5777BC46BFF4F1264C6F07781C04D77948F63634B03EF295E75761D708B8FD43E472CD78DFE30A2D25A98C15105E3481CC80981BDE050BC42DE5ECB563D31EE220C52498CFB3140D95107441D3995D252B8DDAAB34458D86A8D2959C38398F37204BB097146E9AA9C7C8D438A722B9D0B5CA0CA1C25001FD41F6E058E4918C676CCEB3BDE7235007061AAE60BE2866E4672CFE8F30C30D2999BA117D368AA099416289E0CDBD5536A7F8235FABC1C2084A3217848DC53F662E42DA087F6747B19282EDD5E1BACFC7E7E756E43F5E56E0C89847B41804EFEF383A3F39893804465A8D78EA443E0AFDFE61AA81157F6824038DC326D5F485CDE76FFF055E0A98DE585D2AF8F39B7A0815D071F09FE99CFD55D8768BB3EE41E651DFBC84BAC21161FA416611AE76A492F16489A42E99CB11496FDFEB1D01518241D6296FDF45F43DEDB0F747A4AF3B4FEE769C8659CABCC8F0BF0F13705E81799812EDBC9D437FDB3274C8AB6DDEA8B317B9FE9AB3BD6497AEFA39FC0D60F8DB8595F30D07A3F7888DD3F63C1C31210FFFE68914893D219EFCC5E71E7618F3697D2A9EDBE7175455A9BE33D6EB0D22DA444EFBF470E300E6EB9939F3E1D1AABC2BBD5DD83CD272A8B8C100C58E9A5974786F25487000DEAED4231BB48E1672C0488B48C09D4C37D8136216B6735D31315C79323819B87A2497F00D5FFA5914BB69A5251FC16789A9839552F66C87182DEDC77CE81425BB88A46AB9C1F8F482E1D1A4C398CDD30112F647DBD3BC8D67E3A7E01BC6706B25C02CB7D8E2BEDD7CBF75F6A0F86D0DE60C940171CC363CA6C4F7A0005F374E6806622DE4004189CB1F149285F3B14715CE9E3863CD751601C7739489FDCE943D281672B2FFEEDBAACCE6B67DB26A80E3164A4CD8047E9A2BEE85F5CC8C4ED0BA5E8B23E02820CB98799BE45C0C093B53790161E8527FB26C395B4555C2A2C4FD98B76F03256BFC073F5A4F64FCD01EB2C8DD87E02EC4E6E3D8E566D563082010CBB794223B77ED7014BB520A99F44694048C57E44B1600EE238DE74D8E558F9DB7D679502239AE343C7B31E73D534163AC39350ADF4C3752216E44894CA1238AF8CBAC29A354CCACB6BFCFEDC0833C15BBEB90EC5B1F70F833784C2EE38B643673E85B58A621BD8A6BDBBB6BBB4C4F49E68D22D93FD55B5581AFB65444B98A6B7A6615FB4A576F56858AA33004DF1BD016DA78FA039F3C21BEC62C79D4340BC6CA98B5B8F7250DE2225E2624485A500861D6916B9CB6F5EEED56DC980E08251BC932844CD3D5465D4783C0A773101D5B0808310282808A755CCCE6964CB4EF91558AB5DB935666592BBDED485AF98115DEFDE6E3F856086B91344C62B4F0A396717D88F6B3BB1F727DCFDB4AD23DFCBEC2F9D36C08F00BD07AA1B3BBEAD5B09919F2EF66C0BCEA7AF632A539B013470FA4B28D0936061B9B0291B81C28904502D320581465D99FAB0C60F8E5E5D2614EA8DD94132E12F2DCE59089EFD86804FF1E557E92D22CB31D75A67796E2F68325A8A45973D20DFC93E359F0CEA770F6182B0AE623C997968C1A200D8F3E51BAE4A6EC5C704FE0EF31851BB8D8D4952E9C3F9D675CDAE0669A68102501F01F4167F61024F48203D6047E07')
GO


/****** Object:  Table [dbo].[UserSetting]    Script Date: 10/04/2012 13:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserSetting](
	[UserId] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Value] [varchar](2048) NOT NULL,
 CONSTRAINT [PK_UserSetting] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[UserSetting] ([UserId], [Name], [Value]) VALUES (1, N'AuthorizeId', N'8991770')
INSERT [dbo].[UserSetting] ([UserId], [Name], [Value]) VALUES (1, N'Language', N'en-US')
INSERT [dbo].[UserSetting] ([UserId], [Name], [Value]) VALUES (1, N'PortletLocationCenter', N'DeviceStateController')
INSERT [dbo].[UserSetting] ([UserId], [Name], [Value]) VALUES (1, N'PortletLocationLeft', N'WeatherController,TreatmentsController')
INSERT [dbo].[UserSetting] ([UserId], [Name], [Value]) VALUES (1, N'PortletLocationRight', N'AlertController,RecentActivityController')
INSERT [dbo].[UserSetting] ([UserId], [Name], [Value]) VALUES (1, N'Region', N'America/Phoenix')
INSERT [dbo].[UserSetting] ([UserId], [Name], [Value]) VALUES (1, N'RegionAuto', N'True')
INSERT [dbo].[UserSetting] ([UserId], [Name], [Value]) VALUES (1, N'SupportPass', N'7B19D09821BD69E81A4517F5E410FF4259264361F9FEDB08870037F7AE9088DE4C7E2201975CD2DAA21E67E291DE0946')
INSERT [dbo].[UserSetting] ([UserId], [Name], [Value]) VALUES (1, N'SupportUser', N'echost14472')
GO



/****** DEFAULT VALUES ******/

/****** Object:  Default [DF_AccountRestriction_CreationTime]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[AccountRestriction] ADD  CONSTRAINT [DF_AccountRestriction_CreationTime]  DEFAULT (getutcdate()) FOR [CreationTime]
GO

/****** Object:  Default [DF_AccountRestriction_IsActive]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[AccountRestriction] ADD  CONSTRAINT [DF_AccountRestriction_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO

/****** Object:  Default [DF_ActivityType_Description]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[ActivityType] ADD  CONSTRAINT [DF_ActivityType_Description]  DEFAULT (NULL) FOR [Description]
GO

/****** Object:  Default [DF_AnalysisResult_AI1]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[AnalysisResult] ADD  CONSTRAINT [DF_AnalysisResult_AI1]  DEFAULT ((0)) FOR [AI1]
GO

/****** Object:  Default [DF_AnalysisResult_AI2]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[AnalysisResult] ADD  CONSTRAINT [DF_AnalysisResult_AI2]  DEFAULT ((0)) FOR [AI2]
GO

/****** Object:  Default [DF_AnalysisResult_AI3]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[AnalysisResult] ADD  CONSTRAINT [DF_AnalysisResult_AI3]  DEFAULT ((0)) FOR [AI3]
GO

/****** Object:  Default [DF_AnalysisResult_AI4]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[AnalysisResult] ADD  CONSTRAINT [DF_AnalysisResult_AI4]  DEFAULT ((0)) FOR [AI4]
GO

/****** Object:  Default [DF_AnalysisResult_AnalysisTime]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[AnalysisResult] ADD  CONSTRAINT [DF_AnalysisResult_AnalysisTime]  DEFAULT (getutcdate()) FOR [AnalysisTime]
GO

/****** Object:  Default [DF_AnalysisResult_AngleofRotation]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[AnalysisResult] ADD  CONSTRAINT [DF_AnalysisResult_AngleofRotation]  DEFAULT ((0)) FOR [AngleOfRotation]
GO

/****** Object:  Default [DF_AnalysisResult_AverageIntensity]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[AnalysisResult] ADD  CONSTRAINT [DF_AnalysisResult_AverageIntensity]  DEFAULT ((0)) FOR [AverageIntensity]
GO

/****** Object:  Default [DF_AnalysisResult_BreakCoefficient]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[AnalysisResult] ADD  CONSTRAINT [DF_AnalysisResult_BreakCoefficient]  DEFAULT ((0.0)) FOR [BreakCoefficient]
GO

/****** Object:  Default [DF_AnalysisResult_CenterX]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[AnalysisResult] ADD  CONSTRAINT [DF_AnalysisResult_CenterX]  DEFAULT ((0)) FOR [CenterX]
GO

/****** Object:  Default [DF_AnalysisResult_CenterY]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[AnalysisResult] ADD  CONSTRAINT [DF_AnalysisResult_CenterY]  DEFAULT ((0)) FOR [CenterY]
GO

/****** Object:  Default [DF_AnalysisResult_EndAngle]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[AnalysisResult] ADD  CONSTRAINT [DF_AnalysisResult_EndAngle]  DEFAULT ((0)) FOR [EndAngle]
GO

/****** Object:  Default [DF_AnalysisResult_Entropy]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[AnalysisResult] ADD  CONSTRAINT [DF_AnalysisResult_Entropy]  DEFAULT ((0)) FOR [Entropy]
GO

/****** Object:  Default [DF_AnalysisResult_FingerType]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[AnalysisResult] ADD  CONSTRAINT [DF_AnalysisResult_FingerType]  DEFAULT ((0)) FOR [FingerType]
GO

/****** Object:  Default [DF_AnalysisResult_Form1_1]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[AnalysisResult] ADD  CONSTRAINT [DF_AnalysisResult_Form1_1]  DEFAULT ((0)) FOR [Form1_1]
GO

/****** Object:  Default [DF_AnalysisResult_Form1_2]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[AnalysisResult] ADD  CONSTRAINT [DF_AnalysisResult_Form1_2]  DEFAULT ((0)) FOR [Form1_2]
GO

/****** Object:  Default [DF_AnalysisResult_Form1_3]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[AnalysisResult] ADD  CONSTRAINT [DF_AnalysisResult_Form1_3]  DEFAULT ((0)) FOR [Form1_3]
GO

/****** Object:  Default [DF_AnalysisResult_Form1_4]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[AnalysisResult] ADD  CONSTRAINT [DF_AnalysisResult_Form1_4]  DEFAULT ((0)) FOR [Form1_4]
GO

/****** Object:  Default [DF_AnalysisResult_Form2]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[AnalysisResult] ADD  CONSTRAINT [DF_AnalysisResult_Form2]  DEFAULT ((0.0)) FOR [Form2]
GO

/****** Object:  Default [DF_AnalysisResult_Form2Prime]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[AnalysisResult] ADD  CONSTRAINT [DF_AnalysisResult_Form2Prime]  DEFAULT ((0)) FOR [Form2Prime]
GO

/****** Object:  Default [DF_AnalysisResult_FormCoefficient]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[AnalysisResult] ADD  CONSTRAINT [DF_AnalysisResult_FormCoefficient]  DEFAULT ((0)) FOR [FormCoefficient]
GO

/****** Object:  Default [DF_AnalysisResult_FractalCoefficient]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[AnalysisResult] ADD  CONSTRAINT [DF_AnalysisResult_FractalCoefficient]  DEFAULT ((0)) FOR [FractalCoefficient]
GO

/****** Object:  Default [DF_AnalysisResult_IntegralArea]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[AnalysisResult] ADD  CONSTRAINT [DF_AnalysisResult_IntegralArea]  DEFAULT ((0)) FOR [IntegralArea]
GO

/****** Object:  Default [DF_AnalysisResult_IsFiltered]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[AnalysisResult] ADD  CONSTRAINT [DF_AnalysisResult_IsFiltered]  DEFAULT ((0)) FOR [IsFiltered]
GO

/****** Object:  Default [DF_AnalysisResult_JsInteger]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[AnalysisResult] ADD  CONSTRAINT [DF_AnalysisResult_JsInteger]  DEFAULT ((0)) FOR [JsInteger]
GO

/****** Object:  Default [DF_AnalysisResult_NoiseLevel]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[AnalysisResult] ADD  CONSTRAINT [DF_AnalysisResult_NoiseLevel]  DEFAULT ((30)) FOR [NoiseLevel]
GO

/****** Object:  Default [DF_AnalysisResult_NormalizedArea]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[AnalysisResult] ADD  CONSTRAINT [DF_AnalysisResult_NormalizedArea]  DEFAULT ((0)) FOR [NormalizedArea]
GO

/****** Object:  Default [DF_AnalysisResult_RadiusMax]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[AnalysisResult] ADD  CONSTRAINT [DF_AnalysisResult_RadiusMax]  DEFAULT ((0)) FOR [RadiusMax]
GO

/****** Object:  Default [DF_AnalysisResult_RadiusMin]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[AnalysisResult] ADD  CONSTRAINT [DF_AnalysisResult_RadiusMin]  DEFAULT ((0)) FOR [RadiusMin]
GO

/****** Object:  Default [DF_AnalysisResult_RingIntensity]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[AnalysisResult] ADD  CONSTRAINT [DF_AnalysisResult_RingIntensity]  DEFAULT ((0.0)) FOR [RingIntensity]
GO

/****** Object:  Default [DF_AnalysisResult_RingThickness]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[AnalysisResult] ADD  CONSTRAINT [DF_AnalysisResult_RingThickness]  DEFAULT ((0.0)) FOR [RingThickness]
GO

/****** Object:  Default [DF_AnalysisResult_SectorArea]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[AnalysisResult] ADD  CONSTRAINT [DF_AnalysisResult_SectorArea]  DEFAULT ((0)) FOR [SectorArea]
GO

/****** Object:  Default [DF_AnalysisResult_SectorNumber]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[AnalysisResult] ADD  CONSTRAINT [DF_AnalysisResult_SectorNumber]  DEFAULT ((0)) FOR [SectorNumber]
GO

/****** Object:  Default [DF_AnalysisResult_SoftwareVersion]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[AnalysisResult] ADD  CONSTRAINT [DF_AnalysisResult_SoftwareVersion]  DEFAULT ('-Unknown-') FOR [SoftwareVersion]
GO

/****** Object:  Default [DF_AnalysisResult_StartAngle]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[AnalysisResult] ADD  CONSTRAINT [DF_AnalysisResult_StartAngle]  DEFAULT ((0)) FOR [StartAngle]
GO

/****** Object:  Default [DF_AnalysisResult_UserName]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[AnalysisResult] ADD  CONSTRAINT [DF_AnalysisResult_UserName]  DEFAULT ('Administrator') FOR [UserName]
GO

/****** Object:  Default [DF_CalculationDebugData_Form2Prime]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[CalculationDebugData] ADD  CONSTRAINT [DF_CalculationDebugData_Form2Prime]  DEFAULT ((0)) FOR [Form2Prime]
GO

/****** Object:  Default [DF_Calibration_ReceivedTime]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[Calibration] ADD  CONSTRAINT [DF_Calibration_ReceivedTime]  DEFAULT (getutcdate()) FOR [ReceivedTime]
GO

/****** Object:  Default [DF_Device_CurrentStatus]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[Device] ADD  CONSTRAINT [DF_Device_CurrentStatus]  DEFAULT ('') FOR [CurrentStatus]
GO

/****** Object:  Default [DF_Device_DeviceState]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[Device] ADD  CONSTRAINT [DF_Device_DeviceState]  DEFAULT ((1)) FOR [DeviceState]
GO

/****** Object:  Default [DF_Device_ScansAvailable]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[Device] ADD  CONSTRAINT [DF_Device_ScansAvailable]  DEFAULT ((0)) FOR [ScansAvailable]
GO

/****** Object:  Default [DF_Device_ScansCompleted]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[Device] ADD  CONSTRAINT [DF_Device_ScansCompleted]  DEFAULT ((0)) FOR [ScansCompleted]
GO

/****** Object:  Default [DF_Device_UidQualifier]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[Device] ADD  CONSTRAINT [DF_Device_UidQualifier]  DEFAULT ([dbo].[GetUidQualifier]()) FOR [UidQualifier]
GO

/****** Object:  Default [DF_DeviceStateTracking_ChangeReason]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[DeviceStateTracking] ADD  CONSTRAINT [DF_DeviceStateTracking_ChangeReason]  DEFAULT ('') FOR [ChangeReason]
GO

/****** Object:  Default [DF_DeviceStateTracking_ChangeTime]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[DeviceStateTracking] ADD  CONSTRAINT [DF_DeviceStateTracking_ChangeTime]  DEFAULT (getutcdate()) FOR [ChangeTime]
GO

/****** Object:  Default [DF_DeviceStateTracking_PreviousState]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[DeviceStateTracking] ADD  CONSTRAINT [DF_DeviceStateTracking_PreviousState]  DEFAULT ((0)) FOR [PreviousState]
GO

/****** Object:  Default [DF_LicenseOrganSystem_LicenseMode]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[LicenseOrganSystem] ADD  CONSTRAINT [DF_LicenseOrganSystem_LicenseMode]  DEFAULT ((1)) FOR [LicenseMode]
GO

/****** Object:  Default [DF_Location_AddressLine1]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[Location] ADD  CONSTRAINT [DF_Location_AddressLine1]  DEFAULT ('') FOR [AddressLine1]
GO

/****** Object:  Default [DF_Location_AddressLine2]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[Location] ADD  CONSTRAINT [DF_Location_AddressLine2]  DEFAULT ('') FOR [AddressLine2]
GO

/****** Object:  Default [DF_Location_City]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[Location] ADD  CONSTRAINT [DF_Location_City]  DEFAULT ('') FOR [City]
GO

/****** Object:  Default [DF_Location_Country]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[Location] ADD  CONSTRAINT [DF_Location_Country]  DEFAULT ('') FOR [Country]
GO

/****** Object:  Default [DF_Location_IsActive]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[Location] ADD  CONSTRAINT [DF_Location_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO

/****** Object:  Default [DF_Location_PostalCode]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[Location] ADD  CONSTRAINT [DF_Location_PostalCode]  DEFAULT ('') FOR [PostalCode]
GO

/****** Object:  Default [DF_Location_State]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[Location] ADD  CONSTRAINT [DF_Location_State]  DEFAULT ('') FOR [State]
GO

/****** Object:  Default [DF_Message_EndTime]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[Message] ADD  CONSTRAINT [DF_Message_EndTime]  DEFAULT (NULL) FOR [EndTime]
GO

/****** Object:  Default [DF_Message_IsActive]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[Message] ADD  CONSTRAINT [DF_Message_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO

/****** Object:  Default [DF_Organization_IsActive]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[Organization] ADD  CONSTRAINT [DF_Organization_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO

/****** Object:  Default [DF_Patient_ReceivedTime]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[Patient] ADD  CONSTRAINT [DF_Patient_ReceivedTime]  DEFAULT (getutcdate()) FOR [ReceivedTime]
GO

/****** Object:  Default [DF_PatientPrescanQuestion_AlcoholQuestion]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[PatientPrescanQuestion] ADD  CONSTRAINT [DF_PatientPrescanQuestion_AlcoholQuestion]  DEFAULT ((0)) FOR [AlcoholQuestion]
GO

/****** Object:  Default [DF_PatientPrescanQuestion_CaffeineQuestion]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[PatientPrescanQuestion] ADD  CONSTRAINT [DF_PatientPrescanQuestion_CaffeineQuestion]  DEFAULT ((0)) FOR [CaffeineQuestion]
GO

/****** Object:  Default [DF_PatientPrescanQuestion_WheatQuestion]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[PatientPrescanQuestion] ADD  CONSTRAINT [DF_PatientPrescanQuestion_WheatQuestion]  DEFAULT ((0)) FOR [WheatQuestion]
GO

/****** Object:  Default [DF_PurchaseHistory_AmountPaid]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[PurchaseHistory] ADD  CONSTRAINT [DF_PurchaseHistory_AmountPaid]  DEFAULT ((0)) FOR [AmountPaid]
GO

/****** Object:  Default [DF_PurchaseHistory_PurchaseNotes]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[PurchaseHistory] ADD  CONSTRAINT [DF_PurchaseHistory_PurchaseNotes]  DEFAULT ('') FOR [PurchaseNotes]
GO

/****** Object:  Default [DF_ScanRate_IsActive]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[ScanRate] ADD  CONSTRAINT [DF_ScanRate_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO

/****** Object:  Default [DF_SupportArea_IsActive]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[SupportArea] ADD  CONSTRAINT [DF_SupportArea_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO

/****** Object:  Default [DF_SupportIssue_FromUserId]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[SupportIssue] ADD  CONSTRAINT [DF_SupportIssue_FromUserId]  DEFAULT (NULL) FOR [FromUserId]
GO

/****** Object:  Default [DF_SupportIssue_IsActive]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[SupportIssue] ADD  CONSTRAINT [DF_SupportIssue_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO

/****** Object:  Default [DF_SupportIssue_IsClosedByFromUser]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[SupportIssue] ADD  CONSTRAINT [DF_SupportIssue_IsClosedByFromUser]  DEFAULT ((0)) FOR [IsClosedByFromUser]
GO

/****** Object:  Default [DF_SupportIssue_IsClosedByToUser]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[SupportIssue] ADD  CONSTRAINT [DF_SupportIssue_IsClosedByToUser]  DEFAULT ((0)) FOR [IsClosedByToUser]
GO

/****** Object:  Default [DF_SupportIssue_IsPublic]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[SupportIssue] ADD  CONSTRAINT [DF_SupportIssue_IsPublic]  DEFAULT ((0)) FOR [IsPublic]
GO

/****** Object:  Default [DF_SupportIssue_ParentId]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[SupportIssue] ADD  CONSTRAINT [DF_SupportIssue_ParentId]  DEFAULT ((0)) FOR [ParentId]
GO

/****** Object:  Default [DF_SupportIssue_Priority]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[SupportIssue] ADD  CONSTRAINT [DF_SupportIssue_Priority]  DEFAULT ((0)) FOR [Priority]
GO

/****** Object:  Default [DF_SupportIssue_Status]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[SupportIssue] ADD  CONSTRAINT [DF_SupportIssue_Status]  DEFAULT ('') FOR [Status]
GO

/****** Object:  Default [DF_SupportIssue_ToUserId]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[SupportIssue] ADD  CONSTRAINT [DF_SupportIssue_ToUserId]  DEFAULT (NULL) FOR [ToUserId]
GO

/****** Object:  Default [DF_Treatment_ReceivedTime]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[Treatment] ADD  CONSTRAINT [DF_Treatment_ReceivedTime]  DEFAULT (getutcdate()) FOR [ReceivedTime]
GO

/****** Object:  Default [DF_UpdateStatus_UpdateTime]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[UpdateStatus] ADD  CONSTRAINT [DF_UpdateStatus_UpdateTime]  DEFAULT (getutcdate()) FOR [UpdateTime]
GO

/****** Object:  Default [DF_User_CreateTime]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_CreateTime]  DEFAULT (getutcdate()) FOR [CreateTime]
GO

/****** Object:  Default [DF_User_IsActive]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO

/****** Object:  Default [DF_UserSetting_Value]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[UserSetting] ADD  CONSTRAINT [DF_UserSetting_Value]  DEFAULT ('') FOR [Value]
GO



/****** FOREIGN KEYS ******/

/****** Object:  ForeignKey [FK_ActiveOrganization_ActivityType]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[ActiveOrganization]  WITH CHECK ADD  CONSTRAINT [FK_ActiveOrganization_ActivityType] FOREIGN KEY([ActivityTypeId])
REFERENCES [dbo].[ActivityType] ([ActivityTypeId])
GO
ALTER TABLE [dbo].[ActiveOrganization] CHECK CONSTRAINT [FK_ActiveOrganization_ActivityType]
GO

/****** Object:  ForeignKey [FK_ActiveOrganization_Location]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[ActiveOrganization]  WITH CHECK ADD  CONSTRAINT [FK_ActiveOrganization_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([LocationId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ActiveOrganization] CHECK CONSTRAINT [FK_ActiveOrganization_Location]
GO

/****** Object:  ForeignKey [FK_AnalysisResult_Treatment]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[AnalysisResult]  WITH CHECK ADD  CONSTRAINT [FK_AnalysisResult_Treatment] FOREIGN KEY([TreatmentId])
REFERENCES [dbo].[Treatment] ([TreatmentId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AnalysisResult] CHECK CONSTRAINT [FK_AnalysisResult_Treatment]
GO

/****** Object:  ForeignKey [FK_CalculationDebugData_Treatment]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[CalculationDebugData]  WITH CHECK ADD  CONSTRAINT [FK_CalculationDebugData_Treatment] FOREIGN KEY([TreatmentId])
REFERENCES [dbo].[Treatment] ([TreatmentId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CalculationDebugData] CHECK CONSTRAINT [FK_CalculationDebugData_Treatment]
GO

/****** Object:  ForeignKey [FK_Calibration_Device]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[Calibration]  WITH CHECK ADD  CONSTRAINT [FK_Calibration_Device] FOREIGN KEY([DeviceId])
REFERENCES [dbo].[Device] ([DeviceId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Calibration] CHECK CONSTRAINT [FK_Calibration_Device]
GO

/****** Object:  ForeignKey [FK_Calibration_ImageSet]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[Calibration]  WITH CHECK ADD  CONSTRAINT [FK_Calibration_ImageSet] FOREIGN KEY([ImageSetId])
REFERENCES [dbo].[ImageSet] ([ImageSetId])
GO
ALTER TABLE [dbo].[Calibration] CHECK CONSTRAINT [FK_Calibration_ImageSet]
GO

/****** Object:  ForeignKey [FK_Contact_Organization]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[Contact]  WITH CHECK ADD  CONSTRAINT [FK_Contact_Organization] FOREIGN KEY([OrganizationId])
REFERENCES [dbo].[Organization] ([OrganizationId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Contact] CHECK CONSTRAINT [FK_Contact_Organization]
GO

/****** Object:  ForeignKey [FK_Device_Location]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[Device]  WITH CHECK ADD  CONSTRAINT [FK_Device_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([LocationId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Device] CHECK CONSTRAINT [FK_Device_Location]
GO

/****** Object:  ForeignKey [FK_DeviceEvent_Device]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[DeviceEvent]  WITH CHECK ADD  CONSTRAINT [FK_DeviceEvent_Device] FOREIGN KEY([DeviceId])
REFERENCES [dbo].[Device] ([DeviceId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DeviceEvent] CHECK CONSTRAINT [FK_DeviceEvent_Device]
GO

/****** Object:  ForeignKey [FK_DeviceMessage_Device]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[DeviceMessage]  WITH CHECK ADD  CONSTRAINT [FK_DeviceMessage_Device] FOREIGN KEY([DeviceId])
REFERENCES [dbo].[Device] ([DeviceId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DeviceMessage] CHECK CONSTRAINT [FK_DeviceMessage_Device]
GO

/****** Object:  ForeignKey [FK_DeviceMessage_Message]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[DeviceMessage]  WITH CHECK ADD  CONSTRAINT [FK_DeviceMessage_Message] FOREIGN KEY([MessageId])
REFERENCES [dbo].[Message] ([MessageId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DeviceMessage] CHECK CONSTRAINT [FK_DeviceMessage_Message]
GO

/****** Object:  ForeignKey [FK_DeviceStateTracking_Device]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[DeviceStateTracking]  WITH CHECK ADD  CONSTRAINT [FK_DeviceStateTracking_Device] FOREIGN KEY([DeviceId])
REFERENCES [dbo].[Device] ([DeviceId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DeviceStateTracking] CHECK CONSTRAINT [FK_DeviceStateTracking_Device]
GO

/****** Object:  ForeignKey [FK_ExceptionLog_Device]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[ExceptionLog]  WITH CHECK ADD  CONSTRAINT [FK_ExceptionLog_Device] FOREIGN KEY([DeviceId])
REFERENCES [dbo].[Device] ([DeviceId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ExceptionLog] CHECK CONSTRAINT [FK_ExceptionLog_Device]
GO

/****** Object:  ForeignKey [FK_LicenseOrganSystem_OrganSystem]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[LicenseOrganSystem]  WITH CHECK ADD  CONSTRAINT [FK_LicenseOrganSystem_OrganSystem] FOREIGN KEY([OrganSystemId])
REFERENCES [dbo].[OrganSystem] ([OrganSystemId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LicenseOrganSystem] CHECK CONSTRAINT [FK_LicenseOrganSystem_OrganSystem]
GO

/****** Object:  ForeignKey [FK_Location_Organization]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[Location]  WITH CHECK ADD  CONSTRAINT [FK_Location_Organization] FOREIGN KEY([OrganizationId])
REFERENCES [dbo].[Organization] ([OrganizationId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Location] CHECK CONSTRAINT [FK_Location_Organization]
GO

/****** Object:  ForeignKey [FK_NBAnalysisResult_OrganSystem]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[NBAnalysisResult]  WITH CHECK ADD  CONSTRAINT [FK_NBAnalysisResult_OrganSystem] FOREIGN KEY([OrganSystemId])
REFERENCES [dbo].[OrganSystem] ([OrganSystemId])
GO
ALTER TABLE [dbo].[NBAnalysisResult] CHECK CONSTRAINT [FK_NBAnalysisResult_OrganSystem]
GO

/****** Object:  ForeignKey [FK_NBAnalysisResult_Treatment]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[NBAnalysisResult]  WITH CHECK ADD  CONSTRAINT [FK_NBAnalysisResult_Treatment] FOREIGN KEY([TreatmentId])
REFERENCES [dbo].[Treatment] ([TreatmentId])
GO
ALTER TABLE [dbo].[NBAnalysisResult] CHECK CONSTRAINT [FK_NBAnalysisResult_Treatment]
GO

/****** Object:  ForeignKey [FK_OrganSystemOrgan_LicenseOrganSystem]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[OrganSystemOrgan]  WITH CHECK ADD  CONSTRAINT [FK_OrganSystemOrgan_LicenseOrganSystem] FOREIGN KEY([LicenseOrganSystemId])
REFERENCES [dbo].[LicenseOrganSystem] ([LicenseOrganSystemId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrganSystemOrgan] CHECK CONSTRAINT [FK_OrganSystemOrgan_LicenseOrganSystem]
GO

/****** Object:  ForeignKey [FK_OrganSystemOrgan_Organ]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[OrganSystemOrgan]  WITH CHECK ADD  CONSTRAINT [FK_OrganSystemOrgan_Organ] FOREIGN KEY([OrganId])
REFERENCES [dbo].[Organ] ([OrganId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrganSystemOrgan] CHECK CONSTRAINT [FK_OrganSystemOrgan_Organ]
GO

/****** Object:  ForeignKey [FK_Patient_Location]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[Patient]  WITH CHECK ADD  CONSTRAINT [FK_Patient_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([LocationId])
GO
ALTER TABLE [dbo].[Patient] CHECK CONSTRAINT [FK_Patient_Location]
GO

/****** Object:  ForeignKey [FK_PatientPrescanQuestion_Treatment]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[PatientPrescanQuestion]  WITH CHECK ADD  CONSTRAINT [FK_PatientPrescanQuestion_Treatment] FOREIGN KEY([TreatmentId])
REFERENCES [dbo].[Treatment] ([TreatmentId])
GO
ALTER TABLE [dbo].[PatientPrescanQuestion] CHECK CONSTRAINT [FK_PatientPrescanQuestion_Treatment]
GO

/****** Object:  ForeignKey [FK_PurchaseHistory_Device]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[PurchaseHistory]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseHistory_Device] FOREIGN KEY([DeviceId])
REFERENCES [dbo].[Device] ([DeviceId])
GO
ALTER TABLE [dbo].[PurchaseHistory] CHECK CONSTRAINT [FK_PurchaseHistory_Device]
GO

/****** Object:  ForeignKey [FK_PurchaseHistory_Location]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[PurchaseHistory]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseHistory_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([LocationId])
GO
ALTER TABLE [dbo].[PurchaseHistory] CHECK CONSTRAINT [FK_PurchaseHistory_Location]
GO

/****** Object:  ForeignKey [FK_PurchaseHistory_User]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[PurchaseHistory]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseHistory_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[PurchaseHistory] CHECK CONSTRAINT [FK_PurchaseHistory_User]
GO

/****** Object:  ForeignKey [FK_ScanHistory_Device]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[ScanHistory]  WITH CHECK ADD  CONSTRAINT [FK_ScanHistory_Device] FOREIGN KEY([DeviceId])
REFERENCES [dbo].[Device] ([DeviceId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ScanHistory] CHECK CONSTRAINT [FK_ScanHistory_Device]
GO

/****** Object:  ForeignKey [FK_Severity_Organ]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[Severity]  WITH CHECK ADD  CONSTRAINT [FK_Severity_Organ] FOREIGN KEY([OrganId])
REFERENCES [dbo].[Organ] ([OrganId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Severity] CHECK CONSTRAINT [FK_Severity_Organ]
GO

/****** Object:  ForeignKey [FK_Severity_Treatment]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[Severity]  WITH CHECK ADD  CONSTRAINT [FK_Severity_Treatment] FOREIGN KEY([TreatmentId])
REFERENCES [dbo].[Treatment] ([TreatmentId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Severity] CHECK CONSTRAINT [FK_Severity_Treatment]
GO

/****** Object:  ForeignKey [FK_SupportIssue_FromUser]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[SupportIssue]  WITH CHECK ADD  CONSTRAINT [FK_SupportIssue_FromUser] FOREIGN KEY([FromUserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[SupportIssue] CHECK CONSTRAINT [FK_SupportIssue_FromUser]
GO

/****** Object:  ForeignKey [FK_SupportIssue_SupportArea]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[SupportIssue]  WITH CHECK ADD  CONSTRAINT [FK_SupportIssue_SupportArea] FOREIGN KEY([SupportAreaId])
REFERENCES [dbo].[SupportArea] ([SupportAreaId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SupportIssue] CHECK CONSTRAINT [FK_SupportIssue_SupportArea]
GO

/****** Object:  ForeignKey [FK_SupportIssue_ToUser]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[SupportIssue]  WITH CHECK ADD  CONSTRAINT [FK_SupportIssue_ToUser] FOREIGN KEY([ToUserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[SupportIssue] CHECK CONSTRAINT [FK_SupportIssue_ToUser]
GO

/****** Object:  ForeignKey [FK_Treatment_Calibration]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[Treatment]  WITH CHECK ADD  CONSTRAINT [FK_Treatment_Calibration] FOREIGN KEY([CalibrationId])
REFERENCES [dbo].[Calibration] ([CalibrationId])
GO
ALTER TABLE [dbo].[Treatment] CHECK CONSTRAINT [FK_Treatment_Calibration]
GO

/****** Object:  ForeignKey [FK_Treatment_EnergizedImageSet]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[Treatment]  WITH CHECK ADD  CONSTRAINT [FK_Treatment_EnergizedImageSet] FOREIGN KEY([EnergizedImageSetId])
REFERENCES [dbo].[ImageSet] ([ImageSetId])
GO
ALTER TABLE [dbo].[Treatment] CHECK CONSTRAINT [FK_Treatment_EnergizedImageSet]
GO

/****** Object:  ForeignKey [FK_Treatment_FingerImageSet]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[Treatment]  WITH CHECK ADD  CONSTRAINT [FK_Treatment_FingerImageSet] FOREIGN KEY([FingerImageSetId])
REFERENCES [dbo].[ImageSet] ([ImageSetId])
GO
ALTER TABLE [dbo].[Treatment] CHECK CONSTRAINT [FK_Treatment_FingerImageSet]
GO

/****** Object:  ForeignKey [FK_Treatment_Patient]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[Treatment]  WITH CHECK ADD  CONSTRAINT [FK_Treatment_Patient] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patient] ([PatientId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Treatment] CHECK CONSTRAINT [FK_Treatment_Patient]
GO

/****** Object:  ForeignKey [FK_User_Organization]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Organization] FOREIGN KEY([OrganizationId])
REFERENCES [dbo].[Organization] ([OrganizationId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Organization]
GO

/****** Object:  ForeignKey [FK_UserAccountRestriction_AccountRestriction]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[UserAccountRestriction]  WITH CHECK ADD  CONSTRAINT [FK_UserAccountRestriction_AccountRestriction] FOREIGN KEY([AccountRestrictionId])
REFERENCES [dbo].[AccountRestriction] ([AccountRestrictionId])
GO
ALTER TABLE [dbo].[UserAccountRestriction] CHECK CONSTRAINT [FK_UserAccountRestriction_AccountRestriction]
GO

/****** Object:  ForeignKey [FK_UserAccountRestriction_User]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[UserAccountRestriction]  WITH CHECK ADD  CONSTRAINT [FK_UserAccountRestriction_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[UserAccountRestriction] CHECK CONSTRAINT [FK_UserAccountRestriction_User]
GO

/****** Object:  ForeignKey [FK_UserAssignedLocation_Location]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[UserAssignedLocation]  WITH CHECK ADD  CONSTRAINT [FK_UserAssignedLocation_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([LocationId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserAssignedLocation] CHECK CONSTRAINT [FK_UserAssignedLocation_Location]
GO

/****** Object:  ForeignKey [FK_UserAssignedLocation_User]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[UserAssignedLocation]  WITH CHECK ADD  CONSTRAINT [FK_UserAssignedLocation_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[UserAssignedLocation] CHECK CONSTRAINT [FK_UserAssignedLocation_User]
GO

/****** Object:  ForeignKey [FK_UserCreditCard_CreditCard]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[UserCreditCard]  WITH CHECK ADD  CONSTRAINT [FK_UserCreditCard_CreditCard] FOREIGN KEY([CreditCardId])
REFERENCES [dbo].[CreditCard] ([CreditCardId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserCreditCard] CHECK CONSTRAINT [FK_UserCreditCard_CreditCard]
GO

/****** Object:  ForeignKey [FK_UserCreditCard_User]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[UserCreditCard]  WITH CHECK ADD  CONSTRAINT [FK_UserCreditCard_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserCreditCard] CHECK CONSTRAINT [FK_UserCreditCard_User]
GO

/****** Object:  ForeignKey [FK_UserRole_Role]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_Role]
GO

/****** Object:  ForeignKey [FK_UserRole_User]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_User]
GO

/****** Object:  ForeignKey [FK_UserSalt_User]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[UserSalt]  WITH CHECK ADD  CONSTRAINT [FK_UserSalt_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserSalt] CHECK CONSTRAINT [FK_UserSalt_User]
GO

/****** Object:  ForeignKey [FK_UserSetting_User]    Script Date: 10/04/2012 13:41:17 ******/
ALTER TABLE [dbo].[UserSetting]  WITH CHECK ADD  CONSTRAINT [FK_UserSetting_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserSetting] CHECK CONSTRAINT [FK_UserSetting_User]
GO
