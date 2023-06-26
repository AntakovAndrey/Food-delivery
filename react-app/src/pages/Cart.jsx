import Header from "../components/Header/Header"
import React from "react"

function Cart()
{

    return(
        <>
            <Header title="Корзина"/>
            <div>
                <h2>Хавчевня</h2>
                <h3>18.05.2023</h3>
                <h3>В пути</h3>
                <div>
                    <p>Пиццуля</p>
                    <p>20 BYN</p>
                </div>
                <div>
                    <p>Пицца</p>
                    <p>20 BYN</p>
                </div>
                <div>
                    <p>Пицца</p>
                    <p>20 BYN</p>
                </div>
                <hr />
                <h1>60 BYN</h1>
            </div>
        </>
    )
}

export default Cart