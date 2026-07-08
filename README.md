--This is a comment 
/* this is
a comment
*/
use MyDatabase

select *    -- Retrieve all columns in the customers
from dbo.customers

SELECT *
FROM orders

SELECT first_name,
country,
score     -- Select requested columns from the table
FROM customers
-- customers whose score is not equal to 0
select *
from customers
where 
score <> 0 -- Filter the rows in the selectio on a condition

-- Customer from genrmany
select first_name, country
from customers
where country='Germany'

---retrieve all the cutomers sort the results by the highest score first
select * 
from customers 
order by score desc --## Diplay the resuls ordered by a column

--Nested sorting
--Retrieve all customers ouder by coutry ascending and then by highest score.
SELECT *
From
customers
order by
country asc,
score desc

-- Get total score group by country
select 
country,
sum(score) as TotalScore
from customers
group by country

-- Get total score and number of customer for each coutry
-- ## Groupby used to find the aggregate values based on field 

select
country,
SUM(score) as Total_Score,
COUNT(*) as [Count]
from customers
group by country
order by country asc, [Count] desc

-- Having filter in Find the average score of each contry
-- considering only customers with score not equal to 0
-- average score is greater than 450  ##  (Having used to add filter on the aggregates)

select 
country,
AVG(score) as Averagas 
from  customers
where score <> 0
group by country
having  AVG(score) > 450

-- select unique list of all contries ## Distinct
select distinct country
from customers

-- Top ## select few rows, it is not a filter but only retrieve the number of rows.
use mydatabase
select
top 4
*
from customers

select * from customers

select
top 3 * from customers
order by score asc, country desc

--## Retrieve lowets 2 customers based on score
select 
top 2 *
from customers
order by score asc

-- ## get the 2 most recent orders
select top 2 *
from orders
order by order_date desc


/*
SELECT DISTINCT ==(5)
TOP 3 ==(7)
COLUMN1,
COLUMN2,
AVG(COLUMN3)
FROM TableName    == (1)
WHERE COLUMN1 > 10 ==(2)
GROUP BY COULUMN3 ==(3)
HAVING AVG(COULMN3) > 100 ==(4)
ORDER BY COULMN1 DESC ==(6)
*/

SELECT 'Sudhakar,Joyothsna,Nidhi,Nikki' as MyFamily, 4 as H_Count

--- DDL commands  ## Create/Alter/Drop
create table persons(
id int not null,
person_name nvarchar(200) not null,
birth_date datetime,
phone varchar(12) not null,
Constraint pk_persons Primary Key (id)
)


-- Alter table add new columm email

alter table persons
add email varchar(50) not null

-- Remove phone column from persons table
alter table persons
drop column phonen

-- DROP the table
drop table persons
--select * from persons

--## DML DATA MANIPULATION LANGUAGE
select * from customers

insert into customers(id, first_name, country, score)
values(6,'sudhakar','India',200),
(7,'Anil','Uk',500);

select top 3
country, sum(score) as total_score
from customers
where score >=200
group by country
having sum(score) > 400
order by country

create table persons(
Id int not null,
person_name varchar(50) not null,
birth_date date null,
phone varchar(14) not null,
constraint pk_person primary key (Id)
)
select * from persons

select 
id,
first_name,
NULL,
'UnKnown'
from customers

insert into persons
select 
id,
first_name,
NULL,
'UnKnown'
from customers

-- Update change the score of customer 6 to 0
update customers
set score=0
where id=6


insert into customers(id, first_name)
values(8, 'Rahul'),
(9, 'Fred'),
(10, 'Alex')

-- upate the score of customer id 10 to 0 and country to Uk

update customers
set score=0,
    country='UK'
where id=10

-- Update all customers with setting their score to 0 when it is null
update customers
set score = 0
where score is null

-- Delete , deltes the rows from table allways must have a where filter else all the rows in the table will be deleted
-- delete the customers whose id is greater than 5

delete from
customers
where id > 5



