import { useEffect, useState } from "react";
import { getEnrollments, updateEnrollment, deleteEnrollment } from "../api";
import CreateEnrollmentForm from "./CreateEnrollmentForm";

export default function EnrollmentsList() {
  const [enrollments, setEnrollments] = useState([]);
  const [editing, setEditing] = useState(null);

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

  async function handleDelete(id) {
    const ok = await deleteEnrollment(id);
    if (ok) {
      setEnrollments(prev => prev.filter(e => e.id !== id));
    }
  }

  return (
    <div className="section enrollments">
      <h2>Enrollments</h2>

      <CreateEnrollmentForm onCreated={handleEnrollmentCreated} />

      {editing && (
        <form
          onSubmit={async e => {
            e.preventDefault();
            const updated = await updateEnrollment(editing.id, editing);
            if (updated) {
              setEnrollments(prev =>
                prev.map(e => (e.id === updated.id ? updated : e))
              );
              setEditing(null);
            }
          }}
        >
          <input
            type="number"
            value={editing.studentId}
            onChange={e => setEditing({ ...editing, studentId: Number(e.target.value) })}
          />
          <input
            type="number"
            value={editing.courseId}
            onChange={e => setEditing({ ...editing, courseId: Number(e.target.value) })}
          />

          <button type="submit" className="save">Save</button>
          <button type="button" className="cancel" onClick={() => setEditing(null)}>
            Cancel
          </button>
        </form>
      )}

      <ul>
        {enrollments.map(e => (
          <li key={e.id}>
            Student #{e.studentId} enrolled in Course #{e.courseId}

            <button className="edit" onClick={() => setEditing(e)}>Edit</button>
            <button className="delete" onClick={() => handleDelete(e.id)}>Delete</button>
          </li>
        ))}
      </ul>
    </div>
  );
}
