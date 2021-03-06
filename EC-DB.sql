USE [EPICCentral]
GO

-- Set to abort all if error occurs.
SET XACT_ABORT ON
GO

-- Check SchemaVersion to see if it exists. If not, then run this ...
IF NOT EXISTS (SELECT *
			   FROM INFORMATION_SCHEMA.TABLES
			   WHERE TABLE_SCHEMA = 'dbo' AND TABLE_CATALOG = 'EPICCentral' AND TABLE_NAME = 'SchemaVersion')
BEGIN

PRINT 'No SchemaVersion table. Major reorganization ...'

-- Remove all the foreign keys first.
PRINT 'Dropping current foreign keys ...'

ALTER TABLE [dbo].[EC_ActiveCustomers]  DROP  CONSTRAINT [FK_EC_ActiveCustomers_ActivityTypeDm]
ALTER TABLE [dbo].[EC_ActiveCustomers]  DROP  CONSTRAINT [FK_EC_ActiveCustomers_EC_CustomerLocation]
ALTER TABLE [dbo].[EC_Authorize_NET]  DROP  CONSTRAINT [FK_EC_Authorize_NET_EC_Customer]
ALTER TABLE [dbo].[EC_Authorize_NET]  DROP  CONSTRAINT [FK_EC_Authorize_NET_EC_User]
ALTER TABLE [dbo].[EC_BillingInfo]  DROP  CONSTRAINT [FK_EC_BillingInfo_EC_CustomerLocation]
ALTER TABLE [dbo].[EC_CustomerDevice]  DROP  CONSTRAINT [FK_EC_CustomerDevice_EC_CustomerLocation]
ALTER TABLE [dbo].[EC_CustomerDevice]  DROP  CONSTRAINT [FK_EC_CustomerDevice_EC_Device1]
ALTER TABLE [dbo].[EC_CustomerLocation]  DROP  CONSTRAINT [FK_CustomerLocation_Customer]
ALTER TABLE [dbo].[EC_ExceptionLog]  DROP  CONSTRAINT [FK_EC_ExceptionLog_EC_CustomerLocation]
ALTER TABLE [dbo].[EC_MessageBank]  DROP  CONSTRAINT [FK_EC_MessageBank_EC_CustomerLocation]
ALTER TABLE [dbo].[EC_MessageBank]  DROP  CONSTRAINT [FK_EC_MessageBank_EC_Device]
ALTER TABLE [dbo].[EC_PurchaseHistory]  DROP  CONSTRAINT [FK_EC_PurchaseHistory_EC_CustomerLocation]
ALTER TABLE [dbo].[EC_PurchaseHistory]  DROP  CONSTRAINT [FK_EC_PurchaseHistory_EC_Device]
ALTER TABLE [dbo].[EC_PurchaseHistory]  DROP  CONSTRAINT [FK_EC_PurchaseHistory_EC_User]
ALTER TABLE [dbo].[EC_PurchaseHistory]  DROP  CONSTRAINT [FK_PurchaseHistory_Customer]
ALTER TABLE [dbo].[EC_ScanRates]  DROP  CONSTRAINT [FK_EC_ScanRates_EC_ScanType]
ALTER TABLE [dbo].[EC_Support]  DROP  CONSTRAINT [FK_EC_Support_EC_CustomerUser]
ALTER TABLE [dbo].[EC_Support]  DROP  CONSTRAINT [FK_EC_Support_EC_SupportAreas]
ALTER TABLE [dbo].[EC_UsageHistory]  DROP  CONSTRAINT [FK_EC_UsageHistory_CustomerLocation]
ALTER TABLE [dbo].[EC_UsageHistory]  DROP  CONSTRAINT [FK_EC_UsageHistory_ScanType]
ALTER TABLE [dbo].[EC_User]  DROP  CONSTRAINT [FK_EC_Customer_User_EC_CustomerLocation]
ALTER TABLE [dbo].[EC_UserOptions]  DROP  CONSTRAINT [FK_EC_UserOptions_EC_UserOptions]
ALTER TABLE [dbo].[WS_Token]  DROP  CONSTRAINT [FK_WS_Token_EC_Customer]
ALTER TABLE [dbo].[WS_UseLog]  DROP  CONSTRAINT [FK_WS_UseLog_EC_Customer]

