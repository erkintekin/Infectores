import React, { useState, useEffect } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { ClipLoader } from "react-spinners/ClipLoader";
import { fetchCharacter } from "../APIs/characterAPI";

function CharacterView() {
  const { id } = useParams(); // URL'den karakter ID'sini al
  const [character, setCharacter] = useState(null);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(null);
  const navigate = useNavigate();

  useEffect(() => {
    const getCharacter = async () => {
      try {
        setLoading(true);
        setError(null);
        const data = await fetchCharacter(id); // API'den belirli karakteri al
        setCharacter(data);
      } catch (err) {
        setError("Failed to fetch character data!"); // Hata mesajı
      } finally {
        setLoading(false);
      }
    };
    getCharacter();
  }, [id]);

  if (loading) {
    return (
      <div>
        <ClipLoader loading={loading} size={50} />
        <p>Loading...</p>
      </div>
    );
  }

  if (error) {
    return <p>{error}</p>;
  }

  if (!character) {
    return <p>No character found with given ID</p>;
  }

  return (
    <div>
      <h1>Character Details</h1>
      <p>
        <strong>Nickname:</strong> {character.nickname}
      </p>
      <p>
        <strong>Age:</strong> {character.age}
      </p>
      <p>
        <strong>Dexterity:</strong> {character.dexterity}
      </p>
      <p>
        <strong>Intelligence:</strong> {character.intelligence}
      </p>
      <p>
        <strong>Strength:</strong> {character.strength}
      </p>
      <p>
        <strong>Wisdom:</strong> {character.wisdom}
      </p>
      <button onClick={() => navigate("/campaign")}>Back to Campaign</button>
    </div>
  );
}

export default CharacterView;
