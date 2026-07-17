📘 School Management System — Full CRUD (React + REST API)

This project is a web application built with React that interacts with a .NET REST API to manage students, courses, profiles, and enrollments.
It includes full CRUD functionality (Create, Read, Update, Delete) for all four main entities in the system.


🚀 Technologies Used

React 18 — user interface

JavaScript (ES6+) — frontend logic

Fetch API — communication with the backend

.NET Web API — REST server

Custom CSS — styling, dark mode, and section‑based design



✅ How to Open the ApiServer (.NET Web API)

1. Open the solution folder in Visual Studio or VS Code:

Go to MiniProjectConsoleDatabaseEF/ApiServer
2. Restore dependencies (only needed once):

After dotnet restore
3. Run the API:
dotnet run 


4. The backend will start at:
http://localhost:5104/api 


This project contains the REST API, Entity Framework Core, and the SQLite database (`school.db`).


✅ How to Open the ConsoleApp (.NET Console Project)

1. Navigate to the ConsoleApp folder:

MiniProjectConsoleDatabaseEF/ConsoleApp


2. Open the project in Visual Studio or VS Code.

3. Restore dependencies:
dotnet restore


4. Run the console application:
dotnet run

This project was used during early development to test database logic before the full API and React UI were implemented.


✅ How to Open the my-react-app (React Frontend) Main UI to add and delete update, etc..

1. Navigate to the React project:
MiniProjectConsoleDatabaseEF/my-react-app


2. Install dependencies:
npm install


3. Start the development server:
npm run dev


4. The frontend will start at:
http://localhost:5173/ 

This project contains all CRUD UI components for Students, Courses, Profiles, and Enrollments.


📂 Project Structure

APISERVER

```text

ApiServer/
│
├── Controllers/
│   ├── StudentsController.cs
│   ├── CoursesController.cs
│   ├── ProfilesController.cs
│   └── EnrollmentsController.cs
│
├── Data/
│   └── AppDbContext.cs
│
├── Migrations/
│   ├── 00000000000000_InitialCreate.cs
│   ├── 00000000000000_InitialCreate.Designer.cs
│   └── AppDbContextModelSnapshot.cs
│
├── Models/
│   ├── Student.cs
│   ├── Course.cs
│   ├── StudentProfile.cs
│   └── Enrollment.cs
│
├── Properties/
│   └── launchSettings.json
│
├── appsettings.json
├── appsettings.Development.json
├── Program.cs
├── ApiServer.csproj
└── school.db                # SQLite database file

``` 


MY REACT APP (FRONTEND)

```text

my-react-app/
│
├── node_modules/
│
├── public/
│   ├── favicon.svg
│   └── icons.svg
│
├── src/
│   │
│   ├── assets/
│   │
│   ├── components/
│   │   ├── StudentsList.jsx
│   │   ├── CreateStudentForm.jsx
│   │
│   │   ├── CoursesList.jsx
│   │   ├── CreateCourseForm.jsx
│   │
│   │   ├── ProfilesList.jsx
│   │   ├── CreateProfileForm.jsx
│   │
│   │   ├── EnrollmentsList.jsx
│   │   └── CreateEnrollmentForm.jsx
│   │
│   ├── api.js
│   ├── App.jsx
│   ├── App.css
│   ├── global.css
│   ├── index.css
│   └── main.jsx
│
├── .gitignore
├── .eslintrc.json
├── index.html
├── package.json
├── package-lock.json
└── vite.config.js

``` 

CONSOLE APP

```text

ConsoleApp/
│
├── bin/                         # Build output (Debug/Release)
│
├── Data/
│   └── AppDbContext.cs          # EF Core database context
│
├── Migrations/                  # EF Core migrations
│   ├── 20260714091911_InitialCreate.cs
│   ├── 20260714091911_InitialCreate.Designer.cs
│   ├── 20260714091357_AddPhoneNumber.cs
│   ├── 20260714091357_AddPhoneNumber.Designer.cs
│   └── AppDbContextModelSnapshot.cs
│
├── Models/                      # Entity classes
│   ├── Course.cs
│   ├── Enrollment.cs
│   ├── Student.cs
│   └── StudentProfile.cs
│
├── obj/                         # Build artifacts (auto‑generated)
│   └── Debug/
│       ├── ConsoleApp.csproj.nuget.dgspec.json
│       ├── ConsoleApp.csproj.nuget.g.props
│       ├── ConsoleApp.csproj.nuget.g.targets
│       ├── project.assets.json
│       └── project.nuget.cache
│
├── ConsoleApp.csproj            # Project file
└── Program.cs                   # Main console entry point

``` 
🧩 Main Features
The School Management System provides complete CRUD functionality across four core entities: Students, Courses, Profiles, and Enrollments.
Each module includes intuitive UI controls and fully tested REST API operations.

✔ Students
Add new students

View all students

Update student information

Delete students

✔ Courses
Create new courses

List all courses

Edit course details

Remove courses

✔ Profiles
Create a profile for an existing student

View all profiles

Edit profile information

Delete profiles

✔ Enrollments
Enroll a student in a course

View all enrollments

Update enrollment details

Delete enrollments

🎨 User Interface & Experience
Clean and modern layout

Each section uses its own color theme

CRUD buttons styled for clarity:

Edit — blue

Delete — red

Save — green

Cancel — gray

Automatic dark mode using prefers-color-scheme

Simple, intuitive navigation across all modules
