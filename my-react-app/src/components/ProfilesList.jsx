import { useEffect, useState } from "react";
import { getProfiles } from "../api";

export default function ProfilesList() {
  const [profiles, setProfiles] = useState([]);

  useEffect(() => {
    async function load() {
      const data = await getProfiles();
      console.log("Profiles from API:", data);
      setProfiles(data);
    }
    load();
  }, []);

  return (
    <div>
      <h2>Profiles</h2>

      {profiles.length === 0 && <p>No profiles found.</p>}

      <ul>
        {profiles.map(p => (
          <li key={p.id}>
            {p.address} — {p.phone}
          </li>
        ))}
      </ul>
    </div>
  );
}