-- delete all records from table persons

delete from persons

truncate table persons
select *
from persons
--## Filte operators
-- Comparitive operaters
-- Get all customers who are from germany.
-- Column = value, = operator.
select *
from customers
where country='Germany'

-- customers not from 
-- can use !=, <> operators
select *
from customers
where country != 'Germany'

-- Retrieve all the customer with score greater than 500
-- > Operator

select * 
from customers
where score > 500

-- Retrieve all the customer with score greater than or 500
-- >= Operator

select *
from customers
where score >= 500

-- Retrieve all the customer with score less than or 500
-- >= Operator

select *
from customers
where score <= 500

-- ## Logical operator AND, OR, NOT
-- Filter on multiple conditions

-- Retrieve all custmers basedd in USA wiht score greater than 500
-- AND operator
select *
from customers
where country='USA' 
AND score > 500

-- Or Operator
-- Retrieve all the customers who are either from usa or have score greater than 500
select *
from customers
where score >= 500
or country = 'USA'

-- Not operator
-- Exludes the matches
-- Reyrieve all the customers with score not less than 500

select *
from customers
where not score < 500

-- Range operators # Between , between the boundaries and boundaries are inclusive
-- Retrieve all the customers whose score is in range of 100 to 500
select*
from customers
where score between 100 and 500

-- also can be written using logical and
select *
from customers
where score >= 100
and score <=500

-- ## Membership operators IN, NOT IN
-- Filter the data in or not in the list

-- retrieve the customers from either germay or usa

select *
from customers
where country = 'Germany' or country ='USA'

select *
from customers
where country in ('Germany','USA')

-- In is simplified version of multiple or operators and faster 

-- Search oeprators with like % and -
-- Retrieve all the customers whose name sarts with M

select *
from customers
where first_name like 'M%'

-- Retrieve all the customers whose first name ends wiht n

select *
from customers
where first_name like '%n'

-- Retrieve all the customers whose first name contains r
select *
from customers
where first_name like '%r%'

-- Retrieve all the customers whose first name contains r in 3rd place
select *
from customers
where first_name like '__r%'

select * from customers


-- # Data from multiple tables
-- Using Joins and Set operators
-- Join require key column between two tables  (Inner, left , right, join)
-- Set operator require same number and type of columns from two tables (Union, Union All, Intersect, Except)

-- # Sql joins help us to 
------Recombine data from decomposed tables
------Extend existing primary table
------Check existance of the related data in the other table.

-- # No Join
-- Return data from two tables with out combining them.
select *
from customers;

select *
from orders;

-- #Inner Join Only matching data from both the tables

select *
from customers c, orders o
where c.id = o.customer_id

---# retrieve orders for customers but only customers who have placed their orders
select 
c.id,
c.first_name,
c.country,
c.score,
o.order_id,
o.order_date,
o.sales
from customers c
inner join orders o
on c.id = o.customer_id

--## Left join ==> all the data from left table and matching data from the right table.
-- Order of the table is important.
-- Key word Left Join

-- Get all cutomers along with theri orders inlcuding those without orders
use MyDatabase

select
c.id, 
c.first_name,
o.order_date,
o.order_id,
o.sales
from customers c
left join
orders o
on c.id = o.customer_id

-- Right join all from right table including orders wihtout matching customers
-- Get all the cutomers wiht orders, and alos ordes without customers

select 
c.id, 
c.first_name,
o.order_date,
o.order_id,
o.sales
from 
customers c
right join orders o
on c.id = o.customer_id

-- Above querry with left join.

select 
c.id, 
c.first_name,
o.order_date,
o.order_id,
o.sales
from 
orders o
left join customers c
on c.id = o.customer_id

-- ## Full join get all the data from both the tables if if there is not match.
-- Order of table is not important
select
c.id, 
c.first_name,
o.order_date,
o.order_id,
o.sales
from
customers c
full join
orders o
on c.id = o.customer_id

