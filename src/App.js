
import React, { useState, useEffect } from "react";
import "./App.css";

function App() {

  const [weather, setWeather] = useState({});
  const [locations, setLocations] = useState("");
  const [datahidden, setDatahidden] = useState(true);

  function ifClicked() {
    fetch(
      `https://localhost:7221/weatherforecast?city=${locations}`
    )
      .then((res) => {
        if (res.ok) {
          console.log(res.status);
          return res.json();
        } else {
          if (res.status === 404) {
            return alert("Oops, there seems to be an error!(wrong location)");
          }
          alert("Oops, there seems to be an error!");
          throw new Error("You have an error");
        }
      })
      .then((object) => {
        setWeather(object);
        console.log(weather);
        setDatahidden(false);
        console.log("data is releaved!")
      })
      .catch((error) => console.log(error));
  }

  return (
    <div className="app">
      <div className="wrapper">
        <div className="search">
          <input
            type="text"
            value={locations}
            onChange={(e) => setLocations(e.target.value)}
            placeholder="Enter location"
            className="location_input"
          />
          <button className="location_searcher" onClick={ifClicked}>
            Search Location
          </button>
        </div>
          <div className="app__data" hidden={datahidden}>
            <p className="temp">City: {weather?.city}</p>
            <p className="temp">Region: {weather?.region}</p>
            <p className="temp">Country: {weather?.country}</p>
            <p className="temp">Local Time: {weather?.localTime}</p>
            <p className="temp">Temparature: {weather?.temperature}</p>
            <p className="temp">Sunrise: {weather?.sunrise}</p>
            <p className="temp">Sunset: {weather?.sunset}</p>
          </div>
      </div>
    </div>
  );
}

export default App;