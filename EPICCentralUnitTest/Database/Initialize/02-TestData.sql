/*
	Script for adding test data required for the unit/integration tests.
*/

-- Create some scan rates.
insert into ScanRate (
	ScanType,
	RatePerScan,
	MinCountForRate,
	MaxCountForRate,
	EffectiveDate,
	IsActive
) values (
	1,
	8.00,
	1,
	50,
	'01/01/2012',
	1
)
go

insert into ScanRate (
	ScanType,
	RatePerScan,
	MinCountForRate,
	MaxCountForRate,
	EffectiveDate,
	IsActive
) values (
	1,
	7.50,
	50,
	100,
	'01/01/2012',
	1
)
go

insert into ScanRate (
	ScanType,
	RatePerScan,
	MinCountForRate,
	MaxCountForRate,
	EffectiveDate,
	IsActive
) values (
	1,
	7.00,
	100,
	1000,
	'01/01/2012',
	1
)
go

-- Create an end-user organization for EPIC.
insert into Organization (
	OrganizationType,
	Name,
	UniqueIdentifier,
	IsActive
) values (
	2,
	'EPIC',
	'000010-' + lower(newid()),
	1
)
go

-- Create a location for the new organization.
-- Just going to copy the one that exists for the EPIC Central organization.
insert into Location (
	OrganizationId,
	UniqueIdentifier,
	Name,
	AddressLine1,
	AddressLine2,
	City,
	State,
	Country,
	PostalCode,
	PhoneNumber,
	Latitude,
	Longitude,
	IsActive
) select
	(select OrganizationId from Organization where Name = 'EPIC'),
	'000020-' + lower(newid()),
	'Home Office',
	AddressLine1,
	AddressLine2,
	City,
	State,
	Country,
	PostalCode,
	PhoneNumber,
	Latitude,
	Longitude,
	1
from Location
where Name = 'Host Site'
go

-- Create an epicadmin user.
insert into [User] (
	OrganizationId,
	Username,
	Password,
	EmailAddress,
	FirstName,
	LastName,
	CreateTime,
	IsActive
) select
	OrganizationId,
	'epicadmin',
	'',
	'EPICAdmin4877@epicdiagnostics.com',
	'EPIC',
	'Admin',
	getutcdate(),
	1
from Organization
where Name = 'EPIC'
go

-- Create a simple user.
insert into [User] (
	OrganizationId,
	Username,
	Password,
	EmailAddress,
	FirstName,
	LastName,
	CreateTime,
	IsActive
) select
	OrganizationId,
	'simpleuser',
	'',
	'simpleuser@epicdiagnostics.com',
	'Simple',
	'User',
	getutcdate(),
	1
from Organization
where Name = 'EPIC'
go

-- Create user password salt for each user.
insert into UserSalt (
	UserId,
	Salt
) select
	UserId,
	right(upper(master.dbo.fn_varbintohexstr(CRYPT_GEN_RANDOM(2048))),4096)
	-- The above creates a random set of 2048 bytes of data and converts it
	-- to a hex equivalent string.
from [User]
where Username = 'epicadmin' or Username = 'simpleuser'
go

-- Set the password for each user to "$Secret0".
update u
set u.Password = right(master.dbo.fn_varbintohexstr(hashbytes('SHA2_512', '$Secret0' + s.Salt)),128),
	u.LastPasswordChangeTime = getutcdate()
from [User] u
join UserSalt s on s.UserId = u.UserId
where u.Username = 'epicadmin' or u.Username = 'simpleuser'
go

-- Set role for the admin user.
insert into UserRole (
	UserId,
	RoleId
) values (
	(select UserId from [User] where Username = 'epicadmin'),
	(select RoleId from [Role] where Name = 'Organization Administrator')
)
go

-- Set role for the simple user.
insert into UserRole (
	UserId,
	RoleId
) values (
	(select UserId from [User] where Username = 'simpleuser'),
	(select RoleId from [Role] where Name = 'Simple User')
)
go

-- Create user settings for admin user.
-- Using an existing support email account and password.
insert into UserSetting (UserId, Name, Value)
select
	u.UserId,
	s.Name,
	s.Value