-- Advance Joins
-- Left anti Join Only eisit in table A but not In B table
-- Get all customers who haven't places any order.
select 
*
From
customers c
left join 
orders o
on c.id = o.customer_id
where o.customer_id is null

-- similar query with in 
select * from customers where id not in  (select customer_id from orders)

-- Right anti join
-- Get all orders which are not mapped to any cutomers

select *
from 
customers c
right join
orders o
on c.id = o.customer_id
where c.id is null

-- same querry using left anti join

select *
from orders o
left join customers c
on c.id = o.customer_id
where c.id is null

-- ## Full Anti join, data from the left, right table but skip the custmer who have orders

select 
*
from 
customers c
full join 
orders o
on c.id = o.customer_id
where c.id is null or o.customer_id is  null

-- Get all customers along wiht their orders but only the customers who have places an order.
-- with put inner join
select *
from customers c
left join 
orders o
on c.id = o.customer_id
where o.customer_id is not null


-- # Cross join do not have any condition or key
select *
from customers
cross join
orders


select *
from customers
cross join
orders
where customer_id = id


-- joins exercise
-- Use Sales Db

use SalesDB;
select * from Sales.Orders;
select * from Sales.Customers;
select * from Sales.Products;
select * from Sales.Employees;

--Retrieve list of all orders, along with related customers, product, employ details
select
o.OrderID,
c.FirstName + ' ' + c.LastName  AS 'Customer Name',
p.Product as ProductNamr,
o.Sales,
p.Price,
e.FirstName +' '+ e.LastName as 'Sales Person Name'
from
Sales.Orders o
left join
Sales.Customers c
on o.CustomerID = c.CustomerID
left join 
Sales.Products p
on o.ProductID = p.ProductID
left join 
Sales.Employees e
on o.SalesPersonID = e.EmployeeID;

use SalesDB

--Sets comibne rows from mutiple tables.
---##Join, where, group by, having can be used with every select query in set but Order By must be only used one in the query.
-- ## Number of colums in all the select queries must be the same.
-- ## Datatypes of the selected queries must match and be compatable
-- ## Order of the columns in each query must be the same
-- ## (Alias Names)/ Column names in the result set is determined by the first query in the set.
-- ## Seelct Correct columns

--## UNION
select 
FirstName F_Name,
LastName
from Sales.Customers
where FirstName like '%r%'
UNION
Select 
FirstName,
LastName
From Sales.Employees
--## UNION Selects combines all the rows from all tables without any duplicates.

select
FirstName,
LastName
from Sales.Customers
UNION
select 
FirstName,
Lastname
from Sales.Employees;
-- ## Except 
-- Except is used to find the unique ones form the first table but not present in the second tab
-- Query return the customers who are not employees.
select
FirstName,
LastName
from Sales.Customers
EXCEPT
select 
FirstName,
Lastname
from Sales.Employees;

-- Query return the Employeee who are not customers.
select
FirstName,
LastName
from Sales.Employees
EXCEPT
select 
FirstName,
Lastname
from Sales.Customers;

-- ## Union All (return the duplicate from the queries)
-- Combine data from customers and employees including duplicates
select
FirstName,
LastName
from Sales.Customers
UNION All
select 
FirstName,
Lastname
from Sales.Employees
order by FirstName

-- ## Intersect get the records avaialble in both the queries
select
FirstName,
LastName
from Sales.Customers
Intersect
select 
FirstName,
Lastname
from Sales.Employees
order by FirstName

-- ## Orders are stored in seperate tables (orders and orderaArchive)
-- Combine all the orders into one report without duplicate
-- Never use * ,if schema changes in any one of the table. This may impact the union so allways go with column names in the query
select
	   'Orders' as 'SourceTable'
	  ,[OrderID]
      ,[ProductID]
      ,[CustomerID]
      ,[SalesPersonID]
      ,[OrderDate]
      ,[ShipDate]
      ,[OrderStatus]
      ,[ShipAddress]
      ,[BillAddress]
      ,[Quantity]
      ,[Sales]
      ,[CreationTime]
