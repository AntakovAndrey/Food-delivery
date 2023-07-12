import React, { useEffect } from "react";
import { useNavigate } from "react-router-dom";
import styles from "./CartItem.module.css"

function CartItem(props)
{
    const { id, name, price, weight, imageUrl} = props;
    const navigate = useNavigate();

    function handleRemoveFromCart() {
        const response = fetch(`${process.env.REACT_APP_API_URL}/Cart/RemoveDishFromCart/${id}`, {
            method: 'DELETE',
            mode: "cors",
            headers: { 'Content-Type': 'application/json' }
          });
        navigate('/')
    }
    return(
        <>
            
        </>

    )
}
export default CartItem;