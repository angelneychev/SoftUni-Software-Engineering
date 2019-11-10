/*
 ===============================================================================================
1. Database design
 ===============================================================================================
 Submit all of yours create statements to Judge (only creation of tables).
 Crеate a database called TripService. You need to create 6 tables:
 */
--create database TripService
--use TripService

--Cities – contains information about cities and their countries.
create table Cities
(
    Id          int PRIMARY KEY IDENTITY,
    [Name]      nvarchar(20) not null,
    CountryCode char(2)      not null
)
-- Hotels – contains information about the hotels in the system.
create table Hotels
(
    Id            int PRIMARY KEY IDENTITY,
    [Name]        nvarchar(30)                               not null,
    CityId        int FOREIGN KEY REFERENCES Cities (Id) not null,
    EmployeeCount int                                        not null,
    BaseRate      decimal(15, 2)
)
--Rooms – contains information about the rooms each hotel has.
create table Rooms
(
    Id      int PRIMARY KEY IDENTITY,
    Price   decimal(15, 2) not null,
    Type    nvarchar(20)   not null,
    Beds    int            not null,
    HotelId int FOREIGN KEY REFERENCES Hotels (Id)
)
--Trips – contains information about each trip.

create table Trips
(
    Id          int PRIMARY KEY IDENTITY,
    RoomId      int FOREIGN KEY REFERENCES Rooms (Id) not null,
    BookDate    date                                      not null,
    ArrivalDate date                                      not null,
    ReturnDate  date                                      not null,
    CancelDate  date,
    CONSTRAINT CH_BookDate CHECK (BookDate < ArrivalDate),
    CONSTRAINT CH_ArrivaDate CHECK (ArrivalDate < ReturnDate)
)
--Accounts – contains information about the trip service users.

create table Accounts
(
    Id         int PRIMARY KEY IDENTITY,
    FirstName  nvarchar(50)                               not null,
    MiddleName nvarchar(20),
    LastName   nvarchar(50)                               not null,
    CityId     int FOREIGN KEY REFERENCES Cities (Id) not null,
    BirthDate  date                                       not null,
    Email      nvarchar(100)                              not null unique
)
--AccountsTrips – contains information about all accounts and their trips.

create table AccountsTrips
(
    AccountId int foreign key references Accounts (Id) not null,
    TripId    int foreign key references Trips (Id) not    null,
    Luggage   int                                          not null check (Luggage >= 0),
    PRIMARY KEY (AccountId, TripId)
)

--2. Insert

insert into Accounts (FirstName, MiddleName, LastName, CityId, BirthDate, Email)
values ('John', 'Smith', 'Smith', 34, '1975-07-21', 'j_smith@gmail.com'),
       ('Gosho', NULL, 'Petrov', 11, '1978-05-16', 'g_petrov@gmail.com'),
       ('Ivan', 'Petrovich', 'Pavlov', 59, '1849-09-26', 'i_pavlov@softuni.bg'),
       ('Friedrich', 'Wilhelm', 'Nietzsche', 2, '1844-10-15', 'f_nietzsche@softuni.bg');

insert into Trips (RoomId, BookDate, ArrivalDate, ReturnDate, CancelDate)
values (101, '2015-04-12', '2015-04-14', '2015-04-20', '2015-02-02'),
       (102, '2015-07-07', '2015-07-15', '2015-07-22', '2015-04-29'),
       (103, '2013-07-17', '2013-07-23', '2013-07-24', NULL),
       (104, '2012-03-17', '2012-03-31', '2012-04-01', '2012-01-10'),
       (109, '2017-08-07', '2017-08-28', '2017-08-29', NULL)

--3. Update
--Make all rooms’ prices 14% more expensive where the hotel ID is either 5, 7 or 9.
update Rooms
SET Price += Price * 0.14
where HotelId in (5, 7, 9);

--4. Delete
--Delete all of Account ID 47’s account’s trips from the mapping table.
delete
from AccountsTrips
where AccountId = 47;

--5. Bulgarian Cities
--Select all cities in Bulgaria. Order them by city name.

select id, name
from Cities
where CountryCode = 'BG'
order by [Name];

--6. People Born After 1991
--Select all full names and birth years from accounts, who are born after 1991.
--Order them by birth year (descending), then by first name (ascending).
-- Keep in mind that middle names can be NULL 😊

select concat(FirstName, ' ' + MiddleName, ' ', LastName) as [Full Name], YEAR(BirthDate) as [BirthYear]
from Accounts
where YEAR(BirthDate) > 1991
order by YEAR(BirthDate) desc, FirstName asc

--7. EEE-Mails
--Select accounts whose emails start with the letter “e”.
-- Select their first and last name, their birthdate in the format "MM-dd-yyyy", and their city name.
--Order them by city name (descending)

select A.FirstName, A.LastName, FORMAT(A.BirthDate, 'MM-dd-yyyy') as BirthDate, C.[Name] as Hometown, A.Email
from Accounts as A
         JOIN Cities C on A.CityId = C.Id
where left(Email, 1) = 'e'
order by C.Name desc;


--8. City Statistics
--Select all cities with the count of hotels in them.
-- Order them by the hotel count (descending), then by city name.
-- Include cities, which have no hotels in them as well.