from Sales.Orders
Union
select
      'OrdersArchive' as 'SourceTable'
	  ,[OrderID]
      ,[ProductID]
      ,[CustomerID]
      ,[SalesPersonID]
      ,[OrderDate]
      ,[ShipDate]
      ,[OrderStatus]
      ,[ShipAddress]
      ,[BillAddress]
      ,[Quantity]
      ,[Sales]
      ,[CreationTime]
from Sales.OrdersArchive;

--## Functions :- are the sqlscripts that take a single or mulitple values as input process them and return a value as result.
-- Single row functions, mutiple row functions, nested fucntions.
-- Nested function ex: Given Name "Maria" need the Firt 2 characters of the name in lower case.
-- Maria ==> Left('Maria',2) ==> Ma ==> Lower('Ma') =ma
-- Lower(Left('Mari',2)) ==> ma
-- Inner functionexecute the first
-- Single row function (sring, number, date and null) ==> Data engineers
-- Multi row functions (aggregate funcitons, windows functions)==> Data scientists

-- #String functions (Manipulations, Calculations, String Extractions)
-- Manipulations

-- Contact
--- Seelct customer first name together wiht their country in one colum,
select
CONCAT(FirstName,' ', Country) as 'Name & Country'
from Sales.Customers

--Upper(),Lower()

select
FirstName,
Lower(LastName),
Upper(Country)
from
Sales.Customers

-- Find customers whose first name contains leading or trainling spaces
-- Using trim()

select
*
from
Sales.Employees
where FirstName != Trim(FirstName);

-- Replace(value, old,new) replace the old with the new in the provided value
Select
'123-456-789' as OldFormat
,REPLACE('123-456-789','-','/') as NewFormat

-- String Calculation function Len()
select
LEN('+91-961823277') as NumberLenght
select
FirstName,
LEN(FirstName) as namelenght
from
Sales.Employees

-- String extraction fucntions LEFT,RIGHT, 
-- Left extract the number of chanracters from left in given string
-- Right extract the number of characters from right in the given string
select
CustomerID,
FirstName,
LEFT(FirstName, 4),
LastName,
RIGHT(LastName,3),
Country
from 
Sales.Customers

-- Subsrting extract number of chars from value from some position
select
CustomerID,
FirstName,
substring(FirstName,2, 2), -- Extract 2 characters after 2 nd cahracter
substring(FirstName, 2, LEN(FirstName)-2)
from 
Sales.Customers

-- Select the customers removing the first character in their first name.
select
CustomerID,
FirstName,
SUBSTRING(FirstName,2,LEN(FirstName)),
LastName,
Country
from 
Sales.Customers
-- NUmber Functions
-- Round()
Select 
ROUND(1.56789,4) as 'Rounded-4',
ROUND(1.56789,3) as 'Rounded-3',
ROUND(1.56789,2) as 'Rounded-2',
ROUND(1.56789,1) as 'Rounded-1',
ROUND(1.56789,0) as 'Rounded-0'
--1.56790	1.56800	1.57000	1.60000	2.00000
select 
ABS(-1000),
ABS(1000)

--Date Time Functions
-- 2025-08-10 15-19-45
use salesdb

select
OrderDate,
ShipDate,
CreationTime,
'20256-06-29' as Today,
getdate() as 'Now'
from
Sales.Orders

-- # Extract Part of Date Date functions
-- Day(),Year(),Month()

select 
GETDATE() as Now,
DAY(GETDATE()) as 'Date',
Month(GETDATE()) as 'Month',
YEAR(Getdate()) as 'Year';

-- DatePart, DatePart(part,date)

