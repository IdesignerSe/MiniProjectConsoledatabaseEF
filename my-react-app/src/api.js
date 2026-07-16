const API_BASE = "http://localhost:5104/api";

export async function getStudents() {
  try {
    const response = await fetch(`${API_BASE}/students`);
    if (!response.ok) throw new Error("Failed to fetch students");
    return await response.json();
  } catch (error) {
    console.error("API error:", error);
    return [];
  }
}

export async function getCourses() {
  try {
    const response = await fetch(`${API_BASE}/courses`);
    if (!response.ok) throw new Error("Failed to fetch courses");
    return await response.json();
  } catch (error) {
    console.error("API error:", error);
    return [];
  }
}

export async function getProfiles() {
  try {
    const response = await fetch(`${API_BASE}/profiles`);
    if (!response.ok) throw new Error("Failed to fetch profiles");
    return await response.json();
  } catch (error) {
    console.error("API error:", error);
    return [];
  }
}

export async function getEnrollments() {
  try {
    const response = await fetch(`${API_BASE}/enrollments`);
    if (!response.ok) throw new Error("Failed to fetch enrollments");
    return await response.json();
  } catch (error) {
    console.error("API error:", error);
    return [];
  }
}