import { useEffect, useState } from "react";
import { getProfiles, updateProfile, deleteProfile } from "../api";
import CreateProfileForm from "./CreateProfileForm";

export default function ProfilesList() {
  const [profiles, setProfiles] = useState([]);
  const [editing, setEditing] = useState(null);

  useEffect(() => {
    async function load() {
      const data = await getProfiles();
      setProfiles(data);
    }
    load();
  }, []);

  function handleProfileCreated(profile) {
    setProfiles(prev => [...prev, profile]);
  }

  async function handleDelete(id) {
    const ok = await deleteProfile(id);
    if (ok) {
      setProfiles(prev => prev.filter(p => p.id !== id));
    }
  }

  return (
    <div className="section profiles">
      <h2>Profiles</h2>

      <CreateProfileForm onCreated={handleProfileCreated} />

      {editing && (
        <form
          onSubmit={async e => {
            e.preventDefault();
            const updated = await updateProfile(editing.id, editing);
            if (updated) {
              setProfiles(prev =>
                prev.map(p => (p.id === updated.id ? updated : p))
              );
              setEditing(null);
            }
          }}
        >
          <input
            type="text"
            value={editing.address}
            onChange={e => setEditing({ ...editing, address: e.target.value })}
          />
          <input
            type="text"
            value={editing.phone}
            onChange={e => setEditing({ ...editing, phone: e.target.value })}
          />
          <input
            type="number"
            value={editing.studentId}
            onChange={e => setEditing({ ...editing, studentId: Number(e.target.value) })}
          />

          <button type="submit" className="save">Save</button>
          <button type="button" className="cancel" onClick={() => setEditing(null)}>
            Cancel
          </button>
        </form>
      )}

      <ul>
        {profiles.map(p => (
          <li key={p.id}>
            {p.address} — {p.phone} (Student #{p.studentId})

            <button className="edit" onClick={() => setEditing(p)}>Edit</button>
            <button className="delete" onClick={() => handleDelete(p.id)}>Delete</button>
          </li>
        ))}
      </ul>
    </div>
  );
}
