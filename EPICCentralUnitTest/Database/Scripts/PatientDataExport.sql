declare @rootdir varchar(128)
declare @sql varchar(8000)

set @rootdir = 'C:\Work\Temp\Data'

declare @patients varchar(128)
set @patients = '343, 358, 342, 353'

declare @where varchar(128)
set @where = ' where p.[PatientId] in (' + @patients + ') '

declare @joinwhere varchar(1024)
set @joinwhere = ' join [EPICCentral].[dbo].[Patient] p on p.[PatientId] = t.[PatientId]' + @where

set @sql = 'bcp "select p.* from [EPICCentral].[dbo].[Patient] p' + @where + '" ' +
		   'queryout ' + @rootdir + '\Patients.dat ' +
		   '-S EPIC-DBSRV1 -U EPICCentralUser -P "Z*y3u9JPawgJ2!Ok" -f' + @rootdir + '\PatientFormat.xml'

print @sql
exec xp_cmdshell @sql --, NO_OUTPUT

set @sql = 'bcp "select t.* ' +
				'from [EPICCentral].[dbo].[Treatment] t ' +
				@joinwhere + '" ' +
		   'queryout ' + @rootdir + '\Treatments.dat ' +
		   '-S EPIC-DBSRV1 -U EPICCentralUser -P "Z*y3u9JPawgJ2!Ok" -f' + @rootdir + '\TreatmentFormat.xml'

print @sql
exec xp_cmdshell @sql --, NO_OUTPUT

set @sql = 'bcp "select q.* ' +
				'from [EPICCentral].[dbo].[PatientPrescanQuestion] q ' +
				'join [EPICCentral].[dbo].[Treatment] t on t.[TreatmentId] = q.[TreatmentId] ' +
				@joinwhere + '" ' +
		   'queryout ' + @rootdir + '\PatientPrescanQuestions.dat ' +
		   '-S EPIC-DBSRV1 -U EPICCentralUser -P "Z*y3u9JPawgJ2!Ok" -f' + @rootdir + '\PatientPrescanQuestionFormat.xml'

print @sql
exec xp_cmdshell @sql --, NO_OUTPUT

set @sql = 'bcp "select nb.* ' +
				'from [EPICCentral].[dbo].[NBAnalysisResult] nb ' +
				'join [EPICCentral].[dbo].[Treatment] t on t.[TreatmentId] = nb.[TreatmentId] ' +
				@joinwhere + '" ' +
		   'queryout ' + @rootdir + '\NBAnalysisResults.dat ' +
		   '-S EPIC-DBSRV1 -U EPICCentralUser -P "Z*y3u9JPawgJ2!Ok" -f' + @rootdir + '\NBAnalysisResultFormat.xml'

print @sql
exec xp_cmdshell @sql --, NO_OUTPUT

set @sql = 'bcp "select a.* ' +
				'from [EPICCentral].[dbo].[AnalysisResult] a ' +
				'join [EPICCentral].[dbo].[Treatment] t on t.[TreatmentId] = a.[TreatmentId] ' +
				@joinwhere + '" ' +
		   'queryout ' + @rootdir + '\AnalysisResults.dat ' +
		   '-S EPIC-DBSRV1 -U EPICCentralUser -P "Z*y3u9JPawgJ2!Ok" -f' + @rootdir + '\AnalysisResultFormat.xml'

print @sql
exec xp_cmdshell @sql --, NO_OUTPUT

set @sql = 'bcp "select c.* ' +
				'from [EPICCentral].[dbo].[CalculationDebugData] c ' +
				'join [EPICCentral].[dbo].[Treatment] t on t.[TreatmentId] = c.[TreatmentId] ' +
				@joinwhere + '" ' +
		   'queryout ' + @rootdir + '\CalculationDebugDatas.dat ' +
		   '-S EPIC-DBSRV1 -U EPICCentralUser -P "Z*y3u9JPawgJ2!Ok" -f' + @rootdir + '\CalculationDebugDataFormat.xml'

print @sql
exec xp_cmdshell @sql --, NO_OUTPUT

set @sql = 'bcp "select s.* ' +
				'from [EPICCentral].[dbo].[Severity] s ' +
				'join [EPICCentral].[dbo].[Treatment] t on t.[TreatmentId] = s.[TreatmentId] ' +
				@joinwhere + '" ' +
		   'queryout ' + @rootdir + '\Severities.dat ' +
		   '-S EPIC-DBSRV1 -U EPICCentralUser -P "Z*y3u9JPawgJ2!Ok" -f' + @rootdir + '\SeverityFormat.xml'

print @sql
exec xp_cmdshell @sql --, NO_OUTPUT

set @sql = 'bcp "select i.* ' +
				'from [EPICCentral].[dbo].[ImageSet] i ' +
				'join [EPICCentral].[dbo].[Treatment] t on t.[EnergizedImageSetId] = i.[ImageSetId] ' +
				@joinwhere + '" ' +
		   'queryout ' + @rootdir + '\EnergizedImageSets.dat ' +
		   '-S EPIC-DBSRV1 -U EPICCentralUser -P "Z*y3u9JPawgJ2!Ok" -f' + @rootdir + '\ImageSetFormat-Export.xml'

print @sql
exec xp_cmdshell @sql --, NO_OUTPUT

set @sql = 'bcp "select i.* ' +
				'from [EPICCentral].[dbo].[ImageSet] i ' +
				'join [EPICCentral].[dbo].[Treatment] t on t.[FingerImageSetId] = i.[ImageSetId] ' +
				@joinwhere + '" ' +
		   'queryout ' + @rootdir + '\FingerImageSets.dat ' +
		   '-S EPIC-DBSRV1 -U EPICCentralUser -P "Z*y3u9JPawgJ2!Ok" -f' + @rootdir + '\ImageSetFormat-Export.xml'

print @sql
exec xp_cmdshell @sql --, NO_OUTPUT

set @sql = 'bcp "select distinct c.* ' +
				'from [EPICCentral].[dbo].[Calibration] c ' +
				'join [EPICCentral].[dbo].[Treatment] t on t.[CalibrationId] = c.[CalibrationId] ' +
				@joinwhere + '" ' +
		   'queryout ' + @rootdir + '\Calibrations.dat ' +
		   '-S EPIC-DBSRV1 -U EPICCentralUser -P "Z*y3u9JPawgJ2!Ok" -f' + @rootdir + '\CalibrationFormat.xml'

print @sql
exec xp_cmdshell @sql --, NO_OUTPUT

set @sql = 'bcp "select distinct i.* ' +
				'from [EPICCentral].[dbo].[ImageSet] i ' +
				'join [EPICCentral].[dbo].[Calibration] c on c.[ImageSetId] = i.[ImageSetId] ' +
				'join [EPICCentral].[dbo].[Treatment] t on t.[CalibrationId] = c.[CalibrationId] ' +
				@joinwhere + '" ' +
		   'queryout ' + @rootdir + '\CalibrationImageSets.dat ' +
		   '-S EPIC-DBSRV1 -U EPICCentralUser -P "Z*y3u9JPawgJ2!Ok" -f' + @rootdir + '\ImageSetFormat-Export.xml'

print @sql
exec xp_cmdshell @sql --, NO_OUTPUT
