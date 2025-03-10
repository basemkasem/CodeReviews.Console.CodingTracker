# Coding Tracker
Coding Tracker is a console app that logs coding sessions, tracks duration, and stores data in an SQLite database.

## ✨ Features

- Start and stop coding sessions
- View past coding sessions
- Track total time spent coding
- Store data in an SQLite database
- Simple console-based user interface

## 🛠️ Technologies Used

- **C#** (Console Application)
- **.NET** (Latest version recommended)
- **Dapper** (Micro-ORM for database interactions)
- **SQLite** (Lightweight database engine)
- **Spectre.Console** (For better console UI)

## 🔧 Installation

1. **Clone the Repository**

   ```sh
   git clone https://github.com/basemkasem/CodeReviews.Console.CodingTracker
   cd CodingTracker
   ```

2. **Install Dependencies**

   Run the following command to install required NuGet packages:
   ```sh
   dotnet restore
   ```

3. **Build the Project**

   ```sh
   dotnet build
   ```

## 🚀 Usage

1. **Run the application**
   ```sh
   dotnet run
   ```
2. Follow the prompts to:
   - Add a coding session
   - Update a session
   - View recorded sessions
   - Delete a session

## 📂 Database Structure

The project uses an SQLite database file (`coding-tracker.db`) with the table:

```sql
CREATE TABLE IF NOT EXISTS CodingSessions (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    StartTime DATETIME NOT NULL,
    EndTime DATETIME NOT NULL,
    Duration INTEGER NOT NULL
);
```

## 📚 Project Source

This project was inspired by the **Coding Tracker** project from [The C# Academy](https://www.thecsharpacademy.com/project/13/coding-tracker). It helps improve C# skills, database work, and console app development.

