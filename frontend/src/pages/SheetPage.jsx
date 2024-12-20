import React, { useState, useEffect } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { ClipLoader } from "react-spinners/ClipLoader";
import { editCharacter, fetchCharacter } from "../APIs/characterAPI";

function CharacterView() {
  const { id } = useParams(); // URL'den karakter ID'sini al
  const [character, setCharacter] = useState(null);
  const [hp, setHp] = useState(character?.hp);
  const [hpInput, setHpInput] = useState(null);
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
        setHp(data.hp);
      } catch (err) {
        setError("Failed to fetch character data!"); // Hata mesajı
      } finally {
        setLoading(false);
      }
    };
    getCharacter();
  }, [id]);

  useEffect(() => {
    const updateHP = async () => {
      try {
        setLoading(true);
        setError(null);
        const updatedHP = { id: id, hp: hp };
        const newCharacter = await editCharacter(updatedHP); // if (character.HP.HasValue) kısmı backend'e eklenmeli, sadece HP put işlemine girecek
        setCharacter(newCharacter);
        setHp(newCharacter.hp);
      } catch (err) {
        setError("Failed to fetch character HP!");
      } finally {
        setLoading(false);
      }
    };
    if (hp !== null) {
      updateHP();
    }
  }, [newHP, id]);

  // Leveling işlemleri yapılacak

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

  const handleHeal = () => {
    const healAmount = parseInt(hpInput, 10);
    if (isNaN(healAmount) || healAmount <= 0) return;

    setHp((prevHP) => Math.min(prevHP + healAmount, character.maxHP));
  };

  const handleDamage = () => {
    const damageAmount = parseInt(hpInput, 10);
    if (isNaN(damageAmount) || damageAmount <= 0) return;

    setHp((prevHP) => Math.max(prevHP - damageAmount, 0));
  };

  const handleRest = (selection) => {
    if (selection === "short") {
      setHp(character.maxHP);
    } else {
      setHp(character.maxHP);
      setSpellSlot(character.SlotCount);
    }
  };

  return (
    <div>
      <h1>Character Details</h1>
      <p>
        <strong>Nickname:</strong> {character.nickname}
      </p>
      <p>
        <strong>HP:</strong> {character.hp}
      </p>
      <p>
        <strong>Max HP:</strong> {character.maxHP}
      </p>
      <p>
        <strong>Age:</strong> {character.age}
      </p>

      {/* Stats */}
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
      <p>
        <strong>Armor Class:</strong> {character.armorClass}
      </p>
      <p>
        <strong>Initiative</strong> {character.initiative}
      </p>

      {/* Equipments */}
      <p>
        <strong>Armor:</strong> {character.armor}
      </p>
      <p>
        <strong>Weapons:</strong>
        {character.weapon.map((weapon) => (
          <li key={weapon.id}>{weapon.name}</li>
        ))}
      </p>

      {/* Senses */}

      <p>
        <strong>Passive Perception:</strong> {character.passivePerception}
      </p>
      <p>
        <strong>Passive Investigation:</strong> {character.passiveInvestigation}
      </p>
      <p>
        <strong>Passive Insight:</strong> {character.passiveInsight}
      </p>
      <p>
        <strong>Dark Vision:</strong> {character.darkVision}
      </p>

      <button onClick={handleDamage}>Damage</button>
      <input type="number" onChange={(e) => setHpInput(e.target.value)} />
      {/* Girilen inputa göre heal veya damage atılacak */}
      <button onClick={handleHeal}>Heal</button>
      <button onClick={() => handleRest("short")}>Short Rest</button>
      <button onClick={() => handleRest("long")}>Long Rest</button>
      <button onClick={() => navigate("/campaign")}>Back to Campaign</button>
    </div>
  );
}

export default CharacterView;
