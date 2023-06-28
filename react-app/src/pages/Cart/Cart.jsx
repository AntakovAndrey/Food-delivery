import Header from "../../components/Header/Header"
import { useNavigate } from "react-router-dom";
import React, { useState,useEffect } from "react"
import styles from "./Cart.module.css"
import { AddressAutofill } from '@mapbox/search-js-react';

function Cart()
{
    const[dishes,setDishes] = useState([]);
    const[address,setAddress] = useState([]);
    const[flat,setFlat] = useState([]);
    const navigate = useNavigate();

    const makeOrder = async (event)=>
    {
        event.preventDefault();
        const response = fetch('https://localhost:7123/Order/CreateOrder', {
          method:"POST",
          mode:"cors",
          headers: {
            'Content-Type': 'application/json'
          },      
          body: JSON.stringify({
            userID: localStorage.getItem("id"),
            address: address+' '+flat})
        });
        navigate("/")
    }

    function handleRemoveFromCart(id) {
        const response = fetch(`${process.env.REACT_APP_API_URL}/Cart/RemoveDishFromCart/${id}`, {
            method: 'DELETE',
            mode: "cors",
            headers: { 'Content-Type': 'application/json' }
        }).then(() => {
            setDishes(dishes.filter((item) => item.id !== id));
          });
    }

    useEffect(()=>{
        if (localStorage.getItem('cartId')) {
            const cartId =  localStorage.getItem('cartId');
            fetch(`${process.env.REACT_APP_API_URL}/Cart/GetCartDishesByCartId/${cartId}`, {mode:'cors'})
            .then(response => response.json())
            .then(data => setDishes(data));   
        }
        else{
            navigate("/login")
        }
    },[])
            
    const total = dishes.reduce((acc, item) => acc + item.dish.price, 0);
    
    if(dishes.length>0)
    {
    return(
        
        <>
        <Header title="Корзина"/>
        
        <div className={styles.container}>
            <form onSubmit={makeOrder}>
            <h2 className={styles.title}>Корзина</h2>
            <h2 style={{fontSize:"24px",marginTop:"15px"}}>Адрес доставки</h2>
            <h2 style={{fontSize:"18px", marginTop:"15px"}}>Улица, дом</h2>
            <AddressAutofill accessToken="pk.eyJ1IjoiYW5kcmV5YW50YWtvdiIsImEiOiJjbGZjbnRpNnQzY2N4M29yMHhkbzJjZ25wIn0.Yj7BV-EJ_lFEPqqgPXigow">
                <input required="true" autocomplete="address-line1" style={{marginTop:"15px",width:"300px"}} type="text" value={address} onChange={(event) => setAddress(event.target.value)} />          
            </AddressAutofill>
            <h2 style={{fontSize:"18px", marginTop:"15px"}}>Квартира</h2>
                <input autocomplete="address-line2" style={{marginTop:"15px",width:"300px"}} type="text" value={flat} onChange={(event) => setFlat(event.target.value)} />
            <br/>
            <button type="submit" style={{marginTop:"15px", padding :" 8px 15px", backgroundColor:"#F78888",borderRadius:"10px", color:"#e5e4e4"}}>Оформить заказ</button>
        </form>
            <p className={styles.total_price}>Общая стоимость: {total}руб.</p>
            <ul className={styles.product_list}>
                {dishes.map(item => (
                    <li key={item.id} className={styles.product_item}>
                        <img src={item.dish.photoURL}></img>
                        <p>{item.dish.name} - {item.dish.price}руб.</p>  
                        <button onClick={()=>handleRemoveFromCart(item.id)}>Удалить</button>       
                    </li>
                ))}
            </ul>
        </div>
        </>
    )}
    else{
        return(
        <>
        <Header title="Корзина"></Header>
        <div className={styles.container}>
        <h2 className={styles.title}>Корзина пуста</h2>
        </div>
        </>)
    }
}

export default Cart