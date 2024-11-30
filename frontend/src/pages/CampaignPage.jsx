import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { fetchCharacter, deleteCharacter } from "../APIs/characterAPI";
import EditCharacterModal from "./EditCharacterModal"; // Edit modal component

function CampaignPage() {
  const [characters, setCharacters] = useState([]); // Tüm karakterler
  const [isModalOpen, setIsModalOpen] = useState(false); // Modal kontrolü
  const [characterToEdit, setCharacterToEdit] = useState(null); // Düzenlenecek karakter verisi
  const navigate = useNavigate();

  // Giriş yapan kullanıcının userId'sini almak için JWT decoding
  const currentUserId = localStorage.getItem("userId"); // Backend'den gelen userId için

  // Backend'den karakterleri fetch et
  useEffect(() => {
    const getCharacters = async () => {
      try {
        const data = await fetchCharacter();
        setCharacters(data); // Tüm karakterler state'e setleniyor
      } catch (err) {
        console.log(err.message);
      }
    };
    getCharacters();
  }, []);

  const handleDeleteCharacter = async (id) => {
    try {
      await deleteCharacter({ id });
      setCharacters(characters.filter((char) => char.id !== id));
    } catch (err) {
      console.log(err.message);
    }
  };

  const handleViewCharacter = (id) => {
    navigate(`/character-sheet/${id}`); // Karakter detay sayfasına yönlendirme
  };

  const handleEditCharacter = (character) => {
    setCharacterToEdit(character); // Düzenlenecek karakteri setleme
    setIsModalOpen(true); // Modalı açma
  };

  const handleCloseModal = () => {
    setIsModalOpen(false);
    setCharacterToEdit(null); // Modal kapandığında karakter verisini sıfırlama
  };

  return (
    <div>
      <h1>Campaign Page</h1>
      <button onClick={() => navigate("/new-character")}>Add Character</button>
      <ul>
        {characters.map((character) => (
          <li key={character.id}>
            {character.nickname} (Age: {character.age})
            <button onClick={() => handleViewCharacter(character.id)}>
              View
            </button>
            <button onClick={() => handleEditCharacter(character)}>Edit</button>
            <button onClick={() => handleDeleteCharacter(character.id)}>
              Delete
            </button>
          </li>
        ))}
      </ul>

      {/* Modal */}
      {isModalOpen && (
        <EditCharacterModal
          character={characterToEdit}
          onClose={handleCloseModal}
        />
      )}
    </div>
  );
}

export default CampaignPage;