from [User] u
cross join (select * from
	 (
		select 'Language', 'en-US'
		union all
		select 'Region', 'America/Phoenix'
		union all
		select 'RegionAuto', 'True'
		union all
		select 'SupportUser', 'EPICAdmin4877'
		union all
		select 'SupportPass', 'C47EC6E12E2DCA94B2EAB898B5330E139632815865E60E7EE26F340636E81A15'
	 ) as x (Name, Value)) s
where u.Username = 'epicadmin'
go

-- Create user settings for simple user.
insert into UserSetting (UserId, Name, Value)
select
	u.UserId,
	s.Name,
	s.Value
from [User] u
cross join (select * from
	 (
		select 'Language', 'en-US'
		union all
		select 'Region', 'America/Phoenix'
		union all
		select 'RegionAuto', 'True'
		union all
		select 'SupportUser', 'pauljones13263'
		union all
		select 'SupportPass', '6FF138A5FE1DDB3EB0574DE6593D08615A8C1393D362EA05909811386F5EF2D9'
	 ) as x (Name, Value)) s
where u.Username = 'simpleuser'
go

-- Assign the simple user to the one location.
insert into UserAssignedLocation (
	UserId,
	LocationId
) values (
	(select UserId from [User] where Username = 'simpleuser'),
	(select LocationId from Location where Name = 'Home Office')
)
go

-- Create a couple credit cards.
insert into CreditCard (
	AuthorizeId,
	FirstName,
	LastName,
	AccountNumber,
	Address
) values (
	'1234567',
	'Simple',
	'User',
	'6239',
	'123 Main Street'
) , (
	'0987654',
	'Simple',
	'User',
	'0728',
	'123 Main Street'
)
go

-- Link the credit cards to simple user.
insert into UserCreditCard (
	UserId,
	CreditCardId
) select
	(select UserId from [User] where Username = 'simpleuser'),
	CreditCardId
from CreditCard
go

-- Add a device.
insert into Device (
	LocationId,
	UniqueIdentifier,
	DeviceState,
	SerialNumber,
	DateIssued,
	RevisionLevel,
	ScansAvailable,
	ScansCompleted,
	CurrentStatus,
	LastReportTime
) values (
	(select LocationId from Location where Name = 'Home Office'),
	'000030-' + lower(newid()),
	2, -- Active
	'01-0999',
	'7/18/2012',
	'2.0',
	100,
	0,
	'Ping',
	getutcdate()
)
go

-- Add a purchase history for the device.
insert into PurchaseHistory (
	LocationId,
	DeviceId,
	UserId,
	PurchaseTime,
	ScansPurchased,
	AmountPaid,
	TransactionId,
	PurchaseNotes
) values (
	(select LocationId from Location where Name = 'Home Office'),
	(select DeviceId from Device where SerialNumber = '01-0999'),
	(select UserId from [User] where Username = 'echost'),
	'7/18/2012',
	100,
	0,
	'',
	'New Device'
)
go

-- Add another device.
insert into Device (
	LocationId,
	UniqueIdentifier,
	DeviceState,
	SerialNumber,
	DateIssued,
	RevisionLevel,
	ScansAvailable,
	ScansCompleted,
	CurrentStatus,
	LastReportTime
) values (
	(select LocationId from Location where Name = 'Home Office'),
	'000030-' + lower(newid()),
	2, -- Active
	'01-0888',
	'8/20/2012',
	'2.1',
	90,
	10,
	'Ping',
	getutcdate()
)
go

-- Add a purchase history for the device.
insert into PurchaseHistory (
	LocationId,
	DeviceId,
	UserId,
	PurchaseTime,
	ScansPurchased,
	AmountPaid,
	TransactionId,
	PurchaseNotes
) values (
	(select LocationId from Location where Name = 'Home Office'),
	(select DeviceId from Device where SerialNumber = '01-0888'),
	(select UserId from [User] where Username = 'echost'),
	'8/20/2012',
	100,
	0,
	'',
	'New Device'
)
go

-- Create another end-user organization.
insert into Organization (
	OrganizationType,
	Name,
	UniqueIdentifier,
	IsActive
) values (
	2,
	'Acme Health',
	'000010-' + lower(newid()),
	1
)
go

