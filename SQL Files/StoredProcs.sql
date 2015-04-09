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
	@sectionNum varchar(2),
	@term varchar(6),
	@termYear varchar(4)
AS
BEGIN
	DECLARE	@teacherID VARCHAR(6)
	SELECT	@teacherID = (	SELECT	TeacherID
							FROM	SCHEDULE
							WHERE	ClassID = (	SELECT ClassID
												FROM	CLASS
												WHERE	Department = @department
												AND		CourseNum = @courseNum)
							AND		SectionNum = @sectionNum
							AND		Term = @term
							AND		TermYear = @termYear)

	SELECT	(SELECT		CourseName
				FROM	CLASS
				WHERE	Department = @department
				AND		CourseNum = @courseNum) AS CourseName, 
			SectionNum, StartTime, EndTime, Mon, Tues, Wed, Thurs, Fri, Sat, Sun,
			(SELECT		LastName
				FROM	PROFESSOR
				WHERE	TeacherID = @teacherID) AS Professor,
			RoomID
	FROM	SCHEDULE
	WHERE	ClassID = (	SELECT ClassID
						FROM	CLASS
						WHERE	Department = @department
						AND		CourseNum = @courseNum)
	AND		SectionNum = @sectionNum
	AND		Term = @term
	AND		TermYear = @termYear
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
	@teacherId varchar(6),
	@term varchar(6),
	@termYear varchar(4)
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
				AND		SectionNum = @sectionNum
				AND		Term = @term
				AND		TermYear = @termYear)
	BEGIN
		UPDATE	SCHEDULE
		SET		TeacherID = @teacherID
		WHERE	ClassID = @classID
		AND		SectionNum = @sectionNum
		AND		Term = @term
		AND		TermYear = @termYear
	END

	ELSE
	BEGIN
		INSERT INTO SCHEDULE (ClassID, SectionNum, TeacherID, Term, TermYear)
		VALUES (@classID, @sectionNum, @teacherID, @term, @termYear)
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

CREATE PROCEDURE GetScheduleForLabels 
	@term varchar(6),
	@termYear varchar(4)
