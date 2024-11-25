import axios from "axios";

const API_URL = "backend-url"; // Buraya back-end URL gelecek

export const login = async (mail, password) => {
  try {
    const response = await axios.post(`${API_URL}/login`, { mail, password });

    return response.data;
  } catch (err) {
    throw new Error(err.response?.data?.message || "Login failed!");
  }
};
