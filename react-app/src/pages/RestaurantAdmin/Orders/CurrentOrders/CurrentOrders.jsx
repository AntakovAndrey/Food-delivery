import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import Header from "../../../../components/Header/Header";
import Modal from "../../../../components/Modal/Modal";
function CurrentOrders()
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
    const[userId,setUserId] = useState('');
    const[orders,setOrders]=useState([]);
    const[orderDishes,setOrderDishes]=useState([])
    const navigate = useNavigate();
    const [isModal, setModal] = React.useState(false);
    const[currentOrder,setCurrentOrder]=useState('')
    
    function handleCooking()
    {
        const orderId = orders[0].id;
        fetch(`${process.env.REACT_APP_API_URL}/Order/SetOrderCooking/${currentOrder}`, {mode:'cors'})
        .then(response => response.json())
        .then(data => setOrderDishes(data)); 
    }
    function handleCooked()
    {
        const orderId = orders[0].id;
        fetch(`${process.env.REACT_APP_API_URL}/Order/SetOrderCooked/${currentOrder}`, {mode:'cors'})
        .then(response => response.json())
        .then(data => setOrderDishes(data)); 
    }

    function showInfo(orderId)
    {
        setCurrentOrder(orderId)
        setModal(true);   
        fetch(`${process.env.REACT_APP_API_URL}/Order/GetOrderDishes/${orderId}`, {mode:'cors'})
        .then(response => response.json())
        .then(data => setOrderDishes(data)); 

    }

    useEffect(()=>{
        
            const restaurantId =  localStorage.getItem('restaurantId');
            fetch(`${process.env.REACT_APP_API_URL}/Order/GetAllByRestaurantId/${restaurantId}`, {mode:'cors'})
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
                            <p>{itemStatusToString(order.orderStatus)}</p>
                            <button onClick={()=>showInfo(order.id)}>Подробно</button>
                        </div>
                    
                    
                    </li>
                    
                ))}
                <Modal
                    isVisible={isModal}
                    title={`Заказ`}
                    content={<ul>
                    {orderDishes.map(item => (
                        <li key={item.id}>
                            <img src={item.dish.photoURL}></img>
                            <p>{item.dish.name} - {item.dish.price}руб.</p>      
                        </li>
                        
                        ))}
                        <button style={{marginTop:"15px", padding :" 8px 15px", backgroundColor:"#F78888",borderRadius:"10px", color:"#e5e4e4"}} onClick={()=>handleCooking()}>Готовится</button> 
                        <button style={{marginTop:"15px", padding :" 8px 15px", backgroundColor:"#F78888",borderRadius:"10px", color:"#e5e4e4"}} onClick={()=>handleCooked()}>Приготовлен</button> 
                    </ul>}
                    footer={<button onClick={()=>setModal(false)}>Cancel</button>}
                    onClose={() => setModal(false)}
                />
            </ul>
        </>
    )
}
export default CurrentOrders;