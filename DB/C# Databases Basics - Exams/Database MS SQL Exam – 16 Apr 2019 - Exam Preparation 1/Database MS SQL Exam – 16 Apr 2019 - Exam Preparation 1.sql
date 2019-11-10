/*
Database MS SQL Exam – 16 Apr 2019 - Exam Preparation 1
Exam problems for the “Database Basics” course @ SoftUni.
Submit your solutions in the SoftUni Judge system at https://judge.softuni.bg/
            ==========
            Airport
            =========
*/

--Section 1. DDL (30 pts)
--You are given an E/R Diagram of the Airport:

-- Crеate a database called Airport. You need to create 6 tables:

create database Airport;

-- 	Planes – contains information about the planes.

create table Planes(
    Id int primary key identity ,
    [Name] varchar(30) not null ,
    Seats int not null ,
    Range int not null
)
-- 	Flights – contains information about the flights.
create table Flights(
    Id int PRIMARY KEY IDENTITY ,
    DepartureTime datetime2,
    ArrivalTime datetime2,
    Origin varchar(50) not null ,
    Destination varchar(50) not null ,
    PlaneId int FOREIGN KEY REFERENCES Planes(Id) not null
)

-- 	Passеngers – contains information about the passengers
create table Passengers(
    Id int PRIMARY KEY IDENTITY ,
    FirstName varchar(30) not null ,
    LastName varchar(30) not null ,
    Age int not null ,
    Address varchar(30) not null ,
    PassportId char(11) not null
)
-- 	LuggageTypes – contains information about the type of luggage's.
create table LuggageTypes(
    Id int PRIMARY KEY IDENTITY ,
    Type varchar(30) not null
)
-- 	Luggages – contains information about the luggage's.
create table Luggages(
    Id int PRIMARY KEY IDENTITY ,
    LuggageTypeId int FOREIGN KEY REFERENCES LuggageTypes(Id) not null ,
    PassengerId int FOREIGN KEY REFERENCES Passengers(Id) not null
)
-- 	Tickets – contains information about the tickets.
create table Tickets(
    Id int PRIMARY KEY IDENTITY ,
    PassengerId int FOREIGN KEY REFERENCES Passengers(Id) not null ,
    FlightId int FOREIGN KEY REFERENCES Flights(Id) not null,
    LuggageId int FOREIGN KEY REFERENCES Luggages(Id) not null ,
    Price decimal(15,2) not null
)

--1.	Database Design
--Submit all of yours create statements to Judge (only creation of tables).

/*
 ====================
 Section 2. DML (10 pts)
 ====================
 Before you start, you must import “DataSet-Airport.sql”. If you have created the structure correctly, the data should be successfully inserted without any errors.
In this section, you have to do some data manipulations:

 */

--2.	Insert
--Insert some sample data into the database.
-- Write a query to add the following records into the corresponding tables.
-- All Ids should be auto-generated.

insert into Planes([Name],Seats, Range)
values
('Airbus 336',	112,	5132),
('Airbus 330',	432,	5325),
('Boeing 369',	231,	2355),
('Stelt 297',	254,	2143),
('Boeing 338',	165,	5111),
('Airbus 558',	387,	1342),
('Boeing 128',	345,	5541)

insert into LuggageTypes(Type)
values
('Crossbody Bag'),
('School Backpack'),
('Shoulder Bag')

--3.	Update
--Make all flights to "Carlsbad" 13% more expensive.

update Tickets SET Price +=Price * 0.13
where FlightId in (
    select Id from Flights where Destination = 'Carlsbad'
    )

--4.	Delete
--Delete all flights to "Ayn Halagim".
delete from Tickets where FlightId in
(select id from Flights where Destination = 'Ayn Halagim')

delete from Flights
where Destination = 'Ayn Halagim'

/*
 Section 3. Querying (40 pts)
You need to start with a fresh dataset, so recreate your DB and import the sample data again
 (DataSet-Bitbucket.sql).
 */
--5.	The "Tr" Planes
--Select all of the planes, which name contains "tr".
-- Order them by id (ascending), name (ascending), seats (ascending) and range (ascending).

select * from Planes where [Name] like '%tr%'

