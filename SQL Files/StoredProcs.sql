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
	SELECT	(Department + ' ' + CourseNum) AS Course, CourseName AS 'Course Name', '1' AS 'Day', '0' AS 'Night', '0' AS 'Online'
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
	SELECT	TeacherID, LastName AS 'Professor'
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
	@ProfessorRank VARCHAR(255)
AS
BEGIN
	INSERT INTO PROFESSOR
	       (TeacherID, FirstName, LastName, YearlyCreditHours, ProfessorRank)
	VALUES (@TeacherID, @FirstName, @LastName, @YearlyCreditHours, @ProfessorRank)
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
	@ProfessorRank VARCHAR(255)
AS
BEGIN
	UPDATE PROFESSOR
	SET FirstName = @FirstName, LastName = @LastName, YearlyCreditHours = @YearlyCreditHours, 
		ProfessorRank = @ProfessorRank
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
	SELECT (Department + ' ' + CourseNum + ' - ' + CourseName) AS Course, ClassID, Department, CourseNum, CourseName, StudentCreditHours, TeacherCreditHours, IsGradClass
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
	SELECT (FirstName + ' ' + LastName) AS 'Professor', TeacherID, FirstName, LastName, YearlyCreditHours, ProfessorRank
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
	@sectionNum varchar(2)
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
	@sectionNum varchar(2),
	@teacherId varchar(6)
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
			P.LastName AS Professor,
			C.TeacherCreditHours AS TeacherCredits
	FROM	SCHEDULE S
	JOIN	CLASS C ON S.ClassID = C.ClassID
	LEFT JOIN	PROFESSOR P ON S.TeacherID = P.TeacherID
END
GO
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
	@sectionNum varchar(2),
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
GO
--End Procedure InsertToSchedule --

-- Start Procedure InsertTimeDayToSchedule --
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'InsertTimeDayToSchedule')
                    AND type IN ( N'P', N'PC' ) ) 
DROP PROCEDURE InsertTimeDayToSchedule;
GO

CREATE PROCEDURE InsertTimeDayToSchedule 
	@department varchar(255),
	@courseNum varchar(255),
	@sectionNum varchar(2),
	@startTime int,
	@endTime int,
	@dayOfWeek varchar(255)
	AS
BEGIN
	DECLARE @classID int
	SELECT	@classID = (	SELECT	ClassID	
							FROM	CLASS
							WHERE	Department = @department
							AND		CourseNum = @courseNum)

	IF @dayOfWeek = 'Monday'
	BEGIN
		UPDATE SCHEDULE
		SET		Mon = 1
		WHERE	ClassID = @classID
		AND		SectionNum = @sectionNum
	END
	IF @dayOfWeek = 'Tuesday'
	BEGIN
		UPDATE SCHEDULE
		SET		Tues = 1
		WHERE	ClassID = @classID
		AND		SectionNum = @sectionNum
	END
	IF @dayOfWeek = 'Wednesday'
	BEGIN
		UPDATE SCHEDULE
		SET		Wed = 1
		WHERE	ClassID = @classID
		AND		SectionNum = @sectionNum
	END
	IF @dayOfWeek = 'Thursday'
	BEGIN
		UPDATE SCHEDULE
		SET		Thurs = 1
		WHERE	ClassID = @classID
		AND		SectionNum = @sectionNum
	END
	IF @dayOfWeek = 'Friday'
	BEGIN
		UPDATE SCHEDULE
		SET		Fri = 1
		WHERE	ClassID = @classID
		AND		SectionNum = @sectionNum
	END
	IF @dayOfWeek = 'Saturday'
	BEGIN
		UPDATE SCHEDULE
		SET		Sat = 1
		WHERE	ClassID = @classID
		AND		SectionNum = @sectionNum
	END
	IF @dayOfWeek = 'Sunday'
	BEGIN
		UPDATE SCHEDULE
		SET		Sun = 1
		WHERE	ClassID = @classID
		AND		SectionNum = @sectionNum
	END
	IF @dayOfWeek = 'Remove'
	BEGIN
		UPDATE SCHEDULE
		SET		Mon = 0, Tues = 0, Wed = 0, Thurs = 0, Fri = 0, Sat = 0, Sun = 0
		WHERE	ClassID = @classID
		AND		SectionNum = @sectionNum
	END
		
	UPDATE	SCHEDULE
	SET		StartTime = @startTime, EndTime = @endTime
	WHERE	ClassID = @classID
	AND		SectionNum = @sectionNum
END
GO
--End Procedure InsertTimeDayToSchedule --


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

-- Start Procedure LoadScreenTermsAndYears --
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'LoadScreenTermsAndYears')
                    AND type IN ( N'P', N'PC' ) ) 
DROP PROCEDURE LoadScreenTermsAndYears;
GO

CREATE PROCEDURE LoadScreenTermsAndYears 
AS
(
	SELECT DISTINCT Term, TermYear, Term + ' ' + TermYear AS 'TermAndYear'
	FROM	SCHEDULE
)
GO
-- End Procedure LoadScreenTermsAndYears --


-- Start Procedure CheckIfRoomColorExists --
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'CheckIfRoomColorExists')
                    AND type IN ( N'P', N'PC' ) ) 
DROP PROCEDURE CheckIfRoomColorExists;
GO

CREATE PROCEDURE CheckIfRoomColorExists 
    @RoomColor INT
AS
(
	SELECT *
	FROM	ROOMS
	WHERE RoomColor = @RoomColor
)
GO
-- End Procedure CheckIfRoomColorExists --

-- Start Procedure GetAllRooms --
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'GetAllRooms')
                    AND type IN ( N'P', N'PC' ) ) 
DROP PROCEDURE GetAllRooms;
GO

CREATE PROCEDURE GetAllRooms 
AS
(
	SELECT 	RoomID, BuildingName, RoomNumber, RoomColor
	FROM	ROOMS
)
GO
-- End Procedure GetAllRooms --


--- Start Procedure AddRoom ---
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'AddRoom')
                    AND type IN ( N'P', N'PC' ) ) 
DROP PROCEDURE AddRoom;
GO

CREATE PROCEDURE AddRoom
	@BuildingName VARCHAR(255),
	@RoomNumber VARCHAR(10),
	@RoomColor INT
AS
BEGIN
	INSERT INTO ROOMS
	       (BuildingName, RoomNumber, RoomColor)
	VALUES (@BuildingName, @RoomNumber, @RoomColor)
END
GO
--- End Procedure AddRoom ---


--- Start Procedure EditRoom ---
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'EditRoom')
                    AND type IN ( N'P', N'PC' ) ) 
DROP PROCEDURE EditRoom;
GO

CREATE PROCEDURE EditRoom
	@RoomID INT,
	@BuildingName VARCHAR(255),
	@RoomNumber VARCHAR(10),
	@RoomColor INT
AS
BEGIN
	UPDATE ROOMS
	SET      BuildingName = @BuildingName, RoomNumber = @RoomNumber, RoomColor = @RoomColor 
	WHERE RoomID = @RoomID
END
GO
--- End Procedure EditRoom ---


--- Start Procedure RemoveRoom ---
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'RemoveRoom')
                    AND type IN ( N'P', N'PC' ) ) 
DROP PROCEDURE RemoveRoom;
GO

CREATE PROCEDURE RemoveRoom
	@RoomID INT
AS
BEGIN
	DELETE FROM ROOMS
	WHERE RoomID = @RoomID
END
GO
--- End Procedure  RemoveRoom ---
