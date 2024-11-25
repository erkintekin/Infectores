import axios from "axios";

const API_URL = "/character"; // Backend URL - Controller based

export const fetchCharacter = async () => {
  try {
    const response = await axios.get(API_URL);
    return response.data; // Axios hata durumunda otomatik olarak catch bloğuna düşer
  } catch (err) {
    throw new Error(
      err.response?.data?.message || "Character cannot be fetched!"
    );
  }
};

export const addCharacter = async (character) => {
  try {
    const response = await axios.post(API_URL, character);
    return response.data;
  } catch (err) {
    throw new Error(
      err.response?.data?.message || "Character cannot be added!"
    );
  }
};

export const editCharacter = async (character) => {
  try {
    const response = await axios.put(`${API_URL}/${character.id}`, character);
    return response.data;
  } catch (err) {
    throw new Error(
      err.response?.data?.message || "Character cannot be updated!"
    );
  }
};

export const deleteCharacter = async (id) => {
  try {
    const response = await axios.delete(`${API_URL}/${id}`);
    return response.data; // DELETE genelde 204 döner, ancak data ile yanıt geliyorsa kullanılabilir
  } catch (err) {
    throw new Error(
      err.response?.data?.message || "Character cannot be deleted!"
    );
  }
};