select
CreationTime,
Datepart(SECOND, CreationTime) as 'Seconds',
Datepart(MINUTE, CreationTime) as 'Mins',
Datepart(HOUR, CreationTime) as 'hour',
DatePart(day, CreationTime) as 'Date',
Datepart(week, CreationTime) as 'Week',
DateName(WEEKDAY, CreationTime) as 'WeekDay',
DatePart(month, CreationTime) as 'Month',
DateName(MONTH, CreationTime) as 'MonthName',
Datepart(quarter, CreationTime) as 'Quarter',
Datepart(year, CreationTime) as 'Year'
from 
Sales.Orders

-- Select all the orders which fall in the second quarter of the year
select 
*
from 
Sales.Orders
where DATEPART(quarter,creationtime) =2;

-- DateTrunc, funtion returns till the part of the date

select
creationtime,
Datetrunc(year,creationtime) as 'Only Year',
DateTrunc(month, creationtime) as 'To Month',
Datetrunc(day, creationtime) as 'to day',
datetrunc(HOUR, creationtime) as 'to hours',
datetrunc(MINUTE, CreationTime) as 'to mins',
DATETRUNC(second, CreationTime) as 'to sec'
from
Sales.Orders
-- Group the orders by their month of creation.
select 
datetrunc(month, creationtime) as 'Month Of Creation',
count(*) as  'Count'
from
Sales.Orders
group by datetrunc(month, creationtime)

select
creationtime,
EOMONTH(creationtime) as 'End of month date'
from
Sales.Orders

select
creationtime,
EOMONTH(creationtime) as 'End of month date',
datetrunc(month, EOMONTH(creationtime)) as 'start of month'
from
Sales.Orders

-- How many orders are placed by year
select 
COUNT(*),
datetrunc(year, orderdate) as 'Year of Order'
from 
Sales.Orders
group by datetrunc(year, orderdate)

select 
COUNT(*),
year(orderdate) as 'Year of Order'
from 
Sales.Orders
group by year(orderdate)

-- How many orders were placed each month
select
COUNT(*) as 'Orders Count',
DateName(month, OrderDate) as 'Month'
from 
Sales.Orders
group by DateName(month, OrderDate)

-- Show all orders that are placed during the month of february
select
*
from
Sales.Orders
where MONTH(OrderDate) = 2

-- Format function
-- Fprmat the result wiht order date like dd/mm/yyyy
select 
format(orderdate, 'dd/MM/yyyy') as Order_Date
from
Sales.Orders

-- Show creation time using the format Day, Wed Jan q1 2025 12:34:56 pm
-- Format has culture

select
creationtime,
format(creationtime, 'ddd MMM yyyy hh:mm:ss ') as FormattedDate,
'Day' + ' ' + Format(creationtime, 'ddd MMM')  + ' Q'+ DATEName(QUARTER, CreationTime) + FORMAT(CreationTime, ' yyyy hh:mm:ss tt') as 'Format'
from
Sales.Orders 

-- Convert convert(type,value[,style])
-- Convert used as cast fucntion and convert to specific format using style
select 
convert(int, '123') +1 as 'string to int',
CONVERT(date, '2025-12-23') as 'string to date',
creationtime,
CONVERT(date, creationtime) as createddate,
CONVERT(varchar, creationtime, 32) as 'US Format:32',
CONVERT(varchar, creationtime,34) as 'UK Format:34'
from 
sales.orders

-- Cast covert from one type to other type
select 
CAST(123 as varchar) + 'abc' as 'Int to string',
cast('124' as int)+ 23 as 'strin8 to int',
CAST('12-1-2025' as date) 'string to date',
CAST('12-1-2025' as datetime) 'string to date',
cast(creationtime as time) 'creation time'
from
Sales.Orders

-- ## Cast, Convert, Format;
-- Cast ==> convert any datatype to other data  type.

-- Covert ==> any datatype to other datatype in adition it can format only datetime.

-- Format ==> Cast any datatype to only string and can format Numbers and Datetime

-- Date calulations (DateAdd, DateDiff)
-- Date Add.
-- Syntax DateAdd(part, interval,date)

Select 
GETDATE() as date,
-month(getdate()) as interval, 
DATEADD(month, -month(getdate()), getdate()) as 'new date' 