-- Create a location for the new organization.
insert into Location (
	OrganizationId,
	UniqueIdentifier,
	Name,
	AddressLine1,
	AddressLine2,
	City,
	State,
	Country,
	PostalCode,
	PhoneNumber,
	Latitude,
	Longitude,
	IsActive
) values (
	(select OrganizationId from Organization where Name = 'Acme Health'),
	'000020-' + lower(newid()),
	'Desert Springs',
	'2075 East Flamingo Road',
	null,
	'Las Vegas',
	'NV',
	'US',
	'89119',
	'7027338800',
	36.113634,
	-115.125727,
	1
)
go

-- Create another location for the new organization.
insert into Location (
	OrganizationId,
	UniqueIdentifier,
	Name,
	AddressLine1,
	AddressLine2,
	City,
	State,
	Country,
	PostalCode,
	PhoneNumber,
	Latitude,
	Longitude,
	IsActive
) values (
	(select OrganizationId from Organization where Name = 'Acme Health'),
	'000020-' + lower(newid()),
	'Renown',
	'1155 Mill Street',
	null,
	'Reno',
	'NV',
	'US',
	'89502',
	'7759824100',
	39.526353,
	-119.795437,
	1
)
go

-- Create an admin user.
insert into [User] (
	OrganizationId,
	Username,
	Password,
	EmailAddress,
	FirstName,
	LastName,
	CreateTime,
	IsActive
) select
	OrganizationId,
	'acmeadmin',
	'',
	'acmeadmin@epicdiagnostics.com',
	'Acme',
	'Admin',
	getutcdate(),
	1
from Organization
where Name = 'Acme Health'
go

-- Create a simple user.
insert into [User] (
	OrganizationId,
	Username,
	Password,
	EmailAddress,
	FirstName,
	LastName,
	CreateTime,
	IsActive
) select
	OrganizationId,
	'joe.acme',
	'',
	'joe.acme@epicdiagnostics.com',
	'Joe',
	'Acme',
	getutcdate(),
	1
from Organization
where Name = 'Acme Health'
go

-- Create another simple user.
insert into [User] (
	OrganizationId,
	Username,
	Password,
	EmailAddress,
	FirstName,
	LastName,
	CreateTime,
	IsActive
) select
	OrganizationId,
	'jane.acme',
	'',
	'jane.acme@epicdiagnostics.com',
	'Jane',
	'Acme',
	getutcdate(),
	1
from Organization
where Name = 'Acme Health'
go

-- Create user password salt for each user.
insert into UserSalt (
	UserId,
	Salt
) select
	UserId,
	right(upper(master.dbo.fn_varbintohexstr(CRYPT_GEN_RANDOM(2048))),4096)
	-- The above creates a random set of 2048 bytes of data and converts it
	-- to a hex equivalent string.
from [User]
where Username = 'acmeadmin' or Username = 'joe.acme' or Username = 'jane.acme'
go

-- Set the password for each user to "$Secret0".
update u
set u.Password = right(master.dbo.fn_varbintohexstr(hashbytes('SHA2_512', '$Secret0' + s.Salt)),128),
	u.LastPasswordChangeTime = getutcdate()
from [User] u
join UserSalt s on s.UserId = u.UserId
where u.Username = 'acmeadmin' or u.Username = 'joe.acme' or u.Username = 'jane.acme'
go

-- Set role for the admin user.
insert into UserRole (
	UserId,
	RoleId
) values (
	(select UserId from [User] where Username = 'acmeadmin'),
	(select RoleId from [Role] where Name = 'Organization Administrator')
)
go

-- Set role for the simple users.
insert into UserRole (
	UserId,
	RoleId
) values (
	(select UserId from [User] where Username = 'joe.acme'),
	(select RoleId from [Role] where Name = 'Simple User')
)
go

insert into UserRole (
	UserId,
	RoleId
) values (
	(select UserId from [User] where Username = 'jane.acme'),
	(select RoleId from [Role] where Name = 'Simple User')
)
go

-- Create user settings for the users.
insert into UserSetting (UserId, Name, Value)
select
	u.UserId,
	s.Name,
	s.Value