/****** Create UserSalt ******/
PRINT 'Creating UserSalt table ...'

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
CREATE TABLE [dbo].[UserSalt](
	[UserId] [int] NOT NULL,
	[Salt] [varchar](4096) NOT NULL,
 CONSTRAINT [PK_UserSalt] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
SET ANSI_PADDING OFF

/****** Create UpdateStatus ******/
PRINT 'Creating UpdateStatus table ...'

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
CREATE TABLE [dbo].[UpdateStatus](
	[UpdateTypeId] [int] NOT NULL,
	[StatusValue] [varchar](40) NOT NULL,
 CONSTRAINT [PK_UpdateStatus] PRIMARY KEY CLUSTERED 
(
	[UpdateTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
SET ANSI_PADDING OFF

/****** Create SupportArea ******/
PRINT 'Creating SupportArea table ...'

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
CREATE TABLE [dbo].[SupportArea](
	[SupportAreaId] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](40) NOT NULL,
	[Description] [varchar](80),
	[IsDeleted] [tinyint] NOT NULL,
 CONSTRAINT [PK_SupportArea] PRIMARY KEY CLUSTERED 
(
	[SupportAreaId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
SET ANSI_PADDING OFF

/****** Create ScanType ******/
PRINT 'Creating ScanType table ...'

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
CREATE TABLE [dbo].[ScanType](
	[ScanTypeId] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](40) NOT NULL,
	[Description] [varchar](80),
	[IsDeleted] [tinyint] NOT NULL,
 CONSTRAINT [PK_ScanType] PRIMARY KEY CLUSTERED 
(
	[ScanTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
SET ANSI_PADDING OFF

/* New table! */
PRINT 'Creating OrganizationType table ...'

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
CREATE TABLE [dbo].[OrganizationType](
	[OrganizationTypeId] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](40) NOT NULL,
	[Description] [varchar](80),
	[IsDeleted] [tinyint] NOT NULL,
 CONSTRAINT [PK_OrganizationType] PRIMARY KEY CLUSTERED 
(
	[OrganizationTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
SET ANSI_PADDING OFF

/****** Create Organization ******/
PRINT 'Creating Organization table ...'

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
CREATE TABLE [dbo].[Organization](
	[OrganizationId] [int] IDENTITY(1,1) NOT NULL,
	[OrganizationTypeId] [smallint] NOT NULL,
	[Name] [varchar](128) NOT NULL,
	[UniqueIdentifier] [varchar](40) NOT NULL,
	[IsDeleted] [tinyint] NOT NULL,
 CONSTRAINT [PK_Organization] PRIMARY KEY CLUSTERED 
(
	[OrganizationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
SET ANSI_PADDING OFF

/* New table! */
PRINT 'Creating Contact table ...'

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
CREATE TABLE [dbo].[Contact](
	[ContactId] [int] IDENTITY(1,1) NOT NULL,
	[OrganizationId] [int] NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[EmailAddress] [varchar](128) NOT NULL,
	[PhoneNumber] [varchar](20) NOT NULL,
	[IsDeleted] [tinyint] NOT NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[ContactId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
SET ANSI_PADDING OFF

/****** Create Device ******/
PRINT 'Creating Device table ...'

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
CREATE TABLE [dbo].[Device](
	[DeviceId] [int] IDENTITY(1,1) NOT NULL,
	[LocationId] [int] NOT NULL,
	[UniqueIdentifier] [varchar](40) NOT NULL,
	[AuthenticationToken] [varchar] (48) NOT NULL,
	[SerialNumber] [varchar](40) NOT NULL,
	[MACAddress] [varchar](20) NOT NULL,
	[DateIssued] [datetime] NOT NULL,
	[RevisionLevel] [varchar](5) NOT NULL,
	[ScansAvailable] [int] NOT NULL,
	[ScansUsed] [int] NOT NULL,
	[CurrentStatus] [varchar](50) NOT NULL,
	[LastReportTime] [datetime] NULL,
	[IsDeleted] [tinyint] NOT NULL,
 CONSTRAINT [PK_Device] PRIMARY KEY CLUSTERED 
(
	[DeviceId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
SET ANSI_PADDING OFF

/****** Create Location ******/
PRINT 'Creating Location table ...'

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
CREATE TABLE [dbo].[Location](
	[LocationId] [int] IDENTITY(1,1) NOT NULL,
	[OrganizationId] [int] NOT NULL,
	[UniqueIdentifier] [varchar](40) NOT NULL,
	[Name] [varchar](80) NOT NULL,
	[AddressLine1] [varchar](80) NOT NULL,
	[AddressLine2] [varchar](80) NULL,
	[City] [varchar](40) NOT NULL,
	[State] [varchar](2) NOT NULL,
	[Country] [varchar](2) NOT NULL,
	[PostalCode] [varchar](10) NOT NULL,
	[PhoneNumber] [varchar](20) NOT NULL,
	[Latitude] [numeric](18, 4) NULL,
	[Longitude] [numeric](18, 4) NULL,
	[IsDeleted] [tinyint] NOT NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[LocationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
SET ANSI_PADDING OFF

/****** Create ScanRate ******/
PRINT 'Creating ScanRate table ...'

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[ScanRate](
	[ScanRateId] [int] IDENTITY(1,1) NOT NULL,
	[ScanTypeId] [smallint] NOT NULL,
	[RatePerScan] [money] NOT NULL,
	[MinCountForRate] [int] NOT NULL,
	[MaxCountForRate] [int] NOT NULL,
	[EffectiveDate] [datetime] NOT NULL,
	[IsDeleted] [tinyint] NOT NULL,
 CONSTRAINT [PK_ScanRate] PRIMARY KEY CLUSTERED 
(
	[ScanRateId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

/** New table! **/
PRINT 'Creating MessageType table ...'

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
CREATE TABLE [dbo].[MessageType](
	[MessageTypeId] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](40) NOT NULL,
	[Description] [varchar](80),
	[IsDeleted] [tinyint] NOT NULL,
 CONSTRAINT [PK_MessageType] PRIMARY KEY CLUSTERED 
(
	[MessageTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
SET ANSI_PADDING OFF

/****** Create Message ******/
PRINT 'Creating Message table ...'

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
CREATE TABLE [dbo].[Message](
	[MessageId] [bigint] IDENTITY(1,1) NOT NULL,
	[MessageTypeId] [smallint] NOT NULL,
	[Title] [varchar](255) NOT NULL,
	[Body] [varchar](4096) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime],
	[IsDeleted] [tinyint] NOT NULL,
 CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED 
(
	[MessageId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
SET ANSI_PADDING OFF

/* Create new table to associate messages with devices. */
PRINT 'Creating DeviceMessage table ...'

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
CREATE TABLE [dbo].[DeviceMessage] (
	[DeviceId] [int] NOT NULL,
	[MessageId] [bigint] NOT NULL,
	[DeliveryTime] [datetime],
	[IsDeleted] [tinyint] NOT NULL
 CONSTRAINT [PK_DeviceMessage] PRIMARY KEY CLUSTERED 
(
	[DeviceId] ASC,
	[MessageId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
SET ANSI_PADDING OFF

/****** Create ActiveOrganization ******/
PRINT 'Creating ActiveOrganization table ...'

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
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

/****** Create User ******/
PRINT 'Creating User table ...'

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[OrganizationId] [int] NOT NULL,
	[Username] [varchar](80) NOT NULL,
	[Password] [varchar](512) NOT NULL,
	[EmailAddress] [varchar](128) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[SecurityQuestion1] [varchar](512) NOT NULL,
	[SecurityAnswer1] [varchar](128) NOT NULL,
	[ResetKey] [varchar](256) NOT NULL,
	[IsDeleted] [tinyint] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
SET ANSI_PADDING OFF

/* Role table is new. */
PRINT 'Creating Role table ...'

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
CREATE TABLE [dbo].[Role](
	[RoleId] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](80) NOT NULL,
	[Description] [varchar](512),
	[IsDeleted] [tinyint] NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
SET ANSI_PADDING OFF

/* Join users to roles. */
PRINT 'Creating UserRole table ...'

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
CREATE TABLE [dbo].[UserRole](
	[UserId] [int] NOT NULL,
	[RoleId] [smallint] NOT NULL
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
SET ANSI_PADDING OFF

/* Join users to locations. */
PRINT 'Creating UserAssignLocation table ...'

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
CREATE TABLE [dbo].[UserAssignedLocation](
	[UserId] [int] NOT NULL,
	[LocationId] [int] NOT NULL,
 CONSTRAINT [PK_UserAssignedLocation] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LocationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
SET ANSI_PADDING OFF

/* EC_Authorize_NET will be replaced with the following table. */
PRINT 'Creating CreditCard table ...'

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[CreditCard](
	[CreditCardId] [int] IDENTITY(1,1) NOT NULL,
	[AuthorizeId] [varchar](20) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[AccountNumber] [char](4),
	[IsDeleted] [tinyint] NOT NULL,
 CONSTRAINT [PK_CreditCard] PRIMARY KEY CLUSTERED 
(
	[CreditCardId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

/* This table will join a credit card to a customer location. */
PRINT 'Creating LocationCreditCard table ...'

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
CREATE TABLE [dbo].[LocationCreditCard] (
	[LocationId] [int] NOT NULL,
	[CreditCardId] [int] NOT NULL,
 CONSTRAINT [PK_LocationCreditCard] PRIMARY KEY CLUSTERED 
(
	[LocationId] ASC,
	[CreditCardId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
SET ANSI_PADDING OFF

/****** Create UserSetting ******/
PRINT 'Creating UserSetting table ...'

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
CREATE TABLE [dbo].[UserSetting](
	[UserId] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Value] [varchar](2048) NOT NULL,
	[IsDeleted] [tinyint] NOT NULL,
 CONSTRAINT [PK_UserSetting] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
SET ANSI_PADDING OFF

/****** Create ExceptionLog ******/
PRINT 'Creating ExceptionLog table ...'

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
CREATE TABLE [dbo].[ExceptionLog](
	[ExceptionLogId] [bigint] NOT NULL,
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
	[IsDeleted] [tinyint] NOT NULL,
 CONSTRAINT [PK_ExceptionLog] PRIMARY KEY CLUSTERED 
(
	[ExceptionLogId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
SET ANSI_PADDING OFF

/****** Create ScanHistory ******/
PRINT 'Creating ScanHistory table ...'

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
CREATE TABLE [dbo].[ScanHistory](
	[ScanHistoryId] [bigint] IDENTITY(1,1) NOT NULL,
	[DeviceId] [int] NOT NULL,
	[ScanTypeId] [smallint] NOT NULL,
	[ScanStartTime] [datetime] NOT NULL,
	[IsDeleted] [tinyint] NOT NULL,
 CONSTRAINT [PK_ScanHistory] PRIMARY KEY CLUSTERED 
(
	[ScanHistoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

/****** Create SupportIssue ******/
PRINT 'Creating SupportIssue table ...'

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
CREATE TABLE [dbo].[SupportIssue](
	[SupportIssueId] [int] IDENTITY(1,1) NOT NULL,
	[ParentId] [int] NOT NULL,
	[SupportAreaId] [smallint] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[ToUserId] [int],
	[FromUserId] [int],
	[Subject] [varchar](512) NOT NULL,
	[Body] [varchar](6144) NOT NULL,
	[Status] [varchar](128) NOT NULL,
	[Priority] [smallint] NOT NULL,
	[IsPublic] [tinyint] NOT NULL,
	[IsClosedByToUser] [tinyint] NOT NULL,
	[IsClosedByFromUser] [tinyint] NOT NULL,
	[IsDeleted] [tinyint] NOT NULL,
 CONSTRAINT [PK_SupportIssue] PRIMARY KEY CLUSTERED 
(
	[SupportIssueId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
SET ANSI_PADDING OFF

/****** Create PurchaseHistory ******/
PRINT 'Creating PurchaseHistory table ...'

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
CREATE TABLE [dbo].[PurchaseHistory](
	[PurchaseHistoryId] [int] IDENTITY(1,1) NOT NULL,
	[LocationId] [int] NOT NULL,
	[DeviceId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[PurchaseTime] [datetime] NOT NULL,
	[ScansPurchased] [int] NULL,
	[AmountPaid] [money] NOT NULL,
	[TransactionId] [numeric](18, 0) NOT NULL,
	[PurchaseNotes] [varchar](2048) NOT NULL,
	[IsDeleted] [tinyint] NOT NULL,
 CONSTRAINT [PK_PurchaseHistory] PRIMARY KEY CLUSTERED 
(
	[PurchaseHistoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
SET ANSI_PADDING OFF

-- Set all defaults.
PRINT 'Setting default values for all columns ...'

ALTER TABLE [dbo].[OrganizationType] ADD CONSTRAINT [DF_OrganizationType_IsDeleted] DEFAULT ((0)) FOR [IsDeleted]
ALTER TABLE [dbo].[Organization] ADD CONSTRAINT [DF_Organization_IsDeleted] DEFAULT ((0)) FOR [IsDeleted]
ALTER TABLE [dbo].[Location] ADD  CONSTRAINT [DF_Location_Country]  DEFAULT ('') FOR [Country]
ALTER TABLE [dbo].[Location] ADD  CONSTRAINT [DF_Location_City]  DEFAULT ('') FOR [City]
ALTER TABLE [dbo].[Location] ADD  CONSTRAINT [DF_Location_State]  DEFAULT ('') FOR [State]
ALTER TABLE [dbo].[Location] ADD  CONSTRAINT [DF_Location_PostalCode]  DEFAULT ('') FOR [PostalCode]
ALTER TABLE [dbo].[Location] ADD  CONSTRAINT [DF_Location_AddressLine1]  DEFAULT ('') FOR [AddressLine1]
ALTER TABLE [dbo].[Location] ADD  CONSTRAINT [DF_Location_AddressLine2]  DEFAULT ('') FOR [AddressLine2]
ALTER TABLE [dbo].[Location] ADD  CONSTRAINT [DF_Location_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
ALTER TABLE [dbo].[Contact] ADD  CONSTRAINT [DF_Contact_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
ALTER TABLE [dbo].[Device] ADD  CONSTRAINT [DF_Device_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
ALTER TABLE [dbo].[Device] ADD  CONSTRAINT [DF_Device_ScansAvailable]  DEFAULT ((0)) FOR [ScansAvailable]
ALTER TABLE [dbo].[Device] ADD  CONSTRAINT [DF_Device_ScansUsed]  DEFAULT ((0)) FOR [ScansUsed]
ALTER TABLE [dbo].[Device] ADD  CONSTRAINT [DF_Device_CurrentStatus]  DEFAULT ('') FOR [CurrentStatus]
ALTER TABLE [dbo].[Device] ADD  CONSTRAINT [DF_Device_AuthenticationToken]  DEFAULT ('') FOR [AuthenticationToken]
ALTER TABLE [dbo].[MessageType] ADD  CONSTRAINT [DF_MessageType_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
ALTER TABLE [dbo].[Message] ADD  CONSTRAINT [DF_Message_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
ALTER TABLE [dbo].[Message] ADD  CONSTRAINT [DF_Message_EndTime]  DEFAULT (NULL) FOR [EndTime]
ALTER TABLE [dbo].[PurchaseHistory] ADD  CONSTRAINT [DF_PurchaseHistory_AmountPaid]  DEFAULT ((0)) FOR [AmountPaid]
ALTER TABLE [dbo].[DeviceMessage] ADD  CONSTRAINT [DF_DeviceMessage_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
ALTER TABLE [dbo].[PurchaseHistory] ADD  CONSTRAINT [DF_PurchaseHistory_PurchaseNotes]  DEFAULT ('') FOR [PurchaseNotes]
ALTER TABLE [dbo].[ScanType] ADD  CONSTRAINT [DF_ScanType_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
ALTER TABLE [dbo].[ScanRate] ADD  CONSTRAINT [DF_ScanRate_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
ALTER TABLE [dbo].[SupportArea] ADD  CONSTRAINT [DF_SupportArea_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
ALTER TABLE [dbo].[SupportIssue] ADD  CONSTRAINT [DF_SupportIssue_ParentId]  DEFAULT ((0)) FOR [ParentId]
ALTER TABLE [dbo].[SupportIssue] ADD  CONSTRAINT [DF_SupportIssue_ToUserId]  DEFAULT (NULL) FOR [ToUserId]
ALTER TABLE [dbo].[SupportIssue] ADD  CONSTRAINT [DF_SupportIssue_FromUserId]  DEFAULT (NULL) FOR [FromUserId]
ALTER TABLE [dbo].[SupportIssue] ADD  CONSTRAINT [DF_SupportIssue_IsClosedByToUser]  DEFAULT ((0)) FOR [IsClosedByToUser]
ALTER TABLE [dbo].[SupportIssue] ADD  CONSTRAINT [DF_SupportIssue_IsClosedByFromUser]  DEFAULT ((0)) FOR [IsClosedByFromUser]
ALTER TABLE [dbo].[SupportIssue] ADD  CONSTRAINT [DF_SupportIssue_IsPublic]  DEFAULT ((0)) FOR [IsPublic]
ALTER TABLE [dbo].[SupportIssue] ADD  CONSTRAINT [DF_SupportIssue_Status]  DEFAULT ('') FOR [Status]
ALTER TABLE [dbo].[SupportIssue] ADD  CONSTRAINT [DF_SupportIssue_Priority]  DEFAULT ((0)) FOR [Priority]
ALTER TABLE [dbo].[SupportIssue] ADD  CONSTRAINT [DF_SupportIssue_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_ResetKey]  DEFAULT ('') FOR [ResetKey]
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_SecurityQuestion1]  DEFAULT ('') FOR [SecurityQuestion1]
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_SecurityAnswer1]  DEFAULT ('') FOR [SecurityAnswer1]
ALTER TABLE [dbo].[Role] ADD  CONSTRAINT [DF_Role_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
ALTER TABLE [dbo].[CreditCard] ADD  CONSTRAINT [DF_CreditCard_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
ALTER TABLE [dbo].[UserSetting] ADD  CONSTRAINT [DF_UserSetting_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
ALTER TABLE [dbo].[UserSetting] ADD  CONSTRAINT [DF_UserSetting_Value]  DEFAULT ('') FOR [Value]
ALTER TABLE [dbo].[ExceptionLog] ADD  CONSTRAINT [DF_ExceptionLog_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
ALTER TABLE [dbo].[ScanHistory] ADD  CONSTRAINT [DF_ScanHistory_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
ALTER TABLE [dbo].[PurchaseHistory] ADD  CONSTRAINT [DF_PurchaseHistory_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]

/* No changes to EC_System, so just rename it. */
PRINT 'Renaming EC_System to SystemSetting ...'
EXEC sp_rename 'EC_System', 'SystemSetting'

/* Delete the 'Roles' setting because it's not used now. */
DELETE FROM [dbo].[SystemSetting]
WHERE [Name] = 'Roles'

/* Change so Value is not null. */
ALTER TABLE [dbo].[SystemSetting]
ALTER COLUMN [Value] [varchar](2048) NOT NULL

/* Changes to EC_ActivityTypeDm are minor. Can just rename. */
PRINT 'Renaming EC_ActivityTypeDm to ActivityType, and some of its columns ...'
EXEC sp_rename 'EC_ActivityTypeDm', 'ActivityType'
EXEC sp_rename 'ActivityType.ActivityTypeDescription', 'Name', 'COLUMN'
EXEC sp_rename 'ActivityType.PK_ActivityTypeDm', 'PK_ActivityType', 'INDEX'

/* Add a Description column. */
ALTER TABLE [dbo].[ActivityType]
ADD [Description] [varchar](80)
CONSTRAINT [DF_ActivityType_Description] DEFAULT (NULL)

/* Change so Name is not null. */
ALTER TABLE [dbo].[ActivityType]
ALTER COLUMN [Name] [varchar](40) NOT NULL

/* Populate the types of organizations. These are static. */
PRINT 'Populating OrganizationType ...'
INSERT INTO [dbo].[OrganizationType] ([Name], [Description]) VALUES ('Host', 'Service host organization')
INSERT INTO [dbo].[OrganizationType] ([Name], [Description]) VALUES ('End User', 'ClearView end-user organization')

/* Copy rows from EC_UpdateStatus to UpdateStatus. */
PRINT 'Copying EC_UpdateStatus to UpdateStatus ...'

IF EXISTS (SELECT 1 FROM dbo.EC_UpdateStatus)
INSERT INTO dbo.UpdateStatus ([UpdateTypeId], [StatusValue])
SELECT [UpdateTypeId], [StatusValue] FROM dbo.EC_UpdateStatus WITH (HOLDLOCK, TABLOCKX)

/* Copy rows from EC_SupportAreas to SupportArea. */
PRINT 'Copying EC_SupportAreas to SupportArea ...'
SET IDENTITY_INSERT [dbo].[SupportArea] ON

IF EXISTS (SELECT 1 FROM dbo.EC_SupportAreas)
INSERT INTO dbo.SupportArea ([SupportAreaId], [Name], [IsDeleted])
SELECT [SupportAreaId], [AreaDescription], CASE WHEN [Active] = 0 THEN 1 ELSE 0 END FROM dbo.EC_SupportAreas WITH (HOLDLOCK, TABLOCKX)

SET IDENTITY_INSERT [dbo].[SupportArea] OFF

/* Copy rows from EC_ScanType to ScanType. */
PRINT 'Copying EC_ScanType to ScanType ...'
SET IDENTITY_INSERT [dbo].[ScanType] ON

IF EXISTS (SELECT 1 FROM dbo.EC_ScanType)
INSERT INTO dbo.ScanType ([ScanTypeId], [Name])
SELECT [ScanType], [ScanTypeDescription] FROM dbo.EC_ScanType WITH (HOLDLOCK, TABLOCKX)

SET IDENTITY_INSERT [dbo].[ScanType] OFF

/* Copy rows from EC_Customer to Organization. Change the ID of the 0 row to be 1. */
PRINT 'Copying EC_Customer to Organization ...'

SET IDENTITY_INSERT [dbo].[Organization] ON

-- Create the host organization.
INSERT INTO dbo.Organization ([OrganizationId], [Name], [UniqueIdentifier], [IsDeleted], [OrganizationTypeId])
VALUES (0, 'EPIC Research & Diagnostics, Inc.', NEWID(), 0, 1)

IF EXISTS (SELECT 1 FROM dbo.EC_Customer)
INSERT INTO dbo.Organization ([OrganizationId], [Name], [UniqueIdentifier], [IsDeleted], [OrganizationTypeId])
SELECT
	CASE WHEN [CustomerId] = 0 THEN 1 ELSE [CustomerId] END,
	[OrganizationName],
	[CustomerUniqueKey],
	CASE WHEN [Active] = 0 THEN 1 ELSE 0 END,
	2
FROM dbo.EC_Customer WITH (HOLDLOCK, TABLOCKX)

SET IDENTITY_INSERT [dbo].[Organization] OFF

/* Create the contacts for the organizations. */
PRINT 'Setting up all the contacts ...'
-- First the contact for the host organization.
INSERT INTO [dbo].[Contact] ([OrganizationId], [FirstName], [LastName], [EmailAddress], [PhoneNumber])
VALUES (0, 'Andrew', 'Mason', 'amason@epicdiagnostics.com', '4804775242')

-- Now contacts for all current organizations.
DECLARE @i int, @max int
SET @i = 0
SET @max = (SELECT MAX(CustomerId) FROM dbo.EC_Customer)
WHILE (@i <= @max)
BEGIN
	IF EXISTS (SELECT 1 FROM dbo.EC_Customer WHERE CustomerId = @i)
	BEGIN
		INSERT INTO dbo.Contact ([OrganizationId], [FirstName], [LastName], [EmailAddress], [PhoneNumber])
		SELECT CASE WHEN @i = 0 THEN 1 ELSE @i END, ContactFirstName, ContactLastName, ContactEmailAddress, ''
		FROM dbo.EC_Customer WHERE CustomerId = @i
	END
	SET @i = @i + 1
END

/* Copy rows from EC_CustomerLocation to Location. Change the ID of the 0 row to be 1. */
PRINT 'Copying EC_CustomerLocation to Location ...'
SET IDENTITY_INSERT [dbo].[Location] ON

-- Create the host organization location.
INSERT INTO dbo.Location ([LocationId], [UniqueIdentifier], [OrganizationId], [Name],
							[AddressLine1], [AddressLine2], [City], [State], [Country], [PostalCode],
							[PhoneNumber], [Latitude], [Longitude])
VALUES (0, NEWID(), 0, 'Home Office', '8501 E. Princess Drive', 'Suite 100', 'Scottsdale', 'AZ', 'US', '85255', '4804775242',
		33.3947, -112.0605)
-- Now are current locations.
IF EXISTS (SELECT 1 FROM dbo.EC_CustomerLocation)
INSERT INTO dbo.Location ([LocationId], [UniqueIdentifier], [OrganizationId], [Name],
							[AddressLine1], [AddressLine2], [City], [State], [Country], [PostalCode],
							[PhoneNumber], [Latitude], [Longitude], [IsDeleted])
SELECT
	CASE WHEN [CustomerLocationId] = 0 THEN 1 ELSE [CustomerLocationId] END,
	[LocationUniqueKey],
	CASE WHEN [CustomerId] = 0 THEN 1 ELSE [CustomerId] END,
	[LocationName],
	[AddressLine1],
	[AddressLine2],
	[AddressCity],
	[AddressState],
	[AddressCountry],
	[AddressPostalCode],
	[PhoneNumber],
	[Latitude],
	[Longitude],
	CASE WHEN [Active] = 0 THEN 1 ELSE 0 END
FROM dbo.EC_CustomerLocation WITH (HOLDLOCK, TABLOCKX)

SET IDENTITY_INSERT [dbo].[Location] OFF

/* Copy rows from EC_Device to Device. */
PRINT 'Copying EC_Device to Device ...'
SET IDENTITY_INSERT [dbo].[Device] ON

IF EXISTS (SELECT 1 FROM dbo.EC_Device)
INSERT INTO dbo.Device ([DeviceId], [LocationId], [MACAddress], [UniqueIdentifier], [SerialNumber], [DateIssued], [RevisionLevel],
						[IsDeleted], [ScansAvailable], [ScansUsed], [CurrentStatus], [LastReportTime])
SELECT d.[DeviceId],
		CASE WHEN cd.[CustomerLocationId] = 0 THEN 1 ELSE cd.[CustomerLocationId] END,
		[MACAddress], [DeviceUniqueIdentifier], [DeviceSerialNumber], [DateIssued], [RevisionLevel],
		CASE WHEN [Active] = 0 THEN 1 ELSE 0 END, [ScansAvailable], [ScansUsed], [CurrentStatus], [LastReportedDate]
FROM dbo.EC_Device d
JOIN dbo.EC_CustomerDevice cd ON cd.[DeviceId] = d.[DeviceId]
--WITH (HOLDLOCK, TABLOCKX)

SET IDENTITY_INSERT [dbo].[Device] OFF

/* Copy rows from EC_ScanRates to ScanRate. */
PRINT 'Copying EC_ScanRates to ScanRate ...'
SET IDENTITY_INSERT [dbo].[ScanRate] ON

IF EXISTS (SELECT 1 FROM dbo.EC_ScanRates)
INSERT INTO dbo.ScanRate ([ScanRateId], [ScanTypeId], [EffectiveDate], [MinCountForRate], [MaxCountForRate], [RatePerScan], [IsDeleted])
SELECT [ScanRateId], [ScanType], [EffectiveDate], [MinCountForRate], [MaxCountForRate], [RatePerScan], CASE WHEN [Active] = 0 THEN 1 ELSE 0 END
FROM dbo.EC_ScanRates WITH (HOLDLOCK, TABLOCKX)

SET IDENTITY_INSERT [dbo].[ScanRate] OFF

/* Populate the new MessageType table. */
PRINT 'Populating the MessageType table ...'
INSERT INTO dbo.MessageType ([Name], [Description])
VALUES ('Information', 'Provides information of interest to users')
INSERT INTO dbo.MessageType ([Name], [Description])
VALUES ('Marketing', 'Advertisement for additional service that may be of interest to users')
INSERT INTO dbo.MessageType ([Name], [Description])
VALUES ('Sale', 'Promotes a sale on current services')
INSERT INTO dbo.MessageType ([Name], [Description])
VALUES ('Attention', 'Alerts the user to an item that needs immediate attention')

/* Copy rows from EC_MessageBank to Message. */
PRINT 'Copying EC_MessageBank to Message ...'
SET IDENTITY_INSERT [dbo].[Message] ON

IF EXISTS (SELECT 1 FROM dbo.EC_MessageBank)
INSERT INTO dbo.[Message] ([MessageId], [Title], [Body], [CreateTime], [StartTime], [MessageTypeId], [IsDeleted])
SELECT
	[MessageBankId],
	[MessageTitle],
	[MessageBody],
	[MessageDateTime],
	[MessageDateTime],
	1,
	[Deleted]
FROM dbo.EC_MessageBank WITH (HOLDLOCK, TABLOCKX)

SET IDENTITY_INSERT [dbo].[Message] OFF

/* Populate DeviceMessage table. */
IF EXISTS (SELECT 1 FROM dbo.EC_MessageBank)
INSERT INTO dbo.DeviceMessage ([DeviceId], [MessageId])
SELECT [DeviceId], [MessageBankId]
FROM dbo.EC_MessageBank WITH (HOLDLOCK, TABLOCKX)

/* Copy rows from EC_ActiveCustomers to ActiveOrganization. No concern with primary keys since they aren't referenced. */
PRINT 'Copying EC_ActiveCustomers to ActiveOrganization ...'
IF EXISTS (SELECT 1 FROM dbo.EC_ActiveCustomers)
INSERT INTO dbo.ActiveOrganization ([ActivityTypeId], [LocationId], [ActivityTime])
SELECT [ActivityTypeId], CASE WHEN [CustomerLocationId] = 0 THEN 1 ELSE [CustomerLocationId] END, [ActivityDateTime]
FROM dbo.EC_ActiveCustomers WITH (HOLDLOCK, TABLOCKX)

/* Set up CreditCard from EC_Authorize_NET. Assuming only one! Might be bad. */
PRINT 'Creating a CreditCard record ...'
INSERT INTO dbo.CreditCard ([AuthorizeId], [FirstName], [LastName], [AccountNumber])
VALUES (4730846, 'John', 'Doe', '4753')
INSERT INTO dbo.LocationCreditCard ([LocationId], [CreditCardId])
VALUES (1, @@IDENTITY)

/* Copy rows from EC_UsageHistory to ScanHistory. No concern with primary keys since they aren't referenced. */
PRINT 'Copying EC_UsageHistory to ScanHistory ...'
IF EXISTS (SELECT 1 FROM dbo.EC_UsageHistory)
INSERT INTO dbo.ScanHistory ([DeviceId], [ScanTypeId], [ScanStartTime])
SELECT [DeviceId], [ScanType], [ScanStartDateTime]
FROM dbo.EC_UsageHistory h
JOIN dbo.EC_CustomerDevice d ON h.CustomerLocationId = d.CustomerLocationId

/* Copy rows from EC_Support to SupportIssue. */
PRINT 'Copying EC_Support to SupportIssue ...'
SET IDENTITY_INSERT [dbo].[SupportIssue] ON

IF EXISTS (SELECT 1 FROM dbo.EC_Support)
INSERT INTO dbo.SupportIssue ([SupportIssueId], [ParentId], [Subject], [Body], [CreateTime], [ToUserId], [FromUserId],
								[SupportAreaId], [IsClosedByToUser], [IsClosedByFromUser], [IsPublic], [Status], [Priority])
SELECT [SupportId], [ParentId], [Subject], [Body], [DateCreated],
	CASE WHEN [ToUserId] = 0 THEN 1 ELSE [ToUserId] END,
	CASE WHEN [FromUserId] = 0 THEN 1 ELSE [FromUserId] END,
	[SupportAreaId], [ToDelete], [FromDelete], [IsPublic], [Status], [Priority]
FROM dbo.EC_Support WITH (HOLDLOCK, TABLOCKX)

SET IDENTITY_INSERT [dbo].[SupportIssue] OFF

/* Create a couple roles. */
PRINT 'Creating Role records ...'
INSERT INTO dbo.Role ([Name], [Description])
VALUES ('Service Administrator', 'EPIC Central administrator with full control of the service')

INSERT INTO dbo.Role ([Name], [Description])
VALUES ('Organization Administrator', 'Organization administrator with full control of the organization')

/* Populate the new User table from the EC_User table. */
PRINT 'Creating the host admin user ...'
SET IDENTITY_INSERT [dbo].[User] ON

-- First create a service admin user, put it in the service admin role and associate with the service org.
INSERT INTO [dbo].[User] ([UserId], [OrganizationId], [Username], [FirstName], [LastName], [EmailAddress], [Password],
							[ResetKey], [SecurityQuestion1], [SecurityAnswer1], [IsDeleted])
VALUES (0, 0, 'echost', 'Service', 'Host', 'lkurth@epicdiagnostics.com', '', '', '', '', 0)

INSERT INTO dbo.UserRole ([UserId], [RoleId])
VALUES (0, 1)

-- Now copy the current users.
PRINT 'Copying existing users ...'
INSERT INTO [dbo].[User] ([UserId], [OrganizationId], [Username], [FirstName], [LastName], [EmailAddress], [Password],
							[ResetKey], [SecurityQuestion1], [SecurityAnswer1], [IsDeleted])
SELECT
	CASE WHEN [UserId] = 0 THEN 1 ELSE [UserId] END,
	1,
	[Username], [FirstName], [LastName], [EmailAddress], [Password],
	[ResetKey], [SecurityQuestion1], [SecurityAnswer1], CASE WHEN [IsActive] = 0 THEN 1 ELSE 0 END
FROM dbo.EC_User WITH (HOLDLOCK, TABLOCKX)

-- Put them all in the org admin role.
INSERT INTO dbo.UserRole ([UserId], [RoleId])
SELECT [UserId], 2
FROM [dbo].[User]
WHERE [UserId] <> 0

SET IDENTITY_INSERT [dbo].[User] OFF

/* Copy rows from EC_UserSalt to UserSalt. */
PRINT 'Copying EC_UserSalt to UserSalt ...'
IF EXISTS (SELECT 1 FROM dbo.EC_UserSalt)
INSERT INTO dbo.UserSalt ([UserId], [Salt])
SELECT CASE WHEN [UserId] = 0 THEN 1 ELSE [UserId] END, [Salt]
FROM dbo.EC_UserSalt WITH (HOLDLOCK, TABLOCKX)

/* Copy rows from EC_UserOptions to UserSetting. */
PRINT 'Copying EC_UserOptions to UserSetting ...'
INSERT INTO dbo.UserSetting ([UserId], [Name], [Value])
SELECT CASE WHEN [UserId] = 0 THEN 1 ELSE [UserId] END, [Option], [Value]
FROM dbo.EC_UserOptions

PRINT 'Creating all the foreign keys ...'

-- Foreign keys on UserSalt.
ALTER TABLE [dbo].[UserSalt]  WITH CHECK ADD  CONSTRAINT [FK_UserSalt_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[UserSalt] CHECK CONSTRAINT [FK_UserSalt_User]


-- Foreign keys on User.
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Organization] FOREIGN KEY([OrganizationId])
REFERENCES [dbo].[Organization] ([OrganizationId])

ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Organization]


-- Foreign keys on UserRole.
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_User]

ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])

ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_Role]


-- Foreign keys on Organization.
ALTER TABLE [dbo].[Organization]  WITH CHECK ADD  CONSTRAINT [FK_Organization_OrganizationType] FOREIGN KEY([OrganizationTypeId])
REFERENCES [dbo].[OrganizationType] ([OrganizationTypeId])

ALTER TABLE [dbo].[Organization] CHECK CONSTRAINT [FK_Organization_OrganizationType]


-- Foreign keys on Contact.
ALTER TABLE [dbo].[Contact]  WITH CHECK ADD  CONSTRAINT [FK_Contact_Organization] FOREIGN KEY([OrganizationId])
REFERENCES [dbo].[Organization] ([OrganizationId])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[Contact] CHECK CONSTRAINT [FK_Contact_Organization]


-- Foreign keys on UserAssignedLocation.
ALTER TABLE [dbo].[UserAssignedLocation]  WITH CHECK ADD  CONSTRAINT [FK_UserAssignedLocation_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[UserAssignedLocation] CHECK CONSTRAINT [FK_UserAssignedLocation_User]

ALTER TABLE [dbo].[UserAssignedLocation]  WITH CHECK ADD  CONSTRAINT [FK_UserAssignedLocation_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([LocationId])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[UserAssignedLocation] CHECK CONSTRAINT [FK_UserAssignedLocation_Location]


-- Foreign keys on LocationCreditCard.
ALTER TABLE [dbo].[LocationCreditCard]  WITH CHECK ADD  CONSTRAINT [FK_LocationCreditCard_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([LocationId])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[LocationCreditCard] CHECK CONSTRAINT [FK_LocationCreditCard_Location]

ALTER TABLE [dbo].[LocationCreditCard]  WITH CHECK ADD  CONSTRAINT [FK_LocationCreditCard_CreditCard] FOREIGN KEY([CreditCardId])
REFERENCES [dbo].[CreditCard] ([CreditCardId])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[LocationCreditCard] CHECK CONSTRAINT [FK_LocationCreditCard_CreditCard]


-- Foreign keys on ActiveOrganization.
ALTER TABLE [dbo].[ActiveOrganization]  WITH CHECK ADD  CONSTRAINT [FK_ActiveOrganization_ActivityType] FOREIGN KEY([ActivityTypeId])
REFERENCES [dbo].[ActivityType] ([ActivityTypeId])

ALTER TABLE [dbo].[ActiveOrganization] CHECK CONSTRAINT [FK_ActiveOrganization_ActivityType]

ALTER TABLE [dbo].[ActiveOrganization]  WITH CHECK ADD  CONSTRAINT [FK_ActiveOrganization_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([LocationId])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[ActiveOrganization] CHECK CONSTRAINT [FK_ActiveOrganization_Location]


-- Foreign keys on Location.
ALTER TABLE [dbo].[Location]  WITH CHECK ADD  CONSTRAINT [FK_Location_Organization] FOREIGN KEY([OrganizationId])
REFERENCES [dbo].[Organization] ([OrganizationId])

ALTER TABLE [dbo].[Location] CHECK CONSTRAINT [FK_Location_Organization]


-- Foreign keys on Device.
ALTER TABLE [dbo].[Device]  WITH CHECK ADD  CONSTRAINT [FK_Device_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([LocationId])

ALTER TABLE [dbo].[Device] CHECK CONSTRAINT [FK_Device_Location]


-- Foreign keys on ExceptionLog.
ALTER TABLE [dbo].[ExceptionLog]  WITH CHECK ADD  CONSTRAINT [FK_ExceptionLog_Device] FOREIGN KEY([DeviceId])
REFERENCES [dbo].[Device] ([DeviceId])

ALTER TABLE [dbo].[ExceptionLog] CHECK CONSTRAINT [FK_ExceptionLog_Device]


-- Foreign keys on Message.
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_MessageType] FOREIGN KEY([MessageTypeId])
REFERENCES [dbo].[MessageType] ([MessageTypeId])

ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_MessageType]


-- Foreign keys on DeviceMessage.
ALTER TABLE [dbo].[DeviceMessage]  WITH CHECK ADD  CONSTRAINT [FK_DeviceMessage_Device] FOREIGN KEY([DeviceId])
REFERENCES [dbo].[Device] ([DeviceId])

ALTER TABLE [dbo].[DeviceMessage] CHECK CONSTRAINT [FK_DeviceMessage_Device]

ALTER TABLE [dbo].[DeviceMessage]  WITH CHECK ADD  CONSTRAINT [FK_DeviceMessage_Message] FOREIGN KEY([MessageId])
REFERENCES [dbo].[Message] ([MessageId])

ALTER TABLE [dbo].[DeviceMessage] CHECK CONSTRAINT [FK_DeviceMessage_Message]


-- Foreign keys on PurchaseHistory.
ALTER TABLE [dbo].[PurchaseHistory]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseHistory_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([LocationId])

ALTER TABLE [dbo].[PurchaseHistory] CHECK CONSTRAINT [FK_PurchaseHistory_Location]

ALTER TABLE [dbo].[PurchaseHistory]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseHistory_Device] FOREIGN KEY([DeviceId])
REFERENCES [dbo].[Device] ([DeviceId])

ALTER TABLE [dbo].[PurchaseHistory] CHECK CONSTRAINT [FK_PurchaseHistory_Device]

ALTER TABLE [dbo].[PurchaseHistory]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseHistory_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])

ALTER TABLE [dbo].[PurchaseHistory] CHECK CONSTRAINT [FK_PurchaseHistory_User]


-- Foreign keys on ScanRate.
ALTER TABLE [dbo].[ScanRate]  WITH CHECK ADD  CONSTRAINT [FK_ScanRate_ScanType] FOREIGN KEY([ScanTypeId])
REFERENCES [dbo].[ScanType] ([ScanTypeId])

ALTER TABLE [dbo].[ScanRate] CHECK CONSTRAINT [FK_ScanRate_ScanType]


-- Foreign keys on SupportIssue.
ALTER TABLE [dbo].[SupportIssue]  WITH CHECK ADD  CONSTRAINT [FK_SupportIssue_ToUser] FOREIGN KEY([ToUserId])
REFERENCES [dbo].[User] ([UserId])

ALTER TABLE [dbo].[SupportIssue] CHECK CONSTRAINT [FK_SupportIssue_ToUser]

ALTER TABLE [dbo].[SupportIssue]  WITH CHECK ADD  CONSTRAINT [FK_SupportIssue_FromUser] FOREIGN KEY([FromUserId])
REFERENCES [dbo].[User] ([UserId])

ALTER TABLE [dbo].[SupportIssue] CHECK CONSTRAINT [FK_SupportIssue_FromUser]

ALTER TABLE [dbo].[SupportIssue]  WITH CHECK ADD  CONSTRAINT [FK_SupportIssue_SupportArea] FOREIGN KEY([SupportAreaId])
REFERENCES [dbo].[SupportArea] ([SupportAreaId])

ALTER TABLE [dbo].[SupportIssue] CHECK CONSTRAINT [FK_SupportIssue_SupportArea]


-- Foreign keys on ScanHistory.
ALTER TABLE [dbo].[ScanHistory]  WITH CHECK ADD  CONSTRAINT [FK_ScanHistory_Device] FOREIGN KEY([DeviceId])
REFERENCES [dbo].[Device] ([DeviceId])

ALTER TABLE [dbo].[ScanHistory] CHECK CONSTRAINT [FK_ScanHistory_Device]

ALTER TABLE [dbo].[ScanHistory]  WITH CHECK ADD  CONSTRAINT [FK_ScanHistory_ScanType] FOREIGN KEY([ScanTypeId])
REFERENCES [dbo].[ScanType] ([ScanTypeId])

ALTER TABLE [dbo].[ScanHistory] CHECK CONSTRAINT [FK_ScanHistory_ScanType]


-- Foreign keys on UserSetting.
ALTER TABLE [dbo].[UserSetting]  WITH CHECK ADD  CONSTRAINT [FK_UserSetting_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[UserSetting] CHECK CONSTRAINT [FK_UserSetting_User]


PRINT 'Creating additional indexes ...'

-- Index for User.
CREATE UNIQUE NONCLUSTERED INDEX IDX_User_Username
ON [dbo].[User] ( [Username] ASC ) WITH ( FILLFACTOR = 80 )

-- Index for Organization.
CREATE UNIQUE NONCLUSTERED INDEX IDX_Organization_UniqueIdentifier
ON [dbo].[Organization] ( [UniqueIdentifier] ASC ) WITH ( FILLFACTOR = 80 )

-- Index for Location.
CREATE UNIQUE NONCLUSTERED INDEX IDX_Location_UniqueIdentifier
ON [dbo].[Location] ( [UniqueIdentifier] ASC ) WITH ( FILLFACTOR = 80 )

-- Index for Device.
CREATE UNIQUE NONCLUSTERED INDEX IDX_Device_UniqueIdentifier
ON [dbo].[Device] ( [UniqueIdentifier] ASC ) WITH ( FILLFACTOR = 80 )


PRINT 'Creating functions and SPs ...'

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

/****** Replace Function [dbo].[EPICOps_ActivityType_DevicePing] ******/
DROP FUNCTION [dbo].[EPICOps_ActivityType_DevicePing]

EXEC('
-- =============================================
-- Author:		Andrew Mason
-- Create date: 07/15/2011
-- Description:	Constant for the activity type that 
--              represents a device ping for EPICOps
-- =============================================
CREATE FUNCTION [dbo].[OpsActivityTypeDevicePing] ()
RETURNS SMALLINT
AS
BEGIN
	RETURN 0
END
')

/****** Replace Function [dbo].[EPICOps_ActivityType_NewException] ******/
DROP FUNCTION [dbo].[EPICOps_ActivityType_NewException]

EXEC('
-- =============================================
-- Author:		Andrew Mason
-- Create date: 07/15/2011
-- Description:	Constant for the activity type that 
--              represents a new exception for EPICOps
-- =============================================
CREATE FUNCTION [dbo].[OpsActivityTypeNewException] ()
RETURNS SMALLINT
AS
BEGIN
	RETURN 3
END
')

/****** Replace Function [dbo].[EPICOps_ActivityType_NewPurchase] ******/
DROP FUNCTION [dbo].[EPICOps_ActivityType_NewPurchase]

EXEC('
-- =============================================
-- Author:		Andrew Mason
-- Create date: 07/15/2011
-- Description:	Constant for the activity type that 
--              represents a device ping for EPICOps
-- =============================================
CREATE FUNCTION [dbo].[OpsActivityTypeNewPurchase] ()
RETURNS SMALLINT
AS
BEGIN
	RETURN 1
END
')

/******  Replace Function [dbo].[EPICOps_ActivityType_NewScan] ******/
DROP FUNCTION [dbo].[EPICOps_ActivityType_NewScan]

EXEC('
-- =============================================
-- Author:		Andrew Mason
-- Create date: 07/15/2011
-- Description:	Constant for the activity type that 
--              represents a new scan for EPICOps
-- =============================================
CREATE FUNCTION [dbo].[OpsActivityTypeNewScan] ()
RETURNS SMALLINT
AS
BEGIN
	RETURN 2
END
')

/******  Replace Function [dbo].[EPICOps_ActivityType_NewSupportRequest] ******/
DROP FUNCTION [dbo].[EPICOps_ActivityType_NewSupportRequest]

EXEC('
-- =============================================
-- Author:		Andrew Mason
-- Create date: 07/15/2011
-- Description:	Constant for the activity type that 
--              represents a new support request for EPICOps
-- =============================================
CREATE FUNCTION [dbo].[OpsActivityTypeNewSupportRequest] ()
RETURNS SMALLINT
AS
BEGIN
	RETURN 4
END
')

/****** Replace Function [dbo].[EPICOps_Update_Value] ******/
DROP FUNCTION [dbo].[EPICOps_Update_Value]

EXEC('
-- =============================================
-- Author:		Andrew Mason
-- Create date: 07/15/2011
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[OpsUpdateValue] ()
RETURNS INT
AS
BEGIN
	RETURN 1
END
')

/****** Replace Procedure [dbo].[EPIC_Signal_Update] ******/
DROP PROCEDURE [dbo].[EPIC_Signal_Update] 

EXEC('
-- =============================================
-- Author:		Andrew Mason
-- Create date: 07/15/2011
-- Description:	This procedure is called by a number of triggers
--				enabled on tables that are used to update the 
--				display of the EPICOps system.
-- =============================================
CREATE PROCEDURE [dbo].[OpsSignalUpdate] 
@ClientLocationId INT,
@ActivityType SMALLINT  
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE UpdateStatus
	SET StatusValue = ''true''
	WHERE UpdateTypeId = dbo.OpsUpdateValue() 
	IF(@ClientLocationId is not NULL) 
	BEGIN
		INSERT INTO ActiveOrganization (ActivityTypeId, LocationId, ActivityTime)
		VALUES(@ActivityType, @ClientLocationId, GetDate())
	END

END
')

PRINT 'Creating triggers ...'

/****** Replace Trigger [dbo].[EPIC_EC_CustomerDevice_Signal_Update] ******/
DROP TRIGGER [dbo].[EPIC_EC_CustomerDevice_Signal_Update] 

EXEC('
-- =============================================
-- Author:		Andrew Mason
-- Create date: 07/15/2011
-- Description: Trigger to toggle the update bit for
--				EPICOps system.
-- =============================================
CREATE TRIGGER [dbo].[DeviceSignalUpdateTrigger] 
   ON  [dbo].[Device] 
   AFTER INSERT, UPDATE
AS 
BEGIN
	SET NOCOUNT ON;
	DECLARE @LocationId as INT
	DECLARE @ActivityType as SMALLINT

	
	SELECT @LocationId = LocationId FROM INSERTED
	SELECT @ActivityType = dbo.OpsActivityTypeDevicePing()

	exec OpsSignalUpdate @LocationId, @ActivityType
END
')

/****** Replace Trigger [dbo].[EPIC_EC_ExceptionLog_Signal_Update] ******/
DROP TRIGGER [dbo].[EPIC_EC_ExceptionLog_Signal_Update] 

EXEC('
-- =============================================
-- Author:		Andrew Mason
-- Create date: 07/15/2011
-- Description: Trigger to toggle the update bit for
--				EPICOps system.
-- =============================================
CREATE TRIGGER [dbo].[ExceptionLogSignalUpdateTrigger] 
   ON  [dbo].[ExceptionLog] 
   AFTER INSERT, DELETE
AS 
BEGIN
	SET NOCOUNT ON;
	DECLARE @ActivityType as SMALLINT
	DECLARE @LocationId as INT

	SELECT @LocationId = d.LocationId
	FROM INSERTED i
	JOIN dbo.Device d ON d.DeviceId = i.DeviceId
	
	SELECT @ActivityType = dbo.OpsActivityTypeNewException()

	exec OpsSignalUpdate @LocationId, @ActivityType
END
')

/****** Replace Trigger [dbo].[EPIC_EC_PurchaseHistory_Signal_Update] ******/
DROP TRIGGER [dbo].[EPIC_EC_PurchaseHistory_Signal_Update] 

EXEC('
-- =============================================
-- Author:		Andrew Mason
-- Create date: 07/15/2011
-- Description: Trigger to toggle the update bit for
--				EPICOps system.
-- =============================================
CREATE TRIGGER [dbo].[PurchaseHistorySignalUpdateTrigger] 
   ON  [dbo].[PurchaseHistory] 
   AFTER INSERT, DELETE
AS 
BEGIN
	SET NOCOUNT ON;
	DECLARE @TempLocation AS INT
	DECLARE @ActivityType as SMALLINT

	SELECT @TempLocation = LocationId FROM INSERTED
	SELECT @ActivityType = dbo.OpsActivityTypeNewPurchase()

	exec OpsSignalUpdate @TempLocation, @ActivityType
END
')

/****** Replace Trigger [dbo].[EPIC_EC_Support_Signal_Update] ******/
DROP TRIGGER [dbo].[EPIC_EC_Support_Signal_Update] 

EXEC('
-- =============================================
-- Author:		Andrew Mason
-- Create date: 07/15/2011
-- Description: Trigger to toggle the update bit for
--				EPICOps system.
-- =============================================
CREATE TRIGGER [dbo].[SupportIssueSignalUpdateTrigger] 
   ON  [dbo].[SupportIssue] 
   AFTER INSERT, DELETE
AS 
BEGIN
	SET NOCOUNT ON;
	DECLARE @TempLocation AS INT
	DECLARE @ActivityType as SMALLINT

	SELECT TOP 1 @TempLocation = l.LocationId
	FROM [dbo].[Location] l
	JOIN [dbo].[User] u ON l.OrganizationId = u.OrganizationId
	WHERE UserId = (SELECT FromUserId FROM INSERTED)
	
	SELECT @ActivityType = dbo.OpsActivityTypeNewSupportRequest()

	exec OpsSignalUpdate @TempLocation, @ActivityType
END
')

/****** Replace Trigger [dbo].[EPIC_EC_Usage_History_Signal_Update] ******/
DROP TRIGGER [dbo].[EPIC_EC_Usage_History_Signal_Update] 

EXEC('
-- =============================================
-- Author:		Andrew Mason
-- Create date: 07/15/2011
-- Description: Trigger to toggle the update bit for
--				EPICOps system.
-- =============================================
CREATE TRIGGER [dbo].[ScanHistorySignalUpdateTrigger] 
   ON  [dbo].[ScanHistory] 
   AFTER INSERT, DELETE
AS 
BEGIN
	SET NOCOUNT ON;
	DECLARE @TempLocation AS INT
	DECLARE @ActivityType AS SMALLINT

	SELECT TOP 1 @TempLocation = [LocationId]
	FROM [dbo].[Device]
	WHERE [DeviceId] = (SELECT DeviceId FROM INSERTED)
	
	SELECT @ActivityType = dbo.OpsActivityTypeNewScan()

	exec OpsSignalUpdate  @TempLocation, @ActivityType 
END
')

-- Drop the old tables.
PRINT 'Dropping the old tables ...'
DROP TABLE [dbo].[EC_ActiveCustomers]
DROP TABLE [dbo].[EC_Authorize_NET]
DROP TABLE [dbo].[EC_BillingInfo]
DROP TABLE [dbo].EC_Customer
DROP TABLE [dbo].EC_CustomerDevice
DROP TABLE [dbo].EC_CustomerLocation
DROP TABLE [dbo].EC_Device
DROP TABLE [dbo].EC_ExceptionLog
DROP TABLE [dbo].EC_MessageBank
DROP TABLE [dbo].EC_PurchaseHistory
DROP TABLE [dbo].EC_ScanRates
DROP TABLE [dbo].EC_ScanType
DROP TABLE [dbo].EC_Support
DROP TABLE [dbo].EC_SupportAreas
DROP TABLE [dbo].EC_UpdateStatus
DROP TABLE [dbo].EC_UsageHistory
DROP TABLE [dbo].EC_User
DROP TABLE [dbo].EC_UserOptions
DROP TABLE [dbo].EC_UserSalt
DROP TABLE [dbo].WS_Token
DROP TABLE [dbo].WS_UseLog

PRINT 'Almost done. Create SchemaVersion table for this version ...'
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
CREATE TABLE [dbo].[SchemaVersion](
	[Version] [smallint] NOT NULL
) ON [PRIMARY]
SET ANSI_PADDING OFF

INSERT INTO [dbo].[SchemaVersion] ( [Version] ) VALUES ( 1 )

PRINT 'Schema version is now 1.'

END -- End of processing when SchemaVersion table is non-existent.
GO

DECLARE @CurrentVersion smallint

-- Check for current schema version = 1
SELECT TOP 1 @CurrentVersion = [Version]
FROM [dbo].[SchemaVersion]

IF @CurrentVersion = 1
BEGIN

PRINT 'Schema version is 1. Upgrading to version 2 ...'

-- Create DeviceEvent table.
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
CREATE TABLE [dbo].[DeviceEvent](
	[DeviceEventId] [bigint] IDENTITY(1,1) NOT NULL,
	[DeviceId] [int] NOT NULL,
	[EventType] [smallint] NOT NULL,
	[EventTime] [datetime] NOT NULL,
	[EventData] [xml] NULL,
	[IsDeleted] [tinyint] NOT NULL,
 CONSTRAINT [PK_DeviceEvent] PRIMARY KEY CLUSTERED 
(
	[DeviceEventId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
SET ANSI_PADDING OFF

-- Define default values.
ALTER TABLE [dbo].[DeviceEvent] ADD  CONSTRAINT [DF_DeviceEvent_IsDeleted] DEFAULT ((0)) FOR [IsDeleted]

-- Foreign keys on DeviceEvent.
ALTER TABLE [dbo].[DeviceEvent] WITH CHECK ADD  CONSTRAINT [FK_DeviceEvent_Device] FOREIGN KEY([DeviceId])
REFERENCES [dbo].[Device] ([DeviceId])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[DeviceEvent] CHECK CONSTRAINT [FK_DeviceEvent_Device]

-- Update schema version.
UPDATE [dbo].[SchemaVersion]
SET [Version] = 2
WHERE [Version] = 1

PRINT 'Schema version is now 2.'

END -- End of processing for upgrading from Version 1 to Version 2.
GO

DECLARE @CurrentVersion smallint

-- Check for current schema version = 2
SELECT TOP 1 @CurrentVersion = [Version]
FROM [dbo].[SchemaVersion]

IF @CurrentVersion = 2
BEGIN

PRINT 'Schema version is 2. Upgrading to version 3 ...'

-- Drop FK contraints that reference ScanType table.
ALTER TABLE [dbo].[ScanRate] DROP CONSTRAINT [FK_ScanRate_ScanType]
ALTER TABLE [dbo].[ScanHistory] DROP CONSTRAINT [FK_ScanHistory_ScanType]

-- There is only one scan type, so change the type of all rates to it.
-- NOTE: For some reason, when running this script, it always complains
-- that ScanTypeId doesn't exist. Executing the update like this, gets
-- rid of the error.
EXEC('UPDATE [dbo].[ScanRate] SET [ScanTypeId] = 1')

-- Rename the ScanTypeId columns to be ScanType.
EXEC sp_rename 'ScanRate.ScanTypeId', 'ScanType', 'COLUMN'
EXEC sp_rename 'ScanHistory.ScanTypeId', 'ScanType', 'COLUMN'

-- Remove ScanType table.
DROP TABLE [dbo].[ScanType]

-- Drop FK constraint that references MessageType table.
ALTER TABLE [dbo].[Message] DROP CONSTRAINT [FK_Message_MessageType]

-- Rename the MessageTypeId column to be MessageType.
EXEC sp_rename 'Message.MessageTypeId', 'MessageType', 'COLUMN'

-- Remove the MessageType table.
DROP TABLE [dbo].[MessageType]

-- Need to add a ReceivedTime column to DeviceEvent, and
-- also remove the EventData column, which won't be used.
-- But would like to maintain some column order. So need
-- to rename old table, create new, move data and drop old.
-- Not really necessary, but early in development, so ...

ALTER TABLE [dbo].[DeviceEvent] DROP CONSTRAINT [DF_DeviceEvent_IsDeleted]
ALTER TABLE [dbo].[DeviceEvent] DROP CONSTRAINT [FK_DeviceEvent_Device]
ALTER TABLE [dbo].[DeviceEvent] DROP CONSTRAINT [PK_DeviceEvent]

EXEC sp_rename 'DeviceEvent', 'Old_DeviceEvent'

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
CREATE TABLE [dbo].[DeviceEvent](
	[DeviceEventId] [bigint] IDENTITY(1,1) NOT NULL,
	[DeviceId] [int] NOT NULL,
	[EventType] [smallint] NOT NULL,
	[EventTime] [datetime] NOT NULL,
	[ReceivedTime] [datetime] NOT NULL,
	[IsDeleted] [tinyint] NOT NULL,
 CONSTRAINT [PK_DeviceEvent] PRIMARY KEY CLUSTERED 
(
	[DeviceEventId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
SET ANSI_PADDING OFF

-- Define default values.
ALTER TABLE [dbo].[DeviceEvent] ADD  CONSTRAINT [DF_DeviceEvent_IsDeleted] DEFAULT ((0)) FOR [IsDeleted]

SET IDENTITY_INSERT [dbo].[DeviceEvent] ON

INSERT INTO [dbo].[DeviceEvent] (DeviceEventId, DeviceId, EventType, EventTime, ReceivedTime, IsDeleted)
SELECT DeviceEventId, DeviceId, EventType, EventTime, GETUTCDATE(), IsDeleted
FROM [dbo].[Old_DeviceEvent]

SET IDENTITY_INSERT [dbo].[DeviceEvent] OFF

DROP TABLE [dbo].[Old_DeviceEvent]

-- Need to add IsActive and DeactivateReason columns to the
-- Device table. So jump through the same hoops for it.

-- Drop trigger.
DROP TRIGGER [dbo].[DeviceSignalUpdateTrigger]

-- Drop index.
DROP INDEX [IDX_Device_UniqueIdentifier] ON [dbo].[Device]

-- Drop FK constraints that reference Device table.
ALTER TABLE [dbo].[ExceptionLog] DROP CONSTRAINT [FK_ExceptionLog_Device]
ALTER TABLE [dbo].[DeviceMessage] DROP CONSTRAINT [FK_DeviceMessage_Device]
ALTER TABLE [dbo].[PurchaseHistory] DROP CONSTRAINT [FK_PurchaseHistory_Device]
ALTER TABLE [dbo].[ScanHistory] DROP CONSTRAINT [FK_ScanHistory_Device]

-- Drop default constraints.
ALTER TABLE [dbo].[Device] DROP CONSTRAINT [DF_Device_IsDeleted]
ALTER TABLE [dbo].[Device] DROP CONSTRAINT [DF_Device_ScansAvailable]
ALTER TABLE [dbo].[Device] DROP CONSTRAINT [DF_Device_ScansUsed]
ALTER TABLE [dbo].[Device] DROP CONSTRAINT [DF_Device_CurrentStatus]
ALTER TABLE [dbo].[Device] DROP CONSTRAINT [DF_Device_AuthenticationToken]

-- Drop PK constraint.
ALTER TABLE [dbo].[Device] DROP CONSTRAINT [PK_Device]

-- Drop FK constraint.
ALTER TABLE [dbo].[Device] DROP CONSTRAINT [FK_Device_Location]

-- Rename current table.
EXEC sp_rename 'Device', 'Old_Device'

-- Create new table.
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
CREATE TABLE [dbo].[Device](
	[DeviceId] [int] IDENTITY(1,1) NOT NULL,
	[LocationId] [int] NOT NULL,
	[UniqueIdentifier] [varchar](40) NOT NULL,
	[AuthenticationToken] [varchar] (48) NOT NULL,
	[SerialNumber] [varchar](40) NOT NULL,
	[MACAddress] [varchar](20) NOT NULL,
	[DateIssued] [datetime] NOT NULL,
	[RevisionLevel] [varchar](5) NOT NULL,
	[ScansAvailable] [int] NOT NULL,
	[ScansCompleted] [int] NOT NULL,
	[CurrentStatus] [varchar](50) NOT NULL,
	[LastReportTime] [datetime] NULL,
	[IsActive] [tinyint] NOT NULL,
	[DeactivateReason] [varchar] (128) NOT NULL,
	[IsDeleted] [tinyint] NOT NULL,
 CONSTRAINT [PK_Device] PRIMARY KEY CLUSTERED 
(
	[DeviceId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
SET ANSI_PADDING OFF

-- Add default constraints.
ALTER TABLE [dbo].[Device] ADD  CONSTRAINT [DF_Device_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
ALTER TABLE [dbo].[Device] ADD  CONSTRAINT [DF_Device_ScansAvailable]  DEFAULT ((0)) FOR [ScansAvailable]
ALTER TABLE [dbo].[Device] ADD  CONSTRAINT [DF_Device_ScansCompleted]  DEFAULT ((0)) FOR [ScansCompleted]
ALTER TABLE [dbo].[Device] ADD  CONSTRAINT [DF_Device_CurrentStatus]  DEFAULT ('') FOR [CurrentStatus]
ALTER TABLE [dbo].[Device] ADD  CONSTRAINT [DF_Device_AuthenticationToken]  DEFAULT ('') FOR [AuthenticationToken]
ALTER TABLE [dbo].[Device] ADD  CONSTRAINT [DF_Device_IsActive]  DEFAULT ((1)) FOR [IsActive]
ALTER TABLE [dbo].[Device] ADD  CONSTRAINT [DF_Device_DeactivateReason]  DEFAULT ('') FOR [DeactivateReason]

-- Copy.
SET IDENTITY_INSERT [dbo].[Device] ON

INSERT INTO [dbo].[Device] (DeviceId, LocationId, UniqueIdentifier, AuthenticationToken, SerialNumber, MACAddress, DateIssued, RevisionLevel,
							ScansAvailable, ScansCompleted, CurrentStatus, LastReportTime, IsDeleted)
SELECT DeviceId, LocationId, UniqueIdentifier, AuthenticationToken, SerialNumber, MACAddress, DateIssued, RevisionLevel,
		ScansAvailable, ScansUsed, CurrentStatus, LastReportTime, IsDeleted
FROM [dbo].[Old_Device]

SET IDENTITY_INSERT [dbo].[Device] OFF

-- Drop old table.
DROP TABLE [dbo].[Old_Device]

-- Foreign keys on Device.
ALTER TABLE [dbo].[Device]  WITH CHECK ADD  CONSTRAINT [FK_Device_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([LocationId])
ALTER TABLE [dbo].[Device] CHECK CONSTRAINT [FK_Device_Location]

-- Foreign keys referencing Device table.
ALTER TABLE [dbo].[ExceptionLog]  WITH CHECK ADD  CONSTRAINT [FK_ExceptionLog_Device] FOREIGN KEY([DeviceId])
REFERENCES [dbo].[Device] ([DeviceId])
ALTER TABLE [dbo].[ExceptionLog] CHECK CONSTRAINT [FK_ExceptionLog_Device]

ALTER TABLE [dbo].[DeviceMessage]  WITH CHECK ADD  CONSTRAINT [FK_DeviceMessage_Device] FOREIGN KEY([DeviceId])
REFERENCES [dbo].[Device] ([DeviceId])
ALTER TABLE [dbo].[DeviceMessage] CHECK CONSTRAINT [FK_DeviceMessage_Device]

ALTER TABLE [dbo].[PurchaseHistory]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseHistory_Device] FOREIGN KEY([DeviceId])
REFERENCES [dbo].[Device] ([DeviceId])
ALTER TABLE [dbo].[PurchaseHistory] CHECK CONSTRAINT [FK_PurchaseHistory_Device]

ALTER TABLE [dbo].[ScanHistory]  WITH CHECK ADD  CONSTRAINT [FK_ScanHistory_Device] FOREIGN KEY([DeviceId])
REFERENCES [dbo].[Device] ([DeviceId])
ALTER TABLE [dbo].[ScanHistory] CHECK CONSTRAINT [FK_ScanHistory_Device]

-- Foreign keys on DeviceEvent.
ALTER TABLE [dbo].[DeviceEvent] WITH CHECK ADD  CONSTRAINT [FK_DeviceEvent_Device] FOREIGN KEY([DeviceId])
REFERENCES [dbo].[Device] ([DeviceId])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[DeviceEvent] CHECK CONSTRAINT [FK_DeviceEvent_Device]

-- Index for Device.
CREATE UNIQUE NONCLUSTERED INDEX IDX_Device_UniqueIdentifier
ON [dbo].[Device] ( [UniqueIdentifier] ASC ) WITH ( FILLFACTOR = 80 )

-- Add the trigger back. The algorithm of the trigger has changed.
EXEC('
-- =============================================
-- Author:		Andrew Mason
-- Create date: 07/15/2011
-- Description: Trigger to toggle the update bit for
--				EPICOps system.
-- =============================================
CREATE TRIGGER [dbo].[DeviceSignalUpdateTrigger] 
   ON  [dbo].[Device] 
   AFTER INSERT, UPDATE
AS 
BEGIN
	SET NOCOUNT ON;
	DECLARE @LocationId as INT
	DECLARE @ActivityType as SMALLINT
	DECLARE @Activity as VARCHAR(50)

	IF UPDATE(LastReportTime)
	BEGIN
		SELECT @Activity = CurrentStatus FROM INSERTED
		IF @Activity = ''Ping''
		BEGIN
			SELECT @LocationId = LocationId FROM INSERTED
			SELECT @ActivityType = dbo.OpsActivityTypeDevicePing()

			exec OpsSignalUpdate @LocationId, @ActivityType
		END
	END
END
')


-- Update schema version.
UPDATE [dbo].[SchemaVersion]
SET [Version] = 3
WHERE [Version] = 2

PRINT 'Schema version is now 3.'

END -- End of processing for upgrading from Version 2 to Version 3.
GO

DECLARE @CurrentVersion smallint

-- Check for current schema version = 3
SELECT TOP 1 @CurrentVersion = [Version]
FROM [dbo].[SchemaVersion]

IF @CurrentVersion = 3
BEGIN

PRINT 'Schema version is 3. Upgrading to version 4 ...'

PRINT 'Creating ImageSet table ...'

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
CREATE TABLE [dbo].[ImageSet](
	[ImageSetId] [bigint] IDENTITY(1,1) NOT NULL,
	[UniqueIdentifier] [varchar](40) NOT NULL,
	[Images] [varbinary](max) NOT NULL,
	[IsDeleted] [tinyint] NOT NULL,
 CONSTRAINT [PK_ImageSet] PRIMARY KEY CLUSTERED 
(
	[ImageSetId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
SET ANSI_PADDING OFF

-- Set default values.
ALTER TABLE [dbo].[ImageSet] ADD  CONSTRAINT [DF_ImageSet_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]

-- Additional index for ImageSet.
CREATE UNIQUE NONCLUSTERED INDEX IDX_ImageSet_UniqueIdentifier
ON [dbo].[ImageSet] ( [UniqueIdentifier] ASC ) WITH ( FILLFACTOR = 80 )

PRINT 'Creating Patient table ...'

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
CREATE TABLE [dbo].[Patient](
	[PatientId] [int] IDENTITY(1,1) NOT NULL,
	[UniqueIdentifier] [varchar](40) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[MiddleInitial] [char](1) NULL,
	[PhoneNumber] [varchar](20) NULL,
	[EmailAddress] [varchar](128) NULL,
	[BirthDate] [datetime] NOT NULL,
	[Gender] [smallint] NOT NULL,
	[IsDeleted] [tinyint] NOT NULL,
 CONSTRAINT [PK_Patient] PRIMARY KEY CLUSTERED 
(
	[PatientId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
SET ANSI_PADDING OFF

-- Set default values.
ALTER TABLE [dbo].[Patient] ADD  CONSTRAINT [DF_Patient_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]

-- Additional indexes for Patient.
CREATE UNIQUE NONCLUSTERED INDEX IDX_Patient_UniqueIdentifier
ON [dbo].[Patient] ( [UniqueIdentifier] ASC ) WITH ( FILLFACTOR = 80 )

CREATE NONCLUSTERED INDEX IDX_Patient_FirstName
ON [dbo].[Patient] ( [FirstName] ASC ) WITH ( FILLFACTOR = 80 )

CREATE NONCLUSTERED INDEX IDX_Patient_LastName
ON [dbo].[Patient] ( [LastName] ASC ) WITH ( FILLFACTOR = 80 )

CREATE NONCLUSTERED INDEX IDX_Patient_BirthDate
ON [dbo].[Patient] ( [BirthDate] ASC ) WITH ( FILLFACTOR = 80 )

PRINT 'Creating Calibration table ...'

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
CREATE TABLE [dbo].[Calibration](
	[CalibrationId] [bigint] IDENTITY(1,1) NOT NULL,
	[DeviceId] [int] NOT NULL,
	[UniqueIdentifier] [varchar](40) NOT NULL,
	[CalibrationTime] [datetime] NOT NULL,
	[PerformedBy] [varchar](80) NOT NULL,
	[ImageSetId] [bigint] NOT NULL,
	[IsDeleted] [tinyint] NOT NULL,
 CONSTRAINT [PK_Calibration] PRIMARY KEY CLUSTERED 
(
	[CalibrationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
SET ANSI_PADDING OFF

-- Set default values.
ALTER TABLE [dbo].[Calibration] ADD  CONSTRAINT [DF_Calibration_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]

-- Additional indexes for Calibration.
CREATE UNIQUE NONCLUSTERED INDEX IDX_Calibration_UniqueIdentifier
ON [dbo].[Calibration] ( [UniqueIdentifier] ASC ) WITH ( FILLFACTOR = 80 )

CREATE NONCLUSTERED INDEX IDX_Calibration_DeviceId
ON [dbo].[Calibration] ( [DeviceId] ASC ) WITH ( FILLFACTOR = 80 )

-- Foreign keys on Calibration.
ALTER TABLE [dbo].[Calibration] WITH CHECK ADD CONSTRAINT [FK_Calibration_Device] FOREIGN KEY([DeviceId])
REFERENCES [dbo].[Device] ([DeviceId])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[Calibration] CHECK CONSTRAINT [FK_Calibration_Device]

ALTER TABLE [dbo].[Calibration] WITH CHECK ADD CONSTRAINT [FK_Calibration_ImageSet] FOREIGN KEY([ImageSetId])
REFERENCES [dbo].[ImageSet] ([ImageSetId])

ALTER TABLE [dbo].[Calibration] CHECK CONSTRAINT [FK_Calibration_ImageSet]

PRINT 'Creating Treatment table ...'

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
CREATE TABLE [dbo].[Treatment](
	[TreatmentId] [bigint] IDENTITY(1,1) NOT NULL,
	[PatientId] [int] NOT NULL,
	[CalibrationId] [bigint] NOT NULL,
	[UniqueIdentifier] [varchar](40) NOT NULL,
	[TreatmentType] [smallint] NOT NULL,
	[TreatmentTime] [datetime] NOT NULL,
	[PerformedBy] [varchar](80) NOT NULL,
	[EnergizedImageSetId] [bigint] NOT NULL,
	[FingerImageSetId] [bigint] NOT NULL,
	[SoftwareVersion] [varchar](20) NOT NULL,
	[FirmwareVersion] [varchar](50) NOT NULL,
	[AnalysisTime] [datetime] NOT NULL,
	[IsDeleted] [tinyint] NOT NULL,
 CONSTRAINT [PK_Treatment] PRIMARY KEY CLUSTERED 
(
	[TreatmentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
SET ANSI_PADDING OFF

-- Set default values.
ALTER TABLE [dbo].[Treatment] ADD CONSTRAINT [DF_Treatment_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]

-- Additional indexes for Treatment.
CREATE UNIQUE NONCLUSTERED INDEX IDX_Treatment_UniqueIdentifier
ON [dbo].[Treatment] ( [UniqueIdentifier] ASC ) WITH ( FILLFACTOR = 80 )

CREATE NONCLUSTERED INDEX IDX_Treatment_PatientId
ON [dbo].[Treatment] ( [PatientId] ASC ) WITH ( FILLFACTOR = 80 )

CREATE NONCLUSTERED INDEX IDX_Treatment_CalibrationId
ON [dbo].[Treatment] ( [CalibrationId] ASC ) WITH ( FILLFACTOR = 80 )

-- Foreign keys on Treatment.
ALTER TABLE [dbo].[Treatment] WITH CHECK ADD CONSTRAINT [FK_Treatment_Patient] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patient] ([PatientId])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[Treatment] CHECK CONSTRAINT [FK_Treatment_Patient]

ALTER TABLE [dbo].[Treatment] WITH CHECK ADD CONSTRAINT [FK_Treatment_EnergizedImageSet] FOREIGN KEY([EnergizedImageSetId])
REFERENCES [dbo].[ImageSet] ([ImageSetId])

ALTER TABLE [dbo].[Treatment] CHECK CONSTRAINT [FK_Treatment_EnergizedImageSet]

ALTER TABLE [dbo].[Treatment] WITH CHECK ADD CONSTRAINT [FK_Treatment_FingerImageSet] FOREIGN KEY([FingerImageSetId])
REFERENCES [dbo].[ImageSet] ([ImageSetId])

ALTER TABLE [dbo].[Treatment] CHECK CONSTRAINT [FK_Treatment_FingerImageSet]

ALTER TABLE [dbo].[Treatment] WITH CHECK ADD CONSTRAINT [FK_Treatment_Calibration] FOREIGN KEY([CalibrationId])
REFERENCES [dbo].[Calibration] ([CalibrationId])

ALTER TABLE [dbo].[Treatment] CHECK CONSTRAINT [FK_Treatment_Calibration]

PRINT 'Creating NBAnalysisResult table ...'

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
CREATE TABLE [dbo].[NBAnalysisResult](
	[NBAnalysisResultId] [bigint] IDENTITY(1,1) NOT NULL,
	[TreatmentId] [bigint] NOT NULL,
	[NBAnalysisGroup] [smallint] NOT NULL,
	[ResultScoreFiltered] [numeric](16,4) NOT NULL,
	[ResultScoreUnfiltered] [numeric](16,4) NOT NULL,
	[OddsRatioFiltered] [numeric](16,4) NOT NULL,
	[OddsRatioUnfiltered] [numeric](16,4) NOT NULL,
	[IsDeleted] [tinyint] NOT NULL,
 CONSTRAINT [PK_NBAnalysisResult] PRIMARY KEY CLUSTERED 
(
	[NBAnalysisResultId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
SET ANSI_PADDING OFF

-- Set default values.
ALTER TABLE [dbo].[NBAnalysisResult] ADD CONSTRAINT [DF_NBAnalysisResult_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]

-- Additional index for NBAnalysisResult.
CREATE NONCLUSTERED INDEX IDX_NBAnalysisResult_TreatmentId
ON [dbo].[NBAnalysisResult] ( [TreatmentId] ASC ) WITH ( FILLFACTOR = 80 )

-- Foreign keys on NBAnalysisResult.
ALTER TABLE [dbo].[NBAnalysisResult] WITH CHECK ADD CONSTRAINT [FK_NBAnalysisResult_Treatment] FOREIGN KEY([TreatmentId])
REFERENCES [dbo].[Treatment] ([TreatmentId])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[NBAnalysisResult] CHECK CONSTRAINT [FK_NBAnalysisResult_Treatment]

PRINT 'Creating Organ table ...'

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
CREATE TABLE [dbo].[Organ](
	[OrganId] [smallint] NOT NULL,
	[EPICOrganId] [smallint] NOT NULL,
	[Description] [varchar](128) NOT NULL,
	[IsDeleted] [tinyint] NOT NULL,
 CONSTRAINT [PK_Organ] PRIMARY KEY CLUSTERED 
(
	[OrganId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
SET ANSI_PADDING OFF

-- Set default values.
ALTER TABLE [dbo].[Organ] ADD CONSTRAINT [DF_Organ_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]

-- Additional index for Organ.
CREATE UNIQUE NONCLUSTERED INDEX IDX_Organ_EPICOrganId
ON [dbo].[Organ] ( [EPICOrganId] ASC ) WITH ( FILLFACTOR = 80 )

PRINT 'Creating Severity table ...'

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
CREATE TABLE [dbo].[Severity](
	[SeverityId] [bigint] IDENTITY(1,1) NOT NULL,
	[TreatmentId] [bigint] NOT NULL,
	[OrganId] [smallint] NOT NULL,
	[PhysicalRight] [int] NOT NULL,
	[PhysicalLeft] [int] NOT NULL,
	[MentalRight] [int] NOT NULL,
	[MentalLeft] [int] NOT NULL,
	[IsDeleted] [tinyint] NOT NULL,
 CONSTRAINT [PK_Severity] PRIMARY KEY CLUSTERED 
(
	[SeverityId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
SET ANSI_PADDING OFF

-- Set default values.
ALTER TABLE [dbo].[Severity] ADD CONSTRAINT [DF_Severity_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]

-- Additional indexes for Severity.
CREATE NONCLUSTERED INDEX IDX_Severity_TreatmentId
ON [dbo].[Severity] ( [TreatmentId] ASC ) WITH ( FILLFACTOR = 80 )

CREATE NONCLUSTERED INDEX IDX_Severity_OrganId
ON [dbo].[Severity] ( [OrganId] ASC ) WITH ( FILLFACTOR = 80 )

-- Foreign keys on Severity.
ALTER TABLE [dbo].[Severity] WITH CHECK ADD CONSTRAINT [FK_Severity_Treatment] FOREIGN KEY([TreatmentId])
REFERENCES [dbo].[Treatment] ([TreatmentId])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[Severity] CHECK CONSTRAINT [FK_Severity_Treatment]

ALTER TABLE [dbo].[Severity] WITH CHECK ADD CONSTRAINT [FK_Severity_Organ] FOREIGN KEY([OrganId])
REFERENCES [dbo].[Organ] ([OrganId])

ALTER TABLE [dbo].[Severity] CHECK CONSTRAINT [FK_Severity_Organ]

PRINT 'Creating AnalysisResult table ...'

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
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
	[IsDeleted] [tinyint] NOT NULL,
 CONSTRAINT [PK_AnalysisResult] PRIMARY KEY CLUSTERED 
(
	[AnalysisResultID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
SET ANSI_PADDING OFF

-- Set default values.
ALTER TABLE [dbo].[AnalysisResult] ADD CONSTRAINT [DF_AnalysisResult_AnalysisTime] DEFAULT (getutcdate()) FOR [AnalysisTime]
ALTER TABLE [dbo].[AnalysisResult] ADD CONSTRAINT [DF_AnalysisResult_IsFiltered] DEFAULT ((0)) FOR [IsFiltered]
ALTER TABLE [dbo].[AnalysisResult] ADD CONSTRAINT [DF_AnalysisResult_FingerType] DEFAULT ((0)) FOR [FingerType]
ALTER TABLE [dbo].[AnalysisResult] ADD CONSTRAINT [DF_AnalysisResult_SectorNumber] DEFAULT ((0)) FOR [SectorNumber]
ALTER TABLE [dbo].[AnalysisResult] ADD CONSTRAINT [DF_AnalysisResult_StartAngle] DEFAULT ((0)) FOR [StartAngle]
ALTER TABLE [dbo].[AnalysisResult] ADD CONSTRAINT [DF_AnalysisResult_EndAngle] DEFAULT ((0)) FOR [EndAngle]
ALTER TABLE [dbo].[AnalysisResult] ADD CONSTRAINT [DF_AnalysisResult_SectorArea] DEFAULT ((0)) FOR [SectorArea]
ALTER TABLE [dbo].[AnalysisResult] ADD CONSTRAINT [DF_AnalysisResult_IntegralArea] DEFAULT ((0)) FOR [IntegralArea]
ALTER TABLE [dbo].[AnalysisResult] ADD CONSTRAINT [DF_AnalysisResult_NormalizedArea] DEFAULT ((0)) FOR [NormalizedArea]
ALTER TABLE [dbo].[AnalysisResult] ADD CONSTRAINT [DF_AnalysisResult_AverageIntensity] DEFAULT ((0)) FOR [AverageIntensity]
ALTER TABLE [dbo].[AnalysisResult] ADD CONSTRAINT [DF_AnalysisResult_Entropy] DEFAULT ((0)) FOR [Entropy]
ALTER TABLE [dbo].[AnalysisResult] ADD CONSTRAINT [DF_AnalysisResult_FormCoefficient] DEFAULT ((0)) FOR [FormCoefficient]
ALTER TABLE [dbo].[AnalysisResult] ADD CONSTRAINT [DF_AnalysisResult_FractalCoefficient] DEFAULT ((0)) FOR [FractalCoefficient]
ALTER TABLE [dbo].[AnalysisResult] ADD CONSTRAINT [DF_AnalysisResult_JsInteger] DEFAULT ((0)) FOR [JsInteger]
ALTER TABLE [dbo].[AnalysisResult] ADD CONSTRAINT [DF_AnalysisResult_CenterX] DEFAULT ((0)) FOR [CenterX]
ALTER TABLE [dbo].[AnalysisResult] ADD CONSTRAINT [DF_AnalysisResult_CenterY] DEFAULT ((0)) FOR [CenterY]
ALTER TABLE [dbo].[AnalysisResult] ADD CONSTRAINT [DF_AnalysisResult_RadiusMin] DEFAULT ((0)) FOR [RadiusMin]
ALTER TABLE [dbo].[AnalysisResult] ADD CONSTRAINT [DF_AnalysisResult_RadiusMax] DEFAULT ((0)) FOR [RadiusMax]
ALTER TABLE [dbo].[AnalysisResult] ADD CONSTRAINT [DF_AnalysisResult_AngleofRotation] DEFAULT ((0)) FOR [AngleOfRotation]
ALTER TABLE [dbo].[AnalysisResult] ADD CONSTRAINT [DF_AnalysisResult_Form2] DEFAULT ((0.0)) FOR [Form2]
ALTER TABLE [dbo].[AnalysisResult] ADD CONSTRAINT [DF_AnalysisResult_NoiseLevel] DEFAULT ((30)) FOR [NoiseLevel]
ALTER TABLE [dbo].[AnalysisResult] ADD CONSTRAINT [DF_AnalysisResult_BreakCoefficient] DEFAULT ((0.0)) FOR [BreakCoefficient]
ALTER TABLE [dbo].[AnalysisResult] ADD CONSTRAINT [DF_AnalysisResult_SoftwareVersion] DEFAULT ('-Unknown-') FOR [SoftwareVersion]
ALTER TABLE [dbo].[AnalysisResult] ADD CONSTRAINT [DF_AnalysisResult_AI1] DEFAULT ((0)) FOR [AI1]
ALTER TABLE [dbo].[AnalysisResult] ADD CONSTRAINT [DF_AnalysisResult_AI2] DEFAULT ((0)) FOR [AI2]
ALTER TABLE [dbo].[AnalysisResult] ADD CONSTRAINT [DF_AnalysisResult_AI3] DEFAULT ((0)) FOR [AI3]
ALTER TABLE [dbo].[AnalysisResult] ADD CONSTRAINT [DF_AnalysisResult_AI4] DEFAULT ((0)) FOR [AI4]
ALTER TABLE [dbo].[AnalysisResult] ADD CONSTRAINT [DF_AnalysisResult_Form1_1] DEFAULT ((0)) FOR [Form1_1]
ALTER TABLE [dbo].[AnalysisResult] ADD CONSTRAINT [DF_AnalysisResult_Form1_2] DEFAULT ((0)) FOR [Form1_2]
ALTER TABLE [dbo].[AnalysisResult] ADD CONSTRAINT [DF_AnalysisResult_Form1_3] DEFAULT ((0)) FOR [Form1_3]
ALTER TABLE [dbo].[AnalysisResult] ADD CONSTRAINT [DF_AnalysisResult_Form1_4] DEFAULT ((0)) FOR [Form1_4]
ALTER TABLE [dbo].[AnalysisResult] ADD CONSTRAINT [DF_AnalysisResult_RingThickness] DEFAULT ((0.0)) FOR [RingThickness]
ALTER TABLE [dbo].[AnalysisResult] ADD CONSTRAINT [DF_AnalysisResult_RingIntensity] DEFAULT ((0.0)) FOR [RingIntensity]
ALTER TABLE [dbo].[AnalysisResult] ADD CONSTRAINT [DF_AnalysisResult_Form2Prime] DEFAULT ((0)) FOR [Form2Prime]
ALTER TABLE [dbo].[AnalysisResult] ADD CONSTRAINT [DF_AnalysisResult_UserName] DEFAULT ('Administrator') FOR [UserName]
ALTER TABLE [dbo].[AnalysisResult] ADD CONSTRAINT [DF_AnalysisResult_IsDeleted] DEFAULT ((0)) FOR [IsDeleted]

-- Additional index for AnalysisResult.
CREATE NONCLUSTERED INDEX IDX_AnalysisResult_TreatmentId
ON [dbo].[AnalysisResult] ( [TreatmentId] ASC ) WITH ( FILLFACTOR = 80 )

-- Foreign keys on AnalysisResult.
ALTER TABLE [dbo].[AnalysisResult] WITH CHECK ADD CONSTRAINT [FK_AnalysisResult_Treatment] FOREIGN KEY([TreatmentId])
REFERENCES [dbo].[Treatment] ([TreatmentId])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[AnalysisResult] CHECK CONSTRAINT [FK_AnalysisResult_Treatment]

PRINT 'Populate the Organ table ...'

INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (2,17,'Descending Colon');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (3,16,'Ascending Colon');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (4,18,'Sigmoid Colon');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (5,20,'Rectum');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (6,23,'Blind Gut');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (7,27,'Appendix');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (8,22,'Abdominal Region');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (10,26,'Jejunum');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (11,24,'Duodenum');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (12,25,'Ileum');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (19,65,'Cervical Spine - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (20,19,'Transverse Colon - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (23,13,'Ear/Nose/Sinus (R) - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (24,10,'Ear/Nose/Sinus (L) - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (26,68,'Jaw/Teeth (R) - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (27,60,'Jaw/Teeth (L) - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (30,9,'Cervical Vascular System - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (31,56,'Thyroid - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (33,6,'Cardiovascular Circulation (whole body) - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (35,38,'Urokidney - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (36,39,'Urokidney - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (38,30,'Immune System - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (39,12,'Thorax Respiratory - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (41,43,'Hypothalamus - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (42,55,'Pituitary - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (43,70,'Nervous System - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (45,34,'Genitourinary System - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (47,45,'Pancreas - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (48,47,'Pituitary - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (49,54,'Pineal - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (51,8,'Heart (right side)');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (54,11,'Respiratory/Mammary - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (56,15,'Thorax Respiratory - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (65,48,'Thyroid - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (67,5,'Cervical Vascular System - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (70,1,'Heart (muscles)');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (78,3,'Coronary Vessels - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (79,7,'Coronary Vessels - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (96,32,'Adrenal - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (97,35,'Adrenal - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (100,33,'Kidney (L)');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (101,36,'Kidney (R)');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (106,52,'Liver - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (108,44,'Liver - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (120,40,'Gallbladder');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (122,21,'Transverse Colon - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (142,57,'Cervical Spine - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (144,64,'Thoracic Spine - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (145,72,'Thoracic Spine - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (146,61,'Lumbar Spine - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (147,69,'Lumbar Spine - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (148,63,'Sacrum - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (149,71,'Sacrum - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (150,58,'Coccyx/Pelvis - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (151,66,'Coccyx/Pelvis - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (152,37,'Genitourinary System - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (155,2,'Cardiovascular Circulation (whole body) - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (159,28,'Immune System - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (161,4,'Heart (left side)');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (162,62,'Nervous System - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (169,53,'Pancreas - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (172,29,'Spleen - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (173,31,'Spleen - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (174,14,'Respiratory/Mammary - Right ');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (196,42,'Cerebral Vessels - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (197,50,'Cerebral Vessels - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (198,46,'Pineal - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (200,41,'Cerebral Cortex - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (201,49,'Cerebral Cortex - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (202,51,'Hypothalamus - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (204,59,'Eye (L) - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (205,77,'Eye (L) - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (206,67,'Eye (R) - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (207,78,'Eye (R) - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (208,74,'Ear/Nose/Sinus (L) - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (209,73,'Ear/Nose/Sinus (R) - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (210,75,'Jaw/Teeth (L) - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (211,76,'Jaw/Teeth (R) - Left');

-- Create some additional indexes on existing tables. These should
-- improve query performance later on.
PRINT 'Creating additional indexes on existing tables ...'

CREATE NONCLUSTERED INDEX IDX_SupportIssue_ParentId
ON [dbo].[SupportIssue] ( [ParentId] ASC ) WITH ( FILLFACTOR = 80 )

CREATE NONCLUSTERED INDEX IDX_SupportIssue_SupportAreaId
ON [dbo].[SupportIssue] ( [SupportAreaId] ASC ) WITH ( FILLFACTOR = 80 )

CREATE NONCLUSTERED INDEX IDX_SupportIssue_ToUserId
ON [dbo].[SupportIssue] ( [ToUserId] ASC ) WITH ( FILLFACTOR = 80 )

CREATE NONCLUSTERED INDEX IDX_SupportIssue_FromUserId
ON [dbo].[SupportIssue] ( [FromUserId] ASC ) WITH ( FILLFACTOR = 80 )

CREATE NONCLUSTERED INDEX IDX_User_OrganizationId
ON [dbo].[User] ( [OrganizationId] ASC ) WITH ( FILLFACTOR = 80 )

CREATE NONCLUSTERED INDEX IDX_User_EmailAddress
ON [dbo].[User] ( [EmailAddress] ASC ) WITH ( FILLFACTOR = 80 )

CREATE NONCLUSTERED INDEX IDX_User_FirstName
ON [dbo].[User] ( [FirstName] ASC ) WITH ( FILLFACTOR = 80 )

CREATE NONCLUSTERED INDEX IDX_User_LastName
ON [dbo].[User] ( [LastName] ASC ) WITH ( FILLFACTOR = 80 )

CREATE NONCLUSTERED INDEX IDX_Organization_OrganizationTypeId
ON [dbo].[Organization] ( [OrganizationTypeId] ASC ) WITH ( FILLFACTOR = 80 )

CREATE NONCLUSTERED INDEX IDX_Contact_OrganizationId
ON [dbo].[Contact] ( [OrganizationId] ASC ) WITH ( FILLFACTOR = 80 )

CREATE NONCLUSTERED INDEX IDX_Location_OrganizationId
ON [dbo].[Location] ( [OrganizationId] ASC ) WITH ( FILLFACTOR = 80 )

CREATE NONCLUSTERED INDEX IDX_PurchaseHistory_LocationId
ON [dbo].[PurchaseHistory] ( [LocationId] ASC ) WITH ( FILLFACTOR = 80 )

CREATE NONCLUSTERED INDEX IDX_PurchaseHistory_DeviceId
ON [dbo].[PurchaseHistory] ( [DeviceId] ASC ) WITH ( FILLFACTOR = 80 )

CREATE NONCLUSTERED INDEX IDX_PurchaseHistory_UserId
ON [dbo].[PurchaseHistory] ( [UserId] ASC ) WITH ( FILLFACTOR = 80 )

CREATE NONCLUSTERED INDEX IDX_PurchaseHistory_PurchaseTime
ON [dbo].[PurchaseHistory] ( [PurchaseTime] ASC ) WITH ( FILLFACTOR = 80 )

CREATE NONCLUSTERED INDEX IDX_PurchaseHistory_TransactionId
ON [dbo].[PurchaseHistory] ( [TransactionId] ASC ) WITH ( FILLFACTOR = 80 )

CREATE NONCLUSTERED INDEX IDX_Device_LocationId
ON [dbo].[Device] ( [LocationId] ASC ) WITH ( FILLFACTOR = 80 )

CREATE NONCLUSTERED INDEX IDX_ExceptionLog_DeviceId
ON [dbo].[ExceptionLog] ( [DeviceId] ASC ) WITH ( FILLFACTOR = 80 )

CREATE NONCLUSTERED INDEX IDX_ScanHistory_DeviceId
ON [dbo].[ScanHistory] ( [DeviceId] ASC ) WITH ( FILLFACTOR = 80 )

CREATE NONCLUSTERED INDEX IDX_ScanHistory_ScanType
ON [dbo].[ScanHistory] ( [ScanType] ASC ) WITH ( FILLFACTOR = 80 )

CREATE NONCLUSTERED INDEX IDX_DeviceEvent_DeviceId
ON [dbo].[DeviceEvent] ( [DeviceId] ASC ) WITH ( FILLFACTOR = 80 )

CREATE NONCLUSTERED INDEX IDX_DeviceEvent_EventType
ON [dbo].[DeviceEvent] ( [EventType] ASC ) WITH ( FILLFACTOR = 80 )


-- Update schema version.
UPDATE [dbo].[SchemaVersion]
SET [Version] = 4
WHERE [Version] = 3

PRINT 'Schema version is now 4.'

END -- End of processing for upgrading from Version 3 to Version 4.
GO

DECLARE @CurrentVersion smallint

-- Check for current schema version = 4
SELECT TOP 1 @CurrentVersion = [Version]
FROM [dbo].[SchemaVersion]

IF @CurrentVersion = 4
BEGIN

PRINT 'Schema version is 4. Upgrading to version 5 ...'

-- Need to add some columns (CreateTime, LastLoginTime,
-- LastActivityTime, LastPasswordChangeTime, LastLockoutTime)
-- to the User table. But would like to maintain some column
-- order. So need to rename old table, create new, move data
-- and drop old. Not really necessary, but early in
-- development, so ...

-- Drop indexes.
DROP INDEX [IDX_User_EmailAddress] ON [dbo].[User]
DROP INDEX [IDX_User_FirstName] ON [dbo].[User]
DROP INDEX [IDX_User_LastName] ON [dbo].[User]
DROP INDEX [IDX_User_OrganizationId] ON [dbo].[User]
DROP INDEX [IDX_User_Username] ON [dbo].[User]

-- Drop foreign keys referencing User table.
ALTER TABLE [dbo].[UserRole] DROP CONSTRAINT [FK_UserRole_User]
ALTER TABLE [dbo].[UserSalt] DROP CONSTRAINT [FK_UserSalt_User]
ALTER TABLE [dbo].[UserSetting] DROP CONSTRAINT [FK_UserSetting_User]
ALTER TABLE [dbo].[PurchaseHistory] DROP CONSTRAINT [FK_PurchaseHistory_User]
ALTER TABLE [dbo].[UserAssignedLocation] DROP CONSTRAINT [FK_UserAssignedLocation_User]
ALTER TABLE [dbo].[SupportIssue] DROP CONSTRAINT [FK_SupportIssue_ToUser]
ALTER TABLE [dbo].[SupportIssue] DROP CONSTRAINT [FK_SupportIssue_FromUser]

-- Drop constraints.
ALTER TABLE [dbo].[User] DROP CONSTRAINT [DF_User_IsDeleted]
ALTER TABLE [dbo].[User] DROP CONSTRAINT [DF_User_ResetKey]
ALTER TABLE [dbo].[User] DROP CONSTRAINT [DF_User_SecurityAnswer1]
ALTER TABLE [dbo].[User] DROP CONSTRAINT [DF_User_SecurityQuestion1]
ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_User_Organization]
ALTER TABLE [dbo].[User] DROP CONSTRAINT [PK_User]

EXEC sp_rename 'User', 'Old_User'

-- Recreate with new columns.
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[OrganizationId] [int] NOT NULL,
	[Username] [varchar](80) NOT NULL,
	[Password] [varchar](512) NOT NULL,
	[EmailAddress] [varchar](128) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[SecurityQuestion1] [varchar](512) NOT NULL,
	[SecurityAnswer1] [varchar](128) NOT NULL,
	[ResetKey] [varchar](256) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[LastLoginTime] [datetime] NULL,
	[LastActivityTime] [datetime] NULL,
	[LastPasswordChangeTime] [datetime] NULL,
	[LastLockoutTime] [datetime] NULL,
	[IsDeleted] [tinyint] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
SET ANSI_PADDING OFF

-- Define default values.
ALTER TABLE [dbo].[User] ADD CONSTRAINT [DF_User_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
ALTER TABLE [dbo].[User] ADD CONSTRAINT [DF_User_ResetKey]  DEFAULT ('') FOR [ResetKey]
ALTER TABLE [dbo].[User] ADD CONSTRAINT [DF_User_SecurityQuestion1]  DEFAULT ('') FOR [SecurityQuestion1]
ALTER TABLE [dbo].[User] ADD CONSTRAINT [DF_User_SecurityAnswer1]  DEFAULT ('') FOR [SecurityAnswer1]
ALTER TABLE [dbo].[User] ADD CONSTRAINT [DF_User_CreateTime] DEFAULT (getutcdate()) FOR [CreateTime]

-- Add foreign key.
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Organization] FOREIGN KEY([OrganizationId])
REFERENCES [dbo].[Organization] ([OrganizationId])
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Organization]

-- Copy data.
SET IDENTITY_INSERT [dbo].[User] ON

INSERT INTO [dbo].[User] (UserId, OrganizationId, Username, Password, EmailAddress, FirstName, LastName, SecurityQuestion1, SecurityAnswer1, ResetKey, IsDeleted)
SELECT UserId, OrganizationId, Username, Password, EmailAddress, FirstName, LastName, SecurityQuestion1, SecurityAnswer1, ResetKey, IsDeleted
FROM [dbo].[Old_User]

SET IDENTITY_INSERT [dbo].[User] OFF

-- Create indexes.
CREATE NONCLUSTERED INDEX IDX_User_OrganizationId
ON [dbo].[User] ( [OrganizationId] ASC ) WITH ( FILLFACTOR = 80 )

CREATE NONCLUSTERED INDEX IDX_User_EmailAddress
ON [dbo].[User] ( [EmailAddress] ASC ) WITH ( FILLFACTOR = 80 )

CREATE NONCLUSTERED INDEX IDX_User_FirstName
ON [dbo].[User] ( [FirstName] ASC ) WITH ( FILLFACTOR = 80 )

CREATE NONCLUSTERED INDEX IDX_User_LastName
ON [dbo].[User] ( [LastName] ASC ) WITH ( FILLFACTOR = 80 )

CREATE NONCLUSTERED INDEX IDX_User_Username
ON [dbo].[User] ( [Username] ASC ) WITH ( FILLFACTOR = 80 )

-- Add back foreign key references to other tables.
ALTER TABLE [dbo].[SupportIssue]  WITH CHECK ADD  CONSTRAINT [FK_SupportIssue_ToUser] FOREIGN KEY([ToUserId])
REFERENCES [dbo].[User] ([UserId])
ALTER TABLE [dbo].[SupportIssue] CHECK CONSTRAINT [FK_SupportIssue_ToUser]

ALTER TABLE [dbo].[SupportIssue]  WITH CHECK ADD  CONSTRAINT [FK_SupportIssue_FromUser] FOREIGN KEY([FromUserId])
REFERENCES [dbo].[User] ([UserId])
ALTER TABLE [dbo].[SupportIssue] CHECK CONSTRAINT [FK_SupportIssue_FromUser]

ALTER TABLE [dbo].[UserAssignedLocation]  WITH CHECK ADD  CONSTRAINT [FK_UserAssignedLocation_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
ON UPDATE CASCADE
ON DELETE CASCADE
ALTER TABLE [dbo].[UserAssignedLocation] CHECK CONSTRAINT [FK_UserAssignedLocation_User]

ALTER TABLE [dbo].[PurchaseHistory]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseHistory_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
ALTER TABLE [dbo].[PurchaseHistory] CHECK CONSTRAINT [FK_PurchaseHistory_User]

ALTER TABLE [dbo].[UserSetting]  WITH CHECK ADD  CONSTRAINT [FK_UserSetting_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
ON UPDATE CASCADE
ON DELETE CASCADE
ALTER TABLE [dbo].[UserSetting] CHECK CONSTRAINT [FK_UserSetting_User]

ALTER TABLE [dbo].[UserSalt]  WITH CHECK ADD  CONSTRAINT [FK_UserSalt_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
ON UPDATE CASCADE
ON DELETE CASCADE
ALTER TABLE [dbo].[UserSalt] CHECK CONSTRAINT [FK_UserSalt_User]

ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
ON UPDATE CASCADE
ON DELETE CASCADE
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_User]

-- Drop the old table.
DROP TABLE [dbo].[Old_User]


-- Update schema version.
UPDATE [dbo].[SchemaVersion]
SET [Version] = 5
WHERE [Version] = 4

PRINT 'Schema version is now 5.'

END -- End of processing for upgrading from Version 4 to Version 5.
GO

DECLARE @CurrentVersion smallint

-- Check for current schema version = 5
SELECT TOP 1 @CurrentVersion = [Version]
FROM [dbo].[SchemaVersion]

IF @CurrentVersion = 5
BEGIN

PRINT 'Schema version is 5. Upgrading to version 6 ...'

-- The lefts and rights can be null.
ALTER TABLE [dbo].[Severity] ALTER COLUMN [PhysicalRight] [int] NULL
ALTER TABLE [dbo].[Severity] ALTER COLUMN [PhysicalLeft] [int] NULL
ALTER TABLE [dbo].[Severity] ALTER COLUMN [MentalRight] [int] NULL
ALTER TABLE [dbo].[Severity] ALTER COLUMN [MentalLeft] [int] NULL


-- Update schema version.
UPDATE [dbo].[SchemaVersion]
SET [Version] = 6
WHERE [Version] = 5

PRINT 'Schema version is now 6.'

END -- End of processing for upgrading from Version 5 to Version 6.
GO

DECLARE @CurrentVersion smallint

-- Check for current schema version = 6
SELECT TOP 1 @CurrentVersion = [Version]
FROM [dbo].[SchemaVersion]

IF @CurrentVersion = 6
BEGIN

PRINT 'Schema version is 6. Upgrading to version 7 ...'

-- Create new DeviceStateTracking table.
PRINT 'Creating DeviceStateTracking table ...'

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF

-- Set default values.
ALTER TABLE [dbo].[DeviceStateTracking] ADD  CONSTRAINT [DF_DeviceStateTracking_PreviousState]  DEFAULT ((0)) FOR [PreviousState]
ALTER TABLE [dbo].[DeviceStateTracking] ADD  CONSTRAINT [DF_DeviceStateTracking_ChangeReason]  DEFAULT (('')) FOR [ChangeReason]
ALTER TABLE [dbo].[DeviceStateTracking] ADD  CONSTRAINT [DF_DeviceStateTracking_ChangeTime]  DEFAULT (getutcdate()) FOR [ChangeTime]

-- Additional indexes for DeviceStateTracking.
CREATE NONCLUSTERED INDEX IDX_DeviceStateTracking_DeviceId
ON [dbo].[DeviceStateTracking] ( [DeviceId] ASC ) WITH ( FILLFACTOR = 80 )


-- Need to remove IsActive and DeactivateReason columns
-- from Device table and add DeviceState and UidQualifier
-- columns. But would like to maintain som column order. So
-- need to rename old table, create new, move data and drop
-- old. Not really necessary, but early in development, so ...

-- Drop trigger.
DROP TRIGGER [dbo].[DeviceSignalUpdateTrigger]

-- Drop indexes.
DROP INDEX [IDX_Device_LocationId] ON [dbo].[Device]
DROP INDEX [IDX_Device_UniqueIdentifier] ON [dbo].[Device]

-- Drop FK constraints that reference Device table.
ALTER TABLE [dbo].[ExceptionLog] DROP CONSTRAINT [FK_ExceptionLog_Device]
ALTER TABLE [dbo].[DeviceMessage] DROP CONSTRAINT [FK_DeviceMessage_Device]
ALTER TABLE [dbo].[PurchaseHistory] DROP CONSTRAINT [FK_PurchaseHistory_Device]
ALTER TABLE [dbo].[ScanHistory] DROP CONSTRAINT [FK_ScanHistory_Device]
ALTER TABLE [dbo].[DeviceEvent] DROP CONSTRAINT [FK_DeviceEvent_Device]
ALTER TABLE [dbo].[Calibration] DROP CONSTRAINT [FK_Calibration_Device]

-- Drop default constraints.
ALTER TABLE [dbo].[Device] DROP CONSTRAINT [DF_Device_IsDeleted]
ALTER TABLE [dbo].[Device] DROP CONSTRAINT [DF_Device_ScansAvailable]
ALTER TABLE [dbo].[Device] DROP CONSTRAINT [DF_Device_ScansCompleted]
ALTER TABLE [dbo].[Device] DROP CONSTRAINT [DF_Device_CurrentStatus]
ALTER TABLE [dbo].[Device] DROP CONSTRAINT [DF_Device_AuthenticationToken]
ALTER TABLE [dbo].[Device] DROP CONSTRAINT [DF_Device_IsActive]
ALTER TABLE [dbo].[Device] DROP CONSTRAINT [DF_Device_DeactivateReason]

-- Drop PK constraint.
ALTER TABLE [dbo].[Device] DROP CONSTRAINT [PK_Device]

-- Drop FK constraint.
ALTER TABLE [dbo].[Device] DROP CONSTRAINT [FK_Device_Location]

-- Rename current table.
EXEC sp_rename 'Device', 'Old_Device'

-- Create new table.
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
CREATE TABLE [dbo].[Device](
	[DeviceId] [int] IDENTITY(1,1) NOT NULL,
	[LocationId] [int] NOT NULL,
	[UniqueIdentifier] [varchar](48) NOT NULL,			-- increase size by 8
	[AuthenticationToken] [binary] (64) NULL,			-- change to binary; will store hashed value
	[UidQualifier] [int] NOT NULL,
	[DeviceState] [smallint] NOT NULL,
	[SerialNumber] [varchar](40) NOT NULL,
	[DateIssued] [datetime] NOT NULL,
	[RevisionLevel] [varchar](5) NOT NULL,
	[ScansAvailable] [int] NOT NULL,
	[ScansCompleted] [int] NOT NULL,
	[CurrentStatus] [varchar](50) NOT NULL,
	[LastReportTime] [datetime] NULL,
	[IsDeleted] [tinyint] NOT NULL,
 CONSTRAINT [PK_Device] PRIMARY KEY CLUSTERED 
(
	[DeviceId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
SET ANSI_PADDING OFF

-- Create function for generating UidQualifier values.
EXEC('
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
		SET @Qualifier = ABS(CAST(crypt_gen_random(4) as int)) % 0x1000000
	END

	-- Return the qualifier.
	RETURN @Qualifier

END
')

-- Add default constraints.
ALTER TABLE [dbo].[Device] ADD CONSTRAINT [DF_Device_IsDeleted] DEFAULT ((0)) FOR [IsDeleted]
ALTER TABLE [dbo].[Device] ADD CONSTRAINT [DF_Device_ScansAvailable] DEFAULT ((0)) FOR [ScansAvailable]
ALTER TABLE [dbo].[Device] ADD CONSTRAINT [DF_Device_ScansCompleted] DEFAULT ((0)) FOR [ScansCompleted]
ALTER TABLE [dbo].[Device] ADD CONSTRAINT [DF_Device_CurrentStatus] DEFAULT ('') FOR [CurrentStatus]
ALTER TABLE [dbo].[Device] ADD CONSTRAINT [DF_Device_DeviceState] DEFAULT ((1)) FOR [DeviceState]
ALTER TABLE [dbo].[Device] ADD CONSTRAINT [DF_Device_UidQualifier] DEFAULT ([dbo].[GetUidQualifier]()) FOR [UidQualifier]

-- Copy.
SET IDENTITY_INSERT [dbo].[Device] ON

INSERT INTO [dbo].[Device] (DeviceId, LocationId, UniqueIdentifier, DeviceState, SerialNumber,
							DateIssued, RevisionLevel, ScansAvailable, ScansCompleted, CurrentStatus, LastReportTime, IsDeleted)
SELECT DeviceId,
	   LocationId,
	   '000030-' + LOWER([UniqueIdentifier]),		-- adding new prefix for devices
	   CASE WHEN IsActive = 1 THEN 2 ELSE 4 END,	-- when "active" set to new Active state (1), else Locked state (4)
	   SerialNumber,
	   DateIssued,
	   RevisionLevel,
	   ScansAvailable,
	   ScansCompleted,
	   CurrentStatus,
	   LastReportTime,
	   IsDeleted
FROM [dbo].[Old_Device]

SET IDENTITY_INSERT [dbo].[Device] OFF

-- Populate the new tracking table.
-- NOTE: FOR SOME REASON THIS COMMENTED OUT STATEMENT DOESN'T WORK!
--INSERT INTO [dbo].[DeviceStateTracking] ( [DeviceId], [CurrentState], [ChangeReason] )
--SELECT [DeviceId], [DeviceState], 'Initialized by SQL script while updating schema'
--FROM [dbo].[Device]
INSERT INTO [dbo].[DeviceStateTracking] ( [DeviceId], [CurrentState], [ChangeReason] )
SELECT [DeviceId], CASE WHEN IsActive = 1 THEN 2 ELSE 4 END, 'Initialized by SQL script while updating schema'
FROM [dbo].[Old_Device]

-- Drop old table.
DROP TABLE [dbo].[Old_Device]

-- Foreign keys on Device.
ALTER TABLE [dbo].[Device]  WITH CHECK ADD  CONSTRAINT [FK_Device_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([LocationId])
ALTER TABLE [dbo].[Device] CHECK CONSTRAINT [FK_Device_Location]

-- Foreign keys referencing Device table.
ALTER TABLE [dbo].[ExceptionLog]  WITH CHECK ADD  CONSTRAINT [FK_ExceptionLog_Device] FOREIGN KEY([DeviceId])
REFERENCES [dbo].[Device] ([DeviceId])
ALTER TABLE [dbo].[ExceptionLog] CHECK CONSTRAINT [FK_ExceptionLog_Device]

ALTER TABLE [dbo].[DeviceMessage]  WITH CHECK ADD  CONSTRAINT [FK_DeviceMessage_Device] FOREIGN KEY([DeviceId])
REFERENCES [dbo].[Device] ([DeviceId])
ALTER TABLE [dbo].[DeviceMessage] CHECK CONSTRAINT [FK_DeviceMessage_Device]

ALTER TABLE [dbo].[PurchaseHistory]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseHistory_Device] FOREIGN KEY([DeviceId])
REFERENCES [dbo].[Device] ([DeviceId])
ALTER TABLE [dbo].[PurchaseHistory] CHECK CONSTRAINT [FK_PurchaseHistory_Device]

ALTER TABLE [dbo].[ScanHistory]  WITH CHECK ADD  CONSTRAINT [FK_ScanHistory_Device] FOREIGN KEY([DeviceId])
REFERENCES [dbo].[Device] ([DeviceId])
ALTER TABLE [dbo].[ScanHistory] CHECK CONSTRAINT [FK_ScanHistory_Device]

-- Foreign keys on DeviceEvent.
ALTER TABLE [dbo].[DeviceEvent] WITH CHECK ADD  CONSTRAINT [FK_DeviceEvent_Device] FOREIGN KEY([DeviceId])
REFERENCES [dbo].[Device] ([DeviceId])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[DeviceEvent] CHECK CONSTRAINT [FK_DeviceEvent_Device]

-- Foreign keys on Calibration.
ALTER TABLE [dbo].[Calibration] WITH CHECK ADD CONSTRAINT [FK_Calibration_Device] FOREIGN KEY([DeviceId])
REFERENCES [dbo].[Device] ([DeviceId])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[Calibration] CHECK CONSTRAINT [FK_Calibration_Device]

-- Foreign keys on DeviceStateTracking.
ALTER TABLE [dbo].[DeviceStateTracking] WITH CHECK ADD CONSTRAINT [FK_DeviceStateTracking_Device] FOREIGN KEY([DeviceId])
REFERENCES [dbo].[Device] ([DeviceId])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[DeviceStateTracking] CHECK CONSTRAINT [FK_DeviceStateTracking_Device]

-- Indexes for Device.
CREATE UNIQUE NONCLUSTERED INDEX IDX_Device_UniqueIdentifier
ON [dbo].[Device] ( [UniqueIdentifier] ASC ) WITH ( FILLFACTOR = 80 )

CREATE NONCLUSTERED INDEX IDX_Device_LocationId
ON [dbo].[Device] ( [LocationId] ASC ) WITH ( FILLFACTOR = 80 )

CREATE NONCLUSTERED INDEX IDX_Device_DeviceState
ON [dbo].[Device] ( [DeviceState] ASC ) WITH ( FILLFACTOR = 80 )

-- Add the trigger back.
EXEC('
-- =============================================
-- Author:		Andrew Mason
-- Create date: 07/15/2011
-- Description: Trigger to toggle the update bit for
--				EPICOps system.
-- =============================================
CREATE TRIGGER [dbo].[DeviceSignalUpdateTrigger] 
   ON  [dbo].[Device] 
   AFTER INSERT, UPDATE
AS 
BEGIN
	SET NOCOUNT ON;
	DECLARE @LocationId as INT
	DECLARE @ActivityType as SMALLINT
	DECLARE @Activity as VARCHAR(50)

	IF UPDATE(LastReportTime)
	BEGIN
		SELECT @Activity = CurrentStatus FROM INSERTED
		IF @Activity = ''Ping''
		BEGIN
			SELECT @LocationId = LocationId FROM INSERTED
			SELECT @ActivityType = dbo.OpsActivityTypeDevicePing()

			exec OpsSignalUpdate @LocationId, @ActivityType
		END
	END
END
')


-- GUIDs in Organization, Location and Device are getting a prefix.
-- Device already fixed above.
PRINT 'Adding prefix to Organization and Location GUIDs ...'

ALTER TABLE [dbo].[Organization] ALTER COLUMN [UniqueIdentifier] [varchar](48) NOT NULL
ALTER TABLE [dbo].[Location] ALTER COLUMN [UniqueIdentifier] [varchar](48) NOT NULL

-- Add the prefixes.
UPDATE [dbo].[Organization]
SET [UniqueIdentifier] = '000010-' + LOWER([UniqueIdentifier])

UPDATE [dbo].[Location]
SET [UniqueIdentifier] = '000020-' + LOWER([UniqueIdentifier])

-- Removing the OrganizationType table in favor of an enum in the C# code.
PRINT 'Removing the OrganizationType table ...'

ALTER TABLE [dbo].[Organization] DROP CONSTRAINT [FK_Organization_OrganizationType]
DROP INDEX [IDX_Organization_OrganizationTypeId] ON [dbo].[Organization]

-- Rename the column.
EXEC sp_rename 'Organization.OrganizationTypeId', 'OrganizationType', 'COLUMN'

-- Recreate the index.
CREATE NONCLUSTERED INDEX [IDX_Organization_OrganizationType]
ON [dbo].[Organization] ( [OrganizationType] ASC ) WITH ( FILLFACTOR = 80 )

-- Finally, drop the OrganizationType table.
DROP TABLE [dbo].[OrganizationType]

-- Expand the UniqueIdentifier columns for IDs generated by ClearView.
PRINT 'Expanding UniqueIdentifier columns for Patient, Calibration, Treatment and ImageSet ...'
ALTER TABLE [dbo].[Patient] ALTER COLUMN [UniqueIdentifier] [varchar](48) NOT NULL
ALTER TABLE [dbo].[Calibration] ALTER COLUMN [UniqueIdentifier] [varchar](48) NOT NULL
ALTER TABLE [dbo].[Treatment] ALTER COLUMN [UniqueIdentifier] [varchar](48) NOT NULL
ALTER TABLE [dbo].[ImageSet] ALTER COLUMN [UniqueIdentifier] [varchar](48) NOT NULL


-- Update schema version.
UPDATE [dbo].[SchemaVersion]
SET [Version] = 7
WHERE [Version] = 6

PRINT 'Schema version is now 7.'

END -- End of processing for upgrading from Version 6 to Version 7.
GO

DECLARE @CurrentVersion smallint

-- Check for current schema version = 7
SELECT TOP 1 @CurrentVersion = [Version]
FROM [dbo].[SchemaVersion]

IF @CurrentVersion = 7
BEGIN

PRINT 'Schema version is 7. Upgrading to version 8 ...'

-- Allow null finger image sets.
ALTER TABLE [dbo].[Treatment] ALTER COLUMN [FingerImageSetId] [bigint] NULL

-- Update schema version.
UPDATE [dbo].[SchemaVersion]
SET [Version] = 8
WHERE [Version] = 7

PRINT 'Schema version is now 8.'

END -- End of processing for upgrading from Version 7 to Version 8.
GO

DECLARE @CurrentVersion smallint

-- Check for current schema version = 8
SELECT TOP 1 @CurrentVersion = [Version]
FROM [dbo].[SchemaVersion]

IF @CurrentVersion = 8
BEGIN

PRINT 'Schema version is 8. Upgrading to version 9 ...'

-- Rename these columns.
EXEC sp_rename 'NBAnalysisResult.OddsRatioFiltered', 'ProbabilityFiltered', 'COLUMN'
EXEC sp_rename 'NBAnalysisResult.OddsRatioUnfiltered', 'ProbabilityUnfiltered', 'COLUMN'

-- Update schema version.
UPDATE [dbo].[SchemaVersion]
SET [Version] = 9
WHERE [Version] = 8

PRINT 'Schema version is now 9.'

END -- End of processing for upgrading from Version 8 to Version 9.
GO

DECLARE @CurrentVersion smallint

-- Check for current schema version = 9
SELECT TOP 1 @CurrentVersion = [Version]
FROM [dbo].[SchemaVersion]

IF @CurrentVersion = 9
BEGIN

PRINT 'Schema version is 9. Upgrading to version 10 ...'

-- New OrganSystem table.
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
CREATE TABLE [dbo].[OrganSystem](
	[OrganSystemId] [smallint] NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_OrganSystem] PRIMARY KEY CLUSTERED 
(
	[OrganSystemId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
SET ANSI_PADDING OFF

-- New LicenseOrganSystem table.
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
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

ALTER TABLE [dbo].[LicenseOrganSystem] ADD CONSTRAINT [DF_LicenseOrganSystem_LicenseMode] DEFAULT ((1)) FOR [LicenseMode]

ALTER TABLE [dbo].[LicenseOrganSystem]  WITH CHECK ADD  CONSTRAINT [FK_LicenseOrganSystem_OrganSystem] FOREIGN KEY([OrganSystemId])
REFERENCES [dbo].[OrganSystem] ([OrganSystemId])

ALTER TABLE [dbo].[LicenseOrganSystem] CHECK CONSTRAINT [FK_LicenseOrganSystem_OrganSystem]

-- New OrganSystemOrgan table.
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
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

ALTER TABLE [dbo].[OrganSystemOrgan]  WITH CHECK ADD  CONSTRAINT [FK_OrganSystemOrgan_LicenseOrganSystem] FOREIGN KEY([LicenseOrganSystemId])
REFERENCES [dbo].[LicenseOrganSystem] ([LicenseOrganSystemId])

ALTER TABLE [dbo].[OrganSystemOrgan] CHECK CONSTRAINT [FK_OrganSystemOrgan_LicenseOrganSystem]

ALTER TABLE [dbo].[OrganSystemOrgan]  WITH CHECK ADD  CONSTRAINT [FK_OrganSystemOrgan_Organ] FOREIGN KEY([OrganId])
REFERENCES [dbo].[Organ] ([OrganId])

ALTER TABLE [dbo].[OrganSystemOrgan] CHECK CONSTRAINT [FK_OrganSystemOrgan_Organ]

-- Populate OrganSystem table.
INSERT [dbo].[OrganSystem] ([OrganSystemId], [Description]) VALUES (1, N'Gastrointestinal & Endocrine Systems')
INSERT [dbo].[OrganSystem] ([OrganSystemId], [Description]) VALUES (2, N'Hepatic System')
INSERT [dbo].[OrganSystem] ([OrganSystemId], [Description]) VALUES (3, N'Sensory & Skeletal Systems')
INSERT [dbo].[OrganSystem] ([OrganSystemId], [Description]) VALUES (4, N'Cardiovascular System')
INSERT [dbo].[OrganSystem] ([OrganSystemId], [Description]) VALUES (5, N'Respiratory System')
INSERT [dbo].[OrganSystem] ([OrganSystemId], [Description]) VALUES (6, N'Renal & Reproductive Systems')

-- Populate the LicenseOrganSystem table.
INSERT [dbo].[LicenseOrganSystem] ([LicenseMode], [OrganSystemId], [ReportOrder]) VALUES (1, 1, 3) -- 1,3
INSERT [dbo].[LicenseOrganSystem] ([LicenseMode], [OrganSystemId], [ReportOrder]) VALUES (1, 2, 4) -- 1,7
INSERT [dbo].[LicenseOrganSystem] ([LicenseMode], [OrganSystemId], [ReportOrder]) VALUES (1, 4, 1) -- 1,1
INSERT [dbo].[LicenseOrganSystem] ([LicenseMode], [OrganSystemId], [ReportOrder]) VALUES (1, 5, 2) -- 1,2
INSERT [dbo].[LicenseOrganSystem] ([LicenseMode], [OrganSystemId], [ReportOrder]) VALUES (1, 6, 5) -- 1,6
INSERT [dbo].[LicenseOrganSystem] ([LicenseMode], [OrganSystemId], [ReportOrder]) VALUES (2, 1, 4) -- 2,4
INSERT [dbo].[LicenseOrganSystem] ([LicenseMode], [OrganSystemId], [ReportOrder]) VALUES (2, 2, 5) -- 2,5
INSERT [dbo].[LicenseOrganSystem] ([LicenseMode], [OrganSystemId], [ReportOrder]) VALUES (2, 3, 1) -- 2,8
INSERT [dbo].[LicenseOrganSystem] ([LicenseMode], [OrganSystemId], [ReportOrder]) VALUES (2, 4, 2) -- 2,9
INSERT [dbo].[LicenseOrganSystem] ([LicenseMode], [OrganSystemId], [ReportOrder]) VALUES (2, 5, 3) -- 2,10
INSERT [dbo].[LicenseOrganSystem] ([LicenseMode], [OrganSystemId], [ReportOrder]) VALUES (2, 6, 6) -- 2,12

-- Populate the OrganSystemOrgan table.
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (2, 1, 9)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (3, 1, 7)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (4, 1, 10)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (5, 1, 11)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (6, 1, 4)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (7, 1, 6)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (8, 1, 5)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (10, 1, 2)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (11, 1, 1)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (12, 1, 3)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (19, 4, 9)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (20, 1, 8)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (23, 4, 4)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (24, 4, 3)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (26, 4, 6)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (27, 4, 5)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (30, 3, 1)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (30, 4, 0)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (31, 2, 4)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (33, 3, 6)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (35, 5, 4)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (36, 5, 4)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (38, 2, 6)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (39, 4, 2)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (41, 2, 8)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (42, 2, 9)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (43, 2, 7)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (45, 5, 5)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (47, 2, 3)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (48, 2, 9)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (49, 2, 10)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (51, 3, 5)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (54, 4, 1)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (56, 4, 2)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (65, 2, 4)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (67, 3, 1)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (67, 4, 0)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (70, 3, 3)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (78, 3, 2)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (79, 3, 2)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (96, 5, 1)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (97, 5, 1)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (100, 5, 2)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (101, 5, 3)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (106, 2, 1)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (108, 2, 1)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (120, 2, 2)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (122, 1, 8)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (142, 4, 9)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (144, 3, 7)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (145, 3, 7)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (146, 1, 12)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (147, 1, 12)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (148, 5, 6)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (149, 5, 6)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (150, 5, 7)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (151, 5, 7)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (152, 5, 5)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (155, 3, 6)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (159, 2, 6)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (161, 3, 4)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (162, 2, 7)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (169, 2, 3)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (172, 2, 5)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (173, 2, 5)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (174, 4, 1)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (196, 2, 12)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (197, 2, 12)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (198, 2, 10)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (200, 2, 11)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (201, 2, 11)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (202, 2, 8)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (204, 4, 7)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (205, 4, 7)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (206, 4, 8)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (207, 4, 8)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (208, 4, 3)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (209, 4, 4)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (210, 4, 5)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (211, 4, 6)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (2, 6, 9)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (3, 6, 7)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (4, 6, 10)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (5, 6, 11)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (6, 6, 4)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (7, 6, 6)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (8, 6, 5)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (10, 6, 2)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (11, 6, 1)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (12, 6, 3)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (19, 8, 7)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (20, 6, 8)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (23, 8, 4)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (24, 8, 3)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (26, 8, 6)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (27, 8, 5)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (30, 9, 1)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (30, 10, 1)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (31, 7, 5)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (33, 9, 6)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (35, 11, 5)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (36, 11, 5)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (38, 7, 8)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (39, 10, 3)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (41, 7, 2)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (42, 7, 3)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (43, 7, 1)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (45, 11, 4)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (47, 7, 10)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (48, 7, 3)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (49, 7, 4)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (51, 9, 5)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (54, 10, 2)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (56, 10, 3)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (65, 7, 5)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (67, 9, 1)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (67, 10, 1)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (70, 9, 3)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (78, 9, 2)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (79, 9, 2)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (96, 11, 3)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (97, 11, 3)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (100, 11, 1)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (101, 11, 2)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (106, 7, 11)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (108, 7, 11)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (120, 7, 12)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (122, 6, 8)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (142, 8, 7)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (144, 8, 8)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (145, 8, 8)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (146, 8, 9)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (147, 8, 9)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (148, 8, 10)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (149, 8, 10)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (150, 8, 11)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (151, 8, 11)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (152, 11, 4)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (155, 9, 6)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (159, 7, 8)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (161, 9, 4)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (162, 7, 1)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (169, 7, 10)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (172, 7, 9)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (173, 7, 9)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (174, 10, 2)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (196, 7, 7)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (197, 7, 7)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (198, 7, 4)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (200, 7, 6)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (201, 7, 6)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (202, 7, 2)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (204, 8, 1)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (205, 8, 1)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (206, 8, 2)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (207, 8, 2)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (208, 8, 3)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (209, 8, 4)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (210, 8, 5)
INSERT [dbo].[OrganSystemOrgan] ([OrganId], [LicenseOrganSystemId], [ReportOrder]) VALUES (211, 8, 6)


-- Update schema version.
UPDATE [dbo].[SchemaVersion]
SET [Version] = 10
WHERE [Version] = 9

PRINT 'Schema version is now 10.'

END -- End of processing for upgrading from Version 9 to Version 10.
GO

DECLARE @CurrentVersion smallint

-- Check for current schema version = 10
SELECT TOP 1 @CurrentVersion = [Version]
FROM [dbo].[SchemaVersion]

IF @CurrentVersion = 10
BEGIN

PRINT 'Schema version is 10. Upgrading to version 11 ...'

-- New table.
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON

CREATE TABLE [dbo].[CalculationDebugData](
      [CalculationDebugDataId] [bigint] IDENTITY(1,1) NOT NULL,
      [TreatmentId] [bigint] NOT NULL,
      [FingerSector] [varchar](20) NOT NULL,
      [IsFiltered] [bit] NOT NULL,
      [OrganComponent] [varchar](40) NOT NULL,
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

SET ANSI_PADDING OFF

ALTER TABLE [dbo].[CalculationDebugData] ADD  DEFAULT ((0)) FOR [Form2Prime]

ALTER TABLE [dbo].[CalculationDebugData]  WITH CHECK ADD  CONSTRAINT [FK_CalculationDebugData_Treatment] FOREIGN KEY([TreatmentId])
REFERENCES [dbo].[Treatment] ([TreatmentId])

ALTER TABLE [dbo].[CalculationDebugData] CHECK CONSTRAINT [FK_CalculationDebugData_Treatment]

PRINT 'Dropping Organ table ...'

-- Drop foreign key references.
ALTER TABLE [dbo].[Severity] DROP CONSTRAINT [FK_Severity_Organ]
ALTER TABLE [dbo].[OrganSystemOrgan] DROP CONSTRAINT [FK_OrganSystemOrgan_Organ]

-- Drop the table.
DROP TABLE [dbo].[Organ]

PRINT 'Recreating Organ table ...'

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
CREATE TABLE [dbo].[Organ](
	[OrganId] [smallint] NOT NULL,
	[EPICOrganId] [smallint] NOT NULL,
	[Description] [varchar](128) NOT NULL,
	[RComp] [varchar](10) NULL,
	[LComp] [varchar](10) NULL,
	[IsDeleted] [tinyint] NOT NULL,
 CONSTRAINT [PK_Organ] PRIMARY KEY CLUSTERED 
(
	[OrganId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
SET ANSI_PADDING OFF

-- Set default values.
ALTER TABLE [dbo].[Organ] ADD CONSTRAINT [DF_Organ_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]

PRINT 'Repopulating the Organ table ...'

INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (2,17,'Descending Colon');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (3,16,'Ascending Colon');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (4,18,'Sigmoid Colon');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (5,20,'Rectum');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (6,23,'Blind Gut');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (7,27,'Appendix');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (8,22,'Abdominal Region');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (10,26,'Jejunum');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (11,24,'Duodenum');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (12,25,'Ileum');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (19,65,'Cervical Spine - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (20,19,'Transverse Colon - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (23,13,'Ear/Nose/Sinus (R) - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (24,10,'Ear/Nose/Sinus (L) - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (26,68,'Jaw/Teeth (R) - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (27,60,'Jaw/Teeth (L) - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (30,9,'Cervical Vascular System - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (31,56,'Thyroid - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (33,6,'Cardiovascular Circulation (whole body) - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (35,38,'Urokidney - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (36,39,'Urokidney - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (38,30,'Immune System - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (39,12,'Thorax Respiratory - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (41,43,'Hypothalamus - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (42,55,'Pituitary - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (43,70,'Nervous System - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (45,34,'Genitourinary System - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (47,45,'Pancreas - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (48,47,'Pituitary - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (49,54,'Pineal - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (51,8,'Heart (right side)');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (54,11,'Respiratory/Mammary - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (56,15,'Thorax Respiratory - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (65,48,'Thyroid - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (67,5,'Cervical Vascular System - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (70,1,'Heart (muscles)');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (78,3,'Coronary Vessels - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (79,7,'Coronary Vessels - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (96,32,'Adrenal - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (97,35,'Adrenal - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (100,33,'Kidney (L)');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (101,36,'Kidney (R)');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (106,52,'Liver - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (108,44,'Liver - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (120,40,'Gallbladder');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (122,21,'Transverse Colon - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (142,57,'Cervical Spine - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (144,64,'Thoracic Spine - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (145,72,'Thoracic Spine - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (146,61,'Lumbar Spine - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (147,69,'Lumbar Spine - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (148,63,'Sacrum - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (149,71,'Sacrum - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (150,58,'Coccyx/Pelvis - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (151,66,'Coccyx/Pelvis - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (152,37,'Genitourinary System - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (155,2,'Cardiovascular Circulation (whole body) - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (159,28,'Immune System - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (161,4,'Heart (left side)');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (162,62,'Nervous System - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (169,53,'Pancreas - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (172,29,'Spleen - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (173,31,'Spleen - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (174,14,'Respiratory/Mammary - Right ');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (196,42,'Cerebral Vessels - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (197,50,'Cerebral Vessels - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (198,46,'Pineal - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (200,41,'Cerebral Cortex - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (201,49,'Cerebral Cortex - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (202,51,'Hypothalamus - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (204,59,'Eye (L) - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (205,77,'Eye (L) - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (206,67,'Eye (R) - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (207,78,'Eye (R) - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (208,74,'Ear/Nose/Sinus (L) - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (209,73,'Ear/Nose/Sinus (R) - Left');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (210,75,'Jaw/Teeth (L) - Right');
INSERT INTO [dbo].[Organ] ( [OrganId], [EPICOrganId], [Description] ) VALUES (211,76,'Jaw/Teeth (R) - Left');

-- Additional index for Organ.
CREATE UNIQUE NONCLUSTERED INDEX IDX_Organ_EPICOrganId
ON [dbo].[Organ] ( [EPICOrganId] ASC ) WITH ( FILLFACTOR = 80 )

-- Recreate foreign keys.
ALTER TABLE [dbo].[Severity] WITH CHECK ADD CONSTRAINT [FK_Severity_Organ] FOREIGN KEY([OrganId])
REFERENCES [dbo].[Organ] ([OrganId])

ALTER TABLE [dbo].[Severity] CHECK CONSTRAINT [FK_Severity_Organ]

ALTER TABLE [dbo].[OrganSystemOrgan]  WITH CHECK ADD  CONSTRAINT [FK_OrganSystemOrgan_Organ] FOREIGN KEY([OrganId])
REFERENCES [dbo].[Organ] ([OrganId])

ALTER TABLE [dbo].[OrganSystemOrgan] CHECK CONSTRAINT [FK_OrganSystemOrgan_Organ]

-- Set the RComp and LComp values.
UPDATE Organ SET RComp=NULL, LComp='1L-1' WHERE OrganId = 2;
UPDATE Organ SET RComp='2R-8', LComp=NULL WHERE OrganId = 3;
UPDATE Organ SET RComp=NULL, LComp='2L-2' WHERE OrganId = 4;
UPDATE Organ SET RComp=NULL, LComp='2L-3' WHERE OrganId = 5;
UPDATE Organ SET RComp='2R-6', LComp=NULL WHERE OrganId = 6;
UPDATE Organ SET RComp='2R-7', LComp=NULL WHERE OrganId = 7;
UPDATE Organ SET RComp=NULL, LComp='3L-4' WHERE OrganId = 8;
UPDATE Organ SET RComp=NULL, LComp='5L-4' WHERE OrganId = 10;
UPDATE Organ SET RComp='5R-1', LComp=NULL WHERE OrganId = 11;
UPDATE Organ SET RComp='5R-2', LComp=NULL WHERE OrganId = 12;
UPDATE Organ SET RComp='2R-1', LComp='2L-8' WHERE OrganId = 19;
UPDATE Organ SET RComp='2R-9', LComp='2L-9' WHERE OrganId = 20;
UPDATE Organ SET RComp='1R-2', LComp='1L-2' WHERE OrganId = 23;
UPDATE Organ SET RComp='1R-6', LComp='1L-6' WHERE OrganId = 24;
UPDATE Organ SET RComp='1R-3', LComp='1L-3' WHERE OrganId = 26;
UPDATE Organ SET RComp='1R-5', LComp='1L-5' WHERE OrganId = 27;
UPDATE Organ SET RComp='1R-4', LComp='1L-4' WHERE OrganId = 30; 
UPDATE Organ SET RComp='4R-2', LComp='4L-7' WHERE OrganId = 31;
UPDATE Organ SET RComp='3R-6', LComp='3L-1' WHERE OrganId = 33;
UPDATE Organ SET RComp='5R-4', LComp='5L-2' WHERE OrganId = 35;
UPDATE Organ SET RComp='5R-4', LComp='5L-2' WHERE OrganId = 36;
UPDATE Organ SET RComp='3R-2', LComp='3L-5' WHERE OrganId = 38;
UPDATE Organ SET RComp='3R-1', LComp='3L-6' WHERE OrganId = 39;
UPDATE Organ SET RComp='4R-8', LComp='4L-1' WHERE OrganId = 41;
UPDATE Organ SET RComp='4R-1', LComp='4L-8' WHERE OrganId = 42;
UPDATE Organ SET RComp='4R-7', LComp='4L-2' WHERE OrganId = 43;
UPDATE Organ SET RComp='4R-5', LComp='4L-4' WHERE OrganId = 45;
UPDATE Organ SET RComp='4R-3', LComp='4L-6' WHERE OrganId = 47;
UPDATE Organ SET RComp='4R-1', LComp='4L-8' WHERE OrganId = 48;
UPDATE Organ SET RComp='4R-9', LComp='4L-9' WHERE OrganId = 49;
UPDATE Organ SET RComp=NULL, LComp='5L-5' WHERE OrganId = 51;
UPDATE Organ SET RComp='5R-3', LComp='5L-3' WHERE OrganId = 54;
UPDATE Organ SET RComp='3R-1', LComp='3L-6' WHERE OrganId = 56;
UPDATE Organ SET RComp='4R-2', LComp='4L-7' WHERE OrganId = 65;
UPDATE Organ SET RComp='4R-2', LComp='4L-7' WHERE OrganId = 65;
UPDATE Organ SET RComp='1R-4', LComp='1L-4' WHERE OrganId = 67; 
UPDATE Organ SET RComp='5R-5', LComp=NULL WHERE OrganId = 70;
UPDATE Organ SET RComp='5R-6', LComp='5L-6' WHERE OrganId = 78;
UPDATE Organ SET RComp='5R-6', LComp='5L-6' WHERE OrganId = 79;
UPDATE Organ SET RComp='4R-4', LComp='4L-5' WHERE OrganId = 96;
UPDATE Organ SET RComp='4R-4', LComp='4L-5' WHERE OrganId = 97;
UPDATE Organ SET RComp='3R-5', LComp='3L-2' WHERE OrganId = 100;
UPDATE Organ SET RComp='3R-5', LComp='3L-2' WHERE OrganId = 101;
UPDATE Organ SET RComp='3R-4', LComp='3L-3' WHERE OrganId = 106;
UPDATE Organ SET RComp='3R-4', LComp='3L-3' WHERE OrganId = 108;
UPDATE Organ SET RComp='3R-3', LComp=NULL WHERE OrganId = 120;
UPDATE Organ SET RComp='2R-9', LComp='2L-9' WHERE OrganId = 122;
UPDATE Organ SET RComp='2R-1', LComp='2L-8' WHERE OrganId = 142;
UPDATE Organ SET RComp='2R-2', LComp='2L-7' WHERE OrganId = 144;
UPDATE Organ SET RComp='2R-2', LComp='2L-7' WHERE OrganId = 145;
UPDATE Organ SET RComp='2R-3', LComp='2L-6' WHERE OrganId = 146;
UPDATE Organ SET RComp='2R-3', LComp='2L-6' WHERE OrganId = 147;
UPDATE Organ SET RComp='2R-4', LComp='2L-5' WHERE OrganId = 148;
UPDATE Organ SET RComp='2R-4', LComp='2L-5' WHERE OrganId = 149;
UPDATE Organ SET RComp='2R-5', LComp='2L-4' WHERE OrganId = 150;
UPDATE Organ SET RComp='2R-5', LComp='2L-4' WHERE OrganId = 151;
UPDATE Organ SET RComp='4R-5', LComp='4L-4' WHERE OrganId = 152;
UPDATE Organ SET RComp='3R-6', LComp='3L-1' WHERE OrganId = 155;
UPDATE Organ SET RComp='3R-2', LComp='3L-5' WHERE OrganId = 159;
UPDATE Organ SET RComp=NULL, LComp='5L-1' WHERE OrganId = 161;
UPDATE Organ SET RComp='4R-7', LComp='4L-2' WHERE OrganId = 162;
UPDATE Organ SET RComp='4R-3', LComp='4L-6' WHERE OrganId = 169;
UPDATE Organ SET RComp='4R-6', LComp='4L-3' WHERE OrganId = 172;
UPDATE Organ SET RComp='4R-6', LComp='4L-3' WHERE OrganId = 173;
UPDATE Organ SET RComp='5R-3', LComp='5L-3' WHERE OrganId = 174;
UPDATE Organ SET RComp='3R-7', LComp='3L-7' WHERE OrganId = 196;
UPDATE Organ SET RComp='3R-7', LComp='3L-7' WHERE OrganId = 197;
UPDATE Organ SET RComp='4R-9', LComp='4L-9' WHERE OrganId = 198;
UPDATE Organ SET RComp='1R-8', LComp='1L-8' WHERE OrganId = 200;
UPDATE Organ SET RComp='1R-8', LComp='1L-8' WHERE OrganId = 201;
UPDATE Organ SET RComp='4R-8', LComp='4L-1' WHERE OrganId = 202;
UPDATE Organ SET RComp='1R-7', LComp='1L-7' WHERE OrganId = 204;
UPDATE Organ SET RComp='1R-7', LComp='1L-7' WHERE OrganId = 205;
UPDATE Organ SET RComp='1R-1', LComp='1L-1' WHERE OrganId = 206;
UPDATE Organ SET RComp='1R-1', LComp='1L-1' WHERE OrganId = 207;
UPDATE Organ SET RComp='1R-6', LComp='1L-6' WHERE OrganId = 208;
UPDATE Organ SET RComp='1R-2', LComp='1L-2' WHERE OrganId = 209;
UPDATE Organ SET RComp='1R-5', LComp='1L-5' WHERE OrganId = 210;
UPDATE Organ SET RComp='1R-3', LComp='1L-3' WHERE OrganId = 211;


-- Update schema version.
UPDATE [dbo].[SchemaVersion]
SET [Version] = 11
WHERE [Version] = 10

PRINT 'Schema version is now 11.'

END -- End of processing for upgrading from Version 10 to Version 11.
GO

DECLARE @CurrentVersion smallint

-- Check for current schema version = 11
SELECT TOP 1 @CurrentVersion = [Version]
FROM [dbo].[SchemaVersion]

IF @CurrentVersion = 11
BEGIN

PRINT 'Schema version is 11. Upgrading to version 12 ...'

-- Analysis of business requirements indicates we don't want to actually
-- delete historical data. Plus, we want it available on an ongoing basis.
-- So archiving isn't something we actually want to do.
--
-- Getting rid of the "soft delete" support built into the schema. Some
-- items will become "inactive", while other won't even do that.

-- Rename these flag columns.
PRINT 'Renaming IsDeleted columns to IsActive on some tables ...'

-- Must first drop default constraints first.
ALTER TABLE [dbo].[Organization] DROP CONSTRAINT [DF_Organization_IsDeleted]
ALTER TABLE [dbo].[Location] DROP CONSTRAINT [DF_Location_IsDeleted]
ALTER TABLE [dbo].[User] DROP CONSTRAINT [DF_User_IsDeleted]
ALTER TABLE [dbo].[Message] DROP CONSTRAINT [DF_Message_IsDeleted]
ALTER TABLE [dbo].[ScanRate] DROP CONSTRAINT [DF_ScanRate_IsDeleted]
ALTER TABLE [dbo].[SupportArea] DROP CONSTRAINT [DF_SupportArea_IsDeleted]
ALTER TABLE [dbo].[SupportIssue] DROP CONSTRAINT [DF_SupportIssue_IsDeleted]
-- Now rename.
EXEC sp_rename 'Organization.IsDeleted', 'IsActive', 'COLUMN'
EXEC sp_rename 'Location.IsDeleted', 'IsActive', 'COLUMN'
EXEC sp_rename 'User.IsDeleted', 'IsActive', 'COLUMN'
EXEC sp_rename 'Message.IsDeleted', 'IsActive', 'COLUMN'
EXEC sp_rename 'ScanRate.IsDeleted', 'IsActive', 'COLUMN'
EXEC sp_rename 'SupportArea.IsDeleted', 'IsActive', 'COLUMN'
EXEC sp_rename 'SupportIssue.IsDeleted', 'IsActive', 'COLUMN'
-- Now add default constraints back.
ALTER TABLE [dbo].[Organization] ADD CONSTRAINT [DF_Organization_IsActive] DEFAULT ((1)) FOR [IsActive]
ALTER TABLE [dbo].[Location] ADD CONSTRAINT [DF_Location_IsActive] DEFAULT ((1)) FOR [IsActive]
ALTER TABLE [dbo].[User] ADD CONSTRAINT [DF_User_IsActive] DEFAULT ((1)) FOR [IsActive]
ALTER TABLE [dbo].[Message] ADD CONSTRAINT [DF_Message_IsActive] DEFAULT ((1)) FOR [IsActive]
ALTER TABLE [dbo].[ScanRate] ADD CONSTRAINT [DF_ScanRate_IsActive] DEFAULT ((1)) FOR [IsActive]
ALTER TABLE [dbo].[SupportArea] ADD CONSTRAINT [DF_SupportArea_IsActive] DEFAULT ((1)) FOR [IsActive]
ALTER TABLE [dbo].[SupportIssue] ADD CONSTRAINT [DF_SupportIssue_IsActive] DEFAULT ((1)) FOR [IsActive]
-- Boolean sense of the column change; need to swap values.
PRINT 'Reversing boolean values in IsActive columns ...'
EXEC('
UPDATE [dbo].[Organization]
SET [IsActive] = CASE [IsActive] WHEN 0 THEN 1 ELSE 0 END
UPDATE [dbo].[Location]
SET [IsActive] = CASE [IsActive] WHEN 0 THEN 1 ELSE 0 END
UPDATE [dbo].[User]
SET [IsActive] = CASE [IsActive] WHEN 0 THEN 1 ELSE 0 END
UPDATE [dbo].[Message]
SET [IsActive] = CASE [IsActive] WHEN 0 THEN 1 ELSE 0 END
UPDATE [dbo].[ScanRate]
SET [IsActive] = CASE [IsActive] WHEN 0 THEN 1 ELSE 0 END
UPDATE [dbo].[SupportArea]
SET [IsActive] = CASE [IsActive] WHEN 0 THEN 1 ELSE 0 END
UPDATE [dbo].[SupportIssue]
SET [IsActive] = CASE [IsActive] WHEN 0 THEN 1 ELSE 0 END
')

-- Drop these columns.
PRINT 'Dropping IsDeleted columns from some tables ...'
-- Must first drop default constraints first.
ALTER TABLE [dbo].[Role] DROP CONSTRAINT [DF_Role_IsDeleted]
ALTER TABLE [dbo].[UserSetting] DROP CONSTRAINT [DF_UserSetting_IsDeleted]
ALTER TABLE [dbo].[CreditCard] DROP CONSTRAINT [DF_CreditCard_IsDeleted]
ALTER TABLE [dbo].[Contact] DROP CONSTRAINT [DF_Contact_IsDeleted]
ALTER TABLE [dbo].[Device] DROP CONSTRAINT [DF_Device_IsDeleted]
ALTER TABLE [dbo].[DeviceEvent] DROP CONSTRAINT [DF_DeviceEvent_IsDeleted]
ALTER TABLE [dbo].[DeviceMessage] DROP CONSTRAINT [DF_DeviceMessage_IsDeleted]
ALTER TABLE [dbo].[ScanHistory] DROP CONSTRAINT [DF_ScanHistory_IsDeleted]
ALTER TABLE [dbo].[ExceptionLog] DROP CONSTRAINT [DF_ExceptionLog_IsDeleted]
ALTER TABLE [dbo].[Calibration] DROP CONSTRAINT [DF_Calibration_IsDeleted]
ALTER TABLE [dbo].[Treatment] DROP CONSTRAINT [DF_Treatment_IsDeleted]
ALTER TABLE [dbo].[Patient] DROP CONSTRAINT [DF_Patient_IsDeleted]
ALTER TABLE [dbo].[ImageSet] DROP CONSTRAINT [DF_ImageSet_IsDeleted]
ALTER TABLE [dbo].[NBAnalysisResult] DROP CONSTRAINT [DF_NBAnalysisResult_IsDeleted]
ALTER TABLE [dbo].[AnalysisResult] DROP CONSTRAINT [DF_AnalysisResult_IsDeleted]
ALTER TABLE [dbo].[Severity] DROP CONSTRAINT [DF_Severity_IsDeleted]
ALTER TABLE [dbo].[Organ] DROP CONSTRAINT [DF_Organ_IsDeleted]
ALTER TABLE [dbo].[PurchaseHistory] DROP CONSTRAINT [DF_PurchaseHistory_IsDeleted]
-- Now do drops.
ALTER TABLE [dbo].[Role] DROP COLUMN [IsDeleted]
ALTER TABLE [dbo].[UserSetting] DROP COLUMN [IsDeleted]
ALTER TABLE [dbo].[CreditCard] DROP COLUMN [IsDeleted]
ALTER TABLE [dbo].[Contact] DROP COLUMN [IsDeleted]
ALTER TABLE [dbo].[Device] DROP COLUMN [IsDeleted]
ALTER TABLE [dbo].[DeviceEvent] DROP COLUMN [IsDeleted]
ALTER TABLE [dbo].[DeviceMessage] DROP COLUMN [IsDeleted]
ALTER TABLE [dbo].[ScanHistory] DROP COLUMN [IsDeleted]
ALTER TABLE [dbo].[ExceptionLog] DROP COLUMN [IsDeleted]
ALTER TABLE [dbo].[Calibration] DROP COLUMN [IsDeleted]
ALTER TABLE [dbo].[Treatment] DROP COLUMN [IsDeleted]
ALTER TABLE [dbo].[Patient] DROP COLUMN [IsDeleted]
ALTER TABLE [dbo].[ImageSet] DROP COLUMN [IsDeleted]
ALTER TABLE [dbo].[NBAnalysisResult] DROP COLUMN [IsDeleted]
ALTER TABLE [dbo].[AnalysisResult] DROP COLUMN [IsDeleted]
ALTER TABLE [dbo].[Severity] DROP COLUMN [IsDeleted]
ALTER TABLE [dbo].[Organ] DROP COLUMN [IsDeleted]
ALTER TABLE [dbo].[PurchaseHistory] DROP COLUMN [IsDeleted]

-- Change these foreign keys.
PRINT 'Altering some foreign keys ...'
-- First drop all of them.
ALTER TABLE [dbo].[CalculationDebugData] DROP CONSTRAINT [FK_CalculationDebugData_Treatment]
ALTER TABLE [dbo].[Device] DROP CONSTRAINT [FK_Device_Location]
ALTER TABLE [dbo].[DeviceMessage] DROP CONSTRAINT [FK_DeviceMessage_Device]
ALTER TABLE [dbo].[DeviceMessage] DROP CONSTRAINT [FK_DeviceMessage_Message]
ALTER TABLE [dbo].[ExceptionLog] DROP CONSTRAINT [FK_ExceptionLog_Device]
ALTER TABLE [dbo].[LicenseOrganSystem] DROP CONSTRAINT [FK_LicenseOrganSystem_OrganSystem]
ALTER TABLE [dbo].[Location] DROP CONSTRAINT [FK_Location_Organization]
ALTER TABLE [dbo].[OrganSystemOrgan] DROP CONSTRAINT [FK_OrganSystemOrgan_Organ]
ALTER TABLE [dbo].[OrganSystemOrgan] DROP CONSTRAINT [FK_OrganSystemOrgan_LicenseOrganSystem]
ALTER TABLE [dbo].[ScanHistory] DROP CONSTRAINT [FK_ScanHistory_Device]
ALTER TABLE [dbo].[Severity] DROP CONSTRAINT [FK_Severity_Organ]
ALTER TABLE [dbo].[SupportIssue] DROP CONSTRAINT [FK_SupportIssue_SupportArea]
ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_User_Organization]
ALTER TABLE [dbo].[UserRole] DROP CONSTRAINT [FK_UserRole_Role]
ALTER TABLE [dbo].[PurchaseHistory] DROP CONSTRAINT [FK_PurchaseHistory_User]
ALTER TABLE [dbo].[PurchaseHistory] DROP CONSTRAINT [FK_PurchaseHistory_Location]
ALTER TABLE [dbo].[PurchaseHistory] DROP CONSTRAINT [FK_PurchaseHistory_Device]
ALTER TABLE [dbo].[UserAssignedLocation] DROP CONSTRAINT [FK_UserAssignedLocation_Location]
ALTER TABLE [dbo].[UserAssignedLocation] DROP CONSTRAINT [FK_UserAssignedLocation_User]
-- Then add them.
ALTER TABLE [dbo].[User] WITH CHECK ADD CONSTRAINT [FK_User_Organization] FOREIGN KEY([OrganizationId])
REFERENCES [dbo].[Organization] ([OrganizationId])
ON UPDATE CASCADE
ON DELETE CASCADE
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Organization]

ALTER TABLE [dbo].[UserRole] WITH CHECK ADD CONSTRAINT [FK_UserRole_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
ON UPDATE CASCADE
ON DELETE CASCADE
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_Role]

ALTER TABLE [dbo].[Location] WITH CHECK ADD CONSTRAINT [FK_Location_Organization] FOREIGN KEY([OrganizationId])
REFERENCES [dbo].[Organization] ([OrganizationId])
ON UPDATE CASCADE
ON DELETE CASCADE
ALTER TABLE [dbo].[Location] CHECK CONSTRAINT [FK_Location_Organization]

ALTER TABLE [dbo].[UserAssignedLocation] WITH CHECK ADD CONSTRAINT [FK_UserAssignedLocation_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([LocationId])
ON UPDATE CASCADE
ON DELETE CASCADE
ALTER TABLE [dbo].[UserAssignedLocation] CHECK CONSTRAINT [FK_UserAssignedLocation_Location]

ALTER TABLE [dbo].[UserAssignedLocation] WITH CHECK ADD CONSTRAINT [FK_UserAssignedLocation_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
ALTER TABLE [dbo].[UserAssignedLocation] CHECK CONSTRAINT [FK_UserAssignedLocation_User]

ALTER TABLE [dbo].[Device] WITH CHECK ADD CONSTRAINT [FK_Device_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([LocationId])
ON UPDATE CASCADE
ON DELETE CASCADE
ALTER TABLE [dbo].[Device] CHECK CONSTRAINT [FK_Device_Location]

ALTER TABLE [dbo].[DeviceMessage] WITH CHECK ADD CONSTRAINT [FK_DeviceMessage_Device] FOREIGN KEY([DeviceId])
REFERENCES [dbo].[Device] ([DeviceId])
ON UPDATE CASCADE
ON DELETE CASCADE
ALTER TABLE [dbo].[DeviceMessage] CHECK CONSTRAINT [FK_DeviceMessage_Device]

ALTER TABLE [dbo].[DeviceMessage] WITH CHECK ADD CONSTRAINT [FK_DeviceMessage_Message] FOREIGN KEY([MessageId])
REFERENCES [dbo].[Message] ([MessageId])
ON UPDATE CASCADE
ON DELETE CASCADE
ALTER TABLE [dbo].[DeviceMessage] CHECK CONSTRAINT [FK_DeviceMessage_Message]

ALTER TABLE [dbo].[ExceptionLog] WITH CHECK ADD CONSTRAINT [FK_ExceptionLog_Device] FOREIGN KEY([DeviceId])
REFERENCES [dbo].[Device] ([DeviceId])
ON UPDATE CASCADE
ON DELETE CASCADE
ALTER TABLE [dbo].[ExceptionLog] CHECK CONSTRAINT [FK_ExceptionLog_Device]

ALTER TABLE [dbo].[ScanHistory] WITH CHECK ADD CONSTRAINT [FK_ScanHistory_Device] FOREIGN KEY([DeviceId])
REFERENCES [dbo].[Device] ([DeviceId])
ON UPDATE CASCADE
ON DELETE CASCADE
ALTER TABLE [dbo].[ScanHistory] CHECK CONSTRAINT [FK_ScanHistory_Device]

ALTER TABLE [dbo].[CalculationDebugData] WITH CHECK ADD CONSTRAINT [FK_CalculationDebugData_Treatment] FOREIGN KEY([TreatmentId])
REFERENCES [dbo].[Treatment] ([TreatmentId])
ON UPDATE CASCADE
ON DELETE CASCADE
ALTER TABLE [dbo].[CalculationDebugData] CHECK CONSTRAINT [FK_CalculationDebugData_Treatment]

ALTER TABLE [dbo].[LicenseOrganSystem] WITH CHECK ADD CONSTRAINT [FK_LicenseOrganSystem_OrganSystem] FOREIGN KEY([OrganSystemId])
REFERENCES [dbo].[OrganSystem] ([OrganSystemId])
ON UPDATE CASCADE
ON DELETE CASCADE
ALTER TABLE [dbo].[LicenseOrganSystem] CHECK CONSTRAINT [FK_LicenseOrganSystem_OrganSystem]

ALTER TABLE [dbo].[OrganSystemOrgan] WITH CHECK ADD CONSTRAINT [FK_OrganSystemOrgan_Organ] FOREIGN KEY([OrganId])
REFERENCES [dbo].[Organ] ([OrganId])
ON UPDATE CASCADE
ON DELETE CASCADE
ALTER TABLE [dbo].[OrganSystemOrgan] CHECK CONSTRAINT [FK_OrganSystemOrgan_Organ]

ALTER TABLE [dbo].[OrganSystemOrgan] WITH CHECK ADD CONSTRAINT [FK_OrganSystemOrgan_LicenseOrganSystem] FOREIGN KEY([LicenseOrganSystemId])
REFERENCES [dbo].[LicenseOrganSystem] ([LicenseOrganSystemId])
ON UPDATE CASCADE
ON DELETE CASCADE
ALTER TABLE [dbo].[OrganSystemOrgan] CHECK CONSTRAINT [FK_OrganSystemOrgan_LicenseOrganSystem]

ALTER TABLE [dbo].[Severity] WITH CHECK ADD CONSTRAINT [FK_Severity_Organ] FOREIGN KEY([OrganId])
REFERENCES [dbo].[Organ] ([OrganId])
ON UPDATE CASCADE
ON DELETE CASCADE
ALTER TABLE [dbo].[Severity] CHECK CONSTRAINT [FK_Severity_Organ]

ALTER TABLE [dbo].[SupportIssue] WITH CHECK ADD CONSTRAINT [FK_SupportIssue_SupportArea] FOREIGN KEY([SupportAreaId])
REFERENCES [dbo].[SupportArea] ([SupportAreaId])
ON UPDATE CASCADE
ON DELETE CASCADE
ALTER TABLE [dbo].[SupportIssue] CHECK CONSTRAINT [FK_SupportIssue_SupportArea]

ALTER TABLE [dbo].[PurchaseHistory] WITH CHECK ADD CONSTRAINT [FK_PurchaseHistory_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
ALTER TABLE [dbo].[PurchaseHistory] CHECK CONSTRAINT [FK_PurchaseHistory_User]

ALTER TABLE [dbo].[PurchaseHistory] WITH CHECK ADD CONSTRAINT [FK_PurchaseHistory_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([LocationId])
ALTER TABLE [dbo].[PurchaseHistory] CHECK CONSTRAINT [FK_PurchaseHistory_Location]

ALTER TABLE [dbo].[PurchaseHistory] WITH CHECK ADD CONSTRAINT [FK_PurchaseHistory_Device] FOREIGN KEY([DeviceId])
REFERENCES [dbo].[Device] ([DeviceId])
ALTER TABLE [dbo].[PurchaseHistory] CHECK CONSTRAINT [FK_PurchaseHistory_Device]

-- Assign users to locations.
PRINT 'Assigning users to locations ...'

INSERT [dbo].[UserAssignedLocation] ([UserId], [LocationId])
SELECT [UserId], 0
FROM [dbo].[User]
WHERE [Username] = 'echost'

INSERT [dbo].[UserAssignedLocation] ([UserId], [LocationId])
SELECT [UserId], 1
FROM [dbo].[User]
WHERE [Username] <> 'echost'


-- Update schema version.
UPDATE [dbo].[SchemaVersion]
SET [Version] = 12
WHERE [Version] = 11

PRINT 'Schema version is now 12.'

END -- End of processing for upgrading from Version 11 to Version 12.
GO

DECLARE @CurrentVersion smallint

-- Check for current schema version = 11
SELECT TOP 1 @CurrentVersion = [Version]
FROM [dbo].[SchemaVersion]

IF @CurrentVersion = 12
BEGIN

PRINT 'Schema version is 12. Upgrading to version 13 ...'

-- Adding Location reference to Patient.
PRINT 'Adding LocationId to Patient table ...'

ALTER TABLE [dbo].[Patient]
ADD [LocationId] [int] NULL

-- Set LocationId before adding constraints.
EXEC('
UPDATE p
SET [LocationId] = d.[LocationId]
FROM [dbo].[Patient] p
JOIN [dbo].[Treatment] t ON t.[PatientId] = p.[PatientId]
JOIN [dbo].[Calibration] c ON c.[CalibrationId] = t.[CalibrationId]
JOIN [dbo].Device d ON d.[DeviceId] = c.[DeviceId]
')

-- If any are still NULL, set to default of 1.
EXEC('
UPDATE [dbo].[Patient]
SET [LocationId] = 1
WHERE [LocationId] IS NULL
')

ALTER TABLE [dbo].[Patient]
ALTER COLUMN [LocationId] [int] NOT NULL

ALTER TABLE [dbo].[Patient] WITH CHECK ADD CONSTRAINT [FK_Patient_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([LocationId])
ALTER TABLE [dbo].[Patient] CHECK CONSTRAINT [FK_Patient_Location]

-- Adding dates to Patient, Calibration and Treatment to track upload times.
PRINT 'Adding ReceivedTime to Patient, Calibration and Treatment ...'

ALTER TABLE [dbo].[Patient]
ADD [ReceivedTime] [datetime] NOT NULL
CONSTRAINT [DF_Patient_ReceivedTime] DEFAULT (getutcdate())

ALTER TABLE [dbo].[Calibration]
ADD [ReceivedTime] [datetime] NOT NULL
CONSTRAINT [DF_Calibration_ReceivedTime] DEFAULT (getutcdate())

ALTER TABLE [dbo].[Treatment]
ADD [ReceivedTime] [datetime] NOT NULL 
CONSTRAINT [DF_Treatment_ReceivedTime] DEFAULT (getutcdate())


-- Update schema version.
UPDATE [dbo].[SchemaVersion]
SET [Version] = 13
WHERE [Version] = 12

PRINT 'Schema version is now 13.'

END -- End of processing for upgrading from Version 12 to Version 13.
GO

DECLARE @CurrentVersion smallint

-- Check for current schema version = 13
SELECT TOP 1 @CurrentVersion = [Version]
FROM [dbo].[SchemaVersion]

IF @CurrentVersion = 13
BEGIN

PRINT 'Schema version is 13. Upgrading to version 14 ...'

-- Change precision of latitude and longitude.
ALTER TABLE [dbo].[Location]
ALTER COLUMN [Latitude] [numeric](18, 7) NULL

ALTER TABLE [dbo].[Location]
ALTER COLUMN [Longitude] [numeric](18, 7) NULL


-- Update schema version.
UPDATE [dbo].[SchemaVersion]
SET [Version] = 14
WHERE [Version] = 13

PRINT 'Schema version is now 14.'

END -- End of processing for upgrading from Version 13 to Version 14.
GO

DECLARE @CurrentVersion smallint

-- Check for current schema version = 14
SELECT TOP 1 @CurrentVersion = [Version]
FROM [dbo].[SchemaVersion]

IF @CurrentVersion = 14
BEGIN

PRINT 'Schema version is 14. Upgrading to version 15 ...'

-- Converting the OrganComponent column in CalculationDebugData table
-- to be an enum. It is currently a varchar holding the name of the
-- new enum. It will be converted to a smallint that is the value of
-- the enum.
--
-- First create a table variable which holds each enum value and
-- corresponding name.
DECLARE @OrganMap TABLE
(
	Id smallint IDENTITY(1,1),
	Name varchar(64)
)

-- Populate the table variable. These names are copied from the C#
-- enum definition.
INSERT INTO @OrganMap ( Name ) VALUES ( 'Heart' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'LeftCardiovascularSystem' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'LeftCoronaryVessels' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'LeftHeart' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'LeftThroatLarynxTracheaThyroid' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'RightCardiovascularSystem' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'RightCoronaryVessels' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'RightHeart' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'RightThroatLarynxTracheaThyroid' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'LeftLEarNoseMaxillarySinus' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'LeftRespiratoryMammary' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'LeftThoraxRespiratory' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'RightREarNoseMaxillarySinus' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'RightRespiratoryMammary' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'RightThoraxZoneRespiratory' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'ColonAscending' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'ColonDescending' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'ColonSigmoid' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'LeftColonTransverse' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'Rectum' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'RightColonTransverse' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'AbdominalZone' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'BlindGut' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'Duodenum' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'Ileum' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'Jejunum' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'Appendix' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'LeftImmuneSystem' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'LeftSpleen' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'RightImmuneSystem' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'RightSpleen' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'LeftAdrenal' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'LeftKidney' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'LeftUrogenital' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'RightAdrenal' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'RightKidney' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'RightUrogenital' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'UroKidneyLeft' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'UroKidneyRight' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'Gallbladder' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'LeftCerebralCortexZone' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'LeftCerebralVessels' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'LeftHypothalamus' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'LeftLiver' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'LeftPancreas' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'LeftPinealEpiphysis' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'LeftPituitaryHypophysis' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'LeftThyroid' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'RightCerebralCortexZone' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'RightCerebralVessels' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'RightHypothalamus' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'RightLiver' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'RightPancreas' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'RightPinealEpiphysis' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'RightPituitaryHypophysis' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'RightThyroid' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'LeftCervicalSpine' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'LeftCoccyxPelvis' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'LeftLSideEye' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'LeftLJawTeeth' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'LeftLumbarSpine' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'LeftNervousSystem' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'LeftSacrum' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'LeftThorax' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'RightCervicalSpine' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'RightCoccyxPelvis' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'RightRSideEye' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'RightRJawTeeth' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'RightLumbarSpine' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'RightNervousSystem' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'RightSacrum' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'RightThorax' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'LeftREarNoseMaxillarySinus' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'RightLEarNoseMaxillarySinus' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'RightLJawTeeth' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'LeftRJawTeeth' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'RightLSideEye' )
INSERT INTO @OrganMap ( Name ) VALUES ( 'LeftRSideEye' )

-- Now update the column switch the current varchar (name) to the value
-- as a varchar.
UPDATE CalculationDebugData
SET OrganComponent = CONVERT(varchar(3), (SELECT Id FROM @OrganMap WHERE Name = OrganComponent))

-- Now simply change the data type of the column. The varchars will be
-- converted to integers.
ALTER TABLE CalculationDebugData
ALTER COLUMN OrganComponent smallint not null

-- The Organ table defines these values also, in the EPICOrganId column.
-- Rename the column to be OrganComponent for consistency.
--
-- First drop this index.
DROP INDEX IDX_Organ_EPICOrganId ON [dbo].[Organ]

-- Rename column.
EXEC sp_rename 'Organ.EPICOrganId', 'OrganComponent', 'COLUMN'

-- Recreate the index.
CREATE UNIQUE NONCLUSTERED INDEX IDX_Organ_OrganComponent
ON [dbo].[Organ] ( [OrganComponent] ASC ) WITH ( FILLFACTOR = 80 )

-- Create new table to restricting user accounts. This is used when new
-- users are created and when a user resets his/her password.
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON

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
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

SET ANSI_PADDING OFF

ALTER TABLE [dbo].[AccountRestriction] ADD CONSTRAINT [DF_AccountRestriction_CreationTime] DEFAULT (getutcdate()) FOR [CreationTime]
ALTER TABLE [dbo].[AccountRestriction] ADD CONSTRAINT [DF_AccountRestriction_IsActive] DEFAULT ((1)) FOR [IsActive]

-- Create another table that will be used to join an AccountRestriction
-- record to user accounts. This allows multiple user accounts to share
-- a restriction, necessary when an email address is used for multiple
-- user accounts.
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[UserAccountRestriction](
	[UserId] [int] NOT NULL,
	[AccountRestrictionId] [int] NOT NULL,
CONSTRAINT [PK_UserAccountRestriction] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[AccountRestrictionId] ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[UserAccountRestriction] WITH CHECK ADD CONSTRAINT [FK_UserAccountRestriction_AccountRestriction] FOREIGN KEY([AccountRestrictionId])
REFERENCES [dbo].[AccountRestriction] ([AccountRestrictionId])
ALTER TABLE [dbo].[UserAccountRestriction] CHECK CONSTRAINT [FK_UserAccountRestriction_AccountRestriction]

ALTER TABLE [dbo].[UserAccountRestriction] WITH CHECK ADD CONSTRAINT [FK_UserAccountRestriction_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
ALTER TABLE [dbo].[UserAccountRestriction] CHECK CONSTRAINT [FK_UserAccountRestriction_User]

-- These columns in the User table are no longer used. So they will be
-- removed.
ALTER TABLE [dbo].[User] DROP CONSTRAINT [DF_User_SecurityQuestion1]
ALTER TABLE [dbo].[User] DROP CONSTRAINT [DF_User_SecurityAnswer1]
ALTER TABLE [dbo].[User] DROP CONSTRAINT [DF_User_ResetKey]
ALTER TABLE [dbo].[User] DROP COLUMN [SecurityQuestion1]
ALTER TABLE [dbo].[User] DROP COLUMN [SecurityAnswer1]
ALTER TABLE [dbo].[User] DROP COLUMN [ResetKey]

-- Add a new role for non-admin users.
INSERT INTO [dbo].[Role] ( [Name], [Description] )
VALUES ( 'Simple User', 'Simple, non-administrator user with limited rights' )


-- Update schema version.
UPDATE [dbo].[SchemaVersion]
SET [Version] = 15
WHERE [Version] = 14

PRINT 'Schema version is now 15.'

END -- End of processing for upgrading from Version 14 to Version 15.
GO

DECLARE @CurrentVersion smallint

-- Check for current schema version = 15
SELECT TOP 1 @CurrentVersion = [Version]
FROM [dbo].[SchemaVersion]

IF @CurrentVersion = 15
BEGIN

PRINT 'Schema version is 15. Upgrading to version 16 ...'

-- Doing status event processing differently. None of this SQL code is
-- required now.
DROP TRIGGER [dbo].[DeviceSignalUpdateTrigger]
DROP TRIGGER [dbo].[ExceptionLogSignalUpdateTrigger]
DROP TRIGGER [dbo].[PurchaseHistorySignalUpdateTrigger]
DROP TRIGGER [dbo].[ScanHistorySignalUpdateTrigger]
DROP TRIGGER [dbo].[SupportIssueSignalUpdateTrigger]

DROP PROCEDURE [dbo].[OpsSignalUpdate]

DROP FUNCTION [dbo].[OpsActivityTypeDevicePing]
DROP FUNCTION [dbo].[OpsActivityTypeNewException]
DROP FUNCTION [dbo].[OpsActivityTypeNewPurchase]
DROP FUNCTION [dbo].[OpsActivityTypeNewScan]
DROP FUNCTION [dbo].[OpsActivityTypeNewSupportRequest]
DROP FUNCTION [dbo].[OpsUpdateValue]

DROP TABLE [dbo].[UpdateStatus]

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF

ALTER TABLE [dbo].[UpdateStatus] ADD CONSTRAINT [DF_UpdateStatus_UpdateTime] DEFAULT (getutcdate()) FOR [UpdateTime]


-- Update schema version.
UPDATE [dbo].[SchemaVersion]
SET [Version] = 16
WHERE [Version] = 15

PRINT 'Schema version is now 16.'

END -- End of processing for upgrading from Version 15 to Version 16.
GO

DECLARE @CurrentVersion smallint

-- Check for current schema version = 16
SELECT TOP 1 @CurrentVersion = [Version]
FROM [dbo].[SchemaVersion]

IF @CurrentVersion = 16
BEGIN

PRINT 'Schema version is 16. Upgrading to version 17 ...'

-- Moving credit cards so they are associated with users, not locations.
-- Also adding an Address.
ALTER TABLE [dbo].[CreditCard]
ADD [Address] [varchar](64) NULL

ALTER TABLE [dbo].[LocationCreditCard] DROP CONSTRAINT [FK_LocationCreditCard_CreditCard]
ALTER TABLE [dbo].[LocationCreditCard] DROP CONSTRAINT [FK_LocationCreditCard_Location]

DROP TABLE [dbo].[LocationCreditCard]

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON
CREATE TABLE [dbo].[UserCreditCard] (
	[UserId] [int] NOT NULL,
	[CreditCardId] [int] NOT NULL,
 CONSTRAINT [PK_UserCreditCard] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[CreditCardId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
SET ANSI_PADDING OFF

ALTER TABLE [dbo].[UserCreditCard]  WITH CHECK ADD  CONSTRAINT [FK_UserCreditCard_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[UserCreditCard] CHECK CONSTRAINT [FK_UserCreditCard_User]

ALTER TABLE [dbo].[UserCreditCard]  WITH CHECK ADD  CONSTRAINT [FK_UserCreditCard_CreditCard] FOREIGN KEY([CreditCardId])
REFERENCES [dbo].[CreditCard] ([CreditCardId])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[UserCreditCard] CHECK CONSTRAINT [FK_UserCreditCard_CreditCard]


-- Update schema version.
UPDATE [dbo].[SchemaVersion]
SET [Version] = 17
WHERE [Version] = 16

PRINT 'Schema version is now 17.'

END -- End of processing for upgrading from Version 16 to Version 17.
GO

DECLARE @CurrentVersion smallint

-- Check for current schema version = 17
SELECT TOP 1 @CurrentVersion = [Version]
FROM [dbo].[SchemaVersion]

IF @CurrentVersion = 17
BEGIN

PRINT 'Schema version is 17. Upgrading to version 18 ...'

-- Change this column type.
DROP INDEX IDX_PurchaseHistory_TransactionId ON [dbo].[PurchaseHistory]

ALTER TABLE [dbo].[PurchaseHistory]
ALTER COLUMN [TransactionId] [varchar](64) NOT NULL

CREATE NONCLUSTERED INDEX IDX_PurchaseHistory_TransactionId
ON [dbo].[PurchaseHistory] ( [TransactionId] ASC ) WITH ( FILLFACTOR = 80 )

-- Update schema version.
UPDATE [dbo].[SchemaVersion]
SET [Version] = 18
WHERE [Version] = 17

PRINT 'Schema version is now 18.'

END -- End of processing for upgrading from Version 16 to Version 17.
GO

DECLARE @CurrentVersion smallint

-- Check for current schema version = 18
SELECT TOP 1 @CurrentVersion = [Version]
FROM [dbo].[SchemaVersion]

IF @CurrentVersion = 18
BEGIN

PRINT 'Schema version is 18. Upgrading to version 19 ...'

-- Data needs to be changed:
--		current 1 => changes to 4
--		current 2 => changes to 5
--		current 3 => changes to 2
--		current 4 => changes to 1
--		current 5 => changes to 6
UPDATE [dbo].[NBAnalysisResult]
SET [NBAnalysisGroup] = 6
WHERE [NBAnalysisGroup] = 5

UPDATE [dbo].[NBAnalysisResult]
SET [NBAnalysisGroup] = 5
WHERE [NBAnalysisGroup] = 2

UPDATE [dbo].[NBAnalysisResult]
SET [NBAnalysisGroup] = 2
WHERE [NBAnalysisGroup] = 3

-- 1 becomes 4 and 4 becomes 1; using 3 as a temp.
UPDATE [dbo].[NBAnalysisResult]
SET [NBAnalysisGroup] = 3
WHERE [NBAnalysisGroup] = 4

UPDATE [dbo].[NBAnalysisResult]
SET [NBAnalysisGroup] = 4
WHERE [NBAnalysisGroup] = 1

UPDATE [dbo].[NBAnalysisResult]
SET [NBAnalysisGroup] = 1
WHERE [NBAnalysisGroup] = 3

-- Rename column and create foreign key.
EXEC sp_rename 'NBAnalysisResult.NBAnalysisGroup', 'OrganSystemId', 'COLUMN'

ALTER TABLE [dbo].[NBAnalysisResult] WITH CHECK ADD CONSTRAINT [FK_NBAnalysisResult_OrganSystem] FOREIGN KEY([OrganSystemId])
REFERENCES [dbo].[OrganSystem] ([OrganSystemId])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[NBAnalysisResult] CHECK CONSTRAINT [FK_NBAnalysisResult_OrganSystem]


-- Update schema version.
UPDATE [dbo].[SchemaVersion]
SET [Version] = 19
WHERE [Version] = 18

PRINT 'Schema version is now 19.'

END -- End of processing for upgrading from Version 18 to Version 19.
GO

DECLARE @CurrentVersion smallint

-- Check for current schema version = 19
SELECT TOP 1 @CurrentVersion = [Version]
FROM [dbo].[SchemaVersion]

IF @CurrentVersion = 19
BEGIN

PRINT 'Schema version is 19. Upgrading to version 20 ...'

-- New audit table for tracking data changes.
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON

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
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

SET ANSI_PADDING OFF


-- Update schema version.
UPDATE [dbo].[SchemaVersion]
SET [Version] = 20
WHERE [Version] = 19

PRINT 'Schema version is now 20.'

END -- End of processing for upgrading from Version 19 to Version 20.
GO

DECLARE @CurrentVersion smallint

-- Check for current schema version = 20
SELECT TOP 1 @CurrentVersion = [Version]
FROM [dbo].[SchemaVersion]

IF @CurrentVersion = 20
BEGIN

PRINT 'Schema version is 20. Upgrading to version 21 ...'

-- Add new table.
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[PatientPrescanQuestion](
	[TreatmentId] [bigint] NOT NULL,
	[AlcoholQuestion] [bit] NOT NULL,
	[WheatQuestion] [bit] NOT NULL,
	[CaffeineQuestion] [bit] NOT NULL,
CONSTRAINT [PK_PatientPrescanQuestion] PRIMARY KEY CLUSTERED 
(
	[TreatmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[PatientPrescanQuestion] WITH CHECK ADD CONSTRAINT [FK_PatientPrescanQuestion_Treatment] FOREIGN KEY([TreatmentId])
REFERENCES [dbo].[Treatment] ([TreatmentId])

ALTER TABLE [dbo].[PatientPrescanQuestion] CHECK CONSTRAINT [FK_PatientPrescanQuestion_Treatment]

ALTER TABLE [dbo].[PatientPrescanQuestion] ADD  CONSTRAINT [DF_PatientPrescanQuestion_AlcoholQuestion]  DEFAULT ((0)) FOR [AlcoholQuestion]
ALTER TABLE [dbo].[PatientPrescanQuestion] ADD  CONSTRAINT [DF_PatientPrescanQuestion_WheatQuestion]  DEFAULT ((0)) FOR [WheatQuestion]
ALTER TABLE [dbo].[PatientPrescanQuestion] ADD  CONSTRAINT [DF_PatientPrescanQuestion_CaffeineQuestion]  DEFAULT ((0)) FOR [CaffeineQuestion]

-- Add another new table.
-- NOTE: This table was added some time ago without updating this script!
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET ANSI_PADDING ON

CREATE TABLE [dbo].[ImageCache](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[LookupKey] [bigint] NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[Image] [varbinary](max) NOT NULL,
CONSTRAINT [PK_ImageCache] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


-- Update schema version.
UPDATE [dbo].[SchemaVersion]
SET [Version] = 21
WHERE [Version] = 20

PRINT 'Schema version is now 21.'

END -- End of processing for upgrading from Version 20 to Version 21.
GO

PRINT 'Done.'
