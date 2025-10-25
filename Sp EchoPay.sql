use EchoPay
select*from cart 
 select * from Payment_Status
select * from Cart

---------------------------------------------------------------------------------------------------------------------------------------------
SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Categories';


/*Category*/


/* Insert*/

CREATE or Alter PROCEDURE sp_InsertCategory
    @Name NVARCHAR(100),
    @Description NVARCHAR(255)
AS
BEGIN
    INSERT INTO Category(Name, Description)
    VALUES (@Name, @Description);

    -- Return the inserted Category_Id
    SELECT SCOPE_IDENTITY() AS Category_Id;
END;

/* Update*/

CREATE or Alter PROCEDURE sp_UpdateCategory
    @Category_Id INT,
    @Name NVARCHAR(100),
    @Description NVARCHAR(255)
AS
BEGIN
    UPDATE Category
    SET Name = @Name, 
        Description = @Description
    WHERE Category_Id = @Category_Id;
END;

/*View*/

CREATE or Alter PROCEDURE sp_GetCategory					
AS
BEGIN
    SELECT Category_Id, Name, Description
    FROM Category
    ORDER BY Category_Id;
END;

/* Delete*/

CREATE  or Alter PROCEDURE sp_DeleteCategory
    @Category_Id INT
AS
BEGIN
    DELETE FROM Category
    WHERE Category_Id = @Category_Id;
END;


CREATE OR ALTER PROCEDURE sp_GetCategoryByID
    @Category_Id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Category_Id, Name, Description 
    FROM Category
    WHERE Category_Id = @Category_Id;
END;
---------------------------------------
CREATE PROCEDURE GetAllCategories
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        Category_Id,
        Name,
        Description
    FROM 
        Category
    ORDER BY 
        Name ASC;
END





-------------------------------------------------------------------------------------------------------
/*Get All Menu Items*/


CREATE PROCEDURE GetMenuItemsByCategory
    @CategoryId INT
AS
BEGIN
    SELECT Menu_Item_Id, Name, Description, Price, Image_Url, Category_Id
    FROM Menu
    WHERE Category_Id = @CategoryId
END

exec GetMenuItemsByCategory 1

CREATE or Alter PROCEDURE sp_GetMenu
AS
BEGIN
    SELECT * FROM Menu 
END;
EXEC sp_GetMenu
/*Get a Menu Item by ID*/
CREATE or Alter PROCEDURE sp_GetMenuItemById
    @Menu_Item_Id INT
AS
BEGIN
    SELECT * FROM Menu WHERE Menu_Item_Id = @Menu_Item_Id;
END;

/*Insert a New Menu Item*/

CREATE  or Alter PROCEDURE sp_InsertMenu
    @Name NVARCHAR(100),
    @Description NVARCHAR(255),
    @Price DECIMAL(10,2),
    @Category_Id INT
AS
BEGIN
    INSERT INTO Menu (Name, Description, Price, Category_Id)
    VALUES (@Name, @Description, @Price, @Category_Id);

    SELECT SCOPE_IDENTITY(); -- Return new ID
END;



/*Update a Menu Item*/

	CREATE  or Alter PROCEDURE sp_UpdateMenu
		@Menu_Item_Id INT,
		@Name NVARCHAR(100),
		@Description NVARCHAR(255),
		@Price DECIMAL(10,2),
		@Category_Id INT,
		@Availability BIT,
		@Image_Url NVARCHAR(255) -- Add this line to handle the image URL
	AS
	BEGIN
		UPDATE Menu
		SET Name = @Name, 
			Description = @Description, 
			Price = @Price, 
			Category_Id = @Category_Id,
			Availability = @Availability,
			Image_Url = @Image_Url
		WHERE Menu_Item_Id = @Menu_Item_Id;
	END;

/*Delete a Menu Item*/

CREATE or Alter PROCEDURE sp_DeleteMenu
    @MenuItem_Id INT
AS
BEGIN
    DELETE FROM Menu WHERE Menu_Item_Id = @MenuItem_Id;
END;



CREATE or Alter PROCEDURE sp_GetAllMenuItems
AS
BEGIN
    SELECT Menu_Item_Id, Name, Price, Category_Id
    FROM Menu
    WHERE Availability = 1;
END;


CREATE  or alter PROCEDURE sp_GetMenuItemsByCategory
    @CategoryId INT
AS
BEGIN
    SELECT Menu_Item_Id, Name, Price, Category_Id
    FROM Menu
    WHERE Category_Id = @CategoryId AND Availability = 1;
END;



-- sp_GetAllMenuItems
CREATE or Alter PROCEDURE sp_GetAllMenuItems
AS
BEGIN
    SELECT * FROM Menu
END

-- sp_GetAllCategories
CREATE PROCEDURE sp_GetAllCategories
AS
BEGIN
    SELECT * FROM Category
END

-------------------------------------------------------------------------------------------------------------------------------

/*User*/

-- 🔹 Add User
CREATE OR ALTER PROCEDURE sp_AddUser
    @Name NVARCHAR(100),
    @Email NVARCHAR(255),
    @Password VARBINARY(64), -- Hashed password as VARBINARY
    @Role NVARCHAR(50),
    @Phone NVARCHAR(20) = NULL,
    @Created_At DATETIME2(3) = NULL  -- Default value should be handled inside
AS
BEGIN
    SET NOCOUNT ON;

    -- Validate Role
    IF @Role NOT IN ('admin', 'waiter', 'cashier', 'chef')
    BEGIN
        THROW 50000, 'Invalid role. Allowed values: admin, waiter, cashier, chef.', 1;
        RETURN;
    END

    -- If Created_At is NULL, set it to the current system time
    IF @Created_At IS NULL
        SET @Created_At = SYSDATETIME();

    -- Insert user into the database
    INSERT INTO Users (Name, Email, Password, Role, Phone, Created_At)
    VALUES (@Name, @Email, @Password, @Role, @Phone, @Created_At);

    -- Return the newly created User_Id
    SELECT SCOPE_IDENTITY() AS User_Id;
END;
GO




