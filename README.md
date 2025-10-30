# Employee Attendance Management System (ASP.NET Core MVC)

## Project Description
The **Employee Attendance Management System** is a web-based application built using **ASP.NET Core MVC (.NET 8)** and **Entity Framework Core 9.0.10**.  
It helps organizations manage employee details and daily attendance efficiently.  

Users can:
- Add, edit, delete, and view employee records.  
- Mark attendance (Present, Absent, or Leave).  
- View and generate daily attendance reports.

---

## ⚙️ Technologies Used
- **.NET 8.0 SDK**  
- **ASP.NET Core MVC Framework**  
- **Entity Framework Core 9.0.10** (Code-First approach)  
- **SQL Server (LocalDB)**  
- **Bootstrap 5** (for responsive UI)  
- **Visual Studio / Visual Studio Code**

---

## 🧩 Folder Structure
```
EmployeeAttendanceSystem/
│
├── Controllers/
│   ├── HomeController.cs
│   ├── EmployeesController.cs
│   └── AttendanceController.cs
│
├── Models/
│   ├── Employee.cs
│   ├── Attendance.cs
│   └── ApplicationDbContext.cs
│
├── Views/
│   ├── Home/
│   │   └── Index.cshtml
│   ├── Employees/
│   │   ├── Index.cshtml
│   │   ├── Create.cshtml
│   │   ├── Edit.cshtml
│   │   └── Details.cshtml
│   ├── Attendance/
│       ├── Index.cshtml
│       ├── MarkAttendance.cshtml
│       └── Report.cshtml
│
├── wwwroot/
│   └── css/, js/, bootstrap files
│
├── appsettings.json
├── appsettings.Development.json
├── Program.cs
├── EmployeeAttendanceSystem.csproj
└── README.md
```

---

## Features
✅ Manage Employee Records (CRUD operations)  
✅ Mark Employee Attendance (Present / Absent / Leave)  
✅ Generate Attendance Reports  
✅ Responsive Bootstrap UI  
✅ SQL Server LocalDB integration using Entity Framework Core  

---

## 🖥️ Installation & Setup (Windows 11)

Follow these steps to install and run the project successfully on your Windows system.

---

### 🧱 Step 1: Install .NET 8 SDK
Download and install from:  
👉 [https://dotnet.microsoft.com/en-us/download/dotnet/8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

Verify installation:
```bash
dotnet --version
```

Expected output:
```
8.0.x
```

---

### 🧱 Step 2: (Optional) Remove Old .NET Versions
To list all installed SDKs:
```bash
dotnet --list-sdks
```

If you want to remove older versions (e.g., .NET 6 or 7):
1. Open **Control Panel → Programs → Programs and Features**
2. Locate **Microsoft .NET SDK x.x.x**
3. Right-click → **Uninstall**

*(Keeping multiple SDKs is fine if you prefer.)*

---

### 🧱 Step 3: Create Project Folder
In Command Prompt or PowerShell:
```bash
dotnet new mvc -n EmployeeAttendanceSystem
cd EmployeeAttendanceSystem
```

---

### 🧱 Step 4: Add Required Packages
Install Entity Framework Core 9.0.10 packages:
```bash
dotnet add package Microsoft.EntityFrameworkCore --version 9.0.10
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 9.0.10
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 9.0.10
```

---

### 🧱 Step 5: Configure Database Connection

**`appsettings.json`**
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=EmployeeAttendanceDB;Trusted_Connection=True;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

**`appsettings.Development.json`**
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=EmployeeAttendanceDB_Dev;Trusted_Connection=True;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Debug",
      "Microsoft.AspNetCore": "Debug"
    }
  }
}
```

---

### 🧱 Step 6: Add Database Context & Models
Inside the **Models** folder, create the following files:

#### ✅ Employee.cs
```csharp
using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeAttendanceSystem.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Employee name is required")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Department is required")]
        public string Department { get; set; } = string.Empty;

        [Required(ErrorMessage = "Designation is required")]
        public string Designation { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [Display(Name = "Date of Joining")]
        public DateTime DateOfJoining { get; set; }
    }
}
```

#### ✅ ApplicationDbContext.cs
```csharp
using Microsoft.EntityFrameworkCore;

namespace EmployeeAttendanceSystem.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
    }
}
```

---

### 🧱 Step 7: Enable EF Core Tools
```bash
dotnet tool install --global dotnet-ef
```

Verify installation:
```bash
dotnet ef
```

---

### 🧱 Step 8: Create and Apply Database Migrations
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

This will create your SQL Server LocalDB database automatically.

---

### 🧱 Step 9: Run the Project
Run the app:
```bash
dotnet run
```

Then open your browser and visit:  
👉 [https://localhost:5001](https://localhost:5001)

---

## 🧰 Common Commands

| Task | Command |
|------|----------|
| Create new controller | `dotnet new controller -n MyController` |
| Add EF migration | `dotnet ef migrations add MigrationName` |
| Apply migrations | `dotnet ef database update` |
| Clean & rebuild | `dotnet clean && dotnet build` |
| Run project | `dotnet run` |

---

## 📸 Pages Overview

| Page | URL | Function |
|------|-----|-----------|
| Home | `/` | Welcome page |
| Employees | `/Employees` | View & manage employee list |
| Add Employee | `/Employees/Create` | Add new employee |
| Edit Employee | `/Employees/Edit/{id}` | Edit existing record |
| Attendance | `/Attendance` | View attendance records |
| Mark Attendance | `/Attendance/MarkAttendance` | Mark new attendance |
| Report | `/Attendance/Report` | View attendance report |

---

## ⚠️ Troubleshooting Tips
🔹 **Error:** “Unable to create DbContext”  
→ Ensure your `ApplicationDbContext` constructor includes `DbContextOptions<ApplicationDbContext>` and is registered in `Program.cs`.

🔹 **Error:** “dotnet ef not recognized”  
→ Run:  
```bash
dotnet tool install --global dotnet-ef
```

🔹 **Database not updating:**  
→ Clean and rebuild:
```bash
dotnet clean
dotnet build
dotnet ef database update
```

---

##Optional Enhancements
You can extend this system with:
- Admin login authentication (Identity-based)
- Export attendance reports to Excel or PDF
- Add search and filter for employees
- Implement role-based access control
- Attendance analytics dashboard

---

## 👩‍💻 Author
**Patil Bhakti Prashant**  
Department of Computer Science  
📧 [bhaktipatil120999@gmail.com](mailto:bhaktipatil120999@gmail.com)

---

## 📜 License
**MIT License © 2025**  

You are free to use, modify, and distribute this project for educational purposes.
"# Employee-Attendance-System" 
