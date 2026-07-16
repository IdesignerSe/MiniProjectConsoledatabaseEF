import { useEffect, useState } from "react";
import { getCourses } from "../api";
import CreateCourseForm from "./CreateCourseForm";

export default function CoursesList() {
  const [courses, setCourses] = useState([]);

  useEffect(() => {
    async function load() {
      const data = await getCourses();
      setCourses(data);
    }
    load();
  }, []);

  function handleCourseCreated(course) {
    setCourses(prev => [...prev, course]);
  }

  return (
    <div className="section courses">

      <h2>Courses</h2>

      <CreateCourseForm onCreated={handleCourseCreated} />

      <ul>
        {courses.map(c => (
          <li key={c.id}>
            {c.title} — {c.credits} credits
          </li>
        ))}
      </ul>
    </div>
  );
}