select 
OrderID,
OrderDate,
DATEADD(year,2,OrderDate) as 'Date after 2 years',
DATEADD(week, 5, OrderDate) as '5 weeks after order date'
from
Sales.Orders

-- Date Diff provide the difference between two date.
-- Sytax DateDiff(part,startdate,enddate)

select 
OrderDate,
ShipDate,
DATEDIFF(year, OrderDate,ShipDate) as 'Order will be delivered in Years',
DATEDIFF(month, OrderDate, ShipDate) as 'will be delivered in months',
DATEDIFF(week, OrderDate,ShipDate) as 'Will be delivered in weeks',
DATEDIFF(day, OrderDate,ShipDate) as 'Will be delivered in days'
from
Sales.Orders

-- Calculate the age of all the employees
select
CONCAT(FirstName,' ', LastName) as name,
DATEDIFF(year, BirthDate, GETDATE()) as 'Age in Years'
from
Sales.Employees

select
CONCAT(FirstName,' ', LastName) as name,
Year(getdate()) - Year(Birthdate) as 'Age'
from
Sales.Employees

-- Find the average shipping duration in day for each moth
select 
--Orderdate,
Avg(DATEDIFF(day, OrderDate,ShipDate)) as 'Shipping Duration',
DATETRUNC(month,Shipdate)
from 
Sales.Orders
group by DATETRUNC(month,Shipdate)

select 
--Orderdate,
Avg(DATEDIFF(day, OrderDate,ShipDate)) as 'Shipping Duration',
month(Shipdate)
from 
Sales.Orders
group by month(Shipdate)

-- Find the number of day between each oder and the previous order
-- Windows function LAG() to get privous date
select
OrderID,
OrderDate,
LAG(OrderDate) over (Order by Orderdate) as 'Previous Order Date',
DATEDIFF(day, LAG(OrderDate) over (Order by Orderdate), OrderDate) as 'Previous Order was before days'
from
Sales.Orders

--## Date Validation
-- ISDate(Value);

Select
OrderDate,
ISDATE(OrderDate),
case when ISDATE(orderdate)=1 then CAST(orderdate as date)
	else '9999-1-1'
end 'New date'
from (
		select'2025-08-12' As orderdate union
		select '2025-09-12' union
		select '2026-03-28' union
		select '2026-04'
	  )t

-- NUll Function Null means nothing in SQL
--ISNULL(value1, value2), COALASCE(value1, value2, value2)
--ISNUll(value1, 'ConstantValue')
use salesdb

-- Fine the average scores of customers.
select
*
from
Sales.Customers

select 
CustomerId,
Score,
avg(Score) over () avgScore
from
Sales.Customers

select 
CustomerId,
Score,
coalesce(score,0) as nonzeroscore,
avg(Score) over () avgScore,
SUM(score) over () sumscore,
AVG(COALESCE(score,0)) over () average
from
Sales.Customers

select 
*
from 
Sales.Customers
--Display the full name of customers in sinlge field 
--by merging their firstname and lastname
--and  add 10 bonus points to each customer's score

select
CustomerID,
LastName + ' ' + FirstName as Fullname,
coalesce(LastName, '') + ' ' + coalesce(FirstName,'') as cFullName,
Score + 10 as score,
coalesce(score,0)+10 as cscore
from
Sales.Customers

-- sort the customers
select
* --,
--case when score is null then 1 else 0 end flag
from
Sales.Customers
order by 
case when score is null then 1 else 0 end,
Score

-- Find the sales price for each order, by dividing the sales by quantity.
select
OrderID, Quantity, Sales,
--Sales/Quantity as salesprice
Sales/NULLIF(Quantity,0) as salesprice
from
Sales.Orders
-- Show the list of customers who does not have scores.
select 
*
from 
Sales.Customers
where score is null

select
*
from
Sales.Customers
where Score is not null

-- Is Null Use case ANTi JOINs
-- Left anti join
select 
*
from 
Sales.Customers;

