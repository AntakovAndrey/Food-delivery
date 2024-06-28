import React, { useState, useEffect } from "react";
import { useParams } from 'react-router-dom';
import DishCard from "../components/DishCard/DishCard";
import Header from "../components/Header/Header";
import styles from "./Dishes.module.css"

function Dishes()
{
    const { id } = useParams()
    const [restaurant,setRestaurant] = useState()
    const [dishes, setDishes] = useState([])
    const [categories, setCategories] = useState([])

    

    useEffect(()=>{
        try{
            fetch(`${process.env.REACT_APP_API_URL}/Restaurant/GetDishesByRestaurantId/${id}`, {mode:'cors'})
            .then(response => response.json())
            .then(json => setDishes(json));
            fetch(`${process.env.REACT_APP_API_URL}/Restaurant/GetById/${id}`, {mode:'cors'})
            .then(response => response.json())
            .then(json => setRestaurant(json));
            fetch(`${process.env.REACT_APP_API_URL}/Restaurant/GetDishCategoriesByRestaurantId/${id}`, {mode:'cors'})
            .then(response => response.json())
            .then(json => setCategories(json));
        }
        catch(e)
        {
            console.log(e)
        }
    })

    if(!restaurant)
    {
        return(<><h3>Загрузка</h3></>)
    }
    return(
        <>
            <Header title={restaurant.name}/>
            <div className={styles.container}> 
                <div style={{backgroundImage:`URL(${restaurant.photoURL})`,
                    backgroundRepeat: "no-repeat",
                    backgroundSize: "cover",
                    backgroundPosition:"center"}} className={styles.restaurant_info_container}>
                    <div className={styles.restaurant_info}>
                        <h1>{restaurant.name}</h1>
                        <h2>{restaurant.rating}</h2>
                        <img src="../star.svg" width="20" height="20" alt="image description"></img>
                    </div>
                </div>

                <div className={styles.menu_container}>
                    {categories.map((category) => (
                        <div key={category.id}>
                            <h1 className={styles.category_name_title} >{category.name}</h1>
                            
                                <div className={styles.menu_category_container}>
                                    {dishes
                                    .filter((dishItem) => dishItem.categoryId === category.id)
                                    .map((dishItem) => (
                                        <DishCard id={dishItem.id} 
                                                name={dishItem.name} 
                                                imageUrl={dishItem.photoURL} 
                                                price={dishItem.price} 
                                                weight={dishItem.weight} 
                                                description={dishItem.description}/>
                                    ))}
                                </div>
                            
                        </div>
                    ))}
                </div>
            </div>
        </>
    )
}

export default Dishes