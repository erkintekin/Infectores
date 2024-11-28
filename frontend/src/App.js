import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import logo from "./logo.svg";
import "./App.css";

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header>
    </div>
  );
}

{
  /* <Router>
<Routes>
  <Route path="/" element={<Login />} />
  <Route path="/admin/dashboard" element={<AdminDashboard />} />
  <Route path="/user/dashboard" element={<UserDashboard />} />
</Routes>
</Router> */
}

export default App;