select 
*
from 
Sales.Orders

--- #LEFT ANTI JOIN
--1) Left join select all customer even of no orders
select
*
from Sales.Customers c
left join
Sales.Orders o
on c.CustomerID = o.CustomerID

--2) Left anti Join select all customer only who have not placed any orders

select
*
from Sales.Customers c
left join
Sales.Orders o
on c.CustomerID = o.CustomerID
where o.CustomerID is null

With OrdersCte as (
select 1 Id, 'A' as Category Union
select 2 , null union
select 3, '' union
select 4, ' ' union
select 5, '   '
)
select
* ,
DATALENGTH(Category) as proplength,
--datalength(trim(category)) as proplength1,
NullIf(trim(category),''), -- Use null for sting.empty and blank spaces
coalesce(NullIf(trim(category),''), 'UnKnown')  -- Use default value as 'Unknown' avoid using null, empty string and blank spaces
from OrdersCte

use SalesDB

select 
*
from 
Sales.Customers

-- ## Case statement used in data transformations
-- Create new clomuns group and categorize data  based on multiple conditions
select 
CustomerID,
CONCAT(LastName, ' ', FirstName) as FullName,
Country,
Coalesce(Score,0) as Score,
Case
	when Score >= 900 then 'High' 
	when Score >= 500 then 'Medium'
	else 'Low' 
end as 'ScoreGrade'
from
Sales.Customers
--##Create report showing total sales for each of the following categories:
-- High (sales over 50), Medium (sales 21-50) and low (sales 20 or less)
-- Sort the categories from highest sales to lowest.
-- Must meet a condition as data types of result is missing.
select
OrderID,
Sales,
case
	when Sales >= 50 then 'High'
	when Sales between 21 and 50 then 'Medium'
	else 'Low'
end 'Category'
from
Sales.Orders
order by Sales desc

Select
Category,
SUM(Sales) as 'Total Sales'
from (
		select
		OrderID,
		Sales,
		case
			when Sales > 50 then 'High'
			when Sales > 20 then 'Medium'
			else 'Low'
		end 'Category'
		from
		Sales.Orders
		)t
group by Category
order by 'Total Sales' desc

-- Retrive the employee details with gender displayed as full text.
select
EmployeeID,
CONCAT(FirstName,' ',LastName) as 'Full Name',
Case
	When Gender = 'M' then 'Male'
	When Gender = 'F' then 'Female'
	else 'Na'
End Gender
from
Sales.Employees

-- Retrive the cusotmer details with abrevated contry code.
select
CustomerID,
FirstName,
LastName,
Country,
case
	when Country = 'Germany' then 'DE'
	when Country = 'USA' then 'US'
	else 'NA'
end ShortName,
case Country
	when 'Germany' then 'DE'
	when 'USA' then 'US'
	else 'NA'
end ShortName1
from
Sales.Customers

--## Find the average score of customers and treat nulls as 0
-- Additionally provide details sucsh as customerID and lastname

select
CustomerID,
LastName,
Score,

CASE 
	when Score is null then 0	
	else score
end Score,
AVG(CASE 
	when Score is null then 0	
	else score
	end) over () AvgCustomerClean,
AVG(Score) over() AVGScore
from
Sales.Customers

--##Count how many times each customer has made an order greter than 30
select
customerid,
COUNT(*)
from 
Sales.Orders
where Sales > 30
group by customerid

-- Written using case statement.
select
customerid,
SUM(
case
	when Sales > 30 then 1
	else 0
end) OrdersWithGreateSales,
COUNT(*) as totalOrders
from 
Sales.Orders
group by customerid

-- Aggregate functions.
-- Select average sales in the order table
select 
AVG(sales),
COUNT(*),
MAX(sales),
Min(sales),
SalesPersonID,
CustomerID
from
Sales.Orders
group by SalesPersonID, CustomerID

use SalesDB
-- Windows function help us to aggregate data More advance fucntions.
--
-- find the total sales across all the orders.
select 
SUM(sales)
from
Sales.Orders

