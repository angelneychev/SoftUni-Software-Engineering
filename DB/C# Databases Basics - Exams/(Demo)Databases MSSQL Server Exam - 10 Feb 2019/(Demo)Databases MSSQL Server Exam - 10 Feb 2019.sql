/*
 Database Basics (MSSQL) Demo Exam
  Colonial Journey
2000 years from now, the known space is colonized by the human race.
However, the four Citadel Council races are planning to populate new home worlds in the SoftUnia Galaxy as part of a strategy called the SoftUnia Initiative.
20000 citizens are send aboard space transportation vessels.
The Council has asked you to create a Colonization Management system so they can keep track of the colonists' journeys trough the stars.
Database Overview
You have given an Entity / Relationship Diagram of the CJMS Database:
The ColonialJourney Database holds information about colonists, their travel cards, information about the journeys, types of space vessels and destination planets. Your task is to create a database called ColonialJourney. Then you will have to create several tables.
•	Planets – contains information about planets.
•	Spaceports – contains information about space ports.
•	Spaceships – contains information about space ships.
•	Colonists – contains information about colonists.
•	Journeys – contains information about journeys.
•	TravelCards – contains information about travel cards.
Make sure you implement the whole database correctly on your local machine, so that you could work with it.
The instructions you are given will be the minimal needed for you to implement the database.
 */
create database ColonialJourney

 --Section 1. DDL (30 pts)
--You have been tasked to create the tables in the database by the following models:

create table Planets(
    Id int PRIMARY KEY IDENTITY ,
    [Name] varchar(30) not null
)

create table Spaceports(
    Id int PRIMARY KEY IDENTITY ,
    [Name] varchar(50) not null ,
    PlanetId int FOREIGN KEY REFERENCES Planets(Id) not null
)

create table Spaceships(
        Id int PRIMARY KEY IDENTITY ,
        [Name] varchar(50) not null ,
        Manufacturer varchar(30) not null ,
        LightSpeedRate int DEFAULT 0
)
create table Colonists(
        Id int PRIMARY KEY IDENTITY ,
        FirstName varchar(20) not null ,
        LastName varchar(20) not null ,
        Ucn varchar(10) not null UNIQUE ,
        BirthDate DATETIME2 not null
)
create table Journeys (
        Id int PRIMARY KEY IDENTITY ,
        JourneyStart datetime2 not null ,
        JourneyEnd datetime2 not null ,
        Purpose varchar(11) check (Purpose IN(
            'Medical','Technical','Educational','Military')) ,
        DestinationSpaceportId int FOREIGN KEY REFERENCES Spaceports(Id) not null ,
        SpaceshipId int FOREIGN KEY REFERENCES Spaceships(Id) not null
)

create table TravelCards(
        Id int PRIMARY KEY IDENTITY ,
        CardNumber char(10) not null UNIQUE ,
        JobDuringJourney varchar(8) check ( JobDuringJourney IN(
            'Pilot','Engineer','Cook','Trooper','Cleaner')) ,
        ColonistId int FOREIGN KEY REFERENCES Colonists(Id) not null ,
        JourneyId int FOREIGN KEY REFERENCES Journeys(Id) not null
)

--2.	Insert
--Insert sample data into the database. Write a query to add the following records into the corresponding tables.
-- All Ids should be auto-generated.

insert into Planets (Name)
values
('Mars'),
('Earth'),
('Jupiter'),
('Saturn')
insert into Spaceships (Name, Manufacturer, LightSpeedRate)
values
('Golf','VW',3),
('WakaWaka','Wakanda',4),
('Falcon9','SpaceX',1),
('Bed','Vidolov',	6)

--3.	Update
--Update all spaceships light speed rate with 1 where the Id is between 8 and 12.

update Spaceships set LightSpeedRate += 1 where Id between 8 AND 12

--4.	Delete
--Delete first three inserted Journeys (be careful with the relationships).

delete from TravelCards where JourneyId in (select top(3) id from Journeys)
--delete from TravelCards where JourneyId in (1,2,3)
delete from Journeys where Id in (1,2,3)

--5.	Select all travel cards
--Extract from the database, all travel cards.
-- Sort the results by card number ascending.
--•	CardNumber
--•	JobDuringJourney


select CardNumber, JobDuringJourney from TravelCards order by CardNumber asc

--6.	Select all colonists
--Extract from the database, all colonists.
-- Sort the results by first name, them by last name, and finally by id in ascending order.
--Required Columns
--•	Id
--•	FullName
--•	Ucn

select Id, (FirstName + ' ' + LastName) as FullName, Ucn from Colonists
order by FirstName asc , LastName asc, Id asc

--7.	Select all military journeys
--Extract from the database, all Military journeys.
-- Sort the results ascending by journey start.
--Required Columns
--•	Id
--•	JourneyStart
--•	JourneyEnd

select Id, convert(varchar, JourneyStart, 103) as JourneyStart, convert(varchar, JourneyEnd, 103) as JourneyEnd
from Journeys
where Purpose = 'Military'
order by JourneyStart asc

--8.	Select all pilots
--Extract from the database all colonists, which have a pilot job.
-- Sort the result by id, ascending.

--Required Columns
--•	Id
--•	FullName

select C.Id, (FirstName + ' ' + LastName) as FullName from TravelCards as TC
left join Colonists C on TC.ColonistId = C.Id
where JobDuringJourney = 'Pilot'
order by Id asc

--9.	Count colonists
--Count all colonists that are on technical journey.
--Required Columns
--•	Count
select count(c.id) as Count from Colonists as C
left join TravelCards TC on C.Id = TC.ColonistId
left join Journeys J on TC.JourneyId = J.Id
where Purpose = 'Technical'


