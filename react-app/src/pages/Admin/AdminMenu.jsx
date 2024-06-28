import React from "react";
import Header from "../../components/Header/Header";
import { Link } from "react-router-dom";

function AdminMenu()
{

    return(<>
        <Header title="Меню администратора"/>
        <Link to={"AdminMenu/Orders"}>Заказы</Link>
        <Link to={"AdminMenu/Orders"}>Рестораны</Link>
        <Link to={"AdminMenu/Orders"}>Блюда</Link>
        <Link to={"AdminMenu/Orders"}>Катерогии ресторана</Link>
        <Link to={"AdminMenu/Orders"}>Катерогии блюда</Link>
        <Link to={"/"}>Пользователи</Link>
        <Link to={"AdminMenu/Orders"}>Отзывы</Link>
    </>)
}

export default AdminMenu;