AS
BEGIN
	SELECT	(C.Department + ' ' + C.CourseNum + '.' + CONVERT(varchar,S.SectionNum)) AS Course,
			P.LastName AS Professor,
			C.TeacherCreditHours AS TeacherCredits
	FROM	SCHEDULE S
	JOIN	CLASS C ON S.ClassID = C.ClassID
	LEFT JOIN	PROFESSOR P ON S.TeacherID = P.TeacherID
	WHERE	S.Term = @term
	AND		S.TermYear = @termYear
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
	@roomID int,
	@term varchar(6),
	@termYear varchar(4)
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
				AND		SectionNum = @sectionNum
				AND		Term = @term
				AND		TermYear = @termYear)
	BEGIN
		UPDATE	SCHEDULE
		SET		StartTime = @startTime, EndTime = @endTime,
				Mon = @mon, Tues = @tues, Wed = @wed, Thurs = @thurs, Fri = @fri, Sat = @sat, Sun = @sun,
				TeacherID = @teacherID, RoomID = @roomID
		WHERE	ClassID = @classID
		AND		SectionNum = @sectionNum
		AND		Term = @term
		AND		TermYear = @termYear
	END

	ELSE
	BEGIN
		INSERT INTO SCHEDULE (ClassID, SectionNum, StartTime, EndTime, Mon, Tues, Wed, Thurs, Fri, Sat, Sun, TeacherID, RoomID, Term, TermYear)
		VALUES (@classID, @sectionNum, @startTime, @endTime, @mon, @tues, @wed, @thurs, @fri, @sat, @sun, @teacherID, @roomID, @term, @termYear)
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
	@dayOfWeek varchar(255),
	@term varchar(6),
	@termYear varchar(4)
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
		SET		Mon = 1, Tues = 0, Wed = 0, Thurs = 0, Fri = 0, Sat = 0, Sun = 0
		WHERE	ClassID = @classID
		AND		SectionNum = @sectionNum
		AND		Term = @term
		AND		TermYear = @termYear
	END
	IF @dayOfWeek = 'Tuesday'
	BEGIN
		UPDATE SCHEDULE
		SET		Mon = 0, Tues = 1, Wed = 0, Thurs = 0, Fri = 0, Sat = 0, Sun = 0
		WHERE	ClassID = @classID
		AND		SectionNum = @sectionNum
		AND		Term = @term
		AND		TermYear = @termYear
	END
	IF @dayOfWeek = 'Wednesday'
	BEGIN
		UPDATE SCHEDULE
		SET		Mon = 0, Tues = 0, Wed = 1, Thurs = 0, Fri = 0, Sat = 0, Sun = 0
		WHERE	ClassID = @classID
		AND		SectionNum = @sectionNum
		AND		Term = @term
		AND		TermYear = @termYear
	END
	IF @dayOfWeek = 'Thursday'
	BEGIN
		UPDATE SCHEDULE
		SET		Mon = 0, Tues = 0, Wed = 0, Thurs = 1, Fri = 0, Sat = 0, Sun = 0
		WHERE	ClassID = @classID
		AND		SectionNum = @sectionNum
		AND		Term = @term
		AND		TermYear = @termYear
	END
	IF @dayOfWeek = 'Friday'
	BEGIN
		UPDATE SCHEDULE
		SET		Mon = 0, Tues = 0, Wed = 0, Thurs = 0, Fri = 1, Sat = 0, Sun = 0
		WHERE	ClassID = @classID
		AND		SectionNum = @sectionNum
		AND		Term = @term
		AND		TermYear = @termYear
	END
	IF @dayOfWeek = 'Saturday'
	BEGIN
		UPDATE SCHEDULE
		SET		Mon = 0, Tues = 0, Wed = 0, Thurs = 0, Fri = 0, Sat = 1, Sun = 0
		WHERE	ClassID = @classID
		AND		SectionNum = @sectionNum
		AND		Term = @term
		AND		TermYear = @termYear
	END
	IF @dayOfWeek = 'Sunday'
	BEGIN
		UPDATE SCHEDULE
		SET		Mon = 0, Tues = 0, Wed = 0, Thurs = 0, Fri = 0, Sat = 0, Sun = 1
		WHERE	ClassID = @classID
		AND		SectionNum = @sectionNum
		AND		Term = @term
		AND		TermYear = @termYear
	END
	IF @dayOfWeek = 'Remove'
	BEGIN
		UPDATE SCHEDULE
		SET		Mon = 0, Tues = 0, Wed = 0, Thurs = 0, Fri = 0, Sat = 0, Sun = 0
		WHERE	ClassID = @classID
		AND		SectionNum = @sectionNum
		AND		Term = @term
		AND		TermYear = @termYear
	END
		
	UPDATE	SCHEDULE
	SET		StartTime = @startTime, EndTime = @endTime
	WHERE	ClassID = @classID
	AND		SectionNum = @sectionNum
	AND		Term = @term
	AND		TermYear = @termYear
END
GO
--End Procedure InsertTimeDayToSchedule --

-- Start Procedure RemoveRepeatingDaySchedule --
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'RemoveRepeatingDaySchedule')
                    AND type IN ( N'P', N'PC' ) ) 
DROP PROCEDURE RemoveRepeatingDaySchedule;
GO

CREATE PROCEDURE RemoveRepeatingDaySchedule 
	@department varchar(255),
	@courseNum varchar(255),
	@sectionNum varchar(2),
	@dayOfWeek varchar(255),
	@term varchar(6),
	@termYear varchar(4)
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
		SET		Mon = 0
		WHERE	ClassID = @classID
		AND		SectionNum = @sectionNum
		AND		Term = @term
		AND		TermYear = @termYear
	END
	IF @dayOfWeek = 'Tuesday'
	BEGIN
		UPDATE SCHEDULE
		SET		Tues = 0
		WHERE	ClassID = @classID
		AND		SectionNum = @sectionNum
		AND		Term = @term
		AND		TermYear = @termYear
	END
	IF @dayOfWeek = 'Wednesday'
	BEGIN
		UPDATE SCHEDULE
		SET		Wed = 0
		WHERE	ClassID = @classID
		AND		SectionNum = @sectionNum
		AND		Term = @term
		AND		TermYear = @termYear
	END
	IF @dayOfWeek = 'Thursday'
	BEGIN
		UPDATE SCHEDULE
		SET		Thurs = 0
		WHERE	ClassID = @classID
		AND		SectionNum = @sectionNum
		AND		Term = @term
		AND		TermYear = @termYear
	END
	IF @dayOfWeek = 'Friday'
	BEGIN
		UPDATE SCHEDULE
		SET		Fri = 0
		WHERE	ClassID = @classID
		AND		SectionNum = @sectionNum
		AND		Term = @term
		AND		TermYear = @termYear
	END
	IF @dayOfWeek = 'Saturday'
	BEGIN
		UPDATE SCHEDULE
		SET		Sat = 0
		WHERE	ClassID = @classID
		AND		SectionNum = @sectionNum
		AND		Term = @term
		AND		TermYear = @termYear
	END
	IF @dayOfWeek = 'Sunday'
	BEGIN
		UPDATE SCHEDULE
		SET		Sun = 0
		WHERE	ClassID = @classID
		AND		SectionNum = @sectionNum
		AND		Term = @term
		AND		TermYear = @termYear
	END
