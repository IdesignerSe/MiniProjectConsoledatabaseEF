import StudentsList from "./components/StudentsList";
import CoursesList from "./components/CoursesList";
import ProfilesList from "./components/ProfilesList";
import EnrollmentsList from "./components/EnrollmentsList";

function App() {
  return (
    <div>
      <h1>School System</h1>
      <StudentsList />
      <CoursesList />
      <ProfilesList />
      <EnrollmentsList />
    </div>
  );
}

export default App;
