import React,{useState,useEffect} from "react";
import Card from "../Card/Card";
import styles from "./HomePageContent.module.css"

function HomePageContent()
{
  /*async function makeAPICall(){
    try {
      const response = await fetch(process.env.REACT_APP_API_URL+"/GetAllRestaurants", {mode:'cors'});
      const data = await response.json();
      console.log({ data })
      setRestaurants(data)
      setIsLoading(false)
    }
    catch (e) {
      console.log(e)
    }
  }*/
  
  async function requestRestaurants(){
    try {
      const response = await fetch(process.env.REACT_APP_API_URL+"/GetAllRestaurants", {mode:'cors'});
      const data = await response.json();
      console.log({ data })
      setRestaurants(data)
      setIsLoading(false)
    }
    catch (e) {
      console.log(e)
    }
  }

    const [restaurants, setRestaurants] = useState(requestRestaurants);
    const [isLoading, setIsLoading] = useState(false);

  setRestaurants(requestRestaurants);


    useEffect(() => {
        
      if(restaurants===null)
      {
        setRestaurants(requestRestaurants());
        if(restaurants===null)
        {
          setIsLoading(true)
        }
      } 
    }, [])

      if(isLoading===false)
      {
        return(<div className={styles.container}>
            {restaurants.map((item,idx)=>(
                    <Card src='https://w.forfun.com/fetch/c9/c92dcab37e861605cf785b0632948e61.jpeg?h=900&r=0.5' 
                          title={item.date} 
                          categories={['Цельсия',item.temperatureC,'Фаренгейт',item.temperatureF]} 
                          key={idx}/>
                ))}
        </div>)
      }
      else
      {
        return (<p>Загрузка</p>)
      }
}

export default HomePageContent;