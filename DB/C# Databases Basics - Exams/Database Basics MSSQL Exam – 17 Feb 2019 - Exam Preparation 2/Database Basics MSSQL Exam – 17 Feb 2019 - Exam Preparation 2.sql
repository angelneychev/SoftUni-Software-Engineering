/*
 =========================
 Database Basics MSSQL Exam – 17 Feb 2019
 =========================
 Don’t be so stressed! Today you must build a very simple school system and execute some
    queries over it to check if it works correctly.
 From the very beginning SoftUni saw a huge potential in you and has
    assigned you a very exciting project.
 In 4 hours, you must develop a complicated system for a small school.
Your database must contain information about the students with their teachers and exams.
 Also, it must contain information about the subjects in the school
 */

--Section 1. DDL (30 pts)
--Crеate a database called School.
-- You need to create 7 tables:

CREATE DATABASE School;

use School

create table Students (
    Id int PRIMARY KEY IDENTITY ,
    FirstName nvarchar(30) not null ,
    MiddleName nvarchar(25) ,
    LastName nvarchar(30) not null ,
    Age smallint CHECK (Age between 5 and 100) not null ,
    Address nvarchar(50) ,
    Phone nchar(10)
)

create table Subjects (
    Id int PRIMARY KEY IDENTITY ,
    [Name] nvarchar(20) not null ,
    Lessons int check (Lessons > 0) not null
)

create table StudentsSubjects(
    Id int PRIMARY KEY IDENTITY ,
    StudentId int FOREIGN KEY REFERENCES Students(Id) not null ,
    SubjectId int FOREIGN KEY REFERENCES Subjects(Id) not null ,
    Grade decimal(3,2) not null CHECK (Grade >= 2 AND Grade <= 6)
)

create table Exams(
        Id int PRIMARY KEY IDENTITY ,
        [Date] datetime2 ,
        SubjectId int FOREIGN KEY REFERENCES Subjects(Id)
)

create table StudentsExams(
    StudentId int FOREIGN KEY REFERENCES Students(Id) not null ,
    ExamId int FOREIGN KEY REFERENCES Exams(Id) not null,
    Grade decimal(3,2) not null CHECK (Grade >= 2 AND Grade <= 6),
    PRIMARY KEY (StudentId,ExamId)
)

create table Teachers(
    Id int PRIMARY KEY IDENTITY ,
    FirstName nvarchar(20) not null ,
    LastName nvarchar(20) not null ,
    Address nvarchar(20) not null ,
    Phone nchar(10) ,
    SubjectId int FOREIGN KEY REFERENCES Subjects(Id) not null
)

create table StudentsTeachers(
    StudentId int FOREIGN KEY REFERENCES Students(Id) not null ,
    TeacherId int FOREIGN KEY REFERENCES Teachers(Id) not null ,
    PRIMARY KEY (StudentId, TeacherId)
)


/*
 ===================
 Section 2. DML (10 pts)
 ===================
 */

--Insert some sample data into the database.
-- Write a query to add the following records into the corresponding tables.
-- All Ids should be auto-generated.

insert into Teachers (FirstName, LastName, Address, Phone, SubjectId)
values
('Ruthanne',	'Bamb',	'84948 Mesta Junction',	'3105500146',	6),
('Gerrard',	'Lowin',	'370 Talisman Plaza',	'3324874824',	2),
('Merrile',	'Lambdin',	'81 Dahle Plaza',	'4373065154',	5),
('Bert',	'Ivie',	'2 Gateway Circle',	'4409584510',	4)

insert into Subjects ([Name], Lessons)
values
('Geometry',	12),
('Health',	10),
('Drama',	7),
('Sports',	9)

--3. Update
--Make all grades 6.00, where the subject id is 1 or 2, if the grade is above or equal to 5.50

update StudentsSubjects set Grade = 6.00 where SubjectId in (1,2) and Grade >=5.50;

select * from StudentsSubjects where SubjectId in (1,2) and Grade >=5.50;

--4. Delete
--Delete all teachers, whose phone number contains ‘72’.
delete
from StudentsTeachers
where TeacherId in (select id from Teachers where Phone like '%72%')

DELETE
FROM Teachers
where Phone like '%72%'

--5. Teen Students
--Select all students who are teenagers (their age is above or equal to 12).
-- Order them by first name (alphabetically), then by last name (alphabetically).
-- Select their first name, last name and their age.

select FirstName, LastName, Age from Students where Age >= 12
order by FirstName asc ,  LastName asc

--6. Students Teachers
--Select all students and the count of teachers each one has.

select FirstName, LastName, count(TeacherId) as TeachersCount from Students as S
left join StudentsTeachers ST on S.Id = ST.StudentId
group by FirstName, LastName

--7. Students to Go
--Find all students, who have not attended an exam.
-- Select their full name (first name + last name).
--Order the results by full name (ascending).


