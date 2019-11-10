/*
 Database Basics MS SQL Exam – 20 Oct 2019
Exam problems for the “Database Basics MSSQL Server” course @ SoftUni"
 Submit your solutions in the SoftUni judge system at Software University.
Service
The city mayor, came up with the idea to create an online platform where
    all the citizens can report about different problems and a special organization
 will work to resolve all the incoming reports.
 This organization has a few departments each of which is responsible for a set of problem's categories in which users can
 submit a report. In each department there are employees who get assigned to a report.
 Of course, this huge platform needs a reliable database to store and process the information and the mayor
 has asked for the best specialist in this area. That’s why you got chosen! Congratulations and good luck!

 */

 --Section 1. DDL (30 pts)
--You have been given the E/R Diagram of the Report Service:
create database Service


--Create a database called Service. You need to create 6 tables:
--•	Users - contains information about the people who submist reports
--•	Reports - contains information about the problems
--•	Employees - contains information about the employees
--•	Departments - contains information about the departments
--•	Categories - contains information about categories in reports.
--•	Status - contains information about the possible
 --Users
create table Users(
    Id int PRIMARY KEY IDENTITY ,
    Username varchar(30) UNIQUE not null ,
    Password varchar(50) not null ,
    Name varchar(50) not null ,
    Birthdate datetime2 not null ,
    Age int CHECK (Age between 14 and 110) ,
    Email nvarchar(50) not null
)


--Departments
create table Departments(
    Id int PRIMARY KEY IDENTITY ,
    Name varchar(50) not null ,
)

--Employees
create table Employees(
    Id int PRIMARY KEY IDENTITY ,
    FirstName varchar(30) ,
    LastName varchar(30) ,
    Birthdate datetime2 ,
    Age int CHECK (Age between 18 and 110) ,
    DepartmentId int FOREIGN KEY REFERENCES Departments(Id)
)

--Categories
create table Categories(
        Id int PRIMARY KEY IDENTITY ,
        Name varchar(50) not null ,
        DepartmentId int FOREIGN KEY REFERENCES Departments(Id) not null
)
--Status
create table Status(
        Id int PRIMARY KEY IDENTITY ,
        Label varchar(30) not null ,
)

--Reports
create table Reports(
       Id int PRIMARY KEY IDENTITY ,
       CategoryId int FOREIGN KEY REFERENCES Categories(Id) not null ,
       StatusId int FOREIGN KEY REFERENCES Status(Id) not null ,
       OpenDate datetime2 not null ,
       CloseDate datetime2 ,
       Description varchar(200) not null ,
       UserId int FOREIGN KEY REFERENCES Users(Id) not null ,
       EmployeeId int FOREIGN KEY REFERENCES Employees(Id)
)

--2.	Insert
--Let's insert some sample data into the database.
-- Write a query to add the following records into the corresponding tables.
-- All Id's should be auto-generated.

insert into Employees (FirstName, LastName, Birthdate, DepartmentId)
values
('Marlo', 'O''Malley',	'1958-9-21',	1),
('Niki',	'Stanaghan',	'1969-11-26',	4),
('Ayrton', 'Senna',	'1960-03-21',	9),
('Ronnie',	'Peterson',	'1944-02-14',	9),
('Giovanna',	'Amati',	'1959-07-20',	5)

insert into Reports (CategoryId, StatusId, OpenDate, CloseDate, Description, UserId, EmployeeId)
values
(1,1,'2017-04-13',	'','Stuck Road on Str.133',	6,2),
(6,3,	'2015-09-05',	'2015-12-06','Charity trail running',3,5),
(14,2,'2015-09-07', '','Falling bricks on Str.58',5,2),
(4,3,	'2017-07-03',	'2017-07-06','Cut off streetlight on Str.11',	1,1)

--3.	Update
--Update the CloseDate with the current date of all reports, which don't have CloseDate.

update Reports set CloseDate = '2019-10-20' where CloseDate is null

--4.	Delete
--Delete all reports who have a Status 4.

delete from Reports where StatusId = 4

--5.	Unassigned Reports
--Find all reports that don't have an assigned employee.
-- Order the results by OpenDate in ascending order, then by description ascending.
-- OpenDate must be in format - 'dd-MM-yyyy'

select Description, convert(varchar,(OpenDate),105) from Reports where EmployeeId is null
order by OpenDate asc , Description asc

--6.	Reports & Categories
--Select all descriptions from reports, which have category.
-- Order them by description (ascending) then by category name (ascending).

select R.Description, C.Name from Reports as R
left join Categories C on R.CategoryId = C.Id
 order by R.Description asc , C.Name asc

--7.	Most Reported Category
--Select the top 5 most reported categories and order
--          them by the number of reports per category in descending order and then alphabetically by name.

