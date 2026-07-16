import { useEffect, useState } from "react";
import { getStudents, updateStudent, deleteStudent } from "../api";
import CreateStudentForm from "./CreateStudentForm";

export default function StudentsList() {
  const [students, setStudents] = useState([]);
  const [editing, setEditing] = useState(null);

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

  async function handleDelete(id) {
    const ok = await deleteStudent(id);
    if (ok) {
      setStudents(prev => prev.filter(s => s.id !== id));
    }
  }

  return (
    <div className="section students">
      <h2>Students</h2>

      <CreateStudentForm onCreated={handleStudentCreated} />

      {editing && (
        <form
          onSubmit={async e => {
            e.preventDefault();
            const updated = await updateStudent(editing.id, editing);
            if (updated) {
              setStudents(prev =>
                prev.map(s => (s.id === updated.id ? updated : s))
              );
              setEditing(null);
            }
          }}
        >
          <input
            type="text"
            value={editing.name}
            onChange={e => setEditing({ ...editing, name: e.target.value })}
          />
          <input
            type="email"
            value={editing.email}
            onChange={e => setEditing({ ...editing, email: e.target.value })}
          />

          {/* BOTONES CON CLASES */}
          <button type="submit" className="save">Save</button>
          <button type="button" className="cancel" onClick={() => setEditing(null)}>Cancel</button>
        </form>
      )}

      <ul>
        {students.map(s => (
          <li key={s.id}>
            {s.name} — {s.email}

            {/* BOTONES CON CLASES */}
            <button className="edit" onClick={() => setEditing(s)}>Edit</button>
            <button className="delete" onClick={() => handleDelete(s.id)}>Delete</button>
          </li>
        ))}
      </ul>
    </div>
  );
}
