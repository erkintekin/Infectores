import React, { useState, useEffect } from "react";
import { editCharacter } from "../APIs/characterAPI"; // updateCharacter API fonksiyonu

function EditCharacterModal({ character, onClose }) {
  const [formData, setFormData] = useState({
    nickname: character.nickname,
    age: character.age,
  });

  useEffect(() => {
    setFormData({
      nickname: character.nickname,
      age: character.age,
    });
  }, [character]);

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const updatedCharacter = {
        id: character.id, // id de karakterle birlikte gönderilmeli
        ...formData, // form verilerini birleştirdim
      };
      await editCharacter(updatedCharacter); // API fonksiyonu ile karakter güncellendi
      onClose(); // Modalı kapat
    } catch (err) {
      console.log(err.message);
    }
  };

  return (
    <div className="modal">
      <h2>Edit Character</h2>
      <form onSubmit={handleSubmit}>
        <div>
          <label>Nickname:</label>
          <input
            type="text"
            name="nickname"
            value={formData.nickname}
            onChange={handleInputChange}
            required
          />
        </div>
        <div>
          <label>Age:</label>
          <input
            type="number"
            name="age"
            value={formData.age}
            onChange={handleInputChange}
            required
          />
        </div>
        <button type="submit">Save</button>
        <button type="button" onClick={onClose}>
          Cancel
        </button>
      </form>
    </div>
  );
}

export default EditCharacterModal;
