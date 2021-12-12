SELECT FirstName, LastName, Age FROM Students
WHERE Age >= 12 ORDER BY FirstName, LastName

--06.
SELECT s.FirstName, s.LastName, COUNT(st.TeacherId) AS TeachersCount  
FROM Students AS s JOIN StudentsTeachers AS st ON st.StudentId = s.Id
GROUP BY s.FirstName, s.LastName

--07.
SELECT CONCAT(s.FirstName, ' ', s.LastName) AS [Full Name] FROM Students AS s
FULL JOIN StudentsExams AS se ON se.StudentId = s.Id
WHERE se.ExamId IS NULL ORDER BY [Full Name]

--08.
SELECT TOP(10) s.FirstName AS [First Name], s.LastName AS [Last Name], 
CAST(AVG(se.Grade) AS DECIMAL(3,2)) AS Grade 
FROM Students AS s JOIN StudentsExams AS se ON s.Id = se.StudentId
GROUP BY s.FirstName, s.LastName ORDER BY Grade DESC, s.FirstName, s.LastName

--09.
SELECT s.FirstName + ISNULL(' ' + s.MiddleName, '') + ' ' + s.LastName AS [Full Name] 
FROM Students AS s LEFT JOIN StudentsSubjects AS ss ON ss.StudentId = s.Id
WHERE ss.SubjectId IS NULL ORDER BY [Full Name]

--10.
SELECT s.[Name], AVG(ss.Grade) FROM Subjects AS s
RIGHT JOIN StudentsSubjects AS ss ON s.Id = ss.SubjectId
GROUP BY s.[Name], ss.SubjectId
ORDER BY ss.SubjectId