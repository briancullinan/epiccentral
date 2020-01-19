/*================================================================================*/
/* DDL SCRIPT                                                                     */
/*================================================================================*/
/*  Title    : EPIC Central Database                                              */
/*  FileName : EPICCentralDataModel.hf                                            */
/*  Platform :                                                                    */
/*  Version  : Concept                                                            */
/*  Date     : Thursday, July 14, 2011                                            */
/*================================================================================*/
/*================================================================================*/
/* CREATE TABLES                                                                  */
/*================================================================================*/

CREATE TABLE dbo.EC_Customer (
  CustomerId NUMERIC(18) IDENTITY(1,1) NOT NULL,
  OrganizationName VARCHAR(128) NOT NULL,
  CustomerUniqueKey VARCHAR(40) NOT NULL,
  ContactEmailAddress VARCHAR(128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  ContactFirstName VARCHAR(50) NOT NULL,
  ContactLastName VARCHAR(50) NOT NULL,
  Active SMALLINT DEFAULT ((1)) NOT NULL,
  UserId NUMERIC(18) DEFAULT ((0)) NOT NULL,
  CONSTRAINT PK_EC_Customer PRIMARY KEY (CustomerId)
)
GO

CREATE TABLE dbo.EC_CustomerLocation (
  CustomerLocationId NUMERIC(18) IDENTITY(1,1) NOT NULL,
  LocationUniqueKey VARCHAR(40) NOT NULL,
  CustomerId NUMERIC(18) NOT NULL,
  LocationName VARCHAR(80) NOT NULL,
  AddressLine1 VARCHAR(80) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  AddressLine2 VARCHAR(80) COLLATE SQL_Latin1_General_CP1_CI_AS,
  AddressCity VARCHAR(40) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  AddressState VARCHAR(2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  AddressPostalCode VARCHAR(10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  PhoneNumber VARCHAR(20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  ScansAvailable INT DEFAULT ((0)) NOT NULL,
  ScansUsed INT DEFAULT ((0)) NOT NULL,
  Active SMALLINT DEFAULT ((0)) NOT NULL,
  CONSTRAINT PK_EC_CustomerLocation PRIMARY KEY (CustomerLocationId)
)
GO

CREATE TABLE dbo.EC_BillingInfo (
  BillingInfoId NUMERIC(18) IDENTITY(1,1) NOT NULL,
  CustomerLocationId NUMERIC(18) NOT NULL,
  PaymentTypeDesc VARCHAR(40) NOT NULL,
  FirstName VARCHAR(50) NOT NULL,
  LastName VARCHAR(50) NOT NULL,
  AddressLine1 VARCHAR(80) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  AddressLine2 VARCHAR(80) COLLATE SQL_Latin1_General_CP1_CI_AS,
  AddressCity VARCHAR(40) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  AddressState VARCHAR(2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  AddressPostalCode VARCHAR(10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  PhoneNumber VARCHAR(20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  AccountNumber VARCHAR(20) COLLATE SQL_Latin1_General_CP1_CI_AS,
  SecurityCode VARCHAR(40),
  ExpirationMonth VARCHAR(2) COLLATE SQL_Latin1_General_CP1_CI_AS,
  ExpirationYear VARCHAR(4) COLLATE SQL_Latin1_General_CP1_CI_AS,
  Active SMALLINT DEFAULT ((1)) NOT NULL,
  Latitude NUMERIC(18,4),
  Longitude NUMERIC(18,4),
  CONSTRAINT PK_EC_BillingInfo PRIMARY KEY (BillingInfoId)
)
GO

CREATE TABLE dbo.EC_Device (
  DeviceId NUMERIC(18) NOT NULL,
  MACAddress VARCHAR(20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  DeviceUniqueIdentifier VARCHAR(40) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  DeviceSerialNumber VARCHAR(40) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  DateIssued DATETIME NOT NULL,
  RevisionLevel VARCHAR(5) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  Active SMALLINT DEFAULT ((1)) NOT NULL,
  CONSTRAINT PK_EC_Device PRIMARY KEY (DeviceId)
)
GO

CREATE TABLE dbo.EC_CustomerDevice (
  CustomerLocationId NUMERIC(18) NOT NULL,
  DeviceId NUMERIC(18) NOT NULL,
  CurrentStatus VARCHAR(50) COLLATE SQL_Latin1_General_CP1_CI_AS,
  LastReportedDate DATETIME NOT NULL,
  CONSTRAINT PK_EC_CustomerDevice PRIMARY KEY (DeviceId, CustomerLocationId)
)
GO

CREATE TABLE dbo.EC_ExceptionLog (
  ExceptionLogId NUMERIC(18) NOT NULL,
  CustomerId NUMERIC(18) NOT NULL,
  CustomerExceptionLogId NUMERIC(18) NOT NULL,
  CustomerExceptionObject VARBINARY NOT NULL,
  CustomerExceptionTitle VARCHAR(1024),
  CustomerExceptionMessage VARCHAR(1024) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  CustomerExceptionStackTrace VARCHAR(4096) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  CustomerExceptionInnerStackTrace VARCHAR(4096) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  CustomerExceptionDateTime DATETIME NOT NULL,
  CustomerExceptionUser VARCHAR(50),
  CustomerExceptionFormName VARCHAR(50),
  CustomerExceptionMachineName VARCHAR(50),
  CustomerExceptionMachineOS VARCHAR(50),
  CustomerExceptionApplicationVersion VARCHAR(40),
  CustomerExceptionCLRVersion VARCHAR(50),
  CustomerExceptionMemoryUsage VARCHAR(40),
  ReceivedDate DATETIME NOT NULL,
  CONSTRAINT PK_EC_ExceptionLog PRIMARY KEY (ExceptionLogId)
)
GO

CREATE TABLE dbo.EC_MessageBank (
  MessageBankId NUMERIC(18) IDENTITY(1,1) NOT NULL,
  CustomerLocationId NUMERIC(18) NOT NULL,
  MessageTitle VARCHAR(255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  MessageBody VARCHAR(4096) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  MessageDateTime DATETIME NOT NULL,
  MessageType SMALLINT NOT NULL,
  DeviceId NUMERIC(18),
  CONSTRAINT PK_EC_MessageBank PRIMARY KEY (MessageBankId)
)
GO

CREATE TABLE dbo.EC_PurchaseHistory (
  PurchaseHistoryId NUMERIC(18) IDENTITY(1,1) NOT NULL,
  CustomerId NUMERIC(18) NOT NULL,
  PurchaseDate DATETIME NOT NULL,
  ScansPurchased NUMERIC(18),
  AmountPaid MONEY DEFAULT ((0)) NOT NULL,
  CustomerLocationId NUMERIC(18) NOT NULL,
  CONSTRAINT PK_EC_PurchaseHistory PRIMARY KEY (PurchaseHistoryId)
)
GO

CREATE TABLE dbo.EC_ScanType (
  ScanType NUMERIC(18) IDENTITY(1,1) NOT NULL,
  ScanTypeDescription VARCHAR(80) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  CONSTRAINT PK_EC_ScanType PRIMARY KEY (ScanType)
)
GO

CREATE TABLE dbo.EC_ScanRates (
  ScanRateId NUMERIC(18) IDENTITY(1,1) NOT NULL,
  ScanType NUMERIC(18) NOT NULL,
  EffectiveDate DATETIME NOT NULL,
  MinCountForRate NUMERIC(18) NOT NULL,
  MaxCountForRate NUMERIC(18) NOT NULL,
  RatePerScan MONEY NOT NULL,
  Active SMALLINT DEFAULT ((1)) NOT NULL,
  CONSTRAINT PK_EC_ScanRates PRIMARY KEY (ScanRateId)
)
GO

CREATE TABLE dbo.EC_User (
  UserId NUMERIC(18) IDENTITY(1,1) NOT NULL,
  Username VARCHAR(80) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  Password VARCHAR(40) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  LocationId NUMERIC(18) NOT NULL,
  EmailAddress VARCHAR(128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  FirstName VARCHAR(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  LastName VARCHAR(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  IsRetailer SMALLINT DEFAULT ((0)) NOT NULL,
  IsAdmin SMALLINT DEFAULT ((0)) NOT NULL,
  IsActive SMALLINT DEFAULT ((1)) NOT NULL,
  ResetKey VARCHAR(256) COLLATE SQL_Latin1_General_CP1_CI_AS DEFAULT ('') NOT NULL,
  SecurityQuestion1 VARCHAR(512) COLLATE SQL_Latin1_General_CP1_CI_AS DEFAULT ('') NOT NULL,
  SecurityAnswer1 VARCHAR(128) COLLATE SQL_Latin1_General_CP1_CI_AS DEFAULT ('') NOT NULL,
  Roles VARCHAR(40) COLLATE SQL_Latin1_General_CP1_CI_AS DEFAULT ('') NOT NULL,
  CONSTRAINT PK_EC_CustomerUser PRIMARY KEY (UserId)
)
GO

CREATE TABLE dbo.EC_SupportAreas (
  SupportAreaId NUMERIC(18) IDENTITY(1,1) NOT NULL,
  AreaDescription VARCHAR(40) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  Active SMALLINT DEFAULT ((0)) NOT NULL,
  CONSTRAINT PK_EC_SupportAreas PRIMARY KEY (SupportAreaId)
)
GO

CREATE TABLE dbo.EC_Support (
  SupportId NUMERIC(18) IDENTITY(1,1) NOT NULL,
  ParentId NUMERIC(18) DEFAULT ((0)) NOT NULL,
  Subject VARCHAR(512) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  Body VARCHAR(6144) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  DateCreated DATETIME NOT NULL,
  ToUserId NUMERIC(18) DEFAULT (NULL) NOT NULL,
  FromUserId NUMERIC(18) DEFAULT (NULL) NOT NULL,
  SupportAreaId NUMERIC(18) NOT NULL,
  ToDelete SMALLINT DEFAULT ((0)) NOT NULL,
  FromDelete SMALLINT DEFAULT ((0)) NOT NULL,
  IsPublic SMALLINT DEFAULT ((0)) NOT NULL,
  Status VARCHAR(128) COLLATE SQL_Latin1_General_CP1_CI_AS DEFAULT ('') NOT NULL,
  Priority SMALLINT DEFAULT ((0)) NOT NULL,
  CONSTRAINT PK_EC_Support PRIMARY KEY (SupportId)
)
GO

CREATE TABLE dbo.EC_System (
  Name VARCHAR(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  Value VARCHAR(40) COLLATE SQL_Latin1_General_CP1_CI_AS,
  CONSTRAINT PK_EC_System PRIMARY KEY (Name)
)
GO

CREATE TABLE dbo.EC_UsageHistory (
  UsageHistoryId NUMERIC(18) IDENTITY(1,1) NOT NULL,
  CustomerLocationId NUMERIC(18) NOT NULL,
  ScanType NUMERIC(18) NOT NULL,
  ScanStartDateTime DATETIME NOT NULL,
  CONSTRAINT PK_EC_UsageHistory PRIMARY KEY (UsageHistoryId)
)
GO

CREATE TABLE dbo.EC_UserSalt (
  UserId NUMERIC(18) NOT NULL,
  Salt VARCHAR(4096) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  CONSTRAINT PK_EC_UserSalt PRIMARY KEY (UserId)
)
GO

/*================================================================================*/
/* CREATE FOREIGN KEYS                                                            */
/*================================================================================*/

ALTER TABLE dbo.EC_CustomerLocation
  ADD CONSTRAINT FK_CustomerLocation_Customer
  FOREIGN KEY (CustomerId) REFERENCES dbo.EC_Customer (CustomerId)
  ON UPDATE CASCADE
  ON DELETE CASCADE
GO

ALTER TABLE dbo.EC_BillingInfo
  ADD CONSTRAINT FK_EC_BillingInfo_EC_CustomerLocation
  FOREIGN KEY (CustomerLocationId) REFERENCES dbo.EC_CustomerLocation (CustomerLocationId)
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
GO

ALTER TABLE dbo.EC_CustomerDevice
  ADD CONSTRAINT FK_EC_CustomerDevice_EC_Device
  FOREIGN KEY (DeviceId) REFERENCES dbo.EC_Device (DeviceId)
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
GO

ALTER TABLE dbo.EC_CustomerDevice
  ADD CONSTRAINT FK_CustomerDevice_CustomerLocation
  FOREIGN KEY (CustomerLocationId) REFERENCES dbo.EC_CustomerLocation (CustomerLocationId)
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
GO

ALTER TABLE dbo.EC_MessageBank
  ADD CONSTRAINT FK_EC_MessageBank_EC_CustomerLocation
  FOREIGN KEY (CustomerLocationId) REFERENCES dbo.EC_CustomerLocation (CustomerLocationId)
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
GO

ALTER TABLE dbo.EC_PurchaseHistory
  ADD CONSTRAINT FK_EC_PurchaseHistory_EC_CustomerLocation
  FOREIGN KEY (CustomerLocationId) REFERENCES dbo.EC_CustomerLocation (CustomerLocationId)
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
GO

ALTER TABLE dbo.EC_PurchaseHistory
  ADD CONSTRAINT FK_PurchaseHistory_Customer
  FOREIGN KEY (CustomerId) REFERENCES dbo.EC_Customer (CustomerId)
  ON UPDATE CASCADE
  ON DELETE CASCADE
GO

ALTER TABLE dbo.EC_ScanRates
  ADD CONSTRAINT FK_EC_ScanRates_EC_ScanType
  FOREIGN KEY (ScanType) REFERENCES dbo.EC_ScanType (ScanType)
  ON UPDATE CASCADE
  ON DELETE CASCADE
GO

ALTER TABLE dbo.EC_User
  ADD CONSTRAINT FK_EC_Customer_User_EC_CustomerLocation
  FOREIGN KEY (LocationId) REFERENCES dbo.EC_CustomerLocation (CustomerLocationId)
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
GO

ALTER TABLE dbo.EC_Support
  ADD CONSTRAINT FK_EC_Support_EC_CustomerUser
  FOREIGN KEY (ToUserId) REFERENCES dbo.EC_User (UserId)
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
GO

ALTER TABLE dbo.EC_Support
  ADD CONSTRAINT FK_EC_Support_EC_SupportAreas
  FOREIGN KEY (SupportAreaId) REFERENCES dbo.EC_SupportAreas (SupportAreaId)
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
GO

ALTER TABLE dbo.EC_UsageHistory
  ADD CONSTRAINT FK_EC_UsageHistory_ScanType
  FOREIGN KEY (ScanType) REFERENCES dbo.EC_ScanType (ScanType)
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
GO

ALTER TABLE dbo.EC_UsageHistory
  ADD CONSTRAINT FK_EC_UsageHistory_CustomerLocation
  FOREIGN KEY (CustomerLocationId) REFERENCES dbo.EC_CustomerLocation (CustomerLocationId)
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
GO
