CREATE  DATABASE EchoPay
GO
USE EchoPay
-- Users Table
CREATE TABLE Users (
    User_Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(255) UNIQUE NOT NULL,
    Password VARBINARY(64) NOT NULL,  -- Recommended for hashed passwords
    Role NVARCHAR(50) NOT NULL CHECK (Role IN ('admin', 'waiter', 'cashier', 'chef')),
    Phone NVARCHAR(20) NULL,
    Created_At DATETIME() DEFAULT GETDATE(),
);	



-- Tables Table
CREATE TABLE Tables (
    Table_Id INT IDENTITY(1,1) PRIMARY KEY,
    Table_Number INT NOT NULL,
    Capacity INT NOT NULL,
    Status NVARCHAR(50) CHECK (Status IN ('available', 'occupied', 'reserved')),
    Location NVARCHAR(100)
);

/*
ALTER TABLE Tables ADD Status NVARCHAR(50) CHECK (Status IN ('available', 'occupied')) DEFAULT 'available';
*/

-- Category Table
CREATE TABLE Category (
    Category_Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255)
);
Select*FROM Category

-- Menu Table
CREATE TABLE Menu (
    Menu_Item_Id INT IDENTITY(1,1) PRIMARY KEY,
    Category_Id INT FOREIGN KEY REFERENCES Category(Category_Id),
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255),
    Price DECIMAL(10,2) NOT NULL,
    Image_Url NVARCHAR(255),
    Availability BIT DEFAULT 1
);

select*from Menu

-- Payment Status Table
	CREATE TABLE Payment_Status (
		Payment_Status_Id INT IDENTITY(1,1) PRIMARY KEY,
		Status_Name NVARCHAR(50) NOT NULL UNIQUE
	);
select*from Payment_Status
INSERT INTO Payment_Status (Status_Name)
VALUES
    ('Paid'),
    ('Unpaid'),
    ('Pending');
	
select * from Order_Items

select*from Payment_Status

	ALTER TABLE Orders
	ADD CONSTRAINT DF_Orders_Payment_Status_Id
	DEFAULT 1 FOR Payment_Status_Id;

-- Orders Table
CREATE TABLE Orders (
    Order_Id INT IDENTITY(1,1) PRIMARY KEY,
    User_Id INT FOREIGN KEY REFERENCES Users(User_Id),
    Table_Id INT FOREIGN KEY REFERENCES Tables(Table_Id),
    Order_Status NVARCHAR(50) CHECK (Order_Status IN ('pending', 'completed', 'canceled')),
    Total_Amount DECIMAL(10,2) NOT NULL,
    Payment_Status_Id INT FOREIGN KEY REFERENCES Payment_Status(Payment_Status_Id),
    Created_At DATETIME DEFAULT GETDATE()
);

-- Step 1: Drop the existing constraint
ALTER TABLE Orders
DROP CONSTRAINT CK__Orders__Order_St__49C3F6B7;

ALTER TABLE Orders
DROP CONSTRAINT CK_Order_Status;
-- Step 2: Re-create the constraint with the updated allowed values
ALTER TABLE Orders
ADD CONSTRAINT CK_Order_Status
CHECK (Order_Status IN ('Pending', 'Completed', 'Ready', 'In Process', 'Canceled'));

select*from Orders order by Order_Id Desc
 

SELECT name 
FROM sys.check_constraints 
WHERE parent_object_id = OBJECT_ID('Orders');


-- Order Items Table
	CREATE TABLE Order_Items (
		Order_Item_Id INT IDENTITY(1,1) PRIMARY KEY,
		Order_Id INT FOREIGN KEY REFERENCES Orders(Order_Id),
		Menu_Item_Id INT FOREIGN KEY REFERENCES Menu(Menu_Item_Id),
		Quantity INT NOT NULL,
		Price DECIMAL(10,2) NOT NULL,
		Special_Instructions NVARCHAR(255),
		Order_Item_Status  NVARCHAR(50) NOT NULL,
		Updated_At DATETIME NOT NULL
	);
	select *from Order_Items


-- Payment Method Table
CREATE TABLE Payment_Method 
(
    Payment_Method_Id INT IDENTITY(1,1) PRIMARY KEY,
    Method_Name NVARCHAR(50) NOT NULL UNIQUE
);
INSERT INTO Payment_Method (Method_Name)
VALUES 
    ('Cash'),
    ('UPI'),
    ('Card');

select* from Payment_Method

-- Transactions Table
CREATE TABLE Transactions (
    Transaction_Id INT IDENTITY(1,1) PRIMARY KEY,
    Order_Id INT FOREIGN KEY REFERENCES Orders(Order_Id),
    Payment_Method_Id INT FOREIGN KEY REFERENCES Payment_Method(Payment_Method_Id),
    Payment_Status_Id INT FOREIGN KEY REFERENCES Payment_Status(Payment_Status_Id),
    Amount DECIMAL(10,2) NOT NULL,
    Transaction_Date DATETIME DEFAULT GETDATE()
);
select*from Transactions
-- Payments Table
CREATE TABLE Payments (
    Payment_Id INT IDENTITY(1,1) PRIMARY KEY,
    Transaction_Id INT FOREIGN KEY REFERENCES Transactions(Transaction_Id),
    Total_Amount DECIMAL(10,2) NOT NULL,
    Paid_At DATETIME DEFAULT GETDATE()
);
select*from Payment_Method
-- Reservations Table
CREATE TABLE Reservations (
    Reservation_Id INT IDENTITY(1,1) PRIMARY KEY,
    User_Id INT FOREIGN KEY REFERENCES Users(User_Id),
    Table_Id INT FOREIGN KEY REFERENCES Tables(Table_Id),
    Reservation_Date DATETIME NOT NULL,
    Status NVARCHAR(50) CHECK (Status IN ('confirmed', 'canceled', 'completed'))
);

