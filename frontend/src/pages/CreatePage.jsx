import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { addCharacter, fetchClasses } from "../APIs/characterAPI"; // updateCharacter API fonksiyonu

function NewCharacter() {
  const [newCharacter, setNewCharacter] = useState({
    age: "",
    nickname: "",
    class: "",
    abilities: {
      strength: 10,
      dexterity: 10,
      constitution: 10,
      intelligence: 10,
      wisdom: 10,
      charisma: 10,
    },
  });

  const [classes, setClasses] = useState([]);
  const navigate = useNavigate();

  useEffect(() => {
    const getClasses = async () => {
      try {
        const data = await fetchClasses(); // Sınıfları getiren API fonksiyonunu çağırma
        setClasses(data);
      } catch (err) {
        console.log(err.message);
      }
    };
    getClasses();
  }, []);

  const handleInputChange = (e) => {
    const { name, value } = e.target;

    if (name.includes("abilities")) {
      // Str, Dex, Int vb.
      const stat = name.split(".")[1];
      setNewCharacter((prevState) => ({
        ...prevState,
        abilities: {
          ...prevState.abilities,
          [stat]: Number(value),
        },
      }));
    } else {
      setNewCharacter((prevState) => ({
        // Age, Nickname vb.
        ...prevState,
        [name]: value,
      }));
    }
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      await addCharacter(newCharacter);
      navigate("/campaign"); // Başarılı olursa yönlendir
    } catch (err) {
      console.log(err.message);
    }
  };

  return (
    <div className="modal">
      <h2>Create New Character</h2>
      <form onSubmit={handleSubmit}>
        <div>
          <label>Nickname:</label>
          <input
            type="text"
            name="nickname"
            value={newCharacter.nickname}
            onChange={handleInputChange}
            required
          />
        </div>
        <div>
          <label>Age:</label>
          <input
            type="number"
            name="age"
            value={newCharacter.age}
            onChange={handleInputChange}
            required
          />
        </div>
        <div>
          <label>Class:</label>
          <select
            name="class"
            value={newCharacter.class}
            onChange={handleInputChange}
            required
          >
            <option value="">Select a class</option>
            {classes.map((cls) => (
              <option key={cls} value={cls}>
                {cls}
              </option>
            ))}
          </select>
        </div>
        <div>
          <h4>Abilities</h4>
          {Object.keys(newCharacter.abilities).map((stat) => (
            <div key={stat}>
              <label>{stat.charAt(0).toUpperCase() + stat.slice(1)}:</label>
              <input
                type="number"
                name={`abilities.${stat}`}
                value={newCharacter.abilities[stat]}
                onChange={handleInputChange}
                min="1"
                max="20"
              />
            </div>
          ))}
        </div>
        <button type="submit">Create Character</button>
      </form>
    </div>
  );
}

export default NewCharacter;
