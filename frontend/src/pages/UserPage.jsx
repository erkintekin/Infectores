import React, { useState, useEffect } from "react";
import {
  addCharacter,
  fetchCharacter,
  editCharacter,
  deleteCharacter,
} from "../APIs/characterAPI";

function characterManagement() {
  const [newCharacter, setNewCharacter] = useState({ age: "", name: "" }); // Formdaki tüm proplar gelmeli
  const [characters, setCharacters] = useState([]); // Tüm karakterler

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
  }, []);

  const handleAddCharacter = async () => {
    try {
      const addedCharacter = await addCharacter(newCharacter);
      setCharacters([...characters, addedCharacter]);
      setNewCharacter({ age: "", name: "" }); // State ve form resetting
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
      setNewCharacter({ age: "", name: "" }); //proplar eklenecek
      setIsEditing(false);
      setCharacterId(null);
    } catch (err) {
      console.log(err.message);
    }
  };
}
