CREATE DATABASE EchoPay
GO
USE EchoPay
-- Users Table
GO
CREATE TABLE Users (
    User_Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(255) UNIQUE NOT NULL,
    Password VARBINARY(64) NOT NULL,
    Role NVARCHAR(50) NOT NULL CHECK (Role IN ('admin', 'waiter', 'cashier', 'chef')),
    Phone NVARCHAR(20) NULL,
    Created_At DATETIME DEFAULT GETDATE(),
);	

-- Tables Table
GO
CREATE TABLE Tables (
    Table_Id INT IDENTITY(1,1) PRIMARY KEY,
    Table_Number INT NOT NULL,
    Capacity INT NOT NULL,
    Status NVARCHAR(50) DEFAULT 'available' CHECK (Status IN ('available', 'occupied', 'reserved')),
    Location NVARCHAR(100)
);

-- Category Table
GO
CREATE TABLE Category (
    Category_Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255)
);

-- Menu Table
GO
CREATE TABLE Menu (
    Menu_Item_Id INT IDENTITY(1,1) PRIMARY KEY,
    Category_Id INT FOREIGN KEY REFERENCES Category(Category_Id),
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255),
    Price DECIMAL(10,2) NOT NULL,
    Image_Url NVARCHAR(255),
    Availability BIT DEFAULT 1
);

-- Payment Status Table
GO
CREATE TABLE Payment_Status (
    Payment_Status_Id INT IDENTITY(1,1) PRIMARY KEY,
    Status_Name NVARCHAR(50) NOT NULL UNIQUE
);
INSERT INTO Payment_Status (Status_Name) VALUES ('Paid'), ('Unpaid'), ('Pending');

-- Orders Table
GO
CREATE TABLE Orders (
    Order_Id INT IDENTITY(1,1) PRIMARY KEY,
    User_Id INT FOREIGN KEY REFERENCES Users(User_Id),
    Table_Id INT FOREIGN KEY REFERENCES Tables(Table_Id),
    Order_Status NVARCHAR(50) DEFAULT 'Pending' CHECK (Order_Status IN ('Pending', 'Completed', 'Ready', 'In Process', 'Canceled')),
    Total_Amount DECIMAL(10,2) NOT NULL,
    Payment_Status_Id INT DEFAULT 2 FOREIGN KEY REFERENCES Payment_Status(Payment_Status_Id), -- Default to Unpaid
    Created_At DATETIME DEFAULT GETDATE()
);

-- Order Items Table
GO
CREATE TABLE Order_Items (
    Order_Item_Id INT IDENTITY(1,1) PRIMARY KEY,
    Order_Id INT FOREIGN KEY REFERENCES Orders(Order_Id),
    Menu_Item_Id INT FOREIGN KEY REFERENCES Menu(Menu_Item_Id),
    Quantity INT NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    Special_Instructions NVARCHAR(255),
    Order_Item_Status  NVARCHAR(50) NOT NULL,
    Updated_At DATETIME DEFAULT GETDATE()
);

-- Payment Method Table
GO
CREATE TABLE Payment_Method (
    Payment_Method_Id INT IDENTITY(1,1) PRIMARY KEY,
    Method_Name NVARCHAR(50) NOT NULL UNIQUE
);
INSERT INTO Payment_Method (Method_Name) VALUES ('Cash'), ('UPI'), ('Card');

-- Transactions Table
GO
CREATE TABLE Transactions (
    Transaction_Id INT IDENTITY(1,1) PRIMARY KEY,
    Order_Id INT FOREIGN KEY REFERENCES Orders(Order_Id),
    Payment_Method_Id INT FOREIGN KEY REFERENCES Payment_Method(Payment_Method_Id),
    Payment_Status_Id INT FOREIGN KEY REFERENCES Payment_Status(Payment_Status_Id),
    Amount DECIMAL(10,2) NOT NULL,
    Transaction_Date DATETIME DEFAULT GETDATE()
);

-- Payments Table
GO
CREATE TABLE Payments (
    Payment_Id INT IDENTITY(1,1) PRIMARY KEY,
    Transaction_Id INT FOREIGN KEY REFERENCES Transactions(Transaction_Id),
    Total_Amount DECIMAL(10,2) NOT NULL,
    Paid_At DATETIME DEFAULT GETDATE()
);