select C.Name, count(H.ID) as Cities
from Cities as C
         LEFT JOIN Hotels H on H.CityId = C.Id
group by C.Id, C.Name
order by Cities desc, C.Name;

--9. Expensive First-Class Rooms
--Find all First-Class rooms and select the Id, Price, Hotel name and City name.
--Order them by Price (descending), then by Room ID.

select R.Id, R.Price, H.[Name] as Hotel, C.Name as City
from Rooms as R
         JOIN Hotels H on R.HotelId = H.Id
         JOIN Cities C on H.CityId = C.Id
where Type = 'First Class'
order by R.Price desc, R.Id;

--10. Longest and Shortest Trips
--Find the longest and shortest trip for each account, in days.
-- Filter the results to accounts with no middle name and trips,
--          which aren’t cancelled (CancelDate is null).
--Order the results by Longest Trip days (descending), then by Account ID.

select A.Id,
       A.FirstName + ' ' + a.LastName                    as FullName,
       MAX(DATEDIFF(DAY, T2.ArrivalDate, T2.ReturnDate)) as LongestTrip,
       MIN(DATEDIFF(DAY, T2.ArrivalDate, T2.ReturnDate)) as ShortestTrip
from Accounts as A
         join AccountsTrips T on A.Id = T.AccountId
         join Trips T2 on T.TripId = T2.Id
where A.MiddleName is null
  AND T2.CancelDate is null
group by A.Id, A.FirstName + ' ' + a.LastName
order by LongestTrip desc, A.Id;

--11. Metropolis
--Find the top 5 cities, which have the most registered accounts in them.
-- Order them by the count of accounts (descending).
--Id	City	Country	Accounts
select
top (5)
C.Id
,
C.Name as City
,
C.CountryCode as Country
,
count(*) as Accounts
from Cities as C
         join Accounts A on C.Id = A.CityId
group by C.Id, C.Name, C.CountryCode
order by Accounts desc, C.Id

--12. Romantic Getaways
--Find all accounts, which have had one or more trips to a hotel in their hometown.
--Sort by them by the trips count (descending), then by Account ID.
--Id	Email	City	Trips
select A.Id, a.Email, c.Name, count(t.Id) as Trips
from Accounts as A
         join AccountsTrips AT on A.Id = AT.AccountId
         join Trips T on AT.TripId = T.Id
         join Rooms R on T.RoomId = R.Id
         join Hotels H on R.HotelId = H.Id
         join Cities C on A.CityId = C.Id
where A.CityId = H.CityId
group by A.Id, a.Email, c.Name
order by Trips desc, a.Id;

--13. Lucrative Destinations
--Find the top 10 cities’ Total Revenue Sum (Hotel Base Rate + Room Price) and trip count.
--Count only trips, which were booked in 2016.
--Sort them by Total Revenue (descending), then by Trip count (descending)

select top (10) C.Id, C.Name, sum(H.BaseRate + R.Price) as [Total Revenue], COUNT(t.Id) as Trips
from Cities as C
         join Hotels H on C.Id = H.CityId
         join Rooms R on H.Id = R.HotelId
         join Trips T on R.Id = T.RoomId
where DATEPART(YEAR , T.BookDate) = 2016
group by C.Id, C.Name
order by [Total Revenue] desc , Trips desc;

--14. Trip Revenues
--Find all trips’ revenue (hotel base rate + room price).
-- If a trip is canceled, its revenue is always 0. Extract the trip’s ID,
-- the hotel’s name, the room type and the revenue.
--Order the results by Room type, then by the Trip ID.

use TripService

select T.Id,
       H.Name,
       R.Type,
       case
           when T.CancelDate is null THEN sum(H.BaseRate + R.Price)
           ELSE 0.00
           END As Revenue
from Trips as T
         join AccountsTrips as AT ON T.Id = AT.TripId
         join Rooms R on T.RoomId = R.Id
         join Hotels H on R.HotelId = H.Id
GROUP BY T.Id, H.Name, R.Type, t.CancelDate
order by R.Type, T.Id

--15. Top Travelers
--Find the top traveler for each country.
-- The top traveler is the account, which has the most trips to that country.
--Order the results by the count of trips (descending), then by Account ID.

select Temp.Id, Temp.Email, Temp.CountryCode, Temp.Trips
from (
         select A.Id,
                A.Email,
                C.CountryCode,
                count(T.Id) as Trips,
                DENSE_RANK() OVER (PARTITION BY C.CountryCode order by count(T.Id) desc, A.Id) as TripsRank
         from Accounts as A
                  join AccountsTrips as AT on A.Id = AT.AccountId
                  join Trips T on AT.TripId = T.Id
                  join Rooms R on T.RoomId = R.Id
                  join Hotels H on R.HotelId = H.Id
                  join Cities C on H.CityId = C.Id
         group by A.Id, A.Email, C.CountryCode) as Temp
where Temp.TripsRank = 1
order by Temp.Trips desc, Temp.Id

--16. Luggage Fees
--Apart from its base rate and room price, each hotel also has a hidden “luggage fee”.
-- It’s in the terms and conditions, but nobody reads those…
--The luggage fee only comes into action if a trip has more than 5 items of luggage and it’s equal to the number of luggage items,
--      multiplied by 5.
--Take into account only trips, which have more than 0 luggage.
--Order the results by the count of luggage (descending)