select top(5) C.Name, count(R2.CategoryId) as ReportsNumber from Reports as R2
join Categories C on R2.CategoryId = C.Id
group by C.Name
 order by ReportsNumber desc , C.Name asc

 --8.	Birthday Report
--Select the user's username and category name in all reports in which users have submitted a report on their birthday.
-- Order them by username (ascending) and then by category name (ascending).

select U.Username, C.Name from Users as U
join Reports R2 on U.Id = R2.UserId
join Categories C on R2.CategoryId = C.Id
where DATEPART(day, U.Birthdate) = DATEPART(day,R2.OpenDate)
 order by U.Username , C.Name

--9.	Users per Employee
--Select all employees and show how many unique users each of them has served to.
--Order by users count  (descending) and then by full name (ascending).

select concat(E.FirstName,' ', E.LastName) as FullName, count(R2.UserId) as UsersCount from Employees as E
LEFT JOIN Reports R2 on E.Id = R2.EmployeeId
group by concat(E.FirstName,' ', E.LastName)
order by UsersCount desc, FullName asc


--10.	Full Info
--Select all info for reports along with employee
--  first name and last name (concataned with space), department name, category name, report description, open date,
--      status label and name of the user.
--  Order them by first name (descending), last name (descending), department (ascending), category (ascending),
--          description (ascending), open date (ascending), status (ascending) and user (ascending).
--Date should be in format - dd.MM.yyyy
--If there are empty records, replace them with 'None'.


select iif(concat(E.FirstName, ' ', E.LastName) is null, 'None' ,concat(E.FirstName, ' ', E.LastName)) as Employee,
       IIF(D.Name is null, 'None', D.Name),
       IIF(C.Name is null, 'None', C.Name),
       IIF(R2.Description, 'None', R2.Description),
       iif(convert(varchar,(OpenDate),104) is null, 'None', convert(varchar,(OpenDate),104)) as OpenDateS,
        iif(S.Label is null, 'None', S.Label),
       IIF(U.Name is null, 'None', U.Name)
from Reports as R2
left join Employees E on R2.EmployeeId = E.Id
join Categories C on R2.CategoryId = C.Id
join Departments D on C.DepartmentId = R2.Id
join Status S on R2.StatusId = S.Id
join Users U on R2.UserId = U.Id
order by E.FirstName desc , E.LastName desc , D.Name asc , C.Name asc , OpenDateS asc , S.Label asc , U.Name

 select iif(concat(E.FirstName, ' ', E.LastName) is null, 'None' ,concat(E.FirstName, ' ', E.LastName)) as Employee,
       IIF(D.Name is null, 'None', D.Name) as Department,
       IIF(C.Name is null, 'None', C.Name) as Category,
       IIF(R2.Description, 'None', R2.Description) as Description,
       iif(convert(varchar,(E.OpenDate),104) is null, 'None', convert(varchar,(E.OpenDate),104)) as OpenDateS,
        iif(S.Label is null, 'None', S.Label) as Status,
       IIF(U.Name is null, 'None', U.Name) as User
  FROM        Reports as R2 left JOIN
                  Employees as E ON R.EmployeeId = E.Id left JOIN
                  Departments as D ON E.DepartmentId = D.Id left JOIN
                  Categories as C ON R2.CategoryId = C.Id AND D.Id = C.DepartmentId JOIN
                  Status as S ON R.StatusId = S.Id left JOIN
                  Users ON R.UserId = U.Id
 ORDER BY E.FirstName DESC, E.LastName DESC, D.Name, C.Name, R.Description, R.OpenDate, S.Label, U.Username


 SELECT    IIF((Employees.FirstName + ' ' + Employees.LastName) is null, 'None', (Employees.FirstName + ' ' + Employees.LastName)),
        IIF(Departments.Name is null, 'None', Departments.Name  ),
        IIF(Categories.Name  is null, 'None',  Categories.Name),
        IIF(Reports.Description is null, 'None',  Reports.Description),
        IIF(convert(varchar,(Reports.OpenDate),104) is null, 'None',  convert(varchar,(Reports.OpenDate),104)),
        IIF(Status.Label is null, 'None',  Status.Label),
        IIF(Users.Username is null, 'None',  Users.Name)

FROM        Reports left JOIN
                  Employees ON Reports.EmployeeId = Employees.Id left JOIN
                  Departments ON Employees.DepartmentId = Departments.Id JOIN
                  Categories ON Reports.CategoryId = Categories.Id  JOIN --AND Departments.Id = Categories.DepartmentId
                  Status ON Reports.StatusId = Status.Id left JOIN
                  Users ON Reports.UserId = Users.Id
ORDER BY Employees.FirstName DESC, Employees.LastName DESC, Departments.Name, Categories.Name, Reports.Description, Reports.OpenDate, Status.Label, Users.Name