-- Reservations Table
GO
CREATE TABLE Reservations (
    Reservation_Id INT IDENTITY(1,1) PRIMARY KEY,
    User_Id INT FOREIGN KEY REFERENCES Users(User_Id),
    Table_Id INT FOREIGN KEY REFERENCES Tables(Table_Id),
    Reservation_Date DATETIME NOT NULL,
    Status NVARCHAR(50) CHECK (Status IN ('confirmed', 'canceled', 'completed'))
);

-- Suppliers Table
GO
CREATE TABLE Suppliers (
    Supplier_Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Contact NVARCHAR(50),
    Email NVARCHAR(100),
    Address NVARCHAR(255)
);

-- Inventory Table
GO
CREATE TABLE Inventory (
    InventoryID INT IDENTITY(1,1) PRIMARY KEY,
    ProductName NVARCHAR(255) NOT NULL,
    Quantity NVARCHAR(50), -- NVARCHAR as requested
    Price DECIMAL(10,2) CHECK (Price >= 0),
    Supplier_ID INT,
    LastUpdated DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (Supplier_ID) REFERENCES Suppliers(Supplier_Id)
);

-- Discounts Table
GO
CREATE TABLE Discounts (
    Discount_Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100),
    Discount_Type NVARCHAR(50) CHECK (Discount_Type IN ('percentage', 'fixed')),
    Value DECIMAL(10,2),
    Start_Date DATETIME,
    End_Date DATETIME
);

-- Taxes Table
GO
CREATE TABLE Taxes (
    Tax_Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100),
    Percentage DECIMAL(5,2)
);

-- Bill Table
GO
CREATE TABLE Bill (
    Bill_Id INT IDENTITY(1,1) PRIMARY KEY,
    Order_Id INT FOREIGN KEY REFERENCES Orders(Order_Id),
    Tax_Id INT FOREIGN KEY REFERENCES Taxes(Tax_Id),
    Discount_Id INT FOREIGN KEY REFERENCES Discounts(Discount_Id),
    Total DECIMAL(10,2) NOT NULL,
    Created_At DATETIME DEFAULT GETDATE()
);

-- Employee Shifts Table
GO
CREATE TABLE Employee_Shifts (
    Shift_Id INT IDENTITY(1,1) PRIMARY KEY,
    User_Id INT FOREIGN KEY REFERENCES Users(User_Id),
    Shift_Start DATETIME NOT NULL,
    Shift_End DATETIME NOT NULL,
    Role NVARCHAR(50)
);

-- Feedback Table
GO
CREATE TABLE Feedback (
    Review_Id INT IDENTITY(1,1) PRIMARY KEY,
    User_Id INT FOREIGN KEY REFERENCES Users(User_Id),
    Rating INT CHECK (Rating BETWEEN 1 AND 5),
    Comments NVARCHAR(255),
    Created_At DATETIME DEFAULT GETDATE()
);

-- Audit Log Table
GO
CREATE TABLE Audit_Log (
    Log_Id INT IDENTITY(1,1) PRIMARY KEY,
    User_Id INT FOREIGN KEY REFERENCES Users(User_Id),
    Action NVARCHAR(255),
    Timestamp DATETIME DEFAULT GETDATE(),
    IpAddress VARCHAR(50)
);

-- Cart Table
GO
CREATE TABLE Cart (
    Cart_Id INT IDENTITY(1,1) PRIMARY KEY,
    Table_Id INT NOT NULL,
    User_Id INT NOT NULL,
    Menu_Item_Id INT NOT NULL,
    Quantity INT NOT NULL DEFAULT 1,
    Price DECIMAL(10,2) NOT NULL,
    Total_Price AS (Quantity * Price), 
    Created_At DATETIME DEFAULT GETDATE(),
    Special_Instructions NVARCHAR(255),
    FOREIGN KEY (Table_Id) REFERENCES Tables(Table_Id),
    FOREIGN KEY (User_Id) REFERENCES Users(User_Id),
    FOREIGN KEY (Menu_Item_Id) REFERENCES Menu(Menu_Item_Id)
);

-- DailyPaymentSummary Table
GO
CREATE TABLE DailyPaymentSummary (
    SummaryDate DATE PRIMARY KEY,
    Cash DECIMAL(10,2) DEFAULT 0,
    UPI DECIMAL(10,2) DEFAULT 0,
    Card DECIMAL(10,2) DEFAULT 0,
    Grand DECIMAL(10,2) DEFAULT 0
);

-- Expenses Table
GO
CREATE TABLE Expenses (
    Id INT IDENTITY PRIMARY KEY,
    Category NVARCHAR(100),
    Amount DECIMAL(18,2),
    Date DATETIME,
    Note NVARCHAR(255)
);