END
GO
--End Procedure RemoveRepeatingDaySchedule --

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
	SELECT 	RoomID, BuildingName, RoomNumber, RoomColor, BuildingName + ' ' + RoomNumber AS 'Room'
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

-- Start Procedure GetAllRanks --
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'GetAllRanks')
                    AND type IN ( N'P', N'PC' ) ) 
DROP PROCEDURE GetAllRanks;
GO

CREATE PROCEDURE GetAllRanks 
AS
(
	SELECT 	ProfRank, RankID
	FROM	PROFESSOR_RANKS
)
GO
-- End Procedure GetAllRanks --

-- Start Procedure FindProfRankID --
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'FindProfRankID')
                    AND type IN ( N'P', N'PC' ) ) 
DROP PROCEDURE FindProfRankID;
GO

CREATE PROCEDURE FindProfRankID 
	@ProfRank VARCHAR(255)
AS
(
	SELECT 	RankID
	FROM	PROFESSOR_RANKS
	WHERE ProfRank = @ProfRank
)
GO
-- End Procedure FindProfRankID --

-- Start Procedure DeleteSemesterAndYearFromSchedule --
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'DeleteSemesterAndYearFromSchedule')
                    AND type IN ( N'P', N'PC' ) ) 
DROP PROCEDURE DeleteSemesterAndYearFromSchedule;
GO

CREATE PROCEDURE DeleteSemesterAndYearFromSchedule 
	@term varchar(6),
	@termYear varchar(4)
AS
BEGIN
	DELETE FROM SCHEDULE
	WHERE	Term = @term
	AND		TermYear = @termYear
END
GO
-- End Procedure DeleteSemesterAndYearFromSchedule --

-- Start Procedure WeeklyReport --
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'WeeklyReport')
                    AND type IN ( N'P', N'PC' ) ) 
DROP PROCEDURE WeeklyReport;
GO

CREATE PROCEDURE WeeklyReport 
	@term varchar(6),
	@termYear varchar(4)
AS
BEGIN
	SELECT Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
	FROM (
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	0800 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '8:00'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	0830 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '8:30'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	0900 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '9:00'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	0930 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '9:30'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	1000 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '10:00'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	1030 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '10:30'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	1100 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '11:00'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	1130 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '11:30'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	1200 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '12:00'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	1230 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '12:30'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	1300 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '13:00'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	1330 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '13:30'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	1400 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '14:00'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	1430 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '14:30'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	1500 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '15:00'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	1530 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '15:30'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	1600 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '16:00'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	1630 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '16:30'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	1700 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '17:00'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	1730 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '17:30'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	1800 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '18:00'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	1830 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '18:30'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	1900 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '19:00'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	1930 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '19:30'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	2000 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '20:00'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	2030 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '20:30'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	2100 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '21:00'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	2130 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '21:30'
	) AS k
	ORDER BY CONVERT(int, Replace(Time, ':', ''))
END
GO
-- End Procedure WeeklyReport --

-- Start Procedure ProfessorWeeklyReport --
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'ProfessorWeeklyReport')
                    AND type IN ( N'P', N'PC' ) ) 
DROP PROCEDURE ProfessorWeeklyReport;
GO

CREATE PROCEDURE ProfessorWeeklyReport 
	@term varchar(6),
	@termYear varchar(4),
	@teacherID varchar(6)
