//import Search from '../Search/Search'
import styles from'./Header.module.css'
import {Link} from 'react-router-dom'
import React, { useState } from 'react'

function Header(props)
{
    const[menu,setMenu]=useState([])
    useState(()=>{
        switch(localStorage.getItem("role"))
    {
      case "User":
        {
            setMenu(
            [{title:'Корзина',
            url:'../cart'},
            {title:'Заказы',
            url:'../orders'}])
            break;
        }
      case "RestaurantAdmin":
      {
        setMenu(
            [{title:'Актуальные заказы',
            url:'../CurrentOrders'},])
        break;
      }
      case "Deliveryman":
      {
          setMenu(
            [
            {title:'Заказы',
            url:'../deliveryOrders'}
            ])
        break;
      }
      default:
      {
          setMenu(
              [{title:'Корзина',
              url:'../cart'},
              {title:'Заказы',
              url:'../orders'}])
          break;
      }
    }
    })
    

    
    return(
        <div className={styles.header}>
            <Link className={styles.header_logo} to='/' alt="На главную">{props.title}</Link>
            <div className={styles.header_menu}>
                {menu.map((item,idx)=>(
                    <Link key={`menu item ${idx}`} to={item.url}>{item.title}</Link>
                ))}
                <Link to={'/login'}>Вход</Link>
            </div>
        </div>
    )
}

export default Header