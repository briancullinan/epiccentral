declare @newids table (id int identity, new bigint)
declare @oldids table (id int identity, old bigint)
declare @imagemap table (old bigint null, new bigint)
declare @deviceid int
declare @sql varchar(4096)

-- Uncomment these lines to run in SQL Server Management Studio.
--declare @rootdir varchar(128)
--set @rootdir = 'C:\Work\Temp\Data'

set @deviceid = 1

select cast(1 as bigint) as idold, * into #patient from Patient where 1 = 0

set @sql = '
	select *
	from openrowset( bulk ''' + @rootdir + '\Patients.dat'', formatfile = ''' + @rootdir + '\PatientFormat.xml'') as p
	order by p.PatientId
'

insert into #patient
exec (@sql)

insert into Patient
output inserted.PatientId
into @newids
select
	p.UniqueIdentifier,
	p.FirstName,
	p.LastName,
	p.MiddleInitial,
	p.PhoneNumber,
	p.EmailAddress,
	p.BirthDate,
	p.Gender,
	(select LocationId from Device where DeviceId = @deviceid),
	p.ReceivedTime
from #patient p
order by p.idold

alter table #patient add idnew bigint null

update p
set p.idnew = n.new
from #patient p
join (select row_number() over(order by id) as id, new from @newids) n on n.id = p.PatientId

delete from @newids

set @sql = '
	insert into ImageSet (
		UniqueIdentifier,
		Images
	)
	output inserted.ImageSetId
	select
		i.UniqueIdentifier,
		i.Images
	from  openrowset( bulk ''' + @rootdir + '\CalibrationImageSets.dat'', formatfile = ''' + @rootdir + '\ImageSetFormat-Import.xml'') as i
	order by i.ImageSetId
'

insert into @newids (new)
exec (@sql)

set @sql = '
	select
		i.ImageSetId
	from  openrowset( bulk ''' + @rootdir + '\CalibrationImageSets.dat'', formatfile = ''' + @rootdir + '\ImageSetFormat-Import.xml'') as i
	order by i.ImageSetId
'

insert into @oldids (old)
exec (@sql)

insert into @imagemap (old, new)
select old, new
from (select row_number() over(order by id) as id, new from @newids) n
join (select row_number() over(order by id) as id, old from @oldids) o on o.id = n.id

delete from @newids
delete from @oldids

select cast(1 as bigint) as idold, * into #calibration from Calibration where 1 = 0

set @sql = '
	select *
	from openrowset( bulk ''' + @rootdir + '\Calibrations.dat'', formatfile = ''' + @rootdir + '\CalibrationFormat.xml'') as c
	order by c.CalibrationId
'

insert into #calibration
exec (@sql)

insert into Calibration
output inserted.CalibrationId
into @newids
select
	@deviceid,
	c.UniqueIdentifier,
	c.CalibrationTime,
	c.PerformedBy,
	(select new from @imagemap where old = c.ImageSetId),
	c.ReceivedTime
from #calibration c
order by c.idold

alter table #calibration add idnew bigint null

update c
set c.idnew = n.new
from #calibration c
join (select row_number() over(order by id) as id, new from @newids) n on n.id = c.CalibrationId

delete from @newids

set @sql = '
	insert into ImageSet (
		UniqueIdentifier,
		Images
	)
	output inserted.ImageSetId
	select
		i.UniqueIdentifier,
		i.Images
	from  openrowset( bulk ''' + @rootdir + '\EnergizedImageSets.dat'', formatfile = ''' + @rootdir + '\ImageSetFormat-Import.xml'') as i
	order by i.ImageSetId
'

insert into @newids (new)
exec (@sql)

set @sql = '
	select
		i.ImageSetId
	from  openrowset( bulk ''' + @rootdir + '\EnergizedImageSets.dat'', formatfile = ''' + @rootdir + '\ImageSetFormat-Import.xml'') as i
	order by i.ImageSetId
'

insert into @oldids (old)
exec (@sql)

insert into @imagemap (old, new)
select old, new
from (select row_number() over(order by id) as id, new from @newids) n
join (select row_number() over(order by id) as id, old from @oldids) o on o.id = n.id

delete from @newids
delete from @oldids

set @sql = '
	insert into ImageSet (
		UniqueIdentifier,
		Images
	)
	output inserted.ImageSetId
	select
		i.UniqueIdentifier,
		i.Images
	from  openrowset( bulk ''' + @rootdir + '\FingerImageSets.dat'', formatfile = ''' + @rootdir + '\ImageSetFormat-Import.xml'') as i
	order by i.ImageSetId
'

insert into @newids (new)
exec (@sql)

set @sql = '
	select
		i.ImageSetId
	from  openrowset( bulk ''' + @rootdir + '\FingerImageSets.dat'', formatfile = ''' + @rootdir + '\ImageSetFormat-Import.xml'') as i
	order by i.ImageSetId
'

insert into @oldids (old)
exec (@sql)

insert into @imagemap (old, new)
select old, new
from (select row_number() over(order by id) as id, new from @newids) n
join (select row_number() over(order by id) as id, old from @oldids) o on o.id = n.id

delete from @newids
delete from @oldids

select cast(1 as bigint) as idold, * into #treatment from Treatment where 1 = 0

set @sql = '
	select *
	from openrowset( bulk ''' + @rootdir + '\Treatments.dat'', formatfile = ''' + @rootdir + '\TreatmentFormat.xml'') as t
	order by t.TreatmentId
'

insert into #treatment
exec (@sql)

insert into Treatment
output inserted.TreatmentId
into @newids
select
	(select idnew from #patient where idold = t.PatientId),
	(select idnew from #calibration where idold = t.CalibrationId),
	t.UniqueIdentifier,
	t.TreatmentType,
	t.TreatmentTime,
	t.PerformedBy,
	(select new from @imagemap where old = t.EnergizedImageSetId),
	(select new from @imagemap where old = t.FingerImageSetId),
	t.SoftwareVersion,
	t.FirmwareVersion,
	t.AnalysisTime,
	t.ReceivedTime
from #treatment t
order by t.idold

alter table #treatment add idnew bigint null

update t
set t.idnew = n.new
from #treatment t
join (select row_number() over(order by id) as id, new from @newids) n on n.id = t.TreatmentId

delete from @newids

select * into #question from PatientPrescanQuestion where 1 = 0

set @sql = '
	select *
	from openrowset( bulk ''' + @rootdir + '\PatientPrescanQuestions.dat'', formatfile = ''' + @rootdir + '\PatientPrescanQuestionFormat.xml'') as s
'

insert into #question
exec (@sql)

insert into PatientPrescanQuestion
select
	(select idnew from #treatment where idold = p.TreatmentId),
	p.AlcoholQuestion,
	p.WheatQuestion,
	p.CaffeineQuestion
from #question p

select cast(1 as bigint) as idold, * into #severity from Severity where 1 = 0

set @sql = '
	select *
	from openrowset( bulk ''' + @rootdir + '\Severities.dat'', formatfile = ''' + @rootdir + '\SeverityFormat.xml'') as s
	order by s.SeverityId
'

insert into #severity
exec (@sql)

insert into Severity
select
	(select idnew from #treatment where idold = s.TreatmentId),
	s.OrganId,
	s.PhysicalRight,
	s.PhysicalLeft,
	s.MentalRight,
	s.MentalLeft
from #severity s

select cast(1 as bigint) as idold, * into #nbanalysisresult from NBAnalysisResult where 1 = 0

set @sql = '
	select *
	from openrowset( bulk ''' + @rootdir + '\NBAnalysisResults.dat'', formatfile = ''' + @rootdir + '\NBAnalysisResultFormat.xml'') as n
	order by n.NBAnalysisResultId
'

insert into #nbanalysisresult
exec (@sql)

insert into NBAnalysisResult
select
	(select idnew from #treatment where idold = n.TreatmentId),
	n.OrganSystemId,
	n.ResultScoreFiltered,
	n.ResultScoreUnfiltered,
	n.ProbabilityFiltered,
	n.ProbabilityUnfiltered
from #nbanalysisresult n

select cast(1 as bigint) as idold, * into #analysisresult from AnalysisResult where 1 = 0

set @sql = '
	select *
	from openrowset( bulk ''' + @rootdir + '\AnalysisResults.dat'', formatfile = ''' + @rootdir + '\AnalysisResultFormat.xml'') as n
	order by n.AnalysisResultId
'

insert into #analysisresult
exec (@sql)

insert into AnalysisResult
select
	(select idnew from #treatment where idold = a.TreatmentId),
	AnalysisTime,
	IsFiltered,
	FingerDesc,
	FingerType,
	SectorNumber,
	StartAngle,
	EndAngle,
	SectorArea,
	IntegralArea,
	NormalizedArea,
	AverageIntensity,
	Entropy,
	FormCoefficient,
	FractalCoefficient,
	JsInteger,
	CenterX,
	CenterY,
	RadiusMin,
	RadiusMax,
	AngleOfRotation,
	Form2,
	NoiseLevel,
	BreakCoefficient,
	SoftwareVersion,
	AI1,
	AI2,
	AI3,
	AI4,
	Form1_1,
	Form1_2,
	Form1_3,
	Form1_4,
	RingThickness,
	RingIntensity,
	Form2Prime,
	UserName
from #analysisresult a

select cast(1 as bigint) as idold, * into #calculationdebugdata from CalculationDebugData where 1 = 0

set @sql = '
	select *
	from openrowset( bulk ''' + @rootdir + '\CalculationDebugDatas.dat'', formatfile = ''' + @rootdir + '\CalculationDebugDataFormat.xml'') as c
	order by c.CalculationDebugDataId
'

insert into #calculationdebugdata
exec (@sql)

insert into CalculationDebugData
select
	(select idnew from #treatment where idold = c.TreatmentId),
	FingerSector,
	IsFiltered,
	OrganComponent,
	Entropy,
	Form,
	Form2,
	Form1_1,
	Form1_2,
	Form1_3,
	Form1_4,
	Area,
	AverageIntensity,
	AI1,
	AI2,
	AI3,
	AI4,
	NS,
	Fractal,
	RingThickness,
	RingIntensity,
	BreakCoefficient,
	EPICBaseScore,
	EPICBonusScore,
	EPICScore,
	EPICRank,
	EPICScaledScore,
	SumZScore,
	LRScore,
	LRRank,
	LRScaledScore,
	Form2Prime
from #calculationdebugdata c

update c
set DeviceId = (select DeviceId from Device where SerialNumber = '01-0555')
from Calibration c
join Treatment t on t.CalibrationId = c.CalibrationId
where t.PatientId in (select idnew from #patient where PatientId = 1 or PatientId = 2)

update c
set DeviceId = (select DeviceId from Device where SerialNumber = '01-0777')
from Calibration c
join Treatment t on t.CalibrationId = c.CalibrationId
where t.PatientId = (select idnew from #patient where PatientId = 4)

update c
set DeviceId = (select DeviceId from Device where SerialNumber = '01-0888')
from Calibration c
join Treatment t on t.CalibrationId = c.CalibrationId
where t.PatientId = (select idnew from #patient where PatientId = 3)

update p
set LocationId = d.LocationId
from Patient p
join Treatment t on t.PatientId = p.PatientId
join Calibration c on c.CalibrationId = t.CalibrationId
join Device d on d.DeviceId = c.DeviceId

update c
set UniqueIdentifier = right(master.dbo.fn_varbintohexstr(convert(varbinary, d.UidQualifier)), 6) + '-' + lower(newid())
from Calibration c
join Device d on d.DeviceId = c.DeviceId

update i
set UniqueIdentifier = right(master.dbo.fn_varbintohexstr(convert(varbinary, d.UidQualifier)), 6) + '-' + lower(newid())
from ImageSet i
join Calibration c on c.ImageSetId = i.ImageSetId
join Device d on d.DeviceId = c.DeviceId

update t
set UniqueIdentifier = right(master.dbo.fn_varbintohexstr(convert(varbinary, d.UidQualifier)), 6) + '-' + lower(newid())
from Treatment t
join Calibration c on c.CalibrationId = t.CalibrationId
join Device d on d.DeviceId = c.DeviceId

update p
set UniqueIdentifier = right(master.dbo.fn_varbintohexstr(convert(varbinary, d.UidQualifier)), 6) + '-' + lower(newid())
from Patient p
join Treatment t on t.PatientId = p.PatientId
join Calibration c on c.CalibrationId = t.CalibrationId
join Device d on d.DeviceId = c.DeviceId

update i
set UniqueIdentifier = right(master.dbo.fn_varbintohexstr(convert(varbinary, d.UidQualifier)), 6) + '-' + lower(newid())
from ImageSet i
join Treatment t on t.EnergizedImageSetId = i.ImageSetId or t.FingerImageSetId = i.ImageSetId
join Calibration c on c.CalibrationId = t.CalibrationId
join Device d on d.DeviceId = c.DeviceId

drop table #calculationdebugdata
drop table #analysisresult
drop table #nbanalysisresult
drop table #severity
drop table #question
drop table #treatment
drop table #calibration
drop table #patient
