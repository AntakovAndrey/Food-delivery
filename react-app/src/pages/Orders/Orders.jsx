import React, { useState,useEffect } from "react";
import { useNavigate } from "react-router-dom";
import styles from "./Orders.module.css"
import Header from "../../components/Header/Header";

function handleDelivered(orderId)
    {
        fetch(`${process.env.REACT_APP_API_URL}/Order/SetOrderDelivered/${orderId}`, {mode:'cors'})
    }

function Orders()
{
    

    function itemStatusToString(itemStatus)
    {
        switch (itemStatus) {
            case 0:
                return("Принят")
            case 1:
                return("Готовится")
            case 2:
                return("Готов")
            case 3:
                return("Доставляется")
            case 4:
                return("Доставлен")
            default:
                break;
        }
    }
    const navigate = useNavigate();
    const[orders,setOrders]=useState([])

    useEffect(()=>{
            const userId =  localStorage.getItem('id');
            fetch(`${process.env.REACT_APP_API_URL}/Order/GetAllByUserId/${userId}`, {mode:'cors'})
            .then(response => response.json())
            .then(data => setOrders(data));   
        
    },[])
    return(
        <>
        <Header title="Заказы"></Header>
            <div className={styles.container}>
                <ul className={styles.product_list}>
                    {orders.map(item => (
                        <li key={item.id} className={styles.product_item}>
                            <div style={{display:"flex",justifyContent:"space-between",width:"60%",marginTop:"25px"}}>
                                <p>{item.restaurant.name} - {item.address} - {
                                    itemStatusToString(item.orderStatus)
                                } - {item.totalPrice}руб.</p>    
                                <button style={{padding:"5px 10px",backgroundColor:"#F78888",color:"#e5e4e4",borderRadius:"10px"}} onClick={()=>handleDelivered(item.id)}>Заказ доставлен</button>
                            </div>
                              
                        </li>
                    ))}
                </ul>
            </div>
        </>
    )
}
export default Orders;