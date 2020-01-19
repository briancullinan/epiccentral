/****** FOREIGN KEYS ******/

ALTER TABLE [dbo].[ActiveOrganization] DROP CONSTRAINT [FK_ActiveOrganization_ActivityType]
GO

ALTER TABLE [dbo].[ActiveOrganization] DROP CONSTRAINT [FK_ActiveOrganization_Location]
GO

ALTER TABLE [dbo].[AnalysisResult] DROP CONSTRAINT [FK_AnalysisResult_Treatment]
GO

ALTER TABLE [dbo].[CalculationDebugData] DROP CONSTRAINT [FK_CalculationDebugData_Treatment]
GO

ALTER TABLE [dbo].[Calibration] DROP CONSTRAINT [FK_Calibration_Device]
GO

ALTER TABLE [dbo].[Calibration] DROP CONSTRAINT [FK_Calibration_ImageSet]
GO

ALTER TABLE [dbo].[Contact] DROP CONSTRAINT [FK_Contact_Organization]
GO

ALTER TABLE [dbo].[Device] DROP CONSTRAINT [FK_Device_Location]
GO

ALTER TABLE [dbo].[DeviceEvent] DROP CONSTRAINT [FK_DeviceEvent_Device]
GO

ALTER TABLE [dbo].[DeviceMessage] DROP CONSTRAINT [FK_DeviceMessage_Device]
GO

ALTER TABLE [dbo].[DeviceMessage] DROP CONSTRAINT [FK_DeviceMessage_Message]
GO

ALTER TABLE [dbo].[DeviceStateTracking] DROP CONSTRAINT [FK_DeviceStateTracking_Device]
GO

ALTER TABLE [dbo].[ExceptionLog] DROP CONSTRAINT [FK_ExceptionLog_Device]
GO

ALTER TABLE [dbo].[LicenseOrganSystem] DROP CONSTRAINT [FK_LicenseOrganSystem_OrganSystem]
GO

ALTER TABLE [dbo].[Location] DROP CONSTRAINT [FK_Location_Organization]
GO

ALTER TABLE [dbo].[NBAnalysisResult] DROP CONSTRAINT [FK_NBAnalysisResult_OrganSystem]
GO

ALTER TABLE [dbo].[NBAnalysisResult] DROP CONSTRAINT [FK_NBAnalysisResult_Treatment]
GO

ALTER TABLE [dbo].[OrganSystemOrgan] DROP CONSTRAINT [FK_OrganSystemOrgan_LicenseOrganSystem]
GO

ALTER TABLE [dbo].[OrganSystemOrgan] DROP CONSTRAINT [FK_OrganSystemOrgan_Organ]
GO

ALTER TABLE [dbo].[Patient] DROP CONSTRAINT [FK_Patient_Location]
GO

ALTER TABLE [dbo].[PatientPrescanQuestion] DROP CONSTRAINT [FK_PatientPrescanQuestion_Treatment]
GO

ALTER TABLE [dbo].[PurchaseHistory] DROP CONSTRAINT [FK_PurchaseHistory_Device]
GO

ALTER TABLE [dbo].[PurchaseHistory] DROP CONSTRAINT [FK_PurchaseHistory_Location]
GO

ALTER TABLE [dbo].[PurchaseHistory] DROP CONSTRAINT [FK_PurchaseHistory_User]
GO

ALTER TABLE [dbo].[ScanHistory] DROP CONSTRAINT [FK_ScanHistory_Device]
GO

ALTER TABLE [dbo].[Severity] DROP CONSTRAINT [FK_Severity_Organ]
GO

ALTER TABLE [dbo].[Severity] DROP CONSTRAINT [FK_Severity_Treatment]
GO

ALTER TABLE [dbo].[SupportIssue] DROP CONSTRAINT [FK_SupportIssue_FromUser]
GO

ALTER TABLE [dbo].[SupportIssue] DROP CONSTRAINT [FK_SupportIssue_SupportArea]
GO

