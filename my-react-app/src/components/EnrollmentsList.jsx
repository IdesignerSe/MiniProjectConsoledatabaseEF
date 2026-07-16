import { useEffect, useState } from "react";
import { getEnrollments } from "../api";
import CreateEnrollmentForm from "./CreateEnrollmentForm";

export default function EnrollmentsList() {
  const [enrollments, setEnrollments] = useState([]);

  useEffect(() => {
    async function load() {
      const data = await getEnrollments();
      setEnrollments(data);
    }
    load();
  }, []);

  function handleEnrollmentCreated(enrollment) {
    setEnrollments(prev => [...prev, enrollment]);
  }

  return (
    <div>
      <h2>Enrollments</h2>

      <CreateEnrollmentForm onCreated={handleEnrollmentCreated} />

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