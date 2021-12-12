CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(15,2)) RETURNS NVARCHAR(MAX)
AS BEGIN
	DECLARE @isValidID INT; DECLARE @count INT; DECLARE @name nvarchar(50);	
	SET @isValidID = (SELECT Id FROM Students WHERE Id = @StudentId);

	IF (@isValidID IS NULL) RETURN 'The student with provided id does not exist in the school!'
	IF (@grade > 6) RETURN 'Grade cannot be above 6.00!';

	SET @name = (SELECT FirstName FROM Students WHERE Id = @StudentId);
	
	SET @count = (SELECT COUNT(StudentId) FROM StudentsExams 
	WHERE StudentId = @StudentId AND Grade >= @grade AND @grade <= @grade + 0.5)

	RETURN 'You have to update '+ CAST(@count as VARCHAR(5)) + ' grades for the student ' + @name;	
END
GO

--12.
CREATE PROCEDURE usp_ExcludeFromSchool @StudentId INT AS
DECLARE @isValidID INT; SET @isValidID=(SELECT Id FROM Students WHERE Id = @StudentId);
IF (@isValidID IS NULL) THROW 50001, 'This school has no student with the provided id!', 1;  
DELETE FROM StudentsTeachers WHERE StudentId = @StudentId;
DELETE FROM StudentsSubjects WHERE StudentId = @StudentId;
DELETE FROM StudentsExams WHERE StudentId = @StudentId;
DELETE FROM Students WHERE Id = @StudentId;