-- 🔹 Get User by ID
CREATE or alter PROCEDURE sp_GetUserById
    @User_Id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT User_Id, Name, Email, Role, Phone
    FROM Users
    WHERE User_Id = @User_Id;
END;
GO





-- 🔹 Get All Users
CREATE OR ALTER PROCEDURE sp_GetAllUser
AS
BEGIN
    SET NOCOUNT ON;

    SELECT User_Id, Name, Email, Role, Phone --, Created_At
    FROM Users;
END;
GO
exec 
-- 🔹 Update User
CREATE OR ALTER PROCEDURE sp_UpdateUser
    @User_Id INT,
    @Name NVARCHAR(100),
    @Email NVARCHAR(255),
    @Password VARBINARY(64), -- ✅ Now matches C# hashing
    @Role NVARCHAR(50),
    @Phone NVARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- Check if User Exists
    IF NOT EXISTS (SELECT 1 FROM Users WHERE User_Id = @User_Id)
    BEGIN
        THROW 50000, 'User not found.', 1;
        RETURN;
    END;

    -- Update user data
    UPDATE Users
    SET Name = @Name,
        Email = @Email,
        Password = @Password, -- ✅ No need to convert
        Role = @Role,
        Phone = @Phone
    WHERE User_Id = @User_Id;
END;

select * from Cart

-- 🔹 Delete User
-- Delete User Procedure
CREATE OR ALTER PROCEDURE sp_DeleteUser
    @User_Id INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Check if User Exists
    IF NOT EXISTS (SELECT 1 FROM Users WHERE User_Id = @User_Id)
    BEGIN
        THROW 50000, 'User not found.', 1;
        RETURN;
    END;

    -- Delete the user
    DELETE FROM Users WHERE User_Id = @User_Id;
END;
GO

-- Get User by ID Procedure
CREATE OR ALTER PROCEDURE sp_GetUserById
    @User_Id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT User_Id, Name, Email, Role, Phone
    FROM Users
    WHERE User_Id = @User_Id;
END;
GO
-------------------------------------------------------------------------------------------------------------------------------

	/*               Table                       */


	/*Insert table*/

	CREATE PROCEDURE sp_InsertTable
		@Table_Number INT,
		@Capacity INT,
		@Status NVARCHAR(50),
		@Location NVARCHAR(100)
	AS
	BEGIN
		INSERT INTO Tables (Table_Number, Capacity, Status, Location)
		VALUES (@Table_Number, @Capacity, @Status, @Location);
    
		SELECT SCOPE_IDENTITY(); -- Return the last inserted ID
	END

	/* Update table*/

	CREATE PROCEDURE sp_UpdateTable
		@Table_Id INT,
		@Table_Number INT,
		@Capacity INT,
		@Status NVARCHAR(50),
		@Location NVARCHAR(100)
	AS
	BEGIN
		UPDATE Tables
		SET Table_Number = @Table_Number,
			Capacity = @Capacity,
			Status = @Status,
			Location = @Location
		WHERE Table_Id = @Table_Id;
	END

	/* Delete*/

	CREATE PROCEDURE sp_DeleteTable
		@Table_Id INT
	AS
	BEGIN
		DELETE FROM Tables WHERE Table_Id = @Table_Id;
	END

	/* Get table by id*/

	CREATE PROCEDURE sp_GetTableById
		@Table_Id INT
	AS
	BEGIN
		SELECT * FROM Tables WHERE Table_Id = @Table_Id;
	END

	/* Get all tables*/

	CREATE or Alter  PROCEDURE sp_GetAllTables
	AS
	BEGIN
		SELECT Table_Id, Table_Number, Capacity, Status, Location
		FROM Tables
	END
	 EXEC sp_GetAllTables
	-- Stored Procedure to Update Table Status
	CREATE PROCEDURE sp_UpdateTableStatus
		@Table_Id INT,
		@Status NVARCHAR(50)
	AS
	BEGIN
		-- Update the table status based on Table_Id
		UPDATE Tables
		SET Status = @Status
		WHERE Table_Id = @Table_Id;
	END



-------------------------------------------------------------------------------------------------------------------------------
SELECT * FROM Tables WHERE Table_Id = 2

/*                        Reservations                  */

--Insert 

CREATE or Alter PROCEDURE sp_InsertReservation
    @User_Id INT,
    @Table_Id INT,
    @Reservation_Date DATETIME,
    @Status NVARCHAR(50)
AS
BEGIN
    -- Check if Table_Id exists
    IF NOT EXISTS (SELECT 1 FROM Tables WHERE Table_Id = @Table_Id)
    BEGIN
        RAISERROR ('Table_Id does not exist.', 16, 1);
        RETURN;
    END
    
    -- Insert into Reservations
    INSERT INTO Reservations (User_Id, Table_Id, Reservation_Date, Status)
    VALUES (@User_Id, @Table_Id, @Reservation_Date, @Status);
    
    -- Return the last inserted ID
    SELECT SCOPE_IDENTITY();
END


--Update

CREATE PROCEDURE sp_UpdateReservation
    @Reservation_Id INT,
    @User_Id INT,
    @Table_Id INT,
    @Reservation_Date DATETIME,
    @Status NVARCHAR(50)
AS
BEGIN
    UPDATE Reservations
    SET User_Id = @User_Id,
        Table_Id = @Table_Id,
        Reservation_Date = @Reservation_Date,
        Status = @Status
    WHERE Reservation_Id = @Reservation_Id;
END

--Delete

CREATE PROCEDURE sp_DeleteReservation
    @Reservation_Id INT
AS
BEGIN
    DELETE FROM Reservations WHERE Reservation_Id = @Reservation_Id;
END


---Get Reservation by ID
CREATE or alter PROCEDURE sp_GetReservationById
    @Reservation_Id INT
AS
BEGIN
    SELECT * FROM Reservations WHERE Reservation_Id = @Reservation_Id;
END

EXEC sp_GetReservationById 5;
select * from Reservations

---Get All Reservations

