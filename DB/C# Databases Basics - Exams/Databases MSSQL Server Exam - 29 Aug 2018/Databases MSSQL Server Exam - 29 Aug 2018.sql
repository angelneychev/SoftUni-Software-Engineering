/*
 Database Basics MS SQL Exam – 24 Jun 2018
Exam problems for the “Database Basics” course @ SoftUni.
Submit your solutions in the SoftUni Judge system at https://judge.softuni.bg/
Supermarket
After feeling extremely disappointed with your previous job at “Krivodol Trip Service LLC”, you have now started working for a new and much better company – “Pustinqk Software”. From the very beginning your new boss saw a huge potential in you and has assigned you a very exciting project. In 6 hours, you must develop a complicated system for a small shop, which has now grown bigger.
Your database must contain information about the employees and their work hours. You must also include information about the products and their orders.
*/

--Section 1. DDL (30 pts)
--You are given an E/R Diagram of the Trip Service:
--Crеate a database called Supermarket. You need to create 6 tables:
-- Categories – contains information about the item categories.
-- Items – contains information about the items and their categories.
-- Orders – contains information about all of the store orders.
-- OrderItems – contains information about every order’s items.
-- Employees – contains information about the employees.
-- Shifts – contains information about check-in tracking for employees.

create database Supermarket


--Categories
create table Categories(
    Id int PRIMARY KEY IDENTITY ,
    [Name] nvarchar(30) not null ,
)
--Items
create table Items(
    Id int PRIMARY KEY IDENTITY ,
    [Name] nvarchar(30) not null ,
    Price decimal(18,2) not null ,
    CategoryId int FOREIGN KEY REFERENCES Categories(Id) not null
)
--Employees
create table Employees(
    Id int PRIMARY KEY IDENTITY ,
    FirstName nvarchar(50) not null ,
    LastName nvarchar(50) not null ,
    Phone nchar(12) not null ,
    Salary decimal(18,2) not null
)
--Orders
create table Orders(
    Id int PRIMARY KEY IDENTITY ,
    DateTime datetime2 not null ,
    EmployeeId int FOREIGN KEY REFERENCES Employees(Id) not null
)
--OrderItems
create table OrderItems(
    OrderId int FOREIGN KEY REFERENCES Orders(Id) not null ,
    ItemId int FOREIGN KEY REFERENCES Items(Id) not null ,
    Quantity int not null CHECK (Quantity >=1) ,
    PRIMARY KEY (OrderId, ItemId)
)
--Shifts
create table Shifts(
    Id int IDENTITY ,
    EmployeeId int FOREIGN KEY REFERENCES Employees(Id) ,
    CheckIn datetime2 not null ,
    CheckOut datetime2 not null ,
    CONSTRAINT CHK_CheckIn CHECK (CheckIn < CheckOut) ,
    CONSTRAINT PK_Shifts PRIMARY KEY (Id, EmployeeId)
)

--2. Insert
--Insert some sample data into the database.
-- Write a query to add the following records into the corresponding tables.
-- All Ids should be auto-generated.

insert into Employees (FirstName, LastName, Phone, Salary)
values
('Stoyan',	'Petrov',	'888-785-8573',	500.25),
('Stamat',	'Nikolov',	'789-613-1122',	999995.25),
('Evgeni',	'Petkov',	'645-369-9517',	1234.51),
('Krasimir',	'Vidolov',	'321-471-9982',	50.25)

insert into Items (Name, Price, CategoryId)
values
('Tesla battery',154.25,8),
('Chess',30.25,8),
('Juice',5.32,1),
('Glasses',10,8),
('Bottle of water',1,	1)

--3. Update
--Make all items’ prices 27% more expensive where the category ID is either 1, 2 or 3.

update Items set Price *= 1.27 where CategoryId IN (1,2,3)

--4. Delete
--Delete all order items where the order id is 48 (be careful with the relationships)
delete OrderItems where OrderId = 48

--5. Richest People
--Select all employees who have a salary above 6500.
-- Order them by first name, then by employee id.

select Id, FirstName from Employees where Salary > 6500
order by FirstName asc , Id asc

