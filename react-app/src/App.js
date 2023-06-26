import './App.css';
import {  Routes, Route} from "react-router-dom";
import Login from "./pages/Login";
import Registration from "./pages/Registration";
import Home from './pages/Home';
import Order from './pages/Order';
import Dishes from './pages/Dishes';
import React from 'react';
import AddingFoodPage from './pages/AddingFood/AddingFood';
import AdminMenu from './pages/Admin/AdminMenu';

function App() {
  return (
    <div className="App">
      <Routes>
        <Route path="/" element={<Home/>}/>
        <Route path="/login" element={<Login/>}/>
        <Route path="/register" element={<Registration/>}/>
        <Route path="/order" element={<Order/>}/>
        <Route path="/addFood" element={<AddingFoodPage/>}/>
        <Route path="/adminMenu" element={<AdminMenu/>}/>
        <Route path="/restaurant/:id" element={<Dishes/>} />
      </Routes>
    </div>
  );
}

export default App;