AS
BEGIN
	SELECT Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
	FROM (
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	0800 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
					AND		TeacherID = @teacherID
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '8:00'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	0830 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
					AND		TeacherID = @teacherID
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '8:30'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	0900 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
					AND		TeacherID = @teacherID
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '9:00'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	0930 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
					AND		TeacherID = @teacherID
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '9:30'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	1000 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
					AND		TeacherID = @teacherID
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '10:00'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	1030 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
					AND		TeacherID = @teacherID
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '10:30'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	1100 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
					AND		TeacherID = @teacherID
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '11:00'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	1130 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
					AND		TeacherID = @teacherID
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '11:30'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	1200 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
					AND		TeacherID = @teacherID
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '12:00'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	1230 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
					AND		TeacherID = @teacherID
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '12:30'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	1300 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
					AND		TeacherID = @teacherID
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '13:00'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	1330 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
					AND		TeacherID = @teacherID
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '13:30'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	1400 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
					AND		TeacherID = @teacherID
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '14:00'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	1430 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
					AND		TeacherID = @teacherID
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '14:30'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	1500 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
					AND		TeacherID = @teacherID
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '15:00'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	1530 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
					AND		TeacherID = @teacherID
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '15:30'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	1600 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
					AND		TeacherID = @teacherID
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '16:00'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	1630 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
					AND		TeacherID = @teacherID
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '16:30'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	1700 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
					AND		TeacherID = @teacherID
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '17:00'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	1730 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
					AND		TeacherID = @teacherID
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '17:30'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	1800 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
					AND		TeacherID = @teacherID
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '18:00'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	1830 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
					AND		TeacherID = @teacherID
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '18:30'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	1900 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
					AND		TeacherID = @teacherID
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '19:00'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	1930 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
					AND		TeacherID = @teacherID
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '19:30'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	2000 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
					AND		TeacherID = @teacherID
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '20:00'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	2030 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
					AND		TeacherID = @teacherID
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '20:30'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	2100 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
					AND		TeacherID = @teacherID
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '21:00'
		UNION
		SELECT	Time, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
		FROM	(	SELECT	(SELECT CASE Mon WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Monday,
							(SELECT CASE Tues WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Tuesday,
							(SELECT CASE Wed WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Wednesday,
							(SELECT CASE Thurs WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Thursday,
							(SELECT CASE Fri WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Friday,
							(SELECT CASE Sat WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Saturday,
							(SELECT CASE Sun WHEN 1 THEN ((select (Department + ' ' + CourseNum) from CLASS where ClassID = s.ClassID) + '.' + CONVERT(varchar, SectionNum) + ' ' + (select LastName from PROFESSOR where TeacherID = s.TeacherID)) ELSE ' ' END) AS Sunday
					FROM	SCHEDULE s
					WHERE	2130 BETWEEN StartTime AND (EndTime - 1)
					AND		Term = @term
					AND		TermYear = @termYear
					AND		TeacherID = @teacherID
				) AS TMP
		RIGHT JOIN TIMES ON 1 = 1
		WHERE Time = '21:30'
	) AS k
	ORDER BY CONVERT(int, Replace(Time, ':', ''))
END
GO
-- End Procedure ProfessorWeeklyReport --

-- Start Procedure CheckIfRoomExists --
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'CheckIfRoomExists')
                    AND type IN ( N'P', N'PC' ) ) 
DROP PROCEDURE CheckIfRoomExists;
GO

CREATE PROCEDURE CheckIfRoomExists 
	@BuildingName VARCHAR(255),
	@RoomNumber VARCHAR(10)
AS
(
	SELECT *
	FROM	ROOM
	WHERE BuildingName = @BuildingName AND RoomNumber = @RoomNumber
)
GO
-- End Procedure CheckIfRoomExists --

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
	FROM	ROOM
	WHERE RoomColor = @RoomColor
)
GO
-- End Procedure CheckIfRoomColorExists --

-- Start Procedure GetRooms --
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'GetRooms')
                    AND type IN ( N'P', N'PC' ) ) 
DROP PROCEDURE GetRooms;
GO

CREATE PROCEDURE GetRooms AS
(
	SELECT	RoomID, (BuildingName + ' ' + RoomNumber) As 'RoomName', RoomColor
	FROM	ROOMS
)
GO
-- End Procedure GetRooms --