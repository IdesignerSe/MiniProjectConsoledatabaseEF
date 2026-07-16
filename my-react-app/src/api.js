const API_BASE = "http://localhost:5104/api";

/* ============================================================
   STUDENTS
   ============================================================ */

// GET all students
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

// CREATE student
export async function createStudent(student) {
  try {
    const response = await fetch(`${API_BASE}/students`, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(student)
    });

    if (!response.ok) throw new Error("Failed to create student");
    return await response.json();
  } catch (error) {
    console.error("API error:", error);
    return null;
  }
}

// UPDATE student
export async function updateStudent(id, student) {
  try {
    const response = await fetch(`${API_BASE}/students/${id}`, {
      method: "PUT",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(student)
    });

    if (!response.ok) throw new Error("Failed to update student");
    return await response.json();
  } catch (error) {
    console.error("API error:", error);
    return null;
  }
}

// DELETE student
export async function deleteStudent(id) {
  try {
    const response = await fetch(`${API_BASE}/students/${id}`, {
      method: "DELETE"
    });

    if (!response.ok) throw new Error("Failed to delete student");
    return true;
  } catch (error) {
    console.error("API error:", error);
    return false;
  }
}


/* ============================================================
   COURSES
   ============================================================ */

// GET all courses
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

// CREATE course
export async function createCourse(course) {
  try {
    const response = await fetch(`${API_BASE}/courses`, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(course)
    });

    if (!response.ok) throw new Error("Failed to create course");
    return await response.json();
  } catch (error) {
    console.error("API error:", error);
    return null;
  }
}

// UPDATE course
export async function updateCourse(id, course) {
  try {
    const response = await fetch(`${API_BASE}/courses/${id}`, {
      method: "PUT",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(course)
    });

    if (!response.ok) throw new Error("Failed to update course");
    return await response.json();
  } catch (error) {
    console.error("API error:", error);
    return null;
  }
}

// DELETE course
export async function deleteCourse(id) {
  try {
    const response = await fetch(`${API_BASE}/courses/${id}`, {
      method: "DELETE"
    });

    if (!response.ok) throw new Error("Failed to delete course");
    return true;
  } catch (error) {
    console.error("API error:", error);
    return false;
  }
}


/* ============================================================
   PROFILES
   ============================================================ */

// GET all profiles
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

// CREATE profile
export async function createProfile(profile) {
  try {
    const response = await fetch(`${API_BASE}/profiles`, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(profile)
    });

    if (!response.ok) throw new Error("Failed to create profile");
    return await response.json();
  } catch (error) {
    console.error("API error:", error);
    return null;
  }
}

// UPDATE profile
export async function updateProfile(id, profile) {
  try {
    const response = await fetch(`${API_BASE}/profiles/${id}`, {
      method: "PUT",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(profile)
    });

    if (!response.ok) throw new Error("Failed to update profile");
    return await response.json();
  } catch (error) {
    console.error("API error:", error);
    return null;
  }
}

// DELETE profile
export async function deleteProfile(id) {
  try {
    const response = await fetch(`${API_BASE}/profiles/${id}`, {
      method: "DELETE"
    });

    if (!response.ok) throw new Error("Failed to delete profile");
    return true;
  } catch (error) {
    console.error("API error:", error);
    return false;
  }
}


/* ============================================================
   ENROLLMENTS
   ============================================================ */

// GET all enrollments
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

// CREATE enrollment
export async function createEnrollment(enrollment) {
  try {
    const response = await fetch(`${API_BASE}/enrollments`, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(enrollment)
    });

    if (!response.ok) throw new Error("Failed to create enrollment");
    return await response.json();
  } catch (error) {
    console.error("API error:", error);
    return null;
  }
}

// UPDATE enrollment
export async function updateEnrollment(id, enrollment) {
  try {
    const response = await fetch(`${API_BASE}/enrollments/${id}`, {
      method: "PUT",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(enrollment)
    });

    if (!response.ok) throw new Error("Failed to update enrollment");
    return await response.json();
  } catch (error) {
    console.error("API error:", error);
    return null;
  }
}

// DELETE enrollment
export async function deleteEnrollment(id) {
  try {
    const response = await fetch(`${API_BASE}/enrollments/${id}`, {
      method: "DELETE"
    });

    if (!response.ok) throw new Error("Failed to delete enrollment");
    return true;
  } catch (error) {
    console.error("API error:", error);
    return false;
  }
}