from [User] u
cross join (select * from
	 (
		select 'Language', 'en-US'
		union all
		select 'Region', 'America/Los_Angeles'
		union all
		select 'RegionAuto', 'True'
	 ) as x (Name, Value)) s
where u.Username = 'acmeadmin' or u.Username = 'joe.acme' or u.Username = 'jane.acme'
go

-- Assign the simple users to locations.
insert into UserAssignedLocation (
	UserId,
	LocationId
) values (
	(select UserId from [User] where Username = 'joe.acme'),
	(select LocationId from Location where Name = 'Desert Springs')
)
go

insert into UserAssignedLocation (
	UserId,
	LocationId
) values (
	(select UserId from [User] where Username = 'joe.acme'),
	(select LocationId from Location where Name = 'Renown')
)
go

insert into UserAssignedLocation (
	UserId,
	LocationId
) values (
	(select UserId from [User] where Username = 'jane.acme'),
	(select LocationId from Location where Name = 'Desert Springs')
)
go

-- Add a device.
insert into Device (
	LocationId,
	UniqueIdentifier,
	DeviceState,
	SerialNumber,
	DateIssued,
	RevisionLevel,
	ScansAvailable,
	ScansCompleted,
	CurrentStatus,
	LastReportTime
) values (
	(select LocationId from Location where Name = 'Desert Springs'),
	'000030-' + lower(newid()),
	2, -- Active
	'01-0777',
	'7/20/2012',
	'2.0',
	100,
	0,
	'Ping',
	getutcdate()
)
go

-- Add a purchase history for the device.
insert into PurchaseHistory (
	LocationId,
	DeviceId,
	UserId,
	PurchaseTime,
	ScansPurchased,
	AmountPaid,
	TransactionId,
	PurchaseNotes
) values (
	(select LocationId from Location where Name = 'Desert Springs'),
	(select DeviceId from Device where SerialNumber = '01-0777'),
	(select UserId from [User] where Username = 'echost'),
	'7/20/2012',
	100,
	0,
	'',
	'New Device'
)
go

-- Add another device.
insert into Device (
	LocationId,
	UniqueIdentifier,
	DeviceState,
	SerialNumber,
	DateIssued,
	RevisionLevel,
	ScansAvailable,
	ScansCompleted,
	CurrentStatus,
	LastReportTime
) values (
	(select LocationId from Location where Name = 'Desert Springs'),
	'000030-' + lower(newid()),
	2, -- Active
	'01-0666',
	'8/27/2012',
	'2.1',
	80,
	20,
	'Ping',
	getutcdate()
)
go

-- Add a purchase history for the device.
insert into PurchaseHistory (
	LocationId,
	DeviceId,
	UserId,
	PurchaseTime,
	ScansPurchased,
	AmountPaid,
	TransactionId,
	PurchaseNotes
) values (
	(select LocationId from Location where Name = 'Desert Springs'),
	(select DeviceId from Device where SerialNumber = '01-0666'),
	(select UserId from [User] where Username = 'echost'),
	'8/27/2012',
	100,
	0,
	'',
	'New Device'
)
go

-- Add another device.
insert into Device (
	LocationId,
	UniqueIdentifier,
	DeviceState,
	SerialNumber,
	DateIssued,
	RevisionLevel,
	ScansAvailable,
	ScansCompleted,
	CurrentStatus,
	LastReportTime
) values (
	(select LocationId from Location where Name = 'Renown'),
	'000030-' + lower(newid()),
	2, -- Active
	'01-0555',
	'8/13/2012',
	'2.1',
	75,
	25,
	'Ping',
	getutcdate()
)
go

-- Add a purchase history for the device.
insert into PurchaseHistory (
	LocationId,
	DeviceId,
	UserId,
	PurchaseTime,
	ScansPurchased,
	AmountPaid,
	TransactionId,
	PurchaseNotes
) values (
	(select LocationId from Location where Name = 'Renown'),
	(select DeviceId from Device where SerialNumber = '01-0555'),
	(select UserId from [User] where Username = 'echost'),
	'8/13/2012',
	100,
	0,
	'',
	'New Device'
)
go

-- TODO: Create an exception.