--6. Cool Phone Numbers
--Select all full names from employees, whose phone number start with ‘3’.
--Order them by first name (ascending), then by phone number (ascending).
select concat(FirstName, ' ', LastName) as [Full Name], Phone as [Phone Number]
from Employees where Phone like '3%'
order by FirstName asc , Phone asc

--7. Employee Statistics
--Select all employees who have orders with the total count of the orders they processed.
-- Order them by their orders count (descending), then by first name.
-- Select their first name, last name and total count of orders.

select FirstName, LastName, count(O.EmployeeId) as Count from Employees as E
join Orders O on E.Id = O.EmployeeId
group by FirstName, LastName
order by Count desc , FirstName

--8. Hard Workers Club
--Select all employees whose workday is over 7 hours long on average, based on their check in/check out times.
-- Select their first, last name and average work hours.
--Order them by work hours (descending), then by employee ID.
select FirstName, LastName, AVG(DATEDIFF(hour , CheckIn, CheckOut)) as [Work hours] from Employees as E
join Shifts S on E.Id = S.EmployeeId
group by E.FirstName, E.LastName, E.Id
having avg(DATEDIFF(hour , CheckIn, CheckOut)) > 7
order by [Work hours] desc , E.Id

--9. The Most Expensive Order
--Find the most expensive order.
-- Select its id and total item price.
-- Consider the item quantity when calculating the price.

select top(1) OI.OrderId, sum(OI.Quantity * I.Price) from OrderItems as OI
join Items I on OI.ItemId = I.Id
group by OI.OrderId
order by sum(OI.Quantity * I.Price) desc

--10. Rich Item, Poor Item
--Find the top 10 most expensive and cheapest item in each order.
--Order the results by most expensive item’s price (descending), then by order id (ascending).

select top(10) O.Id, max(I.Price) as ExpensivePrice, min(I.Price) as CheapPrice from Orders as O
join OrderItems OI on O.Id = OI.OrderId
join Items I on OI.ItemId = I.Id
group by O.Id
order by ExpensivePrice desc , O.Id

--11. Cashiers
--Find all employees who have orders. Select their id, first name and last name.
-- Order them by employee id.

select E.Id, E.FirstName, E.LastName from Orders as O
left join Employees E on O.EmployeeId = E.Id
group by E.Id, E.FirstName, E.LastName
order by E.Id

--12. Lazy Employees
--Find all employees, who have below 4 work hours per day.
--Order them by employee id.
select E.Id, concat(FirstName, ' ',LastName) as [Full Name] from Employees as E
join Shifts S on E.Id = S.EmployeeId
where  DATEDIFF(hour , S.CheckIn, S.CheckOut) < 4
group by E.FirstName, E.LastName, E.Id
order by E.Id asc

--13. Sellers
--Find the top 10 employees with their full name, orders’ total price and item count.
--Count only orders which were ordered before 2018-06-15.
--Order them by total sum (descending), then by item count (descending)

--
select top (10) concat(FirstName, ' ', LastName) as [Full Name],
       sum(OI.Quantity * I.Price) as [Total Price], sum(OI.Quantity ) as Items from OrderItems as OI
join Items I on OI.ItemId = I.Id
join Orders O on OI.OrderId = O.Id
join Employees E on O.EmployeeId = E.Id
where DateTime < '2018-06-15'
group by E.Id, E.FirstName, E.LastName
order by [Total Price] desc , Items

--14. Tough days
--Find all records of the employees who don’t have orders and who work over 12 hours.
--Select only their full name and day of the week.
--Order the results by employee id.
--Note: By the American Standards, Sunday is the first day of week.

SELECT
  e.FirstName + ' ' + e.LastName AS FullName,
  CASE
  WHEN DATEPART(WEEKDAY, s.CheckIn) = 2
    THEN 'Monday'
  WHEN DATEPART(WEEKDAY, s.CheckIn) = 3
    THEN 'Tuesday'
  WHEN DATEPART(WEEKDAY, s.CheckIn) = 4
    THEN 'Wednesday'
  WHEN DATEPART(WEEKDAY, s.CheckIn) = 5
    THEN 'Thursday'
  WHEN DATEPART(WEEKDAY, s.CheckIn) = 6
    THEN 'Friday'
  WHEN DATEPART(WEEKDAY, s.CheckIn) = 7
    THEN 'Saturday'
  WHEN DATEPART(WEEKDAY, s.CheckIn) = 1
    THEN 'Sunday'
  END                            as DayOfWeek
