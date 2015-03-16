--- The Buddies ---
--- Stored Procedures ---

--- Start Procedure GetClasses ---
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'GetClasses')
                    AND type IN ( N'P', N'PC' ) ) 
DROP PROCEDURE GetClasses;
GO

CREATE PROCEDURE GetClasses AS
(
	SELECT	(Department + ' ' + CourseNum) AS Course, CourseName AS 'Course Name', '1' AS Sections, '0' AS Online
	FROM	CLASS
)
GO
--- End Procedure GetClasses ---


--- Start Procedure GetProfessorLastName ---
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'GetProfessorLastName')
                    AND type IN ( N'P', N'PC' ) ) 
DROP PROCEDURE GetProfessorLastName;
GO

CREATE PROCEDURE GetProfessorLastName AS
(
	SELECT	LastName
	FROM	PROFESSOR
)
GO
--- End Procedure GetProfessorLastName ---


--- Start Procedure AddProfessor ---
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'AddProfessor')
                    AND type IN ( N'P', N'PC' ) ) 
DROP PROCEDURE AddProfessor;
GO

CREATE PROCEDURE AddProfessor
    @TeacherID VARCHAR(6),
  	@FirstName VARCHAR(255),
	@LastName VARCHAR(255),
	@YearlyCreditHours DECIMAL(5,2),
	@Associates BIT,
	@Bachelors BIT,
	@Masters BIT,
	@PhD BIT
AS
BEGIN
	INSERT INTO PROFESSOR
	       (TeacherID, FirstName, LastName, YearlyCreditHours, Associates, Bachelors, Masters, PhD)
	VALUES (@TeacherID, @FirstName, @LastName, @YearlyCreditHours, @Associates, @Bachelors, @Masters, @PhD)
END
GO
--- End Procedure AddProfessor ---


--- Start Procedure EditProfessor ---
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'EditProfessor')
                    AND type IN ( N'P', N'PC' ) ) 
DROP PROCEDURE EditProfessor;
GO

CREATE PROCEDURE EditProfessor
    @TeacherID VARCHAR(6),
  	@FirstName VARCHAR(255),
	@LastName VARCHAR(255),
	@YearlyCreditHours DECIMAL(5,2),
	@Associates BIT,
	@Bachelors BIT,
	@Masters BIT,
	@PhD BIT
AS
BEGIN
	UPDATE Professor
	SET FirstName = @FirstName, LastName = @LastName, YearlyCreditHours = @YearlyCreditHours, 
		Associates = @Associates, Bachelors = @Bachelors, Masters = @Masters, PhD = @PhD
	WHERE TeacherID = @TeacherID
END
GO
--- End Procedure EditProfessor ---


--- Start Procedure DeleteProfessor ---
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'DeleteProfessor')
                    AND type IN ( N'P', N'PC' ) ) 
DROP PROCEDURE DeleteProfessor;
GO

CREATE PROCEDURE DeleteProfessor
    @TeacherID VARCHAR(6)
AS
BEGIN
	DELETE FROM PROFESSOR
	WHERE TeacherID = @TeacherID;
END
GO
--- End Procedure DeleteProfessor ---


--- Start Procedure AddClass ---
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'AddClass')
                    AND type IN ( N'P', N'PC' ) ) 
DROP PROCEDURE AddClass;
GO

CREATE PROCEDURE AddClass
	@Department VARCHAR(255),
	@CourseNum VARCHAR(255),
	@CourseName VARCHAR(255),
	@StudentCreditHours DECIMAL(5,2),
	@TeacherCreditHours DECIMAL(5,2),
	@IsGradClass BIT
AS
BEGIN
	INSERT INTO CLASS
	       (Department, CourseNum, CourseName, StudentCreditHours, TeacherCreditHours, IsGradClass)
	VALUES (@Department, @CourseNum, @CourseName, @StudentCreditHours, @TeacherCreditHours, @IsGradClass)
END
GO
--- End Procedure AddClass ---


--- Start Procedure EditClass ---
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'EditClass')
                    AND type IN ( N'P', N'PC' ) ) 
DROP PROCEDURE EditClass;
GO

CREATE PROCEDURE EditClass
	@Department VARCHAR(255),
	@CourseNum VARCHAR(255),
	@CourseName VARCHAR(255),
	@StudentCreditHours DECIMAL(5,2),
	@TeacherCreditHours DECIMAL(5,2),
	@IsGradClass BIT,
	@ClassID INT
AS
BEGIN
	UPDATE CLASS
	 SET      Department = @Department, CourseNum = @CourseNum, CourseName = @CourseName, 
			  StudentCreditHours = @StudentCreditHours, TeacherCreditHours = @TeacherCreditHours, IsGradClass = @IsGradClass
	WHERE ClassID = @ClassID
END
GO
--- End Procedure EditClass ---


--- Start Procedure RemoveClass ---
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'RemoveClass')
                    AND type IN ( N'P', N'PC' ) ) 
DROP PROCEDURE RemoveClass;
GO

CREATE PROCEDURE RemoveClass
	@ClassID INT
AS
BEGIN
	DELETE FROM CLASS
	WHERE ClassID = @ClassID
END
GO
--- End Procedure  RemoveClass ---

--- Start Procedure GetAllClasses ---
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'GetAllClasses')
                    AND type IN ( N'P', N'PC' ) ) 
DROP PROCEDURE GetAllClasses;
GO

CREATE PROCEDURE GetAllClasses AS
(
	SELECT Department, CourseNum, CourseName, StudentCreditHours, TeacherCreditHours, IsGradClass
	FROM	CLASS
)
GO
--- End Procedure  GetAllClasses ---

--- Start Procedure GetAllProfessors ---
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'GetAllProfessors')
                    AND type IN ( N'P', N'PC' ) ) 
DROP PROCEDURE GetAllProfessors;
GO

CREATE PROCEDURE GetAllProfessors AS
(
	SELECT TeacherID, FirstName, LastName, YearlyCreditHours, Associates, Bachelors, Masters, PhD
	FROM	PROFESSOR
)
GO
--- End Procedure  GetAllProfessors ---

--- Start Procedure GetCourseNumAndClassName ---
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'GetCourseNumAndClassName')
                    AND type IN ( N'P', N'PC' ) ) 
DROP PROCEDURE GetCourseNumAndClassName;
GO

CREATE PROCEDURE GetCourseNumAndClassName AS
(
	SELECT	(Department + ' ' + CourseNum + ' - ' + CourseName) AS Course, ClassID
	FROM	CLASS
)
GO
--- End Procedure GetCourseNumAndClassName ---