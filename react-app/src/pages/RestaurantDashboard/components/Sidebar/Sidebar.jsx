import React from "react";
import { Link, useLocation } from 'react-router-dom';
import styles from "./Sidebar.module.css"

function Sidebar()
{
    const location = useLocation();

    return(
        <div className={styles.sidebar}>
            <div className={styles.sidebar_menu}>
                <div className={styles.sidebar_menu_item + ' ' + (location.pathname === '/Dashboard' ? (styles.active) : '')}>
                    <Link to="/admin/dashboard">Панель</Link>
                </div>
                <div className={styles.sidebar_menu_item}> 
                    <Link to="/admin/orders" className={location.pathname === '/admin/orders' ? (styles.active) : ''}>Список заказов</Link>
                </div>
                <div className={styles.sidebar_menu_item}>                
                    <Link to="/admin/analytics" className={location.pathname === '/admin/analytics' ? (styles.active) : ''}>Аналитика</Link>
                </div>
                <div className={styles.sidebar_menu_item}>                
                    <Link to="/admin/dishes" className={location.pathname === '/admin/dishes' ? (styles.active) : ''}>Блюда</Link>
                </div>
                <div className={styles.sidebar_menu_item}>               
                    <Link to="/admin/calendar" className={location.pathname === '/admin/calendar' ? (styles.active) : ''}>Отзывы</Link>
                </div>
                <div className={styles.sidebar_menu_item}>
                    <Link to="/admin/invoices" className={location.pathname === '/admin/invoices' ? (styles.active) : ''}>Счет</Link>
                </div>
                <div className={styles.sidebar_menu_item}>
                    <Link to="/" className={location.pathname === '/' ? (styles.active) : ''}>На главную</Link>
                </div>
            </div>

            <div className={styles.board}>
                <p>Пожалуйста, организуйте меню нажав на кнопку ниже.</p>
                <img src="../illustration.svg" width="75" height="210" alt="image description"></img>
                <button>+Добавить меню</button>
            </div>
            
        </div>
    )
}
export default Sidebar;