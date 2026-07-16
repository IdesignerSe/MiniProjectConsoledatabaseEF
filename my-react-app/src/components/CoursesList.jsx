import { useEffect, useState } from "react";
import { getCourses, updateCourse, deleteCourse } from "../api";
import CreateCourseForm from "./CreateCourseForm";

export default function CoursesList() {
  const [courses, setCourses] = useState([]);
  const [editing, setEditing] = useState(null);

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

  async function handleDelete(id) {
    const ok = await deleteCourse(id);
    if (ok) {
      setCourses(prev => prev.filter(c => c.id !== id));
    }
  }

  return (
    <div className="section courses">
      <h2>Courses</h2>

      <CreateCourseForm onCreated={handleCourseCreated} />

      {editing && (
        <form
          onSubmit={async e => {
            e.preventDefault();
            const updated = await updateCourse(editing.id, editing);
            if (updated) {
              setCourses(prev =>
                prev.map(c => (c.id === updated.id ? updated : c))
              );
              setEditing(null);
            }
          }}
        >
          <input
            type="text"
            value={editing.title}
            onChange={e => setEditing({ ...editing, title: e.target.value })}
          />
          <input
            type="number"
            value={editing.credits}
            onChange={e => setEditing({ ...editing, credits: Number(e.target.value) })}
          />

          <button type="submit" className="save">Save</button>
          <button type="button" className="cancel" onClick={() => setEditing(null)}>
            Cancel
          </button>
        </form>
      )}

      <ul>
        {courses.map(c => (
          <li key={c.id}>
            {c.title} — {c.credits} credits

            <button className="edit" onClick={() => setEditing(c)}>Edit</button>
            <button className="delete" onClick={() => handleDelete(c.id)}>Delete</button>
          </li>
        ))}
      </ul>
    </div>
  );
}
