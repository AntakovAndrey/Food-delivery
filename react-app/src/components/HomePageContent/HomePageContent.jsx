import React,{useState,useEffect} from "react";
import styles from "./HomePageContent.module.css"
import RestaurantList from "./RestaurantList/RestaurantList";

function HomePageContent()
{
    const [categories, setCategories] = useState(null);
    const [isLoading, setIsLoading] = useState(true);

    useEffect(() => {
      try{
        fetch(process.env.REACT_APP_API_URL+"/RestaurantCategory", {mode:'cors'})
        .then(response => response.json())
        .then(json => setCategories(json))
      }
      catch(e)
      {
        console.log(e)
      }
        setIsLoading(false)
        //requestCategories()
        //setCategories(requestCategories());
    }, [])

      if(categories!==null)
      {
        return(<div className={styles.container}>
          {categories.map((item,idx)=>(
              <RestaurantList category={item} key={idx}/>  
          ))}
        </div>)
      }
      else
      {
        return (<p>Загрузка</p>)
      }
}

export default HomePageContent;