ALTER TABLE [dbo].[SupportIssue] DROP CONSTRAINT [FK_SupportIssue_ToUser]
GO

ALTER TABLE [dbo].[Treatment] DROP CONSTRAINT [FK_Treatment_Calibration]
GO

ALTER TABLE [dbo].[Treatment] DROP CONSTRAINT [FK_Treatment_EnergizedImageSet]
GO

ALTER TABLE [dbo].[Treatment] DROP CONSTRAINT [FK_Treatment_FingerImageSet]
GO

ALTER TABLE [dbo].[Treatment] DROP CONSTRAINT [FK_Treatment_Patient]
GO

ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_User_Organization]
GO

ALTER TABLE [dbo].[UserAccountRestriction] DROP CONSTRAINT [FK_UserAccountRestriction_AccountRestriction]
GO

ALTER TABLE [dbo].[UserAccountRestriction] DROP CONSTRAINT [FK_UserAccountRestriction_User]
GO

ALTER TABLE [dbo].[UserAssignedLocation] DROP CONSTRAINT [FK_UserAssignedLocation_Location]
GO

ALTER TABLE [dbo].[UserAssignedLocation] DROP CONSTRAINT [FK_UserAssignedLocation_User]
GO

ALTER TABLE [dbo].[UserCreditCard] DROP CONSTRAINT [FK_UserCreditCard_CreditCard]
GO

ALTER TABLE [dbo].[UserCreditCard] DROP CONSTRAINT [FK_UserCreditCard_User]
GO

ALTER TABLE [dbo].[UserRole] DROP CONSTRAINT [FK_UserRole_Role]
GO

ALTER TABLE [dbo].[UserRole] DROP CONSTRAINT [FK_UserRole_User]
GO

ALTER TABLE [dbo].[UserSalt] DROP CONSTRAINT [FK_UserSalt_User]
GO

ALTER TABLE [dbo].[UserSetting] DROP CONSTRAINT [FK_UserSetting_User]
GO



/****** DEFAULT VALUES ******/

ALTER TABLE [dbo].[AccountRestriction] DROP CONSTRAINT [DF_AccountRestriction_CreationTime]
GO

ALTER TABLE [dbo].[AccountRestriction] DROP CONSTRAINT [DF_AccountRestriction_IsActive]
GO

ALTER TABLE [dbo].[ActivityType] DROP CONSTRAINT [DF_ActivityType_Description]
GO

ALTER TABLE [dbo].[AnalysisResult] DROP CONSTRAINT [DF_AnalysisResult_AI1]
GO

ALTER TABLE [dbo].[AnalysisResult] DROP CONSTRAINT [DF_AnalysisResult_AI2]
GO

ALTER TABLE [dbo].[AnalysisResult] DROP CONSTRAINT [DF_AnalysisResult_AI3]
GO

ALTER TABLE [dbo].[AnalysisResult] DROP CONSTRAINT [DF_AnalysisResult_AI4]
GO

ALTER TABLE [dbo].[AnalysisResult] DROP CONSTRAINT [DF_AnalysisResult_AnalysisTime]
GO

ALTER TABLE [dbo].[AnalysisResult] DROP CONSTRAINT [DF_AnalysisResult_AngleofRotation]
GO

ALTER TABLE [dbo].[AnalysisResult] DROP CONSTRAINT [DF_AnalysisResult_AverageIntensity]
GO

ALTER TABLE [dbo].[AnalysisResult] DROP CONSTRAINT [DF_AnalysisResult_BreakCoefficient]
GO

ALTER TABLE [dbo].[AnalysisResult] DROP CONSTRAINT [DF_AnalysisResult_CenterX]
GO

ALTER TABLE [dbo].[AnalysisResult] DROP CONSTRAINT [DF_AnalysisResult_CenterY]
GO

ALTER TABLE [dbo].[AnalysisResult] DROP CONSTRAINT [DF_AnalysisResult_EndAngle]
GO

