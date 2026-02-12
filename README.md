# EchoPOS - Restaurant Point Of Sale System

EchoPOS is a comprehensive Point of Sale (POS) and Management System for restaurants. It features role-based access control, inventory management, table reservations, and a dynamic POS interface.

## 🚀 Features

- **Role-Based Authentication**: Custom dashboards for Admins, Waiters, Chefs, and Cashiers.
- **POS System**: Dynamic menu and table-based ordering system.
- **Kitchen Dashboard**: Real-time order tracking and status management for chefs.
- **Inventory Management**: Track stock levels, suppliers, and purchase history.
- **Reservation System**: Manage table bookings and availability.
- **Reporting & Analytics**: Order history, billing summary, and expense tracking.
- **Employee Management**: Shift scheduling and user role assignments.

## 🛠️ Tech Stack

- **Backend**: ASP.NET Core 8.0 (MVC)
- **Database**: SQL Server
- **ORM**: Dapper & Entity Framework Core
- **Frontend**: HTML5, CSS3, JavaScript, Bootstrap 5, jQuery
- **Containerization**: Docker & Docker Compose

## 📋 Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or VS Code

## ⚙️ Installation & Setup

### 1. Database Configuration
1. Create a new database named `EchoPay` in your SQL Server instance.
2. Execute the SQL scripts in the following order:
   - `EchoPay Tables.sql` (Creates schema)
   - `Sp EchoPay.sql` (Creates stored procedures)
   - `Data EchoPay.sql` (Inserts initial/seed data)

### 2. Connection String
Update the `ConnectionStrings` section in `appsettings.json` with your SQL Server credentials:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=EchoPay;User Id=YOUR_USER;Password=YOUR_PASSWORD;TrustServerCertificate=True"
}
```

### 3. Run via .NET CLI
```bash
dotnet restore
dotnet run
```

### 4. Run via Docker
```bash
docker compose up --build
```

### 5. then go to http://localhost:5000 in your browser

## 🔐 Default Credentials

| Role | Username | Password |
| :--- | :--- | :--- |
| **Admin** | Pratham Modi | Admin@123 |
| **Waiter** | Darshan | Waiter@123 |
| **Chef** | Rachit | Chef@123 |
| **Cashier** | Apurva | Cashier@123 |

## 📁 Project Structure

- `Controllers/`: Application logic and routing.
- `Models/`: Data structures and domain logic.
- `Views/`: Frontend templates (Razor).
- `Repository/`: Database access layer (Dapper).
- `wwwroot/`: Static assets (JS, CSS, Images).
- `*.sql`: Database initialization and seed scripts.

---

*Developed by Pratham Modi*

