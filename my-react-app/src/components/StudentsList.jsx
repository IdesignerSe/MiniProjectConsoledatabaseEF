import { useEffect, useState } from "react";
import { getStudents } from "../api";

export default function StudentsList() {
  const [students, setStudents] = useState([]);

  useEffect(() => {
    async function load() {
      const data = await getStudents();
      setStudents(data);
    }
    load();
  }, []);

  return (
    <div>
      <h2>Students</h2>
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