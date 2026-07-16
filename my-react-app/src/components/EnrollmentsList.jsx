import { useEffect, useState } from "react";
import { getEnrollments } from "../api";

export default function EnrollmentsList() {
  const [enrollments, setEnrollments] = useState([]);

  useEffect(() => {
    async function load() {
      const data = await getEnrollments();
      console.log("Enrollments from API:", data);
      setEnrollments(data);
    }
    load();
  }, []);

  return (
    <div>
      <h2>Enrollments</h2>

      {enrollments.length === 0 && <p>No enrollments found.</p>}

      <ul>
        {enrollments.map(e => (
          <li key={e.id}>
            Student #{e.studentId} enrolled in Course #{e.courseId}
          </li>
        ))}
      </ul>
    </div>
  );
}