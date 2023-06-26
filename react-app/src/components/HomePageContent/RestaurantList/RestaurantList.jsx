import React,{useState,useEffect} from "react";
import Card from "../../Card/Card";
import styles from "./RestaurantList.module.css"

function RestaurantList(props)
{
    const[category,setCategory] = useState(props.category)
    const[restaurants,setRestaurants] = useState([])

    useEffect(()=>{
        try{
        fetch(process.env.REACT_APP_API_URL+"/Restaurant/GetByCategoryId/"+category.id, {mode:'cors'})
        .then(response => response.json())
        .then(json => setRestaurants(json))
        }
        catch(e)
        {
            console.log(e)
        }})
    
    return(
        <div className = {styles.container}>
            <div className="title">
                <h1>{category.name}</h1>
            </div>
            <div className={styles.category_list_container}>
            {restaurants.map((restaurantItem,restaurantIndex)=>(
                    <Card id={restaurantItem.id}
                    src={restaurantItem.photoURL} 
                    title={restaurantItem.name} 
                    categories={['Цельсия', 'Фаренгейт']} 
                    key={restaurantIndex}/>
            ))}
            </div>
        </div>
         
    )
}
export default RestaurantList;