ALTER TABLE [dbo].[AnalysisResult] DROP CONSTRAINT [DF_AnalysisResult_Entropy]
GO

ALTER TABLE [dbo].[AnalysisResult] DROP CONSTRAINT [DF_AnalysisResult_FingerType]
GO

ALTER TABLE [dbo].[AnalysisResult] DROP CONSTRAINT [DF_AnalysisResult_Form1_1]
GO

ALTER TABLE [dbo].[AnalysisResult] DROP CONSTRAINT [DF_AnalysisResult_Form1_2]
GO

ALTER TABLE [dbo].[AnalysisResult] DROP CONSTRAINT [DF_AnalysisResult_Form1_3]
GO

ALTER TABLE [dbo].[AnalysisResult] DROP CONSTRAINT [DF_AnalysisResult_Form1_4]
GO

ALTER TABLE [dbo].[AnalysisResult] DROP CONSTRAINT [DF_AnalysisResult_Form2]
GO

ALTER TABLE [dbo].[AnalysisResult] DROP CONSTRAINT [DF_AnalysisResult_Form2Prime]
GO

ALTER TABLE [dbo].[AnalysisResult] DROP CONSTRAINT [DF_AnalysisResult_FormCoefficient]
GO

ALTER TABLE [dbo].[AnalysisResult] DROP CONSTRAINT [DF_AnalysisResult_FractalCoefficient]
GO

ALTER TABLE [dbo].[AnalysisResult] DROP CONSTRAINT [DF_AnalysisResult_IntegralArea]
GO

ALTER TABLE [dbo].[AnalysisResult] DROP CONSTRAINT [DF_AnalysisResult_IsFiltered]
GO

ALTER TABLE [dbo].[AnalysisResult] DROP CONSTRAINT [DF_AnalysisResult_JsInteger]
GO

ALTER TABLE [dbo].[AnalysisResult] DROP CONSTRAINT [DF_AnalysisResult_NoiseLevel]
GO

ALTER TABLE [dbo].[AnalysisResult] DROP CONSTRAINT [DF_AnalysisResult_NormalizedArea]
GO

ALTER TABLE [dbo].[AnalysisResult] DROP CONSTRAINT [DF_AnalysisResult_RadiusMax]
GO

ALTER TABLE [dbo].[AnalysisResult] DROP CONSTRAINT [DF_AnalysisResult_RadiusMin]
GO

ALTER TABLE [dbo].[AnalysisResult] DROP CONSTRAINT [DF_AnalysisResult_RingIntensity]
GO

ALTER TABLE [dbo].[AnalysisResult] DROP CONSTRAINT [DF_AnalysisResult_RingThickness]
GO

ALTER TABLE [dbo].[AnalysisResult] DROP CONSTRAINT [DF_AnalysisResult_SectorArea]
GO

ALTER TABLE [dbo].[AnalysisResult] DROP CONSTRAINT [DF_AnalysisResult_SectorNumber]
GO

ALTER TABLE [dbo].[AnalysisResult] DROP CONSTRAINT [DF_AnalysisResult_SoftwareVersion]
GO

ALTER TABLE [dbo].[AnalysisResult] DROP CONSTRAINT [DF_AnalysisResult_StartAngle]
GO

ALTER TABLE [dbo].[AnalysisResult] DROP CONSTRAINT [DF_AnalysisResult_UserName]
GO

ALTER TABLE [dbo].[CalculationDebugData] DROP CONSTRAINT [DF_CalculationDebugData_Form2Prime]
GO

ALTER TABLE [dbo].[Calibration] DROP CONSTRAINT [DF_Calibration_ReceivedTime]
GO

ALTER TABLE [dbo].[Device] DROP CONSTRAINT [DF_Device_CurrentStatus]
GO

ALTER TABLE [dbo].[Device] DROP CONSTRAINT [DF_Device_DeviceState]
GO

