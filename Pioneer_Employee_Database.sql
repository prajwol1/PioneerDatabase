CREATE TABLE EmployeeDetail(
	EmployeeID INTEGER IDENTITY PRIMARY KEY,
	FirstName varchar(25), 
	LastName varchar(25), 
	Email varchar(20), 
	ContactNumber BIGINT,
	AlternateContactNumber BIGINT NULL,
	[Address] varchar (50), 
	AlternateAddress varchar(50) NULL,
	CurrentCountry varchar(10),
	HomeCountry varchar(10),
	ZipCode int;

CREATE TABLE CompanyDetail(
	 CompanyID INTEGER IDENTITY PRIMARY KEY,
	 EmployerName varchar(50), 
	 ContactNumber BIGINT, 
	 [Location] varchar(50), 
	 Website nvarchar(25),
	 EmployeeID INTEGER REFERENCES EmployeeDetail(EmployeeID));

CREATE TABLE ProjectDetail (
		ProjectID INTEGER IDENTITY PRIMARY KEY,
		ProjectName varchar(25),
		ClientName varchar(25),
		[Location] varchar(50),
		Roles varchar(25),
		EmployeeID INTEGER REFERENCES EmployeeDetail(EmployeeID));

CREATE TABLE TechnicalDetail(
	 UI varchar(10),
	 ProgrammingLanguage varchar(10),
	 [Database] varchar (10),
	 EmployeeID INTEGER REFERENCES EmployeeDetail(EmployeeID));

CREATE TABLE EducationDetail(
	CourseType varchar(25),
	YearOfPass int,
	CourseSpecilization varchar(20),
	EmployeeID INTEGER PRIMARY KEY REFERENCES EmployeeDetail(EmployeeID))