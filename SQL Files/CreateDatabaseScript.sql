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
	@ProfessorRank VARCHAR(255) NOT NULL
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
	CONSTRAINT pk_Class PRIMARY KEY (ClassID, SectionNum)
)
GO
--- END CREATING SCHEDULE TABLE ---


--- BEGIN CREATING PROFESSOR_RANKS TABLE ---
CREATE TABLE PROFESSOR_RANKS
(
	ProfRank VARCHAR(255) NOT NULL PRIMARY KEY
)
GO
--- END CREATING PROFESSOR_RANKS TABLE ---


--- Begin Class Insert Statement ---
INSERT INTO CLASS
VALUES

('CSCI','027','ACM',3,3,0),
('CSCI','148','Educational Technology',3,3,0),
('CSCI','149','Computer Concepts for Business',3,3,0),
('CSCI','150','Introduction to Computers',3,3,0),
('CSCI','151','Word Processing',3,3,0),
('CSCI','152','Presentation Graphics',3,3,0),
('CSCI','153','PC Operating Systems',3,3,0),
('CSCI','155','Spreadsheet Design',3,3,0),
('CSCI','157','Database Applications',3,3,0),
('CSCI','158','Web Page Design',3,3,0),
('CSCI','159','Microcomputer Topics',3,3,0),
('CSCI','190','Computer Concepts w/ Programming',3,3,0),
('CSCI','191','Visual Basic Programming',3,3,0),
('CSCI','192','Introductory Java Programming',3,3,0),
('CSCI','193','Introduction to Unix',3,3,0),
('CSCI','240','Computer Software Design I',3,3,0),
('CSCI','241','Computer Software Design II',3,3,0),
('CSCI','270','Web Page Development',3,3,0),
('CSCI','285','SQL Programming',3,3,0),
('CSCI','299','Topics in Computer Science & Technology',3,3,0),
('CSCI','300','Discrete Structures',3,3,0),
('CSCI','325','Operating Systems',3,3,0),
('CSCI','330','Applied Operations Research',3,3,0),
('CSCI','345','Data Communications',3,3,0),
('CSCI','355','Computer Organization',3,3,0),
('CSCI','360','Data Structures',3,3,0),
('CSCI','374','Internet Programming Unix',3,3,0),
('CSCI','410','Information Security Fundamentals',3,3,0),
('CSCI','412','Managing Business Networks',3,3,0),
('CSCI','414','Secure eCommerce',3,3,0),
('CSCI','416','Computer and Network Forensics',3,3,0),
('CSCI','445','Computer Networking',3,3,0),
('CSCI','460','Computer Systems Administration',3,3,0),
('CSCI','470','Java-Based Web App Development',3,3,0),
('CSCI','475','Internet Programming Windows',3,3,0),
('CSCI','480','Software Engineering',3,3,0),
('CSCI','490','Database Management Systems',4,4,0),
('CSCI','496','Information Assurance Capstone',3,3,0),
('CSCI','498','Internship in Computer Science',3,3,0),
('CSCI','499','Adv Topics in Computer Science & Technology',3,3,0),
('CSCI','510','Applied Security Principles',3,3,1),
('CSCI','523','Statistical Methods for Business Analytics',3,3,1),
('CSCI','560','Secure Coding',3,3,1),
('CSCI','580','Advanced Software Engineering',3,3,1),
('CSCI','590','Data Mining for Decision Making',3,3,1),
('CSCI','613','Risk Management for Information Systems',3,3,1),
('CSCI','690','Data Visualization and Predictive Analytics',3,3,1),
('CSCI','698','Capstone Project',3,3,1);
GO
-- END Class Insert Statement ---


--- BEGIN PROFESSOR Insert Statement ---
INSERT INTO PROFESSOR
VALUES

('000001', 'Mary Jo', 'Geise', 24, 'Professor'),
('000002', 'Helen', 'Schneider', 24, 'Professor'),
('000003', 'Craig', 'Gunnett', 24, 'Associate'),
('000004', 'Jordan', 'Ringenberg', 24, 'Assistant'),
('000005', 'Paul', 'Langhals', 24, 'Instructor'),
('000006', 'Heda', 'Samimi', 24, 'Instructor'),
('000007', 'Bob', 'Wardzala', 24, 'Adjunct'),
('000008', 'Bill', 'Baker', 24, 'Adjunct');
GO
--- END PROFESSOR Insert Statement ---

-- BEGIN ROOMS Insert Statement --
INSERT INTO ROOMS
VALUES
	('Davis', '196', -16744448),
	('Main', '301', -128),
	('Davis', '179', -8323200),
	('Main', '309', -256),
	('INET', 'INET', -8355585),
	('BCHS', '100', -8323073),
	('BCHS', '107', -16776961);
GO
-- END ROOMS Insert Statement --

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
