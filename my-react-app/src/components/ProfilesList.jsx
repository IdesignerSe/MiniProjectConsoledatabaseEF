import { useEffect, useState } from "react";
import { getProfiles } from "../api";
import CreateProfileForm from "./CreateProfileForm";

export default function ProfilesList() {
  const [profiles, setProfiles] = useState([]);

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

  return (
    <div className="section profiles">
      <h2>Profiles</h2>

      <CreateProfileForm onCreated={handleProfileCreated} />

      <ul>
        {profiles.map(p => (
          <li key={p.id}>
            {p.address} — {p.phone} (Student #{p.studentId})
          </li>
        ))}
      </ul>
    </div>
  );
}
