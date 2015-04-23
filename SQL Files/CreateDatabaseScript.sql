--CREATE DATABASE 480-Buddies

--USE 480-Buddies


--- BEGIN CREATING CLASS TABLE ---
CREATE TABLE CLASS
(
	ClassID INT IDENTITY(1,1) PRIMARY KEY,
	Department VARCHAR(255) NOT NULL,
	CourseNum VARCHAR(255) NOT NULL,
	CourseName VARCHAR(255) NOT NULL,
	StudentCreditHours DECIMAL(5,2),
	TeacherCreditHours DECIMAL(5,2),
	IsGradClass BIT
)
GO
--- END CREATING CLASS TABLE ---


--- BEGIN CREATING PROFESSOR TABLE ---
CREATE TABLE PROFESSOR
(
	TeacherID VARCHAR(6) PRIMARY KEY,
	FirstName VARCHAR(255) NOT NULL,
	LastName VARCHAR(255) NOT NULL,
	YearlyCreditHours DECIMAL(5,2),
	ProfessorRank VARCHAR(255) NOT NULL
)
GO
--- END CREATING PROFESSOR TABLE ---


--- BEGIN CREATING FACULTY_HOURS TABLE ---
CREATE TABLE FACULTY_HOURS
(
	TeacherID VARCHAR(6),
	DayOfWeek VARCHAR(15) NOT NULL,
	TimeOfDay INT NOT NULL,
	StartTime INT NOT NULL,
	EndTime INT NOT NULL,
	WeeklyOfficeHours INT
)
GO
--- END CREATING FACULTY_HOURS TABLE ---


--- BEGIN CREATING ROOMS TABLE ---
CREATE TABLE ROOMS
(
	RoomID INT IDENTITY(1,1) PRIMARY KEY,
	BuildingName VARCHAR(255) NOT NULL,
	RoomNumber VARCHAR(10) NOT NULL,
	RoomColor INT,
	TextColor VARCHAR(1) NOT NULL
)
GO
--- END CREATING ROOMS TABLE ---


--- BEGIN CREATING SCHEDULE TABLE ---
CREATE TABLE SCHEDULE
(
	ClassID INT,
	SectionNum VARCHAR(2) NOT NULL,
	StartTime INT,
	EndTime INT,
	Mon BIT,
	Tues BIT,
	Wed BIT,
	Thurs BIT,
	Fri BIT,
	Sat BIT,
	Sun BIT,
	TeacherID VARCHAR(6),
	RoomID INT,
	Term VARCHAR(6) NOT NULL,
	TermYear VARCHAR(4) NOT NULL,
	CONSTRAINT pk_Class PRIMARY KEY (ClassID, SectionNum, Term, TermYear)
)
GO
--- END CREATING SCHEDULE TABLE ---


--- BEGIN CREATING PROFESSOR_RANKS TABLE ---
CREATE TABLE PROFESSOR_RANKS
(
	RankID INT IDENTITY(1,1) PRIMARY KEY,
	ProfRank VARCHAR(255) NOT NULL
)
GO
--- END CREATING PROFESSOR_RANKS TABLE ---



-- BEGIN PROFESSOR FirstNameLastName INDEX Statement --
CREATE INDEX ProfFirstNameLastName
ON PROFESSOR (LastName, FirstName)
GO
-- END PROFESSOR FirstNameLastName INDEX Statement --


-- BEGIN CLASS DeptCourseNumUnique INDEX Statement --
CREATE UNIQUE INDEX DeptCourseNumUnique
ON CLASS (Department, CourseNum)
GO
-- END PROFESSOR DeptCourseNumUnique INDEX Statement --


-- BEGIN CLASS DeptCourseNumUnique INDEX Statement --
CREATE UNIQUE INDEX RoomNameAndID
ON ROOMS (BuildingName, RoomNumber)
GO
-- END PROFESSOR DeptCourseNumUnique INDEX Statement --

-- BEGIN Create TIMES Table -- 
CREATE TABLE TIMES
(
	Time varchar(5) PRIMARY KEY
)
GO

INSERT INTO TIMES
VALUES	('8:00'),
		('8:30'),
		('9:00'),
		('9:30'),
		('10:00'),
		('10:30'),
		('11:00'),
		('11:30'),
		('12:00'),
		('12:30'),
		('13:00'),
		('13:30'),
		('14:00'),
		('14:30'),
		('15:00'),
		('15:30'),
		('16:00'),
		('16:30'),
		('17:00'),
		('17:30'),
		('18:00'),
		('18:30'),
		('19:00'),
		('19:30'),
		('20:00'),
		('20:30'),
		('21:00'),
		('21:30')
GO
-- END Create TIMES table

--- BEGIN PROFESSOR_RANKS Insert Statement ---
INSERT INTO PROFESSOR_RANKS
VALUES

('Professor'),
('Associate'),
('Assistant'),
('Instructor'),
('Adjunct');
GO
--- END PROFESSOR_RANKS Insert Statement ---