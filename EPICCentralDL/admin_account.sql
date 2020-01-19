set identity_insert EC_Customer on
INSERT INTO EC_Customer (CustomerId,OrganizationName,CustomerUniqueKey,ContactEmailAddress,ContactFirstName,ContactLastName,Active,UserId)
Values(0,'EPIC Research & Diagnostics, Inc.','1DAE4B0B-94D5-42B5-BE8D-070D352A62B2','test@epicdiagnostics.com','EPIC','Admin',1,0)
set identity_insert EC_Customer off
set identity_insert [EC_CustomerLocation] on
INSERT INTO [EC_CustomerLocation] (CustomerLocationId,LocationUniqueKey,CustomerId,LocationName,AddressLine1,AddressLine2,AddressCity,AddressState,AddressPostalCode,PhoneNumber,ScansAvailable,ScansUsed,Active)
Values(0,'486C4201-C03E-496E-9121-66A5F9937363',0,'EPIC Offices','','','','','','',0,0,1)
set identity_insert [EC_CustomerLocation] off
set identity_insert EC_User on
INSERT INTO EC_User (UserId,Username,Password,LocationId,EmailAddress,FirstName,LastName,IsRetailer,IsAdmin,IsActive,ResetKey,SecurityQuestion1,SecurityAnswer1,Roles)
values(0,'EPICAdmin','ea',0,'test@epicdiagnostics.com','EPIC','Admin',0,1,1,'','','','')
set identity_insert EC_User off
