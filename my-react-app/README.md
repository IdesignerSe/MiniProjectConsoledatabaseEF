📘 School Management System — Full CRUD (React + REST API)

This project is a web application built with React that interacts with a .NET REST API to manage students, courses, profiles, and enrollments.
It includes full CRUD functionality (Create, Read, Update, Delete) for all four main entities in the system.


🚀 Technologies Used

React 18 — user interface

JavaScript (ES6+) — frontend logic

Fetch API — communication with the backend

.NET Web API — REST server

Custom CSS — styling, dark mode, and section‑based design


📂 Project Structure

```text

src/
│
├── api.js                 # All REST functions (GET, POST, PUT, DELETE)
│
├── components/
│   ├── StudentsList.jsx
│   ├── CreateStudentForm.jsx
│   ├── CoursesList.jsx
│   ├── CreateCourseForm.jsx
│   ├── ProfilesList.jsx
│   ├── CreateProfileForm.jsx
│   ├── EnrollmentsList.jsx
│   └── CreateEnrollmentForm.jsx
│
├── index.css              # Global styles, section colors, CRUD button styles
└── App.jsx                # Main render of all sections

``` 

🧩 Main Features

✔ Students
Create students

List students

Edit students

Delete students

✔ Courses
Create courses

List courses

Edit courses

Delete courses

✔ Profiles
Create profiles

List profiles

Edit profiles

Delete profiles

✔ Enrollments
Create enrollments

List enrollments

Edit enrollments

Delete enrollments


🎨 Design & User Experience

Each section has its own color theme (Students, Courses, Profiles, Enrollments).

Styled CRUD buttons:

Edit (blue)

Delete (red)

Save (green)

Cancel (gray)

Automatic dark mode using prefers-color-scheme.

Clean and professional layout.

🔌 REST API

The api.js file contains all functions used to communicate with the backend:

getStudents(), createStudent(), updateStudent(), deleteStudent()

getCourses(), createCourse(), updateCourse(), deleteCourse()

getProfiles(), createProfile(), updateProfile(), deleteProfile()

getEnrollments(), createEnrollment(), updateEnrollment(), deleteEnrollment()

All functions use fetch() and return JSON data.

▶️ How to Run the Project:

1. Clone the repository

git clone <your-repo>
2. Install dependencies

npm install
3. Start the React development server

npm run dev
4. Start the .NET API (backend)

dotnet run

Make sure the API is running at:
http://localhost:5104/api