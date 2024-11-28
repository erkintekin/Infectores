import axios from "axios";

const API_URL = "/inventory"; // Backend URL - Controller based

export const fetchItems = async (characterId) => {
  try {
    const response = await axios.get(`${API_URL}/${characterId}`);
    return response.data;
  } catch (err) {
    throw new Error(err.response?.data?.message || "Items can not fetched");
  }
};

export const addItems = async (item) => {
  try {
    const response = await axios.post(API_URL, item); // , {headers: { Authorization: `Bearer ${token}` },  //JWT
    return response.data;
  } catch (err) {
    throw new Error(err.response?.data?.message || "Item can not added");
  }
};

export const deleteItems = async (itemId) => {
  try {
    const response = await axios.delete(`${API_URL}/${itemId}`);
    return response.data;
  } catch (err) {
    throw new Error(err.response?.data?.message || "Item can not deleted");
  }
};

export const editItems = async (item) => {
  try {
    const response = await axios.put(`${API_URL}/${item.id}`, item);
    return response.data;
  } catch (err) {
    throw new Error(err.response?.data?.message || "Item is not editable");
  }
};