select (FirstName + ' ' + LastName) as [Full Name]
from Students as S
         left join StudentsExams SE on S.Id = SE.StudentId
where SE.ExamId is null
order by [Full Name]

--8. Top Students
--Find top 10 students, who have highest average grades from the exams.
--Format the grade, two symbols after the decimal point.
--Order them by grade (descending), then by first name (ascending), then by last name (ascending)

select top(10) FirstName, LastName, format(avg(Grade), 'N2') as Grade from Students as S
join StudentsExams SE on S.Id = SE.StudentId
group by FirstName, LastName
order by Grade desc, FirstName, LastName

--9. Not So In The Studying
--Find all students who don’t have any subjects.
-- Select their full name. The full name is combination of first name, middle name and last name.
-- Order the result by full name
--NOTE: If the middle name is null you have to concatenate the first name and last name separated with single space.

select concat(FirstName, ' ', IIF(MiddleName is null, '',MiddleName + ' '), LastName) as [Full Name] from Students as S
left join StudentsSubjects SS on S.Id = SS.StudentId
where SS.Id is null
order by [Full Name]

--10. Average Grade per Subject
--Find the average grade for each subject. Select the subject name and the average grade.
--Sort them by subject id (ascending).

select S.Name, avg(SS.Grade) from Subjects as S
join StudentsSubjects SS on S.Id = SS.SubjectId
group by S.Name, S.Id
order by S.Id


/*
 Section 4. Programmability (20 pts)
11. Exam Grades

Create a user defined function, named udf_ExamGradesToUpdate(@studentId, @grade), that receives a student id and grade.
The function should return the count of grades, for the student with the given id, which are above the received grade and under the received grade with 0.50 added (example: you are given grade 3.50 and you have to find all grades for the provided student which are between 3.50 and 4.00 inclusive):
If the condition is true, you must return following message in the format:
•	 “You have to update {count} grades for the student {student first name}”
If the provided student id is not in the database the function should return “The student with provided id does not exist in the school!”
If the provided grade is above 6.00 the function should return “Grade cannot be above 6.00!”
Note: Do not update any records in the database!
 */
use School

create function udf_ExamGradesToUpdate(@studentId int, @grade decimal)
returns nvarchar(100)
as
    begin
        declare  @studentName nvarchar(30)  = (
            select top(1) FirstName from Students
            where Id = @studentId);
            -- Намираме първо името, като селектираме таблица Student
            --и в условието казваме, че Id = @studentId (това ни се подава като стойност)
            -- top(1) за всеки случай, ако върне повече от един резултат, което е случая е невъзможно

-- правим проверка дали все пак ни връща някакво име по подаденот ID,
        -- ако не връща вадим съобщението от условието
        if (@studentName  is null )
        begin
            return 'The student with provided id does not exist in the school!';
        end
        --Праверяваме оценката дали е > 6
        if (@grade > 6.00)
        begin
            return 'Grade cannot be above 6.00!';
        end
-- трябва да намерим колко каунта от оценките за този студент
        declare @studentGradeCount int = (
            select count(Grade) from StudentsExams
            where StudentId = @studentId and (Grade >= @grade and Grade <=(Grade + 0.50)))
        --You have to update {count} grades for the student {student first name}
        return concat('You have to update ', @studentGradeCount,' grades for the student ',
            @studentName)
    end
SELECT dbo.udf_ExamGradesToUpdate(12, 6.20)
SELECT dbo.udf_ExamGradesToUpdate(12, 5.50)
SELECT dbo.udf_ExamGradesToUpdate(121, 5.50)
select * from StudentsExams where StudentId =12

/*
 12. Exclude from school
Create a user defined stored procedure, named usp_ExcludeFromSchool(@StudentId), that receives a student id and attempts to delete the current student.
 A student will only be deleted if all of these conditions pass:
If the student doesn’t exist, then it cannot be deleted. Raise an error with the message “This school has no student with the provided id!”
If all the above conditions pass, delete the student and ALL OF HIS REFERENCES!
 */


create proc usp_ExcludeFromSchool(@StudentId int)
as
    begin
        --проверяваме не COUNT дали съществува такъв студент, ако го има id-to ще има и count
        DECLARE @studentMatchingIdCount BIT = (
            select count(*) from Students where Id = @StudentId
            );

        if(@studentMatchingIdCount = 0)
        begin
            raiserror ('This school has no student with the provided id!', 16,1);
            return ;
        end

        delete  from StudentsExams where StudentId = @StudentId;
        delete from StudentsSubjects where StudentId = @StudentId;
        delete from StudentsTeachers where StudentId = @StudentId;
        delete from Students where Id = @StudentId;
    end

EXEC usp_ExcludeFromSchool 301
EXEC usp_ExcludeFromSchool 2 SELECT COUNT(*) FROM Students



