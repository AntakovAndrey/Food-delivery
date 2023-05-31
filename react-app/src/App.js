import './App.css';
import {  Routes, Route} from "react-router-dom";
import Login from "./pages/Login";
import Registration from "./pages/Registration";
import Home from './pages/Home';
import Order from './pages/Order';
import React from 'react';

function App() {
  return (
    <div className="App">
      <Routes>
        <Route path="/" element={<Home/>}/>
        <Route path="/login" element={<Login/>}/>
        <Route path="/register" element={<Registration/>}/>
        <Route path="/order" element={<Order/>}/>
      </Routes>
    </div>
  );
}

export default App;