-- FInd total sales by each product
select
ProductID,
SUM(Sales) 'Total Sales'
from
Sales.Orders
group by(ProductID)

--Find the total sales by each product addtionally provide the details such as orderid and order date.

select
	OrderID,
	OrderDate,
	ProductID,
	SUM(sales)
from 
Sales.Orders
group by(ProductID)

-- Window function
select
	OrderID,
	OrderDate,
	ProductID,
	SUM(sales) over() -- windows function return result for each row
from Sales.Orders

-- Window function are used to show aggregations along with the details
select
	OrderID,
	OrderDate,
	ProductID,
	SUM(sales) over(partition by productid) -- windows function return result for each row
from Sales.Orders

-- Syntax of windows funtions
--Two parts
-- Part1                              Part2--
---									Over() 
--Aggreate Function           (Partition claues,  order clause, frame clause)
--Rank Funtions
--Value Analytics Funtions

-- Total sum of sales with all the order details
select
OrderID,
OrderDate,
SUM(sales) over() as Total_Sales
from
Sales.Orders

-- Total sum of sales by product with all the order details
select
OrderID,
OrderDate,
Sales,
SUM(sales) over(Partition by productid) as Total_product_Sales
from
Sales.Orders

--Sales, Total sales of all, Total sum of sales by product with all the order details
select
OrderID,
OrderDate,
Sales,
SUM(Sales) over() totalsales,
SUM(sales) over(Partition by productid) as Total_product_Sales
from
Sales.Orders

-- Find the total sales for each combination of product and order status
select 
ProductID,
OrderStatus,
sum(Sales)
from
Sales.Orders
group by ProductID, OrderStatus

-- Find the total sales across all the orders
-- Find the total sales for each product
-- find the total sales for each conbination of product and status
-- Additionally provide order id and order date

select 
ProductID,
OrderDate,
OrderStatus,
Sales,
SUM(sales) over () 'TotalSales',
SUM(sales) over (partition by productid) 'SalesByProduct',
SUM(sales) over (partition by productid, orderstatus) 'ProductSalesByStatus'
from
Sales.Orders

--Rank each order based on sales highest to lowest
-- Additionally provide details such as order id, order date
select
OrderID,
OrderDate,
sales,
RANK() OVER(order by sales desc) 'Rank'
from
Sales.Orders
--## With Frame
select
OrderID,
OrderDate,
OrderStatus,
sales,
SUM(sales) Over(partition by orderstatus order by orderdate
rows between current row and 2 following) 'Total_Sales'
from
Sales.Orders
---Windows functions can be used only in select and order by
--- Can use nesting windows function
-- First where clause is executed and then then the windows function

--Rank the customers based on the total sales
select
CustomerID,
sum(sales) totelSales,
rank() over(order by sum(sales) desc) RankCustomer
from 
Sales.Orders
group by CustomerID

--#Aggregate Window function
--function(<numericolumn>) over(partition by partitioncolumn order by column)
--Count Function()

-- How many orders we have for each product
select
productid,
COUNT(ProductID) totalorders
from
Sales.Orders
group by ProductID

--Total number of orders we have along
-- Total number of orders by customer
--with order id and date
select
OrderID,
OrderDate,
customerid,
count(*) over() OrdersCount,
COUNT(*) over(partition by customerid) CustomerOrders
from
Sales.Orders

-- Find the total number of customers
-- Additionally provide all the customer details
select
*,
COUNT(*) over () 'TotalCustomers'
from
Sales.Customers
-- Find the total number of scores for the customers
select
*,
COUNT(Score) over () 'TotalCustomers'
from
Sales.Customers

-- Check if the table orders has any duplicates
select
orderid,
COUNT(*) over(partition by orderid) as PKCheck
from
Sales.Orders

select distinct
OrderID,
COUNT(*) over (partition by orderid) as DupCheck
from
Sales.OrdersArchive




