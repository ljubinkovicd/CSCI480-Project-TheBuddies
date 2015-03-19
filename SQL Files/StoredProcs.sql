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


--- Start Procedure GetProfessorName ---
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'GetProfessorName')
                    AND type IN ( N'P', N'PC' ) ) 
DROP PROCEDURE GetProfessorName;
GO

CREATE PROCEDURE GetProfessorName AS
(
	SELECT	TeacherID, (FirstName + ' ' + LastName) AS 'Professor'
	FROM	PROFESSOR
)
GO
--- End Procedure GetProfessorName ---


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
	UPDATE PROFESSOR
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
	@OrigDepartment VARCHAR(255),
	@OrigCourseNum VARCHAR(255)
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
	SELECT ClassID, Department, CourseNum, CourseName, StudentCreditHours, TeacherCreditHours, IsGradClass
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

-- Start Procedure GetEditInfo --
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'GetEditInfo')
                    AND type IN ( N'P', N'PC' ) ) 
DROP PROCEDURE GetEditInfo;
GO

CREATE PROCEDURE GetEditInfo 
	@department varchar(255), 
	@courseNum varchar(255),
	@sectionNum int
AS
BEGIN
	DECLARE	@teacherID VARCHAR(6)
	SELECT	@teacherID = (	SELECT	TeacherID
							FROM	SCHEDULE
							WHERE	ClassID = (	SELECT ClassID
												FROM	CLASS
												WHERE	Department = @department
												AND		CourseNum = @courseNum)
							AND		SectionNum = @sectionNum)

	SELECT	(SELECT		CourseName
				FROM	CLASS
				WHERE	Department = @department
				AND		CourseNum = @courseNum) AS CourseName, 
			SectionNum, StartTime, EndTime, Mon, Tues, Wed, Thurs, Fri, Sat, Sun,
			(SELECT		(FirstName + ' ' + LastName)
				FROM	PROFESSOR
				WHERE	TeacherID = @teacherID) AS Professor,
			RoomID
	FROM	SCHEDULE
	WHERE	ClassID = (	SELECT ClassID
						FROM	CLASS
						WHERE	Department = @department
						AND		CourseNum = @courseNum)
	AND		SectionNum = @sectionNum
END
GO
-- End Procedure GetEditInfo

-- Start Procedure InsertProfessorToSchedule --
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'InsertProfessorToSchedule')
                    AND type IN ( N'P', N'PC' ) ) 
DROP PROCEDURE InsertProfessorToSchedule;
GO

CREATE PROCEDURE InsertProfessorToSchedule 
	@department varchar(255), 
	@courseNum varchar(255),
	@sectionNum int,
	@firstName varchar(255),
	@lastName varchar(255)
AS
BEGIN
	DECLARE @classID int,
			@teacherID VARCHAR(6)
	SELECT	@teacherID = (	SELECT	TeacherID
							FROM	PROFESSOR
							WHERE	FirstName = @firstName
							AND		LastName = @lastName)
	SELECT	@classID = (	SELECT	ClassID
							FROM	CLASS
							WHERE	Department = @department
							AND		CourseNum = @courseNum)

	IF EXISTS (	SELECT	*
				FROM	SCHEDULE
				WHERE	ClassID = @classID
				AND		SectionNum = @sectionNum)
	BEGIN
		UPDATE	SCHEDULE
		SET		TeacherID = @teacherID
		WHERE	ClassID = @classID
		AND		SectionNum = @sectionNum
	END

	ELSE
	BEGIN
		INSERT INTO SCHEDULE (ClassID, SectionNum, TeacherID)
		VALUES (@classID, @sectionNum, @teacherID)
	END
END
GO
-- End Procedure InsertProfessorToSchedule

-- Start Procedure GetScheduleForLabels --
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'GetScheduleForLabels')
                    AND type IN ( N'P', N'PC' ) ) 
DROP PROCEDURE GetScheduleForLabels;
GO

CREATE PROCEDURE GetScheduleForLabels AS
BEGIN
	SELECT	(C.Department + ' ' + C.CourseNum + '.' + CONVERT(varchar,S.SectionNum)) AS Course,
			(P.FirstName + ' ' + P.LastName) AS Professor,
			C.StudentCreditHours AS StudentCredits
	FROM	SCHEDULE S
	JOIN	CLASS C ON S.ClassID = C.ClassID
	LEFT JOIN	PROFESSOR P ON S.TeacherID = P.TeacherID
END
-- End Procedure GetScheduleForLabels --

-- Start Procedure InsertToSchedule --
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'InsertToSchedule')
                    AND type IN ( N'P', N'PC' ) ) 
DROP PROCEDURE InsertToSchedule;
GO

CREATE PROCEDURE InsertToSchedule 
	@department varchar(255),
	@courseNum varchar(255),
	@sectionNum int,
	@startTime int,
	@endTime int,
	@mon bit,
	@tues bit,
	@wed bit,
	@thurs bit,
	@fri bit,
	@sat bit,
	@sun bit,
	@teacherID varchar(6),
	@roomID int
AS
BEGIN
	DECLARE @classID int
	SELECT	@classID = (	SELECT	ClassID	
							FROM	CLASS
							WHERE	Department = @department
							AND		CourseNum = @courseNum)

	IF EXISTS (	SELECT	*
				FROM	SCHEDULE
				WHERE	ClassID = @classID
				AND		SectionNum = @sectionNum)
	BEGIN
		UPDATE	SCHEDULE
		SET		StartTime = @startTime, EndTime = @endTime,
				Mon = @mon, Tues = @tues, Wed = @wed, Thurs = @thurs, Fri = @fri, Sat = @sat, Sun = @sun,
				TeacherID = @teacherID, RoomID = @roomID
		WHERE	ClassID = @classID
		AND		SectionNum = @sectionNum
	END

	ELSE
	BEGIN
		INSERT INTO SCHEDULE (ClassID, SectionNum, StartTime, EndTime, Mon, Tues, Wed, Thurs, Fri, Sat, Sun, TeacherID, RoomID)
		VALUES (@classID, @sectionNum, @startTime, @endTime, @mon, @tues, @wed, @thurs, @fri, @sat, @sun, @teacherID, @roomID)
	END
END
--End Procedure InsertToSchedule --


-- Start Procedure CheckIfClassExists --
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'CheckIfClassExists')
                    AND type IN ( N'P', N'PC' ) ) 
DROP PROCEDURE CheckIfClassExists;
GO

CREATE PROCEDURE CheckIfClassExists 
	@Department VARCHAR(255),
	@CourseNum VARCHAR(255)
AS
(
	SELECT *
	FROM	CLASS
	WHERE Department = @Department AND CourseNum = @CourseNum
)
GO
-- End Procedure CheckIfClassExists --

-- Start Procedure CheckIfProfessorExists --
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'CheckIfProfessorExists')
                    AND type IN ( N'P', N'PC' ) ) 
DROP PROCEDURE CheckIfProfessorExists;
GO

CREATE PROCEDURE CheckIfProfessorExists 
    @TeacherID VARCHAR(6),
	@FirstName VARCHAR(255),
	@LastName VARCHAR(255)
AS
(
	SELECT *
	FROM	PROFESSOR
	WHERE (FirstName = @FirstName AND LastName = @LastName) OR (TeacherID = @TeacherID)
)
GO
-- End Procedure CheckIfProfessorExists --