FROM Employees AS e
  LEFT JOIN Orders AS o ON o.EmployeeId = e.Id
  JOIN Shifts AS s ON s.EmployeeId = e.Id
WHERE o.Id IS NULL AND DATEDIFF(HOUR, s.CheckIn, s.CheckOut) > 12
ORDER BY e.Id

--15. Top Order per Employee
--Find all information of the employees who have orders.
-- Select their full name, duration of the work day (in hours) and total price of all sold products.
-- Find only the top orders (top orders with highest total price).
--Sort them by full name (ascending), work hours (descending) and total price (descending)
SELECT emp.FirstName + ' ' + emp.LastName AS FullName, DATEDIFF(HOUR, s.CheckIn, s.CheckOut) AS WorkHours, e.TotalPrice AS TotalPrice FROM
 (
    SELECT o.EmployeeId, SUM(oi.Quantity * i.Price) AS TotalPrice, o.DateTime,
	ROW_NUMBER() OVER (PARTITION BY o.EmployeeId ORDER BY o.EmployeeId, SUM(i.Price * oi.Quantity) DESC ) AS Rank
    FROM Orders AS o
    JOIN OrderItems AS oi ON oi.OrderId = o.Id
    JOIN Items AS i ON i.Id = oi.ItemId
GROUP BY o.EmployeeId, o.Id, o.DateTime
) AS e
JOIN Employees AS emp ON emp.Id = e.EmployeeId
JOIN Shifts AS s ON s.EmployeeId = e.EmployeeId
WHERE e.Rank = 1 AND e.DateTime BETWEEN s.CheckIn AND s.CheckOut
ORDER BY FullName, WorkHours DESC, TotalPrice DESC


--16. Average Profit per Day
--Find the average profit for each day. Select the day of month and average daily profit of sold products.
--Sort them by day of month (ascending) and format the profit to the second digit after the decimal point.
SELECT
DATEPART(DAY, o.DateTime)  AS [DayOfMonth],
CAST(AVG(i.Price * oi.Quantity)  AS decimal(15, 2)) AS TotalPrice
FROM Orders AS o
JOIN OrderItems AS oi ON oi.OrderId = o.Id
JOIN Items AS i ON i.Id = oi.ItemId
GROUP BY DATEPART(DAY, o.DateTime)
ORDER BY DayOfMonth ASC

--17. Top Products
--Find information about all products. Select their name, category,
--              how many of them were sold and the total profit they produced.
--Sort them by total profit (descending) and their count (descending)

SELECT
  i.Name,
  c.Name,
  SUM(oi.Quantity)  As [Count],
  SUM(i.Price * oi.Quantity) AS TotalPrice
FROM Orders AS o
  JOIN OrderItems AS oi ON oi.OrderId = o.Id
  RIGHT JOIN Items AS i ON i.Id = oi.ItemId
  JOIN Categories AS c ON c.Id = i.CategoryId
GROUP BY i.Name, c.Name
ORDER BY TotalPrice DESC, [Count] DESC

--18. Promotion days
/*
 Create a user defined function,
named udf_GetPromotedProducts(@CurrentDate, @StartDate,
        @EndDate, @Discount, @FirstItemId, @SecondItemId, @ThirdItemId),
 that receives a current date, a start date for the promotion, an end date for the promotion,
    a discount, a first item id, a second item id and third item id.
The function should print the discounted price of the items, based on these conditions:
•	The first, second and third items must exist in the database.
•	The current date must be between the start date and end date.
If both conditions are true, you must discount the price and print the following message in the format:
•	 “{FirstItemName} price: {@FirstItemPrice} <-> {SecondItemName}
        price: {@SecondItemPrice} <-> {ThirdItemName} price: {@ThirdItemPrice}”
If one of the items is not in the database, the function should return
    “One of the items does not exists!”
If the current date is not between the start date and end date, the function should return
    “The current date is not within the promotion dates!”
 */
