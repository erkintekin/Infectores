import React, { useState, useEffect } from "react";
import {
  addCharacter,
  fetchCharacter,
  editCharacter,
  deleteCharacter,
} from "../APIs/characterAPI";
import { fetchItems } from "../APIs/itemAPI";

function characterManagement() {
  const [newCharacter, setNewCharacter] = useState({ age: "", nickname: "" }); // Formdaki tüm proplar gelmeli
  const [characters, setCharacters] = useState([]); // Tüm karakterler
  const [inventory, setInventory] = useState({});
  const [items, setItems] = useState([]);
  const [inventoryLoading, setInventoryLoading] = useState(false);
  const [inventoryError, setInventoryError] = useState("");
  const [showInventoryModal, setShowInventoryModal] = useState(false);

  // Giriş yapan kullanıcının userId'sini almak için JWT decoding
  const currentUserId = localStorage.getItem("userId"); // Backend'den gelen userId için

  // Editing ve add işlemleri için
  const [isEditing, setIsEditing] = useState(false);
  const [characterId, setCharacterId] = useState(null);

  // Backendten karakterleri fetchleme
  useEffect(() => {
    const getCharacters = async () => {
      try {
        const data = await fetchCharacter();
        setCharacters(data); // Tüm karakterler setlendi
      } catch (err) {
        console.log(err.message);
      }
    };
    getCharacters();
  }, []);

  const handleAddCharacter = async () => {
    try {
      const addedCharacter = await addCharacter(newCharacter);
      setCharacters([...characters, addedCharacter]);
      setNewCharacter({ age: "", nickname: "" }); // State ve form resetting
    } catch (err) {
      console.log(err.message);
    }
  };

  const handleEditCharacter = async (character) => {
    // State doldurma
    setNewCharacter(character);
    setIsEditing(true);
    setCharacterId(character.id);
  };

  const handleSaveEdit = async () => {
    try {
      const updatedCharacter = await editCharacter({
        id: characterId, // State'den gelen editlenecek karakter id'si
        ...newCharacter, // Formdan alınan character bilgileri
      });

      setCharacters([
        characters.map((character) =>
          character.id === updatedCharacter.id ? updatedCharacter : character
        ),
      ]); // Listeyi güncelleme

      // Statleri ve formu sıfırlama
      setNewCharacter({ age: "", nickname: "" }); //proplar eklenecek
      setIsEditing(false);
      setCharacterId(null);
    } catch (err) {
      console.log(err.message);
    }
  };

  const handleDeleteCharacter = async (id) => {
    try {
      await deleteCharacter({ id });
      setCharacters(characters.filter((char) => char.id !== id));
    } catch (err) {
      console.log(err.message);
    }
  };

  const handleFetchInventory = async (id) => {
    setInventoryLoading(true);
    setInventoryError("");
    try {
      const data = await fetchItems({ id });
      setInventory(data);
      setShowInventoryModal(true);
    } catch (err) {
      console.log(err.message);
    } finally {
      setInventoryLoading(false);
    }
  };

  const handleCloseModal = () => {
    setShowInventoryModal(false);
    setInventory([]);
  };
  return (
    <div>
      <h1>Character CRUD Page</h1>

      <ul>
        {characters.map((character) => (
          <li key={character.id}>
            {character.nickname} (Age: {character.age})
            <button onClick={() => handleEditCharacter(character)}>Edit</button>
            <button onClick={() => handleDeleteCharacter(character.id)}>
              Delete
            </button>
            {/* <button onClick={() => }></button> */}
          </li>
        ))}
      </ul>

      <div>
        <h2>{isEditing ? "Edit Character" : "Add Character"}</h2>
        <input
          type="text"
          placeholder="Nickname"
          value={newCharacter.nickname}
          onChange={(e) =>
            setNewCharacter({ ...newCharacter, nickname: e.target.value })
          }
        />
        <input
          type="text"
          placeholder="Age"
          value={newCharacter.age}
          onChange={(e) =>
            setNewCharacter({ ...newCharacter, age: e.target.value })
          }
        />
        {isEditing ? (
          <button onClick={handleSaveEdit}>Save Changes</button>
        ) : (
          <button onClick={handleAddCharacter}>Add Character</button>
        )}
      </div>
    </div>
  );
}

export default characterManagement;