CREATE or alter PROCEDURE sp_GetAllReservations
AS
BEGIN
    SELECT u.Name,Table_Number,Reservation_Date,r.Status FROM Reservations r
	inner join Users u
	on r.User_Id = u.User_Id
	inner join Tables t
	ON t.Table_Id= r.Table_Id;
END

exec sp_GetAllReservations
select * FROM Reservations
-------------------------------------------------------------------------------------------------------------------------------
/*                 SUPPLIER                */






-- ✅ Insert Supplier
CREATE  PROCEDURE sp_AddSupplier
    @Name NVARCHAR(100),
    @Contact NVARCHAR(50),
    @Email NVARCHAR(100),
    @Address NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Suppliers (Name, Contact, Email, Address)
    VALUES (@Name, @Contact, @Email, @Address);

    SELECT SCOPE_IDENTITY();  -- Return the newly inserted Supplier_Id
END;
GO

-- ✅ Update Supplier
CREATE  PROCEDURE sp_UpdateSupplier
    @Supplier_Id INT,
    @Name NVARCHAR(100),
    @Contact NVARCHAR(50),
    @Email NVARCHAR(100),
    @Address NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Suppliers
    SET Name = @Name, 
        Contact = @Contact, 
        Email = @Email, 
        Address = @Address
    WHERE Supplier_Id = @Supplier_Id;
END;
GO

-- ✅ Delete Supplier
CREATE  PROCEDURE sp_DeleteSuppliers
    @Supplier_Id INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM Suppliers 
    WHERE Supplier_Id = @Supplier_Id;
END;
GO



-- ✅ Get Supplier by ID
CREATE  PROCEDURE sp_GetSupplierById
    @Supplier_Id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Supplier_Id, Name, Contact, Email, Address
    FROM Suppliers 
    WHERE Supplier_Id = @Supplier_Id;
END;
GO

-- ✅ Get All Suppliers (Index Page)
CREATE  PROCEDURE sp_GetAllSuppliers
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Supplier_Id, Name, Contact, Email, Address 
    FROM Suppliers
    ORDER BY Supplier_Id;
END;
GO



--------------------------------------------------------------------------------------------------------------------------------

/*                           Inventory                                                            */

--Inventory Insert
CREATE PROCEDURE InsertInventory
    @ProductName NVARCHAR(255),
    @Quantity NVARCHAR(255),
    @Price DECIMAL(10,2),
    @Supplier_ID INT
AS
BEGIN
    INSERT INTO Inventory (ProductName, Quantity, Price, Supplier_ID, LastUpdated)
    VALUES (@ProductName, @Quantity, @Price, @Supplier_ID, GETDATE());
END;

--Inventory Update
CREATE PROCEDURE UpdateInventory
    @InventoryID INT,
    @ProductName NVARCHAR(255),
    @Quantity NVARCHAR(255),
    @Price DECIMAL(10,2),
    @Supplier_ID INT
AS
BEGIN
    UPDATE Inventory
    SET ProductName = @ProductName, Quantity = @Quantity, Price = @Price, Supplier_ID = @Supplier_ID, LastUpdated = GETDATE()
    WHERE InventoryID = @InventoryID;
END;


--Inventory Delete
CREATE PROCEDURE DeleteInventory
    @InventoryID INT
AS
BEGIN
    DELETE FROM Inventory WHERE InventoryID = @InventoryID;
END;


--Inventory Get Inventory By Id
CREATE PROCEDURE GetInventoryById
    @InventoryID INT
AS
BEGIN
    SELECT * FROM Inventory WHERE InventoryID = @InventoryID;
END;

--Inventory Get All Inventory
CREATE OR Alter  PROCEDURE GetAllInventory
AS
BEGIN
    SELECT InventoryID,ProductName,Quantity,Price,s.Name  FROM Inventory i
	INNER JOIN Suppliers s
	On i.Supplier_Id = s.Supplier_Id
END;
Exec s
GetAllInventory
select*from Inventory
select*from Suppliers
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


/*               Employee_Shift                              */

-- Add Shift
CREATE PROCEDURE sp_AddShift
    @User_Id INT,
    @Shift_Start DATETIME,
    @Shift_End DATETIME,
    @Role NVARCHAR(50)
AS
BEGIN
    INSERT INTO Employee_Shifts (User_Id, Shift_Start, Shift_End, Role)
    VALUES (@User_Id, @Shift_Start, @Shift_End, @Role)
END
GO

-- Get Shift By Id
CREATE PROCEDURE sp_GetShiftById
    @Shift_Id INT
AS
BEGIN
    SELECT * FROM Employee_Shifts WHERE Shift_Id = @Shift_Id
END
GO

-- Get All Shifts
CREATE  or Alter PROCEDURE sp_GetAllShifts
AS
BEGIN
    SELECT 
        es.Shift_Id,
        es.User_Id,
        u.Name AS User_Name,
        es.Shift_Start,
        es.Shift_End,
        es.Role	
    FROM Employee_Shifts es
    INNER JOIN Users u ON es.User_Id = u.User_Id
END
GO

GO

-- Update Shift
CREATE PROCEDURE sp_UpdateShift
    @Shift_Id INT,
    @User_Id INT,
    @Shift_Start DATETIME,
    @Shift_End DATETIME,
    @Role NVARCHAR(50)
AS
BEGIN
    UPDATE Employee_Shifts
    SET User_Id = @User_Id, Shift_Start = @Shift_Start, Shift_End = @Shift_End, Role = @Role
    WHERE Shift_Id = @Shift_Id
END
GO

-- Delete Shift
CREATE PROCEDURE sp_DeleteShift
    @Shift_Id INT
AS
BEGIN
    DELETE FROM Employee_Shifts WHERE Shift_Id = @Shift_Id
END
GO

------------------------------------------------------------------------------------------------------------------------------------


/*                       cart                                         */
--Add Item to Cart
EXEC sp_AddToCart;

