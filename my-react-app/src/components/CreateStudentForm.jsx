import { useState } from "react";
import { createStudent } from "../api";

export default function CreateStudentForm({ onCreated }) {
  const [name, setName] = useState("");
  const [email, setEmail] = useState("");

  async function handleSubmit(e) {
    e.preventDefault();

    const newStudent = await createStudent({ name, email });

    if (newStudent) {
      onCreated(newStudent);
      setName("");
      setEmail("");
    }
  }

  return (
    <form onSubmit={handleSubmit}>
      <h3>Create Student</h3>

      <input
        type="text"
        placeholder="Name"
        value={name}
        onChange={e => setName(e.target.value)}
      />

      <input
        type="email"
        placeholder="Email"
        value={email}
        onChange={e => setEmail(e.target.value)}
      />

      <button type="submit">Add Student</button>
    </form>
  );
}