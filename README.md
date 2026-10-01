# 🚗 Driving & Vehicle License Department (DVLD) System

[![.NET](https://img.shields.io/badge/.NET-%23512BD4.svg?style=flat&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-239120?style=flat&logo=c-sharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![WinForms](https://img.shields.io/badge/WinForms-Windows-blue)](https://docs.microsoft.com/en-us/dotnet/desktop/winforms/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-CC292B?style=flat&logo=microsoft-sql-server&logoColor=white)](https://www.microsoft.com/sql-server)
[![Dapper](https://img.shields.io/badge/ORM-Dapper-red)](https://github.com/DapperLib/Dapper)

A comprehensive, enterprise-grade desktop management system built using **C#**, **WinForms**, and **SQL Server**. The system automates and manages all administrative services of a Driving and Vehicle License Department, including driver management, multi-stage sequential test scheduling, license issuance, international licenses, renewals, replacements, and license detention/release logic.

---

## 🏛 Architecture & Design Patterns

The project is structured following clean architectural principles to ensure maintainability, scalability, and loose coupling:

- **Layered Architecture:** Clear separation between **UI (WinForms)**, **Application/Services Layer**, and **Infrastructure/Data Access Layer**.
- **Data Access Layer (DAL):** Powered by **Dapper Micro-ORM** for high-performance SQL execution and parameter mapping.
- **Dependency Injection:** Service and Repository lifecycles are registered and injected to uphold SOLID principles.
- **Asynchronous Programming:** Async/Await pattern applied across data access and service operations to keep the desktop UI responsive.

---

## 🌟 Key Features & Business Modules

### 1. 🪪 Driver & People Management
- Comprehensive CRUD operations for system users and citizens/applicants.
- National ID validation and duplicate prevention rules.
- Linked personal details across all applications and license records.

### 2. 📝 Driving License Applications (Local & International)
- **Local Driving License Applications:** Supports 7 different license classes (Motorcycles, Light Vehicles, Commercial, Heavy Trucks, etc.).
- **International License Issuance:** Restricted strictly to active Class 3 license holders with validity verification.

### 3. 🧪 Sequential Test Scheduling System
Applicants must pass three prerequisite tests sequentially:
1. **Vision Test**
2. **Written Test**
3. **Practical / Street Test**
- **Retake Logic:** Automatic handling and tracking of retake fees ($5 retake fee + test fee) if an applicant fails a test.
- Prevents scheduling out-of-order or duplicate active test appointments.

### 4. 🪪 License Lifecycle Operations
- **First-Time License Issuance:** Triggered upon passing all 3 sequential tests.
- **License Renewal:** Processes expired licenses with fee calculation and old license surrender tracking.
- **Replacement Management:** Supports issuing replacement licenses for Damaged or Lost licenses.
- **Detain & Release System:** Ability to detain active licenses with fine fees, and release them upon fee settlement.

### 5. 🔐 User Authentication & Authorization
- User account management linked to system Person profiles.
- Secure login and user permissions.

---

## 🛠 Tech Stack

- **Language:** C# 10 / .NET
- **UI Framework:** Windows Forms (WinForms)
- **Database:** Microsoft SQL Server
- **Data Access:** Dapper ORM
- **Version Control:** Git / GitHub

---

## 📂 Project Structure

```text
DVLD/
├── Domain                  # Core Entities, Enums, and Repository/Service Interfaces
├── Application             # DTOs, Business Services, and Application Logic
├── Infrastructure          # Database Context (Dapper), SQL Queries, and Repositories
├── DependencyInjection     # Service Bootstrapper & IoC Container Configuration
└── UI.WinForms             # Windows Forms UI, Custom Controls, Form Logic, & Resources
```
## ⚙️ Getting Started & Local Setup

### Prerequisites
- [Visual Studio 2022](https://visualstudio.microsoft.com/) (with .NET Desktop Development workload).
- [Microsoft SQL Server](https://www.microsoft.com/en-us/sql-server/) & SSMS.

### Installation
1. **Clone the repository:**
```bash
   git clone https://github.com/Zolfikaar/DVLD.git
```

2. **Setup Database:**
   - Execute the SQL Schema script included in the repository on your local SQL Server instance.
   - Update the connection string in `App.config` / configuration settings to point to your local SQL Server instance.

3. **Build & Run:**
   - Open `DVLD.sln` in Visual Studio.
   - Restore NuGet packages.
   - Set `UI.WinForms` as the Startup Project and press **F5**.


## 👤 Author

**Tholfikar Mohammed Matar**
- GitHub: [@Zolfikaar](https://github.com/Zolfikaar)
- LinkedIn: [https://www.linkedin.com/in/zolfikaar-kinani/](https://www.linkedin.com/in/zolfikaar-kinani/)