CREATE OR ALTER PROCEDURE sp_AddToCart
    @Table_Id INT,
    @Menu_Item_Id INT,
    @Price DECIMAL(10,2),
    @Quantity INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Check if the Table_Id exists in the Tables table
    IF NOT EXISTS (SELECT 1 FROM Tables WHERE Table_Id = @Table_Id)
    BEGIN
        RAISERROR('Invalid Table_Id. The specified table does not exist.', 16, 1);
        RETURN; -- Exit the procedure if the Table_Id is not valid
    END

    DECLARE @ExistingQuantity INT;

    -- Check if the menu item already exists in the cart
    SELECT @ExistingQuantity = Quantity FROM Cart 
    WHERE Table_Id = @Table_Id AND Menu_Item_Id = @Menu_Item_Id;

    IF @ExistingQuantity IS NOT NULL
    BEGIN
        -- If it exists, update the quantity
        UPDATE Cart 
        SET Quantity = Quantity + @Quantity  -- Only update the Quantity
        WHERE Table_Id = @Table_Id AND Menu_Item_Id = @Menu_Item_Id;
    END
    ELSE
    BEGIN
        -- If it doesn't exist, insert a new record
        INSERT INTO Cart (Table_Id, Menu_Item_Id, Quantity, Price)  -- Let Total_Price be calculated
        VALUES (@Table_Id, @Menu_Item_Id, @Quantity, @Price);
    END
END;

select *from Cart 

-------------------------------------------------------------------------------------------------------------------
ALTER TABLE Cart
DROP COLUMN User_id
ALTER TABLE Cart
DROP CONSTRAINT [FK__Cart__User_Id__02C769E9];
-----------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE GetCartItemById
    @CartId INT
AS
BEGIN
    SELECT * FROM Cart
    WHERE Cart_Id = @CartId;
END

EXEC sp_helptext 'GetCartItemById';

SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'GetCartItemById';


-----------------------------------------------------------------------------------------------------------------------------
-- Get Cart Items
CREATE  or ALTER PROCEDURE sp_GetCartItems		
    @Table_Id INT
 
AS
BEGIN
    SELECT c.Cart_Id, c.Table_Id, c.Menu_Item_Id, c.Quantity, c.Price, c.Total_Price,
           m.Name, m.Image_Url
    FROM Cart c
    INNER JOIN Menu m ON c.Menu_Item_Id = m.Menu_Item_Id
    WHERE c.Table_Id = @Table_Id 
END

-------------------------------------------------------------------------------------------------------------------------
--Remove Item from Cart
CREATE  or Alter PROCEDURE sp_RemoveCartItem
    @Cart_Id INT
AS
BEGIN
    DELETE FROM Cart WHERE Cart_Id = @Cart_Id;
END;
----------------------------------------------------------------------------------------------------------------------
---Convert into Order
CREATE PROCEDURE sp_SubmitOrder
    @Table_Id INT,
    @User_Id INT,
    @Order_Id INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Total_Amount DECIMAL(10,2) = 0;

    -- Calculate total order amount from the cart
    SELECT @Total_Amount = SUM(Total_Price)
    FROM Cart
    WHERE Table_Id = @Table_Id AND User_Id = @User_Id;

    -- Insert into Orders table
    INSERT INTO Orders (Table_Id, User_Id, Order_Status, Total_Amount, Payment_Status_Id, Created_At)
    VALUES (@Table_Id, @User_Id, 'pending', @Total_Amount, NULL, GETDATE());

    -- Get the generated Order_Id
    SET @Order_Id = SCOPE_IDENTITY();

    -- Insert Cart items into Order_Items table
    INSERT INTO Order_Items (Order_Id, Menu_Item_Id, Quantity, Price, Special_Instructions)
    SELECT @Order_Id, Menu_Item_Id, Quantity, Price, NULL
    FROM Cart
    WHERE Table_Id = @Table_Id AND User_Id = @User_Id;

    -- Clear the cart after order submission
    DELETE FROM Cart WHERE Table_Id = @Table_Id AND User_Id = @User_Id;
END;

select * from Cart 

Select * from Order_Items

Select* from Orders
-----------------------------------------------------------------------------------------------------------------------------

CREATE OR ALTER PROCEDURE SubmitOrder_KeepCart
    @Table_Id INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Order_Id INT;
    DECLARE @Payment_Status_Id INT;
    DECLARE @Default_User_Id INT = 1;  -- Replace with actual default user if needed

    -- Get Payment_Status_Id for 'Unpaid'
    SELECT @Payment_Status_Id = Payment_Status_Id
    FROM Payment_Status
    WHERE Status_Name = 'Unpaid';

    IF @Payment_Status_Id IS NULL
        SET @Payment_Status_Id = 1; -- fallback default

    -- Insert into Orders from Cart
    INSERT INTO Orders (User_Id, Table_Id, Order_Status, Total_Amount, Payment_Status_Id, Created_At)
    SELECT TOP 1
        @Default_User_Id,
        @Table_Id,
        'pending',
        SUM(c.Quantity * c.Price),
        @Payment_Status_Id,
        GETDATE()
    FROM Cart c
    WHERE c.Table_Id = @Table_Id;

    SET @Order_Id = SCOPE_IDENTITY();

    -- Insert into Order_Items using JOIN with Menu
    INSERT INTO Order_Items (Order_Id, Menu_Item_Id, Quantity, Price, Special_Instructions)
    SELECT
        @Order_Id,
        c.Menu_Item_Id,
        c.Quantity,
        c.Price,
        'No instructions'  -- default since Cart doesn't have Special_Instructions
    FROM Cart c
    INNER JOIN Menu m ON c.Menu_Item_Id = m.Menu_Item_Id
    WHERE c.Table_Id = @Table_Id;

    -- Update table status
    UPDATE Tables
    SET Status = 'Occupied'
    WHERE Table_Id = @Table_Id;
END;
-------------------------------------------------------------------------------------
CREATE PROCEDURE sp_GetOrderDetails
    @Table_Id INT
AS
BEGIN
    SELECT 
        o.Order_Id, 
        o.Created_At, 
        o.Order_Status, 
        o.Total_Amount, 
        o.Payment_Status_Id,
        oi.Menu_Item_Id, 
        oi.Quantity, 
        oi.Price, 
        (oi.Quantity * oi.Price) AS Total_Price, 
        oi.Special_Instructions
    FROM Orders o
    JOIN Order_Items oi ON o.Order_Id = oi.Order_Id
    WHERE o.Table_Id = @Table_Id;
