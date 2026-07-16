import { useEffect, useState } from "react";
import { getStudents } from "../api";
import CreateStudentForm from "./CreateStudentForm";

export default function StudentsList() {
  const [students, setStudents] = useState([]);

  useEffect(() => {
    async function load() {
      const data = await getStudents();
      setStudents(data);
    }
    load();
  }, []);

  function handleStudentCreated(student) {
    setStudents(prev => [...prev, student]);
  }

  return (
    <div className="section students">
      <h2>Students</h2>

      <CreateStudentForm onCreated={handleStudentCreated} />

      <ul>
        {students.map(s => (
          <li key={s.id}>
            {s.name} — {s.email}
          </li>
        ))}
      </ul>
    </div>
  );
}