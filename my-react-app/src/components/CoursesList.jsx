import { useEffect, useState } from "react";
import { getCourses } from "../api";

export default function CoursesList() {
  const [courses, setCourses] = useState([]);

  useEffect(() => {
    async function load() {
      const data = await getCourses();
      console.log("Courses from API:", data);
      setCourses(data);
    }
    load();
  }, []);

  return (
    <div>
      <h2>Courses</h2>

      {courses.length === 0 && <p>No courses found.</p>}

      <ul>
        {courses.map(c => (
          <li key={c.Id}>
            {c.Title} — {c.Credits} credits
          </li>
        ))}
      </ul>
    </div>
  );
}