END;

------------------------------------------------------------------------------
	CREATE  or alter PROCEDURE sp_UpdateCartQuantity
		@Cart_Id INT,
		@Change INT
	AS
	BEGIN
		SET NOCOUNT ON;

		-- Update quantity based on +1 or -1
		UPDATE Cart
		SET Quantity = Quantity + @Change
		WHERE Cart_Id = @Cart_Id;

		-- If the updated quantity is less than or equal to 0, delete the cart item
		DELETE FROM Cart
		WHERE Cart_Id = @Cart_Id AND Quantity <= 0;

		-- Return the new quantity (or 0 if deleted)
		SELECT ISNULL((
			SELECT Quantity FROM Cart WHERE Cart_Id = @Cart_Id
		), 0) AS NewQuantity;
	END



---------------------------------------------------------------------------------
CREATE PROCEDURE sp_GetCartItemById
    @Cart_Id INT
AS
BEGIN
    SELECT * FROM Cart
    WHERE Cart_Id = @Cart_Id
END

-------------------------------------------------------------------------------------
		CREATE PROCEDURE GetCartItemsByTable
			@Table_Id INT
		AS
		BEGIN
			SELECT 
				c.Cart_Id,
				c.Table_Id,	
				c.Menu_Item_Id,
				m.Name AS Item_Name,
				c.Quantity,
				c.Price
			FROM Cart c
			INNER JOIN Menu m ON c.Menu_Item_Id = m.Menu_Item_Id
			WHERE c.Table_Id = @Table_Id
		END
--------------------------------------------------------------------
CREATE PROCEDURE sp_RemoveFromCart
    @Cart_Id INT
AS
BEGIN
    DELETE FROM Cart
    WHERE Cart_Id = @Cart_Id;
END
-------------------------------------------------------------------------

CREATE  or Alter PROCEDURE sp_SubmitOrder_NoUser
    @TableId INT
AS
BEGIN
    DECLARE @OrderId INT

    -- Insert order
    INSERT INTO Orders ( Table_Id, Order_Status, Total_Amount, Payment_Status_Id, Created_At)
    SELECT  @TableId, 'Pending', SUM(Quantity * Price), 1, GETDATE()
    FROM Cart
    WHERE Table_Id = @TableId

    SET @OrderId = SCOPE_IDENTITY()

    -- Insert order items
    INSERT INTO Order_Items (Order_Id, Menu_Item_Id, Quantity, Price)
    SELECT @OrderId, Menu_Item_Id, Quantity, Price
    FROM Cart
    WHERE Table_Id = @TableId
END
--------------------------------------------------------------------------------

CREATE PROCEDURE sp_ClearCart_NoUser
    @TableId INT
AS
BEGIN
    DELETE FROM Cart WHERE Table_Id = @TableId
END
-------------------------------------------------------------------------------
CREATE PROCEDURE sp_UpdateTableStatus
    @TableId INT,
    @Status NVARCHAR(50)
AS
BEGIN
    UPDATE Tables SET Status = @Status WHERE Table_Id = @TableId
END

---------------------------------------------------------------
CREATE PROCEDURE sp_UpdateTablesStatus
    @Table_Id INT,
    @Status NVARCHAR(50)
AS
BEGIN
    UPDATE Tables
    SET Status = @Status
    WHERE Table_Id = @Table_Id;
END
--------------------------------------------------------------
	CREATE PROCEDURE sp_GetOrderDetailsForBill
		@OrderId INT
	AS
	BEGIN
		SELECT oi.Menu_Item_Id, oi.Quantity, oi.Price, 
			   (oi.Quantity * oi.Price) AS TotalPrice, mi.Name
		FROM Order_Items oi
		JOIN Menu_Items mi ON oi.Menu_Item_Id = mi.Menu_Item_Id
		WHERE oi.Order_Id = @OrderId;
	END
-----------------------------------------------------------------------
select * from Orders
CREATE PROCEDURE sp_InsertOrderFromCart
    @TableId INT,
    @UserId INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @TotalAmount DECIMAL(10,2) = 0;

    SELECT @TotalAmount = SUM(Total_Price) FROM Cart WHERE Table_Id = @TableId;

    INSERT INTO Orders (Table_Id, User_Id, Total_Amount, Order_Status, Payment_Status_Id)
    VALUES (@TableId, @UserId, @TotalAmount, 'Pending', 1);

    DECLARE @OrderId INT = SCOPE_IDENTITY();

    INSERT INTO Order_Items (Order_Id, Menu_Item_Id, Quantity, Price)
    SELECT 
        @OrderId,
        Menu_Item_Id,
        Quantity,
        Price
    FROM Cart
    WHERE Table_Id = @TableId;

    DELETE FROM Cart WHERE Table_Id = @TableId;

    UPDATE Tables SET Status = 'Occupied' WHERE Table_Id = @TableId;
END
---------------------------------------------------------------------------------------------
CREATE  or Alter   PROCEDURE sp_GetKitchenPendingOrders
AS
BEGIN
    SELECT 
        o.Order_Id,
        o.Table_Id,
        o.Order_Status,
        o.Created_At,
        oi.Quantity,
        oi.Price,
        oi.Special_Instructions,
        m.Name AS Menu_Item_Name,
        o.Total_Amount,
		oi.Order_Item_Id,
		oi.Order_Item_Status
    FROM Orders o
    INNER JOIN Order_Items oi ON o.Order_Id = oi.Order_Id
    INNER JOIN Menu m ON oi.Menu_Item_Id = m.Menu_Item_Id
    WHERE o.Order_Status = 'Pending'
END

	select * from Orders order by Order_Id desc
	select * from Order_Items order by Order_Item_Id desc

Exec sp_GetKitchenPendingOrders


------------------------------------------------------------------

		CREATE PROCEDURE sp_UpdateOrderStatus
			@Order_Id INT,
			@NewStatus NVARCHAR(50)
		AS
		BEGIN
			UPDATE Orders
			SET Order_Status = @NewStatus
			WHERE Order_Id = @Order_Id
		END