ALTER TABLE [dbo].[Device] DROP CONSTRAINT [DF_Device_ScansAvailable]
GO

ALTER TABLE [dbo].[Device] DROP CONSTRAINT [DF_Device_ScansCompleted]
GO

ALTER TABLE [dbo].[Device] DROP CONSTRAINT [DF_Device_UidQualifier]
GO

ALTER TABLE [dbo].[DeviceStateTracking] DROP CONSTRAINT [DF_DeviceStateTracking_ChangeReason]
GO

ALTER TABLE [dbo].[DeviceStateTracking] DROP CONSTRAINT [DF_DeviceStateTracking_ChangeTime]
GO

ALTER TABLE [dbo].[DeviceStateTracking] DROP CONSTRAINT [DF_DeviceStateTracking_PreviousState]
GO

ALTER TABLE [dbo].[LicenseOrganSystem] DROP CONSTRAINT [DF_LicenseOrganSystem_LicenseMode]
GO

ALTER TABLE [dbo].[Location] DROP CONSTRAINT [DF_Location_AddressLine1]
GO

ALTER TABLE [dbo].[Location] DROP CONSTRAINT [DF_Location_AddressLine2]
GO

ALTER TABLE [dbo].[Location] DROP CONSTRAINT [DF_Location_City]
GO

ALTER TABLE [dbo].[Location] DROP CONSTRAINT [DF_Location_Country]
GO

ALTER TABLE [dbo].[Location] DROP CONSTRAINT [DF_Location_IsActive]
GO

ALTER TABLE [dbo].[Location] DROP CONSTRAINT [DF_Location_PostalCode]
GO

ALTER TABLE [dbo].[Location] DROP CONSTRAINT [DF_Location_State]
GO

ALTER TABLE [dbo].[Message] DROP CONSTRAINT [DF_Message_EndTime]
GO

ALTER TABLE [dbo].[Message] DROP CONSTRAINT [DF_Message_IsActive]
GO

ALTER TABLE [dbo].[Organization] DROP CONSTRAINT [DF_Organization_IsActive]
GO

ALTER TABLE [dbo].[Patient] DROP CONSTRAINT [DF_Patient_ReceivedTime]
GO

ALTER TABLE [dbo].[PatientPrescanQuestion] DROP CONSTRAINT [DF_PatientPrescanQuestion_AlcoholQuestion]
GO

ALTER TABLE [dbo].[PatientPrescanQuestion] DROP CONSTRAINT [DF_PatientPrescanQuestion_CaffeineQuestion]
GO

ALTER TABLE [dbo].[PatientPrescanQuestion] DROP CONSTRAINT [DF_PatientPrescanQuestion_WheatQuestion]
GO

ALTER TABLE [dbo].[PurchaseHistory] DROP CONSTRAINT [DF_PurchaseHistory_AmountPaid]
GO

ALTER TABLE [dbo].[PurchaseHistory] DROP CONSTRAINT [DF_PurchaseHistory_PurchaseNotes]
GO

ALTER TABLE [dbo].[ScanRate] DROP CONSTRAINT [DF_ScanRate_IsActive]
GO

ALTER TABLE [dbo].[SupportArea] DROP CONSTRAINT [DF_SupportArea_IsActive]
GO

ALTER TABLE [dbo].[SupportIssue] DROP CONSTRAINT [DF_SupportIssue_FromUserId]
GO

ALTER TABLE [dbo].[SupportIssue] DROP CONSTRAINT [DF_SupportIssue_IsActive]
GO

ALTER TABLE [dbo].[SupportIssue] DROP CONSTRAINT [DF_SupportIssue_IsClosedByFromUser]
GO

ALTER TABLE [dbo].[SupportIssue] DROP CONSTRAINT [DF_SupportIssue_IsClosedByToUser]
GO

ALTER TABLE [dbo].[SupportIssue] DROP CONSTRAINT [DF_SupportIssue_IsPublic]
GO