--10.	Select the fastest spaceship
--Extract from the database the fastest spaceship and its destination spaceport name.
-- In other words, the ship with the highest light speed rate.
--Required Columns
--•	SpaceshipName
--•	SpaceportName

select top (1) S.Name as SpaceshipName, S2.Name as SpaceportName from Spaceships as S
join Journeys J on S.Id = J.SpaceshipId
join Spaceports S2 on J.DestinationSpaceportId = S2.Id
order by LightSpeedRate desc

--11.	Select spaceships with pilots younger than 30 years
--Extract from the database those spaceships, which have pilots, younger than 30 years old.
-- In other words, 30 years from 01/01/2019.
-- Sort the results alphabetically by spaceship name.
--Required Columns
--•	Name
--•	Manufacturer

--select * from Spaceships

select S.Name, S.Manufacturer from TravelCards as TC
join Colonists C on TC.ColonistId = C.Id
join Journeys J on TC.JourneyId = J.Id
join Spaceships S on J.SpaceshipId = S.Id
where JobDuringJourney = 'Pilot' and DATEDIFF(YEAR, c.Birthdate, '01/01/2019') < 30
order by S.Name asc

--12.	Select all educational mission planets and spaceports
--Extract from the database names of all planets and their spaceports, which have educational missions.
-- Sort the results by spaceport name in descending order.
-- Required Columns
--•	PlanetName
--•	SpaceportName

select (P.Name) as PlanetName, (S.Name) as SpaceportName  from Journeys as J
join Spaceports S on J.DestinationSpaceportId = S.Id
join Planets P on S.PlanetId = P.Id
where J.Purpose = 'Educational'
order by SpaceportName desc

--13.	Select all planets and their journey count
--Extract from the database all planets’ names and their journeys count.
-- Order the results by journeys count, descending and by planet name ascending.
--Required Columns
--•	PlanetName
--•	JourneysCount

select (P.Name) as PlanetName, count(*) as JourneysCount from Journeys as J
join Spaceports S on J.DestinationSpaceportId = S.Id
join Planets P on S.PlanetId = P.Id
group by P.Name
order by JourneysCount desc , PlanetName asc

--14.	Select the shortest journey
--Extract from the database the shortest journey, its destination spaceport name, planet name and purpose.
--Required Columns
--•	Id
--•	PlanetName
--•	SpaceportName
--•	JourneyPurpose

select top(1) J.Id, P.Name as PlanetName, S.Name as SpaceportName, J.Purpose as JourneyPurpose from Journeys as J
join Spaceports S on J.DestinationSpaceportId = S.Id
join Planets P on S.PlanetId = P.Id
order by DATEDIFF(second , J.JourneyStart, J.JourneyEnd)

--15.	Select the less popular job
--Extract from the database the less popular job in the longest journey.
-- In other words, the job with less assign colonists.
--Required Columns
--•	JourneyId
--•	JobName

select top(1) TC.JourneyId, TC.JobDuringJourney from Journeys as J
join TravelCards TC on J.Id = TC.JourneyId
order by DATEDIFF(second , J.JourneyStart, J.JourneyEnd) desc

--16.	Select Second Oldest Important Colonist
--Find all colonists and their job during journey with rank 2.
-- Keep in mind that all the selected colonists with rank 2 must be the oldest ones.
-- You can use ranking over their job during their journey.
--Required Columns
--•	JobDuringJourney
--•	FullName
--•	JobRank

--17.	Planets and Spaceports
--Find all planets and all of their spaceports.
-- Select planet name and the count of the spaceports.
-- Sort them by spaceports count (descending), then by name (ascending).
--Required Columns


--Section 4. Programmability (20 pts)
--18.	Get Colonists Count
--Create a user defined function with the
-- name dbo.udf_GetColonistsCount(PlanetName VARCHAR (30))
-- that receives planet name and returns the count of all colonists sent to that planet.

create function udf_GetColonistsCount(@PlanetName VARCHAR(30))
    returns int
as
begin
    RETURN (
        select count(TC.ColonistId)
        from Planets as P
                 join Spaceports S on P.Id = S.PlanetId
                 join Journeys J on S.Id = J.DestinationSpaceportId
                 join TravelCards TC on J.Id = TC.JourneyId
                 join Colonists C on TC.ColonistId = C.Id
        where P.Name = @PlanetName)
end


--19.	Change Journey Purpose
--Create a user defined stored procedure, named usp_ChangeJourneyPurpose(@JourneyId, @NewPurpose),
--   that receives an journey id and purpose, and attempts to change the purpose of that journey.
--   An purpose will only be changed if all of these conditions pass:
--•	If the journey id doesn’t exists, then it cannot be changed.
--      Raise an error with the message “The journey does not exist!”
--•	If the journey has already that purpose,
--          raise an error with the message “You cannot change the purpose!”
--If all the above conditions pass, change the purpose of that journey.

create proc usp_ChangeJourneyPurpose(@JourneyId int, @NewPurpose nvarchar(50))
as
    begin
        DECLARE @TargetJourneyId int = (
            select Id from Journeys where Id = @JourneyId
        )
        IF (@TargetJourneyId is null )
        begin
            ;THROW 51000, 'The journey does not exist!', 1
        end
        DECLARE @CurrentJourneyPurpose varchar(50) = (
            select Journeys.Purpose from Journeys where Id = @JourneyId
            )
        IF (@CurrentJourneyPurpose = @NewPurpose)
        begin
            ;THROW 51000, 'You cannot change the purpose!', 2
        end
        update Journeys
        set Purpose = @NewPurpose
        where Id = JourneyEnd
    end