---------------------------------------------------------------------------------

CREATE PROCEDURE dbo.UpdateCartItem
    @CartId INT,
    @Quantity INT
AS
BEGIN
    UPDATE Cart
    SET Quantity = @Quantity
       
    WHERE Cart_Id = @CartId;
END

--------------------------------------------------------------------------------------------

CREATE PROCEDURE sp_MarkOrderAsReady
    @OrderId INT
AS
BEGIN
    UPDATE Orders
    SET Order_Status = 'Ready'
    WHERE Order_Id = @OrderId;
    
    -- You can also include any other logic you want, such as logging, notifications, etc.
END

---------------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE GetReadyOrders
AS
BEGIN
    SELECT 
        o.Order_Id,
        o.Table_Id,
        o.Order_Status,
        o.Created_At,
        oi.Quantity,
        oi.Price,
        oi.Special_Instructions,
        m.Name AS Menu_Item_Name,
        o.Total_Amount
    FROM Orders o
    INNER JOIN Order_Items oi ON o.Order_Id = oi.Order_Id
    INNER JOIN Menu m ON oi.Menu_Item_Id = m.Menu_Item_Id
    WHERE o.Order_Status = 'Ready'
    ORDER BY o.Created_At ASC
END


--------------------------------------------------------------------------------------------------------------
SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_UpdateOrderItemStatuss';
SELECT * FROM Order_Items WHERE Order_Item_Id = 8

	

CREATE PROCEDURE UpdateOrderItemStatuss
    @Order_Item_Id INT,
    @Order_Item_Status VARCHAR(50)
AS
BEGIN
    IF EXISTS (
        SELECT 1 FROM Order_Items WHERE Order_Item_Id = @Order_Item_Id
    )
    BEGIN
        UPDATE Order_Items
        SET 
            Order_Item_Status = @Order_Item_Status,
            Updated_At = GETDATE()
        WHERE Order_Item_Id = @Order_Item_Id;

        -- Optional return data
        SELECT * 
        FROM Order_Items oi
        INNER JOIN Orders o ON oi.Order_Id = o.Order_Id
        WHERE oi.Order_Item_Id = @Order_Item_Id;
    END
    ELSE
    BEGIN
        RAISERROR('Order item not found.', 16, 1);
    END
END

----------------------------------------------------------------------------------------------------------------
CREATE or alter PROCEDURE sp_GetReadyOrderItems
AS
BEGIN
SELECT 
    oi.Order_Item_Id,
    oi.Order_Id,
    m.Name AS Menu_Item_Name,
    oi.Quantity,
    t.Table_Number,
    oi.Order_Item_Status,
    oi.Special_Instructions,
    oi.Updated_At
FROM Order_Items oi
INNER JOIN Menu m ON oi.Menu_Item_Id = m.Menu_Item_Id
INNER JOIN Orders o ON oi.Order_Id = o.Order_Id
INNER JOIN Tables t ON o.Table_Id = t.Table_Id
WHERE oi.Order_Item_Status = 'ready'
ORDER BY oi.Updated_At DESC
END
EXEC sp_GetReadyOrderItems

select*from Order_Items order by order_id Desc
select*from Orders order by order_id Desc
exec Add
------------------------------------------------------------------------------------------------------------------------------

CREATE  or Alter PROCEDURE MarkOrderCompleted
    @Order_Item_Id INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Order_Items
    SET Order_Item_Status = 'Completed',
        Updated_At = GETDATE()
    WHERE Order_Item_Id = @Order_Item_Id;
END

SELECT * FROM Order_Items
WHERE Order_Item_Status = 'Ready';

	-----------------------------------------------------------------------------------------------------------------------
	/*Order History */

	CREATE or Alter PROCEDURE sp_GetOrderHistory
AS
BEGIN
    SELECT 
        o.Order_Id,
        o.Order_Status,
        o.Total_Amount,
        oi.Menu_Item_Id,
        oi.Quantity,
        oi.Price,
        oi.Order_Item_Status,
        m.Name AS Menu_Item_Name,
        oi.Updated_At,
        o.Created_At
    FROM 
        Orders o
    INNER JOIN 
        Order_Items oi ON o.Order_Id = oi.Order_Id
    INNER JOIN 
        Menu m ON oi.Menu_Item_Id = m.Menu_Item_Id
    ORDER BY 
        o.Created_At DESC, o.Order_Id;
END;
--------------------------------------------------------------------------------------
	-- 1. Get All Discounts
CREATE or Alter PROCEDURE GetAllDiscounts
AS
BEGIN
    SELECT * FROM Discounts;
END
GO

-- 2. Get Discount by ID
CREATE or Alter PROCEDURE GetDiscountById
    @DiscountId INT
AS
BEGIN
    SELECT * FROM Discounts WHERE Discount_Id = @DiscountId;
END
GO

-- 3. Add a New Discount
CREATE or Alter PROCEDURE AddDiscount
    @Name NVARCHAR(100),
    @Discount_Type NVARCHAR(50),
    @Value DECIMAL(10,2),
    @Start_Date DATETIME,
    @End_Date DATETIME
AS
BEGIN
    INSERT INTO Discounts (Name, Discount_Type, Value, Start_Date, End_Date)
    VALUES (@Name, @Discount_Type, @Value, @Start_Date, @End_Date);
END
GO

-- 4. Update Existing Discount
CREATE or Alter PROCEDURE UpdateDiscount
    @Discount_Id INT,
    @Name NVARCHAR(100),
    @Discount_Type NVARCHAR(50),
    @Value DECIMAL(10,2),
    @Start_Date DATETIME,
    @End_Date DATETIME
AS
BEGIN
    UPDATE Discounts
    SET Name = @Name,
        Discount_Type = @Discount_Type,
        Value = @Value,
        Start_Date = @Start_Date,
        End_Date = @End_Date
    WHERE Discount_Id = @Discount_Id;
END
GO

-- 5. Delete a Discount
CREATE or Alter PROCEDURE DeleteDiscount
    @DiscountId INT