--6.	Flight Profits
--Select the total profit for each flight from database.
-- Sort by them by total price (descending), flight id (ascending).

select FlightId, sum(Price) as Price from Tickets
group by FlightId
order by Price desc , FlightId asc

--7.	Passenger Trips
--Select the full name of the passengers with their trips (origin - destination).
-- Order them by full name (ascending), origin (ascending) and destination (ascending).

select (P.FirstName + ' ' + P.LastName) as [Full Name], F.Origin, F.Destination from Passengers as P
join Tickets T on P.Id = T.PassengerId
join Flights F on T.FlightId = F.Id
order by [Full Name] asc , Origin asc , Destination asc

--8.	Non Adventures People
--Select all people who don't have tickets.
-- Select their first name, last name and age .
-- Sort them by age (descending), first name (ascending) and last name (ascending).

select P.FirstName as [First Name], P.LastName as [Last Name], Age from Passengers as P
left join Tickets T on P.Id = T.PassengerId
where T.Id is null
order by Age desc , FirstName asc , LastName asc

--9.	Full Info
--Select all passengers who have trips.
-- Select their full name (first name – last name),
-- plane name, trip (in format {origin} - {destination}) and luggage type.
-- Order the results by full name (ascending), name (ascending), origin (ascending),
-- destination (ascending) and luggage type (ascending).

select (P.FirstName + ' ' + P.LastName)   as [Full Name],
       PL.Name                            as [Plane Name],
       (F.Origin + ' - ' + F.Destination) as Trip,
       LT.Type                            as [Luggage Type]
from Passengers as P
         join Tickets T on P.Id = T.PassengerId
         join Flights F on T.FlightId = F.Id
         join Planes PL on F.PlaneId = PL.Id
         join Luggages L on T.LuggageId = L.Id
         join LuggageTypes LT on L.LuggageTypeId = LT.Id
order by [Full Name] asc, [Plane Name] asc, Trip asc, [Luggage Type] asc

--10.	PSP
--Select all planes with their name, seats count and passengers count.
-- Order the results by passengers count (descending),
-- plane name (ascending) and seats (ascending)

select P.Name, P.Seats, count(T.Id) as Count from Planes as P
left join Flights F on P.Id = F.PlaneId
left join Tickets T on F.Id = T.FlightId
group by P.Name, P.Seats
order by  Count desc, Name asc , Seats asc

/*
 ==========================
 Section 4. Programmability (20 pts)
 =========================
 */
 --11.	Vacation
--Create a user defined function, named udf_CalculateTickets(@origin, @destination, @peopleCount)
--          that receives an origin (town name), destination (town name) and people count.
--The function must return the total price in format "Total price {price}"
--	If people count is less or equal to zero return – "Invalid people count!"
--	If flight is invalid return – "Invalid flight!"


create function udf_CalculateTickets(@origin varchar(50), @destination varchar(50), @peopleCount int)
returns VARCHAR(50)
AS
    BEGIN
        IF (@peopleCount <=0)
        BEGIN
            RETURN  'Invalid people count!';
        END

        DECLARE @flightId int = (
            select TOP(1) Id FROM Flights
            where Origin = @origin AND Destination = @destination
            );
        IF(@flightId is null)
        BEGIN
            RETURN 'Invalid flight!';
        END

        DECLARE @pricePerPerson DECIMAL(18,2) = (
            select TOP(1) Price from Tickets
            where FlightId = @flightId
            );
        DECLARE  @totalPrice DECIMAL (24,2) =  @pricePerPerson * @peopleCount;

        RETURN CONCAT('Total price ', @totalPrice)
    END

SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', 33)
SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', -1)
SELECT dbo.udf_CalculateTickets('Invalid','Rancabolang', 33)

--12.	Wrong Data
--Create a user defined stored procedure, named usp_CancelFlights
--The procedure must cancel all flights on which the arrival time is before the departure time.
--Cancel means you need to leave the departure and arrival time empty.

create proc usp_CancelFlights
as
    begin
        update Flights set DepartureTime = null, ArrivalTime = null
        where DATEDIFF(SECOND, DepartureTime, ArrivalTime) > 0
    end