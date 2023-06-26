import React, { useState } from "react";
import { Navigate, useNavigate } from "react-router-dom";
import Modal from "../Modal/Modal";
import styles from './DishCard.module.css'

function DishCard(props)
{
    const [isModal, setModal] = React.useState(false);
    const { id, name, price, weight, imageUrl,description } = props;
    const [quantity, setQuantity] = useState(0);

    const navigate = useNavigate();

    function handleAddToCart() {
        setQuantity(quantity + 1);
        const response = fetch(`${process.env.REACT_APP_API_URL}/AddItemToCart`, {
          method: 'POST',
          mode: "cors",
          headers: { 'Content-Type': 'application/json' },
          body: JSON.stringify({cartId:localStorage.getItem("cartId"),dishId:id})
        });
    
        if (response.ok) {
          const data = response.json();
          localStorage.setItem('accessToken', data.accessToken);
          localStorage.setItem('refreshToken', data.refreshToken);
        }

    }

    function handleRemoveFromCart() {
        setQuantity(quantity - 1);
    }

    return (
        <div className={styles.container} >
            <div onClick={() => setModal(true)}>
                <div className={styles.image_container}>
                    <img src={imageUrl} alt={name} />
                </div>
                
                <h2 className={styles.product_title}>{name}</h2>
                <div className={styles.description_container} >
                    <p>Вес: {weight}</p>
                    <p>Цена: {price}</p>
                </div>
            </div>
            
            <Modal
                isVisible={isModal}
                title={name}
                content={
                    <>
                        <h1 style={{fontSize:"24px"}}>{name}</h1>
                        <div className={styles.image_container} style={{marginTop:"15px"}}>
                            <img src={imageUrl} alt={name} />
                        </div>
                        <h3 style={{marginTop:"15px",fontSize:"18px"}}>{description}</h3>
                        
                        <h3 style={{fontSize:"24px", marginTop:"15px"}}>Цена: {price}руб.</h3>
                    </>
                }
                footer={<button onClick={()=>setModal(false)}>Закрыть</button>}
                onClose={() => setModal(false)}
            />

            {quantity === 0 ? (
                <button onClick={()=>{if(localStorage.getItem("cartId")===null){navigate('/login')}else{handleAddToCart()}}} className={styles.add_to_cart_button}>Добавить в корзину</button>
            ) : (
                <div className={styles.control_buttons_container}>
                    <button onClick={handleAddToCart} className={styles.control_button}>+</button>
                    <p>Количество: {quantity}</p>
                    <button onClick={handleRemoveFromCart} className={styles.control_button}>-</button>
                </div>
            )}
        </div>
    );
}

export default DishCard;