ALTER TABLE [dbo].[SupportIssue] DROP CONSTRAINT [DF_SupportIssue_ParentId]
GO

ALTER TABLE [dbo].[SupportIssue] DROP CONSTRAINT [DF_SupportIssue_Priority]
GO

ALTER TABLE [dbo].[SupportIssue] DROP CONSTRAINT [DF_SupportIssue_Status]
GO

ALTER TABLE [dbo].[SupportIssue] DROP CONSTRAINT [DF_SupportIssue_ToUserId]
GO

ALTER TABLE [dbo].[Treatment] DROP CONSTRAINT [DF_Treatment_ReceivedTime]
GO

ALTER TABLE [dbo].[UpdateStatus] DROP CONSTRAINT [DF_UpdateStatus_UpdateTime]
GO

ALTER TABLE [dbo].[User] DROP CONSTRAINT [DF_User_CreateTime]
GO

ALTER TABLE [dbo].[User] DROP CONSTRAINT [DF_User_IsActive]
GO

ALTER TABLE [dbo].[UserSetting] DROP CONSTRAINT [DF_UserSetting_Value]
GO



/****** TABLES ******/

DROP TABLE [dbo].[AccountRestriction]
GO

DROP TABLE [dbo].[ActiveOrganization]
GO

DROP TABLE [dbo].[ActivityType]
GO

DROP TABLE [dbo].[AnalysisResult]
GO

DROP TABLE [dbo].[Audit]
GO

DROP TABLE [dbo].[CalculationDebugData]
GO

DROP TABLE [dbo].[Calibration]
GO

DROP TABLE [dbo].[Contact]
GO

DROP TABLE [dbo].[CreditCard]
GO

DROP TABLE [dbo].[Device]
GO

DROP TABLE [dbo].[DeviceEvent]
GO

DROP TABLE [dbo].[DeviceMessage]
GO

DROP TABLE [dbo].[DeviceStateTracking]
GO

DROP TABLE [dbo].[ImageSet]
GO

DROP TABLE [dbo].[ImageCache]
GO

DROP TABLE [dbo].[ExceptionLog]
GO

DROP TABLE [dbo].[LicenseOrganSystem]
GO

DROP TABLE [dbo].[Location]
GO

DROP TABLE [dbo].[Message]
GO

DROP TABLE [dbo].[NBAnalysisResult]
GO

DROP TABLE [dbo].[Organ]
GO

DROP TABLE [dbo].[Organization]
GO

DROP TABLE [dbo].[OrganSystem]
GO

DROP TABLE [dbo].[OrganSystemOrgan]
GO

DROP TABLE [dbo].[Patient]
GO

DROP TABLE [dbo].[PatientPrescanQuestion]
GO

DROP TABLE [dbo].[PurchaseHistory]
GO

DROP TABLE [dbo].[Role]
GO

DROP TABLE [dbo].[ScanHistory]
GO

DROP TABLE [dbo].[ScanRate]
GO

DROP TABLE [dbo].[SchemaVersion]
GO

DROP TABLE [dbo].[Severity]
GO

DROP TABLE [dbo].[SupportArea]
GO

DROP TABLE [dbo].[SupportIssue]
GO

DROP TABLE [dbo].[SystemSetting]
GO

DROP TABLE [dbo].[Treatment]
GO

DROP TABLE [dbo].[UpdateStatus]
GO

DROP TABLE [dbo].[User]
GO

DROP TABLE [dbo].[UserAccountRestriction]
GO

DROP TABLE [dbo].[UserAssignedLocation]
GO

DROP TABLE [dbo].[UserCreditCard]
GO

DROP TABLE [dbo].[UserRole]
GO

DROP TABLE [dbo].[UserSalt]
GO

DROP TABLE [dbo].[UserSetting]
GO



/****** FUNCTIONS ******/

DROP FUNCTION [dbo].[GetUidQualifier]
GO



/****** VIEWS ******/
DROP VIEW [dbo].[Random]
GO