--ALTER FUNCTION udf_GetPromotedProducts
create function udf_GetPromotedProducts(@CurrentDate date, @StartDate date,
  @EndDate date, @Discount int, @FirstItemId int, @SecondItemId int, @ThirdItemId int)
    returns varchar(80)
as
    begin
    DECLARE @FirstItemPrice decimal(18,2) = (select Price from Items where Id = @FirstItemId);
    DECLARE @SecondItemPrice decimal(18,2) = (select Price from Items where Id = @SecondItemId);
    DECLARE @ThirdItemPrice decimal(18,2) = (select Price from Items where Id = @ThirdItemId);

    IF (@FirstItemPrice is null or @SecondItemPrice is null or @ThirdItemPrice is null )
        begin
                RETURN 'One of the items does not exists!';
        end
    IF (@CurrentDate < @StartDate) or (@CurrentDate > @EndDate)
        begin
            RETURN 'The current date is not within the promotion dates!'
        end
    DECLARE @NewFirstItemPrice decimal(18,2) = @FirstItemPrice - (@FirstItemPrice * @Discount / 100)
    DECLARE @NewSecondPrice decimal(18,2) = @SecondItemPrice - (@SecondItemPrice * @Discount /100);
    DECLARE @NewThirdItemPrice decimal(18,2) = @ThirdItemPrice - (@ThirdItemPrice * @Discount / 100);

    DECLARE @FirstItemName varchar(50) = ( select [Name] from Items where Id = @FirstItemId );
    DECLARE @SecondItemName varchar(50) = ( select [Name] from Items where Id = @SecondItemId );
    DECLARE @ThirdItemName varchar(50) = ( select [Name] from Items where Id = @ThirdItemId );

    RETURN @FirstItemName +' price: ' + CAST(ROUND(@NewFirstItemPrice, 2) as varchar) + ' <-> ' +
        @SecondItemName + ' price: ' + CAST(ROUND(@NewSecondPrice,2) as varchar) + ' <-> ' +
           @ThirdItemName + ' price: ' + CAST(ROUND(@NewThirdItemPrice,2) as varchar)
    end

    SELECT dbo.udf_GetPromotedProducts('2018-08-02', '2018-08-01', '2018-08-03',13, 3,4,5)
/*
 Example:
Query
SELECT dbo.udf_GetPromotedProducts('2018-08-02', '2018-08-01', '2018-08-03',13, 3,4,5)
Output
Water price: 0.74 <-> Juice price: 1.31 <-> Ayran price: 4.35

Query
SELECT dbo.udf_GetPromotedProducts('2018-08-01', '2018-08-02', '2018-08-03',13,3 ,4,5)
Output
The current date is not within the promotion dates!

 */

 --19. Cancel order
/*
Create a user defined stored procedure,
    named usp_CancelOrder(@OrderId, @CancelDate),
    that receives an order id and date, and attempts to delete the current order.
        An order will only be deleted if all of these conditions pass:
•	If the order doesn’t exists, then it cannot be deleted.
    Raise an error with the message “The order does not exist!”
•	If the cancel date is 3 days after the issue date, raise an error with the message
        “You cannot cancel the order!”
If all the above conditions pass, delete the order.
 */

create proc usp_CancelOrder(@OrderId int, @CancelDate DATE)
as
    begin
            DECLARE @SearchOrderID int = (select Id from Orders where Id = @OrderId)
        IF (@SearchOrderID is null )
        begin
                ;THROW 51000, 'The order does not exist!' , 1;
        end
        DECLARE @OrderDate DATE = (select DateTime from Orders where Id = @OrderId)
        DECLARE @DateDiff int = DATEDIFF(day, @OrderDate, @CancelDate)

        IF (@DateDiff > 3)
        begin
            ;THROW 51000, 'You cannot cancel the order!' , 2;
        end

        delete from OrderItems where OrderId = @OrderId;
        delete from Orders where Id = @OrderId;
    end

EXEC usp_CancelOrder 1, '2018-06-02'

EXEC usp_CancelOrder 1, '2018-06-15'






