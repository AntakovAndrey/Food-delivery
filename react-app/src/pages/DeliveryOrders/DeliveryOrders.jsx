import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import Header from '../../components/Header/Header'
import Modal from "../../components/Modal/Modal";

function DeliveryOrders()
{
    const[userId,setUserId] = useState('');
    const[orders,setOrders]=useState([]);
    const[orderDishes,setOrderDishes]=useState([])
    const navigate = useNavigate();
    const [isModal, setModal] = React.useState(false);
    const [currentOrder,setCurrentOrder] =useState('');

    function handleApplyToDeliver()
    {
        fetch(`${process.env.REACT_APP_API_URL}/Order/SetOrderDelivering/${currentOrder}`, {mode:'cors'})
        .then(response => response.json())
        .then(data => setOrderDishes(data)); 
        const response =  fetch(`${process.env.REACT_APP_API_URL}/Order/ApplyOrderToDeliver`, {
          method:"POST",
          mode:"cors",
          headers: {
            'Content-Type': 'application/json'
          },      
          body: JSON.stringify({
            orderId: currentOrder,
            deliverymanId: localStorage.getItem("id")
          })
        });
        setModal(false);
    }

    function showInfo(orderId)
    {
        setModal(true);   
        fetch(`${process.env.REACT_APP_API_URL}/Order/GetOrderDishes/${orderId}`, {mode:'cors'})
        .then(response => response.json())
        .then(data => setOrderDishes(data)); 
        setCurrentOrder(orderId);

    }

    useEffect(()=>{
        fetch(`${process.env.REACT_APP_API_URL}/Order/GetAll`, {mode:'cors'})
        .then(response => response.json())
        .then(data => setOrders(data));   
    },[])

    return(
        <>
            <Header title="Текущие заказы"></Header>
            <ul style={{width:"80%",marginLeft:"auto",marginRight:"auto"}}>
                {orders.map((order) => (
                    <li key={order.id} style={{marginTop:"15px"}}>
                        <div style={{width:"40%", display:"flex",justifyContent:"space-between"}}>
                            <p>{order.address}</p>
                            <p>{order.totalPrice} руб.</p>
                            <button onClick={()=>showInfo(order.id)}>Подробно</button>
                        </div>
                    
                    
                    </li>
                    
                ))}
                <Modal
                    isVisible={isModal}
                    title={process.env.REACT_APP_API_URL}
                    content={<ul>
                    {orderDishes.map(item => (
                        <li key={item.id}>
                            <img src={item.dish.photoURL}></img>
                            <p>{item.dish.name} - {item.dish.price}руб.</p>      
                        </li>
                        
                        ))}
                        <button style={{marginTop:"15px", padding :" 8px 15px", backgroundColor:"#F78888",borderRadius:"10px", color:"#e5e4e4"}} onClick={()=>handleApplyToDeliver()}>Доставить</button> 
                    </ul>}
                    footer={<button onClick={()=>setModal(false)}>Cancel</button>}
                    onClose={() => setModal(false)}
                />
            </ul>
        </>
    )
}
export default DeliveryOrders;