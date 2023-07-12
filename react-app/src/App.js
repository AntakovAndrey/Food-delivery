import './App.css';
import {  Routes, Route} from "react-router-dom";
import Login from "./pages/Login/Login";
import Registration from "./pages/Registration";
import Home from './pages/Home';

import Dishes from './pages/Dishes';
import React from 'react';
import AddingFoodPage from './pages/AddingFood/AddingFood';
import AdminMenu from './pages/Admin/AdminMenu';
import Cart from './pages/Cart/Cart';
import CurrentOrders from './pages/RestaurantAdmin/Orders/CurrentOrders/CurrentOrders';
import Orders from './pages/Orders/Orders';
import DeliveryOrders from './pages/DeliveryOrders/DeliveryOrders'

function App() {
  return (
    <div className="App">
      <Routes>
        <Route path="/" element={<Home/>}/>
        <Route path="/login" element={<Login/>}/>
        <Route path="/register" element={<Registration/>}/>
        <Route path="/orders" element={<Orders/>}/>
        <Route path="/addFood" element={<AddingFoodPage/>}/>
        <Route path="/adminMenu" element={<AdminMenu/>}/>
        <Route path="/cart" element={<Cart/>} />
        <Route path="/restaurant/:id" element={<Dishes/>} />
        <Route path="/currentOrders" element={<CurrentOrders/>} />
        <Route path="/deliveryOrders" element={<DeliveryOrders/>} />
      </Routes>
    </div>
  );
}

export default App;