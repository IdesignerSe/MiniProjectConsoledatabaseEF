import { useState } from "react";
import { createCourse } from "../api";

export default function CreateCourseForm({ onCreated }) {
  const [title, setTitle] = useState("");
  const [credits, setCredits] = useState("");

  async function handleSubmit(e) {
    e.preventDefault();

    const newCourse = await createCourse({
      title,
      credits: Number(credits)
    });

    if (newCourse) {
      onCreated(newCourse);
      setTitle("");
      setCredits("");
    }
  }

  return (
    <form onSubmit={handleSubmit}>
      <h3>Create Course</h3>

      <input
        type="text"
        placeholder="Course title"
        value={title}
        onChange={e => setTitle(e.target.value)}
      />

      <input
        type="number"
        placeholder="Credits"
        value={credits}
        onChange={e => setCredits(e.target.value)}
      />

      <button type="submit">Add Course</button>
    </form>
  );
}