AS
BEGIN
    DELETE FROM Discounts WHERE Discount_Id = @DiscountId;
END
GO

CREATE PROCEDURE sp_GetDiscountIdByValue
    @Discount_Value FLOAT
AS
BEGIN
    SELECT Discount_Id
    FROM Discounts
    WHERE Value = @Discount_Value
END


--------------------------------------------------------------------------------------------------------------------------------

-- 1. Stored Procedure to Get All Taxes
CREATE PROCEDURE GetAllTaxes
AS
BEGIN
    SELECT * FROM Taxes;
END;
GO

-- 2. Stored Procedure to Get a Tax by ID
CREATE PROCEDURE GetTaxById
    @Tax_Id INT
AS
BEGIN
    SELECT * FROM Taxes WHERE Tax_Id = @Tax_Id;
END;
GO

-- 3. Stored Procedure to Add a Tax
CREATE PROCEDURE AddTax
    @Name NVARCHAR(100),
    @Percentage DECIMAL(5,2)
AS
BEGIN
    INSERT INTO Taxes (Name, Percentage)
    VALUES (@Name, @Percentage);
END;
GO

-- 4. Stored Procedure to Update a Tax
CREATE PROCEDURE UpdateTax
    @Tax_Id INT,
    @Name NVARCHAR(100),
    @Percentage DECIMAL(5,2)
AS
BEGIN
    UPDATE Taxes
    SET Name = @Name, Percentage = @Percentage
    WHERE Tax_Id = @Tax_Id;
END;
GO

-- 5. Stored Procedure to Delete a Tax
CREATE PROCEDURE DeleteTax
    @Tax_Id INT
AS
BEGIN
    DELETE FROM Taxes WHERE Tax_Id = @Tax_Id;
END;
GO

CREATE PROCEDURE sp_GetTaxIdByPercentage
    @Tax_Percentage FLOAT
AS
BEGIN
    SELECT Tax_Id
    FROM Taxes
    WHERE Percentage = @Tax_Percentage
END

------------------------------------------------------------------------------------------------------------------------------------------
	select *from Bill
	CREATE or Alter PROCEDURE InsertBill
		@Order_Id INT,
		@Tax_Id INT,
		@Discount_Id INT,
		@Total DECIMAL(10, 2)
	AS
	BEGIN
		INSERT INTO Bill (Order_Id, Tax_Id, Discount_Id, Total)
		VALUES (@Order_Id, @Tax_Id, @Discount_Id, @Total)

		SELECT SCOPE_IDENTITY() AS Bill_Id
	END
	-------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE GetLatestOrderIdByTable
    @Table_Id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 1 Order_Id
    FROM Orders
    WHERE Table_Id = @Table_Id
    ORDER BY Created_At DESC; -- Assumes you have a datetime column like Created_At
END;

select*from Discounts
----------------------------------------------------------------------------------------------------------------------------------------------
/*CREATE OR ALTER PROCEDURE sp_GetBillDetailsByOrderId
    @Order_Id INT
AS
BEGIN
    -- 1. Bill Detail with Tax & Discount
    SELECT 
        B.Bill_Id, B.Order_Id, B.Tax_Id, B.Discount_Id, B.Total, B.Created_At,
        T.Percentage,
        D.Value
    FROM Bill B
    LEFT JOIN Taxes T ON B.Tax_Id = T.Tax_Id
    LEFT JOIN Discounts D ON B.Discount_Id = D.Discount_Id
    WHERE B.Order_Id = @Order_Id;

    -- 2. Order Detail
    SELECT 
        O.Order_Id, O.Table_Id, O.User_Id, O.Total_Amount, O.Order_Status, O.Created_At,
        TBL.Table_Number
    FROM Orders O
    INNER JOIN Tables TBL ON O.Table_Id = TBL.Table_Id
    WHERE O.Order_Id = @Order_Id;

    -- 3. Order Items with Menu Item names
    SELECT 
        OI.Order_Item_Id, OI.Menu_Item_Id, M.Name, OI.Quantity, OI.Price, OI.Special_Instructions
    FROM Order_Items OI
    INNER JOIN Menu M ON OI.Menu_Item_Id = M.Menu_Item_Id
    WHERE OI.Order_Id = @Order_Id;
END*/
CREATE OR ALTER PROCEDURE sp_GetBillDetailsByOrderId
    @Order_Id INT
AS
BEGIN
    -- 1. Bill Details with Tax % and Discount ₹
    SELECT B.*, T.Percentage AS Tax_Percentage, D.Value AS Discount_Value
    FROM Bill B
    LEFT JOIN Taxes T ON B.Tax_Id = T.Tax_Id
    LEFT JOIN Discounts D ON B.Discount_Id = D.Discount_Id
    WHERE B.Order_Id = @Order_Id;

    -- 2. Order Details
    -- 2. Order Details with Payment Status Name
SELECT 
    O.Order_Id,
    O.Order_Status,
    O.Total_Amount As Sub_Total,
    PS.Status_Name AS Payment_Status_Name
FROM Orders O
LEFT JOIN Payment_Status PS ON O.Payment_Status_Id = PS.Payment_Status_Id
WHERE O.Order_Id = @Order_Id;

    -- 3. Order Items with Menu Name
    SELECT 
         OI.Quantity, OI.Price,
        M.Name AS Menu_Name
    FROM Order_Items OI
    INNER JOIN Menu M ON OI.Menu_Item_Id = M.Menu_Item_Id
    WHERE OI.Order_Id = @Order_Id;
END



exec sp_GetBillDetailsByOrderId 169
-----------------------------------------------------------------------------------------------------------------------------+

CREATE OR ALTER PROCEDURE sp_GetBillDisplay
AS
BEGIN
    SELECT 
        B.Bill_Id,
        B.Order_Id,
        B.Total,
        B.Created_At,

        -- Tax Info
        T.Tax_Id,
        T.Percentage AS Tax_Percentage,

        -- Discount Info
        D.Discount_Id,
        D.Value AS Discount_Value,

        -- Order Info
        O.Order_Status,
        O.Total_Amount,
        O.Payment_Status_Id,
        PS.Status_Name AS Payment_Status_Name
    FROM Bill B
    LEFT JOIN Taxes T ON B.Tax_Id = T.Tax_Id
    LEFT JOIN Discounts D ON B.Discount_Id = D.Discount_Id
    LEFT JOIN Orders O ON B.Order_Id = O.Order_Id
    LEFT JOIN Payment_Status PS ON O.Payment_Status_Id = PS.Payment_Status_Id
    ORDER BY B.Bill_Id DESC;
