import { useState } from "react";
import { createProfile } from "../api";

export default function CreateProfileForm({ onCreated }) {
  const [address, setAddress] = useState("");
  const [phone, setPhone] = useState("");
  const [studentId, setStudentId] = useState("");

  async function handleSubmit(e) {
    e.preventDefault();

    const newProfile = await createProfile({
      address,
      phone,
      studentId: Number(studentId)
    });

    if (newProfile) {
      onCreated(newProfile);
      setAddress("");
      setPhone("");
      setStudentId("");
    }
  }

  return (
    <form onSubmit={handleSubmit}>
      <h3>Create Profile</h3>

      <input
        type="text"
        placeholder="Address"
        value={address}
        onChange={e => setAddress(e.target.value)}
      />

      <input
        type="text"
        placeholder="Phone"
        value={phone}
        onChange={e => setPhone(e.target.value)}
      />

      <input
        type="number"
        placeholder="Student ID"
        value={studentId}
        onChange={e => setStudentId(e.target.value)}
      />

      <button type="submit">Add Profile</button>
    </form>
  );
}