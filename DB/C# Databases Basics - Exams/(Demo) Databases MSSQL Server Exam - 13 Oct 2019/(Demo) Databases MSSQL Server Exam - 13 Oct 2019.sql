/*
                                    ==========================================
                                    (Demo) Databases MSSQL Server Exam - 13 Oct 2019
                                    ==========================================
 */

 --Section 1. DDL (30 pts)
--You are given an E/R Diagram of the Trip Service:
--Crеate a database called Bitbucket. You need to create 6 tables:

create database Bitbucket

--1.	Database Design
--Submit all of yours create statements to Judge (only creation of tables).
create table Users(
    Id int PRIMARY KEY IDENTITY ,
    Username varchar(30) not null ,
    Password varchar(30) not null ,
    Email varchar(50) not null ,
)

create table Repositories(
    Id int PRIMARY KEY IDENTITY ,
    [Name] varchar(50) not null
)

create table RepositoriesContributors(
    RepositoryId int FOREIGN KEY REFERENCES Repositories(Id) not null ,
    ContributorId int FOREIGN KEY REFERENCES Users(Id) not null ,
    PRIMARY KEY (RepositoryId,ContributorId)
)

create table Issues(
     Id int PRIMARY KEY IDENTITY ,
     Title varchar(255) not null ,
     IssueStatus char(6) not null ,
     RepositoryId int FOREIGN KEY REFERENCES Repositories(Id) not null ,
     AssigneeId int FOREIGN KEY REFERENCES Users(Id) not null
)

create table Commits(
     Id int PRIMARY KEY IDENTITY ,
     Message varchar(255) not null ,
     IssueId int FOREIGN KEY REFERENCES Issues(Id) ,
     RepositoryId int FOREIGN KEY REFERENCES Repositories(Id) not null ,
     ContributorId int FOREIGN KEY REFERENCES Users(Id) not null ,
)

create table Files(
     Id int PRIMARY KEY IDENTITY ,
     [Name] varchar(100) not null ,
     Size decimal (18,2) not null ,
     ParentId int FOREIGN KEY REFERENCES Files(Id),
     CommitId int FOREIGN KEY REFERENCES Commits(Id) not null
)

/*
 ==================================
 Section 2. DML (10 pts)
 ==================================
 */

 --2.	Insert
--Insert some sample data into the database.
-- Write a query to add the following records into the corresponding tables.
-- All Ids should be auto-generated.


---Name	Size	ParentId	CommitId

insert into Files (Name, Size, ParentId, CommitId)
values ('Trade.idk', 2598.0, 1, 1),
       ('menu.net', 9238.31, 2, 2),
       ('Administrate.soshy', 1246.93, 3, 3),
       ('Controller.php', 7353.15, 4, 4),
       ('Find.java', 9957.86, 5, 5),
       ('Controller.json', 14034.87, 3, 6),
       ('Operate.xix', 7662.92, 7, 7);

insert into Issues (Title, IssueStatus, RepositoryId, AssigneeId)
values ('Critical Problem with HomeController.cs file', 'open', 1, 4),
       ('Typo fix in Judge.html', 'open', 4, 3),
       ('Implement documentation for UsersService.cs', 'closed', 8, 2),
       ('Unreachable code in Index.cs', 'open', 9, 8);

--3.	Update
--Make issue status 'closed' where Assignee Id is 6.

update Issues set  IssueStatus = 'closed' where AssigneeId = 6


--4.	Delete
--Delete repository "Softuni-Teamwork" in repository contributors and issues.

delete from Issues where RepositoryId = 3
delete from RepositoriesContributors where RepositoryId = 3
delete from Repositories where Name = 'Softuni-Teamwork'

/*
 ========================================
 Section 3. Querying (40 pts)
You need to start with a fresh dataset, so recreate your DB and import the sample data again (DataSet-Bitbucket.sql).
 =====================================
 */

 --5.	Commits
--Select all commits from the database.
-- Order them by id (ascending), message (ascending),
--      repository id (ascending) and contributor id (ascending).

select Id, Message, RepositoryId, ContributorId
from Commits
order by Id asc, Message asc, RepositoryId asc, ContributorId asc


--6.	Heavy HTML
--Select all of the files, which have size, greater than 1000, and their name contains "html".
-- Order them by size (descending), id (ascending) and by file name (ascending)

select id, Name, Size  from Files
where Name like '%html%' and Size > 1000
order by Size desc , Id asc , Name asc

-- 7.	Issues and Users
-- Select all of the issues, and the users that are assigned to them,
--              so that they end up in the following format: {username} : {issueTitle}.
-- Order them by issue id (descending) and issue assignee (ascending).

select I.Id, (U.Username + ' : ' + I.Title) as IssueAssignee  from Users as U
join Issues I on U.Id = I.AssigneeId
order by I.Id desc, IssueStatus asc


--8.	Non-Directory Files
--Examples
--Select all of the files, which are NOT a parent to any other file.
-- Select their size of the file and add "KB" to the end of it.
-- Order them file id (ascending), file name (ascending) and file size (descending).
select Id, Name, concat(Size, + 'KB') from Files
where Id not in
      (select FL.ParentId from Files FL where FL.ParentId is not null group by FL.ParentId)
order by Id asc , Name asc , Size desc
select * from Files where ParentId is null


--9.	Most Contributed Repositories
--Select the top 5 repositories in terms of count of commits.
-- Order them by commits count (descending), repository id (ascending) then by repository name (ascending).
--Id	Name	Commits

select R2.Id, R2.Name, count(C.RepositoryId) as Count  from Commits as C
left join Repositories R2 on C.RepositoryId = R2.Id
group by R2.Id, R2.Name
order by Count desc

select top(5) R2.Id, R2.Name, count(RC.RepositoryId) as Count from Repositories as R2
join Commits C on R2.Id = C.RepositoryId
join RepositoriesContributors RC on R2.Id = RC.RepositoryId
group by R2.Id, R2.Name
order by Count desc, R2.Id asc , R2.Name


--10.	User and Files
--Select all users which have commits.
-- Select their username and average size of the file, which were uploaded by them.
-- Order the results by average upload size (descending) and by username (ascending).

select U.Username, avg(Size) as Size from Users as U
join Commits C on U.Id = C.ContributorId
join Files F on C.Id = F.CommitId
group by U.Username
order by Size desc , U.Username asc

--11.	 User Total Commits
--Create a user defined function, named udf_UserTotalCommits(@username) that receives a username.
--The function must return count of all commits for the user:

create function udf_UserTotalCommits(@username varchar(50))
    returns int
as
begin
    declare @countUsers int = (
        select count(C.Id) from Users as U
        join Commits as C on U.Id = C.ContributorId
        where U.Username = @username
        )
    return @countUsers
end
SELECT udf_UserTotalCommits('UnderSinduxrein')


--12.	 Find by Extensions
--Create a user defined stored procedure, named usp_FindByExtension(@extension), that receives a files extensions.
--The procedure must print the id, name and size of the file. Add "KB" in the end of the size.
-- Order them by id (ascending), file name (ascending) and file size (descending)

create proc usp_FindByExtension(@extension varchar(max))
as
begin
    select id, [Name], concat(Size, 'KB') as Size
    from Files
    where Name like '%' + @extension
    order by id, [name], Size desc
end
EXEC usp_FindByExtension 'txt'





select * from Files