END

	EXEC sp_GetBillDisplay;
	select*from Payment_Method
-----------------------------------------------------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE sp_ProcessPayment
    @Order_Id INT,
    @Method_Name NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Payment_Method_Id INT;
    DECLARE @Payment_Status_Id INT;
    DECLARE @Transaction_Id INT;
    DECLARE @Amount DECIMAL(10, 2);

    -- Normalize input to lowercase for safe matching
    SET @Method_Name = LOWER(@Method_Name);

    -- Get Payment Method ID
    SELECT @Payment_Method_Id = Payment_Method_Id 
    FROM Payment_Method 
    WHERE LOWER(Method_Name) = @Method_Name;

    -- Get Order Amount
    SELECT @Amount = Total_Amount 
    FROM Orders 
    WHERE Order_Id = @Order_Id;

    -- Set Payment Status ID
    IF @Method_Name = 'cash'
        SET @Payment_Status_Id = 2; -- Paid
    ELSE IF @Method_Name IN ('upi', 'card')
        SET @Payment_Status_Id = 1; -- Pending
    ELSE
    BEGIN
        RAISERROR('Invalid payment method.', 16, 1);
        RETURN;
    END

    -- Update Payment Status in Orders table
    UPDATE Orders
    SET Payment_Status_Id = @Payment_Status_Id
    WHERE Order_Id = @Order_Id;

    -- Insert into Transactions
    INSERT INTO Transactions (Order_Id, Payment_Method_Id, Payment_Status_Id, Amount)
    VALUES (@Order_Id, @Payment_Method_Id, @Payment_Status_Id, @Amount);

    SET @Transaction_Id = SCOPE_IDENTITY();

    -- Insert into Payments
    INSERT INTO Payments (Transaction_Id, Total_Amount)
    VALUES (@Transaction_Id, @Amount);
END;
select * from Payments
----------------------------------------------------------------------------------------------------------------------------------------

CREATE OR ALTER PROCEDURE GetFilteredPaymentSummary
    @StartDate DATETIME,
    @EndDate DATETIME
AS
BEGIN
    SELECT
        SUM(CASE WHEN LOWER(pm.Method_Name) = 'cash' AND LOWER(ps.Status_Name) = 'paid' THEN p.Total_Amount ELSE 0 END) AS CashTotal,
        SUM(CASE WHEN LOWER(pm.Method_Name) = 'upi' AND LOWER(ps.Status_Name) = 'paid' THEN p.Total_Amount ELSE 0 END) AS UPITotal,
        SUM(CASE WHEN LOWER(pm.Method_Name) = 'card' AND LOWER(ps.Status_Name) = 'paid' THEN p.Total_Amount ELSE 0 END) AS CardTotal,
        SUM(CASE WHEN LOWER(ps.Status_Name) = 'paid' THEN p.Total_Amount ELSE 0 END) AS GrandTotal
    FROM Payments p
    INNER JOIN Transactions t ON p.Transaction_Id = t.Transaction_Id
    INNER JOIN Payment_Method pm ON t.Payment_Method_Id = pm.Payment_Method_Id
    INNER JOIN Payment_Status ps ON t.Payment_Status_Id = ps.Payment_Status_Id
    WHERE p.Paid_At BETWEEN @StartDate AND @EndDate;
END;

select*from Payments

----------------------------------------------------------------------------------------------------------------------------------------------
		CREATE OR ALTER PROCEDURE ClearPaymentSummary
		AS
		BEGIN
			SET NOCOUNT ON;

			DECLARE @Today DATE = CAST(GETDATE() AS DATE);

			IF EXISTS (SELECT 1 FROM DailyPaymentSummary WHERE SummaryDate = @Today)
			BEGIN
				UPDATE DailyPaymentSummary
				SET Cash = 0, UPI = 0, Card = 0, Grand = 0
				WHERE SummaryDate = @Today;
			END
			ELSE
			BEGIN
				INSERT INTO DailyPaymentSummary (SummaryDate, Cash, UPI, Card, Grand)
				VALUES (@Today, 0, 0, 0, 0);
			END
		END;
		exec ClearDailyPaymentSummary


-----------------------------------------------------------------------------------------------------------------------------------------
/*Expense*/
/*Add*/
CREATE PROCEDURE sp_AddExpense
    @Category NVARCHAR(100),
    @Amount DECIMAL(18, 2),
    @Date DATETIME,
    @Note NVARCHAR(255)
AS
BEGIN
    INSERT INTO Expenses (Category, Amount, Date, Note)
    VALUES (@Category, @Amount, @Date, @Note)
END
/*Update*/
CREATE PROCEDURE sp_UpdateExpense
    @Id INT,
    @Category NVARCHAR(100),
    @Amount DECIMAL(18, 2),
    @Date DATETIME,
    @Note NVARCHAR(255)
AS
BEGIN
    UPDATE Expenses
    SET Category = @Category,
        Amount = @Amount,
        Date = @Date,
        Note = @Note
    WHERE Id = @Id
END
/*Delete*/
CREATE PROCEDURE sp_DeleteExpense
    @Id INT
AS
BEGIN
    DELETE FROM Expenses
    WHERE Id = @Id
END

/*All Expenses*/
CREATE PROCEDURE sp_GetAllExpenses
AS
BEGIN
    SELECT Id, Category, Amount, Date, Note
    FROM Expenses
    ORDER BY Date DESC
END
/* By Id*/
CREATE PROCEDURE sp_GetExpenseById
    @Id INT
AS
BEGIN
    SELECT Id, Category, Amount, Date, Note
    FROM Expenses
    WHERE Id = @Id
END