-- Suppliers Table
CREATE TABLE Suppliers (
    Supplier_Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Contact NVARCHAR(50),
    Email NVARCHAR(100),
    Address NVARCHAR(255)
);

-- Inventory Table
CREATE TABLE Inventory (
    InventoryID INT IDENTITY(1,1) PRIMARY KEY,
    ProductName NVARCHAR(255) NOT NULL,
    Quantity INT CHECK (Quantity >= 0),
    Price DECIMAL(10,2) CHECK (Price >= 0),
    Supplier_ID INT,
    LastUpdated DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (Supplier_ID) REFERENCES Suppliers(Supplier_ID)
);

-- Drop the CHECK constraint
ALTER TABLE Inventory DROP CONSTRAINT CK__Inventory__Quant__3E1D39E1;

-- Alter the column to NVARCHAR
ALTER TABLE Inventory ALTER COLUMN Quantity NVARCHAR(50);



-- Discounts Table
CREATE  TABLE Discounts (
    Discount_Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100),
    Discount_Type NVARCHAR(50) CHECK (Discount_Type IN ('percentage', 'fixed')),
    Value DECIMAL(10,2),
    Start_Date DATETIME,
    End_Date DATETIME
);


-- Taxes Table
CREATE TABLE Taxes (
    Tax_Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100),
    Percentage DECIMAL(5,2)
);

-- Bill Table
CREATE TABLE Bill (
    Bill_Id INT IDENTITY(1,1) PRIMARY KEY,
    Order_Id INT FOREIGN KEY REFERENCES Orders(Order_Id),
    Tax_Id INT FOREIGN KEY REFERENCES Taxes(Tax_Id),
    Discount_Id INT FOREIGN KEY REFERENCES Discounts(Discount_Id),
    Total DECIMAL(10,2) NOT NULL,
    Created_At DATETIME DEFAULT GETDATE()
);

-- Employee Shifts Table
CREATE TABLE Employee_Shifts (
    Shift_Id INT IDENTITY(1,1) PRIMARY KEY,
    User_Id INT FOREIGN KEY REFERENCES Users(User_Id),
    Shift_Start DATETIME NOT NULL,
    Shift_End DATETIME NOT NULL,
    Role NVARCHAR(50)
);


-- Feedback Table
CREATE TABLE Feedback (
    Review_Id INT IDENTITY(1,1) PRIMARY KEY,
    User_Id INT FOREIGN KEY REFERENCES Users(User_Id),
    Rating INT CHECK (Rating BETWEEN 1 AND 5),
    Comments NVARCHAR(255),
    Created_At DATETIME DEFAULT GETDATE()
);

-- Audit Log Table
CREATE TABLE Audit_Log (
    Log_Id INT IDENTITY(1,1) PRIMARY KEY,
    User_Id INT FOREIGN KEY REFERENCES Users(User_Id),
    Action NVARCHAR(255),
    Timestamp DATETIME DEFAULT GETDATE()
);
ALTER TABLE Audit_Log
ADD IpAddress VARCHAR(50);


CREATE TABLE Cart (
    Cart_Id INT IDENTITY(1,1) PRIMARY KEY,
    Table_Id INT NOT NULL,
    User_Id INT NOT NULL,
    Menu_Item_Id INT NOT NULL,
    Quantity INT NOT NULL DEFAULT 1,
    Price DECIMAL(10,2) NOT NULL,
    Total_Price AS (Quantity * Price), 
    Created_At DATETIME DEFAULT GETDATE(),
	Special_Instructions
    FOREIGN KEY (Table_Id) REFERENCES Tables(Table_Id),
    FOREIGN KEY (User_Id) REFERENCES Users(User_Id),
    FOREIGN KEY (Menu_Item_Id) REFERENCES Menu(Menu_Item_Id)
);
SELECT * FROM Cart;


CREATE TABLE DailyPaymentSummary (
    SummaryDate DATE PRIMARY KEY,
    Cash DECIMAL(10,2) DEFAULT 0,
    UPI DECIMAL(10,2) DEFAULT 0,
    Card DECIMAL(10,2) DEFAULT 0,
    Grand DECIMAL(10,2) DEFAULT 0
);

select*from DailyPaymentSummary

CREATE TABLE Expenses (
    Id INT IDENTITY PRIMARY KEY,
    Category NVARCHAR(100),
    Amount DECIMAL(18,2),
    Date DATETIME,
    Note NVARCHAR(255)
);
-- Selecting Data for Verification
SELECT * FROM Users;
SELECT * FROM Tables;
SELECT * FROM Category;
SELECT * FROM Menu;
SELECT * FROM Payment_Status;
SELECT * FROM Orders;
SELECT *FROM Order_Items;
SELECT * FROM Payment_Method;
SELECT * FROM Transactions;
SELECT * FROM Payments;
SELECT * FROM Reservations;
SELECT * FROM Suppliers;
SELECT * FROM Inventory;
SELECT * FROM Discounts;
SELECT * FROM Taxes;
SELECT * FROM Bill;
SELECT * FROM Employee_Shifts;
SELECT * FROM Feedback;
SELECT * FROM Audit_Log;
SELECT * FROM Cart;






