import './App.css';
import {  Routes, Route, Link} from "react-router-dom";
import Login from "./pages/Login";
import Registration from "./pages/Registration";

function App() {
  return (
    <div className="App">
      <header>
        <p>Главная</p>
        <Link to="/login">Вход</Link>
        <Link to="/register">Регистрация</Link>
      </header>
      <Routes>
        <Route path="/login" element={<Login/>}/>
        <Route path="/register" element={<Registration/>}/>
      </Routes>
    </div>
  );
}

export default App;
