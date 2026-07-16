import { useState } from "react";
import { createEnrollment } from "../api";

export default function CreateEnrollmentForm({ onCreated }) {
  const [studentId, setStudentId] = useState("");
  const [courseId, setCourseId] = useState("");

  async function handleSubmit(e) {
    e.preventDefault();

    const newEnrollment = await createEnrollment({
      studentId: Number(studentId),
      courseId: Number(courseId)
    });

    if (newEnrollment) {
      onCreated(newEnrollment);
      setStudentId("");
      setCourseId("");
    }
  }

  return (
    <form onSubmit={handleSubmit}>
      <h3>Create Enrollment</h3>

      <input
        type="number"
        placeholder="Student ID"
        value={studentId}
        onChange={e => setStudentId(e.target.value)}
      />

      <input
        type="number"
        placeholder="Course ID"
        value={courseId}
        onChange={e => setCourseId(e.target.value)}
      />

      <button type="submit">Add Enrollment